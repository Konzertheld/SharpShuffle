using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace TagEditor
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            lblApplicationName.Text = Program.SoftwareCompleteName;

            lblCore.Text += " " + Program.GetAssemblyVersion("Tags");
            lblTagControl.Text += " " + Program.GetAssemblyVersion("TagInfoControls");
        }

        private void tmrClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            tmrClose.Enabled = true;
        }
    }
}