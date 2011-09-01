namespace ThePlayer
{
    partial class Audiofilepoolmanager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lsvAudiofilepools = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ordnerHinzufügenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHint = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markiertenOrdnerUmbenennenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvAudiofilepools
            // 
            this.lsvAudiofilepools.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvAudiofilepools.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvAudiofilepools.Location = new System.Drawing.Point(12, 12);
            this.lsvAudiofilepools.Name = "lsvAudiofilepools";
            this.lsvAudiofilepools.Size = new System.Drawing.Size(620, 395);
            this.lsvAudiofilepools.TabIndex = 0;
            this.lsvAudiofilepools.UseCompatibleStateImageBehavior = false;
            this.lsvAudiofilepools.View = System.Windows.Forms.View.Details;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ordnerHinzufügenToolStripMenuItem,
            this.markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem,
            this.markiertenOrdnerUmbenennenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(306, 92);
            // 
            // ordnerHinzufügenToolStripMenuItem
            // 
            this.ordnerHinzufügenToolStripMenuItem.Name = "ordnerHinzufügenToolStripMenuItem";
            this.ordnerHinzufügenToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.ordnerHinzufügenToolStripMenuItem.Text = "Ordner hinzufügen";
            this.ordnerHinzufügenToolStripMenuItem.Click += new System.EventHandler(this.ordnerHinzufügenToolStripMenuItem_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.BackColor = System.Drawing.Color.Transparent;
            this.lblHint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblHint.Location = new System.Drawing.Point(37, 45);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(203, 13);
            this.lblHint.TabIndex = 1;
            this.lblHint.Text = "Rechtsklicken, um Einträge hinzuzufügen";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Dateisammlung";
            this.columnHeader1.Width = 183;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pfad";
            this.columnHeader2.Width = 433;
            // 
            // markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem
            // 
            this.markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem.Name = "markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem";
            this.markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem.Text = "Markierte Ordner aus der Bibliothek löschen";
            this.markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem.Click += new System.EventHandler(this.markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem_Click);
            // 
            // markiertenOrdnerUmbenennenToolStripMenuItem
            // 
            this.markiertenOrdnerUmbenennenToolStripMenuItem.Name = "markiertenOrdnerUmbenennenToolStripMenuItem";
            this.markiertenOrdnerUmbenennenToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.markiertenOrdnerUmbenennenToolStripMenuItem.Text = "Markierten Ordner umbenennen";
            // 
            // Audiofilepoolmanager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 419);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lsvAudiofilepools);
            this.Name = "Audiofilepoolmanager";
            this.Text = "Audiofilepoolmanager";
            this.Load += new System.EventHandler(this.Audiofilepoolmanager_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvAudiofilepools;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ordnerHinzufügenToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem markierteOrdnerAusDerBibliothekLöschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem markiertenOrdnerUmbenennenToolStripMenuItem;
    }
}