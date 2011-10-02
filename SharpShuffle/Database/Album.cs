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
        public uint Year { get; set; }
        public string AlbumArtists { get; set; }
        public string Name { get; set; }
        public uint TrackCount { get; set; }
    }
}
