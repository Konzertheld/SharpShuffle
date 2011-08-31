using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using TagEditor.Properties;
using Tags.ID3;
using Tags.ASF;
using TagEditor.Columns;
using Tags;
using TagEditor.Templates;
using Tags.ID3.ID3v2Frames.TextFrames;

namespace TagEditor
{
    public partial class MainDialog : Form
    {
        private const int IndexOK = 0;
        private const int IndexWarning = 1;
        private const int IndexSave = 2;
        private const int IndexError = 3;
        private const int IndexEdit = 4;

        public MainDialog()
        {
            InitializeComponent();

            LoadSetting();
            sTemplateCollection.Load();
        }

        private void LoadSetting()
        {
            this.WindowState = Settings.Default.MainFormMaximized ? FormWindowState.Maximized : FormWindowState.Normal;
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Size = Settings.Default.MainFormSize;
                this.Location = Settings.Default.MainFormLocation;
            }

            mnuViewLeftPanel.Checked = Settings.Default.ShowLeftPanel;
            mnuViewProffesionalPanel.Checked = Settings.Default.ShowProfessionalPanel;
            pnlLeft.Size = Settings.Default.LeftPanelSize;

            tbcRight.SelectedIndex = (Settings.Default.SelectedTab < tbcRight.TabPages.Count) ?
              Settings.Default.SelectedTab : 2;

            LoadFormula();
        }

        private void LoadFormula()
        {
            if (ListType != TagListTypes.ASF)
            {
                txtFormula.Text = Settings.Default.MP3FilenameFormula;
                chbFilename.Checked = Settings.Default.MP3UseFormula;
            }
            else
            {
                txtFormula.Text = Settings.Default.WMAFilenameFormula;
                chbFilename.Checked = Settings.Default.WMAUseFormula;
            }
        }

        private void SaveSetting()
        {
            for (int i = 0; i < lsbFiles.Columns.Count; i++)
                ColumnsCollection.Columns[i].Width = lsbFiles.Columns[i].Width;
            ColumnsCollection.Save();

            sTemplateCollection.Save();

            Settings.Default.MainFormMaximized = (this.WindowState == FormWindowState.Maximized);
            if (this.WindowState != FormWindowState.Maximized)
            {
                Settings.Default.MainFormSize = this.Size;
                Settings.Default.MainFormLocation = this.Location;
            }

            Settings.Default.ShowLeftPanel = mnuViewLeftPanel.Checked;
            Settings.Default.ShowProfessionalPanel = mnuViewProffesionalPanel.Checked;
            Settings.Default.LeftPanelSize = pnlLeft.Size;
            Settings.Default.SelectedTab = tbcRight.SelectedIndex;

            Settings.Default.Save();
        }

        #region -> Menu Events <-

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddNewFile(object sender, EventArgs e)
        {
            AddFile();
        }

        private void mnuViewListColumns_Click(object sender, EventArgs e)
        {
            frmColumnSetting ColForm = new frmColumnSetting();
            if (ColForm.ShowDialog() == DialogResult.OK)
                UpdateList();
        }

        private void mnuFileSelectFolder_Click(object sender, EventArgs e)
        {
            SelectFolder Form = new SelectFolder();

            Form.ShowDialog();
            UpdateUI(null, null);
        }

        private void mnuEditSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem I in lsbFiles.Items)
                I.Selected = true;
        }

        private void ExportSelectedAsM3U(object sender, EventArgs e)
        {
            sM3U.Save(GetSelected());
        }

        private void mnuViewProffesionalPanel_CheckedChanged(object sender, EventArgs e)
        {
            tbcRight.Visible = mnuViewProffesionalPanel.Checked;
        }

        private void mnuViewLeftPanel_CheckedChanged(object sender, EventArgs e)
        {
            ShowLeftPanel = mnuViewLeftPanel.Checked;
        }

        #endregion

        #region -> Items methods and properties <-

        /// <summary>
        /// Add specific file to list
        /// </summary>
        /// <param name="path">Path of file to add to list</param>
        public void AddFile(string path)
        {
            string Ext = Path.GetExtension(path).ToLower();

            if (lsbFiles.Items.ContainsKey(path))
            {
                MessageBox.Show("'" + path + "' is already in list.", "Exists",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if ((Ext == ".mp3" && ListType == TagListTypes.ASF)
                || (Ext == ".wma" && ListType == TagListTypes.ID3))
            {
                MessageBox.Show("You have " + ((ListType == TagListTypes.ID3) ? "Mp3" : "Wma") +
                    " file in list already, you must add same file type or clear the list to add another type." +
                    "If you are addging more than one file check if all selected files have same extention",
                    "File Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ITagInfo Tag;
                if (Ext == ".mp3")
                    Tag = new ID3Info(path, true);
                else if (Ext == ".wma")
                    Tag = new ASFTagInfo(path, true);
                else if (Ext == ".m3u")
                {
                    string[] List = sM3U.Load(path);
                    foreach (string st in List)
                        AddFile(st);
                    return;
                }
                else
                {
                    MessageBox.Show("'" + Ext + "' file type is unknown to this application", "Unknown FileType.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (lsbFiles.Items.Count == 0) // If this was first file of list
                {
                    ColumnsCollection.Load((Ext == ".mp3") ? TagListTypes.ID3 : TagListTypes.ASF);
                    UpdateList();
                }

                AddToList(Tag);
                if (lsbFiles.Items.Count == 1)
                {
                    if (Tag.GetType() == typeof(ASFTagInfo))
                    {
                        lblListType.Text = "W";
                        pnlWMA.Visible = true;
                        pnlMP3.Visible = false;
                    }
                    else if (Tag.GetType() == typeof(ID3Info))
                    {
                        lblListType.Text = "M";
                        pnlWMA.Visible = false;
                        pnlMP3.Visible = true;
                    }

                    UpdateButtons();
                    UpdateTemplates();
                    LoadFormula();
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You don't have access permision for '" + path + "'. Check if file is readonly or you have access by operating system.", "Error On Adding", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Could not add file \"" + path +
                    "\".\n" + Ex.Message, "Error On Adding", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Open an OpenFileDialog to select files to add to list
        /// </summary>
        public void AddFile()
        {
            TagListTypes T = ListType;
            if (T == TagListTypes.ASF)
            {
                ofdAddFile.Filter = Resources.ASFExtention;
                ofdAddFile.FilterIndex = 1;
            }
            else if (T == TagListTypes.ID3)
            {
                ofdAddFile.Filter = Resources.ID3Extention;
                ofdAddFile.FilterIndex = 1;
            }
            else
            {
                ofdAddFile.Filter = Resources.BothExtention;
                ofdAddFile.FilterIndex = 3;
            }

            if (ofdAddFile.ShowDialog() == DialogResult.OK)
                foreach (string var in ofdAddFile.FileNames)
                    AddFile(var);
        }

        /// <summary>
        /// When open button of OpenFileDialog clicked, validating extensions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ofdAddFile_FileOk(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsExtentionsValid(ofdAddFile.FileNames);
        }

        private void lsbFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lsbFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] Files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (Directory.Exists(Files[0]))
            {
                SelectFolder dlg = new SelectFolder();
                dlg.DirectoryName = Files[0];
                dlg.ShowDialog();
            }
            else
                foreach (string st in Files)
                    AddFile(st);
        }

        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (ListViewItem I in lsbFiles.Items)
                if (I.StateImageIndex == IndexEdit)
                {
                    DialogResult R = MessageBox.Show("There is unsaved item in list. Are you sure you want close application ?",
                        "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (R == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                        break;
                }

            SaveSetting();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdateList();

            UpdateUI(null, null);

#if DEBUG
            throw new Exception();
#endif
        }

        private void UpdateUI(object sender, EventArgs e)
        {
            if (lsbFiles.SelectedIndices.Count > 0)
                UpdateUI();
            tmrUpdateUI.Enabled = true;
        }

        private void UpdateUI()
        {
            UpdateButtons();

            UpdateProPanel();
        }

        private void UpdateProPanel()
        {
            if (mnuViewProffesionalPanel.Checked)
            {
                UpdateSummary();
                UpdateError();
            }
        }

        private void tmrUpdateUI_Tick(object sender, EventArgs e)
        {
            if (lsbFiles.SelectedIndices.Count == 0)
                UpdateUI();

            tmrUpdateUI.Enabled = false;
        }

        private void tbcRight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcRight.SelectedTab == tbpSummary)
                UpdateSummary();
            else if (tbcRight.SelectedTab == tbpErrors)
                UpdateError();
            else
                UpdateTemplates();
        }

        #region -> Context Menu Events <-

        private void cmnListSummary_Click(object sender, EventArgs e)
        {

        }

        private void cmnList_Opening(object sender, CancelEventArgs e)
        {

        }

        #endregion

        #region -> Button Clicked Events <-

        private void DownClicked(object sender, EventArgs e)
        {
            int index = lsbFiles.SelectedIndices[0];
            ListViewItem LVI = lsbFiles.SelectedItems[0];
            lsbFiles.Items.Remove(LVI);
            lsbFiles.Items.Insert(index + 1, LVI);
        }

        private void UpClicked(object sender, EventArgs e)
        {
            int index = lsbFiles.SelectedIndices[0];
            ListViewItem LVI = lsbFiles.SelectedItems[0];
            lsbFiles.Items.Remove(LVI);
            lsbFiles.Items.Insert(index - 1, LVI);
        }

        private void DeleteSelectedFromList(object sender, EventArgs e)
        {
            foreach (ListViewItem var in lsbFiles.SelectedItems)
                lsbFiles.Items.Remove(var);

            if (lsbFiles.Items.Count == 0)
                lblListType.Text = "WM";

            UpdateUI(null, null);
        }

        private void SaveAllClicked(object sender, EventArgs e)
        {
            if (chbFilename.Checked)
                if (MessageBox.Show("You have checked 'File name formula' are you sure you want to rename the files ?",
                    "Renaming", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

            SaveFiles frmSave = new SaveFiles((IList)lsbFiles.Items, chbFilename.Checked ? txtFormula.Text : "");
            frmSave.ShowDialog();
        }

        private void ClearClicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear the list ?", "List Clearing",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                lsbFiles.Items.Clear();
                UpdateUI(null, null);
            }

            if (lsbFiles.Items.Count == 0)
                lblListType.Text = "WM";
        }

        private void ShowDialog(object sender, EventArgs e)
        {
            Type FormType = Type.GetType((string)(sender as Control).Tag);
            DialogResult R;

            if (FormType.BaseType == typeof(iFormBase))
            {
                iFormBase Dialog;
                if (lsbFiles.SelectedIndices.Count > 1)
                    Dialog = FormType.GetConstructor(new Type[] { typeof(IList) }).Invoke(new object[] { (IList)lsbFiles.SelectedItems }) as iFormBase;
                else
                    Dialog = FormType.GetConstructor(new Type[] { typeof(int) }).Invoke(new object[] { lsbFiles.SelectedIndices[0] }) as iFormBase;
                R = Dialog.ShowDialog();
            }
            else
            {
                aFormBase Dialog;
                if (lsbFiles.SelectedIndices.Count > 1)
                    Dialog = FormType.GetConstructor(new Type[] { typeof(ASFTagInfo[]) }).Invoke(new object[] { (ASFTagInfo[])GetSelected() }) as aFormBase;
                else
                    Dialog = FormType.GetConstructor(new Type[] { typeof(int) }).Invoke(new object[] { lsbFiles.SelectedIndices[0] }) as aFormBase;
                R = Dialog.ShowDialog();
            }

            if (R == DialogResult.OK && lsbFiles.SelectedIndices.Count > 1)
                UpdateListValues();

            UpdateProPanel();
        }

        #endregion

        #region -> UI Update Methods <-

        void UpdateSummary()
        {
            if (tbcRight.SelectedTab != tbpSummary)
                return;

            if (lsbFiles.SelectedIndices.Count == 0)
            {
                lblSummary.Text = "No file selected";
                return;
            }

            if (lsbFiles.SelectedIndices.Count > 1)
            {
                lblSummary.Text = lsbFiles.SelectedIndices.Count.ToString() +
                    " File(s) selected";
                return;
            }

            if (ListType == TagListTypes.ID3)
            {
                ID3Info Tag = (ID3Info)lsbFiles.SelectedItems[0].Tag;
                lblSummary.Text = Tag.FileName + " Include:\n";
                lblSummary.Text += (Tag.ID3v1Info.HaveTag) ? "\n  ID3v1" : "";
                lblSummary.Text += (Tag.ID3v2Info.HaveTag) ? "\n  ID3v" + Tag.ID3v2Info.Version.ToString() : "";
                SummaryTextAdder(Tag.ID3v2Info.Errors.Count, "Error(s)");
                if (Tag.ID3v2Info.HaveTag)
                {
                    lblSummary.Text += "\n- - - - - - - - - - - - - -\n";
                    if (Tag.ID3v2Info.Experimental)
                        lblSummary.Text += "\n Experimental ID3";
                    SummaryTextAdder(Tag.ID3v2Info.UnKnownFrames.Count, "Unknown Frame(s) Found");
                    SummaryTextAdder(Tag.ID3v2Info.TextFrames.Count, "Text Frame(s)");
                    SummaryTextAdder(Tag.ID3v2Info.UserTextFrames.Count, "UserText Frame(s)");
                    SummaryTextAdder(Tag.ID3v2Info.AttachedPictureFrames.Count, "Picture(s)");

                    int Count = 0;
                    foreach (TextWithLanguageFrame T in Tag.ID3v2Info.TextWithLanguageFrames)
                        if (T.FrameID == "COMM")
                            Count++;
                    SummaryTextAdder(Count, "Comment(s)");

                    SummaryTextAdder(Tag.ID3v2Info.LinkFrames.Count, "Linked Frame(s)");
                    if (Tag.ID3v2Info.PlayCounter != null)
                        SummaryTextAdder(Tag.ID3v2Info.PlayCounter.Counter, "Time(s) Played");
                    SummaryTextAdder(Tag.ID3v2Info.PopularimeterFrames.Count, "Time(s) Rated");
                    SummaryTextAdder(Tag.ID3v2Info.SynchronisedTextFrames.Count, "Synchronized Lyric(s)");

                    FileInfo F = new FileInfo(Tag.FilePath);
                    lblSummary.Text += "\n\n- - - - - - - - - - - - - -";
                    lblSummary.Text += "\n  File Size: " + Program.GetLengthString(F.Length);
                    lblSummary.Text += "\n  Tag Size: " + Program.GetLengthString(Tag.ID3v2Info.Length);
                }
            }
            else
            {
                ASFTagInfo Tag = (ASFTagInfo)lsbFiles.SelectedItems[0].Tag;
                lblSummary.Text = Tag.FileName + " Include:\n\n";
                if (Tag.ContentBranding != null)
                    lblSummary.Text += "Branding\n\n";
                if (Tag.ContentDescription != null)
                    lblSummary.Text += "Content Description\n\n";
                if (Tag.ExContentDescription != null)
                    lblSummary.Text += "Extended Content Description [" + Tag.ExContentDescription.Count.ToString() + " Values(s)]\n\n";

                lblSummary.Text += "- - - - - - - - - - - - - -";
                FileInfo F = new FileInfo(Tag.FilePath);
                lblSummary.Text += "\n  File Size: " + Program.GetLengthString(F.Length);
            }
        }

        void SummaryTextAdder(long Length, string Name)
        {
            if (Length > 0)
                lblSummary.Text += "\n  " + Length.ToString() + " " + Name;
        }

        void UpdateError()
        {
            if (tbcRight.SelectedTab != tbpErrors)
                return;

            if (lsbFiles.SelectedIndices.Count == 0)
            {
                txtError.Text = "No file selected";
                return;
            }

            if (lsbFiles.SelectedIndices.Count > 1)
            {
                txtError.Text = lsbFiles.SelectedIndices.Count.ToString() +
                    " File(s) selected";
                return;
            }

            ITagInfo Tag = (ITagInfo)lsbFiles.SelectedItems[0].Tag;
            if (Tag.HaveException)
            {
                txtError.Text = string.Empty;
                ExceptionCollection ExCol;
                if (ListType == TagListTypes.ID3)
                    ExCol = (Tag as ID3Info).ID3v2Info.Errors;
                else
                    ExCol = (Tag as ASFTagInfo).Exceptions;

                foreach (Exception var in ExCol)
                    txtError.Text += var.Message + "\n";
            }
            else
                txtError.Text = "No Error Occured";
        }

        void UpdateTemplates()
        {
            if (tbcRight.SelectedTab != tbpTemplate)
                return;

            lsbTemplates.Items.Clear();

            foreach (Template T in sTemplateCollection.TemplateArray)
                if ((int)T.TagType == (int)ListType)
                    lsbTemplates.Items.Add(T);
        }

        /// <summary>
        /// Updates columns names and their values
        /// </summary>
        void UpdateList()
        {
            List<ITagInfo> List = new List<ITagInfo>();
            foreach (ListViewItem Item in lsbFiles.Items)
                List.Add(Item.Tag as ITagInfo);

            lsbFiles.Items.Clear();
            lsbFiles.Columns.Clear();
            foreach (ListColumn Col in ColumnsCollection.Columns)
                lsbFiles.Columns.Add(Col.Name, Col.Width);

            foreach (ITagInfo T in List)
                AddToList(T);
        }

        void UpdateListValues()
        {
            for (int i = 0; i < lsbFiles.SelectedIndices.Count; i++)
                UpdateRow(lsbFiles.SelectedIndices[i], true);
        }

        void UpdateButtons()
        {
            bool Up = true, Down = true;
            if (lsbFiles.SelectedIndices.Count != 1)
            {
                Up = false;
                Down = false;
            }
            else
            {
                if (lsbFiles.SelectedIndices[0] == lsbFiles.Items.Count - 1)
                    Down = false;

                if (lsbFiles.SelectedIndices[0] == 0)
                    Up = false;
            }

            btnUp.Enabled = mnuEditUp.Enabled = Up;
            btnDown.Enabled = mnuEditDown.Enabled = Down;

            mnuFileReload.Enabled = btnSave.Enabled = btnRemove.Enabled =
                mnuEditDelete.Enabled = (lsbFiles.SelectedIndices.Count != 0);
            CurrentPanel.Enabled = mnuFileSaveSelected.Enabled =
                mnuFileSaveM3U.Enabled = btnRemove.Enabled;

            if (CurrentPanel.Enabled == true)
            {
                bool isSingle = (lsbFiles.SelectedItems.Count == 1);
                btnIdentifiers.Enabled = btnPictures.Enabled = btnLyric.Enabled =
                    btnCommercial.Enabled = btnPopularimeter.Enabled =
                    btnFiles.Enabled = btnComment.Enabled = isSingle;

                btnAIdentifiers.Enabled = btnABranding.Enabled = isSingle;
            }

            btnClear.Enabled = mnuEditClearList.Enabled = (lsbFiles.Items.Count > 0);
            lnlSetTrackNumber.Enabled = btnSaveAll.Enabled = mnuFileSaveAll.Enabled = btnClear.Enabled;

            lnkExportM3U.Enabled = mnuTemplateSet.Enabled = (lsbFiles.SelectedIndices.Count > 0);

        }

        #endregion

        #region -> UI Properties <-

        bool ShowLeftPanel
        {
            get
            { return pnlLeft.Visible; }
            set
            {
                pnlLeft.Visible = value;
                splLeft.Visible = value;
            }
        }

        bool ShowRightPanel
        {
            get
            { return pnlRight.Visible; }
            set
            {
                pnlRight.Visible = value;
                splRight.Visible = value;
            }
        }

        #endregion

        #region -> File Collection M&P <-

        public ListView.ListViewItemCollection Items
        {
            get
            { return lsbFiles.Items; }
        }

        /// <summary>
        /// Get Listtype of current list of files
        /// </summary>
        public TagListTypes ListType
        {
            get
            {
                if (lblListType.Text == "W")
                    return TagListTypes.ASF;
                else if (lblListType.Text == "M")
                    return TagListTypes.ID3;
                else
                    return TagListTypes.Both;
                //if (lsbFiles.Items.Count == 0)
                //    return TagListTypes.Both;

                //if (Path.GetExtension(lsbFiles.Items[0].Name).ToLower() == ".mp3")
                //    return TagListTypes.ID3;
                //else if (Path.GetExtension(lsbFiles.Items[0].Name).ToLower() == ".wma")
                //    return TagListTypes.ASF;
                //else
                //    return TagListTypes.Both;
            }
        }

        #endregion

        #region -> Validating Methods <-

        bool IsExtentionsValid(params string[] FileNames)
        {
            string Ext;
            Ext = Path.GetExtension(FileNames[0]).ToLower();
            if (Ext != ".wma" && Ext != ".mp3")
            {
                MessageBox.Show("Selected file(s) extensions must be mp3 or wma.",
                        "Extension problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Ext == ".wma" && ListType == TagListTypes.ID3)
            {
                MessageBox.Show("List already contains mp3 file(s). To add wma you must first remove mp3 files from list.",
                        "Extension problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (Ext == ".mp3" && ListType == TagListTypes.ASF)
            {
                MessageBox.Show("List already contains wma file(s). To add mp3 you must first remove wma files from list.",
                        "Extension problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check all files have one extension
            for (int i = 1; i < FileNames.Length; i++)
                if (Path.GetExtension(FileNames[i]).ToLower() != Path.GetExtension(FileNames[0]).ToLower())
                {
                    MessageBox.Show("All of selected files must be mp3 or all of them must be wma.",
                        "Extension problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            return true;
        }

        #endregion

        private Panel CurrentPanel
        {
            get
            { return pnlMP3.Visible ? pnlMP3 : pnlWMA; }
        }

        private ITagInfo[] GetSelected()
        {
            ArrayList Arr = new ArrayList();
            foreach (ListViewItem var in lsbFiles.SelectedItems)
                Arr.Add((ITagInfo)var.Tag);
            return (ITagInfo[])Arr.ToArray((ListType == TagListTypes.ASF) ? typeof(ASFTagInfo) : typeof(ID3Info));
        }

        void AddToList(ITagInfo Tag)
        {
            List<string> Params = new List<string>();
            foreach (ListColumn var in ColumnsCollection.Columns)
                Params.Add(var.GetValue(Tag));

            ListViewItem LVI = new ListViewItem(Params.ToArray());
            LVI.Name = Tag.FilePath;
            LVI.Tag = Tag;
            if (Tag.HaveException)
                LVI.StateImageIndex = IndexWarning;
            else
                LVI.StateImageIndex = IndexOK;
            lsbFiles.Items.Add(LVI);
        }

        private void lnlSelectFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mnuFileSelectFolder_Click(null, null);
        }

        private void lnkExportM3U_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ExportSelectedAsM3U(null, null);
        }

        private void lnlMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditFormula Dialog = new EditFormula();
            Dialog.Formula = txtFormula.Text;
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                txtFormula.Text = Dialog.Formula;
                chbFilename.Checked = true;
            }
        }

        private void chbFilename_CheckedChanged(object sender, EventArgs e)
        {
            txtFormula.Enabled = chbFilename.Checked;
            mnuEditUseFormula.Checked = chbFilename.Checked;
            if (ListType != TagListTypes.ASF)
            {
                Settings.Default.MP3FilenameFormula = txtFormula.Text;
                Settings.Default.MP3UseFormula = chbFilename.Checked;
            }
            else
            {
                Settings.Default.WMAFilenameFormula = txtFormula.Text;
                Settings.Default.WMAUseFormula = chbFilename.Checked;
            }
        }

        private void mnuEditUseFormula_Click(object sender, EventArgs e)
        {
            mnuEditUseFormula.Checked = !mnuEditUseFormula.Checked;
            chbFilename.Checked = mnuEditUseFormula.Checked;
        }

        private void ShowTemplateForm(object sender, EventArgs e)
        {
            TemplateManager Manager = new TemplateManager();
            Manager.ShowDialog();
            UpdateTemplates();
        }

        private void lsbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            lnkSet.Enabled = lsbTemplates.Items.Count > 0;
        }

        private void SetTemplate(object sender, EventArgs e)
        {
            if (lsbTemplates.SelectedIndex == -1)
                return;

            if (lsbFiles.SelectedItems.Count == 0)
            {
                MessageBox.Show("There's no selected file in list to set template.", "Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetTemplate(lsbTemplates.SelectedItem as Template);
        }

        private void SetTemplate(Template Temp)
        {
            if (lsbFiles.SelectedIndices.Count < 1)
                return;

            frmSetTemplate SetDlg;
            if (lsbFiles.SelectedIndices.Count == 1)
                SetDlg = new frmSetTemplate(Temp, lsbFiles.SelectedItems[0].Tag as ITagInfo);
            else
                SetDlg = new frmSetTemplate(Temp, lsbFiles.SelectedItems.Count);
            if (SetDlg.ShowDialog() == DialogResult.OK)
            {
                foreach (ITagInfo Ta in GetSelected())
                    Temp.CopyTo(Ta, SetDlg.CopyType);
                UpdateListValues();
            }
        }

        private void mnuTemplateSet_Click(object sender, EventArgs e)
        {
            frmSelectTemplate SelectTemplateDlg = new frmSelectTemplate(ListType);
            if (SelectTemplateDlg.ShowDialog() == DialogResult.OK)
            {
                SetTemplate(SelectTemplateDlg.SelectedTemplate);
                UpdateListValues();
            }
        }

        private void mnuEditEditFormula_Click(object sender, EventArgs e)
        {
            lnlMore_LinkClicked(null, null);
        }

        private void SaveSelectedClicked(object sender, EventArgs e)
        {
            SaveFiles frmSave = new SaveFiles((IList)lsbFiles.SelectedItems, chbFilename.Checked ? txtFormula.Text : "");
            frmSave.ShowDialog();
        }

        private void mnuFileReload_Click(object sender, EventArgs e)
        {
            string st;
            if (lsbFiles.SelectedIndices.Count > 1)
                st = lsbFiles.SelectedIndices.Count.ToString() + " items ?";
            else
                st = "'" + (lsbFiles.SelectedItems[0].Tag as ITagInfo).FileName + "' ?";

            if (MessageBox.Show("Are you sure you want to reload " + st,
                "Reload", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (ListViewItem var in lsbFiles.SelectedItems)
                ReloadItem(var);
        }

        private void ReloadItem(ListViewItem var)
        {
            ITagInfo T = (ITagInfo)var.Tag;
            try
            {
                T.Load();
                if (T.HaveException)
                    var.StateImageIndex = IndexWarning;
                else
                    var.StateImageIndex = IndexOK;
                UpdateRow(var.Index, false);
            }
            catch (Exception Ex)
            {
                var.StateImageIndex = IndexError;
                MessageBox.Show("Could not load file '" + T.FileName + "'\n" + Ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateRow(int index, bool Edit)
        {
            for (int i = 0; i < ColumnsCollection.Columns.Count; i++)
                lsbFiles.Items[index].SubItems[i].Text = ColumnsCollection.Columns[i].GetValue((ITagInfo)lsbFiles.Items[index].Tag);

            if (Edit)
                lsbFiles.Items[index].StateImageIndex = IndexEdit;
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            AboutDialog frmAbout = new AboutDialog();
            frmAbout.ShowDialog();
        }

        private void SetTrackNumber(object sender, EventArgs e)
        {
            TrackNumberModeDialog TND = new TrackNumberModeDialog(ListType);

            if (TND.ShowDialog() == DialogResult.OK)
            {
                byte C = 1;
                if (ListType == TagListTypes.ASF)
                    foreach (ListViewItem I in lsbFiles.Items)
                    {
                        ASFTagInfo T = (ASFTagInfo)I.Tag;
                        if (TND.SetHaveTagForWMA && T.ExContentDescription == null)
                            T.ExContentDescription = new Tags.Objects.ExContentDescriptionOb();

                        if (T.ExContentDescription != null)
                        {
                            T.ExContentDescription.SetValue("WM/TrackNumber", C.ToString() + ((TND.WriteTotal) ? "/" + lsbFiles.Items.Count.ToString() : ""));
                            UpdateRow(I.Index, true);
                        }

                        C++;
                    }
                else
                    foreach (ListViewItem I in lsbFiles.Items)
                    {
                        ID3Info T = (ID3Info)I.Tag;
                        if (!T.ID3v1Info.HaveTag && TND.SetHaveTagForID3v1)
                            T.ID3v1Info.HaveTag = true;

                        if (T.ID3v1Info.HaveTag)
                            T.ID3v1Info.TrackNumber = C;

                        if (!T.ID3v2Info.HaveTag && TND.SetHaveTagForID3v2)
                            T.ID3v2Info.HaveTag = true;

                        if (T.ID3v2Info.HaveTag)
                        {
                            T.ID3v2Info.SetTextFrame("TRCK", C.ToString() + ((TND.WriteTotal) ? "/" + lsbFiles.Items.Count.ToString() : ""));
                            UpdateRow(I.Index, true);
                        }

                        C++;
                    }
            }
        }

        private void lnlSetTrackNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void mnuHelpHelp_Click(object sender, EventArgs e)
        {
            this.OnHelpRequested(new HelpEventArgs(new Point(0, 0)));
        }
    }
}