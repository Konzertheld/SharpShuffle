using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags;
using Tags.ID3.ID3v2Frames;
using TagInfoControls.Properties;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and edit language value according to ISO
    /// </summary>
    [ToolboxBitmap(typeof(ComboBox))]
    public partial class LanguageBox : ComboBox
    {
        /// <summary>
        /// Create new LanguageBox
        /// </summary>
        public LanguageBox()
        {
            UpdateList();
            base.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Gets drop down style of current LanguageBox
        /// </summary>
        [DefaultValue(ComboBoxStyle.DropDownList)]
        public new ComboBoxStyle DropDownStyle
        {
            get
            { return ComboBoxStyle.DropDownList; }
            set
            { }
        }

        /// <summary>
        /// Get or Set selected language
        /// </summary>
        [Description("LanguageID of selected language"), Category("Appearance")]
        public string SelectedLanguage
        {
            set
            {
                if (value == "")
                {
                    this.SelectedItem = "";
                    return;
                }

                foreach (string st in base.Items)
                {
                    if (st.Length == 0)
                        continue;

                    if (GetLangID(st).ToUpper() == value.ToUpper())
                    {
                        this.SelectedItem = st;
                        return;
                    }
                }

                this.SelectedIndex = 0;
            }
            get
            {
                if (this.Text == "")
                    return "";

                return GetLangID(base.Text).ToUpper();
            }
        }

        /// <summary>
        /// Just for hiding inherited member of ComboBox
        /// </summary>
        [Browsable(false)]
        public new string[] Items
        {
            get { return null; }
        }

        private void UpdateList()
        {
            base.Items.Clear();
            if (TagType == TagListTypes.ASF)
            {
                base.Items.AddRange(Resources.RFC1766.Split(';'));
            }
            else
            {
                base.Items.AddRange(Resources.IsoLanguages.Split(';'));
            }
        }

        /// <summary>
        /// Gets ID of language from language string
        /// </summary>
        /// <param name="st">Language string</param>
        /// <returns>Language ID</returns>
        private string GetLangID(string st)
        {
            return st.Substring(st.IndexOf('[') + 1).TrimEnd(']');
        }

        TagListTypes _TagType = TagListTypes.ID3;
        /// <summary>
        /// Indicate type of Language box
        /// </summary>
        [Description("Indicate type of Language list"), Browsable(true),
            Category("Appearance"), DefaultValue(TagListTypes.ID3)]
        public TagListTypes TagType
        {
            get
            { return _TagType; }
            set
            {
                if (value == TagListTypes.Both)
                    throw new ArgumentException("Both is not valid value for this property");
                if (value != _TagType)
                {
                    _TagType = value;
                    UpdateList();
                }
            }
        }
    }
}