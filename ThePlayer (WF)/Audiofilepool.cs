using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    [Serializable]
    class Audiofilepool
    {
        public string Basepath { get; private set; }
        private List<Audiofile> audiofiles;

        public Audiofilepool(string path)
        {
            audiofiles = new List<Audiofile>();
            //TODO: Make subdirs chosable
            Basepath = path;
            string[] files = (string[])Directory.GetFiles(path,"*",SearchOption.AllDirectories);

            foreach (string file in files)
            {
                if (Program.ALLOWED_EXTENSIONS.Contains(Path.GetExtension(file).Substring(1)))
                {
                    audiofiles.Add(new Audiofile(file));
                }
            }
        }

        /// <summary>
        /// Find the first file that matches a song.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public Audiofile findSong(Song song)
        {
            //TODO: When does a file match a song?
            foreach (Audiofile audiofile in audiofiles)
            {
                if (audiofile.Track.Equals(song))
                    return audiofile;
            }
            return null;
        }

        /// <summary>
        /// Simply return the list of files in this pool.
        /// </summary>
        /// <returns></returns>
        public List<Audiofile> getAudiofiles()
        {
            return audiofiles;
        }

        /// <summary>
        /// Get a songpool of all the files' tracks.
        /// </summary>
        /// <returns></returns>
        public Songpool createSongpool()
        {
            List<Song> songs = new List<Song>();
            foreach (Audiofile audiofile in audiofiles)
            {
                songs.Add(audiofile.Track);
            }
            return new Songpool(songs);
        }
    }
}
