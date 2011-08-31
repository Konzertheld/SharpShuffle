using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ID3;
using System.Collections;

namespace TagEditor
{
    public partial class iComments : TagEditor.iFormBase
    {
        public iComments(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iComments(ID3Info TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public iComments(IList Tags)
            : base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iComments()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            ictComments.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override void OnViewMultiple()
        {
            ictComments.MultipleData = MultipleTag;

            base.OnViewMultiple();
        }

        protected override void OnCollectMultiple()
        {
            ictComments.CollectData();
        }

        protected override bool OnCollectSingle()
        {
            ictComments.CollectData();
            return true;
        }
    }
}

