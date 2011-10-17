using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace SharpShuffle
{
    class Database
    {
        private SQLiteConnection connection;

        public Database(string path)
        {
            connection = new SQLiteConnection("Data Source=" + path);
            connection.Open();
        }

        #region Database methods
        public void CloseDB()
        {
            connection.Close();
        }

        public void ClearDB()
        {
            using (SQLiteCommand c = new SQLiteCommand(connection))
            {
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
                c.CommandText = "DELETE FROM sqlite_sequence WHERE name='Songs' OR name='Songpools' OR name='Poolsongs' OR name='Audiofiles' OR name='Albums'";
                c.ExecuteNonQuery();
                c.CommandText = "VACUUM";
                c.ExecuteNonQuery();
            }
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
        /// Inserts songs into the database (only not existing). Returns the input list with ids set.
        /// </summary>
        /// <param name="songs"></param>
        /// <returns></returns>
        public IEnumerable<Song> InsertSongs(IEnumerable<Song> songs)
        {
            using (SQLiteTransaction sqt = connection.BeginTransaction())
            {
                // Alben laden bzw. anlegen
                foreach (Song song in songs)
                {
                    if (song.Album != null && song.Album.Name != "")
                        song.Album.id = InsertAlbum(song.Album);
                }

                using (SQLiteCommand sqcInsert = new SQLiteCommand(connection))
                {
                    // Parameter und Query vorbereiten
                    string[] parameters = Enum.GetNames(typeof(SONGMETA));
                    string[] namedparameters = new string[parameters.Count()];

                    for (ushort j = 0; j < parameters.Count(); j++)
                    {
                        sqcInsert.Parameters.Add(new SQLiteParameter(parameters[j]));
                        namedparameters[j] = ":" + parameters[j];
                    }
                    sqcInsert.Parameters.Add(new SQLiteParameter("idAlbum"));
                    sqcInsert.CommandText = "INSERT INTO Songs (idAlbum, " + String.Join(", ", parameters) + ") SELECT :idAlbum, " + String.Join(", ", namedparameters) + " WHERE NOT EXISTS(SELECT id FROM Songs WHERE LOWER(Artists)=LOWER(:Artists) AND LOWER(Title)=LOWER(:Title) AND LOWER(Version)=LOWER(:Version))";

                    // Für jeden Song Parameter setzen und Query ausführen
                    foreach (Song song in songs)
                    {
                        if (song.id == 0)
                        {
                            // If the id is 0, assume the song is not yet in the database. Fill all the parameters, execute the query and save the id.
                            for (ushort j = 0; j < parameters.Count(); j++)
                            {
                                sqcInsert.Parameters[parameters[j]].Value = song[parameters[j]];
                            }

                            if (song.Album != null && song.Album.id != 0)
                                sqcInsert.Parameters["idAlbum"].Value = song.Album.id;
                            else
                                sqcInsert.Parameters["idAlbum"].Value = null;

                            if (sqcInsert.ExecuteNonQuery() > 0)
                                song.id = Convert.ToUInt32(new SQLiteCommand("SELECT last_insert_rowid()", connection).ExecuteScalar());

                            // If the id is still empty at this point, the song was not inserted because it already existed. The ID remains 0
                            // so whatever called InsertSongs() has to check itself which were newly inserted.
                        }
                    }
                }
                sqt.Commit();
                return songs;
            }
        }

        /// <summary>
        /// Put songs in a pool. Songs that already are in the pool are skipped.
        /// </summary>
        /// <param name="song_ids"></param>
        /// <param name="poolname">Name of the target pool. Must exist!</param>
        public void PutSongsInPool(uint[] song_ids, string poolname)
        {
            using (SQLiteTransaction sqt = connection.BeginTransaction())
            {
                using (SQLiteCommand sqcInsert = new SQLiteCommand(connection))
                {
                    sqcInsert.CommandText = "INSERT INTO Poolsongs (idSong, idPool) SELECT :idSong, (SELECT id FROM Songpools WHERE Name=:Pool) WHERE NOT :idSong IN (SELECT idSong FROM Poolsongs WHERE idPool=:idTarget)";
                    sqcInsert.Parameters.Add(new SQLiteParameter("idSong"));
                    sqcInsert.Parameters.Add(new SQLiteParameter("Pool", poolname));
                    for (int i = 0; i < song_ids.Count(); i++)
                    {
                        sqcInsert.Parameters["idSong"].Value = song_ids[i];
                        sqcInsert.ExecuteNonQuery();
                    }
                }
                sqt.Commit();
            }
        }
        /// <summary>
        /// Put songs in a pool. Songs that already are in the pool are skipped. Songs that don't have their id set are also skipped.
        /// </summary>
        /// <param name="songs"></param>
        /// <param name="poolname">Name of the target pool. Must exist!</param>
        public void PutSongsInPool(IEnumerable<Song> songs, string poolname)
        {
            using (SQLiteTransaction sqt = connection.BeginTransaction())
            {
                using (SQLiteCommand sqcInsert = new SQLiteCommand(connection))
                {
                    sqcInsert.CommandText = "INSERT INTO Poolsongs (idSong, idPool) SELECT :idSong, (SELECT id FROM Songpools WHERE Name=:Pool) WHERE NOT :idSong IN (SELECT idSong FROM Poolsongs WHERE idPool=(SELECT id FROM Songpools WHERE Name=:Pool))";
                    sqcInsert.Parameters.Add(new SQLiteParameter("idSong"));
                    sqcInsert.Parameters.Add(new SQLiteParameter("Pool", poolname));
                    foreach (Song song in songs)
                    {
                        if (song.id != 0)
                        {
                            sqcInsert.Parameters["idSong"].Value = song.id;
                            sqcInsert.ExecuteNonQuery();
                        }
                    }
                }
                sqt.Commit();
            }
        }

        /// <summary>
        /// Insert audiofiles into the database. Make sure the song's id is set to avoid putting strange stuff into your database. If the given path is existing, it is updated with the given song.
        /// </summary>
        /// <param name="scannedfiles">A dictionary containing the read meta associated with the paths.</param>
        public void ManageAudiofiles(Dictionary<string, Song> scannedfiles)
        {
            using (SQLiteTransaction sqt = connection.BeginTransaction())
            {
                using (SQLiteCommand sqc = new SQLiteCommand(connection))
                {
                    sqc.CommandText = "INSERT OR IGNORE INTO Audiofiles (Path, idMeta) VALUES (:Path, :idMeta); UPDATE Audiofiles SET idMeta=:idMeta WHERE Path=:Path";
                    sqc.Parameters.Add(new SQLiteParameter("Path"));
                    sqc.Parameters.Add(new SQLiteParameter("idMeta"));
                    foreach (string path in scannedfiles.Keys)
                    {
                        sqc.Parameters["Path"].Value = path;
                        sqc.Parameters["idMeta"].Value = scannedfiles[path].id;
                        sqc.ExecuteNonQuery();
                    }
                }
                sqt.Commit();
            }
        }

        /// <summary>
        /// Get an album's id. Insert the album if necessary.
        /// </summary>
        /// <param name="albumname"></param>
        /// <param name="case_sensitive"></param>
        /// <returns></returns>
        public uint InsertAlbum(CAlbum album)
        {
            if (album.Name == null || album.Name.Trim() == "") return 0;
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "INSERT INTO Albums (Name, AlbumArtists, TrackCount, Year) SELECT :Name, :AlbumArtists, :TrackCount, :Year WHERE NOT EXISTS(SELECT id FROM Albums WHERE LOWER(Name)=LOWER(:Name) AND LOWER(AlbumArtists)=LOWER(:AlbumArtists) AND TrackCount=:TrackCount AND Year=:Year)";
                sqc.Parameters.Add(new SQLiteParameter("Name", album.Name));
                sqc.Parameters.Add(new SQLiteParameter("AlbumArtists", album.AlbumArtists));
                sqc.Parameters.Add(new SQLiteParameter("TrackCount", album.TrackCount));
                sqc.Parameters.Add(new SQLiteParameter("Year", album.Year));

                if (sqc.ExecuteNonQuery() > 0)
                    return Convert.ToUInt32(new SQLiteCommand("SELECT last_insert_rowid()", connection).ExecuteScalar());
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

        /// <summary>
        /// Load all the songs from a pool.
        /// </summary>
        /// <param name="poolname"></param>
        /// <returns></returns>
        public List<Song> LoadSongs(string poolname)
        {
            return LoadSongs(poolname, new string[0], new Filter[0]);
        }
        /// <summary>
        /// Load all the songs from a pool, ordered and filtered if you want.
        /// </summary>
        /// <param name="poolname"></param>
        /// <param name="order_by"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
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

                sqc.CommandText = "SELECT Songs.id AS SID, Songs.Artists, Songs.Title, Songs.Genres, Songs.TrackNr, Songs.Copyright, Songs.Comment, Songs.Composer, Songs.Conductor, Songs.Lyrics, Songs.BPM, Songs.Version, Songs.PlayCount, Songs.SkipCount, Songs.Rating, Albums.id AS AID, Albums.Name AS Album, Albums.AlbumArtists, Albums.TrackCount, Albums.Year FROM Poolsongs INNER JOIN Songs ON Poolsongs.idSong=Songs.id INNER JOIN Albums ON Albums.id=Songs.idAlbum WHERE Poolsongs.idPool=(SELECT id FROM Songpools WHERE Songpools.Name=:Poolname)" + String.Join(" AND ", wheres);
                sqc.Parameters.Add(new SQLiteParameter("Poolname", poolname));
                if (order_by.Count() > 0) sqc.CommandText += " ORDER BY " + String.Join(", ", order_by);

                // Process the result: Create song objects
                using (SQLiteDataReader sqr = sqc.ExecuteReader())
                {
                    while (sqr.Read())
                    {
                        Song tempsong = new Song();
                        for (int i = 0; i < sqr.FieldCount; i++)
                        {
                            if (!sqr.IsDBNull(i))
                            {
                                switch (sqr.GetName(i))
                                {
                                    case "SID":
                                        tempsong.id = Convert.ToUInt32(sqr.GetInt32(i));
                                        break;
                                    case "AID":
                                        if (tempsong.Album == null)
                                            tempsong.Album = new CAlbum();
                                        tempsong.Album.id = Convert.ToUInt32(sqr.GetValue(i));
                                        break;
                                    case "Album":
                                        if (tempsong.Album == null)
                                            tempsong.Album = new CAlbum();
                                        tempsong.Album.Name = (string)sqr.GetValue(i);
                                        break;
                                    case "AlbumArtists":
                                    case "TrackCount":
                                    case "Year":
                                        if (tempsong.Album != null)
                                            tempsong.Album[sqr.GetName(i)] = sqr.GetValue(i);
                                        break;
                                    default:
                                        tempsong[sqr.GetName(i)] = sqr.GetValue(i);
                                        break;
                                }
                            }
                        }
                        result.Add(tempsong);
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Get all the song ids for a pool. In cases where you don't need all the meta this is faster.
        /// </summary>
        /// <param name="poolname"></param>
        /// <returns></returns>
        public uint[] LoadSongIDs(string poolname)
        {
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "SELECT idSong FROM Poolsongs WHERE idPool=(SELECT id FROM Songpools WHERE Name=:Name)";
                sqc.Parameters.Add(new SQLiteParameter("Name", poolname));
                using (SQLiteDataReader sqr = sqc.ExecuteReader())
                {
                    int i = 0;
                    List<uint> result = new List<uint>();
                    while (sqr.Read())
                    {
                        result.Add(Convert.ToUInt32(sqr.GetValue(i)));
                        i++;
                    }
                    return result.ToArray();
                }
            }
        }

        /// <summary>
        /// Get all the song ids for a list of songs. Useful for songs that were skipped inserting because they already existed.
        /// </summary>
        /// <param name="songs"></param>
        /// <returns></returns>
        public IEnumerable<Song> LoadSongIDs(IEnumerable<Song> songs)
        {
            using (SQLiteTransaction sqt = connection.BeginTransaction())
            {
                using (SQLiteCommand sqc = new SQLiteCommand(connection))
                {
                    sqc.CommandText = "SELECT id FROM Songs WHERE LOWER(Artists)=LOWER(:Artists) AND LOWER(Title)=LOWER(:Title) AND LOWER(Version)=LOWER(:Version)";
                    foreach (Song song in songs)
                    {
                        sqc.Parameters.Add(new SQLiteParameter("Artists", song.Artists));
                        sqc.Parameters.Add(new SQLiteParameter("Title", song.Title));
                        sqc.Parameters.Add(new SQLiteParameter("Version", song.Version));
                        song.id = Convert.ToUInt32(sqc.ExecuteScalar());
                    }
                }
            }
            return songs;
        }

        /// <summary>
        /// Get the id for a single song.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public uint LoadSongID(Song song)
        {
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "SELECT id FROM Songs WHERE Artists=:Artists AND Title=:Title AND Version=:Version";
                sqc.Parameters.Add(new SQLiteParameter("Artists", song.Artists));
                sqc.Parameters.Add(new SQLiteParameter("Title", song.Title));
                sqc.Parameters.Add(new SQLiteParameter("Version", song.Version));
                return Convert.ToUInt32(sqc.ExecuteScalar());
            }
        }

        /// <summary>
        /// Get an audiofile path associated with the meta entry for a given song.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public string GetFileForSong(Song song)
        {
            if (song.id == 0) throw new Exception("Für einen Song, dessen ID nicht geladen ist, kann kein Audiofile gesucht werden.");
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                //TODO: Don't simply take all audiofiles. The user might not want that.
                sqc.CommandText = "SELECT Path FROM Audiofiles WHERE idMeta=:idMeta";
                sqc.Parameters.Add(new SQLiteParameter("idMeta", song.id));
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
            /*uint[] remove_ids = ManageSongs(songs, false);
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
            sqt.Commit();*/
        }

        public void ClearPool(string poolname)
        {
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "DELETE FROM Poolsongs WHERE idPool=(SELECT id FROM Songpools WHERE Name=:Name)";
                sqc.Parameters.Add(new SQLiteParameter("Name", poolname));
                sqc.ExecuteNonQuery();
            }
        }
        #endregion

        #region Update Data
        /// <summary>
        /// Update song meta. Songs are identified using their artist-title-version combination.
        /// </summary>
        /// <param name="songs"></param>
        /// <returns></returns>
        public IEnumerable<Song> UpdateSongs(IEnumerable<Song> songs)
        {
            using (SQLiteTransaction sqt = connection.BeginTransaction())
            {
                using (SQLiteCommand sqc = new SQLiteCommand(connection))
                {
                    // Alben laden bzw. anlegen
                    foreach (Song song in songs)
                    {
                        if (song.Album != null && song.Album.Name != "")
                            song.Album.id = InsertAlbum(song.Album);
                    }

                    // Parameter und Query vorbereiten
                    string[] parameters = Enum.GetNames(typeof(SONGMETA));
                    string[] valueparts = new string[parameters.Count()];

                    for (ushort j = 0; j < parameters.Count(); j++)
                    {
                        sqc.Parameters.Add(new SQLiteParameter(parameters[j]));
                        valueparts[j] = parameters[j] + "=" + ":" + parameters[j];
                    }
                    sqc.Parameters.Add(new SQLiteParameter("idAlbum"));
                    sqc.CommandText = "UPDATE Songs SET idAlbum=:idAlbum, " + String.Join(", ", valueparts) + " WHERE LOWER(Artists)=LOWER(:Artists) AND LOWER(Title)=LOWER(:Title) AND LOWER(Version)=LOWER(:Version)";

                    // Für jeden Song Parameter setzen und Query ausführen
                    foreach (Song song in songs)
                    {
                        for (ushort j = 0; j < parameters.Count(); j++)
                        {
                            sqc.Parameters[parameters[j]].Value = song[parameters[j]];
                        }

                        if (song.Album != null && song.Album.id != 0)
                            sqc.Parameters["idAlbum"].Value = song.Album.id;
                        else
                            sqc.Parameters["idAlbum"].Value = null;
                        sqc.ExecuteNonQuery();
                    }
                }
                sqt.Commit();
            }
            return songs;
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
