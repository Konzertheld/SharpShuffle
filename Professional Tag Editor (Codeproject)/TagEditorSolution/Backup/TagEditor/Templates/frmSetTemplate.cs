using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags;

namespace TagEditor.Templates
{
    public partial class frmSetTemplate : Form
    {
        private string[] _CopyTypesDescription = { "First clear all information that file included and then copy information from template to file." ,
                "Copy the information from template that was not defined in file.", 
                "Copy the infromation from template. If the field was defined overwrite it."};

        public frmSetTemplate(Template Temp, int Count)
        {
            InitializeComponent();
            ShowTemplate(Temp);

            lblQuestion.Text += Count.ToString() + " files selected ?";
        }

        public frmSetTemplate(Template Temp, ITagInfo Tag)
        {
            InitializeComponent();
            ShowTemplate(Temp);

            lblQuestion.Text += "'" + Tag.FileName + "' ?";
        }

        private void ShowTemplate(Template Temp)
        {
            lblName.Text = Temp.Name;
            lblDescription.Text = Temp.Description;
            cmbCopyType.SelectedIndex = (int)Temp.CopyType;

            ctrlTagSummary.TagInfo = Temp.Tag;
        }

        private void cmbCopyTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCopyTypeDescription.Text = _CopyTypesDescription[cmbCopyType.SelectedIndex];
        }

        public TemplateCopyTypes CopyType
        {
            get
            { return (TemplateCopyTypes)cmbCopyType.SelectedIndex; }
        }
    }
}