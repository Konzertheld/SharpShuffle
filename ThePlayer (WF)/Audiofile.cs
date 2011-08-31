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
            //TODO: Include more tags
            //TODO: Include all artists, genres...
            TagLib.File f = TagLib.File.Create(this.Filepath);
            if (f.Tag.Performers.Count() > 0)
                Track.setInformation("Artist", f.Tag.Performers[0]);
            Track.setInformation("Title", f.Tag.Title);
            Track.setInformation("Album", f.Tag.Album);
            if (f.Tag.Genres.Count() > 0)
                Track.setInformation("Genre", f.Tag.Genres[0]);
        }


    }
}
