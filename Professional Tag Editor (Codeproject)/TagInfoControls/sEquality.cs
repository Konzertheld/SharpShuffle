using System;
using System.Collections.Generic;
using System.Text;
using Tags.ID3;
using Tags.ID3.ID3v2Frames.TextFrames;
using Tags;
using System.Reflection;
using Tags.ASF;

namespace TagInfoControls
{
    /// <summary>
    /// This class use for comparing TagInfos of an array
    /// </summary>
    public static class sEquality
    {
        /// <summary>
        /// Indicate if specific ID3Info contains specific TextFrame
        /// </summary>
        /// <param name="Data">Array to check values</param>
        /// <param name="FrameID">FrameID to search in array</param>
        public static bool TextFrame(ID3Info[] Data, string FrameID)
        {
            string Text = Data[0].ID3v2Info.GetTextFrame(FrameID);
            for (int i = 1; i < Data.Length; i++)
                if (!Data[i].ID3v2Info.GetTextFrame(FrameID).Equals(Text))
                    return false;

            return true;
        }

        /// <summary>
        /// Indicate if specific ID3Info contains specific UserTextFrame
        /// </summary>
        /// <param name="Data">Array To Check</param>
        /// <param name="FrameID">FrameID to search in array</param>
        public static bool UserTextFrame(ID3Info[] Data, string FrameID)
        {
            string Text;
            string Description;
            if (!FindUTF(Data[0], FrameID, out Text, out Description))
                return false;

            string TText, TDescription;
            for (int i = 1; i < Data.Length; i++)
            {
                if (FindUTF(Data[i], FrameID, out TText, out TDescription))
                    if (TText != Text || TDescription != Description)
                        return false;
            }

            return true;
        }

        /// <summary>
        /// Find specific UserTextFrame in ID3Info
        /// </summary>
        /// <param name="Source">ID3Info to search for UserTextFrame</param>
        /// <param name="FrameID">FrameID of UserTextFrame to search</param>
        /// <param name="Text">Out value for text of found UserTextFrame</param>
        /// <param name="Description">Out value for description of found UserTextFrame</param>
        private static bool FindUTF(ID3Info Source, string FrameID, out string Text, out string Description)
        {
            foreach (UserTextFrame T in Source.ID3v2Info.UserTextFrames)
                if (T.FrameID == FrameID)
                {
                    Text = T.Text;
                    Description = T.Description;
                    return true;
                }

            Text = "";
            Description = "";
            return false;
        }

        // 1: have
        // 0: not have
        // 2: middle
        /// <summary>
        /// Indicate if all specific items of array contains ID3v1
        /// </summary>
        /// <param name="Data">Array of ID3Info to check for ID3v1</param>
        /// <returns>0 if non of them contains ID3v1, 1 if all of them contains otherwise 2</returns>
        public static int HaveV1(ID3Info[] Data)
        {
            bool Have = Data[0].ID3v1Info.HaveTag;
            for (int i = 1; i < Data.Length; i++)
                if (Have != Data[i].ID3v1Info.HaveTag)
                    return 2;

            if (Have)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Indicate if all specific items of array contains ID3v1
        /// </summary>
        /// <param name="Data">Array of ID3Info to check for ID3v2</param>
        /// <returns>0 if non of them contains ID3v2, 1 if all of them contains otherwise 2</returns>
        public static int HaveV2(ID3Info[] Data)
        {
            bool Have = Data[0].ID3v2Info.HaveTag;
            for (int i = 1; i < Data.Length; i++)
                if (Have != Data[i].ID3v2Info.HaveTag)
                    return 2;

            if (Have)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Indicate if all values of specific property of array items be equal together
        /// </summary>
        /// <param name="Arr">Array to control</param>
        /// <param name="PropertyNames">Name of properties</param>
        /// <returns>true if all values equal together otherwise false</returns>
        public static bool IsPropertyEqual(ITagInfo[] Arr, params string[] PropertyNames)
        {
            if (Arr == null || Arr.Length < 2)
                throw new ArgumentException("Arr most contain at least two items");

            object Value = GetValueOfProperty(Arr[0], PropertyNames);
            object Temp;
            for (int i = 1; i < Arr.Length; i++)
            {
                Temp = GetValueOfProperty(Arr[i], PropertyNames);
                if (Value == null && Temp == Value)
                    continue;
                else if (Value == null || Temp == null)
                    return false;
                else if (!Temp.Equals(Value))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Get value of specific property from specific object
        /// </summary>
        /// <param name="ob">Object to get property value</param>
        /// <param name="PropertyNames">Name of properties</param>
        private static object GetValueOfProperty(object ob, params string[] PropertyNames)
        {
            for (int i = 0; i < PropertyNames.Length; i++)
            {
                if (ob != null)
                    ob = ob.GetType().GetProperty(PropertyNames[i]).GetValue(ob, null);
                else
                    break;
            }
            return ob;
        }

        /// <summary>
        /// Get specific property from specific Item of ExContentDescription
        /// </summary>
        /// <param name="Tag">Tag to get value</param>
        /// <param name="index">Name of properties</param>
        private static object GetItemOfExContent(ASFTagInfo Tag, params string[] index)
        {
            return Tag.GetType().GetProperty("ExContentDescription").GetValue(Tag, null).GetType().GetProperty("Item").GetValue(Tag.ExContentDescription, index);
        }

        /// <summary>
        /// Indicate if all values of specific property in ASFTagInfo is one
        /// </summary>
        /// <param name="Arr">Array to check values</param>
        /// <param name="Value">Default Value</param>
        /// <param name="index">Name of properties</param>
        public static bool IsItemEqual(ASFTagInfo[] Arr, out object Value, params string[] index)
        {
            Value = GetItemOfExContent(Arr[0], index);
            for (int i = 1; i < Arr.Length; i++)
            {
                object ob = GetItemOfExContent(Arr[i], index);
                if (Value == null && Value == ob)
                    continue;
                else if (Value == null || ob == null)
                    return false;
                else if (!Value.Equals(ob))
                    return false;
            }

            return true;
        }
    }
}
