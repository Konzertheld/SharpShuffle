using System;
using System.Collections.Generic;
using System.Text;
using Tags;
using Tags.ID3;
using Tags.ASF;
using System.IO;
using Tags.Objects;

namespace TagEditor.Columns
{
    public enum ColumnTypes
    {
        Tag,
        FileInfo
    }

    public class ListColumn
    {
        private string _Name;
        private string _ID;
        private int _Width;

        public ListColumn(string Name, string ID)
        {
            _ID = ID;
            _Name = Name;
            Width = 100;
        }

        public ListColumn()
        {
            _Width = 100;
        }

        /// <summary>
        /// Name of columns
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string GetValue(ITagInfo Data)
        {
            if (this.ColumnType == ColumnTypes.Tag)
            {
                if (Data.GetType() == typeof(ID3Info))
                    return GetID3Info((ID3Info)Data);
                else
                    return GetASFInfo((ASFTagInfo)Data);
            }
            else
                return GetFileInfo(Data);
        }

        string GetASFInfo(ASFTagInfo Tag)
        {
            if (Tag.ExContentDescription == null)
                return "";

            object D = Tag.ExContentDescription[ID];
            return D == null ? "" : D.ToString();
        }

        string GetID3Info(ID3Info Tag)
        {
            return Tag.ID3v2Info.GetTextFrame(ID);
        }

        string GetFileInfo(ITagInfo Tag)
        {
            switch (Name)
            {
                case "File Name":
                    return Tag.FileName;
                case "Path":
                    return Tag.FilePath;
                case "ID3v1":
                    return (((ID3Info)Tag).ID3v1Info.HaveTag) ? "*" : "";
                case "ID3v2":
                    return (((ID3Info)Tag).ID3v2Info.HaveTag) ? "*" : "";
                case "Size":
                    FileInfo F = new FileInfo(Tag.FilePath);
                    return Program.GetLengthString(F.Length);
                case "Tag Size":
                    return ((ID3Info)Tag).ID3v2Info.Length.ToString();
                default:
                    throw new ArgumentException(Name + " is unknown param.");
            }
        }

        /// <summary>
        /// Get current column type
        /// </summary>
        public ColumnTypes ColumnType
        {
            get
            { return (ID == null || ID == "") ? ColumnTypes.FileInfo : ColumnTypes.Tag; }
        }

        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;

            if (Name == ((ListColumn)obj).Name)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
