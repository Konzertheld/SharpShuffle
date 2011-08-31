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
    public partial class iIdentifiers : iFormBase
    {
        public iIdentifiers(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iIdentifiers(IList Tags)
            : base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iIdentifiers(ID3Info TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public iIdentifiers()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            ictFileIdentifier.SingleData = SingleTag;
            ictMusicCDIdentifier.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override bool OnCollectSingle()
        {
            ictFileIdentifier.CollectData();
            ictMusicCDIdentifier.CollectData();
            return true;
        }
    }
}

