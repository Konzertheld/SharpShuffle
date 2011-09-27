﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle
{
    class Startup
    {
        public const string AppName = "SharpShuffle";
        public static Database.Database ActiveDB;

        [STAThread]
        static void main()
        {
            ActiveDB = new Database.Database(Environment.SpecialFolder.ApplicationData + "\\" + AppName + "\\database.db");

            App app = new App();
            app.MainWindow = new MainWindow();
            app.MainWindow.Show();
            app.Run();
        }
    }
}
