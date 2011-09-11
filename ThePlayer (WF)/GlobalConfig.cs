using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;

namespace ThePlayer
{
    [Serializable]
    class Config
    {
        //TODO: Split them up into config settings like song data, view settings...
        #region Attributes
        /// <summary>
        /// The path to the directory where all the data is stored (pools, settings etc).
        /// </summary>
        public string Appdatapath { get; set; }

        /// <summary>
        /// Folders in which the program should always look for audiofile instances of songs.
        /// </summary>
        private List<string> _sourceFolders;

        public List<string> CurrentSongviewColumns;

        [NonSerialized]
        public XmlWriterSettings XmlSettings;
        #endregion

        #region Constructor
        public Config()
        {
            Appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + System.Windows.Forms.Application.ProductName;
            CurrentSongviewColumns = new List<string>(new string[5] { Song.META_ARTISTS, Song.META_TITLE, Song.META_ALBUM, Song.META_GENRES, Song.META_PLAYCOUNT });

            // Could also be static. Just to avoid duplicate code
            XmlSettings = new XmlWriterSettings();
            XmlSettings.Indent = true;
            XmlSettings.IndentChars = "\t";
        }
        #endregion

        #region Methods
        public void AddSourceFolder(string path)
        {
            path = path.ToLower();
            if (System.IO.Directory.Exists(path) && !_sourceFolders.Contains(path)) _sourceFolders.Add(path);
        }
        public void RemoveSourceFolder(string path)
        {
            path = path.ToLower();
            if (_sourceFolders.Contains(path)) _sourceFolders.Remove(path);
        }
        #endregion

        #region Load and save
        /// <summary>
        /// Save the configuration into the Appdatapath.
        /// </summary>
        /// <returns>True when everything is ok or throws an error.</returns>
        public bool Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(Appdatapath + "\\config.conf", FileMode.Create);
            bf.Serialize(fs, this);
            fs.Close();
            return true;
        }

        /// <summary>
        /// Loads a configuration. Returns null when the file does not exist.
        /// </summary>
        /// <param name="Appdatapath">Path where all the data, including the config, is stored.</param>
        /// <returns></returns>
        public bool Load(string Appdatapath)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Appdatapath + "\\config.conf"))
            {
                FileStream fs = new FileStream(Appdatapath + "\\config.conf", FileMode.Open);
                Config c = (Config)bf.Deserialize(fs);
                fs.Close();
                if (c.Appdatapath != null) this.Appdatapath = c.Appdatapath;

                if (c.CurrentSongviewColumns != null) this.CurrentSongviewColumns = c.CurrentSongviewColumns;

                if (c._sourceFolders != null) this._sourceFolders = c._sourceFolders;
                return true;
            }
            else return false;
        }
        #endregion
    }
}
