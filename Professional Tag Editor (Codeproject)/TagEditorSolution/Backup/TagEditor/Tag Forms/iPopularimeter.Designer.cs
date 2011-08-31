namespace TagEditor
{
    partial class iPopularimeter
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
            this.ictPopularimeter = new TagInfoControls.Popularimeter();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(280, 293);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(361, 293);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(477, 293);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(442, 293);
            // 
            // ictPopularimeter
            // 
            this.ictPopularimeter.Location = new System.Drawing.Point(12, 12);
            this.ictPopularimeter.Name = "ictPopularimeter";
            this.ictPopularimeter.Size = new System.Drawing.Size(497, 271);
            this.ictPopularimeter.TabIndex = 5;
            // 
            // iPopularimeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(518, 328);
            this.Controls.Add(this.ictPopularimeter);
            this.hlpHelp.SetHelpKeyword(this, "Popularimeter");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "iPopularimeter";
            this.hlpHelp.SetShowHelp(this, true);
            this.Controls.SetChildIndex(this.ictPopularimeter, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.Popularimeter ictPopularimeter;
    }
}
