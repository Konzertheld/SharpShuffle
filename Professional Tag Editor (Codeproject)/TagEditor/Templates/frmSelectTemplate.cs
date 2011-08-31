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
    public partial class frmSelectTemplate : Form
    {
        /// <summary>
        /// Create new select template dialog
        /// </summary>
        /// <param name="ListType">Indicate wich type of tags must show in list</param>
        public frmSelectTemplate(TagListTypes ListType)
        {
            InitializeComponent();

            _ListType = ListType;
            LoadList();
        }

        private void LoadList()
        {
            foreach (Template T in sTemplateCollection.TemplateArray)
                if (ListType == TagListTypes.Both || ListType.ToString() == T.TagType.ToString())
                    lsbTemplates.Items.Add(T);
        }

        private TagListTypes _ListType;
        /// <summary>
        /// Gets type of tags that list shows
        /// </summary>
        public TagListTypes ListType
        {
            get
            { return _ListType; }
        }

        /// <summary>
        /// Gets or sets selected template of list
        /// </summary>
        public Template SelectedTemplate
        {
            set
            { lsbTemplates.SelectedItem = value; }
            get
            { return lsbTemplates.SelectedItem as Template; }
        }

        private void lsbTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (lsbTemplates.SelectedIndex != -1);
        }
    }
}