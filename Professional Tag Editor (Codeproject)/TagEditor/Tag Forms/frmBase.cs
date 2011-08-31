using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ID3;
using Tags;
using Tags.ASF;
using System.Collections;

namespace TagEditor
{
    /// <summary>
    /// Base form to use Tag Editing forms
    /// </summary>
    public partial class frmBase<TagType> : Form
    {
        private int _Index; // contain index of current file in list
        private IList _TagList; // Contains list of tags
        private TagType _tag;

        /// <summary>
        /// Create new frmBase
        /// </summary>
        /// <param name="Index">Index of </param>
        /// <param name="ListLength"></param>
        /// <param name="Tags"></param>
        public frmBase(int Index)
        {
            InitializeComponent();
            _Index = Index;
            _Title = Text;
        }

        /// <summary>
        /// Create new frmBase with multi for for edit
        /// </summary>
        /// <param name="TagsInfo">TagsInfo to edit</param>
        public frmBase(IList TagsInfo)
        {
            InitializeComponent();
            if (TagsInfo.Count < 2)
                throw new ArgumentException("This constructor is for multi file editing");

            this._TagList = TagsInfo;
        }

        public frmBase(TagType tag)
        {
            InitializeComponent();
            _tag = tag;
        }

        /// <summary>
        /// Create new frmBase for form designer
        /// </summary>
        protected frmBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get Tags Info that must edit
        /// </summary>
        public TagType[] MultipleTag
        {
            get
            {
                List<TagType> L = new List<TagType>();
                foreach (ListViewItem I in _TagList)
                    L.Add((TagType)I.Tag);
                return L.ToArray();
            }
        }

        /// <summary>
        /// Get Tag Info that must edit
        /// </summary>
        public TagType SingleTag
        {
            get
            {
                if (_tag != null)
                    return _tag;
                else
                    return (TagType)((Program.MainForm.Items[_Index]).Tag);
            }
        }

        /// <summary>
        /// Indicate if current form is in Multi file editing mode
        /// </summary>
        public bool IsMultiMode
        {
            get
            { return (_TagList != null && _TagList.Count > 1); }
        }

        string _Title;
        /// <summary>
        /// Get default title of form
        /// </summary>
        public string Title
        {
            get
            { return _Title; }
            protected set
            { _Title = value; }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // when this event raise we sure form is viewing just one file (single file mode)
            if (OnCollectSingle())
            {
                Program.MainForm.UpdateRow(_Index, true);
                _Index++;
                ViewData();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (OnCollectSingle())
            {
                Program.MainForm.UpdateRow(_Index, true);
                _Index--;
                ViewData();
            }
        }

        #region -> Protected Methods <-

        protected virtual bool OnCollectSingle()
        { throw new Exception("This method does not implement"); }

        protected virtual void OnCollectMultiple()
        { throw new Exception("This method does not implement"); }

        protected virtual void OnViewSingle()
        { OnUpdateUserInterface(); }

        protected virtual void OnViewMultiple()
        { OnUpdateUserInterface(); }

        protected virtual void OnUpdateUserInterface()
        {
            if (IsMultiMode)
            {
                Text = Title + " - " + MultipleTag.Length.ToString() + " File(s) selected";
                HideButtons();
            }
            else
            {
                Text = Title + " - " + (SingleTag as ITagInfo).FileName;
                btnNext.Enabled = (_Index != Program.MainForm.Items.Count - 1);
                btnPrevious.Enabled = (_Index != 0);
            }
        }

        #endregion

        protected void HideButtons()
        {
            btnCancel.Location = new Point(btnCancel.Location.X + 70, btnCancel.Location.Y);
            btnOK.Location = new Point(btnOK.Location.X + 70, btnOK.Location.Y);
            btnNext.Visible = false;
            btnPrevious.Visible = false;
        }

        public void ViewData()
        {
            if (IsMultiMode)
                OnViewMultiple();
            else
                OnViewSingle();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsMultiMode)
                OnCollectMultiple();
            else
            {
                if (OnCollectSingle())
                {
                    Program.MainForm.UpdateRow(_Index, true);
                }
                else
                    return;
            }
            DialogResult = DialogResult.OK;
        }
    }

    public class iFormBase : frmBase<ID3Info>
    {
        public iFormBase(int Index)
            : base(Index)
        { }

        public iFormBase(IList Tags)
            : base(Tags)
        { }

        public iFormBase(ID3Info Tags)
            : base(Tags)
        { }

        public iFormBase()
        { }
    }

    public class aFormBase : frmBase<ASFTagInfo>
    {
        public aFormBase(int Index)
            : base(Index)
        { }

        public aFormBase(IList Tags)
            : base(Tags)
        { }

        public aFormBase(ASFTagInfo Tags)
            : base(Tags)
        { }

        public aFormBase()
        { }
    }
}