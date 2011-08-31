using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ASF;
using System.Collections;

namespace TagEditor
{
    public partial class aSimpleText : TagEditor.aFormBase
    {
          public aSimpleText(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public aSimpleText(IList Tags)
            :base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public aSimpleText(ASFTagInfo TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public aSimpleText()
        {
            InitializeComponent();
        }


        protected override void OnViewSingle()
        {
            actSimpleText.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override void OnViewMultiple()
        {
            actSimpleText.MultipleData = MultipleTag;

            base.OnViewMultiple();
        }

        protected override void OnCollectMultiple()
        {
            actSimpleText.CollectData();
        }

        protected override bool OnCollectSingle()
        {
            actSimpleText.CollectData();
            return true;
        }
    }
}

