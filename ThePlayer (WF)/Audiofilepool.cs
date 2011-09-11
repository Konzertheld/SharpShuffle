using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ThePlayer
{
    [Serializable]
    public class Audiofilepool
    {
        public string Basepath { get; private set; }
        public string Name { get; set; }
        private List<Audiofile> audiofiles;

        #region Constructors
        public Audiofilepool(string path, string name)
        {
            Name = name;
            //TODO: Make subdirs chosable
            Basepath = path;
            audiofiles = new List<Audiofile>();
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (Program.ALLOWED_EXTENSIONS.Contains(Path.GetExtension(file).Substring(1)))
                    audiofiles.Add(new Audiofile(file));
            }
        }
        #endregion
        /*
        #region Main methods
        /// <summary>
        /// Find the first file that matches a song.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public Audiofile findSong(Song song)
        {
            foreach (Audiofile audiofile in audiofiles)
            {
                if (audiofile.Track.Equals(song))
                    return audiofile;
            }
            return null;
        }*/

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
            //Program.ActiveDatabase.InsertSongpool(Name);
            //Program.ActiveDatabase.InsertSongs(songs, Name);
            return new Songpool(songs, Name);
        }
        

        #region Save and load
        public void Save()
        {
            Program.ActiveDatabase.InsertMeta(createSongpool().getSongs());
            foreach (Audiofile file in audiofiles)
                file.Track.LoadID();
            Program.ActiveDatabase.InsertAudiofilepool(Name, Basepath);
            Program.ActiveDatabase.InsertAudiofiles(audiofiles, Name);
        }

        public static Audiofilepool Load(string path)
        {
            //TODO: Validation before loading
            //TODO: Make it possible to not reload the pool on startup (tell the Constructor to not search the basepath and use the xml instead)
            XElement x = XElement.Load(path);
            Audiofilepool afp;
            if (true)
                afp = new Audiofilepool(x.Attribute("Basepath").Value, x.Attribute("Name").Value);
            else
            {
                //afp = new Audiofilepool();
                var load = from e in x.Elements()
                           where e.Name == "Audiofile"
                           select new { e };

                foreach (var v in load)
                {
                    afp.audiofiles.Add(new Audiofile(v.e.Attribute("Filepath").Value));
                }
            }
            return afp;
        }
        #endregion*/
    }
}
