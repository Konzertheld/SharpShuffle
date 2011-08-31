namespace TagEditor
{
    partial class Splash
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lblApplicationDescription = new System.Windows.Forms.Label();
            this.lblCore = new System.Windows.Forms.Label();
            this.lblTagControl = new System.Windows.Forms.Label();
            this.tmrClose = new System.Windows.Forms.Timer(this.components);
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TagEditor.Properties.Resources.id3v2;
            this.pictureBox1.Location = new System.Drawing.Point(446, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 34);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblApplicationName.Location = new System.Drawing.Point(11, 8);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(242, 31);
            this.lblApplicationName.TabIndex = 1;
            this.lblApplicationName.Text = "[Application Name]";
            // 
            // lblApplicationDescription
            // 
            this.lblApplicationDescription.AutoSize = true;
            this.lblApplicationDescription.Location = new System.Drawing.Point(82, 53);
            this.lblApplicationDescription.Name = "lblApplicationDescription";
            this.lblApplicationDescription.Size = new System.Drawing.Size(251, 13);
            this.lblApplicationDescription.TabIndex = 2;
            this.lblApplicationDescription.Text = "An application to view and edit Mp3 and Wma tags.";
            // 
            // lblCore
            // 
            this.lblCore.AutoSize = true;
            this.lblCore.Location = new System.Drawing.Point(11, 113);
            this.lblCore.Name = "lblCore";
            this.lblCore.Size = new System.Drawing.Size(70, 13);
            this.lblCore.TabIndex = 3;
            this.lblCore.Text = "Core Version:";
            // 
            // lblTagControl
            // 
            this.lblTagControl.AutoSize = true;
            this.lblTagControl.Location = new System.Drawing.Point(11, 141);
            this.lblTagControl.Name = "lblTagControl";
            this.lblTagControl.Size = new System.Drawing.Size(103, 13);
            this.lblTagControl.TabIndex = 4;
            this.lblTagControl.Text = "Tag Control Version:";
            // 
            // tmrClose
            // 
            this.tmrClose.Interval = 4500;
            this.tmrClose.Tick += new System.EventHandler(this.tmrClose_Tick);
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblCopyright);
            this.pnlMain.Controls.Add(this.lblApplicationName);
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Controls.Add(this.lblTagControl);
            this.pnlMain.Controls.Add(this.lblApplicationDescription);
            this.pnlMain.Controls.Add(this.lblCore);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(500, 199);
            this.pnlMain.TabIndex = 6;
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(346, 176);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(141, 13);
            this.lblCopyright.TabIndex = 6;
            this.lblCopyright.Text = "Copyright © Hamed J.I 2008";
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 199);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Label lblApplicationDescription;
        private System.Windows.Forms.Label lblCore;
        private System.Windows.Forms.Label lblTagControl;
        private System.Windows.Forms.Timer tmrClose;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblCopyright;
    }
}