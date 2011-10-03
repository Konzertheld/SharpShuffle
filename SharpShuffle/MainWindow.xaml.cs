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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            List<Song> songs = new List<Song>();
            songs.Add(new Song());
            songs.Add(new Song());
            songs.Add(new Song());
            
            lsvView.Items.Add(songs[0]);
        }
    }
}
