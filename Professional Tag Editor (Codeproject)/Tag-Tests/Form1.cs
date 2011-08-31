using System;
using System.Windows.Forms;
using System.IO;
using Tags;
using Tags.ID3;
using Tags.ASF;
using Tags.ID3.ID3v2Frames.TextFrames;
using System.Collections.Generic;
using System.Linq;

namespace Tag_Tests
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this awesome line simply gets all the files specified in the beginning
            string[] audiofiles = "*.mp3|*.ogg|*.wma|*.asf".Split('|').SelectMany(filter => Directory.GetFiles(@"E:\Musik\Endsortierung\Alternative, Rock, Metal\", filter, SearchOption.AllDirectories)).ToArray();
            List<Song> songs = new List<Song>();
            Audiofile af;
            Audiopool ap = new Audiopool();
            foreach (string audiofile in audiofiles)
            {
                af = new Audiofile(audiofile);
                ap.AddSong(af.Track);
            }
            foreach (Song song in songs)
            {
                listView1.Items.Add(new ListViewItem(new string[] { song.GetField("Artist"), song.GetField("Title"), song.GetField("Album"), song.GetField("Genre") }));
            }
            List<Song> s = ap.findSongs(new List<MP_Filter> {
            {new MP_Filter("Artist",MP_COMPARETYPE.equal,"The sounds") },
            {new MP_Filter("Album",MP_COMPARETYPE.similar,"dying to say this") } }).getSongs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            last.fm_Test.Scrobbel.Scrobbeln(textBox1.Text, textBox2.Text, new DateTime(2010, 08, 30, int.Parse(textBox3.Text), int.Parse(textBox4.Text),0));
        }
    }
}
