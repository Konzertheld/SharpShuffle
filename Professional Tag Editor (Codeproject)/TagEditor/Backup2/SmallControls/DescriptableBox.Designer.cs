namespace TagInfoControls.SmallControls
{
    partial class DescriptableBox
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lnbLanguage
            // 
            this.lnbLanguage.Location = new System.Drawing.Point(69, 26);
            this.lnbLanguage.TabIndex = 3;
            this.tlpMain.SetToolTip(this.lnbLanguage, "Language for text");
            this.lnbLanguage.Validated += new System.EventHandler(this.lnbLanguage_Validated);
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(3, 54);
            this.txtText.Size = new System.Drawing.Size(349, 157);
            this.txtText.TabIndex = 5;
            this.tlpMain.SetToolTip(this.txtText, "Text of frame");
            this.txtText.Validated += new System.EventHandler(this.txtText_Validated);
            // 
            // lblLanguage
            // 
            this.lblLanguage.Location = new System.Drawing.Point(0, 31);
            this.lblLanguage.TabIndex = 2;
            // 
            // rdbRTL
            // 
            this.rdbRTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbRTL.Location = new System.Drawing.Point(330, 26);
            this.tlpMain.SetToolTip(this.rdbRTL, "Right to left language");
            // 
            // rdbLTR
            // 
            this.rdbLTR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbLTR.Location = new System.Drawing.Point(302, 26);
            this.tlpMain.SetToolTip(this.rdbLTR, "Left to right language");
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(69, 0);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(202, 20);
            this.txtDescription.TabIndex = 1;
            this.tlpMain.SetToolTip(this.txtDescription, "Description of text");
            this.txtDescription.Validated += new System.EventHandler(this.txtDescription_Validated);
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescription_Validating);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(0, 3);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            // 
            // DescriptableBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Name = "DescriptableBox";
            this.Size = new System.Drawing.Size(354, 211);
            this.Controls.SetChildIndex(this.rdbRTL, 0);
            this.Controls.SetChildIndex(this.rdbLTR, 0);
            this.Controls.SetChildIndex(this.lblDescription, 0);
            this.Controls.SetChildIndex(this.lnbLanguage, 0);
            this.Controls.SetChildIndex(this.txtText, 0);
            this.Controls.SetChildIndex(this.lblLanguage, 0);
            this.Controls.SetChildIndex(this.txtDescription, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// Description Label
        /// </summary>
        protected System.Windows.Forms.Label lblDescription;
        /// <summary>
        /// TextBox contains Description
        /// </summary>
        protected System.Windows.Forms.TextBox txtDescription;

    }
}
