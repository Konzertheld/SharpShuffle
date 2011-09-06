using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ThePlayer
{
    //TODO: Find out if this can used like "is x element of ALLOWED_EXTENSIONS", if not, remove it
    public enum ALLOWED_EXTENSIONS
    {
        aac,
        aif,
        aiff,
        ape,
        asf,
        mp3,
        ogg,
        wma,
        wav,
        flac,
        m4a
    }

    public enum META_IDENTIFIERS : short
    {
        Album = 1,
        AlbumArtists,
        AmazonID,
        Artists,
        BPM,
        Comment,
        Composers,
        Conductor,
        Copyright,
        Disc,
        DiscCount,
        Genres,
        Lyrics,
        Title,
        TrackNr,
        TrackCount,
        Year
    }

    static class Program
    {

        /// <summary>
        /// The user's songpools.
        /// </summary>
        public static Dictionary<string, Songpool> Songpools;

        /// <summary>
        /// The user's audiofilepools.
        /// </summary>
        public static Dictionary<string, Audiofilepool> Audiofilepools;

        /// <summary>
        /// File types handled by this application. In fact, all TagLib# is able to handle.
        /// </summary>
        public static string[] ALLOWED_EXTENSIONS = { "aac", "aif", "aiff", "ape", "asf", "mp3", "ogg", "wma", "wav", "flac", "m4a" };

        /// <summary>
        /// The global application configuration. Contains all the settings.
        /// </summary>
        public static Config GlobalConfig;

        public static Player ActivePlayer;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Load configuration
            GlobalConfig = new Config();
            GlobalConfig.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + System.Windows.Forms.Application.ProductName);
            if (GlobalConfig == null)
                GlobalConfig = new Config();

            // Create directories, they're needed for loading
            if (!Directory.Exists(GlobalConfig.Appdatapath)) Directory.CreateDirectory(GlobalConfig.Appdatapath);
            if (!Directory.Exists(GlobalConfig.Appdatapath + "\\songpools")) Directory.CreateDirectory(GlobalConfig.Appdatapath + "\\songpools");
            if (!Directory.Exists(GlobalConfig.Appdatapath + "\\audiofilepools")) Directory.CreateDirectory(GlobalConfig.Appdatapath + "\\audiofilepools");

            // Initialize and load stuff
            Songpools = new Dictionary<string, Songpool>();
            LoadSongpools();
            Audiofilepools = new Dictionary<string, Audiofilepool>();
            LoadAudiofilepools();

            //TODO: Load instead of create new player
            //TODO: Add audio sources when created, not only at program start
            ActivePlayer = new Player();
            foreach (Audiofilepool afp in Program.Audiofilepools.Values)
            {
                ActivePlayer.Audiosources.Add(afp);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Mainform());
        }

        public static void LoadSongpools()
        {
            foreach (string file in Directory.GetFiles(GlobalConfig.Appdatapath + "\\songpools"))
            {
                Songpool s = Songpool.Load(file);
                Songpools.Add(s.Name, s);
            }
        }

        public static void LoadAudiofilepools()
        {
            foreach (string file in Directory.GetFiles(GlobalConfig.Appdatapath + "\\audiofilepools"))
            {
                Audiofilepool a = Audiofilepool.Load(file);
                Audiofilepools.Add(a.Name, a);
            }
        }

        public static bool SaveSongpools()
        {
            bool result = true;
            foreach (Songpool s in Songpools.Values) 
                result = result && s.Save();
            return result;
        }

        public static bool SaveAudiofilepools()
        {
            bool result = true;
            foreach (Audiofilepool a in Audiofilepools.Values)
                result = result && a.Save();
            return result;
        }
    }
}
