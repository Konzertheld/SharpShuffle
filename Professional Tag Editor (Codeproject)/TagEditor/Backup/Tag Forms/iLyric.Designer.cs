namespace TagEditor
{
    partial class iLyric
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
            this.tbcLyricType = new System.Windows.Forms.TabControl();
            this.tbpNonSynchronizedLyric = new System.Windows.Forms.TabPage();
            this.ictNLyric = new TagInfoControls.CommentAndLyric();
            this.tbpSynchronizedLyric = new System.Windows.Forms.TabPage();
            this.ictSLyric = new TagInfoControls.Lyric();
            this.tbcLyricType.SuspendLayout();
            this.tbpNonSynchronizedLyric.SuspendLayout();
            this.tbpSynchronizedLyric.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(350, 372);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(431, 372);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(547, 372);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(512, 372);
            // 
            // tbcLyricType
            // 
            this.tbcLyricType.Controls.Add(this.tbpNonSynchronizedLyric);
            this.tbcLyricType.Controls.Add(this.tbpSynchronizedLyric);
            this.tbcLyricType.Location = new System.Drawing.Point(12, 12);
            this.tbcLyricType.Name = "tbcLyricType";
            this.tbcLyricType.SelectedIndex = 0;
            this.tbcLyricType.Size = new System.Drawing.Size(566, 348);
            this.tbcLyricType.TabIndex = 5;
            // 
            // tbpNonSynchronizedLyric
            // 
            this.tbpNonSynchronizedLyric.CausesValidation = false;
            this.tbpNonSynchronizedLyric.Controls.Add(this.ictNLyric);
            this.tbpNonSynchronizedLyric.Location = new System.Drawing.Point(4, 22);
            this.tbpNonSynchronizedLyric.Name = "tbpNonSynchronizedLyric";
            this.tbpNonSynchronizedLyric.Padding = new System.Windows.Forms.Padding(3);
            this.tbpNonSynchronizedLyric.Size = new System.Drawing.Size(558, 322);
            this.tbpNonSynchronizedLyric.TabIndex = 0;
            this.tbpNonSynchronizedLyric.Text = "Non Synchronized Lyric";
            // 
            // ictNLyric
            // 
            this.ictNLyric.ControlType = TagInfoControls.ControlTypes.UnSynchronizedLyric;
            this.ictNLyric.Location = new System.Drawing.Point(6, 6);
            this.ictNLyric.Name = "ictNLyric";
            this.ictNLyric.Size = new System.Drawing.Size(546, 310);
            this.ictNLyric.TabIndex = 0;
            // 
            // tbpSynchronizedLyric
            // 
            this.tbpSynchronizedLyric.Controls.Add(this.ictSLyric);
            this.tbpSynchronizedLyric.Location = new System.Drawing.Point(4, 22);
            this.tbpSynchronizedLyric.Name = "tbpSynchronizedLyric";
            this.tbpSynchronizedLyric.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSynchronizedLyric.Size = new System.Drawing.Size(558, 322);
            this.tbpSynchronizedLyric.TabIndex = 1;
            this.tbpSynchronizedLyric.Text = "Synchronized Lyric";
            // 
            // ictSLyric
            // 
            this.ictSLyric.Location = new System.Drawing.Point(6, 6);
            this.ictSLyric.Name = "ictSLyric";
            this.ictSLyric.Size = new System.Drawing.Size(546, 308);
            this.ictSLyric.TabIndex = 6;
            // 
            // iLyric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(588, 407);
            this.Controls.Add(this.tbcLyricType);
            this.hlpHelp.SetHelpKeyword(this, "Lyric");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "iLyric";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Lyric";
            this.Controls.SetChildIndex(this.tbcLyricType, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.tbcLyricType.ResumeLayout(false);
            this.tbpNonSynchronizedLyric.ResumeLayout(false);
            this.tbpSynchronizedLyric.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcLyricType;
        private System.Windows.Forms.TabPage tbpNonSynchronizedLyric;
        private System.Windows.Forms.TabPage tbpSynchronizedLyric;
        private TagInfoControls.Lyric ictSLyric;
        private TagInfoControls.CommentAndLyric ictNLyric;
    }
}
