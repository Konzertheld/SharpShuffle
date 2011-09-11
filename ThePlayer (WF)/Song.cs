using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    [Serializable]
    public class Song
    {
        private Dictionary<string, string> _allTheInformation;
        public int id { get; private set; }

        #region Constants
        public const string META_ALBUM = "Album";
        public const string META_ALBUMARTISTS = "AlbumArtists";
        public const string META_AMAZON = "AmazonID";
        public const string META_ARTISTS = "Artists";
        public const string META_COMMENT = "Comment";
        public const string META_COMPOSERS = "Composers";
        public const string META_CONDUCTOR = "Conductor";
        public const string META_COPYRIGHT = "Copyright";
        public const string META_BPM = "BPM";
        public const string META_DISC = "Disc";
        public const string META_DISCCOUNT = "DiscCount";
        public const string META_GENRES = "Genres";
        public const string META_LYRICS = "Lyrics";
        public const string META_TITLE = "Title";
        public const string META_TRACK = "TrackNr";
        public const string META_TRACKCOUNT = "TrackCount";
        public const string META_YEAR = "Year";
        public const string META_PLAYCOUNT = "playCount";
        public const string META_SKIPCOUNT = "skipCount";
        public const string META_RATING = "rating";
        #endregion

        public Song()
        {
            _allTheInformation = new Dictionary<string, string>(20);
            //TODO: Test if this is necessary for the DB query
            _allTheInformation["Album"] = "";
            _allTheInformation["AlbumArtists"] = "";
            _allTheInformation["AmazonID"] = "";
            _allTheInformation["Artists"] = "";
            _allTheInformation["Comment"] = "";
            _allTheInformation["Composers"] = "";
            _allTheInformation["Conductor"] = "";
            _allTheInformation["Copyright"] = "";
            _allTheInformation["BPM"] = "";
            _allTheInformation["Disc"] = "";
            _allTheInformation["DiscCount"] = "";
            _allTheInformation["Genres"] = "";
            _allTheInformation["Lyrics"] = "";
            _allTheInformation["Title"] = "";
            _allTheInformation["TrackNr"] = "";
            _allTheInformation["TrackCount"] = "";
            _allTheInformation["Year"] = "";
            _allTheInformation["playCount"] = "0";
            _allTheInformation["skipCount"] = "0";
            _allTheInformation["rating"] = "-1";
        }

        #region Information access
        public Dictionary<string, string> AllTheInformation()
        {
            return _allTheInformation;
        }

        /// <summary>
        /// Get a stored information field (tag). Returns an empty string if the field is not set.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public string getInformation(string identifier)
        {
            if (_allTheInformation.ContainsKey(identifier)) return _allTheInformation[identifier];
            else return "";
        }

        /// <summary>
        /// Set an information field (tag). Check result for true if you do not know if your identifier is allowed.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool setInformation(string identifier, string value)
        {
            if (_allTheInformation.ContainsKey(identifier))
                _allTheInformation[identifier] = value;
            else
                _allTheInformation.Add(identifier, value);
            return true;
        }
        #endregion

        public int LoadID()
        {
            id = Program.ActiveDatabase.GetSongID(this);
            return id;
        }

        public override string ToString()
        {
            //TODO: Let the user choose
            return string.Format("{0} - {1}", this.getInformation(META_ARTISTS), this.getInformation(META_TITLE));
        }

        public override bool Equals(object obj)
        {
            Song song = (Song)obj;
            //TODO: When does a song match a song?
            try
            {
                return (_allTheInformation[META_ARTISTS] == song._allTheInformation[META_ARTISTS] && _allTheInformation[META_TITLE] == song._allTheInformation[META_TITLE]);
            }
            catch (KeyNotFoundException E)
            {
                return false;
            }
        }
    }

    public class SongComparer : IComparer<Song>
    {
        private List<string> _orderby;
        private bool _ignorecase;

        public SongComparer()
        {
            _orderby = new List<string>();
            _orderby.Add(Song.META_ARTISTS);
        }
        public SongComparer(IEnumerable<string> orderby)
        {
            _orderby = new List<string>(orderby);
            _ignorecase = true;
        }
        public SongComparer(IEnumerable<string> orderby, bool ignorecase)
            : this(orderby)
        {
            this._ignorecase = ignorecase;
        }


        public int Compare(Song a, Song b)
        {
            foreach (string identifier in _orderby)
            {
                int test = String.Compare(a.getInformation(identifier), b.getInformation(identifier), _ignorecase);
                if (test != 0)
                    return test;
            }
            return 0;
        }
    }
}
