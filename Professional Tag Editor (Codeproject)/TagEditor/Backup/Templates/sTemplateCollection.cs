using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using TagEditor.Properties;

namespace TagEditor.Templates
{
    public static class sTemplateCollection
    {
        private static ArrayList _List;

        public static void Add(Template Template)
        {
            if (List.Contains(Template))
                List.Remove(Template);

            List.Add(Template);
        }

        public static void Remove(Template Template)
        {
            List.Remove(Template);
        }

        public static Template[] TemplateArray
        {
            get
            { return (Template[])List.ToArray(typeof(Template)); }
        }

        private static ArrayList List
        {
            get
            {
                if (_List == null)
                    Load();

                return _List;
            }
        }

        public static void Load()
        {
            FileStream FS = null;
            try
            {
                XmlSerializer S = new XmlSerializer(typeof(Template[]));
                string path = Path.Combine(Application.UserAppDataPath, Resources.TemplateList);
                _List = new ArrayList();
                if (File.Exists(path))
                {

                    FS = new FileStream(path, FileMode.Open);
                    _List.AddRange(S.Deserialize(FS) as Template[]);
                    FS.Close();

                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("There's an error while want to load Templates list.\n" + Ex.Message,
                    "Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (FS != null && FS.CanRead)
                    FS.Close();
            }
        }

        public static void Save()
        {
            FileStream FS = null;
            try
            {
                XmlSerializer S = new XmlSerializer(typeof(Template[]));
                string path = Path.Combine(Application.UserAppDataPath, Resources.TemplateList);
                if (_List != null)
                {
                    FS = new FileStream(path, FileMode.Create);
                    S.Serialize(FS, (Template[])_List.ToArray(typeof(Template)));
                    FS.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("There's an error while want to save template file list.\n" + Ex.Message,
                    "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (FS != null && FS.CanRead)
                    FS.Close();
            }
        }

        public static void Clear()
        {
            _List.Clear();
        }

        public static bool IsInList(string Name)
        {
            Name = Name.ToLower();
            foreach (Template t in List)
                if (t.Name.ToLower() == Name)
                    return true;
            return false;
        }
    }
}
