using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using Tags.ID3.ID3v2Frames.BinaryFrames;
using Tags.ID3;
using Tags.ID3.ID3v2Frames;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and edit commercial information of a tag
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(Commercial), "Ownership.bmp")]
    public partial class Commercial : ID3UserControl
    {
        /// <summary>
        /// Create new commercial control
        /// </summary>
        public Commercial()
        {
            InitializeComponent();
            Activated = false;
            cmbRecievedAs.SelectedIndex = 0;
        }

        /// <summary>
        /// Indicate if current ID3Info contain Commercial information
        /// </summary>
        [DefaultValue(false), Browsable(false)]
        public bool Activated
        {
            get
            { return lblValidUntil.Enabled; }
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

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(Tags.ID3.ID3Info Data)
        {
            if (Data.ID3v2Info.Commercial == null)
            {
                Activated = false;
                return;
            }

            prbPrice.Currency = Data.ID3v2Info.Commercial.Price.Currency;
            prbPrice.Price = Data.ID3v2Info.Commercial.Price.Value;
            txtValidUntil.Text = Data.ID3v2Info.Commercial.ValidUntil.ToString();
            txtContactURL.Text = Data.ID3v2Info.Commercial.ContactUrl;
            cmbRecievedAs.SelectedIndex = (int)Data.ID3v2Info.Commercial.RecievedAs;
            txtSellerName.Text = Data.ID3v2Info.Commercial.SellerName;
            txtDescription.Text = Data.ID3v2Info.Commercial.Description;
            if (Data.ID3v2Info.Commercial.LogoExists)
                ViewImage(Image.FromStream(Data.ID3v2Info.Commercial.Data), Data.ID3v2Info.Commercial.MIMEType);
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            if (!Activated)
                SData.ID3v2Info.Commercial = null;
            else
            {
                MemoryStream MS = new MemoryStream();
                if (pcbSeller.Image != null)
                    pcbSeller.Image.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);
                else
                    MS = null;

                SData.ID3v2Info.Commercial = new CommercialFrame(new FrameFlags(), txtDescription.Text,
                    IsAsciiCommercial() ? TextEncodings.Ascii : TextEncodings.UTF_16,
                    new Price(prbPrice.Currency, prbPrice.Price), new SDate(txtValidUntil.Text),
                    txtContactURL.Text, (CommercialFrame.RecievedAsEnum)cmbRecievedAs.SelectedIndex,
                    txtSellerName.Text, lblMIME.Text, MS);
            }
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            txtValidUntil.Clear();
            txtContactURL.Clear();
            cmbRecievedAs.SelectedIndex = 0;
            txtSellerName.Clear();
            txtDescription.Clear();
            prbPrice.Price = "";
            btnClear_Click(null, null);
        }

        private void ViewImage(Image Im, string MIME)
        {
            pcbSeller.Image = Im;
            if (Im.Height < pcbSeller.Height &&
                Im.Width < pcbSeller.Width)
                pcbSeller.SizeMode = PictureBoxSizeMode.CenterImage;
            else
                pcbSeller.SizeMode = PictureBoxSizeMode.Zoom;
            lblMIME.Text = MIME;

            btnSave.Enabled = true;
        }

        private void prbPrice_TextChanged(object sender, EventArgs e)
        {
            Activated = !(prbPrice.Price == "");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "png and jpeg files|*.png;*.jpg;*.jpeg";
            OpenFile.Title = "Open Seller Logo";
            OpenFile.Multiselect = false;
            OpenFile.CheckFileExists = true;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo File = new System.IO.FileInfo(OpenFile.FileName);
                string MIME = StaticMethods.GetMIMEType(File.Extension);
                if (MIME == "" || (MIME != "image/png" && MIME != "image/jpeg"))
                {
                    MessageBox.Show("The file extension is not valid\nThe image must be PNG or JPEG file",
                        "Invalid Extension", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ViewImage(Image.FromFile(File.FullName), MIME);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pcbSeller.Image = null;
            lblMIME.Text = "";
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();

            SaveFile.Filter = StaticMethods.GetExtension(lblMIME.Text);
            SaveFile.Title = "Save Image";
            SaveFile.ValidateNames = true;
            SaveFile.AddExtension = true;
            SaveFile.CheckFileExists = false;
            SaveFile.CheckPathExists = true;
            SaveFile.OverwritePrompt = true;

            if (SaveFile.ShowDialog() == DialogResult.OK)
                pcbSeller.Image.Save(SaveFile.FileName);
        }

        private bool IsAsciiCommercial()
        {
            return (Tags.StaticMethods.IsAscii(txtSellerName.Text) &&
                Tags.StaticMethods.IsAscii(txtDescription.Text));
        }

        private void pcbSeller_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Indicate is available data in screen valid or not
        /// </summary>
        /// <returns>true if all fields contain valid information otherwise false</returns>
        public new bool Validate()
        {
            erpError.SetError(txtValidUntil, "");
            if (!Activated)
                return true;

            if (!txtValidUntil.MaskCompleted)
            {
                erpError.SetError(txtValidUntil, "This is not valid date");
                return false;
            }
            return true;
        }
    }
}
