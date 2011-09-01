using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThePlayer
{
    public partial class Mainform : Form
    {

        delegate MethodInvoker bang(string zeugs);

        public Mainform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //vlcalt.addTarget(@"E:\Musik\Endsortierung\Blur - Song 2.mp3", null, AXVLC.VLCPlaylistMode.VLCPlayListAppend, 0);
            //vlcalt.addTarget(@"E:\Musik\Endsortierung\John Farnham - Youre The Voice.mp3", null, AXVLC.VLCPlaylistMode.VLCPlayListReplace, 0);
            //vlcalt.Volume = 100;
            //vlcalt.play();

            //vlcalt.MediaPlayerPositionChanged += new AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEventHandler(vlcalt_MediaPlayerPositionChanged);


            LoadSongpools();
        }

        private void LoadSongpools()
        {
            lsvSongpools.Items.Clear();
            foreach (KeyValuePair<string,Songpool> k in Program.GlobalConfig.Songpools)
            {
                lsvSongpools.Items.Add(k.Key);
            }
        }
        

        void vlcalt_MediaPlayerPositionChanged(object sender, AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEvent e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                label1.Text = (vlcalt.Position * vlcalt.Length / 1000).ToString();
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vlcalt.Playing)
                vlcalt.pause();
            else
                vlcalt.play();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vlcalt.stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vlcalt.playlistNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vlcalt.playlistPrev();
        }

        private void songsAusOrdnerHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Audiofilepoolmanager().ShowDialog();
        }
    }
}
