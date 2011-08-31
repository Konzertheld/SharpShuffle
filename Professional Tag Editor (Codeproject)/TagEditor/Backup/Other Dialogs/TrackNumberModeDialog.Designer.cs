namespace TagEditor
{
    partial class TrackNumberModeDialog
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
            this.lblChoose = new System.Windows.Forms.Label();
            this.rdbTotal = new System.Windows.Forms.RadioButton();
            this.rdbSingle = new System.Windows.Forms.RadioButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblSingle = new System.Windows.Forms.Label();
            this.chbSetHaveID3v1 = new System.Windows.Forms.CheckBox();
            this.chbSetHaveID3v2 = new System.Windows.Forms.CheckBox();
            this.grbTrackType = new System.Windows.Forms.GroupBox();
            this.hlpHelp = new System.Windows.Forms.HelpProvider();
            this.grbTrackType.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChoose
            // 
            this.lblChoose.AutoSize = true;
            this.lblChoose.Location = new System.Drawing.Point(6, 16);
            this.lblChoose.Name = "lblChoose";
            this.lblChoose.Size = new System.Drawing.Size(172, 13);
            this.lblChoose.TabIndex = 0;
            this.lblChoose.Text = "Choose one of track number types:";
            // 
            // rdbTotal
            // 
            this.rdbTotal.AutoSize = true;
            this.rdbTotal.Checked = true;
            this.rdbTotal.Location = new System.Drawing.Point(33, 42);
            this.rdbTotal.Name = "rdbTotal";
            this.rdbTotal.Size = new System.Drawing.Size(61, 17);
            this.rdbTotal.TabIndex = 1;
            this.rdbTotal.TabStop = true;
            this.rdbTotal.Text = "#/Total";
            this.rdbTotal.UseVisualStyleBackColor = true;
            // 
            // rdbSingle
            // 
            this.rdbSingle.AutoSize = true;
            this.rdbSingle.Location = new System.Drawing.Point(33, 78);
            this.rdbSingle.Name = "rdbSingle";
            this.rdbSingle.Size = new System.Drawing.Size(32, 17);
            this.rdbSingle.TabIndex = 2;
            this.rdbSingle.Text = "#";
            this.rdbSingle.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(100, 44);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 13);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "ex: 1/10, 2/10, 3/10  ...";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(83, 184);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(164, 184);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblSingle
            // 
            this.lblSingle.AutoSize = true;
            this.lblSingle.Location = new System.Drawing.Point(100, 80);
            this.lblSingle.Name = "lblSingle";
            this.lblSingle.Size = new System.Drawing.Size(69, 13);
            this.lblSingle.TabIndex = 6;
            this.lblSingle.Text = "ex: 1, 2, 3  ...";
            // 
            // chbSetHaveID3v1
            // 
            this.chbSetHaveID3v1.AutoSize = true;
            this.chbSetHaveID3v1.Location = new System.Drawing.Point(12, 128);
            this.chbSetHaveID3v1.Name = "chbSetHaveID3v1";
            this.chbSetHaveID3v1.Size = new System.Drawing.Size(184, 17);
            this.chbSetHaveID3v1.TabIndex = 7;
            this.chbSetHaveID3v1.Text = "Set HaveTag for ID3v1 if needed";
            this.chbSetHaveID3v1.UseVisualStyleBackColor = true;
            // 
            // chbSetHaveID3v2
            // 
            this.chbSetHaveID3v2.AutoSize = true;
            this.chbSetHaveID3v2.Location = new System.Drawing.Point(12, 151);
            this.chbSetHaveID3v2.Name = "chbSetHaveID3v2";
            this.chbSetHaveID3v2.Size = new System.Drawing.Size(184, 17);
            this.chbSetHaveID3v2.TabIndex = 8;
            this.chbSetHaveID3v2.Text = "Set HaveTag for ID3v2 if needed";
            this.chbSetHaveID3v2.UseVisualStyleBackColor = true;
            // 
            // grbTrackType
            // 
            this.grbTrackType.Controls.Add(this.lblChoose);
            this.grbTrackType.Controls.Add(this.rdbTotal);
            this.grbTrackType.Controls.Add(this.rdbSingle);
            this.grbTrackType.Controls.Add(this.lblSingle);
            this.grbTrackType.Controls.Add(this.lblTotal);
            this.grbTrackType.Location = new System.Drawing.Point(12, 12);
            this.grbTrackType.Name = "grbTrackType";
            this.grbTrackType.Size = new System.Drawing.Size(231, 110);
            this.grbTrackType.TabIndex = 9;
            this.grbTrackType.TabStop = false;
            // 
            // hlpHelp
            // 
            this.hlpHelp.HelpNamespace = "Help.chm";
            // 
            // TrackNumberModeDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(251, 219);
            this.Controls.Add(this.grbTrackType);
            this.Controls.Add(this.chbSetHaveID3v2);
            this.Controls.Add(this.chbSetHaveID3v1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.hlpHelp.SetHelpKeyword(this, "Auto Track Number");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "TrackNumberModeDialog";
            this.hlpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Track Number Mode Selection";
            this.grbTrackType.ResumeLayout(false);
            this.grbTrackType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoose;
        private System.Windows.Forms.RadioButton rdbTotal;
        private System.Windows.Forms.RadioButton rdbSingle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSingle;
        private System.Windows.Forms.CheckBox chbSetHaveID3v1;
        private System.Windows.Forms.CheckBox chbSetHaveID3v2;
        private System.Windows.Forms.GroupBox grbTrackType;
        private System.Windows.Forms.HelpProvider hlpHelp;
    }
}