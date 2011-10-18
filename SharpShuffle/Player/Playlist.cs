using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SharpShuffle
{
    public class Playlist : BindingList<Song>
    {
        private List<Song> remaining;
        public int Position { get; private set; }
        public bool Randomize;
        public bool Repeat;

        public Playlist()
            : base()
        {

            remaining = new List<Song>();
            Position = -1;
            Randomize = true;
            Repeat = true;
        }

        /// <summary>
        /// Add a song to the playlist. Automatically adds that song to the list of remaining playable songs.
        /// </summary>
        /// <param name="song"></param>
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
            this.Remove(song);
            remaining.RemoveAll(delegate(Song needle) { return needle.Equals(song); });
        }

        /// <summary>
        /// Returns true if there are songs left to play (when all songs were played or skipped and repeat is off, somewhen there will be no more songs to play).
        /// </summary>
        /// <returns></returns>
        public bool SongsLeft()
        {
            return remaining.Count > 0;
        }

        /// <summary>
        /// Get the current song.
        /// </summary>
        /// <returns></returns>
        public Song Current()
        {
            if (Position < this.Count())
                return this[Position];
            else
                return null;
        }

        /// <summary>
        /// Reset the playlist and remove all songs.
        /// </summary>
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
                remaining = new List<Song>(this);
            Next();
        }

        /// <summary>
        /// Set the position to the next song that has not been played yet.
        /// </summary>
        /// <returns>Returns -1 if no songs is left and otherwise the new position.</returns>
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
