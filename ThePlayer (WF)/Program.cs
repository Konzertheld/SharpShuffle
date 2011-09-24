using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace ThePlayer
{
    static class Program
    {
        /// <summary>
        /// File types handled by this application. In fact, all TagLib# is able to handle.
        /// </summary>
        public static string[] ALLOWED_EXTENSIONS = { "aac", "aif", "aiff", "ape", "asf", "mp3", "ogg", "wma", "wav", "flac", "m4a" };
        
        /// <summary>
        /// The global application configuration. Contains all the settings.
        /// </summary>
        public static Config GlobalConfig;

        public static Player ActivePlayer;
        public static PlayerView ActivePlayerUI;

        public static Database ActiveDatabase;

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Load configuration
            GlobalConfig = new Config();
            //GlobalConfig.Load();

            ActiveDatabase = new Database();

            // Create directories, they're needed for loading
            if (!Directory.Exists(GlobalConfig.Appdatapath)) Directory.CreateDirectory(GlobalConfig.Appdatapath);

            //TODO: Load instead of create new player
            //TODO: Add audio sources when created, not only at program start
            ActivePlayer = new Player();
            ActivePlayerUI = new PlayerView();
            //foreach (Audiofilepool afp in Program.Audiofilepools.Values)
            //{
            //    ActivePlayer.Audiosources.Add(afp);
            //}

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mainform());
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            ActiveDatabase.CloseDB();
        }
    }
}
