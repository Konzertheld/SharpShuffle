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

        public int InsertSongpool(string name)
        {
            //TODO: Check for invalid names (invalid chars for db) & activate duplicate check
            SQLiteCommand c = new SQLiteCommand(connection);
            //c.CommandText = "SELECT id FROM songpools WHERE name='" + name + "'";
            //if (c.ExecuteReader().HasRows)
                //return -1;
            c.CommandText = "INSERT INTO songpools (name) VALUES ('" + name + "')";
            return c.ExecuteNonQuery();
        }

        public void InsertSongs(IEnumerable<Song> songs, string poolname)
        {
            SQLiteCommand c = new SQLiteCommand(connection);

            // Get pool id
            c.CommandText = "SELECT id FROM songpools WHERE name='" + poolname + "'";
            SQLiteDataReader r = c.ExecuteReader();
            int poolnr = -1;
            while (r.Read())
            {
                poolnr = r.GetInt32(r.GetOrdinal("id"));
            }
            r.Close();

            if (poolnr != -1)
            {
                SQLiteTransaction trans = connection.BeginTransaction();

                // Prepare statements
                string[] parameters = new string[21] { "Album", "AlbumArtists", "AmazonID", "Artists", "Comment", "Composers", "Conductor", "Copyright", "BPM", "Disc", "DiscCount", "Genres", "Lyrics", "Title", "TrackNr", "TrackCount", "Year", "playCount", "skipCount", "rating", "pool" };
                c.CommandText = "INSERT INTO songs (" + String.Join(", ", parameters) + ") VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                Dictionary<string, SQLiteParameter> parameterobjects = new Dictionary<string, SQLiteParameter>(21);
                for (int i = 0; i < 21; i++)
                {
                    parameterobjects.Add(parameters[i], new SQLiteParameter());
                    c.Parameters.Add(parameterobjects[parameters[i]]);
                }
                parameterobjects["pool"].Value = poolnr;
                
                // Insert songs
                foreach (Song song in songs)
                {
                    foreach (KeyValuePair<string, string> k in song.AllTheInformation())
                        parameterobjects[k.Key].Value = k.Value;
                    c.ExecuteNonQuery();
                }
                trans.Commit();
            }

            //TODO: Throw error for not existing pools
        }

        public int InsertAudiofilepool(string name, string path)
        {
            //TODO: Check for valid names
            SQLiteCommand c = new SQLiteCommand(connection);
            c.CommandText = String.Format("INSERT INTO audiofilepools (name, path) VALUES ('{0}', '{1}')", EscapeText(name), EscapeText(path));
            return c.ExecuteNonQuery();
        }

        public void InsertAudiofiles(IEnumerable<string> files, string poolname)
        {
            SQLiteCommand c = new SQLiteCommand(connection);

            // Get pool id
            int poolid = -1;
            c.CommandText = "SELECT id FROM audiofilepools WHERE name='" + poolname + "'";
            SQLiteDataReader r = c.ExecuteReader();
            while (r.Read())
            {
                poolid = r.GetInt32(r.GetOrdinal("id"));
            }
            r.Close();

            if (poolid != -1)
            { // Insert the files
                SQLiteTransaction trans = connection.BeginTransaction();
                c.CommandText = "INSERT INTO audiofiles (path, pool) VALUES (?, ?)";
                SQLiteParameter p1 = new SQLiteParameter();
                SQLiteParameter p2 = new SQLiteParameter();
                c.Parameters.Add(p1);
                c.Parameters.Add(p2);
                p2.Value = poolid;
                foreach (string file in files)
                {
                    p1.Value = file;
                    c.ExecuteNonQuery();
                }
                trans.Commit();
            }

            //TODO: Throw error if pool does not exist
        }

        public void CloseDB()
        {
            connection.Close();
        }

        private string EscapeText(string input)
        {
            return input.Replace("'", "''");
        }
    }
}
