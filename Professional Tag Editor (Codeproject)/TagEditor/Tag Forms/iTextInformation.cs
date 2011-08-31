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
    public partial class iTextInformation : iFormBase
    {
        public iTextInformation(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData(); 
        }

        public iTextInformation(IList Tags)
            : base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData(); 
        }

        public iTextInformation(ID3Info TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public iTextInformation()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            ictTextInformation.SingleData = SingleTag;

            base.OnViewSingle();
        }

        protected override void OnViewMultiple()
        {
            ictTextInformation.MultipleData = MultipleTag;

            base.OnViewMultiple();
        }

        protected override void OnCollectMultiple()
        {
            ictTextInformation.CollectData();
        }

        protected override bool OnCollectSingle()
        {
            ictTextInformation.CollectData();
            return true;
        }
    }
}

