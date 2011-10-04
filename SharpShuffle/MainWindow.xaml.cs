using System;
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

namespace SharpShuffle
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Song> songs = new ObservableCollection<Song>();
        ObservableCollection<Song> playlist = new ObservableCollection<Song>();

        Player player;

        public MainWindow()
        {
            InitializeComponent();
            player = new Player();
            songs = new System.Collections.ObjectModel.ObservableCollection<Song>(Startup.ActiveDB.LoadSongs("Endsortierung"));
            playlist = new ObservableCollection<Song>(player.Playlist);
            

            lsvFilterPool.ItemsSource = Startup.ActiveDB.PoolList();
            
            lsvView.ItemsSource = songs;
            foreach (SONGMETA meta in Enum.GetValues(typeof(SONGMETA)))
            {
                ((GridView)(lsvView.View)).Columns.Add(new GridViewColumn());
                ((GridView)(lsvView.View)).Columns.Last().Header = meta.ToString();
                ((GridView)(lsvView.View)).Columns.Last().DisplayMemberBinding = new Binding(meta.ToString());
            }

            lsvPlaylist.ItemsSource = playlist;
            ((GridView)(lsvPlaylist.View)).Columns.Add(new GridViewColumn());
            ((GridView)(lsvPlaylist.View)).Columns.Add(new GridViewColumn());
            ((GridView)(lsvPlaylist.View)).Columns[0].DisplayMemberBinding = new Binding("Artists");
            ((GridView)(lsvPlaylist.View)).Columns[1].DisplayMemberBinding = new Binding("Title");
            
        }

        private void RefreshPlaylist()
        {
            playlist = new ObservableCollection<Song>(player.Playlist);
            lsvPlaylist.ItemsSource = playlist;
            lsvPlaylist.Items.Refresh();
        }

        private void lsvView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            songs.RemoveAt(0);
        }

        private void lsvView_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void lsvView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            player.Playlist.Add(lsvView.SelectedItem as Song);
            RefreshPlaylist();
            player.PlayPlaylist();
        }

        private void lsvView_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
