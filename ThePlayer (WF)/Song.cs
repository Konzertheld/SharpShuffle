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

        /// <summary>
        /// Read the tags from a file and save them in the Song object. Useful when creating a new pool of songs.
        /// </summary>
        public static Song ReadTags(string Filepath)
        {
            Song Track = new Song();
            //TODO: What to do when joined strings shall be written?
            //TODO: Possibly include images
            TagLib.File f = TagLib.File.Create(Filepath);
            if (f.Tag.Album != null && f.Tag.Album != "") Track.setInformation(Song.META_ALBUM, f.Tag.Album);
            if (f.Tag.JoinedAlbumArtists != null && f.Tag.JoinedAlbumArtists != "") Track.setInformation(Song.META_ALBUMARTISTS, f.Tag.JoinedAlbumArtists);
            if (f.Tag.AmazonId != null && f.Tag.AmazonId != "") Track.setInformation(Song.META_AMAZON, f.Tag.AmazonId);
            if (f.Tag.JoinedPerformers != null && f.Tag.JoinedPerformers != "") Track.setInformation(Song.META_ARTISTS, f.Tag.JoinedPerformers);
            if (f.Tag.BeatsPerMinute != 0) Track.setInformation(Song.META_BPM, f.Tag.BeatsPerMinute.ToString());
            if (f.Tag.Comment != null && f.Tag.Comment != "") Track.setInformation(Song.META_COMMENT, f.Tag.Comment);
            if (f.Tag.JoinedComposers != null && f.Tag.JoinedComposers != "") Track.setInformation(Song.META_COMPOSERS, f.Tag.JoinedComposers);
            if (f.Tag.Conductor != null && f.Tag.Conductor != "") Track.setInformation(Song.META_CONDUCTOR, f.Tag.Conductor);
            if (f.Tag.Copyright != null && f.Tag.Copyright != "") Track.setInformation(Song.META_COPYRIGHT, f.Tag.Copyright);
            if (f.Tag.Disc != 0) Track.setInformation(Song.META_DISC, f.Tag.Disc.ToString());
            if (f.Tag.DiscCount != 0) Track.setInformation(Song.META_DISCCOUNT, f.Tag.DiscCount.ToString());
            if (f.Tag.JoinedGenres != null && f.Tag.JoinedGenres != "") Track.setInformation(Song.META_GENRES, f.Tag.JoinedGenres);
            if (f.Tag.Lyrics != null && f.Tag.Lyrics != "") Track.setInformation(Song.META_LYRICS, f.Tag.Lyrics);
            if (f.Tag.Title != null && f.Tag.Title != "") Track.setInformation(Song.META_TITLE, f.Tag.Title);
            if (f.Tag.TrackCount != 0) Track.setInformation(Song.META_TRACKCOUNT, f.Tag.TrackCount.ToString());
            if (f.Tag.Track != 0) Track.setInformation(Song.META_TRACK, f.Tag.Track.ToString());
            if (f.Tag.Year != 0) Track.setInformation(Song.META_YEAR, f.Tag.Year.ToString());
            return Track;
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
