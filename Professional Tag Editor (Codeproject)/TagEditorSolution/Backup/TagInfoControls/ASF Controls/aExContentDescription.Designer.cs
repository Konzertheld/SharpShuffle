namespace TagInfoControls
{
    partial class aExContentDescription
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
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clmValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmName,
            this.clmType,
            this.clmValue});
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size(511, 310);
            this.dgvList.TabIndex = 0;
            this.dgvList.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvList_RowValidating);
            this.dgvList.SelectionChanged += new System.EventHandler(this.dgvList_SelectionChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = global::TagInfoControls.Properties.Resources.DeleteFolderHS;
            this.btnClear.Location = new System.Drawing.Point(484, 316);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 26);
            this.btnClear.TabIndex = 7;
            this.tlpMain.SetToolTip(this.btnClear, "Clear all list");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = global::TagInfoControls.Properties.Resources.DeleteHS;
            this.btnRemove.Location = new System.Drawing.Point(454, 316);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 26);
            this.btnRemove.TabIndex = 6;
            this.tlpMain.SetToolTip(this.btnRemove, "Delete current row");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // clmName
            // 
            this.clmName.HeaderText = "Name";
            this.clmName.Name = "clmName";
            this.clmName.Width = 150;
            // 
            // clmType
            // 
            this.clmType.HeaderText = "Type";
            this.clmType.Items.AddRange(new object[] {
            "String",
            "Bool",
            "Number"});
            this.clmType.Name = "clmType";
            this.clmType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clmValue
            // 
            this.clmValue.HeaderText = "Value";
            this.clmValue.Name = "clmValue";
            this.clmValue.Width = 200;
            // 
            // aExContentDescription
            // 
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.dgvList);
            this.Name = "aExContentDescription";
            this.Size = new System.Drawing.Size(511, 345);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolTip tlpMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmValue;
    }
}
