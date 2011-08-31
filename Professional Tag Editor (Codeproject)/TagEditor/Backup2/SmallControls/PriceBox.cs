using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TagInfoControls.SmallControls
{
    /// <summary>
    /// Provide a control to edit and add Price values
    /// </summary>
    [DefaultEvent("TextChanged"), ToolboxBitmap("../../Images\\PriceBox.bmp")]
    public partial class PriceBox : UserControl
    {
        /// <summary>
        /// Occur when price value changed
        /// </summary>
        [Description("Occur when price value changed"), Browsable(true)]
        public new event EventHandler TextChanged;

        /// <summary>
        /// Creates new PriceBox with USD as currency
        /// </summary>
        public PriceBox()
        {
            InitializeComponent();

            Currency = "USD";
        }

        /// <summary>
        /// Gets or sets currency of current PriceBox
        /// </summary>
        [Description("3 character Currency value"), DefaultValue("USD")]
        public string Currency
        {
            get
            {
                if (cmbCurrency.SelectedIndex == -1)
                    return "";

                return cmbCurrency.Text.Substring(cmbCurrency.Text.Length - 5, 3);
            }
            set
            {
                cmbCurrency.SelectedIndex = 0;

                foreach (string st in cmbCurrency.Items)
                {
                    if (st.Length == 0)
                        continue;

                    if (st.Substring(st.Length - 5, 3) == value)
                    {
                        cmbCurrency.SelectedItem = st;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Get Price + Currency
        /// </summary>
        public new string Text
        {
            get
            {
                return ftbPrice.Text + Currency;
            }
        }

        /// <summary>
        /// Gets or sets price of current PriceBox
        /// </summary>
        public string Price
        {
            get { return ftbPrice.Text; }
            set { ftbPrice.Text = value; }
        }

        private void ftbPrice_TextChanged(object sender, EventArgs e)
        {
            TextChanged(this, e);
        }

        /// <summary>
        /// Gets or set backcolor of controls when multiple values are diffrent
        /// </summary>
        [Description("The background color of the component"), DefaultValue(typeof(Color), "Window")]
        public new Color BackColor
        {
            get
            {
                return ftbPrice.BackColor;
            }
            set
            {
                ftbPrice.BackColor = value;
                cmbCurrency.BackColor = value;
            }
        }
    }
}