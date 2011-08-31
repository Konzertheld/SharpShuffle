using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ASF;

namespace TagInfoControls
{
    /// <summary>
    /// Provde a control to view and edit Simple texts of ASF tag
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(TextBox))]
    public partial class aSimpleText : ASFUserControl
    {
        /// <summary>
        /// Create new SimpleASFTag control
        /// </summary>
        public aSimpleText()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(Tags.ASF.ASFTagInfo Data)
        {
            if (Data.ContentDescription == null)
                return;

            txtTitle.Text = Data.ContentDescription.Title;
            txtAuthor.Text = Data.ContentDescription.Author;
            txtCopyright.Text = Data.ContentDescription.Copyright;
            txtDescription.Text = Data.ContentDescription.Description;
            foreach (string st in Data.ContentDescription.Ratings)
                lsbRatings.Items.Add(st);
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            SData.ContentDescription = null;
            if (txtTitle.TextLength > 0 || txtAuthor.TextLength > 0 || txtCopyright.TextLength > 0 ||
                txtDescription.TextLength > 0 || lsbRatings.Items.Count > 0)
            {
                SData.ContentDescription = new Tags.Objects.ContentDescriptionOb(txtTitle.Text.Trim(),
                    txtAuthor.Text.Trim(), txtCopyright.Text.Trim(),
                    txtDescription.Text.Trim());
                SData.ContentDescription.Ratings.Clear();
                foreach (string var in lsbRatings.Items)
                    SData.ContentDescription.Ratings.Add(var);
            }
        }

        /// <summary>
        /// Shows or hides rating part of control
        /// </summary>
        [Category("Appearance"), Description("Shows or hides Rating part of control")]
        public bool ShowRating
        {
            get
            { return grpRating.Visible; }
            set
            {
                if (EditMode == EditModes.Multiple && value == true)
                    throw new ArgumentException("In multiple mode can't show rating part");

                grpRating.Visible = value;
                SetControlSize();
            }
        }

        private void SetControlSize()
        {
            int W = this.Size.Width, H;
            if (grpRating.Visible)
                H = grpRating.Location.Y + grpRating.Height;
            else
                H = txtDescription.Location.Y + txtDescription.Size.Height;
            this.Size = new Size(W, H + 1);
        }

        private void btnAddRating_Click(object sender, EventArgs e)
        {
            lsbRatings.Items.Add(txtRating.Text);
            txtRating.Text = "";
        }

        private void lsbRatings_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = lsbRatings.SelectedIndex != -1;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lsbRatings.Items.RemoveAt(lsbRatings.SelectedIndex);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lsbRatings.Items.Clear();
        }

        private void txtRating_TextChanged(object sender, EventArgs e)
        {
            btnAddRating.Enabled = txtRating.Text != "";
        }

        /// <summary>
        /// Show data of multiple tags
        /// </summary>
        protected override void OnMultipleSet(Tags.ASF.ASFTagInfo[] Data)
        {
            StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ContentDescription", "Title"), txtTitle, Data[0].ContentDescription.Title, ConflictColor);
            StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ContentDescription", "Author"), txtAuthor, Data[0].ContentDescription.Author, ConflictColor);
            StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ContentDescription", "Copyright"), txtCopyright, Data[0].ContentDescription.Copyright, ConflictColor);
            StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ContentDescription", "Description"), txtDescription, Data[0].ContentDescription.Description, ConflictColor);
            this.ShowRating = false;
        }

        /// <summary>
        /// Collect data as multi tag
        /// </summary>
        protected override void OnCollectMultiple(Tags.ASF.ASFTagInfo Data)
        {
            if (txtTitle.Text.Length > 0)
                Data.ContentDescription.Title = txtTitle.Text.Trim();
            if (txtAuthor.Text.Length > 0)
                Data.ContentDescription.Author = txtAuthor.Text.Trim();
            if (txtCopyright.Text.Length > 0)
                Data.ContentDescription.Copyright = txtCopyright.Text.Trim();
            if (txtDescription.Text.Length > 0)
                Data.ContentDescription.Description = txtDescription.Text.Trim();
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl.Name.StartsWith("txt"))
                {
                    ctrl.Text = "";
                    ctrl.BackColor = SystemColors.Window;
                }
            lsbRatings.Items.Clear();
        }
    }
}