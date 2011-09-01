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

    public enum META_IDENTIFIERS
    {
        Artist,
        Title,
        Genre,
        Album
    }

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

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GlobalConfig = new Config();
            GlobalConfig.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + System.Windows.Forms.Application.ProductName);
            if (GlobalConfig == null)
                GlobalConfig = new Config();
            if (!Directory.Exists(GlobalConfig.Appdatapath)) Directory.CreateDirectory(GlobalConfig.Appdatapath);

            //TODO: Load instead of create new player
            ActivePlayer = new Player();
            foreach (Audiofilepool afp in GlobalConfig.Audiofilepools.Values)
            {
                ActivePlayer.Audiosources.Add(afp);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Mainform());
        }
    }
}
