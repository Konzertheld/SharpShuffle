using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SharpShuffle
{
    class Filemanagement
    {
        /// <summary>
        /// Read meta from files and return a dictionary where you can lookup the meta by the file.
        /// </summary>
        /// <param name="path">Folder to look for songs.</param>
        /// <returns></returns>
        public static Dictionary<string, Song> Read(string path)
        {
            Dictionary<string, Song> data = new Dictionary<string, Song>();
            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            foreach (string file in files)
            {
                if (Program.ALLOWED_EXTENSIONS.Contains(Path.GetExtension(file).Substring(1)))
                    data.Add(file, Song.ReadTags(file));
            }
            return data;
        }

        public static void ProcessFolder(string path)
        {
        }
    }
}
