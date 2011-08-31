namespace TagInfoControls
{
    partial class Commercial
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSellerName = new System.Windows.Forms.TextBox();
            this.cmbRecievedAs = new System.Windows.Forms.ComboBox();
            this.txtContactURL = new System.Windows.Forms.TextBox();
            this.txtValidUntil = new System.Windows.Forms.MaskedTextBox();
            this.grbSellerLogo = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pcbSeller = new System.Windows.Forms.PictureBox();
            this.lblMIME = new System.Windows.Forms.Label();
            this.lblMIMEL = new System.Windows.Forms.Label();
            this.lblSellerLogo = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSellerName = new System.Windows.Forms.Label();
            this.lblRecievedAs = new System.Windows.Forms.Label();
            this.lblContactURL = new System.Windows.Forms.Label();
            this.lblValidUntil = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.prbPrice = new TagInfoControls.SmallControls.PriceBox();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.erpError = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbSellerLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSeller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(80, 133);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(186, 20);
            this.txtDescription.TabIndex = 11;
            this.tlpMain.SetToolTip(this.txtDescription, "Description about file commercial information");
            // 
            // txtSellerName
            // 
            this.txtSellerName.Location = new System.Drawing.Point(80, 107);
            this.txtSellerName.Name = "txtSellerName";
            this.txtSellerName.Size = new System.Drawing.Size(186, 20);
            this.txtSellerName.TabIndex = 9;
            this.tlpMain.SetToolTip(this.txtSellerName, "Name of seller");
            // 
            // cmbRecievedAs
            // 
            this.cmbRecievedAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecievedAs.FormattingEnabled = true;
            this.cmbRecievedAs.Items.AddRange(new object[] {
            "Other",
            "Standard CD album",
            "Compressed audio on CD",
            "File over the Internet",
            "Stream over the Internet",
            "As note sheets",
            "As note sheets in a book",
            "Music on other media",
            "Non-musical merchandise"});
            this.cmbRecievedAs.Location = new System.Drawing.Point(80, 80);
            this.cmbRecievedAs.Name = "cmbRecievedAs";
            this.cmbRecievedAs.Size = new System.Drawing.Size(186, 21);
            this.cmbRecievedAs.TabIndex = 7;
            this.tlpMain.SetToolTip(this.cmbRecievedAs, "Recievation type of file");
            // 
            // txtContactURL
            // 
            this.txtContactURL.Location = new System.Drawing.Point(80, 54);
            this.txtContactURL.Name = "txtContactURL";
            this.txtContactURL.Size = new System.Drawing.Size(186, 20);
            this.txtContactURL.TabIndex = 5;
            this.tlpMain.SetToolTip(this.txtContactURL, "URL to contact to seller");
            // 
            // txtValidUntil
            // 
            this.txtValidUntil.Location = new System.Drawing.Point(80, 28);
            this.txtValidUntil.Mask = "0000/00/00";
            this.txtValidUntil.Name = "txtValidUntil";
            this.txtValidUntil.Size = new System.Drawing.Size(72, 20);
            this.txtValidUntil.TabIndex = 3;
            this.tlpMain.SetToolTip(this.txtValidUntil, "Date of validation of price");
            // 
            // grbSellerLogo
            // 
            this.grbSellerLogo.Controls.Add(this.btnClear);
            this.grbSellerLogo.Controls.Add(this.btnSave);
            this.grbSellerLogo.Controls.Add(this.btnBrowse);
            this.grbSellerLogo.Controls.Add(this.pcbSeller);
            this.grbSellerLogo.Controls.Add(this.lblMIME);
            this.grbSellerLogo.Controls.Add(this.lblMIMEL);
            this.grbSellerLogo.Controls.Add(this.lblSellerLogo);
            this.grbSellerLogo.Location = new System.Drawing.Point(272, 30);
            this.grbSellerLogo.Name = "grbSellerLogo";
            this.grbSellerLogo.Size = new System.Drawing.Size(179, 122);
            this.grbSellerLogo.TabIndex = 12;
            this.grbSellerLogo.TabStop = false;
            this.grbSellerLogo.Text = "Seller Logo";
            // 
            // btnClear
            // 
            this.btnClear.Image = global::TagInfoControls.Properties.Resources.DeleteHS;
            this.btnClear.Location = new System.Drawing.Point(141, 90);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 26);
            this.btnClear.TabIndex = 5;
            this.tlpMain.SetToolTip(this.btnClear, "Clear logo part");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::TagInfoControls.Properties.Resources.saveHS;
            this.btnSave.Location = new System.Drawing.Point(111, 90);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 26);
            this.btnSave.TabIndex = 4;
            this.tlpMain.SetToolTip(this.btnSave, "Save logo to file");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Image = global::TagInfoControls.Properties.Resources.openHS;
            this.btnBrowse.Location = new System.Drawing.Point(81, 90);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 26);
            this.btnBrowse.TabIndex = 3;
            this.tlpMain.SetToolTip(this.btnBrowse, "Open logo from file");
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // pcbSeller
            // 
            this.pcbSeller.Location = new System.Drawing.Point(75, 35);
            this.pcbSeller.Name = "pcbSeller";
            this.pcbSeller.Size = new System.Drawing.Size(98, 49);
            this.pcbSeller.TabIndex = 9;
            this.pcbSeller.TabStop = false;
            this.tlpMain.SetToolTip(this.pcbSeller, "Logo of seller");
            this.pcbSeller.Click += new System.EventHandler(this.pcbSeller_Click);
            // 
            // lblMIME
            // 
            this.lblMIME.AutoSize = true;
            this.lblMIME.Location = new System.Drawing.Point(77, 16);
            this.lblMIME.Name = "lblMIME";
            this.lblMIME.Size = new System.Drawing.Size(0, 13);
            this.lblMIME.TabIndex = 1;
            this.tlpMain.SetToolTip(this.lblMIME, "MIME type of logo");
            // 
            // lblMIMEL
            // 
            this.lblMIMEL.AutoSize = true;
            this.lblMIMEL.Location = new System.Drawing.Point(6, 16);
            this.lblMIMEL.Name = "lblMIMEL";
            this.lblMIMEL.Size = new System.Drawing.Size(65, 13);
            this.lblMIMEL.TabIndex = 0;
            this.lblMIMEL.Text = "Logo MIME:";
            // 
            // lblSellerLogo
            // 
            this.lblSellerLogo.AutoSize = true;
            this.lblSellerLogo.Location = new System.Drawing.Point(6, 35);
            this.lblSellerLogo.Name = "lblSellerLogo";
            this.lblSellerLogo.Size = new System.Drawing.Size(63, 13);
            this.lblSellerLogo.TabIndex = 2;
            this.lblSellerLogo.Text = "Seller Logo:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(3, 136);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "&Description:";
            // 
            // lblSellerName
            // 
            this.lblSellerName.AutoSize = true;
            this.lblSellerName.Location = new System.Drawing.Point(3, 110);
            this.lblSellerName.Name = "lblSellerName";
            this.lblSellerName.Size = new System.Drawing.Size(67, 13);
            this.lblSellerName.TabIndex = 8;
            this.lblSellerName.Text = "&Seller Name:";
            // 
            // lblRecievedAs
            // 
            this.lblRecievedAs.AutoSize = true;
            this.lblRecievedAs.Location = new System.Drawing.Point(3, 83);
            this.lblRecievedAs.Name = "lblRecievedAs";
            this.lblRecievedAs.Size = new System.Drawing.Size(71, 13);
            this.lblRecievedAs.TabIndex = 6;
            this.lblRecievedAs.Text = "R&ecieved As:";
            // 
            // lblContactURL
            // 
            this.lblContactURL.AutoSize = true;
            this.lblContactURL.Location = new System.Drawing.Point(3, 57);
            this.lblContactURL.Name = "lblContactURL";
            this.lblContactURL.Size = new System.Drawing.Size(72, 13);
            this.lblContactURL.TabIndex = 4;
            this.lblContactURL.Text = "C&ontact URL:";
            // 
            // lblValidUntil
            // 
            this.lblValidUntil.AutoSize = true;
            this.lblValidUntil.Location = new System.Drawing.Point(3, 31);
            this.lblValidUntil.Name = "lblValidUntil";
            this.lblValidUntil.Size = new System.Drawing.Size(57, 13);
            this.lblValidUntil.TabIndex = 2;
            this.lblValidUntil.Tag = "";
            this.lblValidUntil.Text = "&Valid Until:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(3, 4);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "P&rice:";
            // 
            // prbPrice
            // 
            this.prbPrice.Location = new System.Drawing.Point(80, 1);
            this.prbPrice.MinimumSize = new System.Drawing.Size(200, 21);
            this.prbPrice.Name = "prbPrice";
            this.prbPrice.Price = "";
            this.prbPrice.Size = new System.Drawing.Size(289, 21);
            this.prbPrice.TabIndex = 1;
            this.tlpMain.SetToolTip(this.prbPrice, "Price that payed\\");
            this.prbPrice.TextChanged += new System.EventHandler(this.prbPrice_TextChanged);
            // 
            // erpError
            // 
            this.erpError.ContainerControl = this;
            // 
            // Commercial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.prbPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtSellerName);
            this.Controls.Add(this.cmbRecievedAs);
            this.Controls.Add(this.txtContactURL);
            this.Controls.Add(this.txtValidUntil);
            this.Controls.Add(this.grbSellerLogo);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblSellerName);
            this.Controls.Add(this.lblRecievedAs);
            this.Controls.Add(this.lblContactURL);
            this.Controls.Add(this.lblValidUntil);
            this.Controls.Add(this.lblPrice);
            this.Name = "Commercial";
            this.Size = new System.Drawing.Size(454, 157);
            this.grbSellerLogo.ResumeLayout(false);
            this.grbSellerLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSeller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtSellerName;
        private System.Windows.Forms.ComboBox cmbRecievedAs;
        private System.Windows.Forms.TextBox txtContactURL;
        private System.Windows.Forms.MaskedTextBox txtValidUntil;
        private System.Windows.Forms.GroupBox grbSellerLogo;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox pcbSeller;
        private System.Windows.Forms.Label lblMIME;
        private System.Windows.Forms.Label lblMIMEL;
        private System.Windows.Forms.Label lblSellerLogo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSellerName;
        private System.Windows.Forms.Label lblRecievedAs;
        private System.Windows.Forms.Label lblContactURL;
        private System.Windows.Forms.Label lblValidUntil;
        private System.Windows.Forms.Label lblPrice;
        private TagInfoControls.SmallControls.PriceBox prbPrice;
        private System.Windows.Forms.ToolTip tlpMain;
        private System.Windows.Forms.ErrorProvider erpError;
    }
}
