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
            LoadWatchedFolders();

        }

        private void LoadWatchedFolders()
        {
            lsvAudiofilepools.Items.Clear();

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
                bool savemeta = (MessageBox.Show("Metadaten aus den Dateien auslesen und in die Datenbank schreiben? Bisher nicht erfasste Songs werden sonst ignoriert.", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes);
                bool linkfiles = (MessageBox.Show("Dateien mit Metadaten verknüpfen (empfohlen)?", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes);
                bool makepool = (savemeta) ? (MessageBox.Show("Einen Songpool aus den Metadaten erstellen?", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) : false;
                if (savemeta || linkfiles)
                    Audiofolder.ProcessFolder(fbd.SelectedPath, savemeta, linkfiles, makepool);
                else
                    MessageBox.Show("Es wurde nichts getan!");
            }
            else
                MessageBox.Show("Folder does not exist!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(lsvAudiofilepools.SelectedItems.Count.ToString() + " Ordner aus der Überwachung entfernen? Die Ordner werden nicht von der Festplatte gelöscht. Aus diesen Ordnern ausgelesene Songs werden nicht aus der Datenbank entfernt.", Application.ProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
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
