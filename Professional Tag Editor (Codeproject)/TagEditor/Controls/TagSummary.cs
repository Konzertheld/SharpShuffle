using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags;
using Tags.ID3;
using Tags.ASF;
using Tags.ID3.ID3v2Frames.TextFrames;
using TagEditor.Properties;
using System.Collections;
using Tags.Objects;

namespace TagEditor
{
    [ToolboxItem(true)]
    public partial class TagSummary : UserControl
    {
        public TagSummary()
        {
            InitializeComponent();
        }

        private ITagInfo _TagInfo;
        /// <summary>
        /// Gets or sets TagInfo that control shows
        /// </summary>
        [Browsable(false), DefaultValue(default(ITagInfo))]
        public ITagInfo TagInfo
        {
            get
            { return _TagInfo; }
            set
            {
                _TagInfo = value;
                if (value.GetType() == typeof(ID3Info))
                    ShowTag(value as ID3Info);
                else
                    ShowTag(value as ASFTagInfo);
            }
        }

        private void ShowTag(ID3Info Tag)
        {
            lblID3v1.Text = (Tag.ID3v1Info.HaveTag) ? "YES" : "-";
            lblTextFields.Text = Tag.ID3v2Info.TextFrames.Count.ToString();
            lblUserTexts.Text = Tag.ID3v2Info.UserTextFrames.Count.ToString();
            lblComments.Text = CountComments(Tag).ToString();
            lblFiles.Text = Tag.ID3v2Info.EncapsulatedObjectFrames.Count.ToString();
            lblPictures.Text = Tag.ID3v2Info.AttachedPictureFrames.Count.ToString();

            pnlASF.Visible = false;
            pnlID3.Visible = true;

            this.Size = pnlID3.Size;
        }

        private void ShowTag(ASFTagInfo Tag)
        {
            lblASimpleText.Text = CountSimpleTexts(Tag).ToString();
            lblATextFields.Text = CountTextField(Tag).ToString();
            lblAPicture.Text = (Tag.ContentBranding == null) ? "-" : "Yes";



            pnlASF.Visible = true;
            pnlID3.Visible = false;

            this.Size = pnlASF.Size;
        }

        private int CountComments(ID3Info Tag)
        {
            int Count = 0;
            foreach (TextWithLanguageFrame TWLF in Tag.ID3v2Info.TextWithLanguageFrames)
                if (TWLF.FrameID == "COMM")
                    Count++;
            return Count;
        }

        private int CountSimpleTexts(ASFTagInfo Tag)
        {
            if (Tag.ContentDescription == null)
                return 0;

            int Count = 0;

            if (Tag.ContentDescription.Author != "")
                Count++;
            if (Tag.ContentDescription.Copyright != "")
                Count++;
            if (Tag.ContentDescription.Description != "")
                Count++;
            if (Tag.ContentDescription.Title != "")
                Count++;

            return Count;
        }

        private int CountTextField(ASFTagInfo Tag)
        {
            int Count = 0;
            string[] Texts = GetASFTextDescriptors();

            foreach (Descriptor D in Tag.ExContentDescription)
                if (Array.IndexOf(Texts, D.Name) != -1)
                    Count++;

            return Count;
        }

        private string[] GetASFTextDescriptors()
        {
            string[] Temp;
            ArrayList List = new ArrayList();
            foreach (string st in Resources.WMAColumns.Split(';'))
            {
                Temp = st.Split(':');
                if (Temp[0] != "")
                    List.Add(Temp[1]);
            }
            return List.ToArray(typeof(string)) as string[];
        }
    }
}
