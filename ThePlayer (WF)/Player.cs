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
        /// Songs currently displayed based on the current selection
        /// </summary>
        public Songpool CurrentView { get; set; }

        /// <summary>
        /// Songs that have been played. Technically: Songs that matched the "mark the song as played" criterias.
        /// </summary>
        public Songpool PlayedHistory { get; set; }

        /// <summary>
        /// Similar to history and playlist, but includes skipped songs. Technically a sequencial list of all Songs that have been passed to PlaySong() and were found as an Audiofile.
        /// </summary>
        private Songpool totalHistory { get; set; }

        /// <summary>
        /// Audiofilepools to use when looking for a file that matches a song.
        /// </summary>
        public List<Audiofilepool> Audiosources;

        private IVideoPlayer vlc;
        private IMediaPlayerFactory factory;
        private bool currentSongLogged;

        private Song _currentSong;
        public Song CurrentSong { get { return _currentSong; } private set { currentSongLogged = false; _currentSong = value; } }

        public event PlayerPositionChangedHandler PositionChanged;
        public event PlaylistEndedHandler PlaylistEnded;

        public bool isPlaying;
        /// <summary>
        /// Helper variable for navigation. If we are navigating (prev and next) through songs that have already been played, they are not logged again.
        /// </summary>
        private bool logging;

        /// <summary>
        /// Null-based index of the current song in the playlist or -1 when the current song is not in the playlist.
        /// </summary>
        private int playlistPosition;

        private int historyPosition;

        #region Constructors
        public Player()
        {
            // Initialization
            Playlist = new Songpool();
            CurrentView = new Songpool();
            PlayedHistory = new Songpool();
            totalHistory = new Songpool();
            Audiosources = new List<Audiofilepool>();
            isPlaying = false;
            playlistPosition = -1;
            historyPosition = -1;

            // VLC Initialization
            factory = new MediaPlayerFactory();
            vlc = factory.CreatePlayer<IVideoPlayer>();
            vlc.Events.MediaEnded += new EventHandler(Events_MediaEnded);
            vlc.Events.TimeChanged += new EventHandler<Declarations.Events.MediaPlayerTimeChanged>(Events_TimeChanged);
            vlc.Events.PlayerPlaying += new EventHandler(Events_PlayerPlaying);
        }
        #endregion

        #region Events
        void Events_PlayerPlaying(object sender, EventArgs e)
        {
            //Scrobbel.Scrobbeln(CurrentSong.getInformation(META_IDENTIFIERS.Artist), CurrentSong.getInformation(META_IDENTIFIERS.Title), (int)(vlc.Length / 1000));
        }

        void Events_TimeChanged(object sender, Declarations.Events.MediaPlayerTimeChanged e)
        {
            //TODO: Use PositionChanged instead?!
            double pos = (double)e.NewTime / vlc.Length;
            PositionChanged(pos);
            //TODO: Make this configurable
            if (pos > 0.8 && !currentSongLogged)
            {
                Scrobbel.Scrobbeln(CurrentSong.getInformation(META_IDENTIFIERS.Artists), CurrentSong.getInformation(META_IDENTIFIERS.Title), DateTime.Now.Subtract(new TimeSpan(1, 0, 0)), (int)(vlc.Length / 1000));
                currentSongLogged = true;
            }
        }

        void Events_MediaEnded(object sender, EventArgs e)
        {
            if (playlistPosition != -1)
            {
                PlaySong(GetNextSong());
            }
        }
        #endregion

        #region Core
        private Song GetNextSong()
        {
            if (historyPosition < totalHistory.getSongs().Count - 1)
            { // User was navigating forward to songs that have already been played and was then navigated back
                historyPosition++;
                logging = false;
                return totalHistory.getSongs()[historyPosition];
            }

            logging = true;
            //TODO: All randomization, not-playing songs that were already played etc goes here
            if (playlistPosition == -1)
            { // Playlist mode is off
                if (Playlist.getSongs().Count > 0)
                { // Start playlist
                    //TODO: Randomization etc. when starting to play the playlist
                    playlistPosition = 0;
                    return Playlist.getSongs()[0];
                }
                else
                    throw new NothingToPlayException("Der nächste Song sollte gespielt werden, aber es war keiner vorhanden.");
            }
            else if (playlistPosition < Playlist.getSongs().Count - 1)
            { // Playlist already playing, get the next song
                playlistPosition++;
                return Playlist.getSongs()[playlistPosition];
            }
            else
            {
                //TODO: Return null here and handle playlist ended elsewhere? Hm.
                return null;
            }
        }

        /// <summary>
        /// Play a specific song.
        /// </summary>
        /// <param name="song">Guess what.</param>
        public void PlaySong(Song song)
        {
            //TODO: Better error messages
            if (song == null)
            {
                raisePlaylistEnded();
                return;
            }
            Stop();
            string temp = FindAudiofile(song);
            if (temp == "")
            {
                throw new Exception("Zu diesem Song wurde kein Audiofile gefunden.");
            }
            else if (System.IO.File.Exists(temp))
            {
                IMedia media = factory.CreateMedia<IMedia>(temp);
                CurrentSong = song;
                vlc.Open(media);
                vlc.Play();
                isPlaying = true;
                if (logging)
                {
                    totalHistory.AddSong(song, true);
                    historyPosition++;
                }
            }
            else
            {
                throw new System.IO.FileNotFoundException("Der abzuspielende Song wurde nicht gefunden.", temp);
            }
        }
        #endregion

        #region Playback control
        /// <summary>
        /// Start playing using the playlist.
        /// </summary>
        public int PlayPlaylist()
        {
            Stop();
            PlaySong(GetNextSong());
            return playlistPosition;
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

        public int NextSong()
        {
            //TODO: Consider doing nothing or just moving the playlist pointer when playback is not running.
            PlaySong(GetNextSong());
            return (logging) ? playlistPosition : positionInPlaylist(totalHistory.getSongs()[historyPosition]);
        }

        public int PrevSong()
        {
            if (historyPosition > 0 && historyPosition < totalHistory.getSongs().Count)
            {
                historyPosition--;
                logging = false;
                PlaySong(totalHistory.getSongs()[historyPosition]);
                return positionInPlaylist(totalHistory.getSongs()[historyPosition]);
            }
            return positionInPlaylist(totalHistory.getSongs()[historyPosition]);
        }
        #endregion

        #region Helper methods
        private int positionInPlaylist(Song needle)
        {
            return Playlist.getSongs().FindIndex(delegate(Song song) { return song == needle; });
        }
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
        #endregion

        public void ScrobbelSong(Song song)
        {
        }
    }
}
