using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TagEditor.Properties;

namespace TagEditor
{
    public partial class Agreement : Form
    {
        public Agreement()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Settings.Default.ShowAgreement = false;
        }
    }
}