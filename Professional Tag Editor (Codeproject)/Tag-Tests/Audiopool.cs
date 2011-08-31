using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tag_Tests
{
    [Serializable]
    public class Audiopool
    {
        private List<Song> _songs;

        public Audiopool()
        {
            _songs = new List<Song>();
        }
        private Audiopool(IEnumerable<Song> songs)
        {
            _songs = new List<Song>(songs);
        }

        public List<Song> getSongs()
        {
            return _songs;
        }

        public Audiopool findSongs(List<MP_Filter> filters)
        {
            return findSongs(filters, this);
        }

        public Audiopool findSongs(List<MP_Filter> filters, Audiopool songs)
        {
            return findSongs(filters, songs, true);
        }

        /// <summary>
        /// The actual recursive incremental search. Filters until no more filters are left.
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="songs"></param>
        /// <returns></returns>
        private Audiopool findSongs(List<MP_Filter> filters, Audiopool songs, bool ignorecase)
        {
            var results = from song in songs.getSongs()
                          where CheckSong(filters[0], song, ignorecase)
                          select song;
            if (filters.Count > 1)
            {
                filters.RemoveAt(0);
                return findSongs(filters, new Audiopool(results));
            }
            else
                return new Audiopool(results);
        }

        public bool AddSong(Song song)
        {
            if (!_songs.Contains(song)) _songs.Add(song);
            else return false;
            return true;
        }

        private static bool CheckSong(MP_Filter filter, Song song, bool ignorecase)
        {
            switch (filter.Comparetype)
            {
                case MP_COMPARETYPE.equal:
                    return (ignorecase ? song.GetField(filter.Key).ToLower() : song.GetField(filter.Key)) == (ignorecase ? filter.Value.ToLower() : filter.Value);
                case MP_COMPARETYPE.similar:
                    return (ignorecase ? song.GetField(filter.Key).ToLower() : song.GetField(filter.Key)).Contains((ignorecase ? filter.Value.ToLower() : filter.Value));
                case MP_COMPARETYPE.startswith:
                    return (ignorecase ? song.GetField(filter.Key).ToLower() : song.GetField(filter.Key)).StartsWith((ignorecase ? filter.Value.ToLower() : filter.Value));
                case MP_COMPARETYPE.endswith:
                    return (ignorecase ? song.GetField(filter.Key).ToLower() : song.GetField(filter.Key)).EndsWith((ignorecase ? filter.Value.ToLower() : filter.Value));
                default:
                    throw new Exception("Some crazy stuff happened.");
            }
        }
    }
}
