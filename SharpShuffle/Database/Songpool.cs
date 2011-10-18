using System;
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
            if (name.Substring(0, 2) == "__")
                throw new Exception("Der Name eines Pools darf nicht mit zwei Unterstrichen beginnen!");
            Startup.ActiveDB.CreateSongpool(name);
            Name = name;
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
    }
}
