using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Tags.Objects;
using System.IO;
using System.Drawing.Imaging;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and edit ContentBranding object of ASF tag
    /// </summary>
    [ToolboxItem(true)]
    public partial class aContentBranding : ASFUserControl
    {
        /// <summary>
        /// Create new ContentBranding control
        /// </summary>
        public aContentBranding()
        {
            InitializeComponent();
        }

        // Regular Expression for URL validating
        Regex URLreg = new Regex(@"^((h|H)(t|T){2}(p|P)(S|s)?://)?((([\w-]*\.)?[\w-]+\.[\w]{2,4})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[\w-\.]*)?$");
        private void URL_Validating(object sender, CancelEventArgs e)
        {
            TextBox T = sender as TextBox;
            if (T.Text != "" && !URLreg.IsMatch(T.Text))
                erpURL.SetError(T, "Entered string is not valid URL");
            else
                erpURL.SetError(T, "");
        }

        private void lnkViewImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            }
            catch { }
        }

        private void URL_TextChanged(object sender, EventArgs e)
        {
            TextBox T = sender as TextBox;
            LinkLabel L;
            if (T.Name == "txtImageURL")
                L = lnkViewImage;
            else
                L = lnkViewCopyright;
            L.Links[0].LinkData = T.Text;
            L.Enabled = (T.Text != "");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            imgImage.Image = null;
            btnSave.Enabled = false;
            lblImageType.Text = "none";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();

            SaveFile.Filter = GetFilterFromType();
            SaveFile.Title = "Save Image";
            SaveFile.ValidateNames = true;
            SaveFile.AddExtension = true;
            SaveFile.CheckFileExists = false;
            SaveFile.CheckPathExists = true;
            SaveFile.OverwritePrompt = true;

            if (SaveFile.ShowDialog() == DialogResult.OK)
                imgImage.Image.Save(SaveFile.FileName);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Filter = "Image files(*.jpg,*.gif,*.bmp)|*.gif;*.jpg;*.bmp";
            OpenFile.Title = "Open Image";
            OpenFile.Multiselect = false;
            OpenFile.CheckFileExists = true;
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                string Ex = System.IO.Path.GetExtension(OpenFile.FileName);
                if (!(Ex == ".jpg" || Ex == ".jpeg" || Ex == ".gif" || Ex == ".bmp"))
                    erpURL.SetError(lblImageType, "Selected file type is not recommended");
                else
                    erpURL.SetError(lblImageType, "");

                ViewImage(Image.FromFile(OpenFile.FileName), Ex.TrimStart('.'));
            }
        }

        /// <summary>
        /// View image in picture box and set zoom automatically
        /// </summary>
        private void ViewImage(Image Im, string Type)
        {
            imgImage.Image = Im;
            if (Im.Height < imgImage.Height &&
                Im.Width < imgImage.Width)
                imgImage.SizeMode = PictureBoxSizeMode.CenterImage;
            else
                imgImage.SizeMode = PictureBoxSizeMode.Zoom;

            lblImageType.Text = (Type == "jpeg") ? "jpg" : Type;
            btnSave.Enabled = true;
        }

        /// <summary>
        /// Get filter for current type of images
        /// </summary>
        /// <returns>string contain Filter for common dialogs</returns>
        private string GetFilterFromType()
        {
            switch (lblImageType.Text.ToLower())
            {
                default:
                    return "Bitmap Image(*.bmp)|*.bmp|Jpeg Image(*.jpg)|*.jpg|Gif Image(*.gif)|*.gif";
                case "bmp":
                    return "Bitmap Image(*.bmp)|*.bmp";
                case "jpg":
                case "jpeg":
                    return "Jpeg Image(*.jpg)|*.jpg";
                case "gif":
                    return "Gif Image(*.gif)|*.gif";
            }
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            if (txtCopyrightURL.Text == "" && txtImageURL.Text == "" &&
                imgImage.Image == null)
                SData.ContentBranding = null;
            else
            {
                MemoryStream MS = null;
                if (imgImage.Image != null)
                {
                    MS = new MemoryStream();
                    imgImage.Image.Save(MS, ImageFormat.Jpeg);
                }
                SData.ContentBranding = new ContentBrandingOb(txtCopyrightURL.Text,
                    txtImageURL.Text, MS, ImageTypes.none);
            }
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(Tags.ASF.ASFTagInfo Data)
        {
            if (Data.ContentBranding == null)
                return;

            txtCopyrightURL.Text = Data.ContentBranding.CopyrightURL;
            txtImageURL.Text = Data.ContentBranding.ImageURL;
            if (Data.ContentBranding.Image != null)
                ViewImage(Data.ContentBranding.GetImage(), "jpg");
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            txtImageURL.Text = string.Empty;
            txtCopyrightURL.Text = string.Empty;
            Image I = imgImage.Image;
            imgImage.Image = null;
            I.Dispose();
        }
    }
}