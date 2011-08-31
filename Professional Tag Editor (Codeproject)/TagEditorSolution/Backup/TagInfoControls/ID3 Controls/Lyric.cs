using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags.ID3.ID3v2Frames.ArrayFrames;
using Tags.ID3;
using System.IO;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and edit Synchronized lyric of tag
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(Lyric), "LyricList.bmp")]
    public partial class Lyric : ID3UserControl
    {
        /// <summary>
        /// Create new lyric control
        /// </summary>
        public Lyric()
        {
            InitializeComponent();
            grpSelected.Enabled = false;
        }

        private void lsbLyrics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbLyrics.List.SelectedIndex != -1)
            {
                grpSelected.Enabled = true;
                ctrlLyricEditor.Lyric = (SynchronisedText)lsbLyrics.List.SelectedItem;
            }
            else
            {
                ctrlLyricEditor.FilePath = SData.FilePath;
                grpSelected.Enabled = false;
                ctrlLyricEditor.Clear();
            }
        }

        private void lsbLyrics_AddClicked(object sender, EventArgs e)
        {
            lsbLyrics.List.Items.Add(new SynchronisedText(new FrameFlags(), TextEncodings.Ascii,
                "ENG", TimeStamps.Milliseconds, SynchronisedText.ContentTypes.Lyric,
                ""));
            lsbLyrics.List.SelectedIndex = lsbLyrics.List.Items.Count - 1;
            ctrlLyricEditor.Focus();
        }

        private void ctrlLyricEditor_DataUpdated(object sender, EventArgs e)
        {
            lsbLyrics.UpdateView();
        }

        private void ctrlLyricEditor_ValidatingDescription(object sender, CancelEventArgs e)
        {
            string Des = ctrlLyricEditor.Description;
            if (DescriptionExists(ref Des, lsbLyrics.List.SelectedIndex))
            {
                MessageBox.Show("List already contains Lyric with '" + ctrlLyricEditor.Description + "' as description. So the description that you entered changed to '" +
                    Des + "'.", "Description repeated", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                ctrlLyricEditor.Description = Des;
            }
        }

        private bool ContainDescription(string Description, int Index)
        {
            for (int i = 0; i < lsbLyrics.List.Items.Count; i++)
            {
                if (i == Index)
                    continue;

                if (((SynchronisedText)lsbLyrics.List.Items[i]).Text == Description)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Take a description if list contains this description change it
        /// </summary>
        /// <param name="description">Description to check and change if need</param>
        /// <param name="Index">Index of selected item</param>
        /// <returns>true if needed to change otherwise false</returns>
        private bool DescriptionExists(ref string description, int Index)
        {
            int Counter = 1;
            bool Changed = false;
            while (ContainDescription(description, Index))
            {
                description = description + (Counter++).ToString();
                Changed = true;
            }
            return Changed;
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(ID3Info Data)
        {
            ctrlLyricEditor.FilePath = Data.FilePath;
            foreach (SynchronisedText ST in Data.ID3v2Info.SynchronisedTextFrames)
                lsbLyrics.List.Items.Add(ST);

            if (lsbLyrics.List.Items.Count > 0)
                lsbLyrics.List.SelectedIndex = 0;
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            ctrlLyricEditor.FilePath = "";
            SData.ID3v2Info.SynchronisedTextFrames.Clear();
            foreach (SynchronisedText ST in lsbLyrics.List.Items)
                SData.ID3v2Info.SynchronisedTextFrames.Add(ST);
        }

        private void lsbLyrics_SaveClicked(object sender, EventArgs e)
        {
            SaveFileDialog frmSave = new SaveFileDialog();
            frmSave.Filter = "Text Files(*.txt)|*.txt";
            frmSave.FileName = ctrlLyricEditor.Description;
            frmSave.Title = "Save Lyric";
            if (frmSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TextWriter T = new StreamWriter(frmSave.FileName);
                    foreach (Syllable S in ctrlLyricEditor.Sylables)
                        T.WriteLine(S.Text);
                    T.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Could not save file" + Environment.NewLine +
                        Ex.Message, "Saving Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            lsbLyrics.Clear();
            ctrlLyricEditor.FilePath = "";
        }
    }
}
