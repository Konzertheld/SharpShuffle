namespace TagEditor
{
    partial class iComments
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
            this.ictComments = new TagInfoControls.CommentAndLyric();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(313, 281);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(394, 281);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(510, 281);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(475, 281);
            // 
            // ictComments
            // 
            this.ictComments.Location = new System.Drawing.Point(12, 12);
            this.ictComments.Name = "ictComments";
            this.ictComments.Size = new System.Drawing.Size(535, 258);
            this.ictComments.TabIndex = 5;
            // 
            // iComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(551, 316);
            this.Controls.Add(this.ictComments);
            this.hlpHelp.SetHelpKeyword(this, "Comments");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "iComments";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Comments";
            this.Controls.SetChildIndex(this.ictComments, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.CommentAndLyric ictComments;
    }
}
