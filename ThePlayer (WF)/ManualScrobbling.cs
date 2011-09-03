using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThePlayer
{
    public partial class frmManualScrobbling : Form
    {
        public frmManualScrobbling()
        {
            InitializeComponent();
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            Scrobbel.Scrobbeln(txtArtist.Text, txtTitle.Text, DateTime.Now.Subtract(new TimeSpan(1,0,0)), int.Parse(txtLength.Text));
        }
    }
}
