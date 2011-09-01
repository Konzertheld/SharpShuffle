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

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //TODO: Load instead of create config
            GlobalConfig = Config.Load(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + System.Windows.Forms.Application.ProductName);
            if (GlobalConfig == null)
                GlobalConfig = new Config();
            if (!Directory.Exists(GlobalConfig.Appdatapath)) Directory.CreateDirectory(GlobalConfig.Appdatapath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Mainform());
        }
    }
}
