using System;
using System.Collections.Generic;
using System.Text;
using ID3.ID3v2Frames;
using System.IO;

/*
 * This namespace contain Frames that is usefull for sending and recieving
 * mpeg files over streams. ex listening to audio from internet
 */
namespace Tags.ID3.ID3v2Frames.StreamFrames
{
    /// <summary>
    /// A class for PositionSynchronised frame
    /// </summary>
    public class PositionSynchronisedFrame : Frame
    {
        private TimeStamps _TimeStamp;
        private long _Position;

        /// <summary>
        /// Create new PositionSynchronisedFrame
        /// </summary>
        /// <param name="FrameID">FrameID for this frame</param>
        /// <param name="Flags">Frame Flags</param>
        /// <param name="Data">TagStream to read data from</param>
        /// <param name="Length">Maximum available length for this frame</param>
        public PositionSynchronisedFrame(string FrameID, FrameFlags Flags, TagStream Data, int Length)
            : base(FrameID, Flags)
        {
            _TimeStamp = (TimeStamps)Data.ReadByte();
            if (!IsValidEnumValue(_TimeStamp, ExceptionLevels.Error, FrameID))
                return;

            Length--;

            byte[] Long = new byte[8];
            byte[] Buf = new byte[Length];

            Data.Read(Buf, 0, Length);
            Buf.CopyTo(Long, 8 - Buf.Length);
            Array.Reverse(Long);
            _Position = BitConverter.ToInt64(Long, 0);
        }

        /// <summary>
        /// create new PositionSynchronised frame
        /// </summary>
        /// <param name="Flags">Flags of frame</param>
        /// <param name="TimeStamp">TimeStamp to use for frame</param>
        /// <param name="Position">Position of frame</param>
        public PositionSynchronisedFrame(FrameFlags Flags, TimeStamps TimeStamp,
            long Position)
            : base("POSS", Flags)
        {
            this.TimeStamp = TimeStamp;
            _Position = Position;
        }

        /// <summary>
        /// Gets or sets current frame TimeStamp
        /// </summary>
        public TimeStamps TimeStamp
        {
            get
            { return _TimeStamp; }
            set
            {
                if (!Enum.IsDefined(typeof(TimeStamps), value))
                    throw (new ArgumentException("This is not valid value for TimeStamp"));

                _TimeStamp = value;
            }
        }

        /// <summary>
        /// Gets or sets current frame Position
        /// </summary>
        public long Position
        {
            get
            { return _Position; }
            set
            { _Position = value; }
        }

        #region -> Override Method and properties <-

        /// <summary>
        /// Indicate if current frame data is valid
        /// </summary>
        protected override bool OnValidating()
        {
            return true;
        }

        /// <summary>
        /// Writing Data to specific TagStream
        /// </summary>
        protected override void OnWritingData(TagStream tg, int MinorVersion)
        {
            tg.WriteByte((byte)_TimeStamp);

            byte[] Buf;
            Buf = BitConverter.GetBytes(_Position);
            Array.Reverse(Buf);
            tg.Write(Buf, 0, 8);
        }

        /// <summary>
        /// Gets lenght of current frame
        /// </summary>
        /// <returns>int contains current frame length</returns>
        protected override int OnGetLength()
        {
            return 9;
        }

        #endregion
    }

    /// <summary>
    /// A class for RecomendedBufferSize Frame
    /// </summary>
    public class RecomendedBufferSizeFrame : Frame
    {
        private uint _BufferSize;
        private bool _EmbededInfoFlag;
        private uint _OffsetToNextTag;

        /// <summary>
        /// Create new RecomendedBufferSize
        /// </summary>
        /// <param name="FrameID">Characters tag identifier</param>
        /// <param name="Flags">2 Bytes flags identifier</param>
        /// <param name="Data">Contain Data for this frame</param>
        /// <param name="Length">Length to read from FileStream</param>
        public RecomendedBufferSizeFrame(string FrameID, FrameFlags Flags, TagStream Data, int Length)
            : base(FrameID, Flags)
        {
            _BufferSize = Data.ReadUInt(3);
            _EmbededInfoFlag = Convert.ToBoolean(Data.ReadByte());

            if (Length > 4)
                _OffsetToNextTag = Data.ReadUInt(4);
        }

        /// <summary>
        /// Create new RecomendedBufferSize
        /// </summary>
        /// <param name="Flags">Flags of frame</param>
        /// <param name="BufferSize">Recommended Buffer size</param>
        /// <param name="EmbededInfoFlag">EmbededInfoFlag</param>
        /// <param name="OffsetToNextTag">Offset to next tag</param>
        public RecomendedBufferSizeFrame(FrameFlags Flags, uint BufferSize,
            bool EmbededInfoFlag, uint OffsetToNextTag)
            : base("RBUF", Flags)
        {
            _BufferSize = BufferSize;
            _EmbededInfoFlag = EmbededInfoFlag;
            _OffsetToNextTag = OffsetToNextTag;
        }

        /// <summary>
        /// Gets or Sets Buffer size for current frame
        /// </summary>
        public uint BufferSize
        {
            get
            {
                return _BufferSize;
            }
            set
            {
                if (value > 0xFFFFFF)
                    throw (new ArgumentException("Buffer size can't be greater 16,777,215(0xFFFFFF)"));

                _BufferSize = value;
            }
        }

        /// <summary>
        /// Gets or Sets current frame EmbeddedInfoFlag
        /// </summary>
        public bool EmbededInfoFlag
        {
            get { return _EmbededInfoFlag; }
            set { _EmbededInfoFlag = value; }
        }

        /// <summary>
        /// Gets or Sets Offset to next tag
        /// </summary>
        public uint OffsetToNextTag
        {
            get
            {
                return _OffsetToNextTag;
            }
            set
            {
                _OffsetToNextTag = value;
            }
        }

        #region -> Override Method and properties <-

        /// <summary>
        /// Gets length of current frame
        /// </summary>
        /// <returns>int contains length of current frame</returns>
        protected override int OnGetLength()
        {
            // 3: Buffer Size
            // 1: Info Flag
            // 4: Offset to next tag (if available)
            return 4 + (_OffsetToNextTag > 0 ? 4 : 0);
        }

        /// <summary>
        /// Writing Data to specific TagStream
        /// </summary>
        protected override void OnWritingData(TagStream tg, int MinorVersion)
        {
            byte[] Buf;
            int Len = Length;

            Buf = BitConverter.GetBytes(_BufferSize);
            Array.Reverse(Buf);
            tg.Write(Buf, 0, Buf.Length);

            tg.WriteByte(Convert.ToByte(_EmbededInfoFlag));

            if (_OffsetToNextTag > 0)
            {
                Buf = BitConverter.GetBytes(_OffsetToNextTag);
                Array.Reverse(Buf);
                tg.Write(Buf, 0, Buf.Length);
            }
        }

        /// <summary>
        /// Indicate if current frame data is valid
        /// </summary>
        protected override bool OnValidating()
        {
            if (_BufferSize != 0)
                return true;
            else
                return false;
        }

        #endregion
    }
}
