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
    public enum TP_PLAYBACKMODE
    {
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

    public class NothingToPlayException : Exception
    {
        public NothingToPlayException() : base() { }
        public NothingToPlayException(string message) : base(message) { }
    }

    public delegate void PlayerPositionChangedHandler(double position);
    public delegate void PlaylistEndedHandler();
    public delegate void PlaylistChangedHandler(string[] newList);
    public delegate void SongChangedHandler(Song song);

    public class PlayerView
    {
        public List<string> Columns;
        public List<string> Sorting;
        private Songpool view;

        public PlayerView()
        {
            //TODO: Implement user sorting
            //TODO: Implement user columns
            Columns = new List<string>(new string[5] { Song.META_ARTISTS, Song.META_TITLE, Song.META_ALBUM, Song.META_GENRES, Song.META_PLAYCOUNT });
            Sorting = new List<string>(new string[3] { Song.META_ARTISTS, Song.META_ALBUM, Song.META_TRACK });
        }

        public void ChangePools(string[] indices)
        {
            view = new Songpool();
            foreach (string s in indices)
            {
                //foreach (Song song in Program.Songpools[s].getSongs(Sorting))
                    //view.AddSong(song);
            }
        }

        public List<string[]> ViewSongs()
        {
            List<string[]> result = new List<string[]>();
            foreach (Song song in view.getSongs(Sorting))
            {
                string[] s = new string[Columns.Count];
                for (int i = 0; i < Columns.Count; i++)
                    s[i] = song.getInformation(Columns[i]);
                result.Add(s);
            }
            return result;
        }

        public Song getSongFromView(int index)
        {
            return view.getSongs()[index];
        }
    }

    public class Player
    {
        #region Attributes
        /// <summary>
        /// Songs to play
        /// </summary>
        private Songpool _Playlist { get; set; }
        /// <summary>
        /// A copy of the playlist. Skipped and played songs are removed from this one.
        /// </summary>
        private Songpool usedPlaylist { get; set; }
        /// <summary>
        /// Songs that have been played. Technically: Songs that matched the "mark the song as played" criterias.
        /// </summary>
        public Songpool PlayedHistory { get; set; }
        /// <summary>
        /// Similar to history and playlist, but includes skipped songs. Technically a sequencial list of all Songs that have been passed to PlaySong() and were found as an Audiofile.
        /// </summary>
        private List<Song> totalHistory { get; set; }
        /// <summary>
        /// Song queue - use to determine the songs to be played next. Has priority.
        /// </summary>
        public List<Song> Queue;

        private IVideoPlayer vlc;
        private IMediaPlayerFactory factory;

        private Song _currentSong;
        public Song CurrentSong { get { return _currentSong; } private set { currentSongLogged = false; _currentSong = value; if (SongChanged != null) SongChanged(_currentSong); } }
        private bool currentSongLogged;

        public bool PlayRandom { get; set; }
        public bool ExcludeSkipped { get; set; }

        //TODO: Maybe raise an event for changed states. Maybe not, as we always stop when the next song is played. Which might also be suboptimal.
        /// <summary>
        /// State: Player is playing, paused (during a song) or stopped. PlayPause does not work when stopped.
        /// </summary>
        public TP_PLAYBACKSTATE PlaybackState { get; private set; }
        /// <summary>
        /// Helper variable for navigation. If we are navigating (prev and next) through songs that have already been played, they are not logged again.
        /// </summary>
        private TP_PLAYBACKMODE playbackMode;
        /// <summary>
        /// Helper variable for navigation. We need to know if we are navigating backwards to avoid the queue.
        /// </summary>
        private TP_PLAYBACKDIRECTION playbackDirection;
        /// <summary>
        /// Null-based index of the current song in the playlist or -1 when the current song is not in the playlist.
        /// </summary>
        private int playlistPosition;
        /// <summary>
        /// Null-based index in totalHistory. Very important as this is relevant to where we are actually.
        /// </summary>
        private int historyPosition;
        /// <summary>
        /// The currently used playlist's index.
        /// </summary>
        private int playlistNumber;

        public event PlayerPositionChangedHandler PositionChanged;
        public event PlaylistEndedHandler PlaylistEnded;
        public event PlaylistChangedHandler PlaylistChanged;
        public event SongChangedHandler SongChanged;
        #endregion

        #region Constructors
        public Player()
        {
            // Initialization (TODO: Make all the stuff configurable, of course)
            _Playlist = new Songpool();
            usedPlaylist = new Songpool();
            PlayedHistory = new Songpool();
            totalHistory = new List<Song>();
            Queue = new List<Song>();
            PlaybackState = TP_PLAYBACKSTATE.Stopped;
            playbackMode = TP_PLAYBACKMODE.Playlist;
            playbackDirection = TP_PLAYBACKDIRECTION.Forward;
            playlistPosition = -1;
            historyPosition = -1;
            PlayRandom = true;
            ExcludeSkipped = true;

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
            //Scrobbel.Scrobbeln(CurrentSong.getInformation(META_IDENTIFIERS.Artist), CurrentSong.getInformation(META_IDENTIFIERS.Title), (int)(vlc.Length / 1000));
        }

        //TODO: Position in Sekunden und Prozent übergeben für Zeitanzeige in der UI
        void Events_TimeChanged(object sender, Declarations.Events.MediaPlayerTimeChanged e)
        {
            //TODO: Use PositionChanged instead?!
            double pos = (double)e.NewTime / vlc.Length;
            PositionChanged(pos);
            //TODO: Make this configurable
            if (pos > 0.8 && !currentSongLogged)
            {
                //TODO: Scrobbeln nur vormerken, erst bei Next oder Stop ausführen
                Scrobbel.Scrobbeln(CurrentSong.getInformation(Song.META_ARTISTS), CurrentSong.getInformation(Song.META_TITLE), DateTime.Now.Subtract(new TimeSpan(1, 0, 0)), (int)(vlc.Length / 1000));
                PlayedHistory.AddSong(CurrentSong, true);
                currentSongLogged = true;
            }
        }

        void Events_MediaEnded(object sender, EventArgs e)
        {
            // The song has played to end, ban it from the current playlist at least until all the songs were skipped or played
            usedPlaylist.RemoveSong(CurrentSong);
            // Don't call NextSong() here because NextSong might do nothing because playback is not running.
            // If the playlist position is -1, we listened to a song not using the playlist (or the playlist is empty).
            if (playlistPosition != -1)
            {
                PlaySong(GetNextSong());
            }
        }
        #endregion

        #region Core
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

            // If we ran out of songs and playlist-repeat is on, refill the internal playlist.
            //TODO: Repeatmodes
            if (usedPlaylist.getSongs().Count == 0 && true)
                usedPlaylist = new Songpool(_Playlist.getSongs());

            // What are we playing? Sequencial or random playlist?
            if (PlayRandom)
            {
                if (usedPlaylist.getSongs().Count > 0)
                {
                    // If there are any songs left to play from the playlist get a random one that matches our criteria
                    // We use the usedPlaylist above to check if something is available to avoid random loops
                    // To get the correct position, we use the real playlist below. Might be suboptimal.
                    do
                    {
                        playlistPosition = new Random().Next(0, _Playlist.getSongs().Count);
                        CurrentSong = _Playlist.getSongs()[playlistPosition];
                    } while (!AllowSong(CurrentSong));
                    return CurrentSong;
                }
                else
                {
                    //TODO: Catch these exceptions where GetNextSong() is called
                    throw new NothingToPlayException("Der nächste Song sollte gespielt werden, aber es war keiner vorhanden.");
                }
            }
            else
            {
                // Sequential: Just get the pointer and if it is not at the end (or -1 when there are no songs), get the next song and increase the pointer.
                if (playlistPosition < _Playlist.getSongs().Count - 1)
                {
                    if (_Playlist.getSongs().Count > 0)
                    {
                        playlistPosition++;
                        CurrentSong = _Playlist.getSongs()[playlistPosition];
                        return CurrentSong;
                    }
                }
                else
                {
                    //TODO: Catch these exceptions where GetNextSong() is called
                    throw new NothingToPlayException("Der nächste Song sollte gespielt werden, aber es war keiner vorhanden.");
                }
            }

            return null;
        }

        public bool AllowSong(Song song)
        {
            //TODO: All song filtering goes here
            bool result = true;

            // Don't play songs that have already been played.
            result = result && !(PlayedHistory.getSongs().Contains(song));

            // Don't play songs that have been played or skipped before the entire playlist has been played or skipped.
            result = result && usedPlaylist.getSongs().Contains(song);

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
                if (ExcludeSkipped)
                    usedPlaylist.RemoveSong(CurrentSong);
                // Playback is running, skip to the next song
                try
                {
                    PlaySong(GetNextSong());
                }
                catch (NothingToPlayException E)
                {

                }
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

        #region Playlist control
        public void ClearPlaylist()
        {
            _Playlist = new Songpool();
            usedPlaylist = new Songpool();
            playlistPosition = -1;
            PlaylistChanged(new string[0]);
        }

        public bool AddSongToPlaylist(Song song)
        {
            //TODO: And more settings... allow adding duplicates to the current playlist?
            usedPlaylist.AddSong(song);
            bool result = _Playlist.AddSong(song);
            if(result)
                PlaylistChanged(_Playlist.ToArray());
            return result;
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Search all the Audiofilepools for a song.
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
        private string FindAudiofile(Song song)
        {
            //TODO: Haha, here is a lot of work to do.
            return Program.ActiveDatabase.GetFileForSong(song);

        }

        public int FindSongInPlaylist(Song song)
        {
            return _Playlist.getSongs().FindIndex(delegate(Song needle) { return needle.Equals(song); });
        }
        #endregion

        public void ScrobbelSong(Song song)
        {
        }
    }
}
