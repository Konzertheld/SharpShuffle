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
        private PlayerView UI;

        public Mainform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UI = new PlayerView();

            LoadPools();
            Program.ActivePlayer.PositionChanged += new PlayerPositionChangedHandler(ActivePlayer_PositionChanged);
            Program.ActivePlayer.PlaylistChanged += new PlaylistChangedHandler(ActivePlayer_PlaylistChanged);
            Program.ActivePlayer.SongChanged += new SongChangedHandler(ActivePlayer_SongChanged);

            // Load songview columns
            foreach (string col in Program.ActivePlayerUI.Columns)
            {
                lsvCurrentSongview.Columns.Add(col);
            }
        }

        void ActivePlayer_SongChanged(Song song)
        {
            this.Invoke((MethodInvoker)delegate
            {
                foreach (ListViewItem item in lsvPlaylist.Items)
                {
                    item.ForeColor = Color.Black;
                }
                lsvPlaylist.Items[Program.ActivePlayer.FindSongInPlaylist(song)].ForeColor = Color.IndianRed;
            });
        }

        void ActivePlayer_PlaylistChanged(string[] newList)
        {
            lsvPlaylist.Items.Clear();
            for (int i = 0; i < newList.Count(); i++)
                lsvPlaylist.Items.Add(new ListViewItem(newList[i]));
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
            foreach (String s in Program.ActiveDatabase.LoadSongpools())
                lsvSongpools.Items.Add(s);
        }

        #region Playlist control buttons
        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (Program.ActivePlayer.PlaybackState == TP_PLAYBACKSTATE.Stopped)
                Program.ActivePlayer.PlayPlaylist();
            else
                Program.ActivePlayer.PlayPause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Program.ActivePlayer.Stop();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Program.ActivePlayer.NextSong();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            Program.ActivePlayer.PrevSong();
        }
        #endregion

        #region Menu calls
        private void songsAusOrdnerHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Audiofilepoolmanager().ShowDialog();
            LoadPools();
        }

        private void leerenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ActivePlayer.ClearPlaylist();
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
        #endregion

        private void lsvSongpools_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: Get lists for subfilters here (artists, genres...) so the following is based on them and not directly on the pools

            // Refresh songs based on selected pools
            string[] indices = new string[lsvSongpools.SelectedItems.Count];
            for (int i = 0; i < lsvSongpools.SelectedItems.Count; i++)
                indices[i] = lsvSongpools.SelectedItems[i].Text;
            Program.ActivePlayerUI.ChangePools(indices);

            // Display the refreshed songlist
            lsvCurrentSongview.Items.Clear();
            foreach (string[] song in Program.ActivePlayerUI.ViewSongs())
                lsvCurrentSongview.Items.Add(new ListViewItem(song));
        }

        private void lsvCurrentSongview_DoubleClick(object sender, EventArgs e)
        {
            SongTrigger();
        }

        private void lsvCurrentSongview_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SongTrigger();
        }

        private void SongTrigger()
        {
            foreach (int i in lsvCurrentSongview.SelectedIndices)
            {
                //TODO: Make the keys configurable
                //TODO: Add both in combination with Alt, ignoring the don't-play-this-song-limits for the selection
                if ((Control.ModifierKeys & Keys.Shift) != Keys.None)
                { //TODO: Play song immediately.

                }
                else if ((Control.ModifierKeys & Keys.Control) != Keys.None)
                { //TODO: Play this song next even if random is active = Queue. Maybe replace with multiple playlists.

                }
                else
                { // Add the selection to the playlist
                    Program.ActivePlayer.AddSongToPlaylist(Program.ActivePlayerUI.getSongFromView(i));
                }
            }
        }
    }
}
