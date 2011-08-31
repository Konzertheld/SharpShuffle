using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Tags;

namespace TagEditor
{
    public partial class SelectFolder : Form
    {
        public SelectFolder()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (frmSelectFolder.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = frmSelectFolder.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chbClearList.Checked)
                Program.MainForm.Items.Clear();

            int c = 0;
            string Ext = (rdbMP3.Checked) ? ".mp3" : ".wma";
            foreach (string F in Directory.GetFiles(txtPath.Text))
                if (Path.GetExtension(F).ToLower().Equals(Ext))
                {
                    Program.MainForm.AddFile(F);
                    c++;
                }

            MessageBox.Show(c.ToString() + " file(s) found in folder and added to list.", "File Adding",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (txtPath.Text.Length > 0);
        }

        private void chbClearList_CheckedChanged(object sender, EventArgs e)
        {
            if (!chbClearList.Checked)
            {
                if (Program.MainForm.ListType == TagListTypes.ID3)
                {
                    rdbMP3.Checked = true;
                    rdbWMA.Enabled = false;
                }
                else if (Program.MainForm.ListType == TagListTypes.ASF)
                {
                    rdbWMA.Checked = true;
                    rdbMP3.Enabled = false;
                }
            }
            else
            {
                rdbMP3.Enabled = true;
                rdbWMA.Enabled = true;
            }
        }

        /// <summary>
        /// Get or set path of file
        /// </summary>
        public string DirectoryName
        {
            get { return txtPath.Text; }
            set { txtPath.Text = value; }
        }
    }
}