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
            vlcalt.Volume = 100;
            vlcalt.MediaPlayerPositionChanged += new AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEventHandler(vlcalt_MediaPlayerPositionChanged);
            LoadSongpools();

            // Load songview columns
            foreach (string col in Program.GlobalConfig.CurrentSongviewColumns)
            {
                lsvCurrentSongview.Columns.Add(col);
            }
        }

        private void LoadSongpools()
        {
            lsvSongpools.Items.Clear();
            foreach (KeyValuePair<string, Songpool> k in Program.GlobalConfig.Songpools)
            {
                lsvSongpools.Items.Add(k.Key);
            }
        }


        void vlcalt_MediaPlayerPositionChanged(object sender, AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEvent e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                prgSongposition.Value = (int)Math.Ceiling(vlcalt.Position * 1000);
            });

        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            try
            {
                if (vlcalt.Playing)
                    vlcalt.pause();
                else
                    vlcalt.play();
            }
            catch (Exception E) { vlcalt.play(); }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            vlcalt.stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            vlcalt.playlistNext();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            vlcalt.playlistPrev();
        }

        private void songsAusOrdnerHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Audiofilepoolmanager().ShowDialog();
        }

        private void lsvSongpools_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.ActivePlayer.CurrentView = new Songpool();
            foreach (ListViewItem item in lsvSongpools.SelectedItems)
            {
                //TODO: Get lists for filters here (artists, genres...)
                foreach (Song song in Program.GlobalConfig.Songpools[item.Text].getSongs())
                {
                    Program.ActivePlayer.CurrentView.AddSong(song);
                }
            }
            lsvCurrentSongview.Items.Clear();
            foreach (Song song in Program.ActivePlayer.CurrentView.getSongs())
            {
                ListViewItem lvi = new ListViewItem(song.getInformation(Program.GlobalConfig.CurrentSongviewColumns[0]));
                for (int i = 1; i < Program.GlobalConfig.CurrentSongviewColumns.Count; i++)
                    lvi.SubItems.Add(song.getInformation(Program.GlobalConfig.CurrentSongviewColumns[i]));
                lsvCurrentSongview.Items.Add(lvi);
            }
        }

        private void lsvCurrentSongview_DoubleClick(object sender, EventArgs e)
        {
            foreach (int i in lsvCurrentSongview.SelectedIndices)
            {
                AddSongToPlaylist(Program.ActivePlayer.CurrentView.getSongs()[i]);
            }
            try
            {
                if (!vlcalt.Playing)
                    vlcalt.play();
            }
            catch (Exception E) { vlcalt.play(); }
        }

        private void AddSongToPlaylist(Song song)
        {
            Program.ActivePlayer.Playlist.AddSong(song);
            lstPlaylist.Items.Add(song.getInformation("Artist") + " - " + song.getInformation("Title"));
            //TODO: Recognize all audiofile pools and let the user choose
            vlcalt.addTarget(Program.GlobalConfig.Audiofilepools[Program.GlobalConfig.Audiofilepools.Keys.First()].findSong(song).Filepath, null, AXVLC.VLCPlaylistMode.VLCPlayListAppend, 0);
        }

        private void PlayPlaylist()
        {
            try
            {
                vlcalt.stop();
            }
            catch (Exception E) { }
            
            vlcalt.playlistClear();

            foreach (Song song in Program.ActivePlayer.Playlist.getSongs())
            {
                
            }
            vlcalt.play();
        }

        private void leerenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vlcalt.playlistClear();
            Program.ActivePlayer.Playlist = new Songpool();
            lstPlaylist.Items.Clear();
        }
    }
}
