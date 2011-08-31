using System.Xml.Serialization;
using System.IO;
using System.Collections;
namespace TagInfoControls.SmallControls
{
    partial class LanguageTextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.rdbLTR = new System.Windows.Forms.RadioButton();
            this.rdbRTL = new System.Windows.Forms.RadioButton();
            this.tlpMain = new System.Windows.Forms.ToolTip(this.components);
            this.lnbLanguage = new TagInfoControls.LanguageBox();
            this.SuspendLayout();
            // 
            // txtText
            // 
            this.txtText.AcceptsReturn = true;
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(5, 31);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(369, 173);
            this.txtText.TabIndex = 18;
            this.tlpMain.SetToolTip(this.txtText, "Text of frame");
            this.txtText.Validated += new System.EventHandler(this.txtText_Validated);
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(2, 6);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(58, 13);
            this.lblLanguage.TabIndex = 16;
            this.lblLanguage.Text = "Language:";
            // 
            // rdbLTR
            // 
            this.rdbLTR.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbLTR.AutoSize = true;
            this.rdbLTR.Checked = true;
            this.rdbLTR.Image = global::TagInfoControls.Properties.Resources.RightToLeftDoucmentHS1;
            this.rdbLTR.Location = new System.Drawing.Point(324, 3);
            this.rdbLTR.Name = "rdbLTR";
            this.rdbLTR.Size = new System.Drawing.Size(22, 22);
            this.rdbLTR.TabIndex = 21;
            this.rdbLTR.TabStop = true;
            this.tlpMain.SetToolTip(this.rdbLTR, "Left to right language");
            this.rdbLTR.UseVisualStyleBackColor = true;
            this.rdbLTR.CheckedChanged += new System.EventHandler(this.rdbLTR_CheckedChanged);
            // 
            // rdbRTL
            // 
            this.rdbRTL.Appearance = System.Windows.Forms.Appearance.Button;
            this.rdbRTL.AutoSize = true;
            this.rdbRTL.Image = global::TagInfoControls.Properties.Resources.RightToLeftDoucmentHS;
            this.rdbRTL.Location = new System.Drawing.Point(352, 3);
            this.rdbRTL.Name = "rdbRTL";
            this.rdbRTL.Size = new System.Drawing.Size(22, 22);
            this.rdbRTL.TabIndex = 20;
            this.tlpMain.SetToolTip(this.rdbRTL, "Right to left language");
            this.rdbRTL.UseVisualStyleBackColor = true;
            // 
            // lnbLanguage
            // 
            this.lnbLanguage.FormattingEnabled = true;
            this.lnbLanguage.Location = new System.Drawing.Point(66, 3);
            this.lnbLanguage.Name = "lnbLanguage";
            this.lnbLanguage.SelectedLanguage = "";
            this.lnbLanguage.Size = new System.Drawing.Size(202, 21);
            this.lnbLanguage.TabIndex = 19;
            this.tlpMain.SetToolTip(this.lnbLanguage, "Language for text");
            this.lnbLanguage.Validating += new System.ComponentModel.CancelEventHandler(this.lnbLanguage_Validating);
            this.lnbLanguage.SelectedIndexChanged += new System.EventHandler(this.lnbLanguage_SelectedIndexChanged);
            this.lnbLanguage.Validated += new System.EventHandler(this.lnbLanguage_Validated);
            // 
            // LanguageTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rdbLTR);
            this.Controls.Add(this.rdbRTL);
            this.Controls.Add(this.lnbLanguage);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblLanguage);
            this.Name = "LanguageTextBox";
            this.Size = new System.Drawing.Size(377, 204);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        /// <summary>
        /// Language Box
        /// </summary>
        protected LanguageBox lnbLanguage;
        /// <summary>
        /// TextBox for holding text data
        /// </summary>
        protected System.Windows.Forms.TextBox txtText;
        /// <summary>
        /// ComboBox for languages
        /// </summary>
        protected System.Windows.Forms.Label lblLanguage;
        /// <summary>
        /// Radio button to choose for RTL languages
        /// </summary>
        protected System.Windows.Forms.RadioButton rdbRTL;
        /// <summary>
        /// Radio button to choose for LTR languages
        /// </summary>
        protected System.Windows.Forms.RadioButton rdbLTR;
        /// <summary>
        /// Tooltip provider
        /// </summary>
        protected System.Windows.Forms.ToolTip tlpMain;

    }
}
