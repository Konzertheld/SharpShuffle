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

        public void ClearDB()
        {
            SQLiteCommand c = new SQLiteCommand(connection);
            c.CommandText = "DELETE FROM songs";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM audiofiles";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM audiofilepools";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM songpools";
            c.ExecuteNonQuery();
            c.CommandText = "VACUUM";
            c.ExecuteNonQuery();
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
            c.CommandText = "INSERT INTO audiofilepools (name, path) VALUES (?, ?)";
            SQLiteParameter p1 = new SQLiteParameter();
            SQLiteParameter p2 = new SQLiteParameter();
            p1.Value = name;
            p2.Value = path;
            c.Parameters.AddRange(new SQLiteParameter[2] { p1, p2 });
            return c.ExecuteNonQuery();
        }

        public void InsertAudiofiles(IEnumerable<Audiofile> files, string poolname)
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
                c.CommandText = "INSERT INTO audiofiles (path, pool, meta_id) VALUES (?, ?, ?)";
                SQLiteParameter p1 = new SQLiteParameter();
                SQLiteParameter p2 = new SQLiteParameter();
                SQLiteParameter p3 = new SQLiteParameter();
                c.Parameters.Add(p1);
                c.Parameters.Add(p2);
                c.Parameters.Add(p3);
                p2.Value = poolid;
                foreach (Audiofile file in files)
                {
                    p1.Value = file.Filepath;
                    p3.Value = file.Track.id;
                    c.ExecuteNonQuery();
                }
                trans.Commit();
            }

            //TODO: Throw error if pool does not exist
        }

        public void InsertMeta(IEnumerable<Song> songs)
        {
            SQLiteCommand c = new SQLiteCommand(connection);
            SQLiteTransaction trans = connection.BeginTransaction();

            // Prepare statements
            string[] parameters = new string[17] { "Album", "AlbumArtists", "AmazonID", "Artists", "Comment", "Composers", "Conductor", "Copyright", "BPM", "Disc", "DiscCount", "Genres", "Lyrics", "Title", "TrackNr", "TrackCount", "Year" };
            c.CommandText = "INSERT INTO filemeta (" + String.Join(", ", parameters) + ") VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            Dictionary<string, SQLiteParameter> parameterobjects = new Dictionary<string, SQLiteParameter>(21);
            for (int i = 0; i < 17; i++)
            {
                parameterobjects.Add(parameters[i], new SQLiteParameter());
                c.Parameters.Add(parameterobjects[parameters[i]]);
            }

            // Insert meta
            foreach (Song song in songs)
            {
                foreach (KeyValuePair<string, string> k in song.AllTheInformation())
                    if(parameterobjects.Keys.Contains(k.Key)) parameterobjects[k.Key].Value = k.Value;
                c.ExecuteNonQuery();
            }
            trans.Commit();
            //TODO: Throw error for not existing pools
        }

        /// <summary>
        /// Get a song's database id.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public int GetSongID(Song song)
        {
            SQLiteCommand c = new SQLiteCommand(connection);
            int songid = -1;

            List<string> wheres = new List<string>();
            foreach (string s in Program.GlobalConfig.ComparisonFields)
            {
                wheres.Add(s + " = ?");
                SQLiteParameter p = new SQLiteParameter();
                p.Value = song.AllTheInformation()[s];
                c.Parameters.Add(p);
            }

            c.CommandText = "SELECT id FROM filemeta WHERE " + String.Join(" AND ", wheres);
            SQLiteDataReader r = c.ExecuteReader();
            while (r.Read())
            {
                songid = r.GetInt32(r.GetOrdinal("id"));
            }
            r.Close();

            return songid;
        }

        public string GetFileForSong(Song song)
        {
            //TODO: Don't simply take all audiofiles. The user might not want that.
            int meta_id = GetSongID(song);
            SQLiteCommand c = new SQLiteCommand(connection);
            c.CommandText = "SELECT path FROM audiofiles WHERE meta_id = ?";
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = meta_id;
            c.Parameters.Add(p1);
            SQLiteDataReader r = c.ExecuteReader();
            while (r.Read())
            {
                //TODO: Take care of multiple matches
                return r.GetString(r.GetOrdinal("path"));
            }
            return null;
        }

        public void CloseDB()
        {
            connection.Close();
        }
    }
}
