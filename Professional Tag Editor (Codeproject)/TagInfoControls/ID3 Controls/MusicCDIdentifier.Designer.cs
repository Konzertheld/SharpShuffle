namespace TagInfoControls
{
    partial class MusicCDIdentifier
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtData = new TagInfoControls.SmallControls.HexBoxEx();
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Data = null;
            this.txtData.Location = new System.Drawing.Point(0, 0);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(346, 182);
            this.txtData.TabIndex = 0;
            // 
            // MusicCDIdentifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtData);
            this.Name = "MusicCDIdentifier";
            this.Size = new System.Drawing.Size(346, 182);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.SmallControls.HexBoxEx txtData;
    }
}
