namespace WeLink.UI
{
    partial class SetForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetForm));
            this.tabControl = new CCWin.SkinControl.SkinTabControl();
            this.tabGeneral = new CCWin.SkinControl.SkinTabPage();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.button2 = new System.Windows.Forms.Button();
            this.btnClearCookie = new CCWin.SkinControl.SkinButton();
            this.btnOpen = new CCWin.SkinControl.SkinButton();
            this.btnClearChatRecord = new CCWin.SkinControl.SkinButton();
            this.btnChange = new CCWin.SkinControl.SkinButton();
            this.labelName = new System.Windows.Forms.Label();
            this.textFile = new CCWin.SkinControl.SkinTextBox();
            this.tabAbout = new CCWin.SkinControl.SkinTabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOpenHelpDoc = new CCWin.SkinControl.SkinButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.tabControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabControl.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.tabControl.Controls.Add(this.tabGeneral);
            this.tabControl.Controls.Add(this.tabAbout);
            this.tabControl.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl.HeadBack = null;
            this.tabControl.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.tabControl.ItemSize = new System.Drawing.Size(50, 150);
            this.tabControl.Location = new System.Drawing.Point(7, 6);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("tabControl.PageArrowDown")));
            this.tabControl.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("tabControl.PageArrowHover")));
            this.tabControl.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("tabControl.PageCloseHover")));
            this.tabControl.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("tabControl.PageCloseNormal")));
            this.tabControl.PageDown = ((System.Drawing.Image)(resources.GetObject("tabControl.PageDown")));
            this.tabControl.PageDownTxtColor = System.Drawing.Color.White;
            this.tabControl.PageHover = ((System.Drawing.Image)(resources.GetObject("tabControl.PageHover")));
            this.tabControl.PageHoverTxtColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabControl.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.tabControl.PageNorml = null;
            this.tabControl.PageNormlTxtColor = System.Drawing.Color.Silver;
            this.tabControl.SelectedIndex = 1;
            this.tabControl.Size = new System.Drawing.Size(680, 362);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabGeneral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabGeneral.Controls.Add(this.skinButton1);
            this.tabGeneral.Controls.Add(this.button2);
            this.tabGeneral.Controls.Add(this.btnClearCookie);
            this.tabGeneral.Controls.Add(this.btnOpen);
            this.tabGeneral.Controls.Add(this.btnClearChatRecord);
            this.tabGeneral.Controls.Add(this.btnChange);
            this.tabGeneral.Controls.Add(this.labelName);
            this.tabGeneral.Controls.Add(this.textFile);
            this.tabGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGeneral.ForeColor = System.Drawing.Color.DimGray;
            this.tabGeneral.Location = new System.Drawing.Point(150, 0);
            this.tabGeneral.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(530, 362);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.TabItemImage = null;
            this.tabGeneral.Text = "通用设置";
            this.tabGeneral.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveForm);
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.ForeColor = System.Drawing.Color.Black;
            this.skinButton1.Location = new System.Drawing.Point(67, 294);
            this.skinButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Size = new System.Drawing.Size(365, 38);
            this.skinButton1.TabIndex = 48;
            this.skinButton1.Text = "清除所有缓存并退出";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::WeLink.Properties.Resources.sysbtn_close_normal;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(440, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 34);
            this.button2.TabIndex = 47;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClearCookie
            // 
            this.btnClearCookie.BackColor = System.Drawing.Color.Transparent;
            this.btnClearCookie.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClearCookie.DownBack = null;
            this.btnClearCookie.ForeColor = System.Drawing.Color.Black;
            this.btnClearCookie.Location = new System.Drawing.Point(67, 238);
            this.btnClearCookie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearCookie.MouseBack = null;
            this.btnClearCookie.Name = "btnClearCookie";
            this.btnClearCookie.NormlBack = null;
            this.btnClearCookie.Size = new System.Drawing.Size(365, 38);
            this.btnClearCookie.TabIndex = 43;
            this.btnClearCookie.Text = "清除账号缓存并注销";
            this.btnClearCookie.UseVisualStyleBackColor = false;
            this.btnClearCookie.Click += new System.EventHandler(this.btnClearCookie_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Transparent;
            this.btnOpen.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOpen.DownBack = null;
            this.btnOpen.ForeColor = System.Drawing.Color.Black;
            this.btnOpen.Location = new System.Drawing.Point(331, 100);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpen.MouseBack = null;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.NormlBack = null;
            this.btnOpen.Size = new System.Drawing.Size(115, 38);
            this.btnOpen.TabIndex = 39;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClearChatRecord
            // 
            this.btnClearChatRecord.BackColor = System.Drawing.Color.Transparent;
            this.btnClearChatRecord.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClearChatRecord.DownBack = null;
            this.btnClearChatRecord.ForeColor = System.Drawing.Color.Black;
            this.btnClearChatRecord.Location = new System.Drawing.Point(67, 181);
            this.btnClearChatRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClearChatRecord.MouseBack = null;
            this.btnClearChatRecord.Name = "btnClearChatRecord";
            this.btnClearChatRecord.NormlBack = null;
            this.btnClearChatRecord.Size = new System.Drawing.Size(365, 38);
            this.btnClearChatRecord.TabIndex = 39;
            this.btnClearChatRecord.Text = "清除聊天记录";
            this.btnClearChatRecord.UseVisualStyleBackColor = false;
            this.btnClearChatRecord.Click += new System.EventHandler(this.btnClearChatRecord_Click);
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.Transparent;
            this.btnChange.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnChange.DownBack = null;
            this.btnChange.ForeColor = System.Drawing.Color.Black;
            this.btnChange.Location = new System.Drawing.Point(168, 100);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChange.MouseBack = null;
            this.btnChange.Name = "btnChange";
            this.btnChange.NormlBack = null;
            this.btnChange.Size = new System.Drawing.Size(115, 38);
            this.btnChange.TabIndex = 39;
            this.btnChange.Text = "更改";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(17, 66);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(135, 20);
            this.labelName.TabIndex = 38;
            this.labelName.Text = "文件保存位置";
            // 
            // textFile
            // 
            this.textFile.BackColor = System.Drawing.Color.Transparent;
            this.textFile.DownBack = null;
            this.textFile.Icon = null;
            this.textFile.IconIsButton = false;
            this.textFile.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textFile.IsPasswordChat = '\0';
            this.textFile.IsSystemPasswordChar = false;
            this.textFile.Lines = new string[0];
            this.textFile.Location = new System.Drawing.Point(168, 51);
            this.textFile.Margin = new System.Windows.Forms.Padding(0);
            this.textFile.MaxLength = 32767;
            this.textFile.MinimumSize = new System.Drawing.Size(37, 35);
            this.textFile.MouseBack = null;
            this.textFile.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textFile.Multiline = true;
            this.textFile.Name = "textFile";
            this.textFile.NormlBack = null;
            this.textFile.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.textFile.ReadOnly = true;
            this.textFile.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textFile.Size = new System.Drawing.Size(277, 35);
            // 
            // 
            // 
            this.textFile.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textFile.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textFile.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textFile.SkinTxt.Location = new System.Drawing.Point(7, 6);
            this.textFile.SkinTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textFile.SkinTxt.Multiline = true;
            this.textFile.SkinTxt.Name = "BaseText";
            this.textFile.SkinTxt.ReadOnly = true;
            this.textFile.SkinTxt.Size = new System.Drawing.Size(263, 23);
            this.textFile.SkinTxt.TabIndex = 0;
            this.textFile.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textFile.SkinTxt.WaterText = "";
            this.textFile.TabIndex = 0;
            this.textFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textFile.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textFile.WaterText = "";
            this.textFile.WordWrap = true;
            // 
            // tabAbout
            // 
            this.tabAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabAbout.Controls.Add(this.button1);
            this.tabAbout.Controls.Add(this.btnOpenHelpDoc);
            this.tabAbout.Controls.Add(this.label4);
            this.tabAbout.Controls.Add(this.label3);
            this.tabAbout.Controls.Add(this.label2);
            this.tabAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAbout.Location = new System.Drawing.Point(150, 0);
            this.tabAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(530, 362);
            this.tabAbout.TabIndex = 1;
            this.tabAbout.TabItemImage = null;
            this.tabAbout.Text = "关于WeLink";
            this.tabAbout.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveForm);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::WeLink.Properties.Resources.sysbtn_close_normal;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(440, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 34);
            this.button1.TabIndex = 46;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpenHelpDoc
            // 
            this.btnOpenHelpDoc.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenHelpDoc.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOpenHelpDoc.DownBack = null;
            this.btnOpenHelpDoc.ForeColor = System.Drawing.Color.Black;
            this.btnOpenHelpDoc.Location = new System.Drawing.Point(199, 208);
            this.btnOpenHelpDoc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenHelpDoc.MouseBack = null;
            this.btnOpenHelpDoc.Name = "btnOpenHelpDoc";
            this.btnOpenHelpDoc.NormlBack = null;
            this.btnOpenHelpDoc.Size = new System.Drawing.Size(183, 38);
            this.btnOpenHelpDoc.TabIndex = 43;
            this.btnOpenHelpDoc.Text = "查看帮助";
            this.btnOpenHelpDoc.UseVisualStyleBackColor = false;
            this.btnOpenHelpDoc.Click += new System.EventHandler(this.btnOpenHelpDoc_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(40, 221);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 24);
            this.label4.TabIndex = 41;
            this.label4.Text = "使用说明：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(40, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 24);
            this.label3.TabIndex = 41;
            this.label3.Text = "版本信息：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(193, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 24);
            this.label2.TabIndex = 40;
            this.label2.Text = "WeLink 1.1.0";
            // 
            // SetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeLink.Properties.Resources.纯色紫背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(693, 375);
            this.CloseBoxSize = new System.Drawing.Size(0, 0);
            this.CloseDownBack = null;
            this.CloseMouseBack = null;
            this.CloseNormlBack = null;
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetForm";
            this.Radius = 10;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.SetForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTabControl tabControl;
        private CCWin.SkinControl.SkinTabPage tabGeneral;
        private CCWin.SkinControl.SkinTabPage tabAbout;
        private CCWin.SkinControl.SkinTextBox textFile;
        private System.Windows.Forms.Label labelName;
        private CCWin.SkinControl.SkinButton btnClearCookie;
        private CCWin.SkinControl.SkinButton btnOpen;
        private CCWin.SkinControl.SkinButton btnClearChatRecord;
        private CCWin.SkinControl.SkinButton btnChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinButton btnOpenHelpDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private CCWin.SkinControl.SkinButton skinButton1;
    }
}