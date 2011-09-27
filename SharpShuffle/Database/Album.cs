using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle.Database
{
    public class CAlbum : Dataset
    {
        public const string META_YEAR = "Year";
        public const string META_ALBUMARTISTS = "AlbumArtists";
        public const string META_NAME = "Name";

        public CAlbum()
        {
            _allTheInformation = new Dictionary<string, string>();
            _allTheInformation[META_NAME] = "";
            _allTheInformation[META_ALBUMARTISTS] = "";
            _allTheInformation[META_YEAR] = "";
        }
    }
}
