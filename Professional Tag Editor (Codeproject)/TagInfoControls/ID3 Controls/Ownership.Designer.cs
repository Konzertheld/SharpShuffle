namespace TagInfoControls
{
    partial class Ownership
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
            this.txtSeller = new System.Windows.Forms.TextBox();
            this.txtPurchDate = new System.Windows.Forms.MaskedTextBox();
            this.lblSeller = new System.Windows.Forms.Label();
            this.lblPurchDate = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.prbPrice = new TagInfoControls.SmallControls.PriceBox();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.erpError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSeller
            // 
            this.txtSeller.Location = new System.Drawing.Point(76, 53);
            this.txtSeller.Name = "txtSeller";
            this.txtSeller.Size = new System.Drawing.Size(173, 20);
            this.txtSeller.TabIndex = 5;
            this.tlpMain.SetToolTip(this.txtSeller, "Name of seller ");
            // 
            // txtPurchDate
            // 
            this.txtPurchDate.Location = new System.Drawing.Point(76, 27);
            this.txtPurchDate.Mask = "0000/00/00";
            this.txtPurchDate.Name = "txtPurchDate";
            this.txtPurchDate.Size = new System.Drawing.Size(72, 20);
            this.txtPurchDate.TabIndex = 3;
            this.tlpMain.SetToolTip(this.txtPurchDate, "Date of file purch");
            // 
            // lblSeller
            // 
            this.lblSeller.AutoSize = true;
            this.lblSeller.Location = new System.Drawing.Point(3, 56);
            this.lblSeller.Name = "lblSeller";
            this.lblSeller.Size = new System.Drawing.Size(36, 13);
            this.lblSeller.TabIndex = 4;
            this.lblSeller.Text = "&Seller:";
            // 
            // lblPurchDate
            // 
            this.lblPurchDate.AutoSize = true;
            this.lblPurchDate.Location = new System.Drawing.Point(3, 30);
            this.lblPurchDate.Name = "lblPurchDate";
            this.lblPurchDate.Size = new System.Drawing.Size(64, 13);
            this.lblPurchDate.TabIndex = 2;
            this.lblPurchDate.Text = "P&urch Date:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(3, 2);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(67, 13);
            this.lblPrice.TabIndex = 0;
            this.lblPrice.Text = "P&rice Payed:";
            // 
            // prbPrice
            // 
            this.prbPrice.Location = new System.Drawing.Point(76, 0);
            this.prbPrice.MinimumSize = new System.Drawing.Size(200, 21);
            this.prbPrice.Name = "prbPrice";
            this.prbPrice.Price = "";
            this.prbPrice.Size = new System.Drawing.Size(289, 21);
            this.prbPrice.TabIndex = 1;
            this.tlpMain.SetToolTip(this.prbPrice, "Price payed for file");
            this.prbPrice.TextChanged += new System.EventHandler(this.prbPrice_TextChanged);
            // 
            // erpError
            // 
            this.erpError.ContainerControl = this;
            // 
            // Ownership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.prbPrice);
            this.Controls.Add(this.txtSeller);
            this.Controls.Add(this.txtPurchDate);
            this.Controls.Add(this.lblSeller);
            this.Controls.Add(this.lblPurchDate);
            this.Controls.Add(this.lblPrice);
            this.MaximumSize = new System.Drawing.Size(367, 76);
            this.MinimumSize = new System.Drawing.Size(367, 76);
            this.Name = "Ownership";
            this.Size = new System.Drawing.Size(367, 76);
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSeller;
        private System.Windows.Forms.MaskedTextBox txtPurchDate;
        private System.Windows.Forms.Label lblSeller;
        private System.Windows.Forms.Label lblPurchDate;
        private System.Windows.Forms.Label lblPrice;
        private TagInfoControls.SmallControls.PriceBox prbPrice;
        private System.Windows.Forms.ToolTip tlpMain;
        private System.Windows.Forms.ErrorProvider erpError;
    }
}
