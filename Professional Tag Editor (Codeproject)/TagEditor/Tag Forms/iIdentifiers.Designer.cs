namespace TagEditor
{
    partial class iIdentifiers
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ictFileIdentifier = new TagInfoControls.FileIdentifiers();
            this.ictMusicCDIdentifier = new TagInfoControls.MusicCDIdentifier();
            this.grpIdentifier = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpIdentifier.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(275, 392);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(356, 392);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(472, 392);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(437, 392);
            // 
            // ictFileIdentifier
            // 
            this.ictFileIdentifier.Location = new System.Drawing.Point(6, 19);
            this.ictFileIdentifier.Name = "ictFileIdentifier";
            this.ictFileIdentifier.Size = new System.Drawing.Size(480, 171);
            this.ictFileIdentifier.TabIndex = 0;
            // 
            // ictMusicCDIdentifier
            // 
            this.ictMusicCDIdentifier.Location = new System.Drawing.Point(12, 19);
            this.ictMusicCDIdentifier.Name = "ictMusicCDIdentifier";
            this.ictMusicCDIdentifier.Size = new System.Drawing.Size(471, 130);
            this.ictMusicCDIdentifier.TabIndex = 0;
            // 
            // grpIdentifier
            // 
            this.grpIdentifier.Controls.Add(this.ictFileIdentifier);
            this.grpIdentifier.Location = new System.Drawing.Point(12, 12);
            this.grpIdentifier.Name = "grpIdentifier";
            this.grpIdentifier.Size = new System.Drawing.Size(489, 197);
            this.grpIdentifier.TabIndex = 5;
            this.grpIdentifier.TabStop = false;
            this.grpIdentifier.Text = "File Identifier";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ictMusicCDIdentifier);
            this.groupBox1.Location = new System.Drawing.Point(12, 215);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 160);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music CD Identifier";
            // 
            // iIdentifiers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(513, 427);
            this.Controls.Add(this.grpIdentifier);
            this.Controls.Add(this.groupBox1);
            this.hlpHelp.SetHelpKeyword(this, "Identifier (Mp3)");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "iIdentifiers";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Identifiers";
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.grpIdentifier, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.grpIdentifier.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.FileIdentifiers ictFileIdentifier;
        private TagInfoControls.MusicCDIdentifier ictMusicCDIdentifier;
        private System.Windows.Forms.GroupBox grpIdentifier;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
