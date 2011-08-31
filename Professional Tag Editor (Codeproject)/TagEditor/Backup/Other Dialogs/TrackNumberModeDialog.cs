using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags;
using TagEditor.Properties;

namespace TagEditor
{
    public partial class TrackNumberModeDialog : Form
    {
        public TrackNumberModeDialog(TagListTypes ListType)
        {
            InitializeComponent();
            rdbTotal.Checked = Settings.Default.WriteTotalTrackNumbers;
            rdbSingle.Checked = !rdbTotal.Checked;
            chbSetHaveID3v1.Checked = Settings.Default.SetHaveTagForID3v1;
            chbSetHaveID3v2.Checked = Settings.Default.SetHaveTagForID3v2;

            if (ListType == TagListTypes.ASF)
            {
                chbSetHaveID3v2.Visible = false;
                chbSetHaveID3v1.Text = chbSetHaveID3v1.Text.Replace("ID3v1", "WMA");
            }
        }

        public bool WriteTotal
        {
            get
            { return rdbTotal.Checked; }
        }

        public bool SetHaveTagForID3v1
        {
            get
            { return chbSetHaveID3v1.Checked; }
        }

        public bool SetHaveTagForID3v2
        {
            get
            { return chbSetHaveID3v2.Checked; }
        }

        public bool SetHaveTagForWMA
        {
            get
            { return chbSetHaveID3v1.Checked; }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.Default.WriteTotalTrackNumbers = rdbTotal.Checked;
            Settings.Default.SetHaveTagForID3v1 = chbSetHaveID3v1.Checked;
            Settings.Default.SetHaveTagForID3v2 = chbSetHaveID3v2.Checked;
        }
    }
}