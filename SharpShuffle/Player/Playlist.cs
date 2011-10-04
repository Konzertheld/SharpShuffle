using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle
{
    public class Playlist : List<Song>
    {
        
        private List<Song> remaining;
        public int Position { get; private set; }
        public bool Randomize;
        public bool Repeat;

        public Playlist()
            :base()
        {
            
            remaining = new List<Song>();
            Position = -1;
            Randomize = true;
            Repeat = true;
        }

        new public void Add(Song song)
        {
            base.Add(song);
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
            base.RemoveAt(index);
            remaining.Remove(this[index]);

        }
        /// <summary>
        /// Remove all occurences of a specific song.
        /// </summary>
        /// <param name="song"></param>
        new public void Remove(Song song)
        {
            this.RemoveAll(delegate(Song needle) { return needle.Equals(song); });
            remaining.RemoveAll(delegate(Song needle) { return needle.Equals(song); });
        }

        public bool SongsLeft()
        {
            return remaining.Count > 0;
        }

        public Song Current()
        {
            if (Position < this.Count())
                return this[Position];
            else
                return null;
        }

        new public void Clear()
        {
            this.Clear();
            remaining.Clear();
            Position = -1;
        }

        /// <summary>
        /// Mark the current song as played so one instance in the remaining songs gets removed and increase the pointer.
        /// </summary>
        /// <param name="song"></param>
        public void Kick()
        {
            remaining.Remove(this[Position]);

            // If repeat is on, refill the remaining playlist so we can start again with all the songs.
            if (remaining.Count == 0 && Repeat)
                remaining = this;
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
                    Position = new Random().Next(0, this.Count());
                } while (!remaining.Contains(Current()));
            }
            else
            {
                Position++;
                if (Position == this.Count())
                    return -1;
            }
            return Position;
        }
    }
}
