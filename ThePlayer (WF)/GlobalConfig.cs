﻿using System;
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
        /// <summary>
        /// The path to the directory where all the data is stored (pools, settings etc).
        /// </summary>
        public string Appdatapath { get; private set; }

        /// <summary>
        /// List of fields that must match to define two songs as equal.
        /// </summary>
        public List<string> ComparisonFields;

        /// <summary>
        /// Global settings for writing xml files
        /// </summary>
        public XmlWriterSettings XmlSettings;

        public List<string> CurrentSongviewColumns { get; set; }

        public Config()
        {
            this.Appdatapath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + System.Windows.Forms.Application.ProductName;
            ComparisonFields = new List<string>(new string[2] { Song.META_ARTISTS, Song.META_TITLE });
            CurrentSongviewColumns = new List<string>(new string[5] { Song.META_ARTISTS, Song.META_TITLE, Song.META_ALBUM, Song.META_GENRES, Song.META_PLAYCOUNT });

            // Could also be static. Just to avoid duplicate code
            XmlSettings = new XmlWriterSettings();
            XmlSettings.Indent = true;
            XmlSettings.IndentChars = "\t";
        }

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
        /// Load the configuration from the default path.
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            return Load(this.Appdatapath + "\\config.conf");
        }
        /// <summary>
        /// Loads a configuration. Returns false when the file does not exist.
        /// </summary>
        /// <returns></returns>
        public bool Load(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                Config c = (Config)bf.Deserialize(fs);
                fs.Close();
                if (c.Appdatapath != null) this.Appdatapath = c.Appdatapath;

                if (c.CurrentSongviewColumns != null) this.CurrentSongviewColumns = c.CurrentSongviewColumns;

                
                return true;
            }
            else return false;
        }
    }
}
