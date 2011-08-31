using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
using System.IO;
using Tags.ID3.ID3v2Frames.BinaryFrames;
using TagInfoControls.SmallControls;

namespace TagInfoControls
{
    /// <summary>
    /// Provide static methods for current Application
    /// </summary>
    public static class StaticMethods
    {
        /// <summary>
        /// Set Text of specific TextBox
        /// </summary>
        /// <param name="Indicator">if true means for multiple view all values are one value</param>
        /// <param name="Ctrl">Control to set text or change background</param>
        /// <param name="Value">Text to set for control</param>
        /// <param name="ConflictColor">Backcolor of controls when multiple values are diffrent</param>
        public static void SetTextBox(bool Indicator, Control Ctrl, string Value, Color ConflictColor)
        {
            if (Indicator)
                Ctrl.Text = Value;
            else
                Ctrl.BackColor = ConflictColor;
        }

        /// <summary>
        /// Get Extension of MIMEType
        /// </summary>
        /// <param name="MIMEType">MimeType to find extension</param>
        /// <returns>System.string contain file extension</returns>
        public static string GetExtension(string MIMEType)
        {
            RegistryKey RK = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + MIMEType);
            if (RK == null)
                return "Unknown MIME Type|*.*";
            else
            {
                object Ex = RK.GetValue("Extension");
                if (Ex != null)
                    return Ex + " File|*" + Ex.ToString();
                else
                    return "Unknown MIME Type|*.*";
            }
        }

        /// <summary>
        /// Get MimeType of specific Extension
        /// </summary>
        /// <param name="Extension"></param>
        /// <returns></returns> 
        public static string GetMIMEType(string Extension)
        {
            RegistryKey RK = Registry.ClassesRoot.OpenSubKey(Extension);
            if (RK == null)
                return "";
            else
            {
                object st = RK.GetValue("Content Type");
                if (st != null)
                    return st.ToString();
                else
                    return "";
            }
        }

        /// <summary>
        /// Gets MemoryStream from specific file path
        /// </summary>
        /// <param name="FilePath">File path to read from</param>
        /// <returns>MemoryStream readed from file</returns>
        public static MemoryStream GetMemoryStream(string FilePath)
        {
            FileStream FS = new FileStream(FilePath, FileMode.Open);
            MemoryStream MS = new MemoryStream();
            byte[] Buf;
            Buf = new byte[FS.Length];
            FS.Read(Buf, 0, Buf.Length);
            MS.Write(Buf, 0, Buf.Length);
            FS.Close();
            return MS;
        }

        /// <summary>
        /// Convert specific long value to Length String contain B, KB or MB
        /// </summary>
        /// <param name="Length">Number to convert</param>
        /// <returns>System.String Contain number plus B, KB or MB</returns>
        public static string GetLengthString(long Length)
        {
            string Ext = "B";
            double L = Length;
            if (L > 1024)
            {
                L /= 1024;
                Ext = "kB";
            }

            if (L > 1024)
            {
                L /= 1024;
                Ext = "MB";
            }

            return L.ToString("N2") + " " + Ext;
        }

        /// <summary>
        /// Indicate if specific list contains specific value
        /// </summary>
        /// <param name="BaseValue">Value to find</param>
        /// <param name="Index">Index of value that we don't want to check</param>
        /// <param name="List">List of frames to search in</param>
        /// <param name="PropertyName">Name of property to compare</param>
        /// <returns>true if list contains otherwise false</returns>
        public static bool ContainValue(string BaseValue, int Index, FrameList List, string PropertyName)
        {
            for (int i = 0; i < List.List.Items.Count; i++)
            {
                if (i == Index)
                    continue;

                if (List.List.Items[i].GetType().GetProperty(PropertyName).GetValue(List.List.Items[i], null).ToString() == BaseValue)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Change specific string if specific List contains specific value
        /// </summary>
        /// <param name="BaseValue">Value to search and change</param>
        /// <param name="Index">Index of item that don't need to check</param>
        /// <param name="List">List to search in</param>
        /// <param name="PropertyName">Name of property to to search</param>
        /// <returns>True if name changed otherwise false</returns>
        public static bool ValidatingProperty(ref string BaseValue, int Index, FrameList List, string PropertyName)
        {
            int Counter = 1;
            bool Changed = false;
            string Value = BaseValue;
            while (ContainValue(BaseValue, Index, List, PropertyName))
            {
                BaseValue = Value + (Counter++).ToString();
                Changed = true;
            }
            return Changed;
        }

        /// <summary>
        /// Check if specific list contains specific Item
        /// </summary>
        /// <param name="ctrl">GetText of control to search for</param>
        /// <param name="Index">Index of item that must not check</param>
        /// <param name="List">List of frames</param>
        /// <param name="PropertyName">Name opf proeprty to check for equality</param>
        /// <returns>true if valid otherwise false</returns>
        public static bool ValidatingControlAsProperty(Control ctrl, int Index, FrameList List, string PropertyName)
        {
            string Value = ctrl.Text;
            if (StaticMethods.ValidatingProperty(ref Value, Index, List, PropertyName))
            {
                bool Ans = (MessageBox.Show("List already contains item with '" + ctrl.Text + "' as " + PropertyName +
                    ". So the " + PropertyName + " you entered changed to '" +
                    Value + "'. Do you want to change it ?", "Repeated value", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
                ctrl.Text = Value;
                if (Ans)
                    return true;
            }
            return false;
        }
    }
}
