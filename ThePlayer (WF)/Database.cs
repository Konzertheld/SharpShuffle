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

        #region Insert and Check
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
        /// Returns the id for the given song. Inserts it before when not found.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public int[] ManageSongs(Song song)
        {
            return ManageSongs(song, true);
        }
        /// <summary>
        /// Returns the id for the given song. Optionally inserts it before when not found.
        /// </summary>
        /// <param name="song"></param>
        /// <param name="insert"></param>
        /// <returns></returns>
        public int[] ManageSongs(Song song, bool insert)
        {
            return ManageSongs(new Song[1] { song }, insert);
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
            // Alben laden bzw. anlegen
            songs = LinkSongsWithAlbums(songs);

            // Array anlegen für die IDs der angelegten / gefundenen Datensätze.
            int[] iResult = new int[songs.Count()];

            SQLiteTransaction sqt = connection.BeginTransaction();
            SQLiteCommand sqcCheck = new SQLiteCommand(connection);
            SQLiteCommand sqcInsert = new SQLiteCommand(connection);
            int i = 0;

            //TODO: 1. More and chosable criteria. 2. Do this with LoadSongs().
            sqcCheck.CommandText = "SELECT id FROM Songs WHERE Artists=? AND Title=?";
            sqcCheck.Parameters.Add(new SQLiteParameter("Artists"));
            sqcCheck.Parameters.Add(new SQLiteParameter("Title"));
            if (insert)
            {
                sqcInsert.CommandText = "INSERT INTO Songs (Artists, Title, Genre, idAlbum, TrackNr, Copyright, Conductor, Composer, Comment, AmazonID, Lyrics, BPM, Version, playCount, skipCount, rating) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
                sqcInsert.Parameters.Add(new SQLiteParameter("Artists"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Title"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Genre"));
                sqcInsert.Parameters.Add(new SQLiteParameter("idAlbum"));
                sqcInsert.Parameters.Add(new SQLiteParameter("TrackNr"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Copyright"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Conductor"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Composer"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Comment"));
                sqcInsert.Parameters.Add(new SQLiteParameter("AmazonID"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Lyrics"));
                sqcInsert.Parameters.Add(new SQLiteParameter("BPM"));
                sqcInsert.Parameters.Add(new SQLiteParameter("Version"));
                sqcInsert.Parameters.Add(new SQLiteParameter("playCount"));
                sqcInsert.Parameters.Add(new SQLiteParameter("skipCount"));
                sqcInsert.Parameters.Add(new SQLiteParameter("rating"));
            }

            foreach (Song song in songs)
            {
                object id;
                // Song schon eingetragen?
                sqcCheck.Parameters["Artists"].Value = song.getInformation(Song.META_ARTISTS);
                sqcCheck.Parameters["Title"].Value = song.getInformation(Song.META_TITLE);
                id = sqcCheck.ExecuteScalar();

                if (id == null && insert)
                {
                    // Nein, also eintragen (falls angegeben)
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
                    sqcInsert.ExecuteNonQuery();

                    // Und jetzt die ID holen (TODO: Iih. Das muss anders gehen.)
                    sqcCheck.Parameters["Artists"].Value = song.getInformation(Song.META_ARTISTS);
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

        public IEnumerable<Song> LinkSongsWithAlbums(IEnumerable<Song> songs)
        {
            List<Song> result = new List<Song>();
            foreach (Song song in songs)
            {
                if (song.Album != null && song.Album.getInformation(CAlbum.META_NAME) != "")
                    song.Album.id = ManageAlbums(song.Album, false);
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
        public int ManageAlbums(CAlbum album, bool case_sensitive)
        {
            SQLiteCommand sqc = new SQLiteCommand(connection);
            if (case_sensitive)
            {
                sqc.CommandText = "SELECT id FROM Albums WHERE Name=? AND AlbumArtists=? AND Year=?";
                sqc.Parameters.Add(new SQLiteParameter("Name", album.getInformation(CAlbum.META_NAME)));
                sqc.Parameters.Add(new SQLiteParameter("AlbumArtists", album.getInformation(CAlbum.META_ALBUMARTISTS)));
                sqc.Parameters.Add(new SQLiteParameter("Year", album.getInformation(CAlbum.META_YEAR)));
            }
            else
            {
                sqc.CommandText = "SELECT id FROM Albums WHERE LOWER(Name)=? AND LOWER(AlbumArtists)=? AND LOWER(Year)=?";
                sqc.Parameters.Add(new SQLiteParameter("Name", album.getInformation(CAlbum.META_NAME).ToLower()));
                sqc.Parameters.Add(new SQLiteParameter("AlbumArtists", album.getInformation(CAlbum.META_ALBUMARTISTS).ToLower()));
                sqc.Parameters.Add(new SQLiteParameter("Year", album.getInformation(CAlbum.META_YEAR).ToLower()));
            }
            object id = sqc.ExecuteScalar();
            if (id == null)
            {
                sqc.CommandText = "INSERT INTO Albums (Name, AlbumArtists, Year) VALUES (?, ?, ?)";
                if (!case_sensitive)
                {
                    // Don't insert lowercase album meta
                    sqc.Parameters.Clear();
                    sqc.Parameters.Add(new SQLiteParameter("Name", album.getInformation(CAlbum.META_NAME)));
                    sqc.Parameters.Add(new SQLiteParameter("AlbumArtists", album.getInformation(CAlbum.META_ALBUMARTISTS)));
                    sqc.Parameters.Add(new SQLiteParameter("Year", album.getInformation(CAlbum.META_YEAR)));
                }
                sqc.ExecuteNonQuery();
                return ManageAlbums(album, case_sensitive);
            }
            return Convert.ToInt32(id);
        }
        #endregion

        #region Load data
        public List<string> LoadSongpools()
        {
            List<string> result = new List<string>();
            SQLiteCommand sqc = new SQLiteCommand(connection);
            sqc.CommandText = "SELECT Name FROM Songpools";
            SQLiteDataReader sqr = sqc.ExecuteReader();
            while (sqr.Read())
                result.Add(sqr.GetString(0));
            return result;
        }

        public List<Song> LoadSongs(string poolname)
        {
            return LoadSongs(poolname, new List<string>());
        }
        public List<Song> LoadSongs(int id_pool)
        {
            return LoadSongs(id_pool, new List<string>());
        }
        public List<Song> LoadSongs(string poolname, IEnumerable<string> order_by)
        {
            return LoadSongs(ManageSongpool(poolname), order_by);
        }
        public List<Song> LoadSongs(int id_pool, IEnumerable<string> order_by)
        {
            return LoadSongs(id_pool, order_by, new List<MP_Filter>(), false);
        }
        public List<Song> LoadSongs(string poolname, IEnumerable<string> order_by, IEnumerable<MP_Filter> filters)
        {
            return LoadSongs(ManageSongpool(poolname), order_by, filters, false);
        }
        public List<Song> LoadSongs(int id_pool, IEnumerable<string> order_by, IEnumerable<MP_Filter> filters, bool case_sensitive)
        {
            // SELECT Songs.Artists, Songs.Title, Albums.Name, Songs.id FROM Songs LEFT JOIN Albums ON Songs.idAlbum=Albums.id WHERE LOWER(Songs.Artists)="wir sind helden"

            //TODO: Load all fields
            List<Song> result = new List<Song>();
            SQLiteCommand sqc = new SQLiteCommand(connection);

            // Process the filters to WHEREs
            List<string> wheres = new List<string>();
            foreach (MP_Filter f in filters)
            {
                if (case_sensitive)
                {
                    wheres.Add(((f.Not_Flag) ? "NOT " : "") + f.Key + f.Comparetype + "?");
                    sqc.Parameters.Add(new SQLiteParameter(f.Key, f.Value));
                }
                else
                {
                    wheres.Add(((f.Not_Flag) ? "NOT " : "") + "LOWER(" + f.Key + ")" + f.Comparetype + "?");
                    sqc.Parameters.Add(new SQLiteParameter(f.Key, f.Value.ToLower()));
                }
                break;
            }

            sqc.Parameters.Add(new SQLiteParameter("idPool", id_pool));

            sqc.CommandText = "SELECT Songs.Artists, Songs.Title, Songs.Genre, Songs.TrackNr, Songs.Copyright, Songs.Comment, Songs.Composer, Songs.Conductor, Songs.AmazonID, Songs.Lyrics, Songs.BPM, Songs.Version, Songs.playCount, Songs.skipCount, Songs.rating, Albums.Name AS Album, Albums.AlbumArtists, Albums.Year FROM Songs LEFT JOIN Albums ON Albums.id=Songs.idAlbum WHERE Songs.id IN (SELECT idSong FROM Poolsongs WHERE idPool=?)" + String.Join(" AND ", wheres);
            if (order_by.Count() > 0) sqc.CommandText += " ORDER BY " + String.Join(", ", order_by);

            // Process the result: Create song objects
            SQLiteDataReader sqr = sqc.ExecuteReader();
            while (sqr.Read())
            {
                Song tempsong = new Song();
                for (int i = 0; i < sqr.FieldCount; i++)
                    tempsong.setInformation(sqr.GetName(i), sqr.GetValue(i).ToString());
                result.Add(tempsong);
            }
            return result;
        }

        public string GetFileForSong(Song song)
        {
            //TODO: Don't simply take all audiofiles. The user might not want that.
            List<Song> templist = new List<Song>();
            templist.Add(song);
            int meta_id = ManageSongs(templist, false)[0];
            SQLiteCommand c = new SQLiteCommand(connection);
            c.CommandText = "SELECT Path FROM Audiofiles WHERE idMeta=?";
            SQLiteParameter p1 = new SQLiteParameter();
            p1.Value = meta_id;
            c.Parameters.Add(p1);
            object result = c.ExecuteScalar();
            if (result == null)
                return null;
            else
                return (string)result;
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

        #region DB functions
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


    }
}
