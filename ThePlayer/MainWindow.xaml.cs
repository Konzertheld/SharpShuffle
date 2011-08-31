using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace ThePlayer
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TODO: WPF Shit. Where should this be stored?
        Player p;
        Audiofilepool afp;

        public MainWindow()
        {
            InitializeComponent();
            p = new Player();
        }

        private void AddSongsFromFolder(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.ShowDialog();
            afp = new Audiofilepool(fbd.SelectedPath);
            p.Playlist = afp.createSongpool();
        }
        
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
        
        }

        




    }
}
