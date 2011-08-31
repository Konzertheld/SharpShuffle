using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags.ID3.ID3v2Frames.TextFrames;
using Tags.ID3;
using System.IO;

namespace TagInfoControls
{
    /// <summary>
    /// Indicates diffrent mode of TextWithLanguage frames editing
    /// </summary>
    public enum ControlTypes
    {
        /// <summary>
        /// Editing Lyric
        /// </summary>
        UnSynchronizedLyric,
        /// <summary>
        /// Editing Comments
        /// </summary>
        Comment
    }

    /// <summary>
    /// Provide a control to view and edit UnSynchronized lyric and Comment frames
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(CommentAndLyric), "ListImage.bmp")]
    public partial class CommentAndLyric : ID3UserControl
    {
        /// <summary>
        /// Create new Control
        /// </summary>
        public CommentAndLyric()
        {
            InitializeComponent();
            grpValue.Enabled = false;
            ControlType = ControlTypes.Comment;
        }

        private ControlTypes _ControlType;
        /// <summary>
        /// Gets or sets ControlType of current control
        /// </summary>
        [Browsable(true), DefaultValue(ControlTypes.Comment)]
        public ControlTypes ControlType
        {
            get { return _ControlType; }
            set { _ControlType = value; }
        }

        /// <summary>
        /// Indicate what FrameID must use for this type of form
        /// </summary>
        private string FrameID
        {
            get
            { return (ControlType == ControlTypes.Comment) ? "COMM" : "USLT"; }
        }

        private void dcbTextWithLang_DataUpdated(object sender, EventArgs e)
        {
            lsbComments.UpdateView();
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(Tags.ID3.ID3Info Data)
        {
            foreach (TextWithLanguageFrame T in Data.ID3v2Info.TextWithLanguageFrames)
                if (T.FrameID == FrameID)
                    lsbComments.List.Items.Add(T);

            if (lsbComments.List.Items.Count > 0)
                lsbComments.List.SelectedIndex = 0;
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            for (int i = 0; i < SData.ID3v2Info.TextWithLanguageFrames.Count; i++)
                if (SData.ID3v2Info.TextWithLanguageFrames[i].FrameID == FrameID)
                    SData.ID3v2Info.TextWithLanguageFrames.RemoveAt(i);

            foreach (TextWithLanguageFrame T in lsbComments.List.Items)
                SData.ID3v2Info.TextWithLanguageFrames.Add(T);
        }

        private void frlComments_AddClicked_1(object sender, EventArgs e)
        {
            lsbComments.List.Items.Add(new TextWithLanguageFrame(FrameID, new FrameFlags(), "",
                    "", TextEncodings.Ascii, "ENG"));
            lsbComments.List.SelectedIndex = lsbComments.List.Items.Count - 1;
            dcbTextWithLang.Focus();
        }

        private void frlComments_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lsbComments.List.SelectedIndex != -1)
            {
                dcbTextWithLang.TextWithLanguageValue = (TextWithLanguageFrame)lsbComments.List.SelectedItem;
                grpValue.Enabled = true;
            }
            else
            {
                dcbTextWithLang.TextWithLanguageValue = null;
                grpValue.Enabled = false;
            }
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            lsbComments.Clear();
        }

        private void lsbComments_SaveClicked(object sender, EventArgs e)
        {
            SaveFileDialog frmSave = new SaveFileDialog();
            frmSave.Filter = "Text Files (*.txt)|*.txt";
            frmSave.Title = "Save File";
            frmSave.FileName = dcbTextWithLang.Description + ".txt";
            if (frmSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    TextWriter TW = new StreamWriter(frmSave.FileName);
                    TW.Write(dcbTextWithLang.Text);
                    TW.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Can't save file on '" + frmSave.FileName + "'.\n" + Ex.Message,
                        "Save Problem", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
