namespace TagEditor
{
    partial class EditFormula
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
            this.lblFormula = new System.Windows.Forms.Label();
            this.lsbFilenames = new System.Windows.Forms.ListBox();
            this.cmbFormula = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.lsbAvailableTexts = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpFileName = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblNoFile = new System.Windows.Forms.Label();
            this.Error = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.hlpHelp = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            this.grpFileName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(6, 24);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(47, 13);
            this.lblFormula.TabIndex = 1;
            this.lblFormula.Text = "&Formula:";
            // 
            // lsbFilenames
            // 
            this.lsbFilenames.FormattingEnabled = true;
            this.lsbFilenames.Location = new System.Drawing.Point(9, 84);
            this.lsbFilenames.Name = "lsbFilenames";
            this.lsbFilenames.Size = new System.Drawing.Size(249, 160);
            this.lsbFilenames.TabIndex = 2;
            this.tlpMain.SetToolTip(this.lsbFilenames, "Preview of files list after rename");
            // 
            // cmbFormula
            // 
            this.cmbFormula.FormattingEnabled = true;
            this.cmbFormula.Location = new System.Drawing.Point(57, 21);
            this.cmbFormula.Name = "cmbFormula";
            this.cmbFormula.Size = new System.Drawing.Size(188, 21);
            this.cmbFormula.TabIndex = 4;
            this.tlpMain.SetToolTip(this.cmbFormula, "Formula to use renaming file");
            this.cmbFormula.TextChanged += new System.EventHandler(this.cmbFormula_TextChanged);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(210, 19);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(28, 23);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = ">>";
            this.tlpMain.SetToolTip(this.btnInsert, "Add selected text to formula");
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // lsbAvailableTexts
            // 
            this.lsbAvailableTexts.FormattingEnabled = true;
            this.lsbAvailableTexts.Location = new System.Drawing.Point(6, 19);
            this.lsbAvailableTexts.Name = "lsbAvailableTexts";
            this.lsbAvailableTexts.Size = new System.Drawing.Size(198, 225);
            this.lsbAvailableTexts.Sorted = true;
            this.lsbAvailableTexts.TabIndex = 8;
            this.tlpMain.SetToolTip(this.lsbAvailableTexts, "Available texts to use in formula");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsbAvailableTexts);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 250);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Texts:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(376, 277);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "&OK";
            this.tlpMain.SetToolTip(this.btnOK, "Accept formula");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(457, 277);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Cancel";
            this.tlpMain.SetToolTip(this.btnCancel, "Close dialog");
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpFileName
            // 
            this.grpFileName.Controls.Add(this.btnPreview);
            this.grpFileName.Controls.Add(this.lblNoFile);
            this.grpFileName.Controls.Add(this.cmbFormula);
            this.grpFileName.Controls.Add(this.lblFormula);
            this.grpFileName.Controls.Add(this.lsbFilenames);
            this.grpFileName.Location = new System.Drawing.Point(262, 12);
            this.grpFileName.Name = "grpFileName";
            this.grpFileName.Size = new System.Drawing.Size(271, 250);
            this.grpFileName.TabIndex = 12;
            this.grpFileName.TabStop = false;
            this.grpFileName.Text = "Filename";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(9, 55);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(129, 23);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview filenames";
            this.tlpMain.SetToolTip(this.btnPreview, "Create preview list of files");
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // lblNoFile
            // 
            this.lblNoFile.AutoSize = true;
            this.lblNoFile.BackColor = System.Drawing.SystemColors.Window;
            this.lblNoFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblNoFile.Location = new System.Drawing.Point(90, 156);
            this.lblNoFile.Name = "lblNoFile";
            this.lblNoFile.Size = new System.Drawing.Size(99, 13);
            this.lblNoFile.TabIndex = 5;
            this.lblNoFile.Text = "There\'s no file in list";
            // 
            // Error
            // 
            this.Error.ContainerControl = this;
            // 
            // hlpHelp
            // 
            this.hlpHelp.HelpNamespace = "Help.chm";
            // 
            // EditFormula
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(541, 312);
            this.Controls.Add(this.grpFileName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.hlpHelp.SetHelpKeyword(this, "Rename Formula");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.hlpHelp.SetHelpString(this, "");
            this.Name = "EditFormula";
            this.hlpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File name formula";
            this.groupBox1.ResumeLayout(false);
            this.grpFileName.ResumeLayout(false);
            this.grpFileName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.ListBox lsbFilenames;
        private System.Windows.Forms.ComboBox cmbFormula;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.ListBox lsbAvailableTexts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpFileName;
        private System.Windows.Forms.Label lblNoFile;
        private System.Windows.Forms.ErrorProvider Error;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ToolTip tlpMain;
        private System.Windows.Forms.HelpProvider hlpHelp;
    }
}