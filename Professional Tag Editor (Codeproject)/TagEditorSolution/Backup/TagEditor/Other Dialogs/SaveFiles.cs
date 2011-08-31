using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags;
using System.Reflection;
using System.Threading;
using TagEditor.Columns;
using System.Collections;

namespace TagEditor
{
    public partial class SaveFiles : Form
    {
        private int _Count;
        IList _Coll;
        private bool _Cancel;
        private readonly string _Rename;
        private string _Exception;

        public SaveFiles(IList Coll, string Rename)
        {
            InitializeComponent();
            _Count = 0;
            _Coll = Coll;
            prgProgress.Maximum = _Coll.Count;
            prgProgress.Value = 1;
            _Cancel = false;
            _Rename = Rename;
        }

        private void Save()
        {
            lblFileName.Text = ((_Coll[_Count] as ListViewItem).Tag as ITagInfo).FileName;
            bgwSaveFiles.RunWorkerAsync((_Coll[_Count++] as ListViewItem).Tag);
        }

        private void bgwSaveFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (e.Argument as ITagInfo).Save(_Rename);
            }
            catch (Exception Ex)
            {
                _Exception = Ex.Message;
            }
        }

        private void bgwSaveFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_Exception) || !(bool)e.Result)
            {
                (_Coll[_Count - 1] as ListViewItem).StateImageIndex = 3;
                DialogResult R = MessageBox.Show("Error while saving '" + ((_Coll[_Count - 1] as ListViewItem).Tag as ITagInfo).FileName + "'.\n" + _Exception +
                  "\nWhat to do for saving this file ?", "Saving Error",
                  MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                if (R == DialogResult.Abort)
                {
                    this.Close();
                    return;
                }
                else if (R == DialogResult.Retry)
                {
                    _Count--;
                    Save();
                    return;
                }

                _Exception = null;
            }
            else
                (_Coll[_Count - 1] as ListViewItem).StateImageIndex = 2;

            prgProgress.PerformStep();
            Program.MainForm.UpdateRow(_Count - 1, false);

            if (_Count >= _Coll.Count || _Cancel)
                this.Close();
            else
                Save();
        }

        private void SaveFiles_Load(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _Cancel = true;
        }
    }
}