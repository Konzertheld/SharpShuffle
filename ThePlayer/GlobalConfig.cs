using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    [Serializable]
    class GlobalConfig
    {
        public static string[] ALLOWED_EXTENSIONS = { "mp3", "ogg", "wma", "asf", "flac" };

        //Folders in which the program should always look for audiofile instances of songs.
        private List<string> _sourceFolders;
        public void AddSourceFolder(string path)
        {
            path = path.ToLower();
            if (System.IO.Directory.Exists(path) && !_sourceFolders.Contains(path)) _sourceFolders.Add(path);
        }
        public void RemoveSourceFolder(string path)
        {
            path = path.ToLower();
            if (_sourceFolders.Contains(path)) _sourceFolders.Remove(path);
        }
    }
}
