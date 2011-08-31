using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TagEditor
{
    public partial class ExceptionDialog : Form
    {
        public ExceptionDialog(string message)
        {
            InitializeComponent();

            txtMessage.Text = message;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnlReport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:hamed.ji@gmail.com");
        }
    }
}