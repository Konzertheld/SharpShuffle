using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThePlayer
{
    public abstract class Dataset
    {
        protected Dictionary<string, string> _allTheInformation;
        public int id;

        public Dictionary<string, string> AllTheInformation()
        {
            return _allTheInformation;
        }

        /// <summary>
        /// Get a stored information field (tag). Returns an empty string if the field is not set.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public string getInformation(string identifier)
        {
            if (_allTheInformation.ContainsKey(identifier)) return _allTheInformation[identifier];
            else return "";
        }

        /// <summary>
        /// Set an information field (tag). Check result for true if you do not know if your identifier is allowed.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool setInformation(string identifier, string value)
        {
            if (_allTheInformation.ContainsKey(identifier))
                _allTheInformation[identifier] = value;
            else
                _allTheInformation.Add(identifier, value);
            return true;
        }
    }
}
