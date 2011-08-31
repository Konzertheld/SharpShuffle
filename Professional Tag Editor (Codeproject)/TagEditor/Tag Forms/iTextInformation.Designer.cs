namespace TagEditor
{
    partial class iTextInformation
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
            this.ictTextInformation = new TagInfoControls.TextInformation();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(328, 357);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(409, 357);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(525, 357);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(490, 357);
            // 
            // ictTextInformation
            // 
            this.ictTextInformation.Location = new System.Drawing.Point(12, 12);
            this.ictTextInformation.MaximumSize = new System.Drawing.Size(541, 333);
            this.ictTextInformation.MinimumSize = new System.Drawing.Size(541, 333);
            this.ictTextInformation.Name = "ictTextInformation";
            this.ictTextInformation.Size = new System.Drawing.Size(541, 333);
            this.ictTextInformation.TabIndex = 5;
            // 
            // iTextInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(566, 392);
            this.Controls.Add(this.ictTextInformation);
            this.hlpHelp.SetHelpKeyword(this, "Text Information (Mp3)");
            this.Name = "iTextInformation";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Text Information";
            this.Controls.SetChildIndex(this.ictTextInformation, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.TextInformation ictTextInformation;
    }
}
