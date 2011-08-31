using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Tags.ID3.ID3v2Frames.TextFrames;
using Tags.ID3;
using Tags.ID3.ID3v2Frames;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and edit Ownership information of tag
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(Ownership), "OwnerShip.bmp")]
    public partial class Ownership : ID3UserControl
    {
        /// <summary>
        /// Create new ownership control
        /// </summary>
        public Ownership()
        {
            InitializeComponent();
            Activated = false;
        }

        /// <summary>
        /// Indicate if current ID3Info contain ownership information
        /// </summary>
        [DefaultValue(false), Browsable(false)]
        public bool Activated
        {
            get
            { return lblPurchDate.Enabled; }
            private set
            {
                if (value == Activated)
                    return;

                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl.Name != prbPrice.Name && Ctrl.Name != lblPrice.Name)
                        Ctrl.Enabled = value;
                }
            }
        }

        private void prbPrice_TextChanged(object sender, EventArgs e)
        {
            Activated = !(prbPrice.Price == "");
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(Tags.ID3.ID3Info Data)
        {
            if (Data.ID3v2Info.OwnerShip == null)
            {
                Activated = false;
                return;
            }

            prbPrice.Price = Data.ID3v2Info.OwnerShip.Price.Value;
            prbPrice.Currency = Data.ID3v2Info.OwnerShip.Price.Currency;
            txtPurchDate.Text = Data.ID3v2Info.OwnerShip.DateOfPurch.ToString();
            txtSeller.Text = Data.ID3v2Info.OwnerShip.Seller;
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            if (!Activated)
                SData.ID3v2Info.OwnerShip = null;
            else
            {
                SData.ID3v2Info.OwnerShip = new OwnershipFrame(new FrameFlags(), new Price(prbPrice.Currency, prbPrice.Price),
                    new SDate(txtPurchDate.Text), txtSeller.Text,
                    Tags.StaticMethods.IsAscii(txtSeller.Text) ? TextEncodings.Ascii : TextEncodings.UTF_16);
            }
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            txtPurchDate.Clear();
            txtSeller.Text = "";
            prbPrice.Price = "";
            prbPrice.Currency = "USD";
        }

        /// <summary>
        /// Indicate if current Owenership control contains valid value and show error
        /// </summary>
        public new bool Validate()
        {
            erpError.SetError(txtPurchDate, "");
            if (!Activated)
                return true;

            if (!txtPurchDate.MaskCompleted)
            {
                erpError.SetError(txtPurchDate, "The entered date is not valid date");
                return false;
            }

            return true;
        }
    }
}
