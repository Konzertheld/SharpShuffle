using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ID3;

namespace TagEditor
{
    public partial class iPictures : TagEditor.iFormBase
    {
        public iPictures(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iPictures(ID3Info[] Tags)
            : base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iPictures(ID3Info TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public iPictures()
        {
            InitializeComponent();
        }

        //public iPictures(ID3Info TagInfo)
        //    : base(TagInfo)
        //{
        //    InitializeComponent();
        //    Title = Text;
        //    ViewData();
        //    HideButtons();
        //}

        protected override void OnViewSingle()
        {
            ictPictures.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override bool OnCollectSingle()
        {
            ictPictures.CollectData();
            return true;
        }
    }
}