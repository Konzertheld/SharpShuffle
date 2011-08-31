using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TagInfoControls;
using Tags.ID3;
using Tags;
using Tags.ASF;
using System.IO;

namespace TagEditor.Templates
{
    public partial class TemplateManager : Form
    {
        public TemplateManager()
        {
            InitializeComponent();

            // Add all templates to list
            foreach (Template T in sTemplateCollection.TemplateArray)
                lsbTemplates.List.Items.Add(T);
        }

        void AddTemplate(Template Temp)
        {
            lsbTemplates.List.Items.Add(Temp);
            lsbTemplates.List.SelectedIndex = lsbTemplates.List.Items.Count - 1;
            txtName.Focus();
        }

        private void lsbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbTemplates.List.SelectedIndices.Count != 1)
            {
                grpSelectedTemplate.Enabled = false;
            }
            else
            {
                grpSelectedTemplate.Enabled = true;
                Template T = SelectedTemplate;
                txtName.Text = T.Name;
                txtDescription.Text = T.Description;
                cmbCopyType.SelectedIndex = (int)T.CopyType;

                pnlMP3.Visible = (T.TagType == TagTypes.ID3);
                pnlWMA.Visible = !pnlMP3.Visible;
            }
        }

        private Template SelectedTemplate
        {
            get
            { return (lsbTemplates.List.SelectedItem as Template); }
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            SelectedTemplate.Description = txtDescription.Text.Trim();
        }

        private void lsbTemplates_AddClicked(object sender, EventArgs e)
        {
            mnuTemplateType.Show(lsbTemplates, 0, lsbTemplates.Height);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (TagInfoControls.StaticMethods.ValidatingControlAsProperty(txtName, lsbTemplates.List.SelectedIndex, lsbTemplates, "Name"))
            {
                e.Cancel = true;
                return;
            }

            if (txtName.Text.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                e.Cancel = true;
                MessageBox.Show("'" + txtName.Text + "' is invalid file name. please enter valid file name for name of templates.",
                    "Filename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                SelectedTemplate.Name = txtName.Text.Trim();
                lsbTemplates.UpdateView();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Can't rename Template file.\n" + Ex.Message, "Rename Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void ShowDialog(object sender, EventArgs e)
        {
            Type FormType = Type.GetType((string)(sender as Control).Tag);

            if (FormType.BaseType == typeof(iFormBase))
            {
                iFormBase Dialog;
                Dialog = FormType.GetConstructor(new Type[] { typeof(ID3Info) }).Invoke(new object[] { (ID3Info)SelectedTemplate.Tag }) as iFormBase;
                Dialog.ShowDialog();
            }
            else
            {
                aFormBase Dialog;
                Dialog = FormType.GetConstructor(new Type[] { typeof(ASFTagInfo) }).Invoke(new object[] { (ASFTagInfo)SelectedTemplate.Tag }) as aFormBase;
                Dialog.ShowDialog();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sTemplateCollection.Clear();
            foreach (Template T in lsbTemplates.List.Items)
                sTemplateCollection.Add(T);

            foreach (Template T in lsbTemplates.List.Items)
                T.Save();
        }

        #region -> Menu Events <-

        private void mnuMP3_Click(object sender, EventArgs e)
        {
            string Name = "MP3 Template";
            TagInfoControls.StaticMethods.ValidatingProperty(ref Name, -1, lsbTemplates,
                "Name");
            AddTemplate(new Template(Name, "", TagTypes.ID3));
        }

        private void mnuWMA_Click(object sender, EventArgs e)
        {
            string Name = "WMA Template";
            TagInfoControls.StaticMethods.ValidatingProperty(ref Name, -1, lsbTemplates,
                "Name");
            AddTemplate(new Template(Name, "", TagTypes.ASF));
        }

        private void mnuFromFile_Click(object sender, EventArgs e)
        {
            Template Temp = Template.FromFile();
            if (Temp != null)
                AddTemplate(Temp);
        }

        #endregion

        private void lsbTemplates_RemovingItem(object sender, CancelEventArgs e)
        {
            try
            {
                if (File.Exists(SelectedTemplate.Tag.FilePath))
                    File.Delete(SelectedTemplate.Tag.FilePath);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Can't remove template file.\n" + Ex.Message, "Removing", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cmbCopyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedTemplate.CopyType = (TemplateCopyTypes)cmbCopyType.SelectedIndex;
        }

        private void lsbTemplates_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lsbTemplates_DragDrop(object sender, DragEventArgs e)
        {
            string F = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            Template Temp = Template.FromFile(F);
            if (Temp != null)
                AddTemplate(Temp);
        }
    }
}