﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    class Audiofilepool
    {
        public string Basepath { get; set; }
        private List<Audiofile> audiofiles;

        public Audiofilepool(string path)
        {
            audiofiles = new List<Audiofile>();
            string[] files = (string[])Directory.GetFiles(path);

            foreach (string file in files)
            {
                if (GlobalConfig.ALLOWED_EXTENSIONS.Contains(Path.GetExtension(file).Substring(1)))
                {
                    audiofiles.Add(new Audiofile(file));
                }
            }
        }

        public Songpool createSongpool()
        {
            List<Song> songs = new List<Song>();
            foreach (Audiofile audiofile in audiofiles)
            {
                songs.Add(audiofile.Track);
            }
            return new Songpool(songs);
        }
    }
}
