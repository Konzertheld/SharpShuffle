namespace TagEditor
{
    partial class aIdentifier
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
            this.txtMCDI = new TagInfoControls.SmallControls.HexBoxEx();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.grpMCDI = new System.Windows.Forms.GroupBox();
            this.grpUniqueFileIdentifier = new System.Windows.Forms.GroupBox();
            this.grpMCDI.SuspendLayout();
            this.grpUniqueFileIdentifier.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(110, 315);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(191, 315);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(307, 315);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(272, 315);
            // 
            // txtMCDI
            // 
            this.txtMCDI.Data = null;
            this.txtMCDI.Location = new System.Drawing.Point(6, 19);
            this.txtMCDI.Name = "txtMCDI";
            this.txtMCDI.Size = new System.Drawing.Size(312, 123);
            this.txtMCDI.TabIndex = 5;
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Location = new System.Drawing.Point(6, 19);
            this.txtIdentifier.Multiline = true;
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.Size = new System.Drawing.Size(312, 112);
            this.txtIdentifier.TabIndex = 6;
            // 
            // grpMCDI
            // 
            this.grpMCDI.Controls.Add(this.txtMCDI);
            this.grpMCDI.Location = new System.Drawing.Point(12, 12);
            this.grpMCDI.Name = "grpMCDI";
            this.grpMCDI.Size = new System.Drawing.Size(324, 148);
            this.grpMCDI.TabIndex = 7;
            this.grpMCDI.TabStop = false;
            this.grpMCDI.Text = "Music CD Identifier";
            // 
            // grpUniqueFileIdentifier
            // 
            this.grpUniqueFileIdentifier.Controls.Add(this.txtIdentifier);
            this.grpUniqueFileIdentifier.Location = new System.Drawing.Point(12, 166);
            this.grpUniqueFileIdentifier.Name = "grpUniqueFileIdentifier";
            this.grpUniqueFileIdentifier.Size = new System.Drawing.Size(324, 137);
            this.grpUniqueFileIdentifier.TabIndex = 8;
            this.grpUniqueFileIdentifier.TabStop = false;
            this.grpUniqueFileIdentifier.Text = "Unique File Identifier";
            // 
            // aIdentifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(348, 350);
            this.Controls.Add(this.grpMCDI);
            this.Controls.Add(this.grpUniqueFileIdentifier);
            this.hlpHelp.SetHelpKeyword(this, "Identifier (Wma)");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "aIdentifier";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Identifier";
            this.Controls.SetChildIndex(this.grpUniqueFileIdentifier, 0);
            this.Controls.SetChildIndex(this.grpMCDI, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.grpMCDI.ResumeLayout(false);
            this.grpUniqueFileIdentifier.ResumeLayout(false);
            this.grpUniqueFileIdentifier.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.SmallControls.HexBoxEx txtMCDI;
        private System.Windows.Forms.TextBox txtIdentifier;
        private System.Windows.Forms.GroupBox grpMCDI;
        private System.Windows.Forms.GroupBox grpUniqueFileIdentifier;
    }
}
