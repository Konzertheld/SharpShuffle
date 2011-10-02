using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace SharpShuffle.Database
{
    class Database
    {
        private SQLiteConnection connection;

        public Dictionary<int, Songpool> LoadedSongpools;

        public Database(string path)
        {
            connection = new SQLiteConnection("Data Source=" + path);
            connection.Open();

            LoadedSongpools = new Dictionary<int, Songpool>();
        }

        #region Database methods
        /// <summary>
        /// Helper method for database models.
        /// </summary>
        /// <returns>Returns an SQLiteCommand based on the active database connection.</returns>
        public SQLiteCommand GetCommand()
        {
            return new SQLiteCommand(connection);
        }

        public void CloseDB()
        {
            connection.Close();
        }

        public void ClearDB()
        {
            SQLiteCommand c = new SQLiteCommand(connection);
            c.CommandText = "DELETE FROM Songs";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Songpools";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Poolsongs";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Audiofiles";
            c.ExecuteNonQuery();
            c.CommandText = "DELETE FROM Albums";
            c.ExecuteNonQuery();
            c.CommandText = "VACUUM";
            c.ExecuteNonQuery();
        }
        #endregion

        #region Data Methods - Creation
        /// <summary>
        /// Make sure a songpool exists. If it does not yet, it is inserted. Returns true if a pool was created and false if it did already exist.
        /// </summary>
        /// <param name="name">The desired name.</param>
        public bool CreateSongpool(string name)
        {
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "INSERT INTO Songpools (Name) SELECT :Name WHERE NOT EXISTS (SELECT id FROM Songpools WHERE Name=:Name)";
                sqc.Parameters.Add(new SQLiteParameter("Name", name));
                int affected = sqc.ExecuteNonQuery();
                return (affected > 0);
            }
        }

        #endregion

        #region Insert and Check
        /// <summary>
        /// Returns the ids for the given songs. Inserts them before when not found.
        /// </summary>
        /// <param name="songs"></param>
        /// <returns></returns>
        public uint[] ManageSongs(IEnumerable<Song> songs)
        {
            return ManageSongs(songs, true);
        }
        /// <summary>
        /// Returns the ids for the given songs. Optionally inserts them when not found.
        /// </summary>
        /// <param name="songs"></param>
        /// <param name="insert"></param>
        /// <returns></returns>
        public uint[] ManageSongs(IEnumerable<Song> songs, bool insert)
        {
            // Alben laden bzw. anlegen
            using (SQLiteTransaction sqt = connection.BeginTransaction())
            {
                if (insert) songs = LinkSongsWithAlbums(songs);

                // Array anlegen für die IDs der angelegten / gefundenen Datensätze.
                uint[] iResult = new uint[songs.Count()];
                uint i = 0;
                string[] parameters = Enum.GetNames(typeof(SONGMETA));
                string[] namedparameters = new string[parameters.Count()];

                SQLiteCommand sqcCheck = new SQLiteCommand(connection);
                //TODO: 1. More and chosable criteria. 2. Do this with LoadSongs().
                sqcCheck.CommandText = "SELECT id FROM Songs WHERE Artists=:Artists AND Title=:Title";
                sqcCheck.Parameters.Add(new SQLiteParameter("Artists"));
                sqcCheck.Parameters.Add(new SQLiteParameter("Title"));

                SQLiteCommand sqcInsert = new SQLiteCommand(connection);

                for (ushort j = 0; j < parameters.Count(); j++)
                {
                    sqcInsert.Parameters.Add(new SQLiteParameter(parameters[j]));
                    namedparameters[j] = ":" + parameters[j];
                }

                sqcInsert.CommandText = "INSERT INTO Songs (idAlbum, " + String.Join(", ", parameters) + ") SELECT :idAlbum, " + String.Join(", ", namedparameters) + " WHERE NOT EXISTS(SELECT id FROM Songs WHERE LOWER(Artists)=LOWER(:Artists) AND LOWER(Title)=LOWER(:Title) AND LOWER(Version)=LOWER(:Version))";

                foreach (Song song in songs)
                {
                    object id = null;
                    //TODO: Überlegen, ob es Fälle gibt, in denen ein Song eine ID hat, obwohl er nicht mit dieser ID in der Datenbank ist
                    if (song.id != 0)
                        id = song.id;
                    else
                    {
                        for(ushort j=0;j<parameters.Count();j++)
                        {
                            sqcInsert.Parameters[parameters[j]].Value = song[parameters[j]];
                        }
                        
                        if (song.Album != null)
                            sqcInsert.Parameters["idAlbum"].Value = song.Album.id;
                        else
                            sqcInsert.Parameters["idAlbum"].Value = null;

                        if (sqcInsert.ExecuteNonQuery() > 0)
                            id = new SQLiteCommand("SELECT last_insert_rowid()", connection).ExecuteScalar();
                        if (id == null)
                            id = -1;
                    }
                    // ID eintragen (entweder von existierendem Datensatz oder von neu eingefügtem)
                    iResult[i] = Convert.ToUInt32(id);
                    i++;
                }

                sqt.Commit();
                return iResult;
            }
        }

        public IEnumerable<Song> LinkSongsWithAlbums(IEnumerable<Song> songs)
        {
            List<Song> result = new List<Song>();
            foreach (Song song in songs)
            {
                if (song.Album != null && song.Album.Name != "")
                    song.Album.id = InsertAlbum(song.Album);
                result.Add(song);
            }
            return result;
        }

        /// <summary>
        /// Connect songs with a pool. Don't allow duplicates.
        /// </summary>
        /// <param name="song_ids"></param>
        /// <param name="pool_id"></param>
        public void PutSongsInPool(uint[] song_ids, uint pool_id)
        {
            PutSongsInPool(song_ids, pool_id, false);
        }
        /// <summary>
        /// Connect songs with a pool.
        /// </summary>
        /// <param name="song_ids"></param>
        /// <param name="pool_id"></param>
        public void PutSongsInPool(uint[] song_ids, uint pool_id, bool allow_duplicates)
        {
            SQLiteTransaction sqt = connection.BeginTransaction();
            SQLiteCommand sqcCheck = new SQLiteCommand(connection);
            sqcCheck.CommandText = "SELECT id FROM Poolsongs WHERE idSong=? AND idPool=?";
            sqcCheck.Parameters.Add(new SQLiteParameter("idSong"));
            sqcCheck.Parameters.Add(new SQLiteParameter("idPool", pool_id));
            SQLiteCommand sqcInsert = new SQLiteCommand(connection);
            sqcInsert.CommandText = "INSERT INTO Poolsongs (idSong, idPool) VALUES (?, ?)";
            sqcInsert.Parameters.Add(new SQLiteParameter("idSong"));
            sqcInsert.Parameters.Add(new SQLiteParameter("idPool", pool_id));
            for (int i = 0; i < song_ids.Count(); i++)
            {
                if (!allow_duplicates)
                    sqcCheck.Parameters["idSong"].Value = song_ids[i];
                if (allow_duplicates || sqcCheck.ExecuteScalar() == null)
                {
                    sqcInsert.Parameters["idSong"].Value = song_ids[i];
                    sqcInsert.ExecuteNonQuery();
                }
            }
            sqt.Commit();
        }
        public void PutSongsInPool(IEnumerable<Song> songs, uint pool_id)
        {
            PutSongsInPool(songs, pool_id, false);
        }
        public void PutSongsInPool(IEnumerable<Song> songs, uint pool_id, bool allow_duplicates)
        {
            var ids = from s in songs
                      where s.id != 0
                      select s.id;
            var unknownsongs = from s in songs
                               where s.id == 0
                               select s;
            uint[] nowknownids = ManageSongs(unknownsongs, false);
            uint[] idstouse = new uint[ids.Count() + nowknownids.Count()];
            nowknownids.CopyTo(idstouse, 0);
            ((uint[])ids).CopyTo(idstouse, nowknownids.Count());
            PutSongsInPool(idstouse, pool_id, allow_duplicates);
        }

        /// <summary>
        /// Insert audiofiles into the database. Make sure idMeta is set to avoid putting strange stuff into your database. If the given path is existing, it is updated with the given idMeta.
        /// </summary>
        /// <param name="files"></param>
        public void ManageAudiofiles(IEnumerable<Audiofile> files)
        {
            SQLiteTransaction sqt = connection.BeginTransaction();
            SQLiteCommand sqcCheck = new SQLiteCommand(connection);
            sqcCheck.CommandText = "SELECT id FROM audiofiles WHERE Path=?";
            sqcCheck.Parameters.Add(new SQLiteParameter("Path"));
            SQLiteCommand sqcInsert = new SQLiteCommand(connection);
            sqcInsert.CommandText = "INSERT INTO audiofiles (Path, idMeta) VALUES (?, ?)";
            sqcInsert.Parameters.Add(new SQLiteParameter("Path"));
            sqcInsert.Parameters.Add(new SQLiteParameter("idMeta"));
            SQLiteCommand sqcUpdate = new SQLiteCommand(connection);
            sqcUpdate.CommandText = "UPDATE audiofiles SET idMeta=? WHERE Path=?";
            sqcUpdate.Parameters.Add(new SQLiteParameter("idMeta"));
            sqcUpdate.Parameters.Add(new SQLiteParameter("Path"));
            foreach (Audiofile file in files)
            {
                sqcCheck.Parameters["Path"].Value = file.Path;
                if (sqcCheck.ExecuteScalar() == null)
                {
                    sqcInsert.Parameters["Path"].Value = file.Path;
                    sqcInsert.Parameters["idMeta"].Value = file.idMeta;
                    sqcInsert.ExecuteNonQuery();
                }
                else
                {
                    sqcUpdate.Parameters["idMeta"].Value = file.idMeta;
                    sqcUpdate.Parameters["Path"].Value = file.Path;
                    sqcUpdate.ExecuteNonQuery();
                }

            }
            sqt.Commit();
        }

        /// <summary>
        /// Get an album's id. Insert the album if necessary.
        /// </summary>
        /// <param name="albumname"></param>
        /// <param name="case_sensitive"></param>
        /// <returns></returns>
        public uint InsertAlbum(CAlbum album)
        {
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "INSERT INTO Albums (Name, AlbumArtists, TrackCount, Year) SELECT :Name, :AlbumArtists, :TrackCount, :Year WHERE NOT EXISTS(SELECT id FROM Albums WHERE LOWER(Name)=LOWER(:Name) AND LOWER(AlbumArtists)=LOWER(:AlbumArtists) AND TrackCount=:TrackCount AND Year=:Year)";
                sqc.Parameters.Add(new SQLiteParameter("Name", album.Name));
                sqc.Parameters.Add(new SQLiteParameter("AlbumArtists", album.AlbumArtists));
                sqc.Parameters.Add(new SQLiteParameter("TrackCount", album.TrackCount));
                sqc.Parameters.Add(new SQLiteParameter("Year", album.Year));

                int i = sqc.ExecuteNonQuery();
                if (i > 0)
                {
                    object id = new SQLiteCommand("SELECT last_insert_rowid()", connection).ExecuteScalar();
                    return Convert.ToUInt32(id);
                }
                else
                {
                    sqc.CommandText = "SELECT id FROM Albums WHERE LOWER(Name)=LOWER(:Name) AND LOWER(AlbumArtists)=LOWER(:AlbumArtists) AND TrackCount=:TrackCount AND Year=:Year";
                    sqc.Parameters.Clear();
                    sqc.Parameters.Add(new SQLiteParameter("Name", album.Name));
                    sqc.Parameters.Add(new SQLiteParameter("AlbumArtists", album.AlbumArtists));
                    sqc.Parameters.Add(new SQLiteParameter("TrackCount", album.TrackCount));
                    sqc.Parameters.Add(new SQLiteParameter("Year", album.Year));
                    return Convert.ToUInt32(sqc.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Add all songs that don't already exist there to another pool.
        /// </summary>
        /// <param name="source">Source pool name</param>
        /// <param name="destination">Destination pool name</param>
        public void PoolMergeInPool(string source, string destination)
        {
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                using (SQLiteTransaction sqt = connection.BeginTransaction())
                {
                    sqc.CommandText = "INSERT INTO Poolsongs (idSong, idPool) SELECT idSong, :idDest FROM Poolsongs WHERE idPool=:idSource AND NOT idSong IN (SELECT idSong FROM Poolsongs WHERE idPool=:idDest)";
                    sqc.Parameters.Add(new SQLiteParameter("idDest", ID_Songpool(destination)));
                    sqc.Parameters.Add(new SQLiteParameter("idSource", ID_Songpool(source)));
                    sqc.ExecuteNonQuery();
                    sqt.Commit();
                }
            }
        }
        #endregion

        #region Load data
        /// <summary>
        /// Get a list of all existing songpools.
        /// </summary>
        /// <returns>name list</returns>
        public List<string> PoolList()
        {
            List<string> result = new List<string>();
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "SELECT Name FROM Songpools";
                using (SQLiteDataReader sqr = sqc.ExecuteReader())
                {
                    while (sqr.Read())
                        result.Add(sqr.GetString(0));
                }
            }
            return result;
        }


        public List<Song> LoadSongs(string poolname)
        {
            return LoadSongs(poolname, new string[0], new Filter[0]);
        }
        public List<Song> LoadSongs(string poolname, IEnumerable<string> order_by, IEnumerable<Filter> filters)
        {
            List<Song> result = new List<Song>();
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                // Process the filters to WHEREs
                List<string> wheres = new List<string>();
                foreach (Filter f in filters)
                {
                    wheres.Add(((f.Not_Flag) ? "NOT " : "") + "LOWER(" + f.Key + ")" + f.Comparetype + "?");
                    sqc.Parameters.Add(new SQLiteParameter(f.Key, f.Value.ToLower()));
                }

                //sqc.Parameters.Add(new SQLiteParameter("idPool", 4));

                sqc.CommandText = "SELECT Songs.id AS SID, Songs.Artists, Songs.Title, Songs.Genre, Songs.TrackNr, Songs.Copyright, Songs.Comment, Songs.Composer, Songs.Conductor, Songs.AmazonID, Songs.Lyrics, Songs.BPM, Songs.Version, Songs.playCount, Songs.skipCount, Songs.rating, Albums.Name AS Album, Albums.AlbumArtists, Albums.Year, Poolsongs.id FROM Poolsongs INNER JOIN Songs ON Poolsongs.idSong=Songs.id INNER JOIN Albums ON Albums.id=Songs.idAlbum WHERE Poolsongs.idPool=?" + String.Join(" AND ", wheres);
                if (order_by.Count() > 0) sqc.CommandText += " ORDER BY " + String.Join(", ", order_by);

                // Process the result: Create song objects
                using (SQLiteDataReader sqr = sqc.ExecuteReader())
                {
                    while (sqr.Read())
                    {
                        Song tempsong = new Song();
                        for (int i = 0; i < sqr.FieldCount; i++)
                        {
                            if (sqr.GetName(i) == "SID")
                                tempsong.id = Convert.ToUInt32(sqr.GetInt32(i));
                            else
                                tempsong[sqr.GetName(i)] = sqr.GetValue(i);
                        }
                        result.Add(tempsong);
                    }
                }
                return result;
            }
        }

        public string GetFileForSong(Song song)
        {
            //TODO: Don't simply take all audiofiles. The user might not want that.
            uint meta_id = ManageSongs(new Song[1] { song }, false)[0];
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "SELECT Path FROM Audiofiles WHERE idMeta=:idMeta";
                sqc.Parameters.Add(new SQLiteParameter("idMeta", meta_id));
                object result = sqc.ExecuteScalar();
                if (result == null)
                    return null;
                else
                    return (string)result;
            }
        }
        #endregion

        #region Remove Data
        public void RemoveSongsFromPool(Song song, int pool_id)
        {
            RemoveSongsFromPool(new Song[1] { song }, pool_id);
        }
        public void RemoveSongsFromPool(IEnumerable<Song> songs, int pool_id)
        {
            //TODO: Return the number of affected rows
            uint[] remove_ids = ManageSongs(songs, false);
            SQLiteTransaction sqt = connection.BeginTransaction();
            SQLiteCommand sqc = new SQLiteCommand(connection);
            sqc.CommandText = "DELETE FROM Poolsongs WHERE idSong=? AND idPool=?";
            sqc.Parameters.Add(new SQLiteParameter("idSong"));
            sqc.Parameters.Add(new SQLiteParameter("idPool", pool_id));
            for (int i = 0; i < remove_ids.Count(); i++)
            {
                sqc.Parameters["idSong"].Value = remove_ids[i];
                sqc.ExecuteNonQuery();
            }
            sqt.Commit();
        }

        public void ClearPool(int pool_id)
        {
            SQLiteCommand sqc = new SQLiteCommand(connection);
            sqc.CommandText = "DELETE FROM Poolsongs WHERE idPool=?";
            sqc.Parameters.Add(new SQLiteParameter("idPool", pool_id));
            sqc.ExecuteNonQuery();
        }
        #endregion


        #region Get IDs
        /// <summary>
        /// Simply get a songpool's id by the name.
        /// </summary>
        /// <param name="name">Name of the songpool.</param>
        /// <returns>Database index</returns>
        public int ID_Songpool(string name)
        {
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "SELECT id FROM Songpools WHERE Name=:Name";
                sqc.Parameters.Add(new SQLiteParameter("Name", name));
                return Convert.ToInt32(sqc.ExecuteScalar());
            }
        }
        #endregion
    }
}
