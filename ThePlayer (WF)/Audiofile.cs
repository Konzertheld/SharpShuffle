using System;
using System.Linq;

namespace ThePlayer
{
    [Serializable]
    public class Audiofile
    {
        public String Filepath { get; private set; }
        public Song Track;

        /// <summary>
        /// Creates a new instance of Audiofile based on an existing file.
        /// </summary>
        /// <param name="filepath"></param>
        public Audiofile(string filepath)
        {
            Filepath = filepath;
            Track = new Song();
            ReadTags();
        }

        /// <summary>
        /// Creates a new instance of Audiofile based on a specific song.
        /// </summary>
        /// <param name="source"></param>
        public Audiofile(Song source)
        {
            // TODO How should this happen? We can't instance Audiofile when there is no file. It has no use then.
            // We might need this when creating an audiofilepool backwards: The user creates a playlist of songs (a songpool) and then wants to burn a CD
            // or something. He might want to have all the files together then. I have no idea how an Audiofile constructor should do that, anyway.

        }

        /// <summary>
        /// Read the tags from a file and save them in the Song object. Useful when creating a new pool of songs.
        /// </summary>
        public void ReadTags()
        {
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
        }
    }
}
