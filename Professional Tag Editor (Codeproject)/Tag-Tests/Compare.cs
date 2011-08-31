using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tag_Tests
{
    public enum MP_COMPARETYPE
    {
        equal,
        similar,
        startswith,
        endswith
    }

    /// <summary>
    /// Filter class to create filter lists for filtering with AND.
    /// </summary>
    public class MP_Filter
    {
        public MP_Filter(string key, MP_COMPARETYPE comparetype, string value)
        {
            //TODO: Nicht irgendeinen Mist abfragen lassen
            Key = key;
            Comparetype = comparetype;
            Value = value;
        }

        public string Key { get; private set; }
        public MP_COMPARETYPE Comparetype { get; private set; }
        public string Value { get; private set; }
    }
}