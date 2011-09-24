using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    public class CAlbum : Dataset
    {
        public const string META_YEAR = "Year";
        public const string META_ARTISTS = "Artists";
        public const string META_NAME = "Name";

        public CAlbum()
        {
            _allTheInformation[META_NAME] = "";
            _allTheInformation[META_ARTISTS] = "";
            _allTheInformation[META_YEAR] = "";
        }
    }
}
