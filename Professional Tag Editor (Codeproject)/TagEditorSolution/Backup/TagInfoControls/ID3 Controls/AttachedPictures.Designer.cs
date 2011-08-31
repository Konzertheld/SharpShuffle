namespace TagInfoControls
{
    partial class AttachedPictures
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
            this.components = new System.ComponentModel.Container();
            this.lsbPictures = new TagInfoControls.SmallControls.FrameList();
            this.grbSelectedImage = new System.Windows.Forms.GroupBox();
            this.lblResolution = new System.Windows.Forms.Label();
            this.lblResolutionL = new System.Windows.Forms.Label();
            this.txtMimeType = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblSizeL = new System.Windows.Forms.Label();
            this.lblPictureType = new System.Windows.Forms.Label();
            this.cmbPictureType = new System.Windows.Forms.ComboBox();
            this.lblMIMETypeL = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.imgImage = new System.Windows.Forms.PictureBox();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.frmOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.frmSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.lblTotalSize = new System.Windows.Forms.Label();
            this.lblTotalSizeL = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.grbSelectedImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lsbPictures
            // 
            this.lsbPictures.Location = new System.Drawing.Point(0, 0);
            this.lsbPictures.Name = "lsbPictures";
            this.lsbPictures.ShowSaveButton = true;
            this.lsbPictures.Size = new System.Drawing.Size(163, 266);
            this.lsbPictures.TabIndex = 0;
            this.lsbPictures.AddClicked += new System.EventHandler(this.lsbPictures_AddClicked);
            this.lsbPictures.SelectedIndexChanged += new System.EventHandler(this.lsbPictures_SelectedIndexChanged);
            this.lsbPictures.SaveClicked += new System.EventHandler(this.lsbPictures_SaveClicked);
            // 
            // grbSelectedImage
            // 
            this.grbSelectedImage.Controls.Add(this.lblResolution);
            this.grbSelectedImage.Controls.Add(this.lblResolutionL);
            this.grbSelectedImage.Controls.Add(this.txtMimeType);
            this.grbSelectedImage.Controls.Add(this.txtDescription);
            this.grbSelectedImage.Controls.Add(this.lblSize);
            this.grbSelectedImage.Controls.Add(this.lblSizeL);
            this.grbSelectedImage.Controls.Add(this.lblPictureType);
            this.grbSelectedImage.Controls.Add(this.cmbPictureType);
            this.grbSelectedImage.Controls.Add(this.lblMIMETypeL);
            this.grbSelectedImage.Controls.Add(this.lblDescription);
            this.grbSelectedImage.Controls.Add(this.imgImage);
            this.grbSelectedImage.Enabled = false;
            this.grbSelectedImage.Location = new System.Drawing.Point(169, 3);
            this.grbSelectedImage.Name = "grbSelectedImage";
            this.grbSelectedImage.Size = new System.Drawing.Size(513, 234);
            this.grbSelectedImage.TabIndex = 1;
            this.grbSelectedImage.TabStop = false;
            this.grbSelectedImage.Text = "Selected Image";
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(398, 201);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(32, 13);
            this.lblResolution.TabIndex = 18;
            this.lblResolution.Text = "[Res]";
            this.tlpMain.SetToolTip(this.lblResolution, "Resolution of selected picture");
            // 
            // lblResolutionL
            // 
            this.lblResolutionL.AutoSize = true;
            this.lblResolutionL.Location = new System.Drawing.Point(332, 201);
            this.lblResolutionL.Name = "lblResolutionL";
            this.lblResolutionL.Size = new System.Drawing.Size(60, 13);
            this.lblResolutionL.TabIndex = 17;
            this.lblResolutionL.Text = "Resolution:";
            // 
            // txtMimeType
            // 
            this.txtMimeType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMimeType.Location = new System.Drawing.Point(398, 131);
            this.txtMimeType.Name = "txtMimeType";
            this.txtMimeType.ReadOnly = true;
            this.txtMimeType.Size = new System.Drawing.Size(109, 13);
            this.txtMimeType.TabIndex = 16;
            this.txtMimeType.Text = "[MIME]";
            this.tlpMain.SetToolTip(this.txtMimeType, "MIME type of selected picture");
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(335, 36);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(172, 20);
            this.txtDescription.TabIndex = 15;
            this.tlpMain.SetToolTip(this.txtDescription, "Description of image");
            this.txtDescription.Validated += new System.EventHandler(this.txtDescription_Validated);
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescription_Validating);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(368, 166);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(38, 13);
            this.lblSize.TabIndex = 14;
            this.lblSize.Text = "0.00 B";
            this.tlpMain.SetToolTip(this.lblSize, "Size of selected picture");
            // 
            // lblSizeL
            // 
            this.lblSizeL.AutoSize = true;
            this.lblSizeL.Location = new System.Drawing.Point(332, 166);
            this.lblSizeL.Name = "lblSizeL";
            this.lblSizeL.Size = new System.Drawing.Size(30, 13);
            this.lblSizeL.TabIndex = 13;
            this.lblSizeL.Text = "Size:";
            // 
            // lblPictureType
            // 
            this.lblPictureType.AutoSize = true;
            this.lblPictureType.Location = new System.Drawing.Point(332, 69);
            this.lblPictureType.Name = "lblPictureType";
            this.lblPictureType.Size = new System.Drawing.Size(70, 13);
            this.lblPictureType.TabIndex = 9;
            this.lblPictureType.Text = "P&icture Type:";
            // 
            // cmbPictureType
            // 
            this.cmbPictureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPictureType.FormattingEnabled = true;
            this.cmbPictureType.Items.AddRange(new object[] {
            "Other",
            "32x32 pixels \'file icon\'",
            "Other file icon",
            "Cover (front)",
            "Cover (back)",
            "Leaflet page",
            "Media (e.g. lable side of CD)",
            "Lead artist",
            "Artist",
            "Conductor",
            "Band",
            "Composer",
            "Lyricist",
            "Recording Location",
            "During recording",
            "During performance",
            "Movie/video screen capture",
            "A bright coloured fish",
            "Illustration",
            "Band/artist logotype",
            "Publisher/Studio logotype"});
            this.cmbPictureType.Location = new System.Drawing.Point(335, 87);
            this.cmbPictureType.Name = "cmbPictureType";
            this.cmbPictureType.Size = new System.Drawing.Size(172, 21);
            this.cmbPictureType.TabIndex = 10;
            this.tlpMain.SetToolTip(this.cmbPictureType, "Type of picture");
            this.cmbPictureType.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPictureType_Validating);
            this.cmbPictureType.Validated += new System.EventHandler(this.cmbPictureType_Validated);
            // 
            // lblMIMETypeL
            // 
            this.lblMIMETypeL.AutoSize = true;
            this.lblMIMETypeL.Location = new System.Drawing.Point(332, 131);
            this.lblMIMETypeL.Name = "lblMIMETypeL";
            this.lblMIMETypeL.Size = new System.Drawing.Size(65, 13);
            this.lblMIMETypeL.TabIndex = 11;
            this.lblMIMETypeL.Text = "MIME Type:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(332, 19);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "&Description:";
            // 
            // imgImage
            // 
            this.imgImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgImage.Location = new System.Drawing.Point(6, 19);
            this.imgImage.Name = "imgImage";
            this.imgImage.Size = new System.Drawing.Size(323, 209);
            this.imgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgImage.TabIndex = 1;
            this.imgImage.TabStop = false;
            this.tlpMain.SetToolTip(this.imgImage, "View of selected picture");
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Enabled = false;
            this.btnFullScreen.Image = global::TagInfoControls.Properties.Resources.FullScreenHS;
            this.btnFullScreen.Location = new System.Drawing.Point(328, 243);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(24, 23);
            this.btnFullScreen.TabIndex = 18;
            this.tlpMain.SetToolTip(this.btnFullScreen, "View pictures with default picture viewer");
            this.btnFullScreen.UseVisualStyleBackColor = true;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // frmOpenFile
            // 
            this.frmOpenFile.Filter = "All Images (*.jpg, *.bmp, *.png, *.gif)|*.jpg;*.jpeg;*.bmp;*.gif ";
            this.frmOpenFile.Multiselect = true;
            // 
            // frmSaveFile
            // 
            this.frmSaveFile.Filter = "Jpeg image (*.jpg)|*.jpg";
            // 
            // lblTotalSize
            // 
            this.lblTotalSize.AutoSize = true;
            this.lblTotalSize.Location = new System.Drawing.Point(564, 248);
            this.lblTotalSize.Name = "lblTotalSize";
            this.lblTotalSize.Size = new System.Drawing.Size(38, 13);
            this.lblTotalSize.TabIndex = 22;
            this.lblTotalSize.Text = "0.00 B";
            this.tlpMain.SetToolTip(this.lblTotalSize, "Total size of pictures");
            // 
            // lblTotalSizeL
            // 
            this.lblTotalSizeL.AutoSize = true;
            this.lblTotalSizeL.Location = new System.Drawing.Point(501, 248);
            this.lblTotalSizeL.Name = "lblTotalSizeL";
            this.lblTotalSizeL.Size = new System.Drawing.Size(57, 13);
            this.lblTotalSizeL.TabIndex = 21;
            this.lblTotalSizeL.Text = "Total Size:";
            // 
            // AttachedPictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalSize);
            this.Controls.Add(this.lblTotalSizeL);
            this.Controls.Add(this.btnFullScreen);
            this.Controls.Add(this.grbSelectedImage);
            this.Controls.Add(this.lsbPictures);
            this.Name = "AttachedPictures";
            this.Size = new System.Drawing.Size(685, 269);
            this.grbSelectedImage.ResumeLayout(false);
            this.grbSelectedImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TagInfoControls.SmallControls.FrameList lsbPictures;
        private System.Windows.Forms.GroupBox grbSelectedImage;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblSizeL;
        private System.Windows.Forms.Label lblPictureType;
        private System.Windows.Forms.ComboBox cmbPictureType;
        private System.Windows.Forms.Label lblMIMETypeL;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.OpenFileDialog frmOpenFile;
        private System.Windows.Forms.SaveFileDialog frmSaveFile;
        private System.Windows.Forms.Label lblTotalSize;
        private System.Windows.Forms.Label lblTotalSizeL;
        private System.Windows.Forms.TextBox txtMimeType;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.Label lblResolutionL;
        private System.Windows.Forms.ToolTip tlpMain;
        private System.Windows.Forms.PictureBox imgImage;
    }
}
