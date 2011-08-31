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
    public partial class iFiles : TagEditor.iFormBase
    {
        public iFiles(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iFiles(IList Tags)
            :base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iFiles(ID3Info TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public iFiles()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            ictFiles.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override void OnViewMultiple()
        {
            ictFiles.MultipleData = MultipleTag;

            base.OnViewMultiple();
        }

        protected override void OnCollectMultiple()
        {
            ictFiles.CollectData();
        }

        protected override bool OnCollectSingle()
        {
            ictFiles.CollectData();
            return true;
        }
    }
}

