namespace TagInfoControls.SmallControls
{
    partial class FrameList
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
            this.lsbFrames = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lsbFrames
            // 
            this.lsbFrames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbFrames.FormattingEnabled = true;
            this.lsbFrames.Location = new System.Drawing.Point(0, 0);
            this.lsbFrames.Name = "lsbFrames";
            this.lsbFrames.Size = new System.Drawing.Size(163, 238);
            this.lsbFrames.TabIndex = 0;
            this.tlpMain.SetToolTip(this.lsbFrames, "List of available items");
            this.lsbFrames.SelectedIndexChanged += new System.EventHandler(this.lsbFrames_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::TagInfoControls.Properties.Resources.saveHS;
            this.btnSave.Location = new System.Drawing.Point(30, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 26);
            this.btnSave.TabIndex = 4;
            this.tlpMain.SetToolTip(this.btnSave, "Save selected item");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = global::TagInfoControls.Properties.Resources.DeleteFolderHS;
            this.btnClear.Location = new System.Drawing.Point(139, 240);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 26);
            this.btnClear.TabIndex = 3;
            this.tlpMain.SetToolTip(this.btnClear, "Clear the list");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Image = global::TagInfoControls.Properties.Resources.DeleteHS;
            this.btnRemove.Location = new System.Drawing.Point(109, 240);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 26);
            this.btnRemove.TabIndex = 2;
            this.tlpMain.SetToolTip(this.btnRemove, "Delete selected item");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Image = global::TagInfoControls.Properties.Resources.NewDocumentHS;
            this.btnAdd.Location = new System.Drawing.Point(0, 240);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 26);
            this.btnAdd.TabIndex = 1;
            this.tlpMain.SetToolTip(this.btnAdd, "Add new item to list");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrameList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lsbFrames);
            this.Name = "FrameList";
            this.Size = new System.Drawing.Size(163, 266);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lsbFrames;
        private System.Windows.Forms.Button btnSave;
        /// <summary>
        /// The main tooltip provider
        /// </summary>
        public System.Windows.Forms.ToolTip tlpMain;
    }
}
