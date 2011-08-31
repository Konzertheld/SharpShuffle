using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThePlayer__WF_
{
    public partial class Form1 : Form
    {

        delegate MethodInvoker bang(string zeugs);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vlcalt.addTarget(@"E:\Musik\Endsortierung\Blur - Song 2.mp3", null, AXVLC.VLCPlaylistMode.VLCPlayListAppend, 0);
            vlcalt.addTarget(@"E:\Musik\Endsortierung\John Farnham - Youre The Voice.mp3", null, AXVLC.VLCPlaylistMode.VLCPlayListReplace, 0);
            vlcalt.Volume = 100;
            vlcalt.play();

            vlcalt.MediaPlayerPositionChanged += new AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEventHandler(vlcalt_MediaPlayerPositionChanged);



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
    }
}
