namespace TagEditor
{
    partial class iPictures
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
            this.ictPictures = new TagInfoControls.AttachedPictures();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(467, 288);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(548, 288);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(664, 288);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(629, 288);
            // 
            // ictPictures
            // 
            this.ictPictures.Location = new System.Drawing.Point(12, 12);
            this.ictPictures.Name = "ictPictures";
            this.ictPictures.Size = new System.Drawing.Size(685, 269);
            this.ictPictures.TabIndex = 5;
            // 
            // iPictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(705, 323);
            this.Controls.Add(this.ictPictures);
            this.hlpHelp.SetHelpKeyword(this, "Attach Picture (Mp3)");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "iPictures";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Attached Pictures";
            this.Controls.SetChildIndex(this.ictPictures, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.AttachedPictures ictPictures;

    }
}
