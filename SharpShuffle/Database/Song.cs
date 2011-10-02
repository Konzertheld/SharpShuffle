using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle.Database
{
    public enum SONGMETA
    {
        id,
        Artists,
        BPM,
        Comment,
        Composer,
        Conductor,
        Copyright,
        Version,
        Genres,
        Lyrics,
        Title,
        TrackNr,
        PlayCount,
        SkipCount,
        Rating
    }

    public class Song
    {
        public uint id { get; set; }
        public string Artists { get; set; }
        public string Comment { get; set; }
        public string Composers { get; set; }
        public string Conductor { get; set; }
        public string Copyright { get; set; }
        public uint BPM { get; set; }
        public string Version { get; set; }
        public string Genres { get; set; }
        public string Lyrics { get; set; }
        public string Title { get; set; }
        public uint TrackNr { get; set; }
        public uint PlayCount { get; set; }
        public uint SkipCount { get; set; }
        public short Rating { get; set; }
        public CAlbum Album;

        public object this[string index]
        {
            get
            {
                return this[(SONGMETA)Enum.Parse(typeof(SONGMETA), index)];
            }
            set
            {
                this[(SONGMETA)Enum.Parse(typeof(SONGMETA), index)] = value;
            }
        }
        public object this[SONGMETA index]
        {
            get
            {
                switch (index)
                {
                    case SONGMETA.Artists:
                        return this.Artists;
                    case SONGMETA.BPM:
                        return this.BPM;
                    case SONGMETA.Comment:
                        return this.Comment;
                    case SONGMETA.Composer:
                        return this.Composers;
                    case SONGMETA.Conductor:
                        return this.Conductor;
                    case SONGMETA.Copyright:
                        return this.Copyright;
                    case SONGMETA.Genres:
                        return this.Genres;
                    case SONGMETA.Lyrics:
                        return this.Lyrics;
                    case SONGMETA.Title:
                        return this.Title;
                    case SONGMETA.TrackNr:
                        return this.TrackNr;
                    case SONGMETA.Version:
                        return this.Version;
                    case SONGMETA.PlayCount:
                        return this.PlayCount;
                    case SONGMETA.SkipCount:
                        return this.SkipCount;
                    case SONGMETA.Rating:
                        return this.Rating;
                    default:
                        throw new IndexOutOfRangeException("Wow! This should never be possible! The Songmeta enum does not contain such a value. Don't pass shit to the song indexer.");
                }
            }
            set
            {
                try
                {
                    switch (index)
                    {
                        case SONGMETA.Artists:
                            this.Artists = (string)value;
                            break;
                        case SONGMETA.BPM:
                            this.BPM = (uint)value;
                            break;
                        case SONGMETA.Comment:
                            this.Comment = (string)value;
                            break;
                        case SONGMETA.Composer:
                            this.Composers = (string)value;
                            break;
                        case SONGMETA.Conductor:
                            this.Conductor = (string)value;
                            break;
                        case SONGMETA.Copyright:
                            this.Copyright = (string)value;
                            break;
                        case SONGMETA.Genres:
                            this.Genres = (string)value;
                            break;
                        case SONGMETA.Lyrics:
                            this.Lyrics = (string)value;
                            break;
                        case SONGMETA.Title:
                            this.Title = (string)value;
                            break;
                        case SONGMETA.TrackNr:
                            this.TrackNr = (uint)value;
                            break;
                        case SONGMETA.Version:
                            this.Version = (string)value;
                            break;
                        case SONGMETA.PlayCount:
                            this.PlayCount = (uint)value;
                            break;
                        case SONGMETA.SkipCount:
                            this.SkipCount = (uint)value;
                            break;
                        case SONGMETA.Rating:
                            this.Rating = (short)value;
                            break;
                    }
                }
                catch (InvalidCastException E) { }
            }
        }

        public override string ToString()
        {
            //TODO: Let the user choose
            return string.Format("{0} - {1}", this.Artists, this.Title);
        }

        /// <summary>
        /// Songs are equal, when they have equal artists, titles and versions (where version is a user defined field).
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Song song = (Song)obj;
            return (this.Artists == song.Artists && this.Title == song.Title && this.Version == song.Version);
        }

        /// <summary>
        /// Read the tags from a file and save them in the Song object. Useful when creating a new pool of songs.
        /// </summary>
        public static Song ReadTags(string Filepath)
        {
            Song song = new Song();
            TagLib.File f = TagLib.File.Create(Filepath);

            if (f.Tag.JoinedPerformers != null && f.Tag.JoinedPerformers != "") song.Artists = f.Tag.JoinedPerformers;
            if (f.Tag.BeatsPerMinute != 0) song.BPM = f.Tag.BeatsPerMinute;
            if (f.Tag.Comment != null && f.Tag.Comment != "") song.Comment = f.Tag.Comment;
            if (f.Tag.JoinedComposers != null && f.Tag.JoinedComposers != "") song.Composers = f.Tag.JoinedComposers;
            if (f.Tag.Conductor != null && f.Tag.Conductor != "") song.Conductor = f.Tag.Conductor;
            if (f.Tag.Copyright != null && f.Tag.Copyright != "") song.Copyright = f.Tag.Copyright;
            if (f.Tag.JoinedGenres != null && f.Tag.JoinedGenres != "") song.Genres = f.Tag.JoinedGenres;
            if (f.Tag.Lyrics != null && f.Tag.Lyrics != "") song.Lyrics = f.Tag.Lyrics;
            if (f.Tag.Title != null && f.Tag.Title != "") song.Title = f.Tag.Title;
            if (f.Tag.Track != 0) song.TrackNr = f.Tag.Track;

            // Get rid of album information when album is not set
            if (f.Tag.Album != null && f.Tag.Album != "")
            {
                song.Album = new CAlbum();
                song.Album.Name = f.Tag.Album;
                if (f.Tag.Year != 0) song.Album.Year = f.Tag.Year;
                if (f.Tag.JoinedAlbumArtists != null && f.Tag.JoinedAlbumArtists != "") song.Album.AlbumArtists = f.Tag.JoinedAlbumArtists;
                if (f.Tag.TrackCount != 0) song.Album.TrackCount = f.Tag.TrackCount;

            }

            return song;
        }
    }

    public class SongComparer : IComparer<Song>
    {
        private List<SONGMETA> _orderby;
        private bool _ignorecase;

        public SongComparer()
        {
            _orderby = new List<SONGMETA>();
            _orderby.Add(SONGMETA.Artists);
        }
        public SongComparer(IEnumerable<SONGMETA> orderby)
        {
            _orderby = new List<SONGMETA>(orderby);
            _ignorecase = true;
        }
        public SongComparer(IEnumerable<SONGMETA> orderby, bool ignorecase)
            : this(orderby)
        {
            this._ignorecase = ignorecase;
        }


        public int Compare(Song a, Song b)
        {
            foreach (SONGMETA identifier in _orderby)
            {
                int test = String.Compare((string)a[identifier], (string)b[identifier], _ignorecase);
                if (test != 0)
                    return test;
            }
            return 0;
        }
    }
}
