using System;
using System.Collections.Generic;
using System.Linq;
using Lastfm;
using Lastfm.Scrobbling;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace ThePlayer
{
    //TODO: Store scrobbel queue when not online

    public enum ScrobbelType
    {
        Playing,
        Played
    }

    public delegate void LastFmAuthReadyHandler(string url, Session session);

    public static class Scrobbel
    {
        // Get your own API_KEY and API_SECRET from http://www.last.fm/api/account
        private static string API_KEY = "fee70a420b127f4630f354545423de8b";
        private static string API_SECRET = "5615f2192e4187622c0b4ecf6e059b26";
        private static Session session;

        public static event LastFmAuthReadyHandler LastFmAuthReady;

        /// <summary>
        /// Dirty method to tell a now playing song.
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="title"></param>
        public static void Scrobbeln(string artist, string title, int length)
        {
            Scrobbeln(artist, title, new DateTime(), length, ScrobbelType.Playing);
        }
        /// <summary>
        /// Quick and not-so-dirty method to scrobbel a song that has just been played.
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="title"></param>
        /// <param name="datetime"></param>
        /// <param name="length"></param>
        public static void Scrobbeln(string artist, string title, DateTime datetime, int length)
        {
            Scrobbeln(artist, title, datetime, length, ScrobbelType.Played);
        }
        /// <summary>
        /// Scrobbel a song on last.fm
        /// </summary>
        /// <param name="artist">Song's artist</param>
        /// <param name="title">Song's title</param>
        /// <param name="datetime">When the song was played</param>
        /// <param name="length">Song length in seconds</param>
        /// <param name="type">Whether the song is now playing or has just been played.</param>
        public static void Scrobbeln(string artist, string title, DateTime datetime, int length, ScrobbelType type)
        {
            BinaryFormatter binFormatter;

            //Prüfe, ob Auth gespeichert ist
            if (File.Exists(Program.GlobalConfig.Appdatapath + "\\lastfm.dat"))
            {
                binFormatter = new BinaryFormatter();
                FileStream fs = new FileStream(Program.GlobalConfig.Appdatapath + "\\lastfm.dat", FileMode.Open);
                session = (Session)binFormatter.Deserialize(fs);
                fs.Close();

                // You can now use the "session" object with everything in your project.
                ScrobbleManager man = new ScrobbleManager(new Connection("tst", "1.0", "Konzertheld", session));
                switch (type)
                {
                    case ScrobbelType.Playing:
                        man.ReportNowplaying(new NowplayingTrack(artist, title));
                        break;
                    case ScrobbelType.Played:
                        man.Queue(new Entry(artist, title, datetime, PlaybackSource.User, new TimeSpan(length / 3600, (length % 3600) / 60, length % 60), ScrobbleMode.Played));
                        break;
                }
            }
            else
            {
                throw new UnauthorizedAccessException("Could not scrobbel because no valid last.fm credentials were found.");
            }
        }

        public static void AuthorizeCall()
        {
            // Creating an unauthenticated session that could only allow me
            // to perform read operations.
            session = new Session(API_KEY, API_SECRET);

            // Generate a web authentication url
            LastFmAuthReady(session.GetWebAuthenticationURL(), session);
        }

        public static void AuthorizeDo(Session session)
        {
            session.AuthenticateViaWeb();

            //Save Auth
            FileStream fs;
            BinaryFormatter binFormatter = new BinaryFormatter();
            fs = new FileStream(Program.GlobalConfig.Appdatapath + "\\lastfm.dat", FileMode.Create);
            binFormatter = new BinaryFormatter();
            binFormatter.Serialize(fs, session);
            fs.Close();
        }

        /// <summary>
        /// Gibt einen MD5 Hash als String zurück
        /// </summary>
        /// <param name="TextToHash">string der Gehasht werden soll.</param>
        /// <returns>Hash als string.</returns>
        public static string GetMD5Hash(string TextToHash)
        {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = System.Text.Encoding.Default.GetBytes(TextToHash);
            byte[] result = md5.ComputeHash(textToHash);

            return System.BitConverter.ToString(result);
        }
    }
}
