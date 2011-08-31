namespace TagInfoControls
{
    partial class aSimpleText
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtCopyright = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.grpRating = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddRating = new System.Windows.Forms.Button();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.lsbRatings = new System.Windows.Forms.ListBox();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.grpRating.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(72, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(143, 20);
            this.txtTitle.TabIndex = 1;
            this.tlpMain.SetToolTip(this.txtTitle, "Title of song");
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 84);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description:";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(3, 58);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(54, 13);
            this.lblCopyright.TabIndex = 4;
            this.lblCopyright.Text = "Copyright:";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(3, 32);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(41, 13);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(72, 29);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(143, 20);
            this.txtAuthor.TabIndex = 3;
            this.tlpMain.SetToolTip(this.txtAuthor, "Author of song");
            // 
            // txtCopyright
            // 
            this.txtCopyright.Location = new System.Drawing.Point(72, 55);
            this.txtCopyright.Name = "txtCopyright";
            this.txtCopyright.Size = new System.Drawing.Size(143, 20);
            this.txtCopyright.TabIndex = 5;
            this.tlpMain.SetToolTip(this.txtCopyright, "Copyright notification for this song");
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(72, 81);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(143, 20);
            this.txtDescription.TabIndex = 7;
            this.tlpMain.SetToolTip(this.txtDescription, "Desciption of current song");
            // 
            // grpRating
            // 
            this.grpRating.Controls.Add(this.btnClear);
            this.grpRating.Controls.Add(this.btnRemove);
            this.grpRating.Controls.Add(this.btnAddRating);
            this.grpRating.Controls.Add(this.txtRating);
            this.grpRating.Controls.Add(this.lsbRatings);
            this.grpRating.Location = new System.Drawing.Point(6, 107);
            this.grpRating.Name = "grpRating";
            this.grpRating.Size = new System.Drawing.Size(209, 171);
            this.grpRating.TabIndex = 8;
            this.grpRating.TabStop = false;
            this.grpRating.Text = "Rating";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Image = global::TagInfoControls.Properties.Resources.DeleteFolderHS;
            this.btnClear.Location = new System.Drawing.Point(179, 45);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 26);
            this.btnClear.TabIndex = 5;
            this.tlpMain.SetToolTip(this.btnClear, "Clear list of ratings");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Image = global::TagInfoControls.Properties.Resources.DeleteHS;
            this.btnRemove.Location = new System.Drawing.Point(179, 77);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 26);
            this.btnRemove.TabIndex = 4;
            this.tlpMain.SetToolTip(this.btnRemove, "delete selected rating");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddRating
            // 
            this.btnAddRating.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRating.Enabled = false;
            this.btnAddRating.Image = global::TagInfoControls.Properties.Resources.NewDocumentHS;
            this.btnAddRating.Location = new System.Drawing.Point(179, 15);
            this.btnAddRating.Name = "btnAddRating";
            this.btnAddRating.Size = new System.Drawing.Size(24, 26);
            this.btnAddRating.TabIndex = 1;
            this.tlpMain.SetToolTip(this.btnAddRating, "Add writed rating to list");
            this.btnAddRating.UseVisualStyleBackColor = true;
            this.btnAddRating.Click += new System.EventHandler(this.btnAddRating_Click);
            // 
            // txtRating
            // 
            this.txtRating.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRating.Location = new System.Drawing.Point(6, 19);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(167, 20);
            this.txtRating.TabIndex = 0;
            this.tlpMain.SetToolTip(this.txtRating, "Write here a rating for add");
            this.txtRating.TextChanged += new System.EventHandler(this.txtRating_TextChanged);
            // 
            // lsbRatings
            // 
            this.lsbRatings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbRatings.FormattingEnabled = true;
            this.lsbRatings.Location = new System.Drawing.Point(6, 45);
            this.lsbRatings.Name = "lsbRatings";
            this.lsbRatings.Size = new System.Drawing.Size(167, 121);
            this.lsbRatings.TabIndex = 2;
            this.tlpMain.SetToolTip(this.lsbRatings, "List of available ratings for selected song");
            this.lsbRatings.SelectedIndexChanged += new System.EventHandler(this.lsbRatings_SelectedIndexChanged);
            // 
            // SimpleASFText
            // 
            this.Controls.Add(this.grpRating);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCopyright);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "SimpleASFText";
            this.Size = new System.Drawing.Size(220, 284);
            this.grpRating.ResumeLayout(false);
            this.grpRating.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtCopyright;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox grpRating;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.ListBox lsbRatings;
        private System.Windows.Forms.Button btnAddRating;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolTip tlpMain;
    }
}
