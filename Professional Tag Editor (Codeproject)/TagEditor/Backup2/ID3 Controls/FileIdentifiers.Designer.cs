namespace TagInfoControls
{
    partial class FileIdentifiers
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
            this.lblFileData = new System.Windows.Forms.Label();
            this.txtFileOwner = new System.Windows.Forms.TextBox();
            this.lblFileOwner = new System.Windows.Forms.Label();
            this.lsbIdentifiers = new TagInfoControls.SmallControls.FrameList();
            this.grpSelectedItem = new System.Windows.Forms.GroupBox();
            this.txtData = new TagInfoControls.SmallControls.HexBoxEx();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.grpSelectedItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileData
            // 
            this.lblFileData.AutoSize = true;
            this.lblFileData.Location = new System.Drawing.Point(7, 45);
            this.lblFileData.Name = "lblFileData";
            this.lblFileData.Size = new System.Drawing.Size(33, 13);
            this.lblFileData.TabIndex = 5;
            this.lblFileData.Text = "&Data:";
            // 
            // txtFileOwner
            // 
            this.txtFileOwner.Location = new System.Drawing.Point(54, 19);
            this.txtFileOwner.Name = "txtFileOwner";
            this.txtFileOwner.Size = new System.Drawing.Size(215, 20);
            this.txtFileOwner.TabIndex = 4;
            this.tlpMain.SetToolTip(this.txtFileOwner, "The owner of identifier");
            this.txtFileOwner.Validated += new System.EventHandler(this.txtFileOwner_Validated);
            this.txtFileOwner.Validating += new System.ComponentModel.CancelEventHandler(this.txtFileOwner_Validating);
            // 
            // lblFileOwner
            // 
            this.lblFileOwner.AutoSize = true;
            this.lblFileOwner.Location = new System.Drawing.Point(7, 22);
            this.lblFileOwner.Name = "lblFileOwner";
            this.lblFileOwner.Size = new System.Drawing.Size(41, 13);
            this.lblFileOwner.TabIndex = 3;
            this.lblFileOwner.Text = "&Owner:";
            // 
            // lsbIdentifiers
            // 
            this.lsbIdentifiers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbIdentifiers.Location = new System.Drawing.Point(0, 0);
            this.lsbIdentifiers.Name = "lsbIdentifiers";
            this.lsbIdentifiers.Size = new System.Drawing.Size(163, 167);
            this.lsbIdentifiers.TabIndex = 9;
            this.lsbIdentifiers.AddClicked += new System.EventHandler(this.lsbIdentifiers_AddClicked);
            this.lsbIdentifiers.SelectedIndexChanged += new System.EventHandler(this.lsbIdentifiers_SelectedIndexChanged);
            // 
            // grpSelectedItem
            // 
            this.grpSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSelectedItem.Controls.Add(this.txtData);
            this.grpSelectedItem.Controls.Add(this.lblFileOwner);
            this.grpSelectedItem.Controls.Add(this.txtFileOwner);
            this.grpSelectedItem.Controls.Add(this.lblFileData);
            this.grpSelectedItem.Location = new System.Drawing.Point(169, 3);
            this.grpSelectedItem.Name = "grpSelectedItem";
            this.grpSelectedItem.Size = new System.Drawing.Size(305, 164);
            this.grpSelectedItem.TabIndex = 11;
            this.grpSelectedItem.TabStop = false;
            this.grpSelectedItem.Text = "Selected Identifier";
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Data = null;
            this.txtData.Location = new System.Drawing.Point(54, 45);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(247, 113);
            this.txtData.TabIndex = 6;
            this.txtData.Validated += new System.EventHandler(this.txtData_Validated_1);
            // 
            // FileIdentifiers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSelectedItem);
            this.Controls.Add(this.lsbIdentifiers);
            this.Name = "FileIdentifiers";
            this.Size = new System.Drawing.Size(480, 171);
            this.grpSelectedItem.ResumeLayout(false);
            this.grpSelectedItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFileData;
        private System.Windows.Forms.TextBox txtFileOwner;
        private System.Windows.Forms.Label lblFileOwner;
        private TagInfoControls.SmallControls.FrameList lsbIdentifiers;
        private System.Windows.Forms.GroupBox grpSelectedItem;
        private TagInfoControls.SmallControls.HexBoxEx txtData;
        private System.Windows.Forms.ToolTip tlpMain;
    }
}
