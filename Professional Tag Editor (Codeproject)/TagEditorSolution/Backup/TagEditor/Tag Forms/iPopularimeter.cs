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
    public partial class iPopularimeter : iFormBase
    {
     public iPopularimeter(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iPopularimeter(IList Tags)
            :base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iPopularimeter(ID3Info TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public iPopularimeter()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            ictPopularimeter.SingleData = SingleTag;
            base.OnViewSingle();
        }

        protected override bool OnCollectSingle()
        {
            ictPopularimeter.CollectData();
            return true;
        }
    }
}

