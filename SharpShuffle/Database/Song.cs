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
        Rating,
        Length
    }

    public class Song
    {
        public uint id { get; set; }
        public string Artists { get; set; }
        public string Comment { get; set; }
        public string Composers { get; set; }
        public string Conductor { get; set; }
        public string Copyright { get; set; }
        public ushort BPM { get; set; }
        public string Version { get; set; }
        public string Genres { get; set; }
        public string Lyrics { get; set; }
        public string Title { get; set; }
        public ushort TrackNr { get; set; }
        public uint PlayCount { get; set; }
        public uint SkipCount { get; set; }
        public short Rating { get; set; }
        public uint Length { get; set; }
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
                if (index == SONGMETA.Artists)
                    return this.Artists;
                else if (index == SONGMETA.BPM)
                    return this.BPM;
                else if (index == SONGMETA.Comment)
                    return this.Comment;
                else if (index == SONGMETA.Composer)
                    return this.Composers;
                else if (index == SONGMETA.Conductor)
                    return this.Conductor;
                else if (index == SONGMETA.Copyright)
                    return this.Copyright;
                else if (index == SONGMETA.Genres)
                    return this.Genres;
                else if (index == SONGMETA.Lyrics)
                    return this.Lyrics;
                else if (index == SONGMETA.Title)
                    return this.Title;
                else if (index == SONGMETA.TrackNr)
                    return this.TrackNr;
                else if (index == SONGMETA.Version)
                    return this.Version;
                else if (index == SONGMETA.PlayCount)
                    return this.PlayCount;
                else if (index == SONGMETA.SkipCount)
                    return this.SkipCount;
                else if (index == SONGMETA.Rating)
                    return this.Rating;
                else if (index == SONGMETA.Length)
                    return this.Length;
                else throw new IndexOutOfRangeException("Wow! This should never be possible! The Songmeta enum does not contain such a value. Don't pass shit to the song indexer.");
            }
            set
            {
                if (index == SONGMETA.Artists)
                    Artists = (string)value;
                else if (index == SONGMETA.Title)
                    Title = (string)value;
                else if (index == SONGMETA.TrackNr)
                    TrackNr = Convert.ToUInt16(value);
                else if (index == SONGMETA.Version)
                    Version = (string)value;
                else if (index == SONGMETA.PlayCount)
                    PlayCount = Convert.ToUInt32(value);
                else if (index == SONGMETA.SkipCount)
                    SkipCount = Convert.ToUInt32(value);
                else if (index == SONGMETA.Rating)
                    Rating = Convert.ToInt16(value);
                else if (index == SONGMETA.Genres)
                    Genres = (string)value;
                else if (index == SONGMETA.Comment)
                    Comment = (string)value;
                else if (index == SONGMETA.Composer)
                    Composers = (string)value;
                else if (index == SONGMETA.Copyright)
                    Copyright = (string)value;
                else if (index == SONGMETA.Conductor)
                    Conductor = (string)value;
                else if (index == SONGMETA.Lyrics)
                    Lyrics = (string)value;
                else if (index == SONGMETA.BPM)
                    BPM = Convert.ToUInt16(value);
                else if (index == SONGMETA.Length)
                    Length = Convert.ToUInt32(value);
                else throw new IndexOutOfRangeException("Wow! This should never be possible! The Songmeta enum does not contain such a value. Don't pass shit to the song indexer.");
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

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + Artists.GetHashCode();
                hash = hash * 23 + Title.GetHashCode();
                hash = hash * 23 + Version.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        /// Read the tags from a file and save them in the Song object. Useful when creating a new pool of songs.
        /// </summary>
        public static Song ReadTags(string Filepath)
        {
            Song song = new Song();
            TagLib.File f = TagLib.File.Create(Filepath);

            if (f.Tag.JoinedPerformers != null && f.Tag.JoinedPerformers != "") song.Artists = f.Tag.JoinedPerformers;
            if (f.Tag.BeatsPerMinute != 0) song.BPM = Convert.ToUInt16(f.Tag.BeatsPerMinute);
            if (f.Tag.Comment != null && f.Tag.Comment != "") song.Comment = f.Tag.Comment;
            if (f.Tag.JoinedComposers != null && f.Tag.JoinedComposers != "") song.Composers = f.Tag.JoinedComposers;
            if (f.Tag.Conductor != null && f.Tag.Conductor != "") song.Conductor = f.Tag.Conductor;
            if (f.Tag.Copyright != null && f.Tag.Copyright != "") song.Copyright = f.Tag.Copyright;
            if (f.Tag.JoinedGenres != null && f.Tag.JoinedGenres != "") song.Genres = f.Tag.JoinedGenres;
            if (f.Tag.Lyrics != null && f.Tag.Lyrics != "") song.Lyrics = f.Tag.Lyrics;
            if (f.Tag.Title != null && f.Tag.Title != "") song.Title = f.Tag.Title;
            if (f.Tag.Track != 0) song.TrackNr = Convert.ToUInt16(f.Tag.Track);

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
