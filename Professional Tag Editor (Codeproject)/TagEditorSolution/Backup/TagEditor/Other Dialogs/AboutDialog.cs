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
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void AboutDialog_Load(object sender, EventArgs e)
        {
            lblApplicationName.Text = Program.SoftwareCompleteName;
            this.Text += " " + Program.SoftwareCompleteName;
            lblCoreVer.Text += " " + Program.GetAssemblyVersion("Tags");
            lblTagControlVer.Text += " " + Program.GetAssemblyVersion("TagInfoControls");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:hamed.ji@gmail.com");
        }
    }
}