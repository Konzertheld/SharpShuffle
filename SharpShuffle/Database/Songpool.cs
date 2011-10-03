﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Data.SQLite;

namespace SharpShuffle
{
    public class Songpool
    {
        public string Name { get; private set; }

        public Songpool (string name)
        {
            Startup.ActiveDB.CreateSongpool(name);
        }

        /// <summary>
        /// Add a single song to this pool. If the song already exists, this will do nothing.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public void AddSongs(Song song)
        {
            AddSongs(new Song[1] { song });
        }
        /// <summary>
        /// Add a list of songs to this pool. Songs that already are in the pool will be skipped without notification.
        /// </summary>
        /// <param name="songs"></param>
        public void AddSongs(IEnumerable<Song> songs)
        {
            Startup.ActiveDB.PutSongsInPool(songs, this.Name);
        }
        /// <summary>
        /// Add all the songs from another pool to this pool. Songs that already are in the pool will be skipped without notification.
        /// </summary>
        /// <param name="poolname"></param>
        public void AddSongs(string poolname)
        {
            Startup.ActiveDB.PoolMergeInPool(poolname, this.Name);
        }

        /// <summary>
        /// Will delete all songs from the pool without further notification.
        /// </summary>
        public void Clear()
        {
            Startup.ActiveDB.ClearPool(this.Name);
        }

        /*
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
        public List<Song> getSongs(List<Filter> filters)
        {
            return getSongs(filters, true);
        }
        /// <summary>
        /// Get a filtered list of songs from this pool, not ordered.
        /// </summary>
        /// <param name="filters">Filters to match.</param>
        /// <returns></returns>
        public List<Song> getSongs(List<Filter> filters, bool ignorecase)
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
            return getSongs(new List<Filter>(), orderby, ignorecase);
        }
        /// <summary>
        /// Get a list of songs from this pool, ignoring the case.
        /// </summary>
        /// <param name="filters">Filters to match.</param>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<Filter> filters, List<string> orderby)
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
        public List<Song> getSongs(List<Filter> filters, List<string> orderby, bool ignorecase)
        {
            //TODO: Decide if we want case-sensitive getSongs(). If yes, teach the database to do so.
            return Program.ActiveDatabase.LoadSongs(Name, orderby, filters);
        }
        #endregion

        //public string[] ToArray()
        //{
        //    List<Song> songs = Program.ActiveDatabase.LoadSongs(Name, new string[1] { "Poolsongs.id" });
        //    string[] result = new string[songs.Count];
        //    for (int i = 0; i < songs.Count; i++)
        //        result[i] = songs[i].ToString();
        //    return result;
        //}

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
