using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ID3.ID3v2Frames.TextFrames;
using Tags.ID3.ID3v2Frames;

namespace TagInfoControls.SmallControls
{
    /// <summary>
    /// Provide a text box with LanguageBox and DescriptionBox
    /// </summary>
    public partial class DescriptableBox : LanguageTextBox
    {
        /// <summary>
        /// Occur when description box of current control validating
        /// </summary>
        [Browsable(true), Description("Occur when Description box of current control validating")]
        public event CancelEventHandler ValidatingDescription;

        /// <summary>
        /// Create new Descriptablebox
        /// </summary>
        public DescriptableBox()
        {
            InitializeComponent();
        }

        private TextWithLanguageFrame _TextWithLanguageValue;
        /// <summary>
        /// Gets or sets TextWithLanguageFrame according to this control
        /// </summary>
        [Browsable(false)]
        public TextWithLanguageFrame TextWithLanguageValue
        {
            get
            {
                if (_TextWithLanguageValue != null)
                {
                    _TextWithLanguageValue.Description = Description;
                    _TextWithLanguageValue.Text = Text;
                    _TextWithLanguageValue.Language = new Language(Language);
                }
                return _TextWithLanguageValue;
            }
            set
            {
                _TextWithLanguageValue = value;
                if (value != null)
                {
                    txtDescription.Text = value.Description;
                    lnbLanguage.SelectedLanguage = value.Language.LanguageID;
                    txtText.Text = value.Text;
                    txtDescription.Focus();
                }
                else
                {
                    txtDescription.Clear();
                    lnbLanguage.SelectedLanguage = "";
                    txtText.Clear();
                }
            }
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            if (TextWithLanguageValue != null)
            {
                TextWithLanguageValue.Description = txtDescription.Text;
                OnDataUpdated(e);
            }
        }

        private void lnbLanguage_Validated(object sender, EventArgs e)
        {
            if (TextWithLanguageValue != null)
            {
                TextWithLanguageValue.Language = new Tags.ID3.ID3v2Frames.Language(lnbLanguage.SelectedLanguage);
                OnDataUpdated(e);
            }
        }

        private void txtText_Validated(object sender, EventArgs e)
        {
            if (TextWithLanguageValue != null)
            {
                TextWithLanguageValue.Text = txtText.Text;
                OnDataUpdated(e);
            }
        }

        /// <summary>
        /// Gets or sets description string of current Control
        /// </summary>
        [Browsable(true), Description("Text of description box"), DefaultValue("")]
        public string Description
        {
            get
            { return txtDescription.Text; }
            set
            { txtDescription.Text = value; }
        }

        /// <summary>
        /// Clear current control
        /// </summary>
        public override void Clear()
        {
            txtDescription.Text = "";
            base.Clear();
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (ValidatingDescription != null)
                ValidatingDescription(this, e);
        }
    }
}

