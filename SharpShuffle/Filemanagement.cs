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
                if (Startup.ALLOWED_EXTENSIONS.Contains(Path.GetExtension(file).Substring(1)))
                    data.Add(file, Song.ReadTags(file));
            }
            return data;
        }

        /// <summary>
        /// Scan a folder for songs. Read the meta and save it to the database (if necessary). Optionally save the filepaths and insert the songs into a pool.
        /// </summary>
        /// <param name="path">Path to a folder to scan.</param>
        /// <param name="keepfiles">Set to true to save the filepaths to the database (otherwise they won't be available for playback).</param>
        /// <param name="poolname">Name of the pool to put the songs in. Can be an existing pool. Leave empty if you don't want to put them in a pool.</param>
        public static void ProcessFolder(string path, bool keepfiles, string poolname)
        {
            // Scan
            Dictionary<string, Song> scanresult = Read(path);
            // Insert
            Startup.ActiveDB.InsertSongs(scanresult.Values);
            // Load ids of skipped songs (songs that already existed)
            List<Song> scannedsongs = new List<Song>(scanresult.Values);
            Startup.ActiveDB.LoadSongIDs(scannedsongs.FindAll(delegate(Song test) { return test.id == 0; }));
            // Put songs in pool if requested
            if (poolname != "")
            {
                Startup.ActiveDB.CreateSongpool(poolname);
                Startup.ActiveDB.PutSongsInPool(scannedsongs, poolname);
            }
            // Put audiofiles in database and link with songs if requested
            if (keepfiles)
            {
                Startup.ActiveDB.ManageAudiofiles(scanresult);
            }
        }
    }
}
