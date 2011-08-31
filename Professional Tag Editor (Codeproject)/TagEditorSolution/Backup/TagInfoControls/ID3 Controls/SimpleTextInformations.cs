using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags.ID3;

namespace TagInfoControls
{
    /// <summary>
    /// Control for usual text information of ID3s
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(TextBox))]
    public partial class SimpleTextInformation : ID3UserControl
    {
        /// <summary>
        /// Create new SimpleTextInformation box
        /// </summary>
        public SimpleTextInformation()
        {
            InitializeComponent();
            ID3Version = ID3Versions.ID3v2;
        }

        private ID3Versions _ID3Ver;
        /// <summary>
        /// ID3 Version to use for UI
        /// </summary>
        [DefaultValue(ID3Versions.ID3v2), Category("Appearance"), Description("ID3 Version to use for UI")]
        public ID3Versions ID3Version
        {
            get { return _ID3Ver; }
            set
            {
                if (value == _ID3Ver)
                    return;

                _ID3Ver = value;

                bool Vis = !(value == ID3Versions.ID3v1);
                lblSet.Visible = Vis;
                txtSet.Visible = Vis;
                cmbGenre.ID3Version = value;

                if (Vis)
                {
                    txtTitle.MaxLength = 32767;
                    txtArtist.MaxLength = 32767;
                    txtAlbum.MaxLength = 32767;
                    txtYear.MaxLength = 32767;
                    lblComment.Text = "Encoded:";
                    tlpMain.SetToolTip(txtComment, "Indicate whom encoded this song");
                }
                else
                {
                    txtTitle.MaxLength = 30;
                    txtArtist.MaxLength = 30;
                    txtAlbum.MaxLength = 30;
                    txtYear.MaxLength = 4;
                    lblComment.Text = "Comment:";
                    tlpMain.SetToolTip(txtComment, "Comment");
                }

                if (EditMode != EditModes.Unknown)
                {
                    Clear();
                    if (EditMode == EditModes.Single)
                        OnSingleSet(SData);
                    else
                        OnMultipleSet(MData);
                }
            }
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(ID3Info Data)
        {
            if (DesignMode || Data == null)
                return;

            if (ID3Version == ID3Versions.ID3v1)
            {
                if (!Data.ID3v1Info.HaveTag)
                    return;

                txtTrack.Text = (Data.ID3v1Info.TrackNumber != 0) ? Data.ID3v1Info.TrackNumber.ToString() : "";
                txtTitle.Text = Data.ID3v1Info.Title;
                txtArtist.Text = Data.ID3v1Info.Artist;
                txtAlbum.Text = Data.ID3v1Info.Album;
                txtYear.Text = Data.ID3v1Info.Year;
                cmbGenre.GenreIndex = Data.ID3v1Info.Genre;
                txtComment.Text = Data.ID3v1Info.Comment;
                txtYear.Enabled = true;
            }
            else
            {
                if (!Data.ID3v2Info.HaveTag)
                    return;

                txtTrack.Text = Data.ID3v2Info.GetTextFrame("TRCK");
                txtTitle.Text = Data.ID3v2Info.GetTextFrame("TIT2");
                txtArtist.Text = Data.ID3v2Info.GetTextFrame("TPE1");
                txtAlbum.Text = Data.ID3v2Info.GetTextFrame("TALB");
                if (Data.ID3v2Info.Version.Minor < 4)
                    txtYear.Text = Data.ID3v2Info.GetTextFrame("TYER");
                else
                {
                    txtYear.Enabled = false;
                    erpWarning.SetError(txtYear, "The selected file have ID3v2.4.\nThis version of ID3 contain Recording time instead of year.");
                }
                cmbGenre.Genre = Data.ID3v2Info.GetTextFrame("TCON");
                txtSet.Text = Data.ID3v2Info.GetTextFrame("TPOS");
                txtComment.Text = Data.ID3v2Info.GetTextFrame("TENC");
            }
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            if (DesignMode)
                return;

            if (ID3Version == ID3Versions.ID3v1)
            {
                SData.ID3v1Info.TrackNumber = (txtTrack.Text.Trim() == "") ? (byte)0 : Byte.Parse(txtTrack.Text.Trim());
                SData.ID3v1Info.Album = txtAlbum.Text.Trim();
                SData.ID3v1Info.Artist = txtArtist.Text.Trim();
                SData.ID3v1Info.Genre = (byte)cmbGenre.GenreIndex;
                SData.ID3v1Info.Title = txtTitle.Text.Trim();
                SData.ID3v1Info.Year = txtYear.Text.Trim();
                SData.ID3v1Info.Comment = txtComment.Text.Trim();
            }
            else
            {
                SData.ID3v2Info.SetTextFrame("TIT2", txtTitle.Text.Trim());
                SData.ID3v2Info.SetTextFrame("TRCK", txtTrack.Text.Trim());
                SData.ID3v2Info.SetTextFrame("TPE1", txtArtist.Text.Trim());
                SData.ID3v2Info.SetTextFrame("TALB", txtAlbum.Text.Trim());
                if (SData.ID3v2Info.Version.Minor < 4)
                    SData.ID3v2Info.SetTextFrame("TYER", txtYear.Text.Trim());
                SData.ID3v2Info.SetTextFrame("TCON", cmbGenre.Genre);
                SData.ID3v2Info.SetTextFrame("TPOS", txtSet.Text.Trim());
                SData.ID3v2Info.SetTextFrame("TENC", txtComment.Text.Trim());
            }
        }

        /// <summary>
        /// Show data of multiple tags
        /// </summary>
        protected override void OnMultipleSet(ID3Info[] Data)
        {
            if (ID3Version == ID3Versions.ID3v1)
            {
                StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ID3v1Info", "TrackNumber"), txtTrack, (Data[0].ID3v1Info.TrackNumber == 0) ? "" : Data[0].ID3v1Info.TrackNumber.ToString(), ConflictColor);
                StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ID3v1Info", "Artist"), txtArtist, Data[0].ID3v1Info.Artist, ConflictColor);
                StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ID3v1Info", "Album"), txtAlbum, Data[0].ID3v1Info.Album, ConflictColor);
                StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ID3v1Info", "Comment"), txtComment, Data[0].ID3v1Info.Comment, ConflictColor);
                StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ID3v1Info", "Title"), txtTitle, Data[0].ID3v1Info.Title, ConflictColor);
                StaticMethods.SetTextBox(sEquality.IsPropertyEqual(Data, "ID3v1Info", "Year"), txtYear, Data[0].ID3v1Info.Year, ConflictColor);
                if (sEquality.IsPropertyEqual(Data, "ID3v1Info", "Genre"))
                    cmbGenre.GenreIndex = Data[0].ID3v1Info.Genre;
            }
            else
            {
                if (!sEquality.IsPropertyEqual(Data, "ID3v2Info", "Version", "Minor"))
                    erpWarning.SetError(txtYear, "Selected files have diffrent ID3v2 versions for ID3v2.4 this property will not set");
                StaticMethods.SetTextBox(sEquality.TextFrame(Data, "TPOS"), txtSet, Data[0].ID3v2Info.GetTextFrame("TPOS"), ConflictColor);
                StaticMethods.SetTextBox(sEquality.TextFrame(Data, "TIT2"), txtTitle, Data[0].ID3v2Info.GetTextFrame("TIT2"), ConflictColor);
                StaticMethods.SetTextBox(sEquality.TextFrame(Data, "TRCK"), txtTrack, Data[0].ID3v2Info.GetTextFrame("TRCK"), ConflictColor);
                StaticMethods.SetTextBox(sEquality.TextFrame(Data, "TPE1"), txtArtist, Data[0].ID3v2Info.GetTextFrame("TPE1"), ConflictColor);
                StaticMethods.SetTextBox(sEquality.TextFrame(Data, "TALB"), txtAlbum, Data[0].ID3v2Info.GetTextFrame("TALB"), ConflictColor);
                StaticMethods.SetTextBox(sEquality.TextFrame(Data, "TYER"), txtYear, Data[0].ID3v2Info.GetTextFrame("TYER"), ConflictColor);
                StaticMethods.SetTextBox(sEquality.TextFrame(Data, "TCON"), cmbGenre, Data[0].ID3v2Info.GetTextFrame("TCON"), ConflictColor);
                StaticMethods.SetTextBox(sEquality.TextFrame(Data, "TYER"), txtYear, Data[0].ID3v2Info.GetTextFrame("TYER"), ConflictColor);
                StaticMethods.SetTextBox(sEquality.TextFrame(Data, "TENC"), txtComment, Data[0].ID3v2Info.GetTextFrame("TENC"), ConflictColor);
            }
        }

        /// <summary>
        /// Collect data as multi tag
        /// </summary>
        protected override void OnCollectMultiple(ID3Info Data)
        {
            if (ID3Version == ID3Versions.ID3v2)
            {
                GetTextBox(txtTrack, "TRCK", Data);
                GetTextBox(txtTitle, "TIT2", Data);
                GetTextBox(txtArtist, "TPE1", Data);
                GetTextBox(txtAlbum, "TALB", Data);
                GetTextBox(txtYear, "TYER", Data);
                if (cmbGenre.Text.Length != 0)
                    Data.ID3v2Info.SetTextFrame("TCON", cmbGenre.Text.Trim());
                GetTextBox(txtSet, "TPOS", Data);
                GetTextBox(txtComment, "TENC", Data);
            }
            else
            {
                if (txtTrack.Text.Length != 0)
                    Data.ID3v1Info.TrackNumber = Byte.Parse(txtTrack.Text);
                if (txtTitle.Text.Length != 0)
                    Data.ID3v1Info.Title = txtTitle.Text.Trim();
                if (txtArtist.Text.Length != 0)
                    Data.ID3v1Info.Artist = txtArtist.Text.Trim();
                if (txtAlbum.Text.Length != 0)
                    Data.ID3v1Info.Album = txtAlbum.Text.Trim();
                if (txtYear.Text.Length != 0)
                    Data.ID3v1Info.Year = txtYear.Text.Trim();
                if (txtComment.Text.Length != 0)
                    Data.ID3v1Info.Comment = txtComment.Text.Trim(); ;
                if (cmbGenre.GenreIndex != 255)
                    Data.ID3v1Info.Genre = (byte)cmbGenre.GenreIndex;
            }
        }

        /// <summary>
        /// Set text of specific TextBox to specific ID3Info
        /// </summary>
        /// <param name="Ctrl">Control to use value</param>
        /// <param name="FrameID">FrameID of frame</param>
        /// <param name="Data">ID3Info to set text for</param>
        private void GetTextBox(TextBox Ctrl, string FrameID, ID3Info Data)
        {
            if (Ctrl.Text.Length != 0)
                Data.ID3v2Info.SetTextFrame(FrameID, Ctrl.Text.Trim());
        }

        private void txtTrack_Validating(object sender, CancelEventArgs e)
        {
            if (txtTrack.Text == "")
                return;

            byte Buf;
            if (ID3Version == ID3Versions.ID3v1 && !byte.TryParse(txtTrack.Text, out Buf))
            {
                MessageBox.Show("Track Number in ID3v1 must be a number from 1 to 255", "Track Number",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            txtTrack.Text = "";
            txtTrack.BackColor = SystemColors.Window;

            txtTitle.Text = "";
            txtTitle.BackColor = SystemColors.Window;

            txtAlbum.Text = "";
            txtAlbum.BackColor = SystemColors.Window;

            txtArtist.Text = "";
            txtArtist.BackColor = SystemColors.Window;

            txtSet.Text = "";
            txtSet.BackColor = SystemColors.Window;

            txtYear.Text = "";
            txtYear.BackColor = SystemColors.Window;

            cmbGenre.Genre = "";
            cmbGenre.BackColor = SystemColors.Window;

            txtComment.Text = "";
            txtComment.BackColor = SystemColors.Window;

            erpWarning.SetError(txtYear, "");
            txtYear.Enabled = true;
        }
    }
}
