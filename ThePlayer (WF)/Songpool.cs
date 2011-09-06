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
        private List<Song> _songs;
        public string Name { get; set; }

        #region Konstruktoren
        public Songpool()
        {
            _songs = new List<Song>();
        }
        public Songpool(IEnumerable<Song> songs)
        {
            _songs = new List<Song>(songs);
        }
        public Songpool(IEnumerable<Song> songs, string name)
            : this(songs)
        {
            Name = name;
        }
        #endregion

        /// <summary>
        /// Add song, avoid duplicates.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        public bool AddSong(Song song)
        {
            return AddSong(song, false);
        }
        /// <summary>
        /// Add song, duplicates optional.
        /// </summary>
        /// <param name="song"></param>
        /// <param name="allow_duplicates">Set to true if you want to insert the song even if it already exists in this pool.</param>
        /// <returns></returns>
        public bool AddSong(Song song, bool allow_duplicates)
        {
            if (!_songs.Contains(song)) _songs.Add(song);
            else return false;
            return true;
        }

        /// <summary>
        /// Get a list of songs from this pool, not filtered, not ordered, ignoring the case. Just get it.
        /// </summary>
        /// <returns></returns>
        public List<Song> getSongs()
        {
            return _songs;
        }

        #region Get Songs
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
            return getSongs(filters, _songs, new List<META_IDENTIFIERS>(), ignorecase);
        }
        /// <summary>
        /// Get an ordered list of songs from this pool, not filtered, ignoring the case.
        /// </summary>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<META_IDENTIFIERS> orderby)
        {
            return getSongs(orderby, true);
        }
        /// <summary>
        /// Get an ordered list of songs from this pool, not filtered.
        /// </summary>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<META_IDENTIFIERS> orderby, bool ignorecase)
        {
            return getSongs(new List<MP_Filter>(), _songs, orderby, ignorecase);
        }
        /// <summary>
        /// Get a list of songs from this pool, ignoring the case.
        /// </summary>
        /// <param name="filters">Filters to match.</param>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<MP_Filter> filters, List<META_IDENTIFIERS> orderby)
        {
            return getSongs(filters, orderby, true);
        }
        /// <summary>
        /// Get a list of songs from this pool.
        /// </summary>
        /// <param name="filters">Filters to match.</param>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<MP_Filter> filters, List<META_IDENTIFIERS> orderby, bool ignorecase)
        {
            return getSongs(filters, _songs, new List<META_IDENTIFIERS>(), ignorecase);
        }
        /// <summary>
        /// Get a list of songs.
        /// </summary>
        /// <param name="filters">Filters to match.</param>
        /// <param name="songs">Songs to search in.</param>
        /// <param name="orderby">A list of meta identifiers to order by (in the order of appearance).</param>
        /// <returns></returns>
        public List<Song> getSongs(List<MP_Filter> filters, List<Song> songs, List<META_IDENTIFIERS> orderby, bool ignorecase)
        {
            if (filters.Count > 0)
            {
                var results = songs
                              .Where(song => CheckSong(filters[0], song, ignorecase))
                              .OrderBy(song => song, new SongComparer(orderby, ignorecase))
                              .Select(song => song);
                if (filters.Count > 1)
                {
                    filters.RemoveAt(0);
                    return getSongs(filters, new List<Song>(results), orderby, ignorecase);
                }
                else
                    return new List<Song>(results);
            }
            else
            {
                var results = songs
                              .OrderBy(song => song, new SongComparer(orderby))
                              .Select(song => song);
                return new List<Song>(results);
            }
        }
        #endregion

        /// <summary>
        /// Get a list of artists, genres, whatever.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public List<string> getList(META_IDENTIFIERS identifier)
        {
            List<string> result = new List<string>();
            foreach (Song song in _songs)
            {
                if (song.getInformation(identifier) != "" && !result.Contains(song.getInformation(identifier)))
                    result.Add(song.getInformation(identifier));
            }
            result = result.OrderBy(song => song).ToList();
            return result;
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

        #region Save and load
        public bool Save()
        {
            //TODO: Throw exception when pool has no name
            XmlWriter xw = XmlWriter.Create(Program.GlobalConfig.Appdatapath + "\\songpools\\" + Name + ".xml", Program.GlobalConfig.XmlSettings);
            xw.WriteStartDocument();
            xw.WriteStartElement("Songpool");
            xw.WriteAttributeString("Name", Name);
            foreach (Song song in _songs)
            {
                xw.WriteStartElement("Song");
                foreach (KeyValuePair<META_IDENTIFIERS, string> i in song.AllTheInformation())
                {
                    xw.WriteAttributeString(i.Key.ToString(), i.Value);
                }
                xw.WriteEndElement();
            }
            xw.WriteEndElement();
            xw.WriteEndDocument();
            xw.Close();
            return true;
        }

        public static Songpool Load(string file)
        {
            Songpool result = new Songpool();
            //TODO: Validation before loading
            XElement x = XElement.Load(file);
            result.Name = x.Attribute("Name").Value;

            foreach (XElement song in x.Descendants("Song"))
            {
                Song songobject = new Song();
                foreach (XAttribute meta in song.Attributes())
                {
                    songobject.setInformation((META_IDENTIFIERS)Enum.Parse(typeof(META_IDENTIFIERS), meta.Name.LocalName), meta.Value);
                }
            }

            return result;
        }
        #endregion
    }
}
