﻿using System;
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
            // Alben laden bzw. anlegen
            SQLiteTransaction sqt = connection.BeginTransaction();
            if (insert) songs = LinkSongsWithAlbums(songs);

            // Array anlegen für die IDs der angelegten / gefundenen Datensätze.
            int[] iResult = new int[songs.Count()];

            SQLiteCommand sqcCheck = new SQLiteCommand(connection);
            //TODO: 1. More and chosable criteria. 2. Do this with LoadSongs().
            sqcCheck.CommandText = "SELECT id FROM Songs WHERE Artists=:Artists AND Title=:Title";
            sqcCheck.Parameters.Add(new SQLiteParameter("Artists"));
            sqcCheck.Parameters.Add(new SQLiteParameter("Title"));

            SQLiteCommand sqcInsert = new SQLiteCommand(connection);
            int i = 0;

            if (insert)
            {
                string[] parameters = new string[16] { "Artists", "Title", "Genre", "idAlbum", "TrackNr", "Copyright", "Conductor", "Composer", "Comment", "AmazonID", "Lyrics", "BPM", "Version", "playCount", "skipCount", "rating" };
                string[] namedparams = new string[parameters.Count()];
                for (int j = 0; j < parameters.Count(); j++)
                {
                    namedparams[j] = ":" + parameters[j];
                    sqcInsert.Parameters.Add(new SQLiteParameter(parameters[j]));
                }
                sqcInsert.Parameters.Add(new SQLiteParameter("lArtists"));
                sqcInsert.Parameters.Add(new SQLiteParameter("lTitle"));
                //TODO: Make artist, title etc chosable as always
                sqcInsert.CommandText = "INSERT INTO Songs (" + String.Join(", ", parameters) + ") SELECT " + String.Join(", ", namedparams) + " WHERE NOT EXISTS(SELECT id FROM Songs WHERE LOWER(Artists)=:lArtists AND LOWER(Title)=:lTitle)";
            }

            foreach (Song song in songs)
            {
                object id = null;
                //TODO: Überlegen, ob es Fälle gibt, in denen ein Song eine ID hat, obwohl er nicht mit dieser ID in der Datenbank ist
                if (song.id != 0)
                    id = song.id;
                else
                {
                    if (insert)
                    {
                        sqcInsert.Parameters["Artists"].Value = song.getInformation(Song.META_ARTISTS);
                        sqcInsert.Parameters["Title"].Value = song.getInformation(Song.META_TITLE);
                        sqcInsert.Parameters["Genre"].Value = song.getInformation(Song.META_GENRES);
                        if (song.Album != null)
                            sqcInsert.Parameters["idAlbum"].Value = song.Album.id;
                        else
                            sqcInsert.Parameters["idAlbum"].Value = null;
                        sqcInsert.Parameters["TrackNr"].Value = song.getInformation(Song.META_TRACK);
                        sqcInsert.Parameters["Copyright"].Value = song.getInformation(Song.META_COPYRIGHT);
                        sqcInsert.Parameters["Conductor"].Value = song.getInformation(Song.META_CONDUCTOR);
                        sqcInsert.Parameters["Composer"].Value = song.getInformation(Song.META_COMPOSERS);
                        sqcInsert.Parameters["Comment"].Value = song.getInformation(Song.META_COMMENT);
                        sqcInsert.Parameters["AmazonID"].Value = song.getInformation(Song.META_AMAZON);
                        sqcInsert.Parameters["Lyrics"].Value = song.getInformation(Song.META_LYRICS);
                        sqcInsert.Parameters["BPM"].Value = song.getInformation(Song.META_BPM);
                        sqcInsert.Parameters["Version"].Value = song.getInformation(Song.META_VERSION);
                        sqcInsert.Parameters["playCount"].Value = song.getInformation(Song.META_PLAYCOUNT);
                        sqcInsert.Parameters["skipCount"].Value = song.getInformation(Song.META_SKIPCOUNT);
                        sqcInsert.Parameters["rating"].Value = song.getInformation(Song.META_RATING);
                        sqcInsert.Parameters["lArtists"].Value = song.getInformation(Song.META_ARTISTS).ToLower();
                        sqcInsert.Parameters["lTitle"].Value = song.getInformation(Song.META_TITLE).ToLower();

                        if (sqcInsert.ExecuteNonQuery() > 0)
                            id = new SQLiteCommand("SELECT last_insert_rowid()", connection).ExecuteScalar();
                    }
                    if (!insert || id == null)
                    {
                        sqcCheck.Parameters["Artists"].Value = song.getInformation(Song.META_ARTISTS);
                        sqcCheck.Parameters["Title"].Value = song.getInformation(Song.META_TITLE);
                        id = sqcCheck.ExecuteScalar();
                    }
                    if (id == null)
                        id = -1;
                }
                // ID eintragen (entweder von existierendem Datensatz oder von neu eingefügtem)
                iResult[i] = Convert.ToInt32(id);
                i++;
            }

            sqt.Commit();
            return iResult;
        }

        public IEnumerable<Song> LinkSongsWithAlbums(IEnumerable<Song> songs)
        {
            List<Song> result = new List<Song>();
            foreach (Song song in songs)
            {
                if (song.Album != null && song.Album.getInformation(CAlbum.META_NAME) != "")
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
        public void PutSongsInPool(int[] song_ids, int pool_id)
        {
            PutSongsInPool(song_ids, pool_id, false);
        }
        /// <summary>
        /// Connect songs with a pool.
        /// </summary>
        /// <param name="song_ids"></param>
        /// <param name="pool_id"></param>
        public void PutSongsInPool(int[] song_ids, int pool_id, bool allow_duplicates)
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
        public void PutSongsInPool(IEnumerable<Song> songs, int pool_id)
        {
            PutSongsInPool(songs, pool_id, false);
        }
        public void PutSongsInPool(IEnumerable<Song> songs, int pool_id, bool allow_duplicates)
        {
            var ids = from s in songs
                      where s.id != 0
                      select s.id;
            var unknownsongs = from s in songs
                               where s.id == 0
                               select s;
            int[] nowknownids = ManageSongs(unknownsongs, false);
            int[] idstouse = new int[ids.Count() + nowknownids.Count()];
            nowknownids.CopyTo(idstouse, 0);
            ((int[])ids).CopyTo(idstouse, nowknownids.Count());
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
        public int InsertAlbum(CAlbum album)
        {
            using (SQLiteCommand sqc = new SQLiteCommand(connection))
            {
                sqc.CommandText = "INSERT INTO Albums (Name, AlbumArtists, Year) SELECT ?, ?, ? WHERE NOT EXISTS(SELECT id FROM Albums WHERE LOWER(Name)=? AND LOWER(AlbumArtists)=? AND Year=?)";
                sqc.Parameters.Add(new SQLiteParameter(null, album.getInformation(CAlbum.META_NAME)));
                sqc.Parameters.Add(new SQLiteParameter(null, album.getInformation(CAlbum.META_ALBUMARTISTS)));
                sqc.Parameters.Add(new SQLiteParameter(null, album.getInformation(CAlbum.META_YEAR)));
                sqc.Parameters.Add(new SQLiteParameter("Name", album.getInformation(CAlbum.META_NAME).ToLower()));
                sqc.Parameters.Add(new SQLiteParameter("AlbumArtists", album.getInformation(CAlbum.META_ALBUMARTISTS).ToLower()));
                sqc.Parameters.Add(new SQLiteParameter("Year", album.getInformation(CAlbum.META_YEAR)));

                int i = sqc.ExecuteNonQuery();
                if (i > 0)
                {
                    object id = new SQLiteCommand("SELECT last_insert_rowid()", connection).ExecuteScalar();
                    return Convert.ToInt32(id);
                }
                else
                {
                    sqc.CommandText = "SELECT id FROM Albums WHERE LOWER(Name)=? AND LOWER(AlbumArtists)=? AND Year=?";
                    sqc.Parameters.Clear();
                    sqc.Parameters.Add(new SQLiteParameter("Name", album.getInformation(CAlbum.META_NAME).ToLower()));
                    sqc.Parameters.Add(new SQLiteParameter("AlbumArtists", album.getInformation(CAlbum.META_ALBUMARTISTS).ToLower()));
                    sqc.Parameters.Add(new SQLiteParameter("Year", album.getInformation(CAlbum.META_YEAR)));
                    return Convert.ToInt32(sqc.ExecuteScalar());
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
                SQLiteDataReader sqr = sqc.ExecuteReader();
                while (sqr.Read())
                {
                    Song tempsong = new Song();
                    for (int i = 0; i < sqr.FieldCount; i++)
                    {
                        if (sqr.GetName(i) == "SID")
                            tempsong.id = sqr.GetInt32(i);
                        else
                            tempsong.setInformation(sqr.GetName(i), sqr.GetValue(i).ToString());
                    }
                    result.Add(tempsong);
                }
                return result;
            }
        }

        public string GetFileForSong(Song song)
        {
            //TODO: Don't simply take all audiofiles. The user might not want that.
            int meta_id = ManageSongs(new Song[1] { song }, false)[0];
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
            int[] remove_ids = ManageSongs(songs, false);
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