namespace ThePlayer
{
    partial class Mainform
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songsAusOrdnerHinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auswahlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leerenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastfmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autorisierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrobbelnAktivToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuellScrobbelnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lsvSongpools = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prgSongposition = new System.Windows.Forms.ProgressBar();
            this.lsvCurrentSongview = new System.Windows.Forms.ListView();
            this.btnPlayPause = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lsvPlaylist = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.auswahlToolStripMenuItem,
            this.playlistToolStripMenuItem,
            this.lastfmToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1092, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.songsAusOrdnerHinzufügenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.dateiToolStripMenuItem.Text = "Medien";
            // 
            // songsAusOrdnerHinzufügenToolStripMenuItem
            // 
            this.songsAusOrdnerHinzufügenToolStripMenuItem.Name = "songsAusOrdnerHinzufügenToolStripMenuItem";
            this.songsAusOrdnerHinzufügenToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.songsAusOrdnerHinzufügenToolStripMenuItem.Text = "Ordner hinzufügen";
            this.songsAusOrdnerHinzufügenToolStripMenuItem.Click += new System.EventHandler(this.songsAusOrdnerHinzufügenToolStripMenuItem_Click);
            // 
            // auswahlToolStripMenuItem
            // 
            this.auswahlToolStripMenuItem.Name = "auswahlToolStripMenuItem";
            this.auswahlToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.auswahlToolStripMenuItem.Text = "Auswahl";
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leerenToolStripMenuItem});
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.playlistToolStripMenuItem.Text = "Playlist";
            // 
            // leerenToolStripMenuItem
            // 
            this.leerenToolStripMenuItem.Name = "leerenToolStripMenuItem";
            this.leerenToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.leerenToolStripMenuItem.Text = "Leeren";
            this.leerenToolStripMenuItem.Click += new System.EventHandler(this.leerenToolStripMenuItem_Click);
            // 
            // lastfmToolStripMenuItem
            // 
            this.lastfmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autorisierenToolStripMenuItem,
            this.scrobbelnAktivToolStripMenuItem,
            this.manuellScrobbelnToolStripMenuItem});
            this.lastfmToolStripMenuItem.Name = "lastfmToolStripMenuItem";
            this.lastfmToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.lastfmToolStripMenuItem.Text = "Last.fm";
            // 
            // autorisierenToolStripMenuItem
            // 
            this.autorisierenToolStripMenuItem.Name = "autorisierenToolStripMenuItem";
            this.autorisierenToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.autorisierenToolStripMenuItem.Text = "Autorisieren";
            this.autorisierenToolStripMenuItem.Click += new System.EventHandler(this.autorisierenToolStripMenuItem_Click);
            // 
            // scrobbelnAktivToolStripMenuItem
            // 
            this.scrobbelnAktivToolStripMenuItem.Name = "scrobbelnAktivToolStripMenuItem";
            this.scrobbelnAktivToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.scrobbelnAktivToolStripMenuItem.Text = "Scrobbeln aktiv";
            // 
            // manuellScrobbelnToolStripMenuItem
            // 
            this.manuellScrobbelnToolStripMenuItem.Name = "manuellScrobbelnToolStripMenuItem";
            this.manuellScrobbelnToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.manuellScrobbelnToolStripMenuItem.Text = "Manuell scrobbeln";
            this.manuellScrobbelnToolStripMenuItem.Click += new System.EventHandler(this.manuellScrobbelnToolStripMenuItem_Click);
            // 
            // lsvSongpools
            // 
            this.lsvSongpools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSongpools.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lsvSongpools.Location = new System.Drawing.Point(12, 27);
            this.lsvSongpools.Name = "lsvSongpools";
            this.lsvSongpools.Size = new System.Drawing.Size(261, 293);
            this.lsvSongpools.TabIndex = 10;
            this.lsvSongpools.UseCompatibleStateImageBehavior = false;
            this.lsvSongpools.View = System.Windows.Forms.View.Details;
            this.lsvSongpools.SelectedIndexChanged += new System.EventHandler(this.lsvSongpools_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Poolname";
            this.columnHeader1.Width = 257;
            // 
            // prgSongposition
            // 
            this.prgSongposition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgSongposition.Location = new System.Drawing.Point(176, 662);
            this.prgSongposition.Maximum = 1000;
            this.prgSongposition.Name = "prgSongposition";
            this.prgSongposition.Size = new System.Drawing.Size(904, 25);
            this.prgSongposition.Step = 1;
            this.prgSongposition.TabIndex = 11;
            // 
            // lsvCurrentSongview
            // 
            this.lsvCurrentSongview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvCurrentSongview.FullRowSelect = true;
            this.lsvCurrentSongview.Location = new System.Drawing.Point(12, 326);
            this.lsvCurrentSongview.Name = "lsvCurrentSongview";
            this.lsvCurrentSongview.Size = new System.Drawing.Size(863, 332);
            this.lsvCurrentSongview.TabIndex = 13;
            this.lsvCurrentSongview.UseCompatibleStateImageBehavior = false;
            this.lsvCurrentSongview.View = System.Windows.Forms.View.Details;
            this.lsvCurrentSongview.DoubleClick += new System.EventHandler(this.lsvCurrentSongview_DoubleClick);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlayPause.Location = new System.Drawing.Point(12, 662);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.Size = new System.Drawing.Size(35, 25);
            this.btnPlayPause.TabIndex = 17;
            this.btnPlayPause.Text = "Play/Pause";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrev.Location = new System.Drawing.Point(53, 662);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(35, 25);
            this.btnPrev.TabIndex = 16;
            this.btnPrev.Text = "Prev";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Location = new System.Drawing.Point(135, 662);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(35, 25);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Location = new System.Drawing.Point(94, 662);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(35, 25);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lsvPlaylist
            // 
            this.lsvPlaylist.Location = new System.Drawing.Point(882, 27);
            this.lsvPlaylist.Name = "lsvPlaylist";
            this.lsvPlaylist.Size = new System.Drawing.Size(198, 630);
            this.lsvPlaylist.TabIndex = 18;
            this.lsvPlaylist.UseCompatibleStateImageBehavior = false;
            this.lsvPlaylist.View = System.Windows.Forms.View.List;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 687);
            this.Controls.Add(this.lsvPlaylist);
            this.Controls.Add(this.btnPlayPause);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lsvCurrentSongview);
            this.Controls.Add(this.prgSongposition);
            this.Controls.Add(this.lsvSongpools);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Mainform";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem songsAusOrdnerHinzufügenToolStripMenuItem;
        private System.Windows.Forms.ListView lsvSongpools;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ProgressBar prgSongposition;
        private System.Windows.Forms.ListView lsvCurrentSongview;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolStripMenuItem auswahlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leerenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastfmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autorisierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scrobbelnAktivToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manuellScrobbelnToolStripMenuItem;
        private System.Windows.Forms.ListView lsvPlaylist;
    }
}

