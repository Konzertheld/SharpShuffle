using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ThePlayer
{
    [Serializable]
    public class Songpool
    {
        public string Name { get; private set; }

        #region Konstruktoren
        /// <summary>
        /// Create a songpool. A new songpool with the given name is automatically inserted into the database if necessary.
        /// </summary>
        /// <param name="name"></param>
        public Songpool(string name)
        {
            Name = name;
            Program.ActiveDatabase.ManageSongpool(name);
        }
        /// <summary>
        /// Create a songpool. A new songpool with the given name is automatically inserted into the database if necessary. The given songs are automatically added.
        /// </summary>
        /// <param name="songs"></param>
        /// <param name="name"></param>
        public Songpool(IEnumerable<Song> songs, string name)
            : this(name)
        {
            AddSongs(songs);
        }
        /// <summary>
        /// Create a songpool. A new songpool with the given name is automatically inserted into the database if necessary. The given songs are automatically added.
        /// </summary>
        /// <param name="songs"></param>
        /// <param name="name"></param>
        /// <param name="allow_duplicates"></param>
        public Songpool(IEnumerable<Song> songs, string name, bool allow_duplicates)
            : this(name)
        {
            AddSongs(songs, allow_duplicates);
        }
        #endregion

        #region Add and remove songs
        /// <summary>
        /// Add song, avoid duplicates.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public void AddSongs(Song song)
        {
            AddSongs(song, false);
        }
        /// <summary>
        /// Add song, duplicates optional.
        /// </summary>
        /// <param name="song"></param>
        /// <param name="allow_duplicates">Set to true if you want to insert the song even if it already exists in this pool.</param>
        /// <returns></returns>
        public void AddSongs(Song song, bool allow_duplicates)
        {
            // Looks awful but does not more than call PutSongsinPool, getting the song's id and the pool's id.
            Program.ActiveDatabase.PutSongsInPool(Program.ActiveDatabase.ManageSongs(song, false), Program.ActiveDatabase.ManageSongpool(this.Name), allow_duplicates);
        }
        public void AddSongs(IEnumerable<Song> songs)
        {
            AddSongs(songs, false);
        }
        public void AddSongs(IEnumerable<Song> songs, bool allow_duplicates)
        {
            Program.ActiveDatabase.PutSongsInPool(Program.ActiveDatabase.ManageSongs(songs, false), Program.ActiveDatabase.ManageSongpool(this.Name), allow_duplicates);
        }

        //TODO: Remove songs by id
        /// <summary>
        /// Removes all instances of a song in this pool using the same criteria as for avoiding duplicates when adding.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public void RemoveSongs(Song song)
        {
            Program.ActiveDatabase.RemoveSongsFromPool(song, Program.ActiveDatabase.ManageSongpool(Name));
        }
        public void RemoveSongs(IEnumerable<Song> songs)
        {
            Program.ActiveDatabase.RemoveSongsFromPool(songs, Program.ActiveDatabase.ManageSongpool(Name));
        }

        /// <summary>
        /// Remove all songs from this pool. Be careful, the change is automatically saved to the database!
        /// </summary>
        public void Clear()
        {
            Program.ActiveDatabase.ClearPool(Program.ActiveDatabase.ManageSongpool(Name));
        }
        #endregion

        #region Get Songs
        public Song getSongByPosition(int id)
        {
            return Program.ActiveDatabase.LoadSongs(Name)[id];
        }
        /// <summary>
        /// Get a list of songs from this pool, not filtered, not ordered, ignoring the case. Just get it.
        /// </summary>
        /// <returns></returns>
        public List<Song> getSongs()
        {
            return Program.ActiveDatabase.LoadSongs(Name);
        }

        /// <summary>
        /// Get a list of songs from this pool, not ordered, ignoring the case.
        /// </summary>
        /// <param name="filters">Filters to match.</param>
        /// <returns></returns>
        public List<Song> getSongs(List<MP_Filter> filters)
        {
            return getSongs(filters, true);
        }
        /// <summary>
        /// Get a filtered list of songs from this pool, not ordered.
        /// </summary>
        /// <param name="filters">Filters to match.</param>
        /// <returns></returns>
        public List<Song> getSongs(List<MP_Filter> filters, bool ignorecase)
        {
            return getSongs(filters, new List<string>(), ignorecase);
        }
        /// <summary>
        /// Get an ordered list of songs from this pool, not filtered, ignoring the case.
        /// </summary>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<string> orderby)
        {
            return getSongs(orderby, true);
        }
        /// <summary>
        /// Get an ordered list of songs from this pool, not filtered.
        /// </summary>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<string> orderby, bool ignorecase)
        {
            return getSongs(new List<MP_Filter>(), orderby, ignorecase);
        }
        /// <summary>
        /// Get a list of songs from this pool, ignoring the case.
        /// </summary>
        /// <param name="filters">Filters to match.</param>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<MP_Filter> filters, List<string> orderby)
        {
            return getSongs(filters, orderby, true);
        }
        /// <summary>
        /// Get a list of songs from this pool.
        /// </summary>
        /// <param name="filters">Filters to match.</param>
        /// <param name="songs">Songs to search in.</param>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<MP_Filter> filters, List<string> orderby, bool ignorecase)
        {
            //TODO: Decide if we want case-sensitive getSongs(). If yes, teach the database to do so.
            return Program.ActiveDatabase.LoadSongs(Name, orderby, filters);
        }
        #endregion

        public string[] ToArray()
        {
            List<Song> songs = Program.ActiveDatabase.LoadSongs(Name);
            string[] result = new string[songs.Count];
            for (int i = 0; i < songs.Count; i++)
                result[i] = songs[i].ToString();
            return result;
        }

        /// <summary>
        /// Get a list of artists, genres, whatever.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        /*public List<string> getList(META_IDENTIFIERS identifier)
        {
            List<string> result = new List<string>();
            foreach (Song song in _songs)
            {
                if (song.getInformation(identifier) != "" && !result.Contains(song.getInformation(identifier)))
                    result.Add(song.getInformation(identifier));
            }
            result = result.OrderBy(song => song).ToList();
            return result;
        }*/
    }
}
