namespace TagInfoControls
{
    partial class AttachedFiles
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grbSelectedFile = new System.Windows.Forms.GroupBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.imgWarning = new System.Windows.Forms.PictureBox();
            this.imgIcon = new System.Windows.Forms.PictureBox();
            this.txtMimeType = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblSizeL = new System.Windows.Forms.Label();
            this.lblMIMETypeL = new System.Windows.Forms.Label();
            this.lsbFrames = new TagInfoControls.SmallControls.FrameList();
            this.frmOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.lblTotalSizeL = new System.Windows.Forms.Label();
            this.lblTotalSize = new System.Windows.Forms.Label();
            this.frmSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.grbSelectedFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 22);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "&Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(75, 19);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(147, 20);
            this.txtDescription.TabIndex = 1;
            this.tlpMain.SetToolTip(this.txtDescription, "Description of selected file");
            this.txtDescription.Validated += new System.EventHandler(this.txtDescription_Validated);
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescription_Validating);
            // 
            // grbSelectedFile
            // 
            this.grbSelectedFile.Controls.Add(this.lblWarning);
            this.grbSelectedFile.Controls.Add(this.imgWarning);
            this.grbSelectedFile.Controls.Add(this.imgIcon);
            this.grbSelectedFile.Controls.Add(this.txtMimeType);
            this.grbSelectedFile.Controls.Add(this.lblFileName);
            this.grbSelectedFile.Controls.Add(this.txtFileName);
            this.grbSelectedFile.Controls.Add(this.lblSize);
            this.grbSelectedFile.Controls.Add(this.lblSizeL);
            this.grbSelectedFile.Controls.Add(this.lblMIMETypeL);
            this.grbSelectedFile.Controls.Add(this.lblDescription);
            this.grbSelectedFile.Controls.Add(this.txtDescription);
            this.grbSelectedFile.Enabled = false;
            this.grbSelectedFile.Location = new System.Drawing.Point(169, 3);
            this.grbSelectedFile.Name = "grbSelectedFile";
            this.grbSelectedFile.Size = new System.Drawing.Size(232, 181);
            this.grbSelectedFile.TabIndex = 1;
            this.grbSelectedFile.TabStop = false;
            this.grbSelectedFile.Text = "Selected File";
            // 
            // lblWarning
            // 
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWarning.Location = new System.Drawing.Point(104, 118);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(122, 60);
            this.lblWarning.TabIndex = 4;
            this.lblWarning.Text = "The file that you have added here is an image file it\'s better to add this to pic" +
                "tures.";
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWarning.Visible = false;
            // 
            // imgWarning
            // 
            this.imgWarning.Image = global::TagInfoControls.Properties.Resources.WarningHS;
            this.imgWarning.Location = new System.Drawing.Point(85, 125);
            this.imgWarning.Name = "imgWarning";
            this.imgWarning.Size = new System.Drawing.Size(16, 16);
            this.imgWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgWarning.TabIndex = 8;
            this.imgWarning.TabStop = false;
            this.imgWarning.Visible = false;
            this.imgWarning.VisibleChanged += new System.EventHandler(this.imgWarning_VisibleChanged);
            // 
            // imgIcon
            // 
            this.imgIcon.Location = new System.Drawing.Point(9, 118);
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.Size = new System.Drawing.Size(66, 56);
            this.imgIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgIcon.TabIndex = 15;
            this.imgIcon.TabStop = false;
            this.tlpMain.SetToolTip(this.imgIcon, "Icon file associated with selected file");
            // 
            // txtMimeType
            // 
            this.txtMimeType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMimeType.Location = new System.Drawing.Point(75, 73);
            this.txtMimeType.Name = "txtMimeType";
            this.txtMimeType.ReadOnly = true;
            this.txtMimeType.Size = new System.Drawing.Size(145, 13);
            this.txtMimeType.TabIndex = 5;
            this.tlpMain.SetToolTip(this.txtMimeType, "MIME type of selected file");
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 48);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(57, 13);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "&File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(75, 45);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(147, 20);
            this.txtFileName.TabIndex = 3;
            this.tlpMain.SetToolTip(this.txtFileName, "File name of selected file");
            this.txtFileName.Validated += new System.EventHandler(this.txtFileName_Validated);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(72, 97);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(0, 13);
            this.lblSize.TabIndex = 7;
            this.tlpMain.SetToolTip(this.lblSize, "Size of selected file");
            // 
            // lblSizeL
            // 
            this.lblSizeL.AutoSize = true;
            this.lblSizeL.Location = new System.Drawing.Point(6, 97);
            this.lblSizeL.Name = "lblSizeL";
            this.lblSizeL.Size = new System.Drawing.Size(30, 13);
            this.lblSizeL.TabIndex = 6;
            this.lblSizeL.Text = "Size:";
            // 
            // lblMIMETypeL
            // 
            this.lblMIMETypeL.AutoSize = true;
            this.lblMIMETypeL.Location = new System.Drawing.Point(6, 73);
            this.lblMIMETypeL.Name = "lblMIMETypeL";
            this.lblMIMETypeL.Size = new System.Drawing.Size(65, 13);
            this.lblMIMETypeL.TabIndex = 4;
            this.lblMIMETypeL.Text = "MIME Type:";
            // 
            // lsbFrames
            // 
            this.lsbFrames.Location = new System.Drawing.Point(0, 0);
            this.lsbFrames.Name = "lsbFrames";
            this.lsbFrames.ShowSaveButton = true;
            this.lsbFrames.Size = new System.Drawing.Size(163, 266);
            this.lsbFrames.TabIndex = 0;
            this.lsbFrames.AddClicked += new System.EventHandler(this.lsbFrames_AddClicked);
            this.lsbFrames.ListCleared += new System.EventHandler(this.lsbFrames_ListCleared);
            this.lsbFrames.SelectedIndexChanged += new System.EventHandler(this.lsbFrames_SelectedIndexChanged);
            this.lsbFrames.SaveClicked += new System.EventHandler(this.lsbFrames_SaveClicked);
            // 
            // frmOpenFile
            // 
            this.frmOpenFile.Filter = "All files (*.*)|*.*";
            this.frmOpenFile.Multiselect = true;
            this.frmOpenFile.Title = "Select a file to add";
            // 
            // lblTotalSizeL
            // 
            this.lblTotalSizeL.AutoSize = true;
            this.lblTotalSizeL.Location = new System.Drawing.Point(169, 187);
            this.lblTotalSizeL.Name = "lblTotalSizeL";
            this.lblTotalSizeL.Size = new System.Drawing.Size(57, 13);
            this.lblTotalSizeL.TabIndex = 2;
            this.lblTotalSizeL.Text = "Total Size:";
            // 
            // lblTotalSize
            // 
            this.lblTotalSize.AutoSize = true;
            this.lblTotalSize.Location = new System.Drawing.Point(232, 187);
            this.lblTotalSize.Name = "lblTotalSize";
            this.lblTotalSize.Size = new System.Drawing.Size(38, 13);
            this.lblTotalSize.TabIndex = 3;
            this.lblTotalSize.Text = "0.00 B";
            this.tlpMain.SetToolTip(this.lblTotalSize, "Total size of files");
            // 
            // frmSaveFile
            // 
            this.frmSaveFile.Filter = "All files (*.*)|*.*";
            // 
            // AttachedFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalSize);
            this.Controls.Add(this.lblTotalSizeL);
            this.Controls.Add(this.lsbFrames);
            this.Controls.Add(this.grbSelectedFile);
            this.Name = "AttachedFiles";
            this.Size = new System.Drawing.Size(406, 267);
            this.grbSelectedFile.ResumeLayout(false);
            this.grbSelectedFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grbSelectedFile;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblSizeL;
        private System.Windows.Forms.Label lblMIMETypeL;
        private TagInfoControls.SmallControls.FrameList lsbFrames;
        private System.Windows.Forms.OpenFileDialog frmOpenFile;
        private System.Windows.Forms.Label lblTotalSizeL;
        private System.Windows.Forms.Label lblTotalSize;
        private System.Windows.Forms.SaveFileDialog frmSaveFile;
        private System.Windows.Forms.TextBox txtMimeType;
        private System.Windows.Forms.PictureBox imgIcon;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.PictureBox imgWarning;
        private System.Windows.Forms.ToolTip tlpMain;
    }
}
