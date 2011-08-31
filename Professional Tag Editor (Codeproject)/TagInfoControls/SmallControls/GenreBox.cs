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
    /// Provide a control to view and edit Genres for both ID3v1 and ID3v2
    /// </summary>
    [ToolboxBitmap(typeof(ComboBox))]
    public class GenreBox : ComboBox
    {
        private readonly string[] _Genre = {   
            "Blues","Classic Rock","Country","Dance","Disco","Funk","Grunge","Hip-Hop",
            "Jazz","Metal","New Age","Oldies","Other","Pop","R&B","Rap","Reggae","Rock",
            "Techno","Industrial","Alternative","Ska","Death Metal","Pranks","Soundtrack",
            "Euro-Techno","Ambient","Trip-Hop","Vocal","Jazz+Funk","Fusion","Trance","Classical",
            "Instrumental","Acid","House","Game","Sound Clip","Gospel","Noise","AlternRock",
            "Bass","Soul","Punk","Space","Meditative","Instrumental Pop","Instrumental Rock",
            "Ethnic","Gothic","Darkwave","Techno-Industrial","Electronic","Pop-Folk","Eurodance",
            "Dream","Southern Rock","Comedy","Cult","Gangsta","Top 40","Christian Rap","Pop/Funk",
            "Jungle","Native American","Cabaret","New Wave","Psychadelic","Rave","Showtunes",
            "Trailer","Lo-Fi","Tribal","Acid Punk","Acid Jazz","Polka","Retro","Musical",
            "Rock & Roll","Hard Rock","" };

        /// <summary>
        /// Create new GenreBox
        /// </summary>
        public GenreBox()
        {
            if (!DesignMode)
                base.Items.AddRange(_Genre);
        }

        /// <summary>
        /// Get or set Genre String of current GenreBox
        /// </summary>
        public string Genre
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (value.Length >= 3)
                {
                    if (value[0] == '(')
                    {
                        string Temp = "";
                        Temp += value[1];
                        if (value[2] != ')')
                            Temp += value[2];
                        int Index;
                        if (Int32.TryParse(Temp, out Index) && Index >= 0 && Index < _Genre.Length)
                            base.Text = _Genre[Index];
                        else
                            base.Text = value;
                        return;
                    }
                }

                base.Text = value;
            }
        }

        /// <summary>
        /// Get or Set ID3v1 GenreIndex
        /// </summary>
        public int GenreIndex
        {
            get
            {
                for (int i = 0; i < _Genre.Length - 2; i++)
                    if (base.Text == _Genre[i])
                        return i;

                return 255;
            }
            set
            {
                if (value < 127)
                    base.Text = _Genre[value];
                else
                    base.Text = "";
            }
        }

        /// <summary>
        /// Gets or sets ID3 version for current GenreBox
        /// </summary>
        [DefaultValue(ID3Versions.ID3v2)]
        public ID3Versions ID3Version
        {
            get
            {
                if (this.DropDownStyle == ComboBoxStyle.DropDownList)
                    return ID3Versions.ID3v1;
                else
                    return ID3Versions.ID3v2;
            }
            set
            {
                if (value == ID3Versions.ID3v2)
                    this.DropDownStyle = ComboBoxStyle.DropDown;
                else
                    this.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        /// <summary>
        /// Items of current GenreBox
        /// </summary>
        public new string[] Items
        {
            get
            { return _Genre; }
        }

        /// <summary>
        /// Gets or sets Genre of current box
        /// </summary>
        public new string Text
        {
            get
            { return Genre; }
            set
            { Genre = value; }
        }
    }
}
