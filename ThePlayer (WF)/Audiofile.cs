using System;
using System.Linq;

namespace ThePlayer
{
    [Serializable]
    public class Audiofile
    {
        public String Filepath { get; private set; }
        public Song Track { get; set; }

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
        /// Read the tags from the file and save them in the Song object. Useful when creating a new pool of songs.
        /// </summary>
        public void ReadTags()
        {
            //TODO: What to do when joined strings shall be written?
            //TODO: Possibly include images
            TagLib.File f = TagLib.File.Create(this.Filepath);
            if (f.Tag.Album != null && f.Tag.Album != "") Track.setInformation(META_IDENTIFIERS.Album, f.Tag.Album);
            if (f.Tag.JoinedAlbumArtists != null && f.Tag.JoinedAlbumArtists != "") Track.setInformation(META_IDENTIFIERS.AlbumArtists, f.Tag.JoinedAlbumArtists);
            if (f.Tag.AmazonId != null && f.Tag.AmazonId != "") Track.setInformation(META_IDENTIFIERS.AmazonID, f.Tag.AmazonId);
            if (f.Tag.JoinedPerformers != null && f.Tag.JoinedPerformers != "") Track.setInformation(META_IDENTIFIERS.Artists, f.Tag.JoinedPerformers);
            if (f.Tag.BeatsPerMinute != 0) Track.setInformation(META_IDENTIFIERS.BPM, f.Tag.BeatsPerMinute.ToString());
            if (f.Tag.Comment != null && f.Tag.Comment != "") Track.setInformation(META_IDENTIFIERS.Comment, f.Tag.Comment);
            if (f.Tag.JoinedComposers != null && f.Tag.JoinedComposers != "") Track.setInformation(META_IDENTIFIERS.Composers, f.Tag.JoinedComposers);
            if (f.Tag.Conductor != null && f.Tag.Conductor != "") Track.setInformation(META_IDENTIFIERS.Conductor, f.Tag.Conductor);
            if (f.Tag.Copyright != null && f.Tag.Copyright != "") Track.setInformation(META_IDENTIFIERS.Copyright, f.Tag.Copyright);
            if (f.Tag.Disc != 0) Track.setInformation(META_IDENTIFIERS.Disc, f.Tag.Disc.ToString());
            if (f.Tag.DiscCount != 0) Track.setInformation(META_IDENTIFIERS.DiscCount, f.Tag.DiscCount.ToString());
            if (f.Tag.JoinedGenres != null && f.Tag.JoinedGenres != "") Track.setInformation(META_IDENTIFIERS.Genres, f.Tag.JoinedGenres);
            if (f.Tag.Lyrics != null && f.Tag.Lyrics != "") Track.setInformation(META_IDENTIFIERS.Lyrics, f.Tag.Lyrics);
            if (f.Tag.Title != null && f.Tag.Title != "") Track.setInformation(META_IDENTIFIERS.Title, f.Tag.Title);
            if (f.Tag.TrackCount != 0) Track.setInformation(META_IDENTIFIERS.TrackCount, f.Tag.TrackCount.ToString());
            if (f.Tag.Track != 0) Track.setInformation(META_IDENTIFIERS.TrackNr, f.Tag.Track.ToString());
            if (f.Tag.Year != 0) Track.setInformation(META_IDENTIFIERS.Year, f.Tag.Year.ToString());
        }
    }
}
