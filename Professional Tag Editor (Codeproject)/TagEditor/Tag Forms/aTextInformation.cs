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
    public partial class aTextInformation : TagEditor.aFormBase
    {
          public aTextInformation(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public aTextInformation(IList Tags)
            :base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public aTextInformation(ASFTagInfo TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public aTextInformation()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            actTextInformations.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override void OnViewMultiple()
        {
            actTextInformations.MultipleData = MultipleTag;

            base.OnViewMultiple();
        }

        protected override void OnCollectMultiple()
        {
            actTextInformations.CollectData();
        }

        protected override bool OnCollectSingle()
        {
            actTextInformations.CollectData();
            return true;
        }
    }
}

