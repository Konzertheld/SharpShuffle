namespace TagInfoControls
{
    partial class aContentBranding
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
            this.components = new System.ComponentModel.Container();
            this.lblImageURL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImageURL = new System.Windows.Forms.TextBox();
            this.txtCopyrightURL = new System.Windows.Forms.TextBox();
            this.lnkViewImage = new System.Windows.Forms.LinkLabel();
            this.lnkViewCopyright = new System.Windows.Forms.LinkLabel();
            this.erpURL = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.imgImage = new System.Windows.Forms.PictureBox();
            this.lblImageType = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpURL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblImageURL
            // 
            this.lblImageURL.AutoSize = true;
            this.lblImageURL.Location = new System.Drawing.Point(3, 6);
            this.lblImageURL.Name = "lblImageURL";
            this.lblImageURL.Size = new System.Drawing.Size(64, 13);
            this.lblImageURL.TabIndex = 0;
            this.lblImageURL.Text = "Image URL:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Copyright URL:";
            // 
            // txtImageURL
            // 
            this.erpURL.SetIconPadding(this.txtImageURL, 5);
            this.txtImageURL.Location = new System.Drawing.Point(88, 3);
            this.txtImageURL.Name = "txtImageURL";
            this.txtImageURL.Size = new System.Drawing.Size(164, 20);
            this.txtImageURL.TabIndex = 2;
            this.tlpMain.SetToolTip(this.txtImageURL, "URL that provide more information about image");
            this.txtImageURL.TextChanged += new System.EventHandler(this.URL_TextChanged);
            this.txtImageURL.Validating += new System.ComponentModel.CancelEventHandler(this.URL_Validating);
            // 
            // txtCopyrightURL
            // 
            this.txtCopyrightURL.Location = new System.Drawing.Point(88, 29);
            this.txtCopyrightURL.Name = "txtCopyrightURL";
            this.txtCopyrightURL.Size = new System.Drawing.Size(164, 20);
            this.txtCopyrightURL.TabIndex = 5;
            this.tlpMain.SetToolTip(this.txtCopyrightURL, "URL that provide information about copyright of file");
            this.txtCopyrightURL.Validating += new System.ComponentModel.CancelEventHandler(this.URL_Validating);
            // 
            // lnkViewImage
            // 
            this.lnkViewImage.AutoSize = true;
            this.lnkViewImage.Enabled = false;
            this.lnkViewImage.Location = new System.Drawing.Point(258, 6);
            this.lnkViewImage.Name = "lnkViewImage";
            this.lnkViewImage.Size = new System.Drawing.Size(16, 13);
            this.lnkViewImage.TabIndex = 1;
            this.lnkViewImage.TabStop = true;
            this.lnkViewImage.Text = "->";
            this.lnkViewImage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkViewImage_LinkClicked);
            // 
            // lnkViewCopyright
            // 
            this.lnkViewCopyright.AutoSize = true;
            this.lnkViewCopyright.Enabled = false;
            this.lnkViewCopyright.Location = new System.Drawing.Point(258, 32);
            this.lnkViewCopyright.Name = "lnkViewCopyright";
            this.lnkViewCopyright.Size = new System.Drawing.Size(16, 13);
            this.lnkViewCopyright.TabIndex = 4;
            this.lnkViewCopyright.TabStop = true;
            this.lnkViewCopyright.Text = "->";
            // 
            // erpURL
            // 
            this.erpURL.ContainerControl = this;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Image = global::TagInfoControls.Properties.Resources.DeleteHS;
            this.btnClear.Location = new System.Drawing.Point(66, 209);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 26);
            this.btnClear.TabIndex = 12;
            this.tlpMain.SetToolTip(this.btnClear, "Delete current image and to not use image");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::TagInfoControls.Properties.Resources.saveHS;
            this.btnSave.Location = new System.Drawing.Point(36, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 26);
            this.btnSave.TabIndex = 11;
            this.tlpMain.SetToolTip(this.btnSave, "Save current image to file");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBrowse.Image = global::TagInfoControls.Properties.Resources.openHS;
            this.btnBrowse.Location = new System.Drawing.Point(6, 209);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 26);
            this.btnBrowse.TabIndex = 10;
            this.tlpMain.SetToolTip(this.btnBrowse, "Browse a image from file");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // imgImage
            // 
            this.imgImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgImage.Location = new System.Drawing.Point(6, 55);
            this.imgImage.Name = "imgImage";
            this.imgImage.Size = new System.Drawing.Size(265, 148);
            this.imgImage.TabIndex = 13;
            this.imgImage.TabStop = false;
            this.tlpMain.SetToolTip(this.imgImage, "Current image for this file");
            // 
            // lblImageType
            // 
            this.lblImageType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImageType.AutoSize = true;
            this.lblImageType.Location = new System.Drawing.Point(96, 216);
            this.lblImageType.Name = "lblImageType";
            this.lblImageType.Size = new System.Drawing.Size(31, 13);
            this.lblImageType.TabIndex = 14;
            this.lblImageType.Text = "none";
            this.tlpMain.SetToolTip(this.lblImageType, "Extension of selected image");
            // 
            // aContentBranding
            // 
            this.Controls.Add(this.lblImageType);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.imgImage);
            this.Controls.Add(this.lnkViewCopyright);
            this.Controls.Add(this.lnkViewImage);
            this.Controls.Add(this.txtCopyrightURL);
            this.Controls.Add(this.txtImageURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblImageURL);
            this.Name = "aContentBranding";
            this.Size = new System.Drawing.Size(274, 238);
            ((System.ComponentModel.ISupportInitialize)(this.erpURL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblImageURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImageURL;
        private System.Windows.Forms.TextBox txtCopyrightURL;
        private System.Windows.Forms.LinkLabel lnkViewImage;
        private System.Windows.Forms.LinkLabel lnkViewCopyright;
        private System.Windows.Forms.ErrorProvider erpURL;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox imgImage;
        private System.Windows.Forms.Label lblImageType;
        private System.Windows.Forms.ToolTip tlpMain;
    }
}
