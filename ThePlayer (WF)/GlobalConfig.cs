using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ThePlayer
{
    [Serializable]
    class Config
    {
        #region Attributes
        /// <summary>
        /// The path to the directory where all the data is stored (pools, settings etc).
        /// </summary>
        public string Appdatapath { get; set; }

        /// <summary>
        /// The user's songpools.
        /// </summary>
        public Dictionary<string, Songpool> Songpools;

        /// <summary>
        /// The user's audiofilepools.
        /// </summary>
        public Dictionary<string, Audiofilepool> Audiofilepools;

        /// <summary>
        /// Folders in which the program should always look for audiofile instances of songs.
        /// </summary>
        private List<string> _sourceFolders;
        #endregion

        #region Constructor
        public Config()
        {
            Appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + System.Windows.Forms.Application.ProductName;
            Songpools = new Dictionary<string, Songpool>();
            Audiofilepools = new Dictionary<string, Audiofilepool>();
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
        public static Config Load(string Appdatapath)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Appdatapath + "\\config.conf"))
            {
                FileStream fs = new FileStream(Appdatapath + "\\config.conf", FileMode.Open);
                Config c = (Config)bf.Deserialize(fs);
                fs.Close();
                return c;
            }
            else return null;
        }
        #endregion
    }
}
