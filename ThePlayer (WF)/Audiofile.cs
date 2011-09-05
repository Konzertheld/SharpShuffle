using System;
using System.Linq;

namespace ThePlayer
{
    [Serializable]
    class Audiofile
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
        }

        /// <summary>
        /// Read the tags from the file and save them in the Song object. Useful when creating a new pool of songs.
        /// </summary>
        public void ReadTags()
        {
            //TODO: Include all artists, genres...
            //TODO: Possibly include images
            TagLib.File f = TagLib.File.Create(this.Filepath);
            Track.setInformation(META_IDENTIFIERS.Album, f.Tag.Album);
            Track.setInformation(META_IDENTIFIERS.AlbumArtists, f.Tag.JoinedAlbumArtists);
            Track.setInformation(META_IDENTIFIERS.AmazonID, f.Tag.AmazonId);
            Track.setInformation(META_IDENTIFIERS.Artists, f.Tag.JoinedPerformers);
            Track.setInformation(META_IDENTIFIERS.BPM, f.Tag.BeatsPerMinute.ToString());
            Track.setInformation(META_IDENTIFIERS.Comment, f.Tag.Comment);
            Track.setInformation(META_IDENTIFIERS.Composers, f.Tag.JoinedComposers);
            Track.setInformation(META_IDENTIFIERS.Conductor, f.Tag.Conductor);
            Track.setInformation(META_IDENTIFIERS.Copyright, f.Tag.Copyright);
            Track.setInformation(META_IDENTIFIERS.Disc, f.Tag.Disc.ToString());
            Track.setInformation(META_IDENTIFIERS.DiscCount, f.Tag.DiscCount.ToString());
            Track.setInformation(META_IDENTIFIERS.Genres, f.Tag.JoinedGenres);
            Track.setInformation(META_IDENTIFIERS.Lyrics, f.Tag.Lyrics);
            Track.setInformation(META_IDENTIFIERS.Title, f.Tag.Title);
            Track.setInformation(META_IDENTIFIERS.TrackCount, f.Tag.TrackCount.ToString());
            Track.setInformation(META_IDENTIFIERS.TrackNr, f.Tag.Track.ToString());
            Track.setInformation(META_IDENTIFIERS.Year, f.Tag.Year.ToString());                
        }


    }
}
