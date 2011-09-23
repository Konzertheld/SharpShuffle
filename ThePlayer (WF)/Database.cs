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
            c.CommandText = "DELETE FROM Songs";
            // etc
            c.CommandText = "VACUUM";
            c.ExecuteNonQuery();
        }

        /// <summary>
        /// Returns a songpool's id. Inserts the songpool before if necessary.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int ManageSongpool(string name)
        {
            SQLiteCommand c = new SQLiteCommand(connection);
            c.CommandText = "SELECT id FROM Songpools WHERE name=?";
            c.Parameters.Add(new SQLiteParameter("name", name));
            object id = c.ExecuteScalar();
            if (id != null)
                return Convert.ToInt32(id);

            c.CommandText = "INSERT INTO songpools (name) VALUES (?)";
            c.ExecuteNonQuery();
            return ManageSongpool(name);
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

        /// <summary>
        /// Connect songs with a pool.
        /// </summary>
        /// <param name="song_ids"></param>
        /// <param name="pool_id"></param>
        public void PutSongsInPools(int[] song_ids, int pool_id)
        {
            SQLiteCommand c = new SQLiteCommand(connection);
            SQLiteTransaction sqt = connection.BeginTransaction();
            c.CommandText = "INSERT INTO Poolsongs (idSong, idPool) VALUES (?, ?)";
            c.Parameters.Add("idSong");
            c.Parameters.Add(new SQLiteParameter("idPool", pool_id));
            for (int i = 0; i < song_ids.Count(); i++)
            {
                c.Parameters["idSong"].Value = song_ids[i];
                c.ExecuteNonQuery();
            }
            sqt.Commit();
        }

        /// <summary>
        /// Insert audiofiles into the database. Make sure idMeta is set to avoid putting strange stuff into your database.
        /// </summary>
        /// <param name="files"></param>
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


        public string GetFileForSong(Song song)
        {
            //TODO: Don't simply take all audiofiles. The user might not want that.
            /*int meta_id = GetSongID(song);
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
            }*/
            return null;
        }

        public void CloseDB()
        {
            connection.Close();
        }
    }
}
