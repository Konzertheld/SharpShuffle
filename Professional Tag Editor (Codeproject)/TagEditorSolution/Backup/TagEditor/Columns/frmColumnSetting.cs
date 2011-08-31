using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ID3.ID3v2Frames;
using System.Xml.Serialization;
using System.IO;
using TagEditor.Properties;
using Tags;

namespace TagEditor.Columns
{
    public partial class frmColumnSetting : Form
    {
        public frmColumnSetting()
        {
            InitializeComponent();
            UpdateNamesBox();
            this.Text += " - " + ((Program.MainForm.ListType == TagListTypes.ASF) ? "WMA" : "MP3");
        }

        bool AddColumn(ListColumn Col)
        {
            if (ColumnsCollection.Columns.Contains(Col))
            {
                MessageBox.Show("List already contain " + Col.Name, "Repeatation",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            ColumnsCollection.Columns.Add(Col);
            return true;
        }

        void UpdateView()
        {
            foreach (ListColumn Col in ColumnsCollection.Columns)
                lsbColumns.Items.Add(Col);
        }

        void UpdateColumnCollection()
        {
            ColumnsCollection.Columns.Clear();
            ListColumn Col;
            for (int i = 0; i < lsbColumns.Items.Count; i++)
            {
                Col = (ListColumn)lsbColumns.Items[i];
                ColumnsCollection.Columns.Add(Col);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListColumn Col = (ListColumn)cmbName.SelectedItem;
            if (lsbColumns.Items.Contains(Col))
            {
                MessageBox.Show("List already contains " + Col.Name, "Repeatation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lsbColumns.Items.Add(Col);
            lsbColumns.SelectedItem = Col;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lsbColumns.Items.Count == 0)
            {
                MessageBox.Show("Used list must contains one item at least.", "No Item Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateColumnCollection();
            ColumnsCollection.Save();
            DialogResult = DialogResult.OK;
        }

        private void frmColumnSetting_Load(object sender, EventArgs e)
        {
            UpdateView();

            clbColumns_SelectedIndexChanged(null, null);
        }

        private void UpdateNamesBox()
        {
            cmbName.Items.Clear();
            string File = (Program.MainForm.ListType != TagListTypes.ASF) ? File = Resources.MP3Columns : File = Resources.WMAColumns;

            string[] Temp;
            foreach (string st in File.Split(';'))
            {
                Temp = st.Split(':');
                cmbName.Items.Add(new ListColumn(Temp[0], Temp[1]));
            }

            cmbName.SelectedIndex = 0;
        }

        private void clbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool Up = true, Down = true;
            if (lsbColumns.SelectedIndex == -1)
            {
                Up = false;
                Down = false;
            }
            else if (lsbColumns.SelectedIndex == lsbColumns.Items.Count - 1)
                Down = false;
            else if (lsbColumns.SelectedIndex == 0)
                Up = false;

            btnUp.Enabled = Up;
            btnDown.Enabled = Down;

            btnRemove.Enabled = (lsbColumns.SelectedIndex != -1);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lsbColumns.Items.RemoveAt(lsbColumns.SelectedIndex);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ListColumn Col = (ListColumn)lsbColumns.SelectedItem;
            int index = lsbColumns.SelectedIndex - 1;
            lsbColumns.Items.RemoveAt(index + 1);
            lsbColumns.Items.Insert(index, Col);
            lsbColumns.SelectedIndex = index;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ListColumn Col = (ListColumn)lsbColumns.SelectedItem;
            int index = lsbColumns.SelectedIndex + 1;
            lsbColumns.Items.RemoveAt(index - 1);
            lsbColumns.Items.Insert(index, Col);
            lsbColumns.SelectedIndex = index;
        }

        private void lnkDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to restore original list of columns ?",
                "Columns List", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lsbColumns.Items.Clear();
                lsbColumns.Items.AddRange(ColumnsCollection.Default);
            }
        }
    }
}