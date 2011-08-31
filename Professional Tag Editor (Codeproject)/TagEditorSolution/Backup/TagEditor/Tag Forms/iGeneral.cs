using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tags.ID3;
using TagInfoControls;
using System.Collections;

namespace TagEditor
{
    public partial class iGeneral : iFormBase
    {
        public iGeneral(int Index)
            : base(Index)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iGeneral(IList Tags)
            : base(Tags)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
        }

        public iGeneral(ID3Info TagInfo)
            : base(TagInfo)
        {
            InitializeComponent();
            Title = Text;
            ViewData();
            HideButtons();
        }

        public iGeneral()
        {
            InitializeComponent();
        }

        protected override void OnViewSingle()
        {
            chbHaveV1.Checked = (SingleTag as ID3Info).ID3v1Info.HaveTag;
            chbHaveV2.Checked = (SingleTag as ID3Info).ID3v2Info.HaveTag;

            ictV1.SingleData = SingleTag as ID3Info;
            ictV2.SingleData = SingleTag as ID3Info;

            base.OnViewSingle();
        }

        protected override void OnViewMultiple()
        {
            int t = TagInfoControls.sEquality.HaveV1(MultipleTag as ID3Info[]);
            if (t == 0)
                chbHaveV1.Checked = false;
            else if (t == 1)
                chbHaveV1.Checked = true;
            else
                chbHaveV1.CheckState = CheckState.Indeterminate;

            t = TagInfoControls.sEquality.HaveV2(MultipleTag as ID3Info[]);
            if (t == 0)
                chbHaveV2.Checked = false;
            else if (t == 1)
                chbHaveV2.Checked = true;
            else
                chbHaveV2.CheckState = CheckState.Indeterminate;

            ictV1.MultipleData = MultipleTag;
            ictV2.MultipleData = MultipleTag;

            base.OnViewMultiple();
        }

        protected override bool OnCollectSingle()
        {
            SingleTag.ID3v1Info.HaveTag = chbHaveV1.Checked;
            if (chbHaveV1.Checked)
                ictV1.CollectData();

            SingleTag.ID3v2Info.HaveTag = chbHaveV2.Checked;
            if (chbHaveV2.Checked)
                ictV2.CollectData();

            return true;
        }

        protected override void OnCollectMultiple()
        {
            if (chbHaveV1.CheckState != CheckState.Indeterminate)
            {
                if (chbHaveV1.Checked)
                {
                    foreach (ID3Info I in MultipleTag)
                        I.ID3v1Info.HaveTag = true;
                    ictV1.CollectData();
                }
                else
                    foreach (ID3Info I in MultipleTag)
                        I.ID3v1Info.HaveTag = false;
            }

            if (chbHaveV2.CheckState != CheckState.Indeterminate)
            {
                if (chbHaveV2.Checked)
                {
                    foreach (ID3Info I in MultipleTag)
                        I.ID3v2Info.HaveTag = true;
                    ictV2.CollectData();
                }
                else
                    foreach (ID3Info I in MultipleTag)
                        I.ID3v2Info.HaveTag = false;
            }
        }

        private void chbHaveV2_CheckedChanged(object sender, EventArgs e)
        {
            btnCopyFrom2.Enabled = ictV2.Enabled = (chbHaveV2.CheckState == CheckState.Checked);
        }

        private void chbHaveV1_CheckedChanged(object sender, EventArgs e)
        {
            btnCopyFrom1.Enabled = ictV1.Enabled = (chbHaveV1.CheckState == CheckState.Checked);
        }

        private void btnCopyFrom1_Click(object sender, EventArgs e)
        {
            if (!chbHaveV2.Checked)
                chbHaveV2.Checked = true;

            Copy(ictV2, ictV1, "TRCK");
            Copy(ictV2, ictV1, "TIT2");
            Copy(ictV2, ictV1, "TPE1");
            Copy(ictV2, ictV1, "TALB");
            Copy(ictV2, ictV1, "TYER");
            Copy(ictV2, ictV1, "TCON");
            Copy(ictV2, ictV1, "TENC");
        }

        private void Copy(SimpleTextInformation C1, SimpleTextInformation C2, string TagName)
        {
            C1.GetControlByTag(TagName).Text = C2.GetControlByTag(TagName).Text;
        }

        private void btnCopyFrom2_Click(object sender, EventArgs e)
        {
            if (!chbHaveV1.Checked)
                chbHaveV1.Checked = true;

            Copy(ictV1, ictV2, "TRCK");
            Copy(ictV1, ictV2, "TIT2");
            Copy(ictV1, ictV2, "TPE1");
            Copy(ictV1, ictV2, "TALB");
            Copy(ictV1, ictV2, "TYER");
            Copy(ictV1, ictV2, "TCON");
            Copy(ictV1, ictV2, "TENC");
        }
    }
}