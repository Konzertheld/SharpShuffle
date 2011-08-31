using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using TagEditor.Properties;
using System.Threading;

namespace TagEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

#if !DEBUG
            Splash frmSplash = new Splash();
            frmSplash.ShowDialog();
#endif

            Settings.Default.Reload();

            if (!ShowAgreement())
                return;

            _MainForm = new MainDialog();
            Application.Run(_MainForm);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionDialog frmEx = new ExceptionDialog(e.Exception.StackTrace);
            frmEx.ShowDialog();
        }

        static private bool ShowAgreement()
        {
            if (Settings.Default.ShowAgreement)
            {
                Agreement frmAgreement = new Agreement();
                if (frmAgreement.ShowDialog() != DialogResult.OK)
                    return false;
            }

            return true;
        }

        public static string GetLengthString(long Length)
        {
            string Ext = "B";
            double L = Length;
            if (L > 1024)
            {
                L /= 1024;
                Ext = "kB";
            }

            if (L > 1024)
            {
                L /= 1024;
                Ext = "MB";
            }

            return L.ToString("N2") + " " + Ext;
        }

        private static MainDialog _MainForm;
        /// <summary>
        /// MainForm of application
        /// </summary>
        public static MainDialog MainForm
        {
            get
            { return _MainForm; }
        }

        /// <summary>
        /// Get name + version of application
        /// </summary>
        static public string SoftwareCompleteName
        {
            get
            {
                string[] Ver = Application.ProductVersion.Split('.');
                return Application.ProductName + " " + Ver[0] + "." + Ver[1];
            }
        }

        /// <summary>
        /// Gets specific assembly version
        /// </summary>
        /// <param name="AssemblyName">Name of assembly</param>
        /// <returns>String contains assembly version</returns>
        static public string GetAssemblyVersion(string AssemblyName)
        {
            Assembly Asm = Assembly.Load(AssemblyName);
            AssemblyFileVersionAttribute VerAtt = Asm.GetCustomAttributes(typeof(AssemblyFileVersionAttribute),
                false)[0] as AssemblyFileVersionAttribute;
            string[] Ver = VerAtt.Version.Split('.');
            return Ver[0] + "." + Ver[1];
        }
    }
}