namespace TagInfoControls
{
    partial class Popularimeter
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
            this.dgvRating = new System.Windows.Forms.DataGridView();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.lblCounterL = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRating)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRating
            // 
            this.dgvRating.AllowUserToAddRows = false;
            this.dgvRating.AllowUserToDeleteRows = false;
            this.dgvRating.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRating.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRating.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Email,
            this.Rating,
            this.Counter});
            this.dgvRating.Location = new System.Drawing.Point(0, 0);
            this.dgvRating.Name = "dgvRating";
            this.dgvRating.Size = new System.Drawing.Size(496, 236);
            this.dgvRating.TabIndex = 0;
            this.tlpMain.SetToolTip(this.dgvRating, "List of persons who had rated the file");
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.Width = 250;
            // 
            // Rating
            // 
            this.Rating.HeaderText = "Rating";
            this.Rating.Name = "Rating";
            // 
            // Counter
            // 
            this.Counter.HeaderText = "Counter";
            this.Counter.Name = "Counter";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = global::TagInfoControls.Properties.Resources.DeleteFolderHS;
            this.btnClear.Location = new System.Drawing.Point(470, 242);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 26);
            this.btnClear.TabIndex = 4;
            this.tlpMain.SetToolTip(this.btnClear, "Clear list of ratings");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(106, 249);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(50, 13);
            this.lblCounter.TabIndex = 20;
            this.lblCounter.Text = "[Counter]";
            this.tlpMain.SetToolTip(this.lblCounter, "Number of times file played");
            // 
            // lblCounterL
            // 
            this.lblCounterL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCounterL.AutoSize = true;
            this.lblCounterL.Location = new System.Drawing.Point(30, 249);
            this.lblCounterL.Name = "lblCounterL";
            this.lblCounterL.Size = new System.Drawing.Size(70, 13);
            this.lblCounterL.TabIndex = 19;
            this.lblCounterL.Text = "Play Counter:";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Image = global::TagInfoControls.Properties.Resources.DeleteHS;
            this.btnRemove.Location = new System.Drawing.Point(0, 242);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 26);
            this.btnRemove.TabIndex = 21;
            this.tlpMain.SetToolTip(this.btnRemove, "Clear Counter");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Popularimeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblCounterL);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgvRating);
            this.Name = "Popularimeter";
            this.Size = new System.Drawing.Size(497, 271);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRating)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRating;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn Counter;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label lblCounterL;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolTip tlpMain;
    }
}
