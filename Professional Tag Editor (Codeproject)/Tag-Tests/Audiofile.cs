using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tags;

namespace Tag_Tests
{
    class Audiofile
    {
        /// <summary>
        /// Creates a new instance of Audiofile based on an existing file.
        /// </summary>
        /// <param name="filepath"></param>
        public Audiofile(string filepath)
        {
            Pfad = filepath;

            //Read all the tag stuff
            Track = new Song();
            ITagInfo info;
            switch (Path.GetExtension(filepath))
            {
                case ".mp3":
                    info = new Tags.ID3.ID3Info(filepath, true);
                    foreach (Tags.ID3.ID3v2Frames.TextFrames.TextFrame frame in ((Tags.ID3.ID3Info)info).ID3v2Info.TextFrames)
                        Track.SetField(Song.getField(frame.FrameID), frame.Text);
                    break;
                case ".wma":
                case ".asf":
                    info = new Tags.ASF.ASFTagInfo(filepath, true);
                    foreach (Tags.Objects.Descriptor crap in ((Tags.ASF.ASFTagInfo)info).ExContentDescription)
                        if (crap != null) Track.SetField(Song.getField(crap.Name), crap.Value.ToString());
                    break;
                case ".ogg":
                    JockerSoft.OggReader ogginfo = new JockerSoft.OggReader(filepath);
                    foreach (KeyValuePair<string, string> tag in ogginfo.AllTheInformation)
                        Track.SetField(Song.getField(tag.Key), tag.Value);
                    break;
                default:
                    throw new Exception("Not a supported format or not an audio file");
            }
        }

        /// <summary>
        /// Creates a new instance of Audiofile based on a specific song.
        /// </summary>
        /// <param name="source"></param>
        public Audiofile(Song source)
        {
        }

        public String Pfad { get; private set; }
        public Song Track { get; set; }
    }
}
