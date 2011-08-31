namespace TagInfoControls
{
    partial class CommentAndLyric
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
            this.grpValue = new System.Windows.Forms.GroupBox();
            this.dcbTextWithLang = new TagInfoControls.SmallControls.DescriptableBox();
            this.lsbComments = new TagInfoControls.SmallControls.FrameList();
            this.grpValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpValue
            // 
            this.grpValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpValue.Controls.Add(this.dcbTextWithLang);
            this.grpValue.Location = new System.Drawing.Point(169, -1);
            this.grpValue.Name = "grpValue";
            this.grpValue.Size = new System.Drawing.Size(363, 256);
            this.grpValue.TabIndex = 13;
            this.grpValue.TabStop = false;
            this.grpValue.Text = "Selected";
            // 
            // dcbTextWithLang
            // 
            this.dcbTextWithLang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dcbTextWithLang.Location = new System.Drawing.Point(2, 17);
            this.dcbTextWithLang.Name = "dcbTextWithLang";
            this.dcbTextWithLang.Size = new System.Drawing.Size(353, 233);
            this.dcbTextWithLang.TabIndex = 0;
            this.dcbTextWithLang.TextWithLanguageValue = null;
            this.dcbTextWithLang.DataUpdated += new System.EventHandler(this.dcbTextWithLang_DataUpdated);
            // 
            // lsbComments
            // 
            this.lsbComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbComments.Location = new System.Drawing.Point(0, 0);
            this.lsbComments.Name = "lsbComments";
            this.lsbComments.ShowSaveButton = true;
            this.lsbComments.Size = new System.Drawing.Size(163, 254);
            this.lsbComments.TabIndex = 1;
            this.lsbComments.AddClicked += new System.EventHandler(this.frlComments_AddClicked_1);
            this.lsbComments.SelectedIndexChanged += new System.EventHandler(this.frlComments_SelectedIndexChanged_1);
            this.lsbComments.SaveClicked += new System.EventHandler(this.lsbComments_SaveClicked);
            // 
            // CommentAndLyric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsbComments);
            this.Controls.Add(this.grpValue);
            this.Name = "CommentAndLyric";
            this.Size = new System.Drawing.Size(535, 258);
            this.grpValue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpValue;
        private TagInfoControls.SmallControls.DescriptableBox dcbTextWithLang;
        private TagInfoControls.SmallControls.FrameList lsbComments;

    }
}
