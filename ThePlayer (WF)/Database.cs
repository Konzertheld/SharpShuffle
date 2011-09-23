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
            c.CommandText = "DELETE FROM Albums";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Artists";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Genres";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Tracks";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Songs";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Audiofiles";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Audiofilepools";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Songpools";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Poolsongs";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Meta";
            c.ExecuteNonQuery();
            c.CommandText = "VACUUM";
            c.ExecuteNonQuery();
        }

        public int InsertSongpool(string name)
        {
            SQLiteCommand c = new SQLiteCommand(connection);
            c.CommandText = "SELECT id FROM Songpools WHERE name=?";
            c.Parameters.Add(new SQLiteParameter("name", name));
            if (c.ExecuteReader().HasRows)
                return -1;
            c.Parameters.Clear();
            c.CommandText = "INSERT INTO songpools (name) VALUES (?)";
            c.Parameters.Add(new SQLiteParameter("name", name));
            return c.ExecuteNonQuery();
        }

        /// <summary>
        /// Returns the ids for the given songs. Inserts them before when not found.
        /// </summary>
        /// <param name="songs"></param>
        /// <returns></returns>
        public int[] ManageSongs(IEnumerable<Song> songs)
        {
            return ManageSongs(songs, true);
        }
        /// <summary>
        /// Returns the ids for the given songs. Optionally inserts them when not found.
        /// </summary>
        /// <param name="songs"></param>
        /// <param name="insert"></param>
        /// <returns></returns>
        public int[] ManageSongs(IEnumerable<Song> songs, bool insert)
        {
            // Array anlegen für die IDs der angelegten / gefundenen Datensätze.
            int[] iResult = new int[songs.Count()];

            SQLiteTransaction sqt = connection.BeginTransaction();
            SQLiteCommand sqcCheck = new SQLiteCommand(connection);
            SQLiteCommand sqcInsert = new SQLiteCommand(connection);
            /*
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
             */

            int i = 0;
            
            sqcCheck.CommandText = "SELECT id FROM Songs WHERE Artist=? AND Title=?";
            sqcCheck.Parameters.Add(new SQLiteParameter("Artist"));
            sqcCheck.Parameters.Add(new SQLiteParameter("Title"));
            if (insert)
            {
                sqcInsert.CommandText = "INSERT INTO Songs (Artist, Title) VALUES (?, ?)";
                sqcInsert.Parameters.Add(new SQLiteParameter("Artist"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Title"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Album"));
            }

            foreach (Song song in songs)
            {
                object id;
                // Song schon eingetragen?
                sqcCheck.Parameters["Artist"].Value = song.getInformation(Song.META_ARTISTS);
                sqcCheck.Parameters["Title"].Value = song.getInformation(Song.META_TITLE);
                id = sqcCheck.ExecuteScalar();

                if (id == null && insert)
                {
                    // Nein, also eintragen (falls angegeben)
                    sqcInsert.Parameters["Artist"].Value = song.getInformation(Song.META_ARTISTS);
                    sqcInsert.Parameters["Title"].Value = song.getInformation(Song.META_TITLE);
                    //sqcInsert.Parameters["Album"].Value = song.getInformation(Song.META_ALBUM);
                    sqcInsert.ExecuteNonQuery();

                    // Und jetzt die ID holen (TODO: Iih. Das muss anders gehen.)
                    sqcCheck.Parameters["Artist"].Value = song.getInformation(Song.META_ARTISTS);
                    sqcCheck.Parameters["Title"].Value = song.getInformation(Song.META_TITLE);
                    id = sqcCheck.ExecuteScalar();
                }
                else if (id == null)
                    id = -1;

                // ID eintragen (entweder von existierendem Datensatz oder von neu eingefügtem)
                iResult[i] = Convert.ToInt32(id);
                i++;
            }

            sqt.Commit();
            return iResult;
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

        public void InsertAudiofiles(IEnumerable<Audiofile> files)
        {
            SQLiteCommand c = new SQLiteCommand(connection);
            SQLiteTransaction trans = connection.BeginTransaction();
            c.CommandText = "INSERT INTO audiofiles (Path, idMeta) VALUES (?, ?)";
            c.Parameters.Add(new SQLiteParameter("Path"));
            c.Parameters.Add(new SQLiteParameter("idMeta"));
            foreach (Audiofile file in files)
            {
                c.Parameters["Path"].Value = file.Path;
                c.Parameters["idMeta"].Value = file.idMeta;
                c.ExecuteNonQuery();
            }
            trans.Commit();
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

        public List<Audiofilepool> LoadAudiofilepools()
        {
            return new List<Audiofilepool>();
        }

        public void CloseDB()
        {
            connection.Close();
        }
    }
}
