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
    public partial class iSelling : TagEditor.iFormBase
    {
        public iSelling(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iSelling(IList Tags)
            : base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iSelling(ID3Info TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public iSelling()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            ictCommercial.SingleData = SingleTag;
            ictOwnership.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override bool OnCollectSingle()
        {
            if (!ictCommercial.Validate() || !ictOwnership.Validate())
                return false;

            ictCommercial.CollectData();
            ictOwnership.CollectData();
            return true;
        }
    }
}

