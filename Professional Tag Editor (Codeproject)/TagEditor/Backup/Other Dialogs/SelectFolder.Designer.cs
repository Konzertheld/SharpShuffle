namespace TagEditor
{
    partial class SelectFolder
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chbClearList = new System.Windows.Forms.CheckBox();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblFileType = new System.Windows.Forms.Label();
            this.rdbMP3 = new System.Windows.Forms.RadioButton();
            this.rdbWMA = new System.Windows.Forms.RadioButton();
            this.lblPath = new System.Windows.Forms.Label();
            this.frmSelectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.hlpHelp = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 106);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.tlpMain.SetToolTip(this.btnCancel, "Cancel");
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(116, 106);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.tlpMain.SetToolTip(this.btnOK, "Add Files");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chbClearList
            // 
            this.chbClearList.AutoSize = true;
            this.chbClearList.Checked = true;
            this.chbClearList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbClearList.Location = new System.Drawing.Point(12, 80);
            this.chbClearList.Name = "chbClearList";
            this.chbClearList.Size = new System.Drawing.Size(101, 17);
            this.chbClearList.TabIndex = 7;
            this.chbClearList.Text = "C&lear current list";
            this.tlpMain.SetToolTip(this.chbClearList, "Before adding files to list clear the list");
            this.chbClearList.UseVisualStyleBackColor = true;
            this.chbClearList.CheckedChanged += new System.EventHandler(this.chbClearList_CheckedChanged);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(47, 43);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(190, 20);
            this.txtPath.TabIndex = 4;
            this.tlpMain.SetToolTip(this.txtPath, "Selected path");
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = global::TagEditor.Properties.Resources.Control_FolderBrowserDialog;
            this.btnBrowse.Location = new System.Drawing.Point(243, 41);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(29, 23);
            this.btnBrowse.TabIndex = 5;
            this.tlpMain.SetToolTip(this.btnBrowse, "Select a folder");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Location = new System.Drawing.Point(9, 12);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(53, 13);
            this.lblFileType.TabIndex = 0;
            this.lblFileType.Text = "File Type:";
            // 
            // rdbMP3
            // 
            this.rdbMP3.AutoSize = true;
            this.rdbMP3.Location = new System.Drawing.Point(95, 10);
            this.rdbMP3.Name = "rdbMP3";
            this.rdbMP3.Size = new System.Drawing.Size(47, 17);
            this.rdbMP3.TabIndex = 1;
            this.rdbMP3.TabStop = true;
            this.rdbMP3.Text = "&MP3";
            this.tlpMain.SetToolTip(this.rdbMP3, "Add Mp3 file from selected folder");
            this.rdbMP3.UseVisualStyleBackColor = true;
            // 
            // rdbWMA
            // 
            this.rdbWMA.AutoSize = true;
            this.rdbWMA.Location = new System.Drawing.Point(185, 10);
            this.rdbWMA.Name = "rdbWMA";
            this.rdbWMA.Size = new System.Drawing.Size(52, 17);
            this.rdbWMA.TabIndex = 2;
            this.rdbWMA.TabStop = true;
            this.rdbWMA.Text = "&WMA";
            this.tlpMain.SetToolTip(this.rdbWMA, "Add Wma files from selected forlder");
            this.rdbWMA.UseVisualStyleBackColor = true;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(9, 46);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 3;
            this.lblPath.Text = "Path:";
            // 
            // frmSelectFolder
            // 
            this.frmSelectFolder.Description = "Select folder to open all files included:";
            // 
            // hlpHelp
            // 
            this.hlpHelp.HelpNamespace = "Help.chm";
            // 
            // SelectFolder
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 138);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.rdbWMA);
            this.Controls.Add(this.rdbMP3);
            this.Controls.Add(this.lblFileType);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.chbClearList);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.hlpHelp.SetHelpKeyword(this, "Add Directory");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectFolder";
            this.hlpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.Text = "Add Folder to list";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chbClearList;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.RadioButton rdbMP3;
        private System.Windows.Forms.RadioButton rdbWMA;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.FolderBrowserDialog frmSelectFolder;
        private System.Windows.Forms.ToolTip tlpMain;
        private System.Windows.Forms.HelpProvider hlpHelp;
    }
}