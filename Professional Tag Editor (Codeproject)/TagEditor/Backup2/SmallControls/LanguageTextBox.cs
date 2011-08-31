using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags.ID3.ID3v2Frames.TextFrames;
using System.IO;
using System.Xml.Serialization;
using System.Collections;

namespace TagInfoControls.SmallControls
{
    /// <summary>
    /// Control to view and edit TermOfUse frame
    /// </summary>
    [ToolboxBitmap(typeof(TextBox))]
    public partial class LanguageTextBox : UserControl
    {
        /// <summary>
        /// Occur when data updated
        /// </summary>
        [Browsable(true)]
        public event EventHandler DataUpdated;

        /// <summary>
        /// Occur when validating language
        /// </summary>
        [Browsable(true)]
        public event CancelEventHandler ValidatingLanguage;

        /// <summary>
        /// Raise DataUpdatted event
        /// </summary>
        /// <param name="e">EventArgs to raise event</param>
        protected void OnDataUpdated(EventArgs e)
        {
            if (DataUpdated != null)
                DataUpdated(this, e);
        }

        /// <summary>
        /// Create new TermOfUse frame
        /// </summary>
        public LanguageTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clear all form data
        /// </summary>
        public virtual void Clear()
        {
            lnbLanguage.SelectedLanguage = "";
            txtText.Text = "";
        }

        /// <summary>
        /// Indicate if current editing text is right to left language
        /// </summary>
        [Browsable(false)]
        public bool RightToLeftLanguage
        {
            get
            { return rdbRTL.Checked; }
            private set
            {
                rdbRTL.Checked = value;
                rdbLTR.Checked = !value;
            }
        }

        /// <summary>
        /// Language of current DesLang control
        /// </summary>
        [Browsable(true), Description("Selected language of current control"),
            DefaultValue("")]
        public string Language
        {
            get
            { return lnbLanguage.SelectedLanguage; }
            set
            { lnbLanguage.SelectedLanguage = value; }
        }

        /// <summary>
        /// Gets or sets text of current control
        /// </summary>
        [Browsable(true), Description("Text of main text screen in this control"),
            DefaultValue("")]
        public new string Text
        {
            get
            { return txtText.Text; }
            set
            { txtText.Text = value; }
        }

        TermOfUseFrame _TermOfUse;
        /// <summary>
        /// Gets or sets TermOfUse
        /// </summary>
        [Browsable(false), DefaultValue(typeof(TermOfUseFrame), "null")]
        public TermOfUseFrame TermOfUse
        {
            get
            { return _TermOfUse; }
            set
            {
                _TermOfUse = value;
                //txtText.Text = value.Text;
                lnbLanguage.SelectedLanguage = value.Language.LanguageID;
            }
        }

        private const string _FileName = "Lang.xml";
        static private string FileName
        {
            get
            {
#if DEBUG
                return _FileName;
#else
                return Path.Combine(Application.UserAppDataPath, _FileName); 
#endif
            }
        }

        private void lnbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            RightToLeftLanguage = LanguageArray.Contains(lnbLanguage.SelectedLanguage);
        }

        private const string _ArrayName = "LanguageArray";
        static private ArrayList LanguageArray
        {
            get
            {
                /* This application load RTL language from XML file behind DLL
                   for more performance store this data in a variable in Application
                   area and when need it retrive it */
                ArrayList LangArray = (ArrayList)AppDomain.CurrentDomain.GetData(_ArrayName);

                if (LangArray == null)
                {
                    if (File.Exists(FileName))
                    {
                        try
                        {
                            XmlSerializer Ser = new XmlSerializer(typeof(ArrayList));
                            FileStream file = new FileStream(FileName, FileMode.Open);
                            LangArray = (ArrayList)Ser.Deserialize(file);
                            file.Close();
                        }
                        catch { }
                    }
                    else
                    {
                        LangArray = new ArrayList();
                    }

                    AppDomain.CurrentDomain.SetData(_ArrayName, LangArray);
                    AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
                }

                // Save Arraylist data in XML file when domain exit
                //AppDomain.CurrentDomain.ProcessExit -= CurrentDomain_ProcessExit;                

                return LangArray;
            }
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            ArrayList Languages = (ArrayList)AppDomain.CurrentDomain.GetData(_ArrayName);
            if (Languages == null)
                return;

            try
            {
                XmlSerializer Ser = new XmlSerializer(typeof(ArrayList));
                FileStream file = new FileStream(FileName, FileMode.Create);
                Ser.Serialize(file, Languages);
                file.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Could not save RightToLeft language list with following error:\n" + Ex.Message,
                    "Save File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnbLanguage_Validated(object sender, EventArgs e)
        {
            if (TermOfUse != null)
                TermOfUse.Language = new Tags.ID3.ID3v2Frames.Language(lnbLanguage.SelectedLanguage);
        }

        private void txtText_Validated(object sender, EventArgs e)
        {
            if (TermOfUse != null)
            {
                TermOfUse.Text = txtText.Text;
                DataUpdated(this, e);
            }
        }

        private void rdbLTR_CheckedChanged(object sender, EventArgs e)
        {
            LanguageArray.Remove(lnbLanguage.SelectedLanguage);
            if (rdbRTL.Checked)
            {
                LanguageArray.Add(lnbLanguage.SelectedLanguage);
                txtText.RightToLeft = RightToLeft.Yes;
            }
            else
            {
                txtText.RightToLeft = RightToLeft.No;
            }
        }

        private void lnbLanguage_Validating(object sender, CancelEventArgs e)
        {
            if (ValidatingLanguage != null)
                ValidatingLanguage(this, e);
        }
    }
}