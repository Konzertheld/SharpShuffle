﻿using System;
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
            LoadSongpools();
            Program.ActivePlayer.PositionChanged += new PlayerPositionChangedHandler(ActivePlayer_PositionChanged);

            // Load songview columns
            foreach (string col in Program.GlobalConfig.CurrentSongviewColumns)
            {
                lsvCurrentSongview.Columns.Add(col);
            }
        }

        void ActivePlayer_PositionChanged(double position)
        {
            this.Invoke((MethodInvoker)delegate
            {
                prgSongposition.Value = (int)Math.Ceiling(position * 1000.0);
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
            Program.ActivePlayer.NextSong();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            //TODO: Implement previous.
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
            if (!Program.ActivePlayer.isPlaying) Program.ActivePlayer.PlayPlaylist();
        }

        private void AddSongToPlaylist(Song song)
        {
            Program.ActivePlayer.Playlist.AddSong(song);
            lstPlaylist.Items.Add(song.ToString());
        }

        private void PlayPlaylist()
        {
            Program.ActivePlayer.PlayPlaylist();
        }

        private void leerenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.ActivePlayer.Playlist = new Songpool();
            lstPlaylist.Items.Clear();
        }
    }
}
