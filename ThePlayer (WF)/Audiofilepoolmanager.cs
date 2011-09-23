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
            foreach (Audiofilepool afp in Program.ActiveDatabase.LoadAudiofilepools())
            {
                lsvAudiofilepools.Items.Add(afp.Name).SubItems.Add(afp.Basepath);
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
                string poolname = Path.GetFileName(fbd.SelectedPath);
                //TODO: Maybe make this different (without Messageboxes)
                bool savemeta = (MessageBox.Show("Metadaten aus den Dateien auslesen und in die Datenbank schreiben? Bisher nicht erfasste Songs werden sonst ignoriert.", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes);
                bool linkfiles = (MessageBox.Show("Dateien auch mit den Metadaten verknüpfen (empfohlen)?", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes);

                Dictionary<string, Song> read = Audiofolder.Read(fbd.SelectedPath);
                List<Song> songs = new List<Song>(read.Values);
                List<string> files = new List<string>(read.Keys);
                int[] ids = null;

                ids = Program.ActiveDatabase.ManageSongs(songs, savemeta);
                if (linkfiles)
                {
                    List<Audiofile> audiofiles = new List<Audiofile>();
                    for (int i = 0; i < files.Count; i++)
                        audiofiles.Add(new Audiofile(-1, files[i], ids[i]));
                    Program.ActiveDatabase.InsertAudiofiles(audiofiles);
                }

                //LoadPools();
                //Program.GlobalConfig.Save();
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
                    //Program.Audiofilepools.Remove(item.Text);
                    item.Remove();
                }
                Program.GlobalConfig.Save();
            }
        }
    }
}
