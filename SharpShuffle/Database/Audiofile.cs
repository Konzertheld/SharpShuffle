using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle.Database
{
    struct Audiofile
    {
        public Audiofile(int id, string path, int idmeta)
        {
            this.id = id;
            this.Path = path;
            this.idMeta = idmeta;
        }

        public int id;
        public string Path;
        public int idMeta;
    }
}
