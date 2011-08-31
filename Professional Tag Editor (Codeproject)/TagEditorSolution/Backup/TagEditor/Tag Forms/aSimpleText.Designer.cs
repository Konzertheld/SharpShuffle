namespace TagEditor
{
    partial class aSimpleText
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
            this.actSimpleText = new TagInfoControls.aSimpleText();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(8, 304);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(89, 304);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(205, 304);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(170, 304);
            // 
            // actSimpleText
            // 
            this.actSimpleText.Location = new System.Drawing.Point(12, 12);
            this.actSimpleText.Name = "actSimpleText";
            this.actSimpleText.ShowRating = true;
            this.actSimpleText.Size = new System.Drawing.Size(220, 284);
            this.actSimpleText.TabIndex = 5;
            // 
            // aSimpleText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(246, 339);
            this.Controls.Add(this.actSimpleText);
            this.hlpHelp.SetHelpKeyword(this, "Basic Information");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "aSimpleText";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Basic Information";
            this.Controls.SetChildIndex(this.actSimpleText, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.aSimpleText actSimpleText;
    }
}
