namespace TagEditor
{
    partial class iSelling
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
            this.ictCommercial = new TagInfoControls.Commercial();
            this.ictOwnership = new TagInfoControls.Ownership();
            this.grpCommercial = new System.Windows.Forms.GroupBox();
            this.grpSelling = new System.Windows.Forms.GroupBox();
            this.grpCommercial.SuspendLayout();
            this.grpSelling.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(250, 318);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(331, 318);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(447, 318);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(412, 318);
            // 
            // ictCommercial
            // 
            this.ictCommercial.Location = new System.Drawing.Point(6, 19);
            this.ictCommercial.Name = "ictCommercial";
            this.ictCommercial.Size = new System.Drawing.Size(459, 157);
            this.ictCommercial.TabIndex = 5;
            // 
            // ictOwnership
            // 
            this.ictOwnership.Location = new System.Drawing.Point(6, 19);
            this.ictOwnership.MaximumSize = new System.Drawing.Size(367, 76);
            this.ictOwnership.MinimumSize = new System.Drawing.Size(367, 76);
            this.ictOwnership.Name = "ictOwnership";
            this.ictOwnership.Size = new System.Drawing.Size(367, 76);
            this.ictOwnership.TabIndex = 6;
            // 
            // grpCommercial
            // 
            this.grpCommercial.Controls.Add(this.ictCommercial);
            this.grpCommercial.Location = new System.Drawing.Point(12, 12);
            this.grpCommercial.Name = "grpCommercial";
            this.grpCommercial.Size = new System.Drawing.Size(467, 182);
            this.grpCommercial.TabIndex = 7;
            this.grpCommercial.TabStop = false;
            this.grpCommercial.Text = "Commercial Information";
            // 
            // grpSelling
            // 
            this.grpSelling.Controls.Add(this.ictOwnership);
            this.grpSelling.Location = new System.Drawing.Point(12, 200);
            this.grpSelling.Name = "grpSelling";
            this.grpSelling.Size = new System.Drawing.Size(465, 105);
            this.grpSelling.TabIndex = 8;
            this.grpSelling.TabStop = false;
            this.grpSelling.Text = "Selling Information";
            // 
            // iSelling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(488, 353);
            this.Controls.Add(this.grpCommercial);
            this.Controls.Add(this.grpSelling);
            this.hlpHelp.SetHelpKeyword(this, "Commercial");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "iSelling";
            this.hlpHelp.SetShowHelp(this, true);
            this.Text = "Commercial Information";
            this.Controls.SetChildIndex(this.grpSelling, 0);
            this.Controls.SetChildIndex(this.grpCommercial, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.grpCommercial.ResumeLayout(false);
            this.grpSelling.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.Commercial ictCommercial;
        private TagInfoControls.Ownership ictOwnership;
        private System.Windows.Forms.GroupBox grpCommercial;
        private System.Windows.Forms.GroupBox grpSelling;
    }
}
