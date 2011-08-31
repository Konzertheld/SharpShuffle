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

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and edit File identifiers
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(FileIdentifiers), "Keys.bmp")]
    public partial class FileIdentifiers : ID3UserControl
    {
        /// <summary>
        /// Create new File Indentifier control
        /// </summary>
        public FileIdentifiers()
        {
            InitializeComponent();
            grpSelectedItem.Enabled = false;
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            lsbIdentifiers.Clear();
            txtFileOwner.Clear();
            txtData.Clear();
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(ID3Info Data)
        {
            foreach (PrivateFrame GF in Data.ID3v2Info.PrivateFrames)
                lsbIdentifiers.List.Items.Add(GF);

            if (lsbIdentifiers.List.Items.Count > 0)
                lsbIdentifiers.List.SelectedIndex = 0;
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            SData.ID3v2Info.PrivateFrames.Clear();
            foreach (PrivateFrame PF in lsbIdentifiers.List.Items)
                SData.ID3v2Info.PrivateFrames.Add(PF);
        }

        private void txtFileOwner_Validated(object sender, EventArgs e)
        {
            lsbIdentifiers.UpdateView();
        }

        private void txtFileOwner_Validating(object sender, CancelEventArgs e)
        {
            if (lsbIdentifiers.List.SelectedIndex == -1)
                return;

            for (int i = 0; i < lsbIdentifiers.List.Items.Count; i++)
            {
                if (i == lsbIdentifiers.List.SelectedIndex)
                    continue;

                if (((PrivateFrame)lsbIdentifiers.List.Items[i]).OwnerIdentifier == txtFileOwner.Text)
                {
                    MessageBox.Show("This owner identifier used by another one, choose another Identifier", "File Identifier",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }

            ((PrivateFrame)lsbIdentifiers.List.SelectedItem).OwnerIdentifier = txtFileOwner.Text;
        }

        private void lsbIdentifiers_AddClicked(object sender, EventArgs e)
        {
            lsbIdentifiers.List.Items.Add(new PrivateFrame("UFID", new FrameFlags(),
               "", null));
            lsbIdentifiers.List.SelectedIndex = lsbIdentifiers.List.Items.Count - 1;
            txtFileOwner.SelectAll();
            txtFileOwner.Focus();
        }

        private void lsbIdentifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbIdentifiers.List.SelectedIndex == -1)
            {
                grpSelectedItem.Enabled = false;
                txtData.Clear();
                txtFileOwner.Clear();
            }
            else
            {
                grpSelectedItem.Enabled = true;
                PrivateFrame PF = (PrivateFrame)lsbIdentifiers.List.SelectedItem;
                if (PF.Data != null)
                {
                    PF.Data.Seek(0, SeekOrigin.Begin);
                    txtData.Data = PF.Data.ToArray();
                }
                else
                    txtData.Clear();

                txtFileOwner.Text = ((PrivateFrame)lsbIdentifiers.List.SelectedItem).OwnerIdentifier;
            }
        }

        private void txtData_Validated_1(object sender, EventArgs e)
        {
            if (lsbIdentifiers.List.SelectedIndex == -1)
                return;

            if (txtData.Data == null)
                ((PrivateFrame)lsbIdentifiers.List.SelectedItem).Data = null;
            else
                ((PrivateFrame)lsbIdentifiers.List.SelectedItem).Data =
                    new MemoryStream(txtData.Data);
        }

    }
}
