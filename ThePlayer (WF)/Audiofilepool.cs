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
            audiofiles = new List<Audiofile>();
            //TODO: Make subdirs chosable
            Basepath = path;
            string[] files = (string[])Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                if (Program.ALLOWED_EXTENSIONS.Contains(Path.GetExtension(file).Substring(1)))
                {
                    audiofiles.Add(new Audiofile(file));
                }
            }
        }
        #endregion

        #region Main methods
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
            return new Songpool(songs, Name);
        }
        #endregion

        #region Save and load
        public bool Save()
        {
            //TODO: Throw exception when pool has no name
            XmlWriter xw = XmlWriter.Create(Program.GlobalConfig.Appdatapath + "\\audiofilepools\\" + Name + ".xml", Program.GlobalConfig.XmlSettings);
            xw.WriteStartDocument();
            xw.WriteStartElement("Audiofilepool");
            xw.WriteAttributeString("Name", Name);
            xw.WriteAttributeString("Basepath", Basepath);
            foreach (Audiofile af in audiofiles)
            {
                xw.WriteStartElement("Audiofile");
                xw.WriteAttributeString("Filepath", af.Filepath);
                xw.WriteEndElement();
            }
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Close();
            return true;
        }

        public static Audiofilepool Load(string path)
        {
            //TODO: Validation before loading
            XElement x = XElement.Load(path);
            Audiofilepool afp = new Audiofilepool(x.Attribute("Basepath").Value, x.Attribute("Name").Value);

            var load = from e in x.Elements()
                       where e.Name == "Audiofile"
                       select new { e };

            foreach (var v in load)
            {
                afp.audiofiles.Add(new Audiofile(v.e.Attribute("Filepath").Value));
            }

            return afp;
        }
        #endregion
    }
}
