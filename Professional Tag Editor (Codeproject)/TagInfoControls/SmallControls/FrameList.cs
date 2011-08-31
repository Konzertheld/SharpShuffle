using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tags.ID3;

namespace TagInfoControls.SmallControls
{
    /// <summary>
    /// Provide a control to add/edit/remove list of array of frame class
    /// </summary>
    [DefaultEvent("SelectedIndexChanged"), ToolboxBitmap(typeof(ListBox))]
    public partial class FrameList : UserControl
    {
        /// <summary>
        /// Occure when add button clicked
        /// </summary>
        [Browsable(true), Description("Occur when add button clicked")]
        public event EventHandler AddClicked;

        /// <summary>
        /// Occur when selected index of List changed
        /// </summary>
        [Browsable(true), Description("Occur when selected index of List changed")]
        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// Occur when save button clicked
        /// </summary>
        [Browsable(true), Description("Occur when save button clicked")]
        public event EventHandler SaveClicked;

        /// <summary>
        /// Occur when list clear
        /// </summary>
        [Browsable(true), Description("Occur when list clear")]
        public event EventHandler ListCleared;

        /// <summary>
        /// Occur when remove button click on an item
        /// </summary>
        [Browsable(true), Description("Occur when remove button click on an item")]
        public event CancelEventHandler RemovingItem;

        private bool _PromptOnClearAll;
        /// <summary>
        /// Show a MessageBox when wants to clear the list
        /// </summary>
        [DefaultValue(false), Description("Indicate if need to show a message when clear button pressed")]
        public bool PromptOnClearAll
        {
            get { return _PromptOnClearAll; }
            set { _PromptOnClearAll = value; }
        }

        private bool _PromtOnRemove;
        /// <summary>
        /// Indicate if need to show a message before removing an item
        /// </summary>
        [DefaultValue(false), Description("Indicate if need to show a message before removing an item")]
        public bool PromtOnRemove
        {
            get { return _PromtOnRemove; }
            set { _PromtOnRemove = value; }
        }


        /// <summary>
        /// Create new FrameList control
        /// </summary>
        public FrameList()
        {
            InitializeComponent();

            btnRemove.Enabled = false;
        }

        /// <summary>
        /// Gets Listbox of current control
        /// </summary>
        public ListBox List
        {
            get
            { return lsbFrames; }
        }

        private bool _UpdateView = false;
        /// <summary>
        /// Update view of current list
        /// </summary>
        public void UpdateView()
        {
            _UpdateView = true;
            lsbFrames.DisplayMember = "A";
            lsbFrames.DisplayMember = "";
            _UpdateView = false;
        }

        /// <summary>
        /// Indicate is Save button visible or not
        /// </summary>
        [Browsable(true), Category("Behavior"), DefaultValue(false),
            Description("Indicate is Save button visible or not")]
        public bool ShowSaveButton
        {
            get
            { return btnSave.Visible; }
            set
            { btnSave.Visible = value; }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (PromtOnRemove)
                if (MessageBox.Show("After removing an item it will not retrieve. Are you sure you want to remove '" + lsbFrames.SelectedItem.ToString() + "' ?",
                    "Removing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

            if (RemovingItem != null)
            {
                CancelEventArgs caa = new CancelEventArgs(false);
                RemovingItem(this, caa);
                if (caa.Cancel)
                    return;
            }

            if (lsbFrames.SelectedIndex != -1)
                lsbFrames.Items.RemoveAt(lsbFrames.SelectedIndex);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void lsbFrames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_UpdateView)
            {
                btnRemove.Enabled = (lsbFrames.SelectedIndex != -1);
                btnSave.Enabled = btnRemove.Enabled;
                if (SelectedIndexChanged != null)
                    SelectedIndexChanged(sender, null);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddClicked != null)
                AddClicked(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveClicked != null)
                SaveClicked(this, e);
        }

        /// <summary>
        /// Clear the current list
        /// </summary>
        public void Clear()
        {
            if (PromptOnClearAll)
                if (MessageBox.Show("Are you sure you want to clear the list. The informations will not retrive ?",
                    "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;
            lsbFrames.Items.Clear();
            lsbFrames_SelectedIndexChanged(null, null);
            if (ListCleared != null)
                ListCleared(this, new EventArgs());
        }
    }
}
