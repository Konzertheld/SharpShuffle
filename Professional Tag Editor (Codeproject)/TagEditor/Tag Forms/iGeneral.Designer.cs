namespace TagEditor
{
    partial class iGeneral
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
            this.ictV1 = new TagInfoControls.SimpleTextInformation();
            this.ictV2 = new TagInfoControls.SimpleTextInformation();
            this.chbHaveV1 = new System.Windows.Forms.CheckBox();
            this.chbHaveV2 = new System.Windows.Forms.CheckBox();
            this.grpV1 = new System.Windows.Forms.GroupBox();
            this.btnCopyFrom2 = new System.Windows.Forms.Button();
            this.grpV2 = new System.Windows.Forms.GroupBox();
            this.btnCopyFrom1 = new System.Windows.Forms.Button();
            this.grpV1.SuspendLayout();
            this.grpV2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(312, 289);
            this.btnOK.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(393, 289);
            this.btnCancel.TabIndex = 4;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(509, 289);
            this.btnNext.TabIndex = 6;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(474, 289);
            this.btnPrevious.TabIndex = 5;
            // 
            // ictV1
            // 
            this.ictV1.Enabled = false;
            this.ictV1.ID3Version = Tags.ID3.ID3Versions.ID3v1;
            this.ictV1.Location = new System.Drawing.Point(6, 42);
            this.ictV1.Name = "ictV1";
            this.ictV1.Size = new System.Drawing.Size(246, 180);
            this.ictV1.TabIndex = 1;
            // 
            // ictV2
            // 
            this.ictV2.Enabled = false;
            this.ictV2.Location = new System.Drawing.Point(6, 42);
            this.ictV2.Name = "ictV2";
            this.ictV2.Size = new System.Drawing.Size(246, 180);
            this.ictV2.TabIndex = 1;
            // 
            // chbHaveV1
            // 
            this.chbHaveV1.AutoSize = true;
            this.chbHaveV1.Location = new System.Drawing.Point(6, 19);
            this.chbHaveV1.Name = "chbHaveV1";
            this.chbHaveV1.Size = new System.Drawing.Size(87, 17);
            this.chbHaveV1.TabIndex = 0;
            this.chbHaveV1.Text = "Have ID3 v1";
            this.chbHaveV1.UseVisualStyleBackColor = true;
            this.chbHaveV1.CheckedChanged += new System.EventHandler(this.chbHaveV1_CheckedChanged);
            // 
            // chbHaveV2
            // 
            this.chbHaveV2.AutoSize = true;
            this.chbHaveV2.Location = new System.Drawing.Point(6, 19);
            this.chbHaveV2.Name = "chbHaveV2";
            this.chbHaveV2.Size = new System.Drawing.Size(87, 17);
            this.chbHaveV2.TabIndex = 0;
            this.chbHaveV2.Text = "Have ID3 v2";
            this.chbHaveV2.UseVisualStyleBackColor = true;
            this.chbHaveV2.CheckedChanged += new System.EventHandler(this.chbHaveV2_CheckedChanged);
            // 
            // grpV1
            // 
            this.grpV1.Controls.Add(this.ictV1);
            this.grpV1.Controls.Add(this.chbHaveV1);
            this.grpV1.Controls.Add(this.btnCopyFrom2);
            this.grpV1.Location = new System.Drawing.Point(12, 12);
            this.grpV1.Name = "grpV1";
            this.grpV1.Size = new System.Drawing.Size(261, 261);
            this.grpV1.TabIndex = 1;
            this.grpV1.TabStop = false;
            this.grpV1.Text = "ID3 v1";
            // 
            // btnCopyFrom2
            // 
            this.btnCopyFrom2.Enabled = false;
            this.btnCopyFrom2.Location = new System.Drawing.Point(6, 228);
            this.btnCopyFrom2.Name = "btnCopyFrom2";
            this.btnCopyFrom2.Size = new System.Drawing.Size(103, 23);
            this.btnCopyFrom2.TabIndex = 2;
            this.btnCopyFrom2.Text = "Copy from v2";
            this.tlpMain.SetToolTip(this.btnCopyFrom2, "Copy information from ID3v2");
            this.btnCopyFrom2.UseVisualStyleBackColor = true;
            this.btnCopyFrom2.Click += new System.EventHandler(this.btnCopyFrom2_Click);
            // 
            // grpV2
            // 
            this.grpV2.Controls.Add(this.chbHaveV2);
            this.grpV2.Controls.Add(this.ictV2);
            this.grpV2.Controls.Add(this.btnCopyFrom1);
            this.grpV2.Location = new System.Drawing.Point(279, 12);
            this.grpV2.Name = "grpV2";
            this.grpV2.Size = new System.Drawing.Size(265, 261);
            this.grpV2.TabIndex = 2;
            this.grpV2.TabStop = false;
            this.grpV2.Text = "ID3 v2";
            // 
            // btnCopyFrom1
            // 
            this.btnCopyFrom1.Enabled = false;
            this.btnCopyFrom1.Location = new System.Drawing.Point(6, 228);
            this.btnCopyFrom1.Name = "btnCopyFrom1";
            this.btnCopyFrom1.Size = new System.Drawing.Size(103, 23);
            this.btnCopyFrom1.TabIndex = 2;
            this.btnCopyFrom1.Text = "Copy from v1";
            this.tlpMain.SetToolTip(this.btnCopyFrom1, "Copy information from ID3v1");
            this.btnCopyFrom1.UseVisualStyleBackColor = true;
            this.btnCopyFrom1.Click += new System.EventHandler(this.btnCopyFrom1_Click);
            // 
            // iGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(550, 324);
            this.Controls.Add(this.grpV1);
            this.Controls.Add(this.grpV2);
            this.hlpHelp.SetHelpKeyword(this, "General");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "iGeneral";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "General Info";
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.grpV2, 0);
            this.Controls.SetChildIndex(this.grpV1, 0);
            this.grpV1.ResumeLayout(false);
            this.grpV1.PerformLayout();
            this.grpV2.ResumeLayout(false);
            this.grpV2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.SimpleTextInformation ictV1;
        private TagInfoControls.SimpleTextInformation ictV2;
        private System.Windows.Forms.CheckBox chbHaveV1;
        private System.Windows.Forms.CheckBox chbHaveV2;
        private System.Windows.Forms.GroupBox grpV1;
        private System.Windows.Forms.GroupBox grpV2;
        private System.Windows.Forms.Button btnCopyFrom2;
        private System.Windows.Forms.Button btnCopyFrom1;
    }
}
