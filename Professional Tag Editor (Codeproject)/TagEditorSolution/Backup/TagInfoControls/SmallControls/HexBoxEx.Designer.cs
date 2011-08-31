namespace TagInfoControls.SmallControls
{
    partial class HexBoxEx
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
            this.txtData = new System.Windows.Forms.HexBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.sfdSave = new System.Windows.Forms.SaveFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.sfdOpen = new System.Windows.Forms.OpenFileDialog();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtData
            // 
            this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtData.Data = null;
            this.txtData.Location = new System.Drawing.Point(0, 0);
            this.txtData.MaxLength = 64;
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtData.Size = new System.Drawing.Size(187, 119);
            this.txtData.TabIndex = 9;
            this.tlpMain.SetToolTip(this.txtData, "Data of current selected frame");
            this.txtData.TextChanged += new System.EventHandler(this.hbxData_TextChanged);
            this.txtData.Validated += new System.EventHandler(this.txtData_Validated);
            this.txtData.Validating += new System.ComponentModel.CancelEventHandler(this.txtData_Validating);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::TagInfoControls.Properties.Resources.saveHS;
            this.btnSave.Location = new System.Drawing.Point(193, 29);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 26);
            this.btnSave.TabIndex = 8;
            this.tlpMain.SetToolTip(this.btnSave, "Save current data to a file");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnMusicSave_Click);
            // 
            // sfdSave
            // 
            this.sfdSave.Filter = "Binary Files (*.bin)|*.bin|All files|*.*";
            this.sfdSave.Title = "Save File Owner";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Image = global::TagInfoControls.Properties.Resources.openHS;
            this.btnOpen.Location = new System.Drawing.Point(193, 0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(24, 26);
            this.btnOpen.TabIndex = 7;
            this.tlpMain.SetToolTip(this.btnOpen, "Open data from a file");
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnMusicOpen_Click);
            // 
            // sfdOpen
            // 
            this.sfdOpen.Filter = "Binary Files (*.bin)|*.bin|All files (*.*)|*.*";
            this.sfdOpen.Title = "File Owner";
            // 
            // HexBoxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnOpen);
            this.Name = "HexBoxEx";
            this.Size = new System.Drawing.Size(217, 119);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HexBox txtData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog sfdSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog sfdOpen;
        private System.Windows.Forms.ToolTip tlpMain;
    }
}
