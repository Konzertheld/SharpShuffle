using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AXVLC;

namespace ThePlayer
{
    public class NothingToPlayException : Exception
    {
        public NothingToPlayException() : base() { }
        public NothingToPlayException(string message) : base(message) { }
    }

    delegate void PlayerPositionChangedHandler(int position);

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

        /// <summary>
        /// Audiofilepools to use when looking for a file that matches a song.
        /// </summary>
        public List<Audiofilepool> Audiosources;

        private VLCPlugin2Class vlc;

        public Song CurrentSong { get; private set; }

        public event PlayerPositionChangedHandler PositionChanged;

        public bool isPlaying;

        /// <summary>
        /// Null-based index of the current song in the playlist or -1 when the current song is not in the playlist.
        /// </summary>
        private int playlistPosition;

        public Player()
        {
            // Initialization
            Playlist = new Songpool();
            LastPlayed = new Songpool();
            CurrentView = new Songpool();
            Audiosources = new List<Audiofilepool>();
            vlc = new VLCPlugin2Class();
            isPlaying = false;
            playlistPosition = -1;

            // Link re-implementations
            vlc.MediaPlayerPositionChanged += new DVLCEvents_MediaPlayerPositionChangedEventHandler(vlc_MediaPlayerPositionChanged);

            // Link events caught by Player class
            vlc.MediaPlayerStopped += new DVLCEvents_MediaPlayerStoppedEventHandler(vlc_MediaPlayerStopped);
        }

        private Song GetNextSong()
        {
            //TODO: All randomization, not-playing songs that were already played etc goes here
            if (playlistPosition == -1)
            {
                if (Playlist.getSongs().Count > 0)
                {
                    //TODO: Randomization etc. when starting to play the playlist
                    playlistPosition = 0;
                    return Playlist.getSongs()[0];
                }
                else
                    throw new NothingToPlayException("Der nächste Song sollte gespielt werden, aber es war keiner vorhanden.");
            }


            return Playlist.getSongs()[Playlist.getSongs().FindIndex(delegate(Song song) { return song == CurrentSong; }) + 1];
        }

        void vlc_MediaPlayerStopped()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start playing using the playlist.
        /// </summary>
        public void PlayPlaylist()
        {
            Stop();
            playlistPosition = -1;
            PlaySong(GetNextSong());
        }

        #region Playback control
        public void PlaySong(Song song)
        {
            Stop();
            vlc.playlist.items.clear();
            string temp = FindAudiofile(song);
            if (System.IO.File.Exists(temp))
                vlc.playlist.add(temp);
            else
                throw new System.IO.FileNotFoundException("Der abzuspielende Song wurde nicht gefunden.", temp);
            vlc.playlist.play();
            isPlaying = true;
        }

        public void PlayPause()
        {
            //TODO: It is not always useful to just tell vlc to toggle pause.
            vlc.playlist.togglePause();
        }

        public void Stop()
        {
            try
            {
                if (vlc.playlist.isPlaying)
                    vlc.playlist.stop();
            }
            catch (Exception E) { }
            isPlaying = false;
        }

        public void NextSong()
        {
            //TODO: Consider doing nothing or just moving the playlist pointer when playback is not running.
            PlaySong(GetNextSong());
        }
        #endregion

        /// <summary>
        /// Search all the Audiofilepools for a song.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        private string FindAudiofile(Song song)
        {
            Audiofile temp;
            foreach (Audiofilepool afp in Audiosources)
            {
                temp = afp.findSong(song);
                if (temp != null) return temp.Filepath;
            }
            return "";
        }

        #region Re-Implentations that do nothing
        void vlc_MediaPlayerPositionChanged(int Position)
        {
            PositionChanged(Position);
        }
        #endregion
    }
}
