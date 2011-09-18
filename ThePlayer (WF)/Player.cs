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
    enum PLAYBACKMODE
    {
        Playlist,
        History
    }

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
        #region Attributes
        /// <summary>
        /// Songs to play
        /// </summary>
        private Songpool _Playlist { get; set; }
        /// <summary>
        /// A copy of the playlist. Skipped and played songs are removed from this one.
        /// </summary>
        private Songpool internalPlaylist { get; set; }
        /// <summary>
        /// Songs that have been played. Technically: Songs that matched the "mark the song as played" criterias.
        /// </summary>
        public Songpool PlayedHistory { get; set; }
        /// <summary>
        /// Similar to history and playlist, but includes skipped songs. Technically a sequencial list of all Songs that have been passed to PlaySong() and were found as an Audiofile.
        /// </summary>
        private Songpool totalHistory { get; set; }

        public PlayerView UI;

        /// <summary>
        /// Audiofilepools to use when looking for a file that matches a song.
        /// </summary>
        public List<Audiofilepool> Audiosources;

        private IVideoPlayer vlc;
        private IMediaPlayerFactory factory;

        private Song _currentSong;
        public Song CurrentSong { get { return _currentSong; } private set { currentSongLogged = false; _currentSong = value; } }
        private bool currentSongLogged;

        public event PlayerPositionChangedHandler PositionChanged;
        public event PlaylistEndedHandler PlaylistEnded;

        public bool IsPlaying { get; private set; }
        public bool PlayRandom { get; set; }

        /// <summary>
        /// Helper variable for navigation. If we are navigating (prev and next) through songs that have already been played, they are not logged again.
        /// </summary>
        private PLAYBACKMODE mode;
        /// <summary>
        /// Null-based index of the current song in the playlist or -1 when the current song is not in the playlist.
        /// </summary>
        private int playlistPosition;
        private int historyPosition;
        #endregion

        #region Constructors
        public Player()
        {
            // Initialization
            _Playlist = new Songpool();
            internalPlaylist = new Songpool();
            UI = new PlayerView();
            PlayedHistory = new Songpool();
            totalHistory = new Songpool();
            Audiosources = new List<Audiofilepool>();
            IsPlaying = false;
            playlistPosition = -1;
            historyPosition = -1;
            PlayRandom = true;

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
            Song result;

            // What are we playing? Songs we already navigated to with Next and Prev? Then play all of them until there are no more before we do anything else.
            if (historyPosition < totalHistory.getSongs().Count - 1)
            {
                //TODO: Optionally pass totalhistory songs to the filters
                historyPosition++;
                mode = PLAYBACKMODE.History;
                result = totalHistory.getSongs()[historyPosition];
            }
            else
            {
                // We are not playing songs from navigation so tell PlaySong() to log everything no matter what song we decide to play.
                mode = PLAYBACKMODE.Playlist;

                // If we ran out of songs and playlist-repeat is on, refill the internal playlist.
                //TODO: Repeatmode
                if (internalPlaylist.getSongs().Count == 0 && true)
                    internalPlaylist = new Songpool(_Playlist.getSongs());

                // What are we playing? Sequencial or random playlist?
                if (PlayRandom)
                {
                    if (_Playlist.getSongs().Count > 0)
                    {
                        do
                        {
                            playlistPosition = new Random().Next(0, _Playlist.getSongs().Count);
                            result = _Playlist.getSongs()[playlistPosition];
                        } while (!AllowSong(result));
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
                            result = _Playlist.getSongs()[playlistPosition];
                        }
                        else
                            //TODO: Do we ever reach this?
                            throw new NothingToPlayException("Der nächste Song sollte gespielt werden, aber es war keiner vorhanden.");
                    }
                    else
                    {
                        //TODO: Catch these exceptions where GetNextSong() is called
                        throw new NothingToPlayException("Der nächste Song sollte gespielt werden, aber es war keiner vorhanden.");
                    }
                }
            }

            return result;
        }

        private bool AllowSong(Song song)
        {
            //TODO: All song filtering goes here
            bool result = true;

            // Don't play songs that have already been played.
            result = result && !(PlayedHistory.getSongs().Contains(song));

            // Don't play songs that have been skipped before the entire playlist has been played or skipped.
            result = result && internalPlaylist.getSongs().Contains(song);

            return result;
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
                IsPlaying = true;
                if (mode == PLAYBACKMODE.Playlist)
                {
                    totalHistory.AddSong(song, true);
                    internalPlaylist.RemoveSong(CurrentSong);
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
            IsPlaying = false;
        }

        public int NextSong()
        {
            //TODO: Consider doing nothing or just moving the playlist pointer when playback is not running.
            try
            {
                PlaySong(GetNextSong());
            }
            catch (NothingToPlayException E)
            {

            }
            return (mode == PLAYBACKMODE.Playlist) ? playlistPosition : positionInPlaylist(totalHistory.getSongs()[historyPosition]);
        }

        public int PrevSong()
        {
            if (historyPosition > 0 && historyPosition < totalHistory.getSongs().Count)
            {
                historyPosition--;
                mode = PLAYBACKMODE.History;
                PlaySong(totalHistory.getSongs()[historyPosition]);
                return positionInPlaylist(totalHistory.getSongs()[historyPosition]);
            }
            return positionInPlaylist(totalHistory.getSongs()[historyPosition]);
        }
        #endregion

        #region Playlist control
        public void ClearPlaylist()
        {
            _Playlist = new Songpool();
            internalPlaylist = new Songpool();
            playlistPosition = -1;
        }

        public bool AddSongToPlaylist(Song song)
        {
            internalPlaylist.AddSong(song);
            return _Playlist.AddSong(song);
        }
        #endregion

        #region Helper methods
        private int positionInPlaylist(Song needle)
        {
            return _Playlist.getSongs().FindIndex(delegate(Song song) { return song.Equals(needle); });
        }
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

        private void raisePlaylistEnded()
        {
            IsPlaying = false;
            if (PlaylistEnded != null) PlaylistEnded();
        }
        #endregion

        public void ScrobbelSong(Song song)
        {
        }
    }

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
            Sorting = new List<string>(new string[3] { Song.META_ARTISTS, Song.META_ALBUM, Song.META_TRACK});
        }

        public void ChangePools(string[] indices)
        {
            view = new Songpool();
            foreach (string s in indices)
            {
                foreach (Song song in Program.Songpools[s].getSongs(Sorting))
                    view.AddSong(song);
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
    }
}
