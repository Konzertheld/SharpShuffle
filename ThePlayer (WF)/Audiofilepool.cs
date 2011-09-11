﻿using System;
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
        private List<string> audiofiles;

        #region Constructors
        public Audiofilepool(string path, string name)
        {
            Name = name;
            audiofiles = new List<string>();
            //TODO: Make subdirs chosable
            Basepath = path;
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            Program.ActiveDatabase.InsertAudiofilepool(name, path);
            foreach (string file in files)
            {
                if (Program.ALLOWED_EXTENSIONS.Contains(Path.GetExtension(file).Substring(1)))
                    audiofiles.Add(file);
            }

            Program.ActiveDatabase.InsertAudiofiles(audiofiles, name);
            

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
        public List<string> getAudiofiles()
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
            foreach (string audiofile in audiofiles)
            {
                songs.Add(new Audiofile(audiofile).Track);
            }
            Program.ActiveDatabase.InsertSongpool(Name);
            Program.ActiveDatabase.InsertSongs(songs, Name);
            return new Songpool(songs, Name);
        }
        /*#endregion

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
