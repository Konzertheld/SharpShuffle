namespace TagInfoControls
{
    partial class SimpleTextInformation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtSet = new System.Windows.Forms.FilterTextBox();
            this.txtTrack = new System.Windows.Forms.FilterTextBox();
            this.lblSet = new System.Windows.Forms.Label();
            this.txtAlbum = new System.Windows.Forms.TextBox();
            this.txtArtist = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTrack = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblAlbum = new System.Windows.Forms.Label();
            this.lblArtist = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbGenre = new TagInfoControls.GenreBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.erpWarning = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSet
            // 
            this.txtSet.AcceptableCharacters = "/";
            this.txtSet.AcceptsLetter = false;
            this.txtSet.AcceptsPunctuation = false;
            this.txtSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSet.Location = new System.Drawing.Point(206, 0);
            this.txtSet.Name = "txtSet";
            this.txtSet.ShowToolTip = true;
            this.txtSet.Size = new System.Drawing.Size(40, 20);
            this.txtSet.TabIndex = 3;
            this.txtSet.Tag = "TPOS";
            this.tlpMain.SetToolTip(this.txtSet, "Part of set. ex. \'1/2\'");
            this.txtSet.ToolTipMessage = "You can only write number here with \'/\'";
            this.txtSet.ToolTipTitle = "Unacceptable Character";
            // 
            // txtTrack
            // 
            this.txtTrack.AcceptableCharacters = " /";
            this.txtTrack.AcceptsLetter = false;
            this.txtTrack.AcceptsPunctuation = false;
            this.txtTrack.Location = new System.Drawing.Point(62, 0);
            this.txtTrack.Name = "txtTrack";
            this.txtTrack.ShowToolTip = true;
            this.txtTrack.Size = new System.Drawing.Size(55, 20);
            this.txtTrack.TabIndex = 1;
            this.txtTrack.Tag = "TRCK";
            this.tlpMain.SetToolTip(this.txtTrack, "Track number of song in album. ex \'1/10\', \'1\'");
            this.txtTrack.ToolTipMessage = "You can only write number here with \'/\'";
            this.txtTrack.ToolTipTitle = "Unacceptable Character";
            this.txtTrack.Validating += new System.ComponentModel.CancelEventHandler(this.txtTrack_Validating);
            // 
            // lblSet
            // 
            this.lblSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSet.AutoSize = true;
            this.lblSet.Location = new System.Drawing.Point(174, 3);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(26, 13);
            this.lblSet.TabIndex = 2;
            this.lblSet.Text = "&Set:";
            // 
            // txtAlbum
            // 
            this.txtAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlbum.Location = new System.Drawing.Point(62, 78);
            this.txtAlbum.Name = "txtAlbum";
            this.txtAlbum.Size = new System.Drawing.Size(184, 20);
            this.txtAlbum.TabIndex = 9;
            this.txtAlbum.Tag = "TALB";
            this.tlpMain.SetToolTip(this.txtAlbum, "Album name");
            // 
            // txtArtist
            // 
            this.txtArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArtist.Location = new System.Drawing.Point(62, 52);
            this.txtArtist.Name = "txtArtist";
            this.txtArtist.Size = new System.Drawing.Size(184, 20);
            this.txtArtist.TabIndex = 7;
            this.txtArtist.Tag = "TPE1";
            this.tlpMain.SetToolTip(this.txtArtist, "Artist name");
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(62, 26);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(184, 20);
            this.txtTitle.TabIndex = 5;
            this.txtTitle.Tag = "TIT2";
            this.tlpMain.SetToolTip(this.txtTitle, "Song title");
            // 
            // lblTrack
            // 
            this.lblTrack.AutoSize = true;
            this.lblTrack.Location = new System.Drawing.Point(3, 3);
            this.lblTrack.Name = "lblTrack";
            this.lblTrack.Size = new System.Drawing.Size(38, 13);
            this.lblTrack.TabIndex = 0;
            this.lblTrack.Text = "T&rack:";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(3, 134);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(39, 13);
            this.lblGenre.TabIndex = 12;
            this.lblGenre.Text = "&Genre:";
            // 
            // lblAlbum
            // 
            this.lblAlbum.AutoSize = true;
            this.lblAlbum.Location = new System.Drawing.Point(3, 81);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.Size = new System.Drawing.Size(39, 13);
            this.lblAlbum.TabIndex = 8;
            this.lblAlbum.Text = "Al&bum:";
            // 
            // lblArtist
            // 
            this.lblArtist.AutoSize = true;
            this.lblArtist.Location = new System.Drawing.Point(3, 55);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.Size = new System.Drawing.Size(33, 13);
            this.lblArtist.TabIndex = 6;
            this.lblArtist.Text = "&Artist:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "&Title:";
            // 
            // cmbGenre
            // 
            this.cmbGenre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGenre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Genre = "";
            this.cmbGenre.GenreIndex = 255;
            this.cmbGenre.ID3Version = Tags.ID3.ID3Versions.ID3v1;
            this.cmbGenre.Location = new System.Drawing.Point(62, 130);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(184, 21);
            this.cmbGenre.Sorted = true;
            this.cmbGenre.TabIndex = 13;
            this.cmbGenre.Tag = "TCON";
            this.tlpMain.SetToolTip(this.cmbGenre, "Genre of song");
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(3, 107);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 10;
            this.lblYear.Text = "&Year:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(62, 104);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(55, 20);
            this.txtYear.TabIndex = 11;
            this.txtYear.Tag = "TYER";
            this.tlpMain.SetToolTip(this.txtYear, "Release year of file");
            // 
            // txtComment
            // 
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(62, 157);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(184, 20);
            this.txtComment.TabIndex = 15;
            this.txtComment.Tag = "TENC";
            this.tlpMain.SetToolTip(this.txtComment, "Comment");
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(3, 160);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(54, 13);
            this.lblComment.TabIndex = 14;
            this.lblComment.Text = "C&omment:";
            // 
            // erpWarning
            // 
            this.erpWarning.ContainerControl = this;
            // 
            // SimpleTextInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.txtSet);
            this.Controls.Add(this.txtTrack);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.txtAlbum);
            this.Controls.Add(this.txtArtist);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTrack);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblTitle);
            this.Name = "SimpleTextInformation";
            this.Size = new System.Drawing.Size(246, 180);
            ((System.ComponentModel.ISupportInitialize)(this.erpWarning)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FilterTextBox txtSet;
        private System.Windows.Forms.FilterTextBox txtTrack;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.TextBox txtAlbum;
        private System.Windows.Forms.TextBox txtArtist;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTrack;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblAlbum;
        private System.Windows.Forms.Label lblArtist;
        private System.Windows.Forms.Label lblTitle;
        private GenreBox cmbGenre;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.ToolTip tlpMain;
        private System.Windows.Forms.ErrorProvider erpWarning;
    }
}
