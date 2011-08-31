namespace TagEditor
{
    partial class aBranding
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
            this.actBranding = new TagInfoControls.aContentBranding();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(58, 258);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(139, 258);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(255, 258);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(220, 258);
            // 
            // actBranding
            // 
            this.actBranding.Location = new System.Drawing.Point(12, 12);
            this.actBranding.Name = "actBranding";
            this.actBranding.Size = new System.Drawing.Size(274, 238);
            this.actBranding.TabIndex = 5;
            // 
            // aBranding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(296, 293);
            this.Controls.Add(this.actBranding);
            this.hlpHelp.SetHelpKeyword(this, "Attach Picture (Wma)");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "aBranding";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Picture";
            this.Controls.SetChildIndex(this.actBranding, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.aContentBranding actBranding;
    }
}
