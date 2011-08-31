using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TagEditor.Properties;
using System.IO;
using Tags.ID3;
using Tags;
using System.Collections;

namespace TagEditor
{
    public partial class EditFormula : Form
    {
        public EditFormula()
        {
            InitializeComponent();

            if (Program.MainForm.Items.Count > 0)
                lblNoFile.Visible = false;

            UpdateTagsList();
        }

        private void UpdateTagsList()
        {
            ArrayList SavedList;
            string File;
            if (Program.MainForm.ListType == TagListTypes.ASF)
            {
                File = Resources.WMAColumns;
                SavedList = Settings.Default.WMAFormulas;
                cmbFormula.Items.Add("<WM/TrackNumber>- <Title>");
                cmbFormula.Items.Add("<WM/TrackNumber>- <WM/AlbumArtist> - <Title>");
                cmbFormula.Items.Add("(<WM/TrackNumber>) - <Title>");
            }
            else
            {
                File = Resources.MP3Columns;
                SavedList = Settings.Default.MP3Formulas;
                cmbFormula.Items.Add("<TRCK2>- <TIT2>");
                cmbFormula.Items.Add("<TRCK2>- <TPE1> - <TIT2>");
                cmbFormula.Items.Add("(<TRCK>) - <TIT2>");
            }

            string[] List = File.Split(';');
            string[] Temp;
            foreach (string st in List)
            {
                Temp = st.Split(':');
                if (Temp[1] != "")
                    lsbAvailableTexts.Items.Add(Temp[0] + " <" + Temp[1] + ">");
            }

            lsbAvailableTexts.SelectedIndex = 0;

            foreach (string st in SavedList)
                cmbFormula.Items.Add(st);
        }

        /// <summary>
        /// The formula to show or edit
        /// </summary>
        public string Formula
        {
            get
            { return cmbFormula.Text; }
            set
            { cmbFormula.Text = value; }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string ID = (lsbAvailableTexts.SelectedItem as string);
            int Index = ID.IndexOf("<");
            ID = ID.Substring(Index, ID.Length - Index);

            cmbFormula.Text += ID;
        }

        private void cmbFormula_TextChanged(object sender, EventArgs e)
        {
            char[] Invalids = Path.GetInvalidFileNameChars();
            string[] SP = cmbFormula.Text.Replace("<", "<;").Split('<', '>');
            bool Temp = true;
            foreach (string st in SP)
                if (!st.StartsWith(";"))
                    foreach (char ch in Invalids)
                        if (st.IndexOf(ch) != -1)
                            Temp = false;

            if (Temp)
            {
                Error.SetError(cmbFormula, "");
                btnOK.Enabled = true;
                btnPreview.Enabled = true;
            }
            else
            {
                Error.SetError(cmbFormula, "Not valid filename character inserted");
                btnOK.Enabled = false;
                btnPreview.Enabled = false;
            }
        }

        private void PreviewFileNames()
        {
            lsbFilenames.Items.Clear();
            ITagInfo T;
            foreach (ListViewItem I in Program.MainForm.Items)
            {
                T = (ITagInfo)I.Tag;
                lsbFilenames.Items.Add(T.MakeFileName(cmbFormula.Text));
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            PreviewFileNames();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Program.MainForm.ListType != TagListTypes.ASF)
            {
                if (!cmbFormula.Items.Contains(cmbFormula.Text))
                    Settings.Default.MP3Formulas.Add(cmbFormula.Text);

                Settings.Default.MP3FilenameFormula = cmbFormula.Text;
            }
            else
            {
                if (!cmbFormula.Items.Contains(cmbFormula.Text))
                    Settings.Default.WMAFormulas.Add(cmbFormula.Text);

                Settings.Default.WMAFilenameFormula = cmbFormula.Text;
            }
        }
    }
}