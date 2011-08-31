using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ASF;
using Tags.Objects;
using System.Collections;

namespace TagEditor
{
    public partial class aIdentifier : aFormBase
    {
        public aIdentifier(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public aIdentifier(IList Tags)
            : base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public aIdentifier(ASFTagInfo TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public aIdentifier()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            if (SingleTag.ExContentDescription == null)
                return;
            else
            {
                object Temp = SingleTag.ExContentDescription["WM/UniqueFileIdentifier"];
                if (Temp != null)
                    txtIdentifier.Text = (string)Temp;

                Temp = SingleTag.ExContentDescription["WM/MCDI"];
                if (Temp != null)
                    txtMCDI.Data = (byte[])Temp;
            }

            base.OnViewSingle();
        }

        protected override bool OnCollectSingle()
        {
            if (SingleTag.ExContentDescription == null)
                SingleTag.ExContentDescription = new Tags.Objects.ExContentDescriptionOb();

            SingleTag.ExContentDescription["WM/UniqueFileIdentifier"] = txtIdentifier.Text;
            SingleTag.ExContentDescription["WM/MCDI"] = txtMCDI.Data;
            return true;
        }
    }
}