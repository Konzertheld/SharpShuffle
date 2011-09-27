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
            List<Database.Song> songs = new List<Database.Song>();
            songs.Add(new Database.Song());
            songs.Add(new Database.Song());
            songs.Add(new Database.Song());
            songs[0].setInformation(Database.Song.META_ALBUM, "sdkjsdkfjk");
            songs[0].setInformation(Database.Song.META_BPM, "123");
            songs[1].setInformation(Database.Song.META_COMMENT, "uiokhjkhjk");
            songs[1].setInformation(Database.Song.META_TITLE, "wetet");
            songs[2].setInformation(Database.Song.META_ALBUM, "sdkjsdkfjk");
            songs[2].setInformation(Database.Song.META_TRACK, "3");
            songs[2].setInformation(Database.Song.META_VERSION, "sdfdfcvcv");
            lsvView.Items.Add(songs[0]);
        }
    }
}
