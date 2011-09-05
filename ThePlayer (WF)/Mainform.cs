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
        public Mainform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSongpools();
            Program.ActivePlayer.PositionChanged += new PlayerPositionChangedHandler(ActivePlayer_PositionChanged);

            // Load songview columns
            foreach (META_IDENTIFIERS col in Program.GlobalConfig.CurrentSongviewColumns)
            {
                lsvCurrentSongview.Columns.Add(col.ToString());
            }
        }

        void ActivePlayer_PositionChanged(double position)
        {
            this.Invoke((MethodInvoker)delegate
            {
                prgSongposition.Value = (position > 1) ? 1000 : (int)Math.Ceiling(position * 1000.0);
            });
        }

        private void LoadSongpools()
        {
            lsvSongpools.Items.Clear();
            foreach (KeyValuePair<string, Songpool> k in Program.GlobalConfig.Songpools)
            {
                lsvSongpools.Items.Add(k.Key);
            }
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            Program.ActivePlayer.PlayPause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Program.ActivePlayer.Stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clearPlaylistColor();
            lsvPlaylist.Items[Program.ActivePlayer.NextSong()].ForeColor = Color.Red;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            clearPlaylistColor();
            lsvPlaylist.Items[Program.ActivePlayer.PrevSong()].ForeColor = Color.Red;
        }

        private void songsAusOrdnerHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Audiofilepoolmanager().ShowDialog();
            LoadSongpools();
        }

        private void lsvSongpools_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Error handling for empty pools
            Program.ActivePlayer.CurrentView = new Songpool();
            foreach (ListViewItem item in lsvSongpools.SelectedItems)
            {
                //TODO: Get lists for filters here (artists, genres...)
                foreach (Song song in Program.GlobalConfig.Songpools[item.Text].getSongs(new List<META_IDENTIFIERS>(new META_IDENTIFIERS[2] { META_IDENTIFIERS.Artist, META_IDENTIFIERS.Title })))
                {
                    Program.ActivePlayer.CurrentView.AddSong(song);
                }
            }
            lsvCurrentSongview.Items.Clear();
            //TODO: Seriously, sorting does not belong HERE and not hardcoded for sure.
            foreach (Song song in Program.ActivePlayer.CurrentView.getSongs(new List<META_IDENTIFIERS>(new META_IDENTIFIERS[2] { META_IDENTIFIERS.Artist, META_IDENTIFIERS.Title })))
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
            if (!Program.ActivePlayer.isPlaying)
            {
                lsvPlaylist.Items[Program.ActivePlayer.PlayPlaylist()].ForeColor = Color.Red;
            }
        }

        private void AddSongToPlaylist(Song song)
        {
            //TODO: Make duplicates available if the user wants it
            if (Program.ActivePlayer.Playlist.AddSong(song))
                lsvPlaylist.Items.Add(song.ToString());
        }

        private void PlayPlaylist()
        {
            Program.ActivePlayer.PlayPlaylist();
        }

        private void leerenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ActivePlayer.Playlist = new Songpool();
            lsvPlaylist.Items.Clear();
        }

        private void autorisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("URL für Webautorisierung in die Zwischenablage kopieren?", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Scrobbel.LastFmAuthReady += new LastFmAuthReadyHandler(Scrobbel_LastFmAuthReady);
                Scrobbel.AuthorizeCall();
            }
            else
                MessageBox.Show("Autorisierung abgebrochen.");
        }

        void Scrobbel_LastFmAuthReady(string url, Lastfm.Session session)
        {
            Clipboard.SetText(url);
            MessageBox.Show("OK klicken, wenn Webautorisierung fertig.");
            Scrobbel.AuthorizeDo(session);
        }

        private void manuellScrobbelnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManualScrobbling f = new frmManualScrobbling();
            f.Show();
        }

        private void clearPlaylistColor()
        {
            foreach (ListViewItem item in lsvPlaylist.Items)
            {
                item.ForeColor = Color.Black;
            }
        }
    }
}
