using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tags;

namespace ThePlayer
{
    [Serializable]
    class Audiofile
    {
        public String Filepath { get; private set; }
        public Song Track { get; set; }

        /// <summary>
        /// Creates a new instance of Audiofile based on an existing file.
        /// </summary>
        /// <param name="filepath"></param>
        public Audiofile(string filepath)
        {
            Filepath = filepath;
            Track = new Song();
            ReadTags();
        }

        /// <summary>
        /// Creates a new instance of Audiofile based on a specific song.
        /// </summary>
        /// <param name="source"></param>
        public Audiofile(Song source)
        {
            // TODO How should this happen? We can't instance Audiofile when there is no file. It has no use then.
        }

        /// <summary>
        /// Read the tags from the file and save them in the Song object. Useful when creating a new pool of songs.
        /// </summary>
        public void ReadTags()
        {
            ITagInfo info;
            switch (Path.GetExtension(this.Filepath))
            {
                case ".mp3":
                    info = new Tags.ID3.ID3Info(this.Filepath, true);
                    foreach (Tags.ID3.ID3v2Frames.TextFrames.TextFrame frame in ((Tags.ID3.ID3Info)info).ID3v2Info.TextFrames)
                        Track.setInformation(Song.getField(frame.FrameID), frame.Text);
                    break;
                case ".wma":
                case ".asf":
                    info = new Tags.ASF.ASFTagInfo(this.Filepath, true);
                    foreach (Tags.Objects.Descriptor crap in ((Tags.ASF.ASFTagInfo)info).ExContentDescription)
                        if (crap != null) Track.setInformation(Song.getField(crap.Name), crap.Value.ToString());
                    break;
                case ".flac":
                case ".ogg":
                    OggReader ogginfo = new OggReader(this.Filepath);
                    foreach (KeyValuePair<string, string> tag in ogginfo.AllTheInformation)
                        Track.setInformation(Song.getField(tag.Key), tag.Value);
                    break;
                default:
                    throw new Exception("Not a supported format or not an audio file");
            }
        }


    }
}
