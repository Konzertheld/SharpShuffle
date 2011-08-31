using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags.ID3.ID3v2Frames.BinaryFrames;
using Tags.ID3;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to read and write Attached file of ID3
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(AttachedFiles), "AttachedFiles.bmp")]
    public partial class AttachedFiles : ID3UserControl
    {
        /// <summary>
        /// Create new Attached files control
        /// </summary>
        public AttachedFiles()
        {
            InitializeComponent();
        }

        private void lsbFrames_SaveClicked(object sender, EventArgs e)
        {
            GeneralFileFrame File = (GeneralFileFrame)lsbFrames.List.SelectedItem;
            frmSaveFile.FileName = File.FileName;
            frmSaveFile.Filter = StaticMethods.GetExtension(File.MIMEType);
            if (frmSaveFile.ShowDialog() == DialogResult.OK)
            {
                FileStream FStream = new FileStream(frmSaveFile.FileName, FileMode.Create);
                File.Data.WriteTo(FStream);
                FStream.Close();
            }
        }

        private void lsbFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbFrames.List.SelectedIndex == -1)
            {
                grbSelectedFile.Enabled = false;
                txtDescription.Clear();
                txtFileName.Clear();
                txtMimeType.Clear();
                lblSize.Text = "";
                imgIcon.Image = null;
                imgWarning.Visible = false;
                CalculateTotalSize();
            }
            else
            {
                grbSelectedFile.Enabled = true;
                txtDescription.Text = SelectedFile.Description;
                txtFileName.Text = SelectedFile.FileName;
                txtMimeType.Text = SelectedFile.MIMEType;
                lblSize.Text = StaticMethods.GetLengthString(SelectedFile.Data.Length);
                imgIcon.Image = GetIconFromExtension(Path.GetExtension(
                    SelectedFile.FileName)).ToBitmap();
                imgWarning.Visible = txtMimeType.Text.StartsWith("image");
            }
        }

        private void lsbFrames_AddClicked(object sender, EventArgs e)
        {
            if (frmOpenFile.ShowDialog() == DialogResult.OK)
            {
                foreach (string Path in frmOpenFile.FileNames)
                {
                    FileInfo File = new FileInfo(Path);
                    string MimeType = StaticMethods.GetMIMEType(File.Extension);
                    lsbFrames.List.Items.Add(new GeneralFileFrame(new FrameFlags(),
                        "", MimeType, TextEncodings.Ascii, File.Name, StaticMethods.GetMemoryStream(Path)));
                }
                if (lsbFrames.List.Items.Count > 0)
                    lsbFrames.List.SelectedIndex = lsbFrames.List.Items.Count - 1;
            }

            CalculateTotalSize();

            txtDescription.Focus();
        }

        private void CalculateTotalSize()
        {
            long Size = 0;
            foreach (GeneralFileFrame F in lsbFrames.List.Items)
                Size += F.Data.Length;

            lblTotalSize.Text = StaticMethods.GetLengthString(Size);
        }

        private void lsbFrames_ListCleared(object sender, EventArgs e)
        {
            CalculateTotalSize();
        }

        private GeneralFileFrame SelectedFile
        {
            get
            {
                return (GeneralFileFrame)lsbFrames.List.SelectedItem;
            }
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            if (SelectedFile != null)
            {
                SelectedFile.Description = txtDescription.Text;
                lsbFrames.UpdateView();
            }
        }

        private void txtFileName_Validated(object sender, EventArgs e)
        {
            if (SelectedFile != null)
            {
                SelectedFile.FileName = txtFileName.Text;
                lsbFrames.UpdateView();
            }
        }

        #region -> Icon Extension <-

        private static Icon GetIconFromExtension(string Extension)
        {
            SHFILEINFO shinfo = new SHFILEINFO();
            IntPtr hImgSmall = SHGetFileInfo(Extension, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), 0x100 | 16);
            return System.Drawing.Icon.FromHandle(shinfo.hIcon);
        }

        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath,
            uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo,
            uint uFlags);

        [StructLayout(LayoutKind.Sequential)]
        struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        #endregion

        private void imgWarning_VisibleChanged(object sender, EventArgs e)
        {
            lblWarning.Visible = imgWarning.Visible;
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(ID3Info Data)
        {
            foreach (GeneralFileFrame F in Data.ID3v2Info.EncapsulatedObjectFrames)
                lsbFrames.List.Items.Add(F);

            CalculateTotalSize();

            if (lsbFrames.List.Items.Count > 0)
                lsbFrames.List.SelectedIndex = 0;
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            SData.ID3v2Info.EncapsulatedObjectFrames.Clear();
            foreach (GeneralFileFrame F in lsbFrames.List.Items)
                SData.ID3v2Info.EncapsulatedObjectFrames.Add(F);
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            lsbFrames.Clear();
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = StaticMethods.ValidatingControlAsProperty(txtDescription, lsbFrames.List.SelectedIndex, lsbFrames, "Description");
        }
    }
}
