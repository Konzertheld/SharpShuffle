using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    [Serializable]
    public class Songpool
    {
        private List<Song> _songs;

        public Songpool()
        {
            _songs = new List<Song>();
        }
        public Songpool(IEnumerable<Song> songs)
        {
            _songs = new List<Song>(songs);
        }

        public List<Song> getSongs()
        {
            return _songs;
        }

        public Songpool findSongs(MP_Filter filter)
        {
            List<MP_Filter> filters = new List<MP_Filter>();
            filters.Add(filter);
            return findSongs(filters);
        }
        public Songpool findSongs(List<MP_Filter> filters)
        {
            return findSongs(filters, this, true);
        }

        /// <summary>
        /// The actual recursive incremental search. Filters until no more filters are left.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="songs"></param>
        /// <returns></returns>
        private Songpool findSongs(List<MP_Filter> filters, Songpool songs, bool ignorecase)
        {
            var results = from song in songs.getSongs()
                          where CheckSong(filters[0], song, ignorecase)
                          select song;
            if (filters.Count > 1)
            {
                filters.RemoveAt(0);
                return findSongs(filters, new Songpool(results), ignorecase);
            }
            else
                return new Songpool(results);
        }

        /// <summary>
        /// Get a list of artists, genres, whatever.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public List<string> getList(string identifier)
        {
            List<string> result = new List<string>();
            foreach (Song song in _songs)
            {
                if(song.getInformation(identifier) != "" && !result.Contains(song.getInformation(identifier)))
                    result.Add(song.getInformation(identifier));
            }
            result = result.OrderBy(song => song).ToList();
            return result;
        }

        /// <summary>
        /// Add songs here to avoid duplicates.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public bool AddSong(Song song)
        {
            if (!_songs.Contains(song)) _songs.Add(song);
            else return false;
            return true;
        }

        /// <summary>
        /// Helpermethod: Check if a song matches a filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="song"></param>
        /// <param name="ignorecase"></param>
        /// <returns></returns>
        private static bool CheckSong(MP_Filter filter, Song song, bool ignorecase)
        {
            switch (filter.Comparetype)
            {
                case MP_COMPARETYPE.equal:
                    return (ignorecase ? song.getInformation(filter.Key).ToLower() : song.getInformation(filter.Key)) == (ignorecase ? filter.Value.ToLower() : filter.Value);
                case MP_COMPARETYPE.similar:
                    return (ignorecase ? song.getInformation(filter.Key).ToLower() : song.getInformation(filter.Key)).Contains((ignorecase ? filter.Value.ToLower() : filter.Value));
                case MP_COMPARETYPE.startswith:
                    return (ignorecase ? song.getInformation(filter.Key).ToLower() : song.getInformation(filter.Key)).StartsWith((ignorecase ? filter.Value.ToLower() : filter.Value));
                case MP_COMPARETYPE.endswith:
                    return (ignorecase ? song.getInformation(filter.Key).ToLower() : song.getInformation(filter.Key)).EndsWith((ignorecase ? filter.Value.ToLower() : filter.Value));
                default:
                    throw new Exception("Some crazy stuff happened.");
            }
        }
    }
}
