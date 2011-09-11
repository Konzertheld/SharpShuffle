using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace ThePlayer
{
    class Database
    {
        private SQLiteConnection connection;

        public Database()
        {
            connection = new SQLiteConnection("Data Source=" + Program.GlobalConfig.Appdatapath + "\\database.db");
            connection.Open();
        }

        public void InsertSongpool(string name)
        {
        }

        public void InsertSong(Song song, string poolname)
        {
        }

        public void InsertAudiofilepool(string name)
        {
        }

        public void InsertAudiofile(string path, string poolname)
        {
        }

        public void CloseDB()
        {
            connection.Close();
        }
    }
}
