namespace TagEditor.Templates
{
    partial class TemplateManager
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
            this.grpSelectedTemplate = new System.Windows.Forms.GroupBox();
            this.pnlMP3 = new System.Windows.Forms.Panel();
            this.btnFiles = new System.Windows.Forms.Button();
            this.btnID3v1 = new System.Windows.Forms.Button();
            this.btnTextInformation = new System.Windows.Forms.Button();
            this.btnComment = new System.Windows.Forms.Button();
            this.btnPictures = new System.Windows.Forms.Button();
            this.cmbCopyType = new System.Windows.Forms.ComboBox();
            this.lblCopyType = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlWMA = new System.Windows.Forms.Panel();
            this.btnASimpleText = new System.Windows.Forms.Button();
            this.btnAPicture = new System.Windows.Forms.Button();
            this.btnATextInformation = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.grbTemplates = new System.Windows.Forms.GroupBox();
            this.lsbTemplates = new TagInfoControls.SmallControls.FrameList();
            this.mnuTemplateType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMP3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWMA = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.hlpHelp = new System.Windows.Forms.HelpProvider();
            this.grpSelectedTemplate.SuspendLayout();
            this.pnlMP3.SuspendLayout();
            this.pnlWMA.SuspendLayout();
            this.grbTemplates.SuspendLayout();
            this.mnuTemplateType.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSelectedTemplate
            // 
            this.grpSelectedTemplate.Controls.Add(this.pnlMP3);
            this.grpSelectedTemplate.Controls.Add(this.cmbCopyType);
            this.grpSelectedTemplate.Controls.Add(this.lblCopyType);
            this.grpSelectedTemplate.Controls.Add(this.lblName);
            this.grpSelectedTemplate.Controls.Add(this.txtName);
            this.grpSelectedTemplate.Controls.Add(this.pnlWMA);
            this.grpSelectedTemplate.Controls.Add(this.txtDescription);
            this.grpSelectedTemplate.Controls.Add(this.lblDescription);
            this.grpSelectedTemplate.Enabled = false;
            this.grpSelectedTemplate.Location = new System.Drawing.Point(195, 12);
            this.grpSelectedTemplate.Name = "grpSelectedTemplate";
            this.grpSelectedTemplate.Size = new System.Drawing.Size(209, 259);
            this.grpSelectedTemplate.TabIndex = 1;
            this.grpSelectedTemplate.TabStop = false;
            this.grpSelectedTemplate.Text = "Selected Template";
            // 
            // pnlMP3
            // 
            this.pnlMP3.Controls.Add(this.btnFiles);
            this.pnlMP3.Controls.Add(this.btnID3v1);
            this.pnlMP3.Controls.Add(this.btnTextInformation);
            this.pnlMP3.Controls.Add(this.btnComment);
            this.pnlMP3.Controls.Add(this.btnPictures);
            this.pnlMP3.Location = new System.Drawing.Point(6, 99);
            this.pnlMP3.Name = "pnlMP3";
            this.pnlMP3.Size = new System.Drawing.Size(196, 151);
            this.pnlMP3.TabIndex = 4;
            // 
            // btnFiles
            // 
            this.btnFiles.Location = new System.Drawing.Point(6, 90);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(184, 23);
            this.btnFiles.TabIndex = 8;
            this.btnFiles.Tag = "TagEditor.iFiles";
            this.btnFiles.Text = "&Files";
            this.btnFiles.UseVisualStyleBackColor = true;
            this.btnFiles.Click += new System.EventHandler(this.ShowDialog);
            // 
            // btnID3v1
            // 
            this.btnID3v1.Location = new System.Drawing.Point(6, 3);
            this.btnID3v1.Name = "btnID3v1";
            this.btnID3v1.Size = new System.Drawing.Size(184, 23);
            this.btnID3v1.TabIndex = 2;
            this.btnID3v1.Tag = "TagEditor.iID3";
            this.btnID3v1.Text = "ID3v1";
            this.btnID3v1.UseVisualStyleBackColor = true;
            this.btnID3v1.Click += new System.EventHandler(this.ShowDialog);
            // 
            // btnTextInformation
            // 
            this.btnTextInformation.Location = new System.Drawing.Point(6, 32);
            this.btnTextInformation.Name = "btnTextInformation";
            this.btnTextInformation.Size = new System.Drawing.Size(184, 23);
            this.btnTextInformation.TabIndex = 4;
            this.btnTextInformation.Tag = "TagEditor.iTextInformation";
            this.btnTextInformation.Text = "&Text Information";
            this.btnTextInformation.UseVisualStyleBackColor = true;
            this.btnTextInformation.Click += new System.EventHandler(this.ShowDialog);
            // 
            // btnComment
            // 
            this.btnComment.Location = new System.Drawing.Point(6, 61);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(184, 23);
            this.btnComment.TabIndex = 6;
            this.btnComment.Tag = "TagEditor.iComments";
            this.btnComment.Text = "&Comments";
            this.btnComment.UseVisualStyleBackColor = true;
            this.btnComment.Click += new System.EventHandler(this.ShowDialog);
            // 
            // btnPictures
            // 
            this.btnPictures.Location = new System.Drawing.Point(6, 119);
            this.btnPictures.Name = "btnPictures";
            this.btnPictures.Size = new System.Drawing.Size(184, 23);
            this.btnPictures.TabIndex = 10;
            this.btnPictures.Tag = "TagEditor.iPictures";
            this.btnPictures.Text = "Pict&ures";
            this.btnPictures.UseVisualStyleBackColor = true;
            this.btnPictures.Click += new System.EventHandler(this.ShowDialog);
            // 
            // cmbCopyType
            // 
            this.cmbCopyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCopyType.FormattingEnabled = true;
            this.cmbCopyType.Items.AddRange(new object[] {
            "Clean Copy",
            "Safe Copy",
            "Overwrite"});
            this.cmbCopyType.Location = new System.Drawing.Point(75, 73);
            this.cmbCopyType.Name = "cmbCopyType";
            this.cmbCopyType.Size = new System.Drawing.Size(121, 21);
            this.cmbCopyType.TabIndex = 11;
            this.cmbCopyType.SelectedIndexChanged += new System.EventHandler(this.cmbCopyType_SelectedIndexChanged);
            // 
            // lblCopyType
            // 
            this.lblCopyType.AutoSize = true;
            this.lblCopyType.Location = new System.Drawing.Point(6, 76);
            this.lblCopyType.Name = "lblCopyType";
            this.lblCopyType.Size = new System.Drawing.Size(61, 13);
            this.lblCopyType.TabIndex = 12;
            this.lblCopyType.Text = "Copy Type:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(75, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(121, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // pnlWMA
            // 
            this.pnlWMA.Controls.Add(this.btnASimpleText);
            this.pnlWMA.Controls.Add(this.btnAPicture);
            this.pnlWMA.Controls.Add(this.btnATextInformation);
            this.pnlWMA.Location = new System.Drawing.Point(6, 99);
            this.pnlWMA.Name = "pnlWMA";
            this.pnlWMA.Size = new System.Drawing.Size(196, 89);
            this.pnlWMA.TabIndex = 6;
            this.pnlWMA.Visible = false;
            // 
            // btnASimpleText
            // 
            this.btnASimpleText.Location = new System.Drawing.Point(6, 3);
            this.btnASimpleText.Name = "btnASimpleText";
            this.btnASimpleText.Size = new System.Drawing.Size(184, 23);
            this.btnASimpleText.TabIndex = 0;
            this.btnASimpleText.Tag = "TagEditor.aSimpleText";
            this.btnASimpleText.Text = "&Simple Texts";
            this.btnASimpleText.UseVisualStyleBackColor = true;
            this.btnASimpleText.Click += new System.EventHandler(this.ShowDialog);
            // 
            // btnAPicture
            // 
            this.btnAPicture.Location = new System.Drawing.Point(6, 61);
            this.btnAPicture.Name = "btnAPicture";
            this.btnAPicture.Size = new System.Drawing.Size(184, 23);
            this.btnAPicture.TabIndex = 4;
            this.btnAPicture.Tag = "TagEditor.aBranding";
            this.btnAPicture.Text = "&Picture";
            this.btnAPicture.UseVisualStyleBackColor = true;
            this.btnAPicture.Click += new System.EventHandler(this.ShowDialog);
            // 
            // btnATextInformation
            // 
            this.btnATextInformation.Location = new System.Drawing.Point(6, 32);
            this.btnATextInformation.Name = "btnATextInformation";
            this.btnATextInformation.Size = new System.Drawing.Size(184, 23);
            this.btnATextInformation.TabIndex = 2;
            this.btnATextInformation.Tag = "TagEditor.aTextInformation";
            this.btnATextInformation.Text = "&Text Information";
            this.btnATextInformation.UseVisualStyleBackColor = true;
            this.btnATextInformation.Click += new System.EventHandler(this.ShowDialog);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(75, 47);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(121, 20);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Validated += new System.EventHandler(this.txtDescription_Validated);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Description:";
            // 
            // grbTemplates
            // 
            this.grbTemplates.Controls.Add(this.lsbTemplates);
            this.grbTemplates.Location = new System.Drawing.Point(12, 12);
            this.grbTemplates.Name = "grbTemplates";
            this.grbTemplates.Size = new System.Drawing.Size(177, 259);
            this.grbTemplates.TabIndex = 0;
            this.grbTemplates.TabStop = false;
            this.grbTemplates.Text = "Templates";
            // 
            // lsbTemplates
            // 
            this.lsbTemplates.AllowDrop = true;
            this.lsbTemplates.Location = new System.Drawing.Point(6, 19);
            this.lsbTemplates.Name = "lsbTemplates";
            this.lsbTemplates.PromptOnClearAll = true;
            this.lsbTemplates.PromtOnRemove = true;
            this.lsbTemplates.Size = new System.Drawing.Size(163, 231);
            this.lsbTemplates.TabIndex = 0;
            this.lsbTemplates.AddClicked += new System.EventHandler(this.lsbTemplates_AddClicked);
            this.lsbTemplates.DragDrop += new System.Windows.Forms.DragEventHandler(this.lsbTemplates_DragDrop);
            this.lsbTemplates.RemovingItem += new System.ComponentModel.CancelEventHandler(this.lsbTemplates_RemovingItem);
            this.lsbTemplates.DragEnter += new System.Windows.Forms.DragEventHandler(this.lsbTemplates_DragEnter);
            this.lsbTemplates.SelectedIndexChanged += new System.EventHandler(this.lsbTemplates_SelectedIndexChanged);
            // 
            // mnuTemplateType
            // 
            this.mnuTemplateType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMP3,
            this.mnuWMA,
            this.mnuFromFile});
            this.mnuTemplateType.Name = "mnuTemplateType";
            this.mnuTemplateType.ShowImageMargin = false;
            this.mnuTemplateType.Size = new System.Drawing.Size(158, 70);
            // 
            // mnuMP3
            // 
            this.mnuMP3.Name = "mnuMP3";
            this.mnuMP3.Size = new System.Drawing.Size(157, 22);
            this.mnuMP3.Text = "Add MP3 Template";
            this.mnuMP3.Click += new System.EventHandler(this.mnuMP3_Click);
            // 
            // mnuWMA
            // 
            this.mnuWMA.Name = "mnuWMA";
            this.mnuWMA.Size = new System.Drawing.Size(157, 22);
            this.mnuWMA.Text = "Add WMA Template";
            this.mnuWMA.Click += new System.EventHandler(this.mnuWMA_Click);
            // 
            // mnuFromFile
            // 
            this.mnuFromFile.Name = "mnuFromFile";
            this.mnuFromFile.Size = new System.Drawing.Size(157, 22);
            this.mnuFromFile.Text = "From File...";
            this.mnuFromFile.Click += new System.EventHandler(this.mnuFromFile_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(322, 277);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // hlpHelp
            // 
            this.hlpHelp.HelpNamespace = "Help.chm";
            // 
            // TemplateManager
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 309);
            this.Controls.Add(this.grbTemplates);
            this.Controls.Add(this.grpSelectedTemplate);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.hlpHelp.SetHelpKeyword(this, "Manage Templates");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TemplateManager";
            this.hlpHelp.SetShowHelp(this, true);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Template Manager";
            this.grpSelectedTemplate.ResumeLayout(false);
            this.grpSelectedTemplate.PerformLayout();
            this.pnlMP3.ResumeLayout(false);
            this.pnlWMA.ResumeLayout(false);
            this.grbTemplates.ResumeLayout(false);
            this.mnuTemplateType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelectedTemplate;
        private System.Windows.Forms.GroupBox grbTemplates;
        private TagInfoControls.SmallControls.FrameList lsbTemplates;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel pnlMP3;
        private System.Windows.Forms.Button btnID3v1;
        private System.Windows.Forms.Button btnTextInformation;
        private System.Windows.Forms.Button btnComment;
        private System.Windows.Forms.Button btnFiles;
        private System.Windows.Forms.Button btnPictures;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel pnlWMA;
        private System.Windows.Forms.Button btnASimpleText;
        private System.Windows.Forms.Button btnAPicture;
        private System.Windows.Forms.Button btnATextInformation;
        private System.Windows.Forms.ContextMenuStrip mnuTemplateType;
        private System.Windows.Forms.ToolStripMenuItem mnuMP3;
        private System.Windows.Forms.ToolStripMenuItem mnuWMA;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ToolStripMenuItem mnuFromFile;
        private System.Windows.Forms.ComboBox cmbCopyType;
        private System.Windows.Forms.Label lblCopyType;
        private System.Windows.Forms.HelpProvider hlpHelp;
    }
}