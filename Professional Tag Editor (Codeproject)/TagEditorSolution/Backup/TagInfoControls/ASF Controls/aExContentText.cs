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
    /// Provide a Control to show and edit Items of Extended content description of ASFTagInfo file
    /// </summary>
    [ToolboxItem(true)]
    public partial class aExContentTexts : ASFUserControl
    {
        /// <summary>
        /// Create new aExContentTexts
        /// </summary>
        public aExContentTexts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clear all fields
        /// </summary>
        protected override void OnClear()
        {
            foreach (TabPage tp in tbcPages.TabPages)
            {
                foreach (Control ctrl in tp.Controls)
                {
                    if (ctrl.Tag != null)
                    {
                        ctrl.Text = "";
                        ctrl.BackColor = SystemColors.Window;
                    }
                }
            }

            cmbInitialKey.SelectedItem = "";
            cmbLanguage.SelectedLanguage = "";
        }

        /// <summary>
        /// Show data of single tag
        /// </summary>
        protected override void OnSingleSet(Tags.ASF.ASFTagInfo Data)
        {
            foreach (TabPage tp in tbcPages.TabPages)
            {
                foreach (Control ctrl in tp.Controls)
                {
                    if (ctrl.Tag == null)
                        continue;

                    object Value = Data.ExContentDescription[ctrl.Tag.ToString()];
                    if (Value != null)
                    {
                        if (ctrl.Name.StartsWith("txt"))
                            ctrl.Text = Value.ToString();
                        else if (ctrl.GetType() == typeof(LanguageBox))
                            (ctrl as LanguageBox).SelectedLanguage = Value.ToString();
                        else if (ctrl.GetType() == typeof(InitialKeyBox))
                            (ctrl as InitialKeyBox).SelectedItem = Value.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Collect data as single Tag
        /// </summary>
        protected override void OnCollectSingle()
        {
            foreach (TabPage tp in tbcPages.TabPages)
            {
                foreach (Control ctrl in tp.Controls)
                {
                    if (ctrl.Tag == null)
                        continue;

                    if (ctrl.Name.StartsWith("txt"))
                        SData.ExContentDescription[ctrl.Tag.ToString()] = ctrl.Text;
                    else if (ctrl.GetType() == typeof(LanguageBox))
                        SData.ExContentDescription[ctrl.Tag.ToString()] = (ctrl as LanguageBox).SelectedLanguage;
                    else if (ctrl.GetType() == typeof(InitialKeyBox))
                        SData.ExContentDescription[ctrl.Tag.ToString()] = (ctrl as InitialKeyBox).SelectedItem;
                }
            }
        }

        /// <summary>
        /// Show data of multiple tags
        /// </summary>
        protected override void OnMultipleSet(Tags.ASF.ASFTagInfo[] Data)
        {
            foreach (TabPage tp in tbcPages.TabPages)
            {
                foreach (Control ctrl in tp.Controls)
                {
                    if (ctrl.Tag == null)
                        continue;

                    object val;
                    if (sEquality.IsItemEqual(Data, out val, ctrl.Tag.ToString()))
                    {
                        if (val != null)
                        {
                            if (ctrl.Name.StartsWith("txt"))
                                ctrl.Text = val.ToString();
                            else if (ctrl.GetType() == typeof(LanguageBox))
                                (ctrl as LanguageBox).SelectedLanguage = val.ToString();
                            else if (ctrl.GetType() == typeof(InitialKeyBox))
                                (ctrl as InitialKeyBox).SelectedItem = val.ToString();
                        }
                    }
                    else
                        ctrl.BackColor = ConflictColor;
                }
            }
        }

        /// <summary>
        /// Collect data as multi tag
        /// </summary>
        protected override void OnCollectMultiple(Tags.ASF.ASFTagInfo Data)
        {
            foreach (TabPage tp in tbcPages.TabPages)
            {
                foreach (Control ctrl in tp.Controls)
                {
                    if (ctrl.Tag == null)
                        continue;

                    if (ctrl.Name.StartsWith("txt") && ctrl.Text != "")
                        Data.ExContentDescription[ctrl.Tag.ToString()] = ctrl.Text;
                    else if (ctrl.GetType() == typeof(LanguageBox) && (ctrl as LanguageBox).SelectedLanguage != "")
                        Data.ExContentDescription[ctrl.Tag.ToString()] = (ctrl as LanguageBox).SelectedLanguage;
                    else if (ctrl.GetType() == typeof(InitialKeyBox) && (ctrl as InitialKeyBox).SelectedItem.ToString() != "")
                        Data.ExContentDescription[ctrl.Tag.ToString()] = (ctrl as InitialKeyBox).SelectedItem;
                }
            }
        }
    }
}