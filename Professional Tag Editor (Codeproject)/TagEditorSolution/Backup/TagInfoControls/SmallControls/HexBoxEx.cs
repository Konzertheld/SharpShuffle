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
    /// Provide a control to view and edit binary data in base of 16
    /// </summary>
    [ToolboxBitmap(typeof(HexBox))]
    public partial class HexBoxEx : UserControl
    {
        /// <summary>
        /// Create new HexBox
        /// </summary>
        public HexBoxEx()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }

        private void btnMusicOpen_Click(object sender, EventArgs e)
        {
            if (sfdOpen.ShowDialog() == DialogResult.OK)
                txtData.Load(sfdOpen.FileName);
        }

        private void btnMusicSave_Click(object sender, EventArgs e)
        {
            if (sfdSave.ShowDialog() == DialogResult.OK)
                txtData.Save(sfdSave.FileName);
        }

        /// <summary>
        /// Clear all data
        /// </summary>
        public void Clear()
        {
            txtData.Clear();
        }

        private void hbxData_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = (txtData.Text != "");
        }

        /// <summary>
        /// Gets or sets data of current HexBoxEx
        /// </summary>
        public byte[] Data
        {
            get
            { return txtData.Data; }
            set
            { txtData.Data = value; }
        }

        private void txtData_Validating(object sender, CancelEventArgs e)
        {
            OnValidating(e);
        }

        private void txtData_Validated(object sender, EventArgs e)
        {
            OnValidated(e);
        }
    }
}
