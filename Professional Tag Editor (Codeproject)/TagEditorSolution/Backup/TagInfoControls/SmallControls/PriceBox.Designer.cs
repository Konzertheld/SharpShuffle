namespace TagInfoControls.SmallControls
{
    partial class PriceBox
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
            this.ftbPrice = new System.Windows.Forms.FilterTextBox();
            this.cmbCurrency = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ftbPrice
            // 
            this.ftbPrice.AcceptableCharacters = ".";
            this.ftbPrice.AcceptsLetter = false;
            this.ftbPrice.AcceptsPunctuation = false;
            this.ftbPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ftbPrice.Location = new System.Drawing.Point(0, 0);
            this.ftbPrice.Name = "ftbPrice";
            this.ftbPrice.Size = new System.Drawing.Size(126, 20);
            this.ftbPrice.TabIndex = 0;
            this.ftbPrice.ToolTipMessage = "";
            this.ftbPrice.ToolTipTitle = "Character Vertification";
            this.ftbPrice.TextChanged += new System.EventHandler(this.ftbPrice_TextChanged);
            // 
            // cmbCurrency
            // 
            this.cmbCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrency.FormattingEnabled = true;
            this.cmbCurrency.ItemHeight = 13;
            this.cmbCurrency.Items.AddRange(new object[] {
            "Afghani [ AFN ]",
            "Algerian Dinar [ DZD ]",
            "Argentine Peso [ ARS ]",
            "Armenian Dram [ AMD ]",
            "Aruban Guilder [ AWG ]",
            "Australian Dollar [ AUD ]",
            "Azerbaijanian Manat [ AZN ]",
            "Bahamian Dollar [ BSD ]",
            "Bahraini Dinar [ BHD ]",
            "Baht [ THB ]",
            "Balboa [ PAB ]",
            "Bangladeshi Taka [ BDT ]",
            "Barbados Dollar [ BBD ]",
            "Belarussian Ruble [ BYR ]",
            "Belize Dollar [ BZD ]",
            "Bermudian Dollar [ BMD ]",
            "Bolivian Mvdol [ BOV ]",
            "Boliviano [ BOB ]",
            "Botswana Pula [ BWP ]",
            "Brazilian Real [ BRL ]",
            "Brunei Dollar [ BND ]",
            "Bulgarian Lev [ BGN ]",
            "Burundian Franc [ BIF ]",
            "Canadian Dollar [ CAD ]",
            "Cape Verde Escudo [ CVE ]",
            "Cayman Islands Dollar [ KYD ]",
            "Cedi [ GHC ]",
            "Chilean Peso [ CLP ]",
            "Colombian Peso [ COP ]",
            "Comoro Franc [ KMF ]",
            "Convertible Marks [ BAM ]",
            "Cordoba Oro [ NIO ]",
            "Costa Rican Colon [ CRC ]",
            "Croatian Kuna [ HRK ]",
            "Cuban Peso [ CUP ]",
            "Cyprus Pound [ CYP ]",
            "Czech Koruna [ CZK ]",
            "Dalasi [ GMD ]",
            "Danish Krone [ DKK ]",
            "Denar [ MKD ]",
            "Djibouti Franc [ DJF ]",
            "Dobra [ STD ]",
            "Dominican Peso [ DOP ]",
            "Dong [ VND ]",
            "East Caribbean Dollar [ XCD ]",
            "Egyptian Pound [ EGP ]",
            "Ethiopian Birr [ ETB ]",
            "Euro [ EUR ]",
            "Falkland Islands Pound [ FKP ]",
            "Fiji Dollar [ FJD ]",
            "Forint [ HUF ]",
            "Franc Congolais [ CDF ]",
            "Gibraltar pound [ GIP ]",
            "Guarani [ PYG ]",
            "Guinea Franc [ GNF ]",
            "Guyana Dollar [ GYD ]",
            "Haiti Gourde [ HTG ]",
            "Hong Kong Dollar [ HKD ]",
            "Hryvnia [ UAH ]",
            "Iceland Krona [ ISK ]",
            "Indian Rupee [ INR ]",
            "Iranian Rial [ IRR ]",
            "Iraqi Dinar [ IQD ]",
            "Jamaican Dollar [ JMD ]",
            "Japanese yen [ JPY ]",
            "Jordanian Dinar [ JOD ]",
            "Kenyan Shilling [ KES ]",
            "Kina [ PGK ]",
            "Kip [ LAK ]",
            "Kroon [ EEK ]",
            "Kuwaiti Dinar [ KWD ]",
            "Kwacha [ MWK ]",
            "Kwacha [ ZMK ]",
            "Kwanza [ AOA ]",
            "Kyat [ MMK ]",
            "Lari [ GEL ]",
            "Latvian Lats [ LVL ]",
            "Lebanese Pound [ LBP ]",
            "Lek [ ALL ]",
            "Lempira [ HNL ]",
            "Leone [ SLL ]",
            "Liberian Dollar [ LRD ]",
            "Libyan Dinar [ LYD ]",
            "Lilangeni [ SZL ]",
            "Lithuanian Litas [ LTL ]",
            "Loti [ LSL ]",
            "Malagasy Ariary [ MGA ]",
            "Malaysian Ringgit [ MYR ]",
            "Maltese Lira [ MTL ]",
            "Manat [ TMM ]",
            "Mauritius Rupee [ MUR ]",
            "Metical [ MZN ]",
            "Mexican Peso [ MXN ]",
            "Mexican Unidad [ MXV ]",
            "Moldovan Leu [ MDL ]",
            "Moroccan Dirham [ MAD ]",
            "Naira [ NGN ]",
            "Nakfa [ ERN ]",
            "Namibian Dollar [ NAD ]",
            "Nepalese Rupee [ NPR ]",
            "Netherlands Antillian Guilder [ ANG ]",
            "New Israeli Shekel [ ILS ]",
            "New Taiwan Dollar [ TWD ]",
            "New Turkish Lira [ TRY ]",
            "New Zealand Dollar [ NZD ]",
            "Ngultrum [ BTN ]",
            "North Korean Won [ KPW ]",
            "Norwegian Krone [ NOK ]",
            "Nuevo Sol [ PEN ]",
            "Ouguiya [ MRO ]",
            "Pa\'anga [ TOP ]",
            "Pakistan Rupee [ PKR ]",
            "Pataca [ MOP ]",
            "Peso Uruguayo [ UYU ]",
            "Philippine Peso [ PHP ]",
            "Pound Sterling [ GBP ]",
            "Qatari Rial [ QAR ]",
            "Quetzal [ GTQ ]",
            "Rial Omani [ OMR ]",
            "Riel [ KHR ]",
            "Romanian Leu [ ROL ]",
            "Romanian New Leu [ RON ]",
            "Rufiyaa [ MVR ]",
            "Rupiah [ IDR ]",
            "Russian Ruble [ RUB ]",
            "Rwanda Franc [ RWF ]",
            "Saint Helena Pound [ SHP ]",
            "Samoan Tala [ WST ]",
            "Saudi Riyal [ SAR ]",
            "Serbian Dinar [ RSD ]",
            "Seychelles Rupee [ SCR ]",
            "Singapore Dollar [ SGD ]",
            "Slovak Koruna [ SKK ]",
            "Solomon Islands Dollar [ SBD ]",
            "Som [ KGS ]",
            "Somali Shilling [ SOS ]",
            "Somoni [ TJS ]",
            "South African Rand [ ZAR ]",
            "South Korean Won [ KRW ]",
            "Sri Lanka Rupee [ LKR ]",
            "Sudanese Dinar [ SDD ]",
            "Surinam Dollar [ SRD ]",
            "Swedish Krona [ SEK ]",
            "Swiss Franc [ CHF ]",
            "Syrian Pound [ SYP ]",
            "Tanzanian Shilling [ TZS ]",
            "Tenge [ KZT ]",
            "Trinidad and Tobago Dollar [ TTD ]",
            "Tugrik [ MNT ]",
            "Tunisian Dinar [ TND ]",
            "Uganda Shilling [ UGX ]",
            "Unidad de Valor Real [ COU ]",
            "Unidades de formento [ CLF ]",
            "United Arab Emirates dirham [ AED ]",
            "US Dollar [ USD ]",
            "Uzbekistan Som [ UZS ]",
            "Vatu [ VUV ]",
            "Venezuelan bolívar [ VEB ]",
            "Yemeni Rial [ YER ]",
            "Yuan Renminbi [ CNY ]",
            "Zimbabwe Dollar [ ZWD ]",
            "Zloty [ PLN ]"});
            this.cmbCurrency.Location = new System.Drawing.Point(130, 0);
            this.cmbCurrency.MaxDropDownItems = 15;
            this.cmbCurrency.Name = "cmbCurrency";
            this.cmbCurrency.Size = new System.Drawing.Size(159, 21);
            this.cmbCurrency.TabIndex = 2;
            // 
            // PriceBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbCurrency);
            this.Controls.Add(this.ftbPrice);
            this.MinimumSize = new System.Drawing.Size(200, 21);
            this.Name = "PriceBox";
            this.Size = new System.Drawing.Size(289, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FilterTextBox ftbPrice;
        private System.Windows.Forms.ComboBox cmbCurrency;
    }
}
