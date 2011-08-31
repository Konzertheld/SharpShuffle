namespace TagInfoControls
{
    partial class Lyric
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlLyricEditor = new TagInfoControls.SmallControls.SLyricEditor();
            this.lsbLyrics = new TagInfoControls.SmallControls.FrameList();
            this.grpSelected = new System.Windows.Forms.GroupBox();
            this.grpSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLyricEditor
            // 
            this.ctrlLyricEditor.FilePath = "";
            this.ctrlLyricEditor.Location = new System.Drawing.Point(6, 19);
            this.ctrlLyricEditor.Lyric = null;
            this.ctrlLyricEditor.Name = "ctrlLyricEditor";
            this.ctrlLyricEditor.Size = new System.Drawing.Size(363, 285);
            this.ctrlLyricEditor.TabIndex = 0;
            this.ctrlLyricEditor.TextWithLanguageValue = null;
            this.ctrlLyricEditor.ValidatingDescription += new System.ComponentModel.CancelEventHandler(this.ctrlLyricEditor_ValidatingDescription);
            this.ctrlLyricEditor.DataUpdated += new System.EventHandler(this.ctrlLyricEditor_DataUpdated);
            // 
            // lsbLyrics
            // 
            this.lsbLyrics.Location = new System.Drawing.Point(0, 0);
            this.lsbLyrics.Name = "lsbLyrics";
            this.lsbLyrics.ShowSaveButton = true;
            this.lsbLyrics.Size = new System.Drawing.Size(163, 306);
            this.lsbLyrics.TabIndex = 1;
            this.lsbLyrics.AddClicked += new System.EventHandler(this.lsbLyrics_AddClicked);
            this.lsbLyrics.SelectedIndexChanged += new System.EventHandler(this.lsbLyrics_SelectedIndexChanged);
            this.lsbLyrics.SaveClicked += new System.EventHandler(this.lsbLyrics_SaveClicked);
            // 
            // grpSelected
            // 
            this.grpSelected.Controls.Add(this.ctrlLyricEditor);
            this.grpSelected.Location = new System.Drawing.Point(169, 0);
            this.grpSelected.Name = "grpSelected";
            this.grpSelected.Size = new System.Drawing.Size(374, 306);
            this.grpSelected.TabIndex = 2;
            this.grpSelected.TabStop = false;
            this.grpSelected.Text = "Selected Lyric";
            // 
            // Lyric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSelected);
            this.Controls.Add(this.lsbLyrics);
            this.Name = "Lyric";
            this.Size = new System.Drawing.Size(546, 308);
            this.grpSelected.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TagInfoControls.SmallControls.SLyricEditor ctrlLyricEditor;
        private TagInfoControls.SmallControls.FrameList lsbLyrics;
        private System.Windows.Forms.GroupBox grpSelected;
    }
}
