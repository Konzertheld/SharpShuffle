using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TagInfoControls
{
    /// <summary>
    /// Provide a Combobox for initial key value
    /// </summary>
    [ToolboxBitmap(typeof(InitialKeyBox), "InitialKey.bmp")]
    public class InitialKeyBox : ComboBox
    {
        private readonly string[] _Values = {
                "", "A","A (minor)","A flat","A flat (minor)","A sharp",
                "A sharp (minor)","B","B (minor)","B flat","B flat (minor)",
                "B sharp","B sharp (minor)","C","C (minor)","C flat","C flat (minor)",
                "C sharp","C sharp (minor)","D","D (minor)","D flat","D flat (minor)",
                "D sharp","D sharp (minor)","E","E (minor)","E flat","E flat (minor)",
                "E sharp","E sharp (minor)","F","F (minor)","F flat","F flat (minor)",
                "F sharp","F sharp (minor)","G","G (minor)","G flat","G flat (minor)",
                "G sharp","G sharp (minor)","off key"};

        /// <summary>
        /// Create new InitialKeyBox
        /// </summary>
        public InitialKeyBox()
        {
            base.Items.AddRange(_Values);
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Initial Key name accroding to ID3 standard
        /// </summary>
        public string InitialKey
        {
            get
            {
                if (this.SelectedIndex == 43)
                    return "o";
                string T = this.Text.Replace(" sharp", "#");
                T = T.Replace(" flat", "b");
                T = T.Replace(" (minor)", "m");
                return T;
            }
            set
            {
                if (value.ToUpper() == "O")
                {
                    this.SelectedIndex = 43;
                    return;
                }
                value = value.Replace("#", " sharp");
                value = value.Replace("b", " flat");
                value = value.Replace("m", " (minor)");
                this.SelectedItem = value;
            }
        }

        /// <summary>
        /// All keys
        /// </summary>
        public new string[] Items
        {
            get
            { return _Values; }
        }
    }
}
