using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using TagEditor.Properties;
using Tags;
using Tags.ID3;
using Tags.ASF;
using Tags.ID3.ID3v2Frames.TextFrames;
using System.Reflection;
using TagInfoControls;
using Tags.ID3.ID3v2Frames.BinaryFrames;
using Tags.ID3.ID3v2Frames;
using Tags.Objects;

namespace TagEditor.Templates
{
    public enum TemplateCopyTypes
    {
        CleanCopy,
        SafeCopy,
        Overwrite
    }

    public class Template
    {
        private const string ID3TemplateExtension = ".itm";
        private const string ASFTemplateExtension = ".atm";

        public Template(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
            TagType = TagTypes.ID3;
            _CopyType = TemplateCopyTypes.SafeCopy;
        }

        public Template(string Name, string Description, TagTypes TagType)
        {
            this.Name = Name;
            this.Description = Description;
            this.TagType = TagType;
            _CopyType = TemplateCopyTypes.SafeCopy;
        }

        public Template()
        {
            Name = "";
            Description = "";
            TagType = TagTypes.ID3;
            _CopyType = TemplateCopyTypes.SafeCopy;
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value == Name)
                    return;

                if (File.Exists(FilePath))
                    File.Move(FilePath, GetFilePath(value));

                _Name = value;

                if (_Tag != null)
                    Load();
            }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private ITagInfo _Tag;
        [XmlIgnore()]
        public ITagInfo Tag
        {
            get
            {
                if (_Tag == null)
                    Load();

                return _Tag;
            }
            private set
            {
                _Tag = value;
            }
        }

        private TemplateCopyTypes _CopyType;
        public TemplateCopyTypes CopyType
        {
            get { return _CopyType; }
            set { _CopyType = value; }
        }

        private TagTypes _TagType;
        public TagTypes TagType
        {
            get { return _TagType; }
            set { _TagType = value; }
        }

        public static Template FromFile(string Filepath)
        {
            string Ext = Path.GetExtension(Filepath).ToLower();
            ITagInfo Tag;
            if (Ext == ".mp3" || Ext == ID3TemplateExtension)
            {
                ID3Info ID3 = new ID3Info(Filepath, true);

                ID3.ID3v2Info.AudioEncryptionFrames.Clear();
                ID3.ID3v2Info.Commercial = null;
                ID3.ID3v2Info.DataWithSymbolFrames.Clear();
                ID3.ID3v2Info.DropUnknowFrames = true;
                ID3.ID3v2Info.Equalisations = null;
                ID3.ID3v2Info.EventTimingCode = null;
                ID3.ID3v2Info.LinkFrames.Clear();
                ID3.ID3v2Info.MusicCDIdentifier = null;
                ID3.ID3v2Info.OwnerShip = null;
                ID3.ID3v2Info.PlayCounter = null;
                ID3.ID3v2Info.PopularimeterFrames.Clear();
                ID3.ID3v2Info.PositionSynchronised = null;
                ID3.ID3v2Info.PrivateFrames.Clear();
                ID3.ID3v2Info.RecomendedBuffer = null;
                ID3.ID3v2Info.RelativeVolume = null;
                ID3.ID3v2Info.Reverb = null;
                ID3.ID3v2Info.SynchronisedTempoCodes = null;
                ID3.ID3v2Info.SynchronisedTextFrames.Clear();
                ID3.ID3v2Info.TermOfUseFrames.Clear();
                ID3.ID3v2Info.UnKnownFrames.Clear();

                Tag = ID3;
            }
            else if (Ext == ".wma" || Ext == ASFTemplateExtension)
                Tag = new ASFTagInfo(Filepath, true);
            else
            {
                MessageBox.Show("'" + Ext + "' is not known file for this application", "File type error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Tag.IsTemplate = true;

            Template Temp = new Template(Tag.FileName, "");
            Temp.Tag = Tag;
            return Temp;
        }

        public static Template FromFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Mp3 file and template|*.mp3;*" + ID3TemplateExtension +
                "|Wma file and template|*.wma;*" + ASFTemplateExtension + "|All known files|*.mp3;*.wma;*" +
                ID3TemplateExtension + ";*" + ASFTemplateExtension;
            dlg.FilterIndex = 3;
            dlg.Title = "Open file for template";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == DialogResult.OK)
                return FromFile(dlg.FileName);
            return null;
        }

        public override string ToString()
        {
            return Name + ((TagType == TagTypes.ID3) ? " [MP3]" : " [WMA]");
        }

        public string FilePath
        {
            get
            { return GetFilePath(Name); }
        }

        private string GetFilePath(string name)
        {
            string Dir = Path.Combine(Application.UserAppDataPath, "Templates");
            if (TagType == TagTypes.ID3)
                return Path.Combine(Dir, name + ID3TemplateExtension);
            else
                return Path.Combine(Dir, name + ASFTemplateExtension);
        }

        public void Load()
        {
            string path = FilePath;
            if (!File.Exists(path))
                Tag = CreateFile(path);

            try
            {
                if (TagType == TagTypes.ID3)
                    Tag = new ID3Info(path, true);
                else
                    Tag = new ASFTagInfo(path, true);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Can't load '" + Name + "'\n" + Ex.Message + "\nApplication create new template instead of this template ?",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Tag = CreateFile(path);
            }
        }

        public void Save()
        {
            if (_Tag != null)
                _Tag.SaveAs(FilePath);
        }

        private ITagInfo CreateFile(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                Directory.CreateDirectory(Path.GetDirectoryName(path));

            if (TagType == TagTypes.ID3)
            {
                ID3Info T = new ID3Info(path, false);
                T.IsTemplate = true;
                T.ID3v1Info.HaveTag = true;
                T.ID3v2Info.HaveTag = true;
                T.Save();
                return T;
            }
            else
            {
                ASFTagInfo T = new ASFTagInfo(path, false);
                T.IsTemplate = true;
                T.ExContentDescription = new Tags.Objects.ExContentDescriptionOb();
                T.Save();
                return T;
            }
        }

        public void CopyTo(ITagInfo CopyTag)
        {
            CopyTo(CopyTag, CopyType);
        }

        public void CopyTo(ITagInfo CopyTag, TemplateCopyTypes CT)
        {
            if (CopyTag.GetType() != Tag.GetType())
                throw new ArgumentException("Parameter type is not valid for this template");

            if (CopyTag.GetType() == typeof(ID3Info))
                CopyTo(CopyTag as ID3Info, CT);
            else
                CopyTo(CopyTag as ASFTagInfo, CT);
        }

        public void CopyTo(ID3Info CopyTag, TemplateCopyTypes CT)
        {
            if (CT == TemplateCopyTypes.CleanCopy)
            {
                CopyTag.ID3v2Info.ClearAll();
                CopyTag.ID3v1Info.ClearAll();

                CopyTag.ID3v2Info.HaveTag = (this.Tag as ID3Info).ID3v2Info.HaveTag;
                CopyTag.ID3v1Info.HaveTag = (this.Tag as ID3Info).ID3v1Info.HaveTag;
            }

            foreach (TextFrame T in (Tag as ID3Info).ID3v2Info.TextFrames)
                if ((CT == TemplateCopyTypes.SafeCopy && CopyTag.ID3v2Info.GetTextFrame(T.FrameID) == "")
                    || CT != TemplateCopyTypes.SafeCopy)
                    if (FramesInfo.IsCompatible(T.FrameID, CopyTag.ID3v2Info.Version.Minor))
                        CopyTag.ID3v2Info.SetTextFrame(T.FrameID, T.Text);

            foreach (AttachedPictureFrame AP in (Tag as ID3Info).ID3v2Info.AttachedPictureFrames)
                if ((CT == TemplateCopyTypes.SafeCopy && !CopyTag.ID3v2Info.AttachedPictureFrames.Contains(AP))
                    || CT != TemplateCopyTypes.SafeCopy)
                    CopyTag.ID3v2Info.AttachedPictureFrames.Add(new AttachedPictureFrame(new FrameFlags(),
                        AP.Description, AP.TextEncoding, AP.MIMEType, AP.PictureType, AP.Data));

            foreach (TextWithLanguageFrame TWL in (Tag as ID3Info).ID3v2Info.TextWithLanguageFrames)
            {
                if (TWL.FrameID != "COMM")
                    continue;

                if ((CT == TemplateCopyTypes.SafeCopy && !CopyTag.ID3v2Info.TextWithLanguageFrames.Contains(TWL))
                    || CT != TemplateCopyTypes.SafeCopy)
                    CopyTag.ID3v2Info.TextWithLanguageFrames.Add(new TextWithLanguageFrame("COMM", new FrameFlags(), TWL.Text,
                        TWL.Description, TWL.TextEncoding, TWL.Language.LanguageID));
            }

            foreach (GeneralFileFrame F in (Tag as ID3Info).ID3v2Info.EncapsulatedObjectFrames)
                if ((CT == TemplateCopyTypes.SafeCopy && !CopyTag.ID3v2Info.EncapsulatedObjectFrames.Contains(F))
                         || CT != TemplateCopyTypes.SafeCopy)
                    CopyTag.ID3v2Info.EncapsulatedObjectFrames.Add(new GeneralFileFrame(new FrameFlags(), F.Description, F.MIMEType, F.TextEncoding,
                        F.FileName, F.Data));

            if ((Tag as ID3Info).ID3v1Info.HaveTag)
                SetProperty((Tag as ID3Info).ID3v1Info, CopyTag.ID3v1Info, "Album", "Artist",
                    "Comment", "Genre", "Title", "TrackNumber", "Year");
        }

        private void SetProperty(object Source, object Destination, params string[] Properties)
        {
            if (Source.GetType() != Destination.GetType())
                throw new ArgumentException("Both object types must be the same");

            PropertyInfo Pro;
            object val;
            object dval;
            for (int i = 0; i < Properties.Length; i++)
            {
                Pro = Source.GetType().GetProperty(Properties[i]);
                val = Pro.GetValue(Source, null);
                dval = Pro.GetValue(Destination, null);
                if (val == null || val.ToString() == "")
                    continue;

                if ((CopyType == TemplateCopyTypes.SafeCopy && (dval == null || dval.ToString() == ""))
                        || CopyType != TemplateCopyTypes.SafeCopy)
                    Pro.SetValue(Destination, val, null);
            }
        }

        public void CopyTo(ASFTagInfo CopyTag, TemplateCopyTypes CopyType)
        {
            ASFTagInfo T = Tag as ASFTagInfo;
            if (T.ContentBranding != null)
            {
                if (CopyTag.ContentBranding == null || CopyType == TemplateCopyTypes.CleanCopy)
                    CopyTag.ContentBranding = new Tags.Objects.ContentBrandingOb(T.ContentBranding.CopyrightURL,
                        T.ContentBranding.ImageURL, T.ContentBranding.Image,
                        T.ContentBranding.ImageType);
                else
                    SetProperty(T.ContentBranding, CopyTag.ContentBranding, "CopyrightURL", "Image", "ImageType", "ImageURL");
            }

            if (T.ContentDescription != null)
            {
                if (CopyTag.ContentDescription == null || CopyType == TemplateCopyTypes.CleanCopy)
                    CopyTag.ContentDescription = new Tags.Objects.ContentDescriptionOb(T.ContentDescription.Title,
                        T.ContentDescription.Author, T.ContentDescription.Copyright, T.ContentDescription.Description);
                else
                    SetProperty(T.ContentDescription, CopyTag.ContentDescription, "Author", "Copyright", "Description", "Title");
            }

            if (T.ExContentDescription != null)
            {
                if (CopyTag.ExContentDescription == null || CopyType == TemplateCopyTypes.CleanCopy)
                    CopyTag.ExContentDescription = new Tags.Objects.ExContentDescriptionOb();

                foreach (Descriptor D in T.ExContentDescription)
                {
                    if (CopyType != TemplateCopyTypes.SafeCopy)
                        CopyTag.ExContentDescription.Add(new Descriptor(D.Name, D.Value));
                    else
                        if (CopyTag.ExContentDescription.GetValue(D.Name) == null)
                            CopyTag.ExContentDescription.SetValue(D.Name, D.Value);
                }
            }
        }
    }
}
