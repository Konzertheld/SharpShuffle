using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ThePlayer
{
    class Audiofolder
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

        public static List<Song> ReadMeta(string path)
        {
            List<Song> result = new List<Song>();
            foreach (Song s in Read(path).Values)
                result.Add(s);
            return result;
        }

        /// <summary>
        /// Search a pool's basepath and link the files to meta in the database. Useful after ReadSongs().
        /// </summary>
        /// <param name="pool">The pool's name.</param>
        public static void LinkFiles(string pool)
        {
            // This is for updating pools.
            // Get the pool's path
            // Do almost the same as ReadSongs with one more thing: Link the read meta to the path. Maybe read less meta.
            // Lookup meta in the database
            // Write files to files table with looked up id
        }

        public static void ProcessFolder(string path, bool savemeta, bool linkfiles, bool makepool)
        {
            //TODO: Let the user enter a name (for both audiofilepool and songpool)
            string poolname = Path.GetFileName(path);

            Dictionary<string, Song> read = Audiofolder.Read(path);
            List<Song> songs = new List<Song>(read.Values);
            List<string> files = new List<string>(read.Keys);
            int[] ids = null;
            ids = Program.ActiveDatabase.ManageSongs(songs, savemeta);
            songs.FindAll(delegate(Song test) { return (test.id == 0); });

            if (linkfiles)
            {
                List<Audiofile> audiofiles = new List<Audiofile>();
                for (int i = 0; i < files.Count; i++)
                    audiofiles.Add(new Audiofile(-1, files[i], ids[i]));
                Program.ActiveDatabase.ManageAudiofiles(audiofiles);
            }

            // Create a songpool and add the songs / add the songs to the existing songpool. Make sure the meta was saved before.
            if (makepool && savemeta)
            {
                Songpool newpool = new Songpool(songs, poolname);
            }
        }
    }
}
