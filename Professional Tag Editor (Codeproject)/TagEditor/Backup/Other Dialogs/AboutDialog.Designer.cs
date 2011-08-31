namespace TagEditor
{
    partial class AboutDialog
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
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCmment = new System.Windows.Forms.TextBox();
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblCoreVer = new System.Windows.Forms.Label();
            this.lblTagControlVer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(263, 205);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtCmment
            // 
            this.txtCmment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCmment.Location = new System.Drawing.Point(18, 43);
            this.txtCmment.Multiline = true;
            this.txtCmment.Name = "txtCmment";
            this.txtCmment.ReadOnly = true;
            this.txtCmment.Size = new System.Drawing.Size(322, 50);
            this.txtCmment.TabIndex = 1;
            this.txtCmment.Text = "This application lets viewing and editing MP3 and WMA tags information. It have i" +
                "t\'s own core for reading and writing data. Also all parts of this application is" +
                " free source and made by C# 2005.";
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblApplicationName.Location = new System.Drawing.Point(12, 9);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(149, 23);
            this.lblApplicationName.TabIndex = 2;
            this.lblApplicationName.Text = "[Name, Version]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Copyright © Hamed J.I 2008";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contact:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(66, 171);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(110, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Hamed.JI@gmail.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblCoreVer
            // 
            this.lblCoreVer.AutoSize = true;
            this.lblCoreVer.Location = new System.Drawing.Point(12, 107);
            this.lblCoreVer.Name = "lblCoreVer";
            this.lblCoreVer.Size = new System.Drawing.Size(70, 13);
            this.lblCoreVer.TabIndex = 6;
            this.lblCoreVer.Text = "Core Version:";
            // 
            // lblTagControlVer
            // 
            this.lblTagControlVer.AutoSize = true;
            this.lblTagControlVer.Location = new System.Drawing.Point(12, 140);
            this.lblTagControlVer.Name = "lblTagControlVer";
            this.lblTagControlVer.Size = new System.Drawing.Size(108, 13);
            this.lblTagControlVer.TabIndex = 7;
            this.lblTagControlVer.Text = "Tag Controls Version:";
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 244);
            this.Controls.Add(this.lblTagControlVer);
            this.Controls.Add(this.lblCoreVer);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblApplicationName);
            this.Controls.Add(this.txtCmment);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AboutDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.AboutDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtCmment;
        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lblCoreVer;
        private System.Windows.Forms.Label lblTagControlVer;
    }
}