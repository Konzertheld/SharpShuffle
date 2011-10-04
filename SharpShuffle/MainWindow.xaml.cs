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

namespace SharpShuffle
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Collections.ObjectModel.ObservableCollection<Song> songs = new System.Collections.ObjectModel.ObservableCollection<Song>();

        public MainWindow()
        {
            InitializeComponent();

            lsvFilterPool.ItemsSource = Startup.ActiveDB.PoolList();

            songs = new System.Collections.ObjectModel.ObservableCollection<Song>(Startup.ActiveDB.LoadSongs("Endsortierung"));
            lsvView.ItemsSource = songs;
            foreach (SONGMETA meta in Enum.GetValues(typeof(SONGMETA)))
            {
                ((GridView)(lsvView.View)).Columns.Add(new GridViewColumn());
                ((GridView)(lsvView.View)).Columns.Last().Header = meta.ToString();
                ((GridView)(lsvView.View)).Columns.Last().DisplayMemberBinding = new Binding(meta.ToString());
            }
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
            MessageBox.Show(Startup.ActiveDB.GetFileForSong(lsvView.Items[lsvView.SelectedIndex] as Song));
        }

        private void lsvView_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
