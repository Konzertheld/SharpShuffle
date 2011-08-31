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
    public static class Scrobbel
    {
        public static void Scrobbeln(string artist, string title, DateTime datetime)
        {
            // Get your own API_KEY and API_SECRET from http://www.last.fm/api/account
            string API_KEY = "fee70a420b127f4630f354545423de8b";
            string API_SECRET = "5615f2192e4187622c0b4ecf6e059b26";
            Session session;
            BinaryFormatter binFormatter;

            //Prüfe, ob Auth gespeichert ist
            if (File.Exists("C:\\lastfmauth.dat"))
            {
                binFormatter = new BinaryFormatter();
                FileStream fs = new FileStream(@"C:\lastfmauth.dat", FileMode.Open);
                session = (Session)binFormatter.Deserialize(fs);
                fs.Close();
            }
            else
            {

                // Creating an unauthenticated session that could only allow me
                // to perform read operations.
                session = new Session(API_KEY, API_SECRET);

                // Generate a web authentication url
                string url = session.GetWebAuthenticationURL();

                Clipboard.SetText(url);
                MessageBox.Show("done");

                session.AuthenticateViaWeb();

                //Save Auth
                FileStream myStream;
                myStream = new FileStream(@"C:\lastfmauth.dat", FileMode.Create);
                binFormatter = new BinaryFormatter();
                binFormatter.Serialize(myStream, session);
                myStream.Close();
            }
            
            // You can now use the "session" object with everything in your project.
            ScrobbleManager man = new ScrobbleManager(new Connection("tst", "1.0", "Konzertheld", session));
            man.Queue(new Entry(artist, title, datetime, PlaybackSource.User, new TimeSpan(0, 3, 30), ScrobbleMode.Played));
            
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
