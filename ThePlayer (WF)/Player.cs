using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Declarations;
using Declarations.Media;
using Declarations.Players;
using Implementation;

namespace ThePlayer
{
    public class NothingToPlayException : Exception
    {
        public NothingToPlayException() : base() { }
        public NothingToPlayException(string message) : base(message) { }
    }

    delegate void PlayerPositionChangedHandler(double position);
    delegate void PlaylistEndedHandler();

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

        private IVideoPlayer vlc;
        private IMediaPlayerFactory factory;

        public Song CurrentSong { get; private set; }

        public event PlayerPositionChangedHandler PositionChanged;
        public event PlaylistEndedHandler PlaylistEnded;

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
            isPlaying = false;
            playlistPosition = -1;

            // VLC Initialization
            factory = new MediaPlayerFactory();
            vlc = factory.CreatePlayer<IVideoPlayer>();
            vlc.Events.MediaEnded += new EventHandler(Events_MediaEnded);
            vlc.Events.TimeChanged += new EventHandler<Declarations.Events.MediaPlayerTimeChanged>(Events_TimeChanged);
            //vlc.Events.PlayerPositionChanged += new EventHandler<Declarations.Events.MediaPlayerPositionChanged>(Events_PlayerPositionChanged);
        }

        void Events_TimeChanged(object sender, Declarations.Events.MediaPlayerTimeChanged e)
        {
            PositionChanged((double)e.NewTime / vlc.Length);
        }

        void Events_MediaEnded(object sender, EventArgs e)
        {
            if (playlistPosition != -1)
            {
                PlaySong(GetNextSong());
            }
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
            else if (playlistPosition < Playlist.getSongs().Count - 1)
            {
                playlistPosition++;
                return Playlist.getSongs()[playlistPosition];
            }
            else
            {
                return null;
            }
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
            if (song == null)
            {
                raisePlaylistEnded();
                return;
            }
            Stop();
            string temp = FindAudiofile(song);
            if (System.IO.File.Exists(temp))
            {
                IMedia media = factory.CreateMedia<IMedia>(temp);
                vlc.Open(media);
                vlc.Play();
                isPlaying = true;
            }
            else
            {
                isPlaying = false;
                throw new System.IO.FileNotFoundException("Der abzuspielende Song wurde nicht gefunden.", temp);
            }
        }

        public void PlayPause()
        {
            //TODO: It is not always useful to just tell vlc to toggle pause.
            if (vlc.IsPlaying) vlc.Pause();
            else vlc.Play();
        }

        public void Stop()
        {
            if (vlc.IsPlaying)
                vlc.Stop();
            isPlaying = false;
        }

        public void NextSong()
        {
            //TODO: Consider doing nothing or just moving the playlist pointer when playback is not running.
            PlaySong(GetNextSong());
        }

        //TODO: Implement navigating backwards - PrevSong
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

        private void raisePlaylistEnded()
        {
            isPlaying = false;
            if (PlaylistEnded != null) PlaylistEnded();
        }
    }
}
