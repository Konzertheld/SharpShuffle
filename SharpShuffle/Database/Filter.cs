using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpShuffle
{
    /// <summary>
    /// Filter class to create filter lists for filtering with AND.
    /// </summary>
    public class Filter
    {
        public const string MP_EQUAL = "=";
        public const string MP_LOWER = "<";
        public const string MP_HIGHER = ">";

        public Filter(string key, string comparetype, string value, bool not_flag)
        {
            //TODO: Nicht irgendeinen Mist abfragen lassen
            Key = key;
            Comparetype = comparetype;
            Value = value;
            Not_Flag = not_flag;
        }

        public string Key { get; private set; }
        public string Comparetype { get; private set; }
        public string Value { get; private set; }
        public bool Not_Flag { get; private set; }
    }
}
