using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Declarations;
using Declarations.Media;
using Declarations.Players;
using Implementation;

namespace SharpShuffle
{
    public class Player
    {
        #region Songlists
        /// <summary>
        /// Songs to play
        /// </summary>
        public Playlist Playlist { get; set; }
        /// <summary>
        /// Songs that have been played. Technically: Songs that matched the "mark the song as played" criterias.
        /// </summary>
        public List<Song> PlayedHistory { get; set; }
        /// <summary>
        /// Similar to history and playlist, but includes skipped songs. Technically a sequencial list of all Songs that have been passed to PlaySong() and were found as an Audiofile.
        /// </summary>
        private List<Song> totalHistory { get; set; }
        /// <summary>
        /// Song queue - use to determine the songs to be played next. Has priority.
        /// </summary>
        public List<Song> Queue;
        #endregion

        #region Settings and Information
        private Song _currentSong;
        public Song CurrentSong { get { return _currentSong; } private set { currentSongLogged = false; _currentSong = value; if (SongChanged != null) SongChanged(_currentSong); } }
        private bool currentSongLogged;

        //TODO: Maybe raise an event for changed states. Maybe not, as we always stop when the next song is played. Which might also be suboptimal.
        /// <summary>
        /// State: Player is playing, paused (during a song) or stopped. PlayPause does not work when stopped.
        /// </summary>
        public TP_PLAYBACKSTATE PlaybackState { get; private set; }
        // Helper variables for navigation. If we are navigating (prev and next) through songs that have already been played, they are not logged again.
        private TP_PLAYBACKMODE playbackMode;
        private TP_PLAYBACKDIRECTION playbackDirection;
        /// <summary>
        /// Gets and sets the mode when a song is logged as played.
        /// </summary>
        public TP_PLAYBACKLOG PlaybackLoggingMode { get; set; }
        /// <summary>
        /// Null-based index in totalHistory. Very important as this is relevant to where we are actually.
        /// </summary>
        private int historyPosition;
        #endregion

        #region Events and VLC
        private IVideoPlayer vlc;
        private IMediaPlayerFactory factory;

        public event PlayerPositionChangedHandler PositionChanged;
        public event PlaylistEndedHandler PlaylistEnded;
        public event SongChangedHandler SongChanged;
        #endregion

        #region Constructors
        public Player()
        {
            // Initialization (TODO: Make all the stuff configurable, of course)
            Playlist = new Playlist();
            PlayedHistory = new List<Song>();
            totalHistory = new List<Song>();
            Queue = new List<Song>();
            PlaybackState = TP_PLAYBACKSTATE.Stopped;
            playbackMode = TP_PLAYBACKMODE.Playlist;
            playbackDirection = TP_PLAYBACKDIRECTION.Forward;
            PlaybackLoggingMode = TP_PLAYBACKLOG.After80Percent;
            historyPosition = -1;

            // VLC Initialization
            factory = new MediaPlayerFactory();
            vlc = factory.CreatePlayer<IVideoPlayer>();
            vlc.Events.MediaEnded += new EventHandler(Events_MediaEnded);
            vlc.Events.TimeChanged += new EventHandler<Declarations.Events.MediaPlayerTimeChanged>(Events_TimeChanged);
            vlc.Events.PlayerPlaying += new EventHandler(Events_PlayerPlaying);
        }
        #endregion

        #region VLC Eventhandlers
        void Events_PlayerPlaying(object sender, EventArgs e)
        {
            if (PlaybackLoggingMode == TP_PLAYBACKLOG.AfterBeginning)
                LogCurrentSong();
            //Scrobbel.Scrobbeln(CurrentSong.getInformation(META_IDENTIFIERS.Artist), CurrentSong.getInformation(META_IDENTIFIERS.Title), (int)(vlc.Length / 1000));
        }

        //TODO: Position in Sekunden und Prozent übergeben für Zeitanzeige in der UI
        void Events_TimeChanged(object sender, Declarations.Events.MediaPlayerTimeChanged e)
        {
            //TODO: Use PositionChanged instead?!
            double pos = (double)e.NewTime / vlc.Length;
            if (PositionChanged != null)
                PositionChanged(pos);
            if (pos > 0.8 && PlaybackLoggingMode == TP_PLAYBACKLOG.After80Percent)
                LogCurrentSong();
        }

        void Events_MediaEnded(object sender, EventArgs e)
        {
            if (PlaybackLoggingMode == TP_PLAYBACKLOG.AfterEnding)
                LogCurrentSong();

            // The song has played to end, tell the playlist to perform actions
            if (playbackMode == TP_PLAYBACKMODE.Playlist)
                Playlist.Kick();

            // Don't call NextSong() here because NextSong might do nothing because playback is no longer running (the user pressed stop).
            Song s = GetNextSong();
            if (s != null)
                PlaySong(s);
        }
        #endregion

        #region Core
        /// <summary>
        /// This function will get you a song to play when you are using a playlist, navigating through history or using the queue.
        /// </summary>
        /// <returns></returns>
        private Song GetNextSong()
        {
            // What are we playing? Is there anything in the queue? Then it has priority. The queue even skips our ultimate filter because
            // it is always user decision. The only exception is we are navigating backwards.
            if (playbackDirection == TP_PLAYBACKDIRECTION.Forward && Queue.Count > 0)
            {
                playbackMode = TP_PLAYBACKMODE.Queue;
                CurrentSong = Queue[0];
                Queue.RemoveAt(0);
                return CurrentSong;
            }

            // What are we playing? Songs we already navigated to with Next and Prev? Then play all of them until there are no more before we do anything else.
            // They also skip the filter because if they had not passed the filter they would not be here. Also it would be confusing if navigating back would
            // lack already played songs.
            // The highest element in totalHistory is usually the song that currently plays. If we navigate, the pointer is moved.
            if (historyPosition < totalHistory.Count - 1)
            {
                historyPosition++;
                playbackMode = TP_PLAYBACKMODE.History;
                CurrentSong = totalHistory[historyPosition];
                return CurrentSong;
            }

            // Reset the playback mode in case we were navigating before. The mode is important for logging new songs to the history.
            playbackMode = TP_PLAYBACKMODE.Playlist;


            if (Playlist.SongsLeft())
            {
                // If there are any songs left to play from the playlist get a random one that matches our criteria
                while (Playlist.Next() != -1)
                {
                    if (AllowSong(Playlist.Current()))
                        break;
                    else
                        Playlist.Kick();
                }

                // Set the current song and if necessary raise the PlaylistEnded event.
                CurrentSong = Playlist.Current();
                if (CurrentSong == null && PlaylistEnded != null)
                    PlaylistEnded();

                return CurrentSong;
            }
            else
            {
                CurrentSong = null;
                return CurrentSong;
            }
        }

        public bool AllowSong(Song song)
        {
            //TODO: All song filtering goes here
            bool result = true;

            // Don't play songs that have already been played.
            result = result && !(PlayedHistory.Contains(song));

            return result;
        }

        private void PlaySong(Song song)
        {
            // As soon as we are trying to play any song we are moving forward again.
            playbackDirection = TP_PLAYBACKDIRECTION.Forward;

            string temp = FindAudiofile(song);
            if (temp == "")
            {
                throw new Exception("Zu diesem Song wurde kein Audiofile gefunden.");
            }
            else if (System.IO.File.Exists(temp))
            {
                Stop();

                // This is the point where the song is actually played for real.
                IMedia media = factory.CreateMedia<IMedia>(temp);
                CurrentSong = song;
                vlc.Open(media);
                vlc.Play();
                PlaybackState = TP_PLAYBACKSTATE.Playing;
                // If we are not already navigating, log the song to the navigation history so it is available in case the user starts skipping
                if (playbackMode == TP_PLAYBACKMODE.Playlist)
                {
                    totalHistory.Add(song);
                    historyPosition++;
                }
            }
            else
            {
                //TODO: Automatically re-scan
                throw new System.IO.FileNotFoundException("Die Datei des abzuspielenden Songs wurde nicht gefunden. Möglicherweise muss die Bibliothek aktualisiert werden.", temp);
            }
        }
        #endregion

        #region Playback control
        /// <summary>
        /// Start playing using the playlist.
        /// </summary>
        public void PlayPlaylist()
        {
            PlaySong(GetNextSong());
        }

        public void PlayPause()
        {
            if (vlc.IsPlaying)
            {
                vlc.Pause();
                PlaybackState = TP_PLAYBACKSTATE.Paused;
            }
            else
            {
                if (PlaybackState == TP_PLAYBACKSTATE.Paused)
                {
                    vlc.Play();
                    PlaybackState = TP_PLAYBACKSTATE.Playing;
                }
                else if (CurrentSong != null)
                    PlaySong(CurrentSong);
            }
        }

        public void Stop()
        {
            // TODO: It is not enough to call this when vlc is not playing. We also have to reset it to avoid resuming skipped songs (see NextSong()).
            vlc.Stop();
            PlaybackState = TP_PLAYBACKSTATE.Stopped;
        }

        /// <summary>
        /// Play the next song. If playback is not running, only the playlist position is changed.
        /// </summary>
        public void NextSong()
        {
            if (vlc.IsPlaying)
            {
                // Playback is running, increase the current song's skip counter and skip to the next song
                CurrentSong.SkipCount++;
                CurrentSong.Update();
                PlaySong(GetNextSong());
            }
            else
            {
                // Playback is not running, move the pointer. Actually GetNextSong() will do that for us. We just discard the result.
                GetNextSong();
                // Call Stop() to avoid resuming a song we skipped while it was paused
                Stop();
            }
        }

        public void PrevSong()
        {
            if (historyPosition > 0)
            {
                // Move one step back in history. Set direction to avoid the queue. GetNextSong() and PlaySong() will do the rest for us.
                historyPosition--;
                playbackDirection = TP_PLAYBACKDIRECTION.Backwards;
                PlaySong(GetNextSong());
            }
        }
        #endregion

        #region Helper methods
        private void LogCurrentSong()
        {
            if (!currentSongLogged)
            {
                //TODO: Scrobbeln nur vormerken, erst bei Next oder Stop ausführen
                //Scrobbel.Scrobbeln(CurrentSong.getInformation(Song.META_ARTISTS), CurrentSong.getInformation(Song.META_TITLE), DateTime.Now.Subtract(new TimeSpan(1, 0, 0)), (int)(vlc.Length / 1000));
                //PlayedHistory.AddSongs(CurrentSong, true);
                CurrentSong.PlayCount++;
                CurrentSong.Update();
                currentSongLogged = true;
            }
        }

        /// <summary>
        /// Search all the Audiofilepools for a song.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        private string FindAudiofile(Song song)
        {
            //TODO: Haha, here is a lot of work to do.
            return Startup.ActiveDB.GetFileForSong(song);
        }
        #endregion

        public void ScrobbelSong(Song song)
        {
        }

        #region Load and save
        public void Save()
        {
            // The pools are saved automatically. Save the rest here.
        }
        #endregion
    }
}
