using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle
{
    class Startup
    {
        public const string AppName = "SharpShuffle";
        public static Database ActiveDB;

        /// <summary>
        /// File types handled by this application. In fact, all TagLib# is able to handle.
        /// </summary>
        public static string[] ALLOWED_EXTENSIONS = { "aac", "aif", "aiff", "ape", "asf", "mp3", "ogg", "wma", "wav", "flac", "m4a" };

        [STAThread]
        public static void Main()
        {
            ActiveDB = new Database(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + AppName + "\\database.db");
            ActiveDB.ClearDB();
            long vorher = DateTime.Now.Ticks;
            XML.ReadITunesXML(@"C:\Users\Christian\Documents\Winamp-Bib-Beispielmaterial\Netbook.xml");
            long nachher = DateTime.Now.Ticks;
            long diffms = (nachher - vorher) / 10000;
            App app = new App();
            app.MainWindow = new MainWindow();
            app.MainWindow.Show();
            app.Run();
        }
    }
}
