using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TagEditor.Properties;
using System.Xml.Serialization;
using System.Windows.Forms;
using Tags;

namespace TagEditor.Columns
{
    /// <summary>
    /// Provide a class to save & load Column information
    /// </summary>
    static class ColumnsCollection
    {
        static ListColumn[] _DefaultM = {   new ListColumn("File Name",""),
                                            new ListColumn("Track Number", "TRCK"),
                                            new ListColumn("Title", "TIT2"),
                                            new ListColumn("Lead Artist", "TPE1"),
                                            new ListColumn("Album", "TALB"),
                                            new ListColumn("ID3v1",""),
                                            new ListColumn("ID3v2", "")};

        static ListColumn[] _DefaultW = {   new ListColumn("File Name",""),
                                            new ListColumn("Track Number","WM/TrackNumber"),
                                            new ListColumn("Title","Title"), 
                                            new ListColumn("Artist","WM/AlbumArtist"),
                                            new ListColumn("Album","WM/AlbumTitle")};

        static string FilePath
        {
            get
            {
                string FileName = (LastLoad == TagListTypes.ASF) ? Resources.ACFileName : Resources.MCFileName;
                return Path.Combine(Application.UserAppDataPath, FileName);
            }
        }

        static List<ListColumn> _Columns;
        public static List<ListColumn> Columns
        {
            get
            {
                if (_Columns == null)
                {
                    _Columns = new List<ListColumn>();
                    Load(Program.MainForm.ListType);
                }
                return _Columns;
            }
        }

        public static void Load(TagListTypes ListType)
        {
            string FileName = (ListType == TagListTypes.ASF) ? Resources.ACFileName : Resources.MCFileName;
            FileName = Path.Combine(Application.UserAppDataPath, FileName);

            Columns.Clear();

            XmlSerializer S = new XmlSerializer(typeof(ListColumn[]));
            if (!File.Exists(FileName))
            {
                _Columns.AddRange((ListType != TagListTypes.ASF) ? _DefaultM : _DefaultW);
                _LastLoad = ListType;
                return;
            }

            FileStream FS = new FileStream(FileName, FileMode.Open);
            Columns.AddRange((ListColumn[])S.Deserialize(FS));

            FS.Close();

            _LastLoad = ListType;
        }

        public static void Save()
        {
            XmlSerializer S = new XmlSerializer(typeof(ListColumn[]));
            FileStream File = new FileStream(FilePath, FileMode.Create);
            S.Serialize(File, Columns.ToArray());
            File.Close();
        }

        public static ListColumn[] Default
        {
            get
            {
                return (Program.MainForm.ListType != TagListTypes.ASF) ? _DefaultM : _DefaultW;
            }
        }

        static TagListTypes _LastLoad = TagListTypes.Both;
        static TagListTypes LastLoad
        {
            get
            { return _LastLoad; }
        }
    }
}
