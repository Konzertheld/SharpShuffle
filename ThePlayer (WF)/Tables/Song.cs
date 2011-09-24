using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    public class Song : Dataset
    {
        #region Constants
        public const string META_ALBUM = "Album";
        public const string META_AMAZON = "AmazonID";
        public const string META_ARTISTS = "Artists";
        public const string META_COMMENT = "Comment";
        public const string META_COMPOSERS = "Composers";
        public const string META_CONDUCTOR = "Conductor";
        public const string META_COPYRIGHT = "Copyright";
        public const string META_BPM = "BPM";
        public const string META_VERSION = "Version";
        public const string META_GENRES = "Genres";
        public const string META_LYRICS = "Lyrics";
        public const string META_TITLE = "Title";
        public const string META_TRACK = "TrackNr";
        public const string META_PLAYCOUNT = "playCount";
        public const string META_SKIPCOUNT = "skipCount";
        public const string META_RATING = "rating";
        #endregion

        public CAlbum Album;

        public Song()
        {
            _allTheInformation = new Dictionary<string, string>(20);
            //TODO: Test if this is necessary for the DB query
            _allTheInformation[META_ALBUM] = "";
            _allTheInformation[META_AMAZON] = "";
            _allTheInformation[META_ARTISTS] = "";
            _allTheInformation[META_COMMENT] = "";
            _allTheInformation[META_COMPOSERS] = "";
            _allTheInformation[META_CONDUCTOR] = "";
            _allTheInformation[META_COPYRIGHT] = "";
            _allTheInformation[META_BPM] = "";
            _allTheInformation[META_VERSION] = "Version";
            _allTheInformation[META_GENRES] = "";
            _allTheInformation[META_LYRICS] = "";
            _allTheInformation[META_TITLE] = "";
            _allTheInformation[META_TRACK] = "";
            _allTheInformation[META_PLAYCOUNT] = "0";
            _allTheInformation[META_SKIPCOUNT] = "0";
            _allTheInformation[META_RATING] = "-1";
        }

        /// <summary>
        /// Read the tags from a file and save them in the Song object. Useful when creating a new pool of songs.
        /// </summary>
        public static Song ReadTags(string Filepath)
        {
            Song Track = new Song();
            TagLib.File f = TagLib.File.Create(Filepath);

            if (f.Tag.AmazonId != null && f.Tag.AmazonId != "") Track.setInformation(Song.META_AMAZON, f.Tag.AmazonId);
            if (f.Tag.JoinedPerformers != null && f.Tag.JoinedPerformers != "") Track.setInformation(Song.META_ARTISTS, f.Tag.JoinedPerformers);
            if (f.Tag.BeatsPerMinute != 0) Track.setInformation(Song.META_BPM, f.Tag.BeatsPerMinute.ToString());
            if (f.Tag.Comment != null && f.Tag.Comment != "") Track.setInformation(Song.META_COMMENT, f.Tag.Comment);
            if (f.Tag.JoinedComposers != null && f.Tag.JoinedComposers != "") Track.setInformation(Song.META_COMPOSERS, f.Tag.JoinedComposers);
            if (f.Tag.Conductor != null && f.Tag.Conductor != "") Track.setInformation(Song.META_CONDUCTOR, f.Tag.Conductor);
            if (f.Tag.Copyright != null && f.Tag.Copyright != "") Track.setInformation(Song.META_COPYRIGHT, f.Tag.Copyright);
            if (f.Tag.JoinedGenres != null && f.Tag.JoinedGenres != "") Track.setInformation(Song.META_GENRES, f.Tag.JoinedGenres);
            if (f.Tag.Lyrics != null && f.Tag.Lyrics != "") Track.setInformation(Song.META_LYRICS, f.Tag.Lyrics);
            if (f.Tag.Title != null && f.Tag.Title != "") Track.setInformation(Song.META_TITLE, f.Tag.Title);
            if (f.Tag.Track != 0) Track.setInformation(Song.META_TRACK, f.Tag.Track.ToString());

            // Get rid of album information when album is not set
            if (f.Tag.Album != null && f.Tag.Album != "")
            {
                Track.Album = new CAlbum();
                Track.Album.setInformation(CAlbum.META_NAME, f.Tag.Album);
                if (f.Tag.Year != 0) Track.Album.setInformation(CAlbum.META_YEAR, f.Tag.Year.ToString());
                if (f.Tag.JoinedAlbumArtists != null && f.Tag.JoinedAlbumArtists != "") Track.Album.setInformation(CAlbum.META_ALBUMARTISTS, f.Tag.JoinedAlbumArtists);
            }

            return Track;
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
