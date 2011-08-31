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
    public partial class iLyric : TagEditor.iFormBase
    {
        public iLyric(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iLyric(IList Tags)
            :base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iLyric(ID3Info TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public iLyric()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            ictNLyric.SingleData = SingleTag;
            ictSLyric.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override bool OnCollectSingle()
        {
            ictNLyric.CollectData();
            ictSLyric.CollectData();
            return true;
        }
    }
    }



