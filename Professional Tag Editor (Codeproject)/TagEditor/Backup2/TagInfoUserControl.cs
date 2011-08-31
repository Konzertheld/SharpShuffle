
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Tags;
using Tags.ID3;
using Tags.ASF;

namespace TagInfoControls
{
    /// <summary>
    /// Base class for Tag user controls
    /// </summary>
    public abstract class TagInfoUserControl<TagType> : UserControl
    {
        /// <summary>
        /// Tags array for multiple tag editing
        /// </summary>
        protected TagType[] MData;
        /// <summary>
        /// Tag for single tag editing
        /// </summary>
        protected TagType SData;

        /// <summary>
        /// ITagInfos that must show in control
        /// </summary>
        [Browsable(false), DefaultValue(null)]
        public TagType[] MultipleData
        {
            get
            {
                CallMultiple();
                return MData;
            }
            set
            {
                if (EditMode != EditModes.Unknown)
                    Clear();

                MData = value;
                SData = default(TagType);

                if (!DesignMode)
                    OnMultipleSet(value);
            }
        }

        /// <summary>
        /// ITagInfo that must show in control
        /// </summary>
        [Browsable(false), DefaultValue(null)]
        public TagType SingleData
        {
            get
            {
                if (!DesignMode)
                    OnCollectSingle();
                return SData;
            }
            set
            {
                if (EditMode != EditModes.Unknown)
                    Clear();

                SData = value;
                MData = null;

                if (!DesignMode)
                    OnSingleSet(value);
            }
        }

        /// <summary>
        /// View One ITagInfo
        /// </summary>
        protected virtual void OnSingleSet(TagType Data) { }

        /// <summary>
        /// View Multiple ITagInfo
        /// </summary>
        protected virtual void OnMultipleSet(TagType[] Data) { }

        /// <summary>
        /// Gather data of single ITagInfo
        /// </summary>
        protected virtual void OnCollectSingle() { }

        /// <summary>
        /// Gather data of multiple ITagInfo
        /// </summary>
        protected virtual void OnCollectMultiple(TagType Data) { }

        /// <summary>
        /// Clear all fields of control
        /// </summary>
        protected virtual void OnClear() { }

        private void CallMultiple()
        {
            if (DesignMode)
                return;

            foreach (TagType var in MData)
                OnCollectMultiple(var);
        }

        /// <summary>
        /// Indicate is current Editor edit multiple ITagInfo or just one
        /// </summary>
        [Browsable(false)]
        public EditModes EditMode
        {
            get
            {
                if (MData != null)
                    return EditModes.Multiple;

                if (SData != null)
                    return EditModes.Single;

                return EditModes.Unknown;
            }
        }

        System.Drawing.Color _ConflictColor = System.Drawing.Color.AliceBlue;
        /// <summary>
        /// Indicate backcolor of controls when the values is diffrent
        /// </summary>
        [DefaultValue(typeof(System.Drawing.Color), "AliceBlue"), Browsable(true),
        Description("Color to use as backgourd color of controls that have conflict in multiple values"),
        Category("Appearance")]
        public System.Drawing.Color ConflictColor
        {
            get
            { return _ConflictColor; }
            set
            {
                if (value == System.Drawing.Color.Empty)
                    value = System.Drawing.Color.AliceBlue;
                _ConflictColor = value;
            }
        }

        /// <summary>
        /// Clear all fields of control
        /// </summary>
        public void Clear()
        { OnClear(); }

        /// <summary>
        /// Collect data from form and edit selected tag(s)
        /// </summary>
        public void CollectData()
        {
            if (EditMode == EditModes.Multiple)
                CallMultiple();
            else
                OnCollectSingle();
        }

        /// <summary>
        /// Find control that must show specific tag
        /// </summary>
        /// <param name="TagName">Tag to find relative control</param>
        /// <returns>Control that related to tag or null</returns>
        public Control GetControlByTag(string TagName)
        {
            foreach (Control ctrl in this.Controls)
                if (ctrl.Tag != null && ctrl.Tag.ToString() == TagName)
                    return ctrl;

            return null;
        }
    }

    /* When simply used TagInfoUserControl for Controls inheritance 
     Editor raise error and don't let to design control so made to other classes
     and named ID3UserControl and ASFUserControl for UserControls to interit*/


    /// <summary>
    /// Inherited class to use for ID3 user Controls
    /// </summary>
    [ToolboxItem(false)]
    public class ID3UserControl : TagInfoUserControl<ID3Info>
    { }

    /// <summary>
    /// Inherited class to use for ASF user Controls
    /// </summary>
    [ToolboxItem(false)]
    public class ASFUserControl : TagInfoUserControl<ASFTagInfo>
    { }

    /// <summary>
    /// Indicates diffrent modes of tag editing for controls
    /// </summary>
    public enum EditModes
    {
        /// <summary>
        /// Editing single tag
        /// </summary>
        Single,
        /// <summary>
        /// Edit multiple tags together
        /// </summary>
        Multiple,
        /// <summary>
        /// Unknown type of editing
        /// </summary>
        Unknown
    }
}
