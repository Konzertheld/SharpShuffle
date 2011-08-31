namespace TagEditor
{
    partial class SaveFiles
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
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFileNameL = new System.Windows.Forms.Label();
            this.lblFileName = new System.Windows.Forms.Label();
            this.bgwSaveFiles = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // prgProgress
            // 
            this.prgProgress.Location = new System.Drawing.Point(12, 29);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(355, 23);
            this.prgProgress.Step = 1;
            this.prgProgress.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(373, 29);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblFileNameL
            // 
            this.lblFileNameL.AutoSize = true;
            this.lblFileNameL.Location = new System.Drawing.Point(12, 9);
            this.lblFileNameL.Name = "lblFileNameL";
            this.lblFileNameL.Size = new System.Drawing.Size(57, 13);
            this.lblFileNameL.TabIndex = 2;
            this.lblFileNameL.Text = "File Name:";
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(75, 9);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(57, 13);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "[FileName]";
            // 
            // bgwSaveFiles
            // 
            this.bgwSaveFiles.WorkerReportsProgress = true;
            this.bgwSaveFiles.WorkerSupportsCancellation = true;
            this.bgwSaveFiles.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSaveFiles_DoWork);
            this.bgwSaveFiles.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSaveFiles_RunWorkerCompleted);
            // 
            // SaveFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 61);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.lblFileNameL);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.prgProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SaveFiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SaveFiles";
            this.Load += new System.EventHandler(this.SaveFiles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgProgress;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFileNameL;
        private System.Windows.Forms.Label lblFileName;
        private System.ComponentModel.BackgroundWorker bgwSaveFiles;
    }
}