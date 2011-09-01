using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    [Serializable]
    public class Song
    {
        private Dictionary<META_IDENTIFIERS, string> _allTheInformation;

        #region Static stuff
        //TODO: Übersetzungs-Dictionarys von allen Tagtypen zu meinen Fields bauen
        private static Dictionary<string, string> _id3Fields = new Dictionary<string, string> { { "COMM", "Comment" }, { "PCNT", "Tag-Playcount" }, { "POPM", "Tag-Rating" }, { "RVAD", "Tag-Volume" }, { "TALB", "Album" }, { "TBPM", "BPM" }, { "TCOM", "Composer" }, { "TCON", "Genre" }, { "TDAT", "Date" }, { "TENC", "Encoder" }, { "TIT1", "Contentgroup" }, { "TIT2", "Title" }, { "TIT3", "Subtitle" }, { "TLAN", "Language" }, { "TLEN", "Tag-Length" }, { "TPE1", "Artist" }, { "TPE2", "Artist2" }, { "TPE3", "Artist3" }, { "TPE4", "ModifiedBy" }, { "TPUB", "Publisher" }, { "TRCK", "TrackNr" }, { "TRDA", "Recording date" }, { "TYER", "Year" }, { "TXXX", "User defined" }, { "USER", "License" }, { "WCOP", "Copyright" } };

        private static Dictionary<string, string> _asfFields = new Dictionary<string, string> { { "Title", "Title" }, { "WM/AlbumArtist", "Artist" }, { "WM/AlbumTitle", "Album" }, { "WM/TrackNumber", "TrackNr" } };

        private static Dictionary<string, string> _oggFields = new Dictionary<string, string> { { "artist", "Artist" }, { "title", "Title" }, { "album", "Album" }, { "genre", "Genre" }, { "date", "Date" }, { "version", "Version" }, { "performer", "Performer" }, { "tracknumber", "TrackNr" }, { "comment", "Comment" }, { "copyright", "Copyright" }, { "license", "License" } };

        /// <summary>
        /// Return the human readable name for an information field.
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        public static string getField(string alias)
        {
            if (_id3Fields.ContainsKey(alias)) return _id3Fields[alias];
            else if (_asfFields.ContainsKey(alias)) return _asfFields[alias];
            else if (_oggFields.ContainsKey(alias)) return _oggFields[alias];
            else return "Undefined";
        }
        #endregion

        public Song()
        {
            _allTheInformation = new Dictionary<META_IDENTIFIERS, string>();
        }


        /// <summary>
        /// Get a stored information field (tag). Returns an empty string if the field is not set.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public string getInformation(META_IDENTIFIERS identifier)
        {
            if (_allTheInformation.ContainsKey(identifier)) return _allTheInformation[identifier];
            else return "";
        }

        /// <summary>
        /// Set an information field (tag). Check result for true if you do not know if your identifier is allowed.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool setInformation(META_IDENTIFIERS identifier, string value)
        {
            if (_allTheInformation.ContainsKey(identifier))
                _allTheInformation[identifier] = value;
            else
                _allTheInformation.Add(identifier, value);
            return true;
        }

        public override string ToString()
        {
            //TODO: Let the user choose
            return string.Format("{1} - {2}", this.getInformation(META_IDENTIFIERS.Artist), this.getInformation(META_IDENTIFIERS.Title));
        }
    }

    public class SongComparer : IComparer<Song>
    {
        private List<META_IDENTIFIERS> _orderby;

        public SongComparer()
        {
            _orderby = new List<META_IDENTIFIERS>();
            _orderby.Add(META_IDENTIFIERS.Artist);
        }
        public SongComparer(IEnumerable<META_IDENTIFIERS> orderby)
        {
            _orderby = new List<META_IDENTIFIERS>(orderby);
        }

        public int Compare(Song a, Song b)
        {
            foreach (META_IDENTIFIERS identifier in _orderby)
            {
                int test = String.Compare(a.getInformation(identifier), b.getInformation(identifier));
                if (test != 0)
                    return test;
            }
            return 0;
        }
    }
}
