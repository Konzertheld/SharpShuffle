using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags.ID3.ID3v2Frames.TextFrames;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and clear popularimeter values of tag
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(Popularimeter), "Star.bmp")]
    public partial class Popularimeter : ID3UserControl
    {
        /// <summary>
        /// Create new popularimeter control
        /// </summary>
        public Popularimeter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(Tags.ID3.ID3Info Data)
        {
            if (Data.ID3v2Info.PlayCounter != null)
                lblCounter.Text = Data.ID3v2Info.PlayCounter.Counter.ToString();
            else
                lblCounter.Text = "0";

            foreach (PopularimeterFrame P in Data.ID3v2Info.PopularimeterFrames)
            {
                dgvRating.Rows.Add(P.EMail, P.Rating, P.Counter);
            }
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            // If user deleted the ratings we do it with ID3Info
            if (dgvRating.Rows.Count == 0)
                SData.ID3v2Info.PopularimeterFrames.Clear();

            if (lblCounter.Text == "0")
                SData.ID3v2Info.PlayCounter = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvRating.Rows.Clear();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            lblCounter.Text = "0";
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            dgvRating.Rows.Clear();
            lblCounter.Text = "0";
        }
    }
}
