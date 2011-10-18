using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle
{
    public enum TP_PLAYBACKMODE
    {
        Single,
        Playlist,
        History,
        Queue
    }

    public enum TP_PLAYBACKSTATE
    {
        Playing,
        Paused,
        Stopped
    }

    public enum TP_PLAYBACKDIRECTION
    {
        Forward,
        Backwards
    }

    public enum TP_PLAYBACKLOG
    {
        AfterBeginning,
        AfterEnding,
        After80Percent
    }

    public enum SONGMETA
    {
        Artists,
        BPM,
        Comment,
        Composer,
        Conductor,
        Copyright,
        Version,
        Genres,
        Lyrics,
        Title,
        TrackNr,
        PlayCount,
        SkipCount,
        Rating,
        Length
    }

    public class SongComparer : IComparer<Song>
    {
        private List<SONGMETA> _orderby;
        private bool _ignorecase;

        public SongComparer()
        {
            _orderby = new List<SONGMETA>();
            _orderby.Add(SONGMETA.Artists);
        }
        public SongComparer(IEnumerable<SONGMETA> orderby)
        {
            _orderby = new List<SONGMETA>(orderby);
            _ignorecase = true;
        }
        public SongComparer(IEnumerable<SONGMETA> orderby, bool ignorecase)
            : this(orderby)
        {
            this._ignorecase = ignorecase;
        }


        public int Compare(Song a, Song b)
        {
            foreach (SONGMETA identifier in _orderby)
            {
                int test = String.Compare((string)a[identifier], (string)b[identifier], _ignorecase);
                if (test != 0)
                    return test;
            }
            return 0;
        }
    }

    public delegate void PlayerPositionChangedHandler(double position);
    public delegate void PlaylistEndedHandler();
    public delegate void PlaylistChangedHandler(string[] newList);
    public delegate void SongChangedHandler(Song song);

    struct PlayerRandomSettings
    {
        /// <summary>
        /// Number of items in the history that must not include the song for the song to be allowed.
        /// </summary>
        public int NoGoHistoryItems;

        /// <summary>
        /// Whether to include skipped songs into the NoGo or not. If set to true, a skipped song will not be played again until NoGoHistoryItems songs have been played or skipped.
        /// </summary>
        public bool TotalNoGo;

        public PlayerRandomSettings(int noGoHistoryItems, bool totalNoGo)
        {
            NoGoHistoryItems = noGoHistoryItems;
            TotalNoGo = totalNoGo;
        }
    }
}
