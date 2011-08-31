using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags.ID3;
using Tags.ID3.ID3v2Frames.BinaryFrames;
using System.IO;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a control to view and edit Music CD Identifier of ID3Info
    /// </summary>
    [ToolboxItem(true), ToolboxBitmap(typeof(MusicCDIdentifier), "Keys.bmp")]
    public partial class MusicCDIdentifier : ID3UserControl
    {
        /// <summary>
        /// Create new Music CD Identifier control
        /// </summary>
        public MusicCDIdentifier()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            txtData.Clear();
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(Tags.ID3.ID3Info Data)
        {
            if (Data.ID3v2Info.MusicCDIdentifier != null)
                txtData.Data = Data.ID3v2Info.MusicCDIdentifier.Data.ToArray();
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            byte[] Buf = txtData.Data;
            if (Buf != null)
                SData.ID3v2Info.MusicCDIdentifier = new BinaryFrame("MCDI",
                    new FrameFlags(), new MemoryStream(Buf));
            else
                SData.ID3v2Info.MusicCDIdentifier = null;
        }
    }
}
