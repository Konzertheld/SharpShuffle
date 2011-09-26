using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle
{
    class Startup
    {
        [STAThread]
        static void main()
        {
            App app = new App();
            app.MainWindow = new MainWindow();
            app.MainWindow.Show();
            app.Run();
        }
    }
}
