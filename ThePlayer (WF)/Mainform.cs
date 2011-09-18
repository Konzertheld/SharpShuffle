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
            LoadPools();
            Program.ActivePlayer.PositionChanged += new PlayerPositionChangedHandler(ActivePlayer_PositionChanged);

            // Load songview columns
            foreach (string col in Program.ActivePlayer.UI.Columns)
            {
                lsvCurrentSongview.Columns.Add(col);
            }
        }

        void ActivePlayer_PositionChanged(double position)
        {
            this.Invoke((MethodInvoker)delegate
            {
                prgSongposition.Value = (position > 1) ? 1000 : (int)Math.Ceiling(position * 1000.0);
            });
        }

        private void LoadPools()
        {
            lsvSongpools.Items.Clear();
            foreach (String s in Program.Songpools.Keys)
            {
                lsvSongpools.Items.Add(s);
            }
            Program.ActivePlayer.Audiosources.Clear();
            foreach (Audiofilepool a in Program.Audiofilepools.Values)
            {
                Program.ActivePlayer.Audiosources.Add(a);
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
            
            LoadPools();
        }

        private void lsvSongpools_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Get lists for subfilters here (artists, genres...) so the following is based on them and not directly on the pools

            // Refresh songs based on selected pools
            string[] indices = new string[lsvSongpools.SelectedItems.Count];
            for (int i = 0; i < lsvSongpools.SelectedItems.Count; i++)
                indices[i] = lsvSongpools.SelectedItems[i].Text;
            Program.ActivePlayer.UI.ChangePools(indices);
            
            // Display the refreshed songlist
            lsvCurrentSongview.Items.Clear();
            foreach (string[] song in Program.ActivePlayer.UI.ViewSongs())
                lsvCurrentSongview.Items.Add(new ListViewItem(song));
        }

        private void lsvCurrentSongview_DoubleClick(object sender, EventArgs e)
        {
            foreach (int i in lsvCurrentSongview.SelectedIndices)
            {
                //AddSongToPlaylist(Program.ActivePlayer.CurrentView.getSongs()[i]);
            }
            if (!Program.ActivePlayer.IsPlaying)
            {
                lsvPlaylist.Items[Program.ActivePlayer.PlayPlaylist()].ForeColor = Color.Red;
            }
        }

        private void AddSongToPlaylist(Song song)
        {
            //TODO: Make duplicates available if the user wants it
            if (Program.ActivePlayer.AddSongToPlaylist(song))
                lsvPlaylist.Items.Add(song.ToString());
        }

        private void PlayPlaylist()
        {
            Program.ActivePlayer.PlayPlaylist();
        }

        private void leerenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ActivePlayer.ClearPlaylist();
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
