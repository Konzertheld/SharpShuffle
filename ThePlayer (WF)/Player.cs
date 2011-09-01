using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    [Serializable]
    class Player
    {
        /// <summary>
        /// Songs to play
        /// </summary>
        public Songpool Playlist { get; set; }

        /// <summary>
        /// Songs last played
        /// </summary>
        public Songpool LastPlayed { get; set; }

        /// <summary>
        /// Songs currently displayed based on the current selection
        /// </summary>
        public Songpool CurrentView { get; set; }

        public Player()
        {
            Playlist = new Songpool();
            LastPlayed = new Songpool();
            CurrentView = new Songpool();
        }
    }
}
