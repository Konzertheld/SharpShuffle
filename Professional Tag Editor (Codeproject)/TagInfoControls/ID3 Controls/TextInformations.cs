using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ID3;
using System.Collections;
using Tags.ID3.ID3v2Frames.TextFrames;

namespace TagInfoControls
{
    /// <summary>
    /// Control for All text informatio of ID3s
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(TextBox))]
    public partial class TextInformation : ID3UserControl
    {
        /// <summary>
        /// Create new TextInformation control
        /// </summary>
        public TextInformation()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Validate values of DataGridView for specific type of Frame
        /// </summary>
        /// <param name="StartChar">Start character of FrameID</param>
        /// <param name="FrameID">FrameID that must validate</param>
        /// <param name="Description">Description of value</param>
        /// <param name="DGV">DataGridView to use for checking values</param>
        /// <param name="SelectedIndex">Index of validating value</param>
        /// <returns>true if UserFrame is valid otherwise false</returns>
        private bool ValidatingUserFrame(char StartChar, string FrameID, string Description, DataGridView DGV,
            int SelectedIndex)
        {
            if (!Tags.ID3.ID3v2Frames.FramesInfo.IsValidFrameID(FrameID))
            {
                MessageBox.Show("FrameID must be 4 character length. and all characters must be Letter",
                    "FrameID validating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (FrameID[0] != StartChar)
            {
                string st;
                if (StartChar == 'W')
                    st = "User Web Frames ";
                else
                    st = "User Text Frames ";
                MessageBox.Show(st + "FrameID must start with " + StartChar.ToString(),
                    "FrameID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            foreach (DataGridViewRow R in DGV.Rows)
            {
                if (R.Index == DGV.Rows.Count - 1 || R.Index == SelectedIndex)
                    continue;

                if (R.Cells[0].Value.ToString() == FrameID)
                    if (R.Cells[1].Value.ToString() == Description)
                    {
                        MessageBox.Show("FrameID with the same description can't repeat", "Repeated FrameID",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
            }

            if (Tags.ID3.ID3v2Frames.FramesInfo.IsTextFrame(FrameID, 3) != 2)
            {
                MessageBox.Show("This FrameID is not USERframeID try to use another FrameID", "Validating FrameID",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private string GetText(object ob)
        {
            if (ob != null)
                return ob.ToString();
            else
                return string.Empty;
        }

        Dictionary<string, Control> _TextControls;
        /// <summary>
        /// Contains all TextBoxs of current form
        /// </summary>
        public Dictionary<string, Control> TextControls
        {
            get
            {
                if (_TextControls == null)
                {
                    _TextControls = new Dictionary<string, Control>();
                    InitTextControls();
                }
                return _TextControls;
            }
        }

        /// <summary>
        /// Initialize TextControl property
        /// </summary>
        private void InitTextControls()
        {
            for (int i = 0; i < tbcFrames.TabCount - 2; i++)
            {
                foreach (Control cn in tbcFrames.TabPages[i].Controls)
                {
                    if (!cn.Name.StartsWith("txt") && !cn.Name.StartsWith("cmb"))
                        continue;

                    if (cn.Tag != null)
                        _TextControls.Add(cn.Tag.ToString(), cn);
                }
            }
        }

        /// <summary>
        /// Set Specific FrameID value in UI
        /// </summary>
        /// <param name="FrameID">FrameID to Set</param>
        /// <param name="Value">Value of frame</param>
        private void SetText(string FrameID, string Value)
        {
            switch (FrameID)
            {
                case "TLAN":
                    cmbLanguage.SelectedLanguage = Value; return;
                case "TCON":
                    cmbGenre.Genre = Value; return;
                case "TKEY":
                    cmbInitialKey.InitialKey = Value; return;
                case "TMED":
                    cmbMediaType.MediaType = Value; return;
                case "TFLT":
                    FileType = Value; return;
            }

            if (TextControls.ContainsKey(FrameID))
                TextControls[FrameID].Text = Value;
        }

        /// <summary>
        /// Add specific UserText frame to related DataGridView
        /// </summary>
        /// <param name="FrameID">FrameID of user text frame</param>
        /// <param name="Description">Description of frame</param>
        /// <param name="Value">Value of frame</param>
        private void AddUserTextFrame(string FrameID, string Description, string Value)
        {
            // We don't need to control frameID to be valid UserTextFrame
            // because ID3v2 class just read valid UserTextFrames
            if (FrameID[0] == 'T')
                dgvUserTexts.Rows.Add(FrameID, Description, Value);
            else if (FrameID[0] == 'W')
                dgvUserWeb.Rows.Add(FrameID, Description, Value);
        }

        private string FileType
        {
            get
            {
                if (cmbFileType.SelectedIndex < 1)
                    return cmbFileType.Text;
                int i = cmbFileType.Text.IndexOf('[');
                return cmbFileType.Text.Substring(i + 1, cmbFileType.Text.Length - i - 2);
            }
            set
            {
                string Temp;
                int i;
                foreach (string st in cmbFileType.Items)
                {
                    if (st.Length == 0)
                        continue;

                    i = st.IndexOf('[');
                    Temp = st.Substring(i + 1, st.Length - i - 2);
                    if (value == Temp)
                    {
                        cmbFileType.Text = st;
                        return;
                    }
                }
                cmbFileType.Text = value;
            }
        }

        /// <summary>
        /// Add all frames of specific DataGridView to SData
        /// </summary>
        /// <param name="DGV">DataGridView for use content</param>
        private void AddUserData(DataGridView DGV)
        {
            string Description;
            string Text;
            TextEncodings Encode = new TextEncodings();

            foreach (DataGridViewRow R in DGV.Rows)
            {
                if (R.Index == DGV.Rows.Count - 1)
                    continue;

                Text = GetText(R.Cells[2].Value);
                Description = GetText(R.Cells[1].Value);

                if (!Tags.StaticMethods.IsAscii(Text) || !Tags.StaticMethods.IsAscii(Description))
                    Encode = TextEncodings.UTF_16;
                else
                    Encode = TextEncodings.Ascii;

                SData.ID3v2Info.UserTextFrames.Add(new UserTextFrame(R.Cells[0].Value.ToString(),
                    new FrameFlags(), Text, Description, Encode, SData.ID3v2Info.Version.Minor));
            }
        }

        /// <summary>
        /// Update UI for specific version of ID3
        /// </summary>
        /// <param name="Ver">ID3version to update form for</param>
        private void UpdateInterface(int Ver)
        {
            foreach (string FI in TextControls.Keys)
                TextControls[FI].Enabled = Tags.ID3.ID3v2Frames.FramesInfo.IsCompatible(FI, Ver);
        }

        private void DateTime_Validating(object sender, CancelEventArgs e)
        {
            string T = GetDateTime((MaskedTextBox)sender);
            if (T != string.Empty)
            {
                if (T.Length <= 10 && T.IndexOf(' ') != -1)
                    e.Cancel = true;

                if (T.Length > 10 && T.Split(' ').Length > 2)
                    e.Cancel = true;
            }
            if (e.Cancel == true)
                MessageBox.Show("For DateTime field you must start writing from left and write how many fields you like\nEg. 2005/01 is valid but ____/01 is not valid",
                            "Validating DateTime", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dgvUserWeb_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvUserWeb.Rows.Count - 1)
                return;

            dgvUserWeb.Rows[e.RowIndex].Cells[0].Value =
                GetText(dgvUserWeb.Rows[e.RowIndex].Cells[0].Value).ToUpper();

            if (!ValidatingUserFrame('W', GetText(dgvUserWeb.Rows[e.RowIndex].Cells[0].Value),
                    GetText(dgvUserWeb.Rows[e.RowIndex].Cells[1].Value), dgvUserWeb, e.RowIndex))
                e.Cancel = true;
        }

        private void dgvUserTexts_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dgvUserTexts.Rows.Count - 1)
                return;

            dgvUserTexts.Rows[e.RowIndex].Cells[0].Value =
                GetText(dgvUserTexts.Rows[e.RowIndex].Cells[0].Value).ToUpper();

            if (!ValidatingUserFrame('T', dgvUserTexts.Rows[e.RowIndex].Cells[0].Value.ToString(),
                    GetText(dgvUserTexts.Rows[e.RowIndex].Cells[1].Value), dgvUserTexts, e.RowIndex))
                e.Cancel = true;
        }

        /// <summary>
        /// Convert specific MaskedTextBox to string
        /// </summary>
        /// <param name="MTB">MaskedTextBox to use value</param>
        /// <returns>String contain DateTime</returns>
        private string GetDateTime(MaskedTextBox MTB)
        {
            if (MTB.Text.Trim(' ', '/', ':') == string.Empty)
                return string.Empty;

            string Temp = MTB.Text;
            for (int i = Temp.Length - 1; i >= 0; i--)
            {
                if (Temp[i] == ' ' || Temp[i] == '/' ||
                    Temp[i] == ':')
                    Temp = Temp.Remove(i);
                else
                    return Temp;
            }
            return Temp;
        }

        /// <summary>
        /// Show data of multiple tags
        /// </summary>
        protected override void OnMultipleSet(ID3Info[] Data)
        {
            if (DesignMode)
                return;

            UpdateInterface(Data[0].ID3v2Info.Version.Minor);

            foreach (ID3Info Info in Data)
                foreach (TextFrame TF in Info.ID3v2Info.TextFrames)
                {
                    if (sEquality.TextFrame(Data, TF.FrameID))
                        SetText(TF.FrameID, TF.Text);
                    else
                        TextControls[TF.FrameID].BackColor = ConflictColor;
                }

            if (tbcFrames.TabPages.Contains(tbpUserText))
            {
                tbcFrames.TabPages.Remove(tbpUserText);
                tbcFrames.TabPages.Remove(tbpUserWeb);
            }
        }

        /// <summary>
        /// Collect data as multi tag
        /// </summary>
        protected override void OnCollectMultiple(ID3Info Data)
        {
            if (cmbLanguage.Enabled && cmbLanguage.SelectedLanguage.Length > 0)
                Data.ID3v2Info.SetTextFrame("TLAN", cmbLanguage.SelectedLanguage);
            if (cmbGenre.Enabled && cmbGenre.Genre.Length > 0)
                Data.ID3v2Info.SetTextFrame("TCON", cmbGenre.Genre.Trim());
            if (cmbInitialKey.Enabled && cmbInitialKey.InitialKey.Length > 0)
                Data.ID3v2Info.SetTextFrame("TKEY", cmbInitialKey.InitialKey.Trim());
            if (cmbMediaType.Enabled && cmbMediaType.MediaType.Length > 0)
                Data.ID3v2Info.SetTextFrame("TMED", cmbMediaType.MediaType.Trim());
            if (cmbFileType.Enabled && FileType.Length > 0)
                Data.ID3v2Info.SetTextFrame("TFLT", FileType.Trim());

            foreach (Control var in TextControls.Values)
                if (var.Enabled && var.Text.Length > 0)
                {
                    if (IsDateTimeBox(var))
                        Data.ID3v2Info.SetTextFrame(var.Tag.ToString(), GetDateTime((MaskedTextBox)var));
                    else
                        Data.ID3v2Info.SetTextFrame(var.Tag.ToString(), var.Text.Trim());
                }
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            foreach (Control var in TextControls.Values)
            {
                var.Text = "";
                var.BackColor = SystemColors.Window;
            }

            dgvUserTexts.Rows.Clear();
            dgvUserWeb.Rows.Clear();
            FileType = "";
            cmbLanguage.SelectedLanguage = "";
            cmbGenre.Genre = "";
            cmbInitialKey.InitialKey = "";
            cmbMediaType.MediaType = "";
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(ID3Info Data)
        {
            if (DesignMode)
                return;

            if (Data.ID3v2Info.Version != null)
                UpdateInterface(Data.ID3v2Info.Version.Minor);
            else
                UpdateInterface(3);

            if (!Data.ID3v2Info.HaveTag)
                return;

            foreach (TextFrame TF in Data.ID3v2Info.TextFrames)
                SetText(TF.FrameID, TF.Text);

            foreach (UserTextFrame UTF in Data.ID3v2Info.UserTextFrames)
                AddUserTextFrame(UTF.FrameID, UTF.Description, UTF.Text);

            if (!tbcFrames.TabPages.Contains(tbpUserText))
            {
                tbcFrames.TabPages.Add(tbpUserText);
                tbcFrames.TabPages.Add(tbpUserWeb);
            }
        }

        string[] _DateTimeTags = { "TDOR", "TDRL", "TDRC", "TDTG", "TDEN" };
        /// <summary>
        /// Indicate whether specific control is MaskedTextBox for DateTime or not
        /// </summary>
        /// <param name="Ctrl">Control To check</param>
        /// <returns>true if is DateTimeBox otherwise false</returns>
        private bool IsDateTimeBox(Control Ctrl)
        {
            foreach (string var in _DateTimeTags)
                if (var == Ctrl.Tag.ToString())
                    return true;
            return false;
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            if (DesignMode)
                return;

            SData.ID3v2Info.TextFrames.Clear();

            foreach (Control var in TextControls.Values)
                if (var.Enabled && var.Text.Trim() != "")
                {
                    if (IsDateTimeBox(var))
                        SData.ID3v2Info.SetTextFrame(var.Tag.ToString(), GetDateTime((MaskedTextBox)var));
                    else
                        SData.ID3v2Info.SetTextFrame(var.Tag.ToString(), var.Text.Trim());
                }

            SData.ID3v2Info.SetTextFrame("TLAN", cmbLanguage.SelectedLanguage);
            SData.ID3v2Info.SetTextFrame("TCON", cmbGenre.Genre.Trim());
            SData.ID3v2Info.SetTextFrame("TKEY", cmbInitialKey.InitialKey.Trim());
            SData.ID3v2Info.SetTextFrame("TMED", cmbMediaType.MediaType.Trim());
            SData.ID3v2Info.SetTextFrame("TFLT", FileType.Trim());

            AddUserData(dgvUserTexts);
            AddUserData(dgvUserWeb);
        }
    }
}