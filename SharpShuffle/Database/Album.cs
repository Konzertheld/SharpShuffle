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
                if (index == ALBUMMETA.AlbumArtists)
                    return this.AlbumArtists;
                else if (index == ALBUMMETA.Name)
                    return this.Name;
                else if (index == ALBUMMETA.TrackCount)
                    return this.TrackCount;
                else if (index == ALBUMMETA.Year)
                    return this.Year;
                else
                    throw new IndexOutOfRangeException("Wow! This should never be possible! The Albummeta enum does not contain such a value. Don't pass shit to the album indexer.");
            }
            set
            {
                if (index == ALBUMMETA.AlbumArtists)
                    this.AlbumArtists = (string)value;
                else if (index == ALBUMMETA.Name)
                    this.Name = (string)value;
                else if (index == ALBUMMETA.TrackCount)
                    this.TrackCount = Convert.ToUInt16(value);
                else if (index == ALBUMMETA.Year)
                    this.Year = Convert.ToUInt16(value);
                else
                    throw new IndexOutOfRangeException("Wow! This should never be possible! The Albummeta enum does not contain such a value. Don't pass shit to the album indexer.");
            }
        }
    }
}
