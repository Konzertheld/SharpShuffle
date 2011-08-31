namespace TagEditor
{
    partial class iFiles
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
            this.ictFiles = new TagInfoControls.AttachedFiles();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(186, 295);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(267, 295);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(383, 295);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(348, 295);
            // 
            // ictFiles
            // 
            this.ictFiles.Location = new System.Drawing.Point(12, 12);
            this.ictFiles.Name = "ictFiles";
            this.ictFiles.Size = new System.Drawing.Size(406, 267);
            this.ictFiles.TabIndex = 5;
            // 
            // iFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(424, 330);
            this.Controls.Add(this.ictFiles);
            this.hlpHelp.SetHelpKeyword(this, "Attach File");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "iFiles";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Attached Files";
            this.Controls.SetChildIndex(this.ictFiles, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.AttachedFiles ictFiles;
    }
}
