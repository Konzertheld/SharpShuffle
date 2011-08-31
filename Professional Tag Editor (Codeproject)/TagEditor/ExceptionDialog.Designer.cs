namespace TagEditor
{
    partial class ExceptionDialog
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lnlReport = new System.Windows.Forms.LinkLabel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(12, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(372, 48);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "We are sorry to show this message. Unknown error occured in application. You can " +
                "report this error. To report error send the following error include the files yo" +
                "u have problem with.";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(309, 227);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lnlReport
            // 
            this.lnlReport.AutoSize = true;
            this.lnlReport.LinkArea = new System.Windows.Forms.LinkArea(0, 18);
            this.lnlReport.Location = new System.Drawing.Point(12, 54);
            this.lnlReport.Name = "lnlReport";
            this.lnlReport.Size = new System.Drawing.Size(104, 13);
            this.lnlReport.TabIndex = 4;
            this.lnlReport.TabStop = true;
            this.lnlReport.Text = "hamed.ji@gmail.com";
            this.lnlReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnlReport_LinkClicked);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 73);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(372, 148);
            this.txtMessage.TabIndex = 5;
            // 
            // ExceptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 262);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lnlReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExceptionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sorry for exception occured ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.LinkLabel lnlReport;
        private System.Windows.Forms.TextBox txtMessage;
    }
}