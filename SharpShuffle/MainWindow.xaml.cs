﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Windows.Controls.Primitives;

namespace SharpShuffle
{
    delegate void FakeDelegate();

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Song> songs = new ObservableCollection<Song>();

        Player player;

        bool[] hiddenColumns;

        public MainWindow()
        {
            InitializeComponent();
            player = new Player();
            player.PositionChanged += new PlayerPositionChangedHandler(player_PositionChanged);
            try
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                hiddenColumns = (bool[])bf.Deserialize(new System.IO.FileStream("c:\\cols.dat", System.IO.FileMode.Open));
            }
            catch (Exception) { }

            songs = new System.Collections.ObjectModel.ObservableCollection<Song>(Startup.ActiveDB.LoadSongs("Endsortierung"));

            lsvFilterPool.ItemsSource = Startup.ActiveDB.PoolList();

            dgrView.ItemsSource = songs;
            dgrView.AutoGeneratedColumns += new EventHandler(dgrView_AutoGeneratedColumns);

            lsvPlaylist.ItemsSource = player.Playlist;
            ((GridView)(lsvPlaylist.View)).Columns.Add(new GridViewColumn());
            ((GridView)(lsvPlaylist.View)).Columns.Add(new GridViewColumn());
            ((GridView)(lsvPlaylist.View)).Columns[0].DisplayMemberBinding = new Binding("Artists");
            ((GridView)(lsvPlaylist.View)).Columns[1].DisplayMemberBinding = new Binding("Title");
        }

        void player_PositionChanged(double position)
        {
            prgPosition.Dispatcher.Invoke(new FakeDelegate(delegate
            {
                prgPosition.Value = 100 - position * 100;
            }));
        }

        private void RefreshPlaylist()
        {
            //playlist = new ObservableCollection<Song>(player.Playlist);
            //lsvPlaylist.ItemsSource = playlist;
            //lsvPlaylist.Items.Refresh();
        }

        void dgrView_AutoGeneratedColumns(object sender, EventArgs e)
        {
            if (hiddenColumns == null)
            {
                hiddenColumns = new bool[dgrView.Columns.Count];
                for (int i = 0; i < hiddenColumns.Count(); i++) hiddenColumns[i] = true;
            }

            for (int i = 0; i < dgrView.Columns.Count; i++)
            {
                MenuItem item = new MenuItem();
                item.Header = dgrView.Columns[i].Header;
                item.IsChecked = hiddenColumns[i];
                menSpalten.Items.Add(item);
                item.Click += new RoutedEventHandler(dgrViewColumn_Click);
                item.Checked += new RoutedEventHandler(dgrViewColumn_Checked);
                item.Unchecked += new RoutedEventHandler(dgrViewColumn_Unchecked);
                item.Tag = i;
                dgrView.Columns[i].Visibility = (hiddenColumns[i]) ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            }
        }

        void dgrViewColumn_Unchecked(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            dgrView.Columns[(int)item.Tag].Visibility = System.Windows.Visibility.Collapsed;
            hiddenColumns[(int)item.Tag] = false;
        }

        void dgrViewColumn_Checked(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            dgrView.Columns[(int)item.Tag].Visibility = System.Windows.Visibility.Visible;
            hiddenColumns[(int)item.Tag] = true;
        }

        void dgrViewColumn_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            item.IsChecked = !item.IsChecked;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bf.Serialize(new System.IO.FileStream("c:\\cols.dat", System.IO.FileMode.Create), hiddenColumns);
        }

        private void dgrView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            player.Playlist.Add(dgrView.SelectedItem as Song);
            //RefreshPlaylist();
            player.PlayPlaylist();
        }

        private void dgrView_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // Ugly hack suggested by Microsoft due to lack of feature
            dgrView.Dispatcher.BeginInvoke(new FakeDelegate(delegate { ((Song)e.Row.Item).Update(); }));
        }
    }
}
