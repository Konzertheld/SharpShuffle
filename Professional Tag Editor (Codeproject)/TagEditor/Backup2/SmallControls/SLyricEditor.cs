using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ID3.ID3v2Frames.ArrayFrames;
using System.Collections;

namespace TagInfoControls.SmallControls
{
    /// <summary>
    /// Provide a control to view and edit UnSynchronized lyric of tag
    /// </summary>
    [ToolboxBitmap("../../Images\\Lyric.bmp")]
    public partial class SLyricEditor : DescriptableBox
    {
        /// <summary>
        /// Occure when control is validating
        /// </summary>
        public event CancelEventHandler ValidatingType;

        /// <summary>
        /// Creates new SLyric control
        /// </summary>
        public SLyricEditor()
        {
            InitializeComponent();
            ctrlMediaPlayer.settings.autoStart = false;
            cmbType.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets or sets syllables of current text editor
        /// </summary>
        public Syllable[] Sylables
        {
            get
            {
                ArrayList AL = new ArrayList();
                string Temp;
                uint Time;
                foreach (string st in txtText.Lines)
                {
                    if (GetTime(st, out Time, out Temp))
                    {
                        AL.Add(new Syllable(Time, Temp));
                    }
                    else
                    {
                        if (AL.Count != 0)
                            ((Syllable)AL[AL.Count - 1]).Text += "\r\n" + st;
                    }
                }
                return (Syllable[])AL.ToArray(typeof(Syllable));
            }
            set
            {
                StringBuilder StB = new StringBuilder();
                double T;
                foreach (Syllable S in value)
                {
                    T = (double)S.Time / 1000;
                    StB.AppendLine("[" + T.ToString("N1") + "]: " + S.Text);
                }
                txtText.Text = StB.ToString().Trim();
            }
        }

        private SynchronisedText _Lyric;
        /// <summary>
        /// Gets or sets Lyric value of current control
        /// </summary>
        [Browsable(false)]
        public SynchronisedText Lyric
        {
            get
            { return _Lyric; }
            set
            {
                _Lyric = value;
                if (value != null)
                {
                    this.Description = value.Text;
                    this.Language = value.Language.LanguageID;
                    this.Sylables = value.Syllables.ToArray();
                    this.cmbType.SelectedIndex = (int)value.ContentType;
                }
            }
        }

        private bool GetTime(string st, out uint Time, out string Text)
        {
            if (st.Length > 4 && st[0] == '[')
            {
                int TimeEnd;
                uint iTime;
                double dTime;
                TimeEnd = st.IndexOf(']');
                if (TimeEnd != -1)
                {
                    if (double.TryParse(st.Substring(1, TimeEnd - 1), out dTime))
                    {
                        iTime = Convert.ToUInt32(dTime * 1000);
                        Time = iTime;
                        Text = st.Substring(TimeEnd + 3, st.Length - TimeEnd - 3);
                        return true;
                    }
                }
            }
            Time = 0;
            Text = "";
            return false;
        }

        /// <summary>
        /// Gets or sets path of file
        /// </summary>
        public string FilePath
        {
            get
            { return ctrlMediaPlayer.URL; }
            set
            { ctrlMediaPlayer.URL = value; }
        }

        double _LastPos;
        private void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.P:
                        if (ctrlMediaPlayer.playState != WMPLib.WMPPlayState.wmppsPlaying)
                            ctrlMediaPlayer.Ctlcontrols.play();
                        else
                            ctrlMediaPlayer.Ctlcontrols.pause();
                        break;
                    case Keys.T:
                        string Temp = "[" + ctrlMediaPlayer.Ctlcontrols.currentPosition.ToString("N1") + "]: ";
                        int Pos = txtText.SelectionStart;
                        txtText.Text = txtText.Text.Insert(txtText.SelectionStart,
                            Temp);

                        txtText.SelectionStart = Pos + Temp.Length;
                        txtText.ScrollToCaret();
                        _LastPos = ctrlMediaPlayer.Ctlcontrols.currentPosition;
                        break;
                    case Keys.Oemplus:
                        ctrlMediaPlayer.Ctlcontrols.currentPosition += 0.5;
                        break;
                    case Keys.OemMinus:
                        ctrlMediaPlayer.Ctlcontrols.currentPosition -= 0.5;
                        break;
                    case Keys.L:
                        ctrlMediaPlayer.Ctlcontrols.currentPosition = _LastPos;
                        break;
                    case Keys.OemPeriod:
                        ctrlMediaPlayer.Ctlcontrols.currentPosition += 2;
                        break;
                    case Keys.Oemcomma:
                        ctrlMediaPlayer.Ctlcontrols.currentPosition -= 2;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets selected text type
        /// </summary>
        [Description("Text type"), DefaultValue(SynchronisedText.ContentTypes.Other), Browsable(true)]
        public Tags.ID3.ID3v2Frames.ArrayFrames.SynchronisedText.ContentTypes Type
        {
            get
            { return (SynchronisedText.ContentTypes)cmbType.SelectedIndex; }
            set
            { cmbType.SelectedIndex = (int)value; }
        }

        private void SLyricEditor_EnabledChanged(object sender, EventArgs e)
        {
            if (!this.Enabled && ctrlMediaPlayer.currentMedia != null)
                ctrlMediaPlayer.Ctlcontrols.stop();
        }

        /// <summary>
        /// Clear all fields of current control
        /// </summary>
        public override void Clear()
        {
            cmbType.SelectedIndex = 0;
            base.Clear();
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            if (Lyric != null)
            {
                Lyric.Text = Description;
                OnDataUpdated(e);
            }
        }

        private void lnbLanguage_Validated(object sender, EventArgs e)
        {
            if (Lyric != null)
            {
                Lyric.Language = new Tags.ID3.ID3v2Frames.Language(this.Language);
                OnDataUpdated(e);
            }
        }

        private void cmbType_Validated(object sender, EventArgs e)
        {
            if (Lyric != null)
                Lyric.ContentType = (SynchronisedText.ContentTypes)cmbType.SelectedIndex;
        }

        private void txtText_Validated(object sender, EventArgs e)
        {
            if (Lyric != null)
            {
                Lyric.Syllables.Clear();
                foreach (Syllable S in this.Sylables)
                    Lyric.Syllables.Add(S);
            }
        }

        private void cmbType_Validating(object sender, CancelEventArgs e)
        {
            if (ValidatingType != null)
                ValidatingType(this, e);
        }
    }
}