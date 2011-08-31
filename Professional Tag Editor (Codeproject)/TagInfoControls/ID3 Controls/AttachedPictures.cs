using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags.ID3.ID3v2Frames.BinaryFrames;
using System.IO;
using Tags.ID3;
using System.Drawing.Imaging;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and edit pictures of ID3
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(PictureBox))]
    public partial class AttachedPictures : ID3UserControl
    {
        /// <summary>
        /// Create new Attached picture control
        /// </summary>
        public AttachedPictures()
        {
            InitializeComponent();
        }

        private void lsbPictures_AddClicked(object sender, EventArgs e)
        {
            if (frmOpenFile.ShowDialog() == DialogResult.OK)
            {
                // Add each selected file
                foreach (string path in frmOpenFile.FileNames)
                    AddPicture(path);

                // if any item added select the last added file
                if (lsbPictures.List.Items.Count > 0)
                    lsbPictures.List.SelectedIndex = lsbPictures.List.Items.Count - 1;
            }
        }

        /// <summary>
        /// Add picture from specific address to list
        /// </summary>
        /// <param name="path">path of file</param>
        private void AddPicture(string path)
        {
            AttachedPictureFrame AddingPicture = new AttachedPictureFrame(new FrameFlags(),
                Path.GetFileName(path).Replace(Path.GetExtension(path), ""), TextEncodings.Ascii,
                StaticMethods.GetMIMEType(Path.GetExtension(path)), AttachedPictureFrame.PictureTypes.Other
                , StaticMethods.GetMemoryStream(path));

            string Des = AddingPicture.Description;
            if (StaticMethods.ValidatingProperty(ref Des, -1, lsbPictures, "Description"))
                AddingPicture.Description = Des;

            lsbPictures.List.Items.Add(AddingPicture);
        }

        private void lsbPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbPictures.List.SelectedIndex == -1)
            {
                grbSelectedImage.Enabled = false;
                ClearView();
            }
            else
            {
                grbSelectedImage.Enabled = true;
                ViewImage((AttachedPictureFrame)lsbPictures.List.SelectedItem);
            }

            btnFullScreen.Enabled = (lsbPictures.List.Items.Count != 0);
            CalculateTotalSize();
        }

        /// <summary>
        /// View and image in the picture box
        /// </summary>
        /// <param name="image">AttachedPictureFrame to view</param>
        private void ViewImage(AttachedPictureFrame image)
        {
            Image pic = image.Picture;
            if (pic.Size.Width < imgImage.Size.Width &&
                pic.Size.Height < imgImage.Size.Height)
                imgImage.SizeMode = PictureBoxSizeMode.CenterImage;
            else
                imgImage.SizeMode = PictureBoxSizeMode.Zoom;
            imgImage.Image = pic;

            txtDescription.Text = image.Description;
            cmbPictureType.SelectedIndex = (int)image.PictureType;
            txtMimeType.Text = image.MIMEType;
            lblSize.Text = StaticMethods.GetLengthString(image.Data.Length);
            lblResolution.Text = pic.Width.ToString() + "*" + pic.Height.ToString() + " px";
        }

        private void ClearView()
        {
            txtDescription.Text = "";
            cmbPictureType.SelectedIndex = -1;
            txtMimeType.Text = "";
            lblSize.Text = "";
            lblResolution.Text = "";
            imgImage.Image = null;
        }

        private void CalculateTotalSize()
        {
            long Size = 0;
            foreach (AttachedPictureFrame F in lsbPictures.List.Items)
                Size += F.Data.Length;

            lblTotalSize.Text = StaticMethods.GetLengthString(Size);
        }

        private AttachedPictureFrame SelectedItem
        {
            get
            { return (AttachedPictureFrame)lsbPictures.List.SelectedItem; }
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            SelectedItem.Description = txtDescription.Text;
            lsbPictures.UpdateView();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            string path = Application.UserAppDataPath;
            path = Path.Combine(path, "TempPictures");
            if (Directory.Exists(path))
                Directory.Delete(path, true);
            Directory.CreateDirectory(path);
            int c = 0;
            foreach (AttachedPictureFrame AP in lsbPictures.List.Items)
            {
                //FileControl.GetExtension(AP.MIMEType))
                AP.Picture.Save(Path.Combine(path, (c++).ToString() + ".jpg"));
            }

            if (lsbPictures.List.SelectedIndex != -1)
                System.Diagnostics.Process.Start(Path.Combine(path,
                    lsbPictures.List.SelectedIndex.ToString() + ".jpg"));
            //FileControl.GetExtension(((AttachedPictureFrame)lsbPictures.List.SelectedItem).MIMEType)));
            else
                System.Diagnostics.Process.Start(Path.Combine(path, "0.jpg"));
            //FileControl.GetExtension(((AttachedPictureFrame)lsbPictures.List.Items[0]).MIMEType)));
        }

        private void lsbPictures_SaveClicked(object sender, EventArgs e)
        {
            frmSaveFile.FileName = txtDescription.Text + ".jpg";
            if (frmSaveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream file = new FileStream(frmSaveFile.FileName, FileMode.Create);
                    SelectedItem.Picture.Save(file, ImageFormat.Jpeg);
                    file.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Can't save image in '" + frmOpenFile.FileName + "'\n" + Ex.Message,
                        "Save Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region -> Validating <-

        bool _ValidType;
        private void cmbPictureType_Validating(object sender, CancelEventArgs e)
        {
            _ValidType = true;
            if (cmbPictureType.SelectedIndex == 1 || cmbPictureType.SelectedIndex == 2)
            {
                for (int i = 0; i < lsbPictures.List.Items.Count; i++)
                {
                    if (i == lsbPictures.List.SelectedIndex)
                        continue;

                    if ((int)((AttachedPictureFrame)lsbPictures.List.Items[i]).PictureType ==
                        cmbPictureType.SelectedIndex)
                    {
                        MessageBox.Show("You already have '" + cmbPictureType.Text +
                            "' picture type for another image", "Picture Type", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        cmbPictureType.SelectedIndex = 0;
                        _ValidType = false;
                    }
                }
            }
        }

        private void cmbPictureType_Validated(object sender, EventArgs e)
        {
            if (_ValidType)
            {
                SelectedItem.PictureType = (AttachedPictureFrame.PictureTypes)cmbPictureType.SelectedIndex;
                lsbPictures.UpdateView();
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = StaticMethods.ValidatingControlAsProperty(txtDescription, lsbPictures.List.SelectedIndex, lsbPictures, "Description");
        }

        #endregion

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(ID3Info Data)
        {
            foreach (AttachedPictureFrame AP in Data.ID3v2Info.AttachedPictureFrames)
                lsbPictures.List.Items.Add(AP);

            if (lsbPictures.List.Items.Count > 0)
                lsbPictures.List.SelectedIndex = 0;
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            SData.ID3v2Info.AttachedPictureFrames.Clear();
            foreach (AttachedPictureFrame AP in lsbPictures.List.Items)
                SData.ID3v2Info.AttachedPictureFrames.Add(AP);
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            lsbPictures.Clear();
        }
    }
}
