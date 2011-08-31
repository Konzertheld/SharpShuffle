using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.Objects;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and edit ExtendedDescription of ASF tag
    /// </summary>
    [ToolboxItem(true)]
    public partial class aExContentDescription : ASFUserControl
    {
        /// <summary>
        /// Create new ExContentDescription control
        /// </summary>
        public aExContentDescription()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(Tags.ASF.ASFTagInfo Data)
        {
            String T;
            foreach (Descriptor var in Data.ExContentDescription)
            {
                if (var.DataType != typeof(byte[]))
                {
                    if (var.DataType == typeof(string))
                        T = "String";
                    else if (var.DataType == typeof(bool))
                        T = "Bool";
                    else
                        T = "Number";
                    dgvList.Rows.Add(var.Name, T, var.Value.ToString());
                }
            }
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            dgvList.Rows.Clear();
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            // remove all descriptor except ByteArrays
            SData.ExContentDescription.RemoveNonArray();

            for (int i = 0; i < dgvList.Rows.Count - 1; i++)
                SData.ExContentDescription.Add(new Descriptor(dgvList.Rows[i].Cells[0].Value.ToString(), ConvertValue((string)dgvList.Rows[i].Cells[2].Value)));
        }

        private object ConvertValue(string st)
        {
            bool b;
            if (bool.TryParse(st, out b))
                return b;

            short num16;
            if (Int16.TryParse(st, out num16))
                return num16;

            int num32;
            if (Int32.TryParse(st, out num32))
                return num32;

            long num64;
            if (Int64.TryParse(st, out num64))
                return num64;

            return st;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvList.Rows.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dgvList.Rows.RemoveAt(dgvList.SelectedCells[0].RowIndex);
        }

        private void dgvList_SelectionChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = dgvList.SelectedCells.Count > 0 &&
                dgvList.SelectedCells[0].RowIndex != -1 &&
                dgvList.SelectedCells[0].RowIndex != dgvList.Rows.Count - 1;
        }

        private void dgvList_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((string)dgvList.Rows[e.RowIndex].Cells[1].Value == "Number")
            {
                long temp;
                if (!long.TryParse((string)dgvList.Rows[e.RowIndex].Cells[2].Value, out temp))
                {
                    MessageBox.Show("Entered value is not valid number the value type will change to string.", "Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvList.Rows[e.RowIndex].Cells[1].Value = "String";
                }
            }
            else if ((string)dgvList.Rows[e.RowIndex].Cells[1].Value == "Bool")
            {
                string Val = (string)dgvList.Rows[e.RowIndex].Cells[2].Value;
                if (Val == "1" || Val.ToLower() == "t")
                    dgvList.Rows[e.RowIndex].Cells[2].Value = "True";
                else
                    dgvList.Rows[e.RowIndex].Cells[2].Value = "False";
            }
        }
    }
}

