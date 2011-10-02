using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle.Database
{
    public enum ALBUMMETA
    {
        AlbumArtists,
        Name,
        TrackCount,
        Year
    }

    public class CAlbum
    {
        public uint id { get; set; }
        public string AlbumArtists { get; set; }
        public string Name { get; set; }
        public uint TrackCount { get; set; }
        public uint Year { get; set; }

        public object this[string index]
        {
            get
            {
                return this[(ALBUMMETA)Enum.Parse(typeof(ALBUMMETA), index)];
            }
            set
            {
                this[(ALBUMMETA)Enum.Parse(typeof(ALBUMMETA), index)] = value;
            }
        }
        public object this[ALBUMMETA index]
        {
            get
            {
                switch (index)
                {
                    case ALBUMMETA.AlbumArtists:
                        return this.AlbumArtists;
                    case ALBUMMETA.Name:
                        return this.Name;
                    case ALBUMMETA.TrackCount:
                        return this.TrackCount;
                    case ALBUMMETA.Year:
                        return this.Year;
                    default:
                        throw new IndexOutOfRangeException("Wow! This should never be possible! The Albummeta enum does not contain such a value. Don't pass shit to the album indexer.");
                }
            }
            set
            {
                try
                {
                    switch (index)
                    {
                        case ALBUMMETA.AlbumArtists:
                            this.AlbumArtists = (string)value;
                            break;
                        case ALBUMMETA.Name:
                            this.Name = (string)value;
                            break;
                        case ALBUMMETA.TrackCount:
                            this.TrackCount = (ushort)value;
                            break;
                        case ALBUMMETA.Year:
                            this.Year = (ushort)value;
                            break;
                    }
                }
                catch (InvalidCastException E) { }
            }
        }
    }
}
