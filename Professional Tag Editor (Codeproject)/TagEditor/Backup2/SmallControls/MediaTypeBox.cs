using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace TagInfoControls
{
    /// <summary>
    /// A Box for selecting MediaTypes
    /// </summary>
    [ToolboxBitmap(typeof(ComboBox))]
    public class MediaTypeBox : ComboBox
    {
        MediaType[] _MediaTypes;
        ISubMediaType _SubMedia;

        /// <summary>
        /// Create new MediaTypeBox
        /// </summary>
        public MediaTypeBox()
        {
            InitilizeMediaTypes();
            base.DataSource = _MediaTypes;
            base.DisplayMember = "Name";
            base.ValueMember = "Value";
            this.SelectedText = "";
        }

        private void InitilizeMediaTypes()
        {
            _MediaTypes = new MediaType[16];
            _MediaTypes[0] = new MediaType("", "");
            _MediaTypes[1] = new MediaType("Other Digital Media", "DIG",
                new MediaType("", ""),
                new MediaType("Analog Transfer From Media", "/A"));
            _MediaTypes[2] = new MediaType("Other Analog Media", "ANA",
                new MediaType("", ""),
                new MediaType("Wax Cylynder", "/WAX"),
                new MediaType("8-Track Tape Cassete", "/8CA"));
            _MediaTypes[3] = new MediaType("CD", "CD",
                new MediaType("", ""),
                new MediaType("Analog Transfer From Media", "/A"),
                new MediaType("DDD", "/DD"),
                new MediaType("ADD", "/AD"),
                new MediaType("AAD", "/AA"));
            _MediaTypes[4] = new MediaType("Laser Disc", "LD",
                new MediaType("", ""),
                new MediaType("Analog Transfer From Media", "/A"));
            _MediaTypes[5] = new MediaType("Turnable Records", "TT",
                new MediaType("", ""),
                new MediaType("33.33 rpm", "/33"),
                new MediaType("45 rpm", "/45"),
                new MediaType("71.29 rpm", "/71"),
                new MediaType("76.59 rpm", "/76"),
                new MediaType("78.26 rpm", "/78"),
                new MediaType("80 rpm", "/80"));
            _MediaTypes[6] = new MediaType("Mini Disc", "MD",
                new MediaType("", ""),
                new MediaType("Analog Transfer From Media", "/A"));
            _MediaTypes[7] = new MediaType("DAT", "DAT",
                new MediaType("", ""),
                new MediaType("Analog Transfer From Media", "/A"),
                new MediaType("Standard, 48 kHz/16 bits, linear", "/1"),
                new MediaType("Mode 2, 32 kHz/16 bits, linear", "/2"),
                new MediaType("Mode 3, 32 kHz/12 bits, nonlinear, low speed", "/3"),
                new MediaType("Mode 4, 32 kHz/12 bits, 4 Channel", "/4"),
                new MediaType("Mode 5, 44.1 kHz/16 bits, linear", "/5"),
                new MediaType("Mode 6, 44.1 kHz/16 bits, 'Wide Track' Play", "/6"));
            _MediaTypes[8] = new MediaType("DCC", "DCC",
                new MediaType("", ""),
                new MediaType("Analog Transfer From Media", "/A"));
            _MediaTypes[9] = new MediaType("DVD", "DVD",
                new MediaType("", ""),
                new MediaType("Analog Transfer From Media", "/A"));
            _MediaTypes[10] = new MediaType("Television", "TV",
                new MediaType("", ""),
                new MediaType("PAL", "/PAL"),
                new MediaType("NTSC", "/NTSC"),
                new MediaType("SECAM", "/SECAM"));
            _MediaTypes[11] = new MediaType("Video", "VID",
                new MediaType("", ""),
                new MediaType("PAL", "/PAL"),
                new MediaType("NTSC", "/NTSC"),
                new MediaType("SECAM", "/SECAM"),
                new MediaType("VHS", "/VHS"),
                new MediaType("S-VHS", "/SVHS"),
                new MediaType("BetaMax", "/BETA"));
            _MediaTypes[12] = new MediaType("Radio", "RAD",
                new MediaType("", ""),
                new MediaType("FM", "/FM"),
                new MediaType("AM", "/AM"),
                new MediaType("LW", "/LW"),
                new MediaType("MW", "/MW"));
            _MediaTypes[13] = new MediaType("Telephone", "TEL",
                new MediaType("", ""),
                new MediaType("ISDN", "/I"));
            _MediaTypes[14] = new MediaType("MC(Normal Cassete)", "MC",
                new MediaType("", ""),
                new MediaType("4.75 cm/s (Normal Speed For A Two Sided Cassette)", "/4"),
                new MediaType("9.5 cm/s", "/9"),
                new MediaType("Type I Cassette (Ferric/Normal)", "/I"),
                new MediaType("Type II Cassette (Chrome)", "/II"),
                new MediaType("Type III Cassette (Ferric Chrome)", "/III"),
                new MediaType("Type IV Cassette (Metal)", "/IV"));
            _MediaTypes[15] = new MediaType("Reel", "REE",
                new MediaType("", ""),
                new MediaType("9.5 cm/s", "/9"),
                new MediaType("19 cm/s", "/19"),
                new MediaType("38 cm/s", "/38"),
                new MediaType("76 cm/s", "76"),
                new MediaType("Type I Cassette (Ferric/Normal)", "/I"),
                new MediaType("Type II Cassette (Chrome)", "/II"),
                new MediaType("Type III Cassette (Ferric Chrome)", "/III"),
                new MediaType("Type IV Cassette (Metal)", "/IV"));
        }

        int LastIndex = -1;
        /// <summary>
        /// Occur when text of control changed
        /// </summary>
        protected override void OnTextChanged(EventArgs e)
        {
            if (this.SelectedIndex != LastIndex)
            {
                LastIndex = this.SelectedIndex;

                if (_SubMedia != null)
                {
                    if (LastIndex <= 0)
                    {
                        _SubMedia.DataSource = null;
                        _SubMedia.Enabled = false;
                    }
                    else
                    {
                        _SubMedia.Enabled = true;
                        _SubMedia.DataSource = ((MediaType)this.SelectedItem).SubTypes;
                        _SubMedia.DisplayMember = "Name";
                        _SubMedia.ValueMember = "Value";
                    }
                }
            }

            base.OnTextChanged(e);
        }

        /// <summary>
        /// Just for hiding inherited item from ComboBox
        /// </summary>
        [Browsable(false)]
        public new string Items
        {
            get
            { return ""; }
        }

        /// <summary>
        /// Just for hiding inherited item from ComboBox
        /// </summary>
        [Browsable(false)]
        public new string DataSource
        {
            get
            { return ""; }
        }

        /// <summary>
        /// Just for hiding inherited item from ComboBox
        /// </summary>
        [Browsable(false)]
        public new string DisplayMember
        {
            get
            { return ""; }
        }

        /// <summary>
        /// Just for hiding inherited item from ComboBox
        /// </summary>
        [Browsable(false)]
        public new string ValueMember
        {
            get
            { return ""; }
        }

        /// <summary>
        /// SubMediaBox class to hold submedia types
        /// </summary>
        [Description("SubMediaBox to set it's data automatically")]
        public ISubMediaType SubMediaBox
        {
            get
            { return _SubMedia; }
            set
            { _SubMedia = value; }
        }

        /// <summary>
        /// MediaType of current MediaTypeBox
        /// </summary>
        [DefaultValue("")]
        public string MediaType
        {
            get
            {
                if (this.SelectedIndex == -1 || _SubMedia == null || !_SubMedia.Enabled)
                    return this.Text;

                return (_SubMedia.SelectedIndex <= 0) ? this.SelectedValue.ToString() :
                    this.SelectedValue.ToString() + _SubMedia.SelectedValue.ToString();
            }
            set
            {
                if (value == null)
                    throw new ArgumentException("MediaType cannot set to null");

                string[] Buf = value.Split('/');
                this.SelectedValue = Buf[0];

                if (_SubMedia != null && _SubMedia.Enabled && Buf.Length > 1)
                    _SubMedia.SelectedValue = "/" + Buf[1];
            }
        }
    }

    /// <summary>
    /// Provide a class for submedia types to use with MediaTypeBox
    /// </summary>
    [ToolboxBitmap(typeof(ComboBox))]
    public class SubMediaTypeBox : ComboBox, ISubMediaType
    {
        /// <summary>
        /// Create new SubMediaTypeBox
        /// </summary>
        public SubMediaTypeBox()
        {
            base.DropDownStyle = ComboBoxStyle.DropDownList;
            base.Enabled = false;
        }

        /// <summary>
        /// Array of mediatypes to show
        /// </summary>
        [Browsable(false)]
        public new MediaType[] DataSource
        {
            get
            { return (MediaType[])base.DataSource; }
            set
            {
                base.DataSource = value;
            }
        }

        /// <summary>
        /// Just a method to hide inherited method
        /// </summary>
        [Browsable(false)]
        public new string Items
        {
            get
            { return ""; }
        }
    }

    /// <summary>
    /// Contain a media type contain Name and ID3 standard string according to name
    /// </summary>
    public class MediaType
    {
        private readonly string _Name;
        private readonly string _Value;
        private readonly MediaType[] _SubTypes;

        /// <summary>
        /// Create new MediaType
        /// </summary>
        public MediaType(string Name, string Value, params MediaType[] SubTypes)
        {
            _Name = Name;
            _SubTypes = SubTypes;
            _Value = Value;
        }

        /// <summary>
        /// MediaType[] Contains subtypes of current Type
        /// </summary>
        public MediaType[] SubTypes
        {
            get { return _SubTypes; }
        }

        /// <summary>
        /// Name of MediaType
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }

        /// <summary>
        /// ID3 standard name of current MediaType
        /// </summary>
        public string Value
        {
            get { return _Value; }
        }
    }

    /// <summary>
    /// An interface for SubMediaTypeBox.
    /// </summary>
    public interface ISubMediaType
    {
        /// <summary>
        /// Gets or sets values of sub media types
        /// </summary>
        MediaType[] DataSource
        { get; set;}

        /// <summary>
        /// Gets of set if control must be enable
        /// </summary>
        bool Enabled
        { get; set;}

        /// <summary>
        /// Gets or sets display member of submedia types
        /// </summary>
        string DisplayMember
        { get; set;}

        /// <summary>
        /// Gets of sets value member of SubMediaTypes
        /// </summary>
        string ValueMember
        { get; set;}

        /// <summary>
        /// Gets or sets selected index of SubMediatype
        /// </summary>
        int SelectedIndex
        { get; set;}

        /// <summary>
        /// Get or sets value of selected item in SubMediatype
        /// </summary>
        object SelectedValue
        { get; set;}
    }
}
