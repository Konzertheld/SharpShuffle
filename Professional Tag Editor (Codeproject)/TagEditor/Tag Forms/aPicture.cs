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
    public partial class aBranding : TagEditor.aFormBase
    {
        public aBranding(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public aBranding(IList Tags)
            : base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public aBranding(ASFTagInfo TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public aBranding()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            actBranding.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override void OnViewMultiple()
        {
            actBranding.MultipleData = MultipleTag;

            base.OnViewMultiple();
        }

        protected override void OnCollectMultiple()
        {
            actBranding.CollectData();
        }

        protected override bool OnCollectSingle()
        {
            actBranding.CollectData();
            return true;
        }

    }
}

