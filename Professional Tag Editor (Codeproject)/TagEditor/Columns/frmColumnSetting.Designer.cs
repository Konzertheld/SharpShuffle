namespace TagEditor.Columns
{
    partial class frmColumnSetting
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lsbColumns = new System.Windows.Forms.ListBox();
            this.lnkDefault = new System.Windows.Forms.LinkLabel();
            this.grbAvailable = new System.Windows.Forms.GroupBox();
            this.grbUsed = new System.Windows.Forms.GroupBox();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.grbAvailable.SuspendLayout();
            this.grbUsed.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(174, 46);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(79, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add";
            this.tlpMain.SetToolTip(this.btnAdd, "Add selected column to used list");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(6, 22);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(38, 13);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Name:";
            // 
            // cmbName
            // 
            this.cmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.IntegralHeight = false;
            this.cmbName.Location = new System.Drawing.Point(50, 19);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(203, 21);
            this.cmbName.Sorted = true;
            this.cmbName.TabIndex = 1;
            this.tlpMain.SetToolTip(this.cmbName, "List of available columns");
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(229, 48);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 23);
            this.btnDown.TabIndex = 2;
            this.btnDown.Text = "▼";
            this.tlpMain.SetToolTip(this.btnDown, "Move selected used column one row down");
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(229, 19);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 23);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "▲";
            this.tlpMain.SetToolTip(this.btnUp, "Move selected used column one row up");
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(115, 315);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.tlpMain.SetToolTip(this.btnOK, "Make change to used columns");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(196, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.tlpMain.SetToolTip(this.btnCancel, "Cancel changing used columns");
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::TagEditor.Properties.Resources.Icon_132;
            this.btnRemove.Location = new System.Drawing.Point(229, 77);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 25);
            this.btnRemove.TabIndex = 3;
            this.tlpMain.SetToolTip(this.btnRemove, "Remove selected used column from used column list");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lsbColumns
            // 
            this.lsbColumns.FormattingEnabled = true;
            this.lsbColumns.Location = new System.Drawing.Point(6, 19);
            this.lsbColumns.Name = "lsbColumns";
            this.lsbColumns.Size = new System.Drawing.Size(217, 186);
            this.lsbColumns.TabIndex = 0;
            this.tlpMain.SetToolTip(this.lsbColumns, "List of used columns");
            this.lsbColumns.SelectedIndexChanged += new System.EventHandler(this.clbColumns_SelectedIndexChanged);
            // 
            // lnkDefault
            // 
            this.lnkDefault.AutoSize = true;
            this.lnkDefault.Location = new System.Drawing.Point(9, 320);
            this.lnkDefault.Name = "lnkDefault";
            this.lnkDefault.Size = new System.Drawing.Size(41, 13);
            this.lnkDefault.TabIndex = 2;
            this.lnkDefault.TabStop = true;
            this.lnkDefault.Text = "Default";
            this.tlpMain.SetToolTip(this.lnkDefault, "Restore list of used columns to it\'s default value");
            this.lnkDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDefault_LinkClicked);
            // 
            // grbAvailable
            // 
            this.grbAvailable.Controls.Add(this.cmbName);
            this.grbAvailable.Controls.Add(this.lblInfo);
            this.grbAvailable.Controls.Add(this.btnAdd);
            this.grbAvailable.Location = new System.Drawing.Point(12, 12);
            this.grbAvailable.Name = "grbAvailable";
            this.grbAvailable.Size = new System.Drawing.Size(259, 73);
            this.grbAvailable.TabIndex = 0;
            this.grbAvailable.TabStop = false;
            this.grbAvailable.Text = "Available Columns";
            // 
            // grbUsed
            // 
            this.grbUsed.Controls.Add(this.lsbColumns);
            this.grbUsed.Controls.Add(this.btnUp);
            this.grbUsed.Controls.Add(this.btnDown);
            this.grbUsed.Controls.Add(this.btnRemove);
            this.grbUsed.Location = new System.Drawing.Point(12, 91);
            this.grbUsed.Name = "grbUsed";
            this.grbUsed.Size = new System.Drawing.Size(259, 218);
            this.grbUsed.TabIndex = 1;
            this.grbUsed.TabStop = false;
            this.grbUsed.Text = "Used Columns";
            // 
            // frmColumnSetting
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(279, 344);
            this.Controls.Add(this.grbUsed);
            this.Controls.Add(this.grbAvailable);
            this.Controls.Add(this.lnkDefault);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmColumnSetting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Column Setting";
            this.Load += new System.EventHandler(this.frmColumnSetting_Load);
            this.grbAvailable.ResumeLayout(false);
            this.grbAvailable.PerformLayout();
            this.grbUsed.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lsbColumns;
        private System.Windows.Forms.LinkLabel lnkDefault;
        private System.Windows.Forms.GroupBox grbAvailable;
        private System.Windows.Forms.GroupBox grbUsed;
        private System.Windows.Forms.ToolTip tlpMain;
    }
}