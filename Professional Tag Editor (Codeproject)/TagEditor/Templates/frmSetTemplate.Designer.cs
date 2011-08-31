namespace TagEditor.Templates
{
    partial class frmSetTemplate
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
            this.lblLName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLDescription = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCopyType = new System.Windows.Forms.Label();
            this.cmbCopyType = new System.Windows.Forms.ComboBox();
            this.lblCopyTypeDescription = new System.Windows.Forms.Label();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctrlTagSummary = new TagEditor.TagSummary();
            this.hlpHelp = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // lblLName
            // 
            this.lblLName.AutoSize = true;
            this.lblLName.Location = new System.Drawing.Point(12, 9);
            this.lblLName.Name = "lblLName";
            this.lblLName.Size = new System.Drawing.Size(38, 13);
            this.lblLName.TabIndex = 0;
            this.lblLName.Text = "Name:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(81, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "[Name]";
            // 
            // lblLDescription
            // 
            this.lblLDescription.AutoSize = true;
            this.lblLDescription.Location = new System.Drawing.Point(12, 37);
            this.lblLDescription.Name = "lblLDescription";
            this.lblLDescription.Size = new System.Drawing.Size(63, 13);
            this.lblLDescription.TabIndex = 2;
            this.lblLDescription.Text = "Description:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(81, 37);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "[Description]";
            // 
            // lblCopyType
            // 
            this.lblCopyType.AutoSize = true;
            this.lblCopyType.Location = new System.Drawing.Point(12, 65);
            this.lblCopyType.Name = "lblCopyType";
            this.lblCopyType.Size = new System.Drawing.Size(61, 13);
            this.lblCopyType.TabIndex = 4;
            this.lblCopyType.Text = "Copy Type:";
            // 
            // cmbCopyType
            // 
            this.cmbCopyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCopyType.FormattingEnabled = true;
            this.cmbCopyType.Items.AddRange(new object[] {
            "Clean Copy",
            "Safe Copy",
            "Overwrite"});
            this.cmbCopyType.Location = new System.Drawing.Point(84, 61);
            this.cmbCopyType.Name = "cmbCopyType";
            this.cmbCopyType.Size = new System.Drawing.Size(121, 21);
            this.cmbCopyType.TabIndex = 5;
            this.cmbCopyType.SelectedIndexChanged += new System.EventHandler(this.cmbCopyTypes_SelectedIndexChanged);
            // 
            // lblCopyTypeDescription
            // 
            this.lblCopyTypeDescription.Location = new System.Drawing.Point(211, 65);
            this.lblCopyTypeDescription.Name = "lblCopyTypeDescription";
            this.lblCopyTypeDescription.Size = new System.Drawing.Size(234, 31);
            this.lblCopyTypeDescription.TabIndex = 6;
            this.lblCopyTypeDescription.Text = "[CopyTypeDescription]";
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(12, 267);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(218, 13);
            this.lblQuestion.TabIndex = 7;
            this.lblQuestion.Text = "Are you sure you want to set this template to ";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(289, 294);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(370, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // ctrlTagSummary
            // 
            this.ctrlTagSummary.Location = new System.Drawing.Point(10, 88);
            this.ctrlTagSummary.Name = "ctrlTagSummary";
            this.ctrlTagSummary.Size = new System.Drawing.Size(192, 159);
            this.ctrlTagSummary.TabIndex = 10;
            // 
            // hlpHelp
            // 
            this.hlpHelp.HelpNamespace = "Help.chm";
            // 
            // frmSetTemplate
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(457, 329);
            this.Controls.Add(this.ctrlTagSummary);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblCopyTypeDescription);
            this.Controls.Add(this.cmbCopyType);
            this.Controls.Add(this.lblCopyType);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblLDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.hlpHelp.SetHelpKeyword(this, "Use Template");
            this.hlpHelp.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.Name = "frmSetTemplate";
            this.hlpHelp.SetShowHelp(this, true);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Template";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCopyType;
        private System.Windows.Forms.ComboBox cmbCopyType;
        private System.Windows.Forms.Label lblCopyTypeDescription;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private TagSummary ctrlTagSummary;
        private System.Windows.Forms.HelpProvider hlpHelp;
    }
}