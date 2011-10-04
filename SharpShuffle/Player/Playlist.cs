using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle
{
    public class Playlist
    {
        private List<Song> total;
        private List<Song> remaining;
        public int Position { get; private set; }
        public bool Randomize;
        public bool Repeat;

        public Playlist()
        {
            total = new List<Song>();
            remaining = new List<Song>();
            Position = -1;
            Randomize = true;
            Repeat = true;
        }

        public Song this[int index]
        {
            get
            {
                return total[index];
            }
            set
            {
                total[index] = value;
            }
        }

        public void Add(Song song)
        {
            total.Add(song);
            remaining.Add(song);
        }

        /// <summary>
        /// Remove the current item.
        /// </summary>
        public void Remove()
        {
            Remove(Position);
        }
        /// <summary>
        /// Remove the song at the given position.
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            total.RemoveAt(index);
            remaining.Remove(total[index]);

        }
        /// <summary>
        /// Remove all occurences of a specific song.
        /// </summary>
        /// <param name="song"></param>
        public void Remove(Song song)
        {
            total.RemoveAll(delegate(Song needle) { return needle.Equals(song); });
            remaining.RemoveAll(delegate(Song needle) { return needle.Equals(song); });
        }

        public int Count()
        {
            return total.Count();
        }

        public bool SongsLeft()
        {
            return remaining.Count > 0;
        }

        public bool Contains(Song song)
        {
            return total.Contains(song);
        }

        public Song Current()
        {
            if (Position < total.Count)
                return this[Position];
            else
                return null;
        }

        public void Clear()
        {
            total.Clear();
            remaining.Clear();
            Position = -1;
        }

        /// <summary>
        /// Mark the current song as played so one instance in the remaining songs gets removed and increase the pointer.
        /// </summary>
        /// <param name="song"></param>
        public void Kick()
        {
            remaining.Remove(total[Position]);

            // If repeat is on, refill the remaining playlist so we can start again with all the songs.
            if (remaining.Count == 0 && Repeat)
                remaining = total;

            Next();
        }

        /// <summary>
        /// Set the position to the next song that has not been played yet.
        /// </summary>
        /// <returns>Returns -1 if no songs is left.</returns>
        public int Next()
        {
            if (Randomize)
            {
                // Don't play songs that have been played or skipped before the entire playlist has been played or skipped.
                if (!SongsLeft())
                    return -1;
                do
                {
                    Position = new Random().Next(0, total.Count);
                } while (!remaining.Contains(Current()));
            }
            else
            {
                Position++;
                if (Position == total.Count)
                    return -1;
            }
            return Position;
        }
    }
}
