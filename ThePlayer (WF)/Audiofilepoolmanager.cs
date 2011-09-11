using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThePlayer
{
    public partial class Audiofilepoolmanager : Form
    {
        public Audiofilepoolmanager()
        {
            InitializeComponent();
        }

        private void Audiofilepoolmanager_Load(object sender, EventArgs e)
        {
            LoadPools();
            Program.GlobalConfig.Save();
        }

        private void LoadPools()
        {
            lsvAudiofilepools.Items.Clear();
            foreach (KeyValuePair<string, Audiofilepool> afp in Program.Audiofilepools)
            {
                lsvAudiofilepools.Items.Add(afp.Key).SubItems.Add(afp.Value.Basepath);
            }
            if (lsvAudiofilepools.Items.Count > 0)
                this.lblHint.Visible = false;
        }

        private void ordnerHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.ShowDialog();
            if (Directory.Exists(fbd.SelectedPath))
            {
                this.Cursor = Cursors.WaitCursor;
                //TODO: Let the user enter a name (for both audiofilepool and songpool)
                Audiofilepool afp = new Audiofilepool(fbd.SelectedPath, Path.GetFileName(fbd.SelectedPath));
                Program.Audiofilepools.Add(Path.GetFileName(fbd.SelectedPath), afp);
                afp.Save();
                if (MessageBox.Show("Möchten Sie auch einen Songpool aus den Songs in diesem Ordner erstellen? Sie können das auch später noch machen. (Wenn Sie das erste Mal einen Ordner scannen, sollten Sie das jetzt tun.)", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    Program.Songpools.Add(Path.GetFileName(fbd.SelectedPath), afp.createSongpool());
                LoadPools();
                Program.GlobalConfig.Save();
                this.Cursor = Cursors.Default;
            }
            else
                MessageBox.Show("Folder does not exist!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(lsvAudiofilepools.SelectedItems.Count.ToString() + " Dateisammlung(en) aus der Bibliothek entfernen? Die Ordner werden nicht von Ihrer Festplatte gelöscht.", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                foreach (ListViewItem item in lsvAudiofilepools.SelectedItems)
                {
                    Program.Audiofilepools.Remove(item.Text);
                    item.Remove();
                }
                Program.GlobalConfig.Save();
            }
        }
    }
}
