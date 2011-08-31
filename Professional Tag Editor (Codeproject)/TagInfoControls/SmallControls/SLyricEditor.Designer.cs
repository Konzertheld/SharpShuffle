namespace TagInfoControls.SmallControls
{
    partial class SLyricEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SLyricEditor));
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.ctrlMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.tlpMain.SetToolTip(this.txtDescription, "Description of text");
            this.txtDescription.Validated += new System.EventHandler(this.txtDescription_Validated);
            // 
            // lnbLanguage
            // 
            this.tlpMain.SetToolTip(this.lnbLanguage, "Language for text");
            this.lnbLanguage.Validated += new System.EventHandler(this.lnbLanguage_Validated);
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(3, 80);
            this.txtText.Size = new System.Drawing.Size(360, 154);
            this.txtText.TabIndex = 8;
            this.tlpMain.SetToolTip(this.txtText, "Text of frame");
            this.txtText.Validated += new System.EventHandler(this.txtText_Validated);
            this.txtText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtText_KeyDown);
            // 
            // rdbRTL
            // 
            this.rdbRTL.Location = new System.Drawing.Point(338, 53);
            this.rdbRTL.TabIndex = 7;
            this.tlpMain.SetToolTip(this.rdbRTL, "Right to left language");
            // 
            // rdbLTR
            // 
            this.rdbLTR.Location = new System.Drawing.Point(310, 53);
            this.rdbLTR.TabIndex = 6;
            this.tlpMain.SetToolTip(this.rdbLTR, "Left to right language");
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Other",
            "Lyric",
            "Text Transcription",
            "Part Name",
            "Event",
            "Chord",
            "Pop up Information"});
            this.cmbType.Location = new System.Drawing.Point(69, 53);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(202, 21);
            this.cmbType.TabIndex = 5;
            this.cmbType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbType_Validating);
            this.cmbType.Validated += new System.EventHandler(this.cmbType_Validated);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(0, 56);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Type:";
            // 
            // ctrlMediaPlayer
            // 
            this.ctrlMediaPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlMediaPlayer.Enabled = true;
            this.ctrlMediaPlayer.Location = new System.Drawing.Point(3, 240);
            this.ctrlMediaPlayer.Name = "ctrlMediaPlayer";
            this.ctrlMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ctrlMediaPlayer.OcxState")));
            this.ctrlMediaPlayer.Size = new System.Drawing.Size(360, 44);
            this.ctrlMediaPlayer.TabIndex = 9;
            // 
            // SLyricEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.ctrlMediaPlayer);
            this.Name = "SLyricEditor";
            this.Size = new System.Drawing.Size(363, 285);
            this.EnabledChanged += new System.EventHandler(this.SLyricEditor_EnabledChanged);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.rdbLTR, 0);
            this.Controls.SetChildIndex(this.rdbRTL, 0);
            this.Controls.SetChildIndex(this.ctrlMediaPlayer, 0);
            this.Controls.SetChildIndex(this.txtText, 0);
            this.Controls.SetChildIndex(this.lnbLanguage, 0);
            this.Controls.SetChildIndex(this.lblType, 0);
            this.Controls.SetChildIndex(this.lblLanguage, 0);
            this.Controls.SetChildIndex(this.cmbType, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private AxWMPLib.AxWindowsMediaPlayer ctrlMediaPlayer;
    }
}
