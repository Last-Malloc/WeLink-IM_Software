namespace WeLink.UI
{
    partial class UserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfo));
            this.headImg = new LayeredSkin.Controls.LayeredBaseControl();
            this.labelName = new CCWin.SkinControl.SkinLabel();
            this.labelSex = new CCWin.SkinControl.SkinLabel();
            this.labelCardID = new CCWin.SkinControl.SkinLabel();
            this.labelLife = new System.Windows.Forms.Label();
            this.labelEmail = new CCWin.SkinControl.SkinLabel();
            this.labelFace = new CCWin.SkinControl.SkinLabel();
            this.btnEmail = new CCWin.SkinControl.SkinButton();
            this.btnFace = new CCWin.SkinControl.SkinButton();
            this.labelChangeInfo = new CCWin.SkinControl.SkinLabel();
            this.panelSex = new CCWin.SkinControl.SkinPanel();
            this.radioWoman = new CCWin.SkinControl.SkinRadioButton();
            this.radioMan = new CCWin.SkinControl.SkinRadioButton();
            this.btnChooseHead = new CCWin.SkinControl.SkinButton();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.textName = new CCWin.SkinControl.SkinTextBox();
            this.textLife = new CCWin.SkinControl.SkinTextBox();
            this.BtnClose = new LayeredSkin.Controls.LayeredButton();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSex.SuspendLayout();
            this.SuspendLayout();
            // 
            // headImg
            // 
            this.headImg.BackgroundImage = global::WeLink.Properties.Resources.moren;
            this.headImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.headImg.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.headImg.Borders.BottomWidth = 1;
            this.headImg.Borders.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.headImg.Borders.LeftWidth = 1;
            this.headImg.Borders.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.headImg.Borders.RightWidth = 1;
            this.headImg.Borders.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.headImg.Borders.TopWidth = 1;
            this.headImg.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("headImg.Canvas")));
            this.headImg.Location = new System.Drawing.Point(29, 45);
            this.headImg.Name = "headImg";
            this.headImg.Size = new System.Drawing.Size(60, 60);
            this.headImg.TabIndex = 37;
            this.headImg.Text = "layeredBaseControl3";
            this.headImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove);
            // 
            // labelName
            // 
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.BorderColor = System.Drawing.Color.White;
            this.labelName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelName.Location = new System.Drawing.Point(112, 54);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(233, 23);
            this.labelName.TabIndex = 41;
            this.labelName.Text = "昵称：张   三";
            this.labelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove);
            // 
            // labelSex
            // 
            this.labelSex.BackColor = System.Drawing.Color.Transparent;
            this.labelSex.BorderColor = System.Drawing.Color.White;
            this.labelSex.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSex.Location = new System.Drawing.Point(112, 92);
            this.labelSex.Name = "labelSex";
            this.labelSex.Size = new System.Drawing.Size(219, 23);
            this.labelSex.TabIndex = 41;
            this.labelSex.Text = "性别：男";
            this.labelSex.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove);
            // 
            // labelCardID
            // 
            this.labelCardID.BackColor = System.Drawing.Color.Transparent;
            this.labelCardID.BorderColor = System.Drawing.Color.White;
            this.labelCardID.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelCardID.Location = new System.Drawing.Point(24, 137);
            this.labelCardID.Name = "labelCardID";
            this.labelCardID.Size = new System.Drawing.Size(183, 23);
            this.labelCardID.TabIndex = 41;
            this.labelCardID.Text = "账号：0000000001";
            this.labelCardID.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove);
            // 
            // labelLife
            // 
            this.labelLife.BackColor = System.Drawing.Color.Transparent;
            this.labelLife.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLife.ForeColor = System.Drawing.Color.White;
            this.labelLife.Location = new System.Drawing.Point(25, 243);
            this.labelLife.Name = "labelLife";
            this.labelLife.Size = new System.Drawing.Size(355, 110);
            this.labelLife.TabIndex = 42;
            this.labelLife.Text = "个性签名：xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            this.labelLife.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove);
            // 
            // labelEmail
            // 
            this.labelEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelEmail.BorderColor = System.Drawing.Color.White;
            this.labelEmail.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEmail.Location = new System.Drawing.Point(24, 172);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(280, 23);
            this.labelEmail.TabIndex = 41;
            this.labelEmail.Text = "邮箱：0000000001@qq.com";
            this.labelEmail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove);
            // 
            // labelFace
            // 
            this.labelFace.BackColor = System.Drawing.Color.Transparent;
            this.labelFace.BorderColor = System.Drawing.Color.White;
            this.labelFace.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFace.Location = new System.Drawing.Point(24, 211);
            this.labelFace.Name = "labelFace";
            this.labelFace.Size = new System.Drawing.Size(246, 23);
            this.labelFace.TabIndex = 41;
            this.labelFace.Text = "人脸识别：未通过";
            this.labelFace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMove);
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.Transparent;
            this.btnEmail.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnEmail.DownBack = null;
            this.btnEmail.Location = new System.Drawing.Point(318, 172);
            this.btnEmail.MouseBack = null;
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.NormlBack = null;
            this.btnEmail.Size = new System.Drawing.Size(75, 23);
            this.btnEmail.TabIndex = 43;
            this.btnEmail.Text = "解除";
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnFace
            // 
            this.btnFace.BackColor = System.Drawing.Color.Transparent;
            this.btnFace.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnFace.DownBack = null;
            this.btnFace.Location = new System.Drawing.Point(318, 211);
            this.btnFace.MouseBack = null;
            this.btnFace.Name = "btnFace";
            this.btnFace.NormlBack = null;
            this.btnFace.Size = new System.Drawing.Size(75, 23);
            this.btnFace.TabIndex = 43;
            this.btnFace.Text = "绑定";
            this.btnFace.UseVisualStyleBackColor = false;
            this.btnFace.Click += new System.EventHandler(this.btnFace_Click);
            // 
            // labelChangeInfo
            // 
            this.labelChangeInfo.AutoSize = true;
            this.labelChangeInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelChangeInfo.BorderColor = System.Drawing.Color.White;
            this.labelChangeInfo.Font = new System.Drawing.Font("黑体", 14.25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelChangeInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(177)))), ((int)(((byte)(227)))));
            this.labelChangeInfo.Location = new System.Drawing.Point(300, 54);
            this.labelChangeInfo.Name = "labelChangeInfo";
            this.labelChangeInfo.Size = new System.Drawing.Size(93, 19);
            this.labelChangeInfo.TabIndex = 45;
            this.labelChangeInfo.Text = "编辑资料";
            this.labelChangeInfo.Click += new System.EventHandler(this.labelChangeInfo_Click);
            // 
            // panelSex
            // 
            this.panelSex.BackColor = System.Drawing.Color.White;
            this.panelSex.Controls.Add(this.radioWoman);
            this.panelSex.Controls.Add(this.radioMan);
            this.panelSex.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelSex.DownBack = null;
            this.panelSex.Font = new System.Drawing.Font("宋体", 15F);
            this.panelSex.Location = new System.Drawing.Point(173, 83);
            this.panelSex.MouseBack = null;
            this.panelSex.Name = "panelSex";
            this.panelSex.NormlBack = null;
            this.panelSex.Size = new System.Drawing.Size(113, 33);
            this.panelSex.TabIndex = 47;
            // 
            // radioWoman
            // 
            this.radioWoman.AutoSize = true;
            this.radioWoman.BackColor = System.Drawing.Color.Transparent;
            this.radioWoman.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.radioWoman.DownBack = null;
            this.radioWoman.Font = new System.Drawing.Font("宋体", 15F);
            this.radioWoman.Location = new System.Drawing.Point(63, 3);
            this.radioWoman.MouseBack = null;
            this.radioWoman.Name = "radioWoman";
            this.radioWoman.NormlBack = null;
            this.radioWoman.SelectedDownBack = null;
            this.radioWoman.SelectedMouseBack = null;
            this.radioWoman.SelectedNormlBack = null;
            this.radioWoman.Size = new System.Drawing.Size(47, 24);
            this.radioWoman.TabIndex = 0;
            this.radioWoman.TabStop = true;
            this.radioWoman.Text = "女";
            this.radioWoman.UseVisualStyleBackColor = false;
            // 
            // radioMan
            // 
            this.radioMan.AutoSize = true;
            this.radioMan.BackColor = System.Drawing.Color.Transparent;
            this.radioMan.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.radioMan.DownBack = null;
            this.radioMan.Font = new System.Drawing.Font("宋体", 15F);
            this.radioMan.Location = new System.Drawing.Point(3, 3);
            this.radioMan.MouseBack = null;
            this.radioMan.Name = "radioMan";
            this.radioMan.NormlBack = null;
            this.radioMan.SelectedDownBack = null;
            this.radioMan.SelectedMouseBack = null;
            this.radioMan.SelectedNormlBack = null;
            this.radioMan.Size = new System.Drawing.Size(47, 24);
            this.radioMan.TabIndex = 0;
            this.radioMan.TabStop = true;
            this.radioMan.Text = "男";
            this.radioMan.UseVisualStyleBackColor = false;
            // 
            // btnChooseHead
            // 
            this.btnChooseHead.BackColor = System.Drawing.Color.Transparent;
            this.btnChooseHead.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnChooseHead.DownBack = null;
            this.btnChooseHead.Location = new System.Drawing.Point(29, 111);
            this.btnChooseHead.MouseBack = null;
            this.btnChooseHead.Name = "btnChooseHead";
            this.btnChooseHead.NormlBack = null;
            this.btnChooseHead.Size = new System.Drawing.Size(60, 23);
            this.btnChooseHead.TabIndex = 48;
            this.btnChooseHead.Text = "浏览";
            this.btnChooseHead.UseVisualStyleBackColor = false;
            this.btnChooseHead.Click += new System.EventHandler(this.btnChooseHead_Click);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // textName
            // 
            this.textName.BackColor = System.Drawing.Color.Transparent;
            this.textName.DownBack = null;
            this.textName.Icon = null;
            this.textName.IconIsButton = false;
            this.textName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textName.IsPasswordChat = '\0';
            this.textName.IsSystemPasswordChar = false;
            this.textName.Lines = new string[0];
            this.textName.Location = new System.Drawing.Point(173, 49);
            this.textName.Margin = new System.Windows.Forms.Padding(0);
            this.textName.MaxLength = 32767;
            this.textName.MinimumSize = new System.Drawing.Size(28, 28);
            this.textName.MouseBack = null;
            this.textName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textName.Multiline = false;
            this.textName.Name = "textName";
            this.textName.NormlBack = null;
            this.textName.Padding = new System.Windows.Forms.Padding(5);
            this.textName.ReadOnly = false;
            this.textName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textName.Size = new System.Drawing.Size(113, 28);
            // 
            // 
            // 
            this.textName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textName.SkinTxt.Font = new System.Drawing.Font("宋体", 15F);
            this.textName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textName.SkinTxt.Name = "BaseText";
            this.textName.SkinTxt.Size = new System.Drawing.Size(103, 23);
            this.textName.SkinTxt.TabIndex = 0;
            this.textName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textName.SkinTxt.WaterText = "";
            this.textName.TabIndex = 51;
            this.textName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textName.WaterText = "";
            this.textName.WordWrap = true;
            // 
            // textLife
            // 
            this.textLife.BackColor = System.Drawing.Color.Transparent;
            this.textLife.DownBack = null;
            this.textLife.Icon = null;
            this.textLife.IconIsButton = false;
            this.textLife.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textLife.IsPasswordChat = '\0';
            this.textLife.IsSystemPasswordChar = false;
            this.textLife.Lines = new string[0];
            this.textLife.Location = new System.Drawing.Point(28, 266);
            this.textLife.Margin = new System.Windows.Forms.Padding(0);
            this.textLife.MaxLength = 32767;
            this.textLife.MinimumSize = new System.Drawing.Size(28, 28);
            this.textLife.MouseBack = null;
            this.textLife.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textLife.Multiline = true;
            this.textLife.Name = "textLife";
            this.textLife.NormlBack = null;
            this.textLife.Padding = new System.Windows.Forms.Padding(5);
            this.textLife.ReadOnly = false;
            this.textLife.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textLife.Size = new System.Drawing.Size(352, 87);
            // 
            // 
            // 
            this.textLife.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textLife.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textLife.SkinTxt.Font = new System.Drawing.Font("宋体", 15F);
            this.textLife.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textLife.SkinTxt.Multiline = true;
            this.textLife.SkinTxt.Name = "BaseText";
            this.textLife.SkinTxt.Size = new System.Drawing.Size(342, 77);
            this.textLife.SkinTxt.TabIndex = 0;
            this.textLife.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textLife.SkinTxt.WaterText = "";
            this.textLife.TabIndex = 52;
            this.textLife.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textLife.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textLife.WaterText = "";
            this.textLife.WordWrap = true;
            // 
            // BtnClose
            // 
            this.BtnClose.AdaptImage = true;
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnClose.BaseColor = System.Drawing.Color.Wheat;
            this.BtnClose.Borders.BottomColor = System.Drawing.Color.Empty;
            this.BtnClose.Borders.BottomWidth = 1;
            this.BtnClose.Borders.LeftColor = System.Drawing.Color.Empty;
            this.BtnClose.Borders.LeftWidth = 1;
            this.BtnClose.Borders.RightColor = System.Drawing.Color.Empty;
            this.BtnClose.Borders.RightWidth = 1;
            this.BtnClose.Borders.TopColor = System.Drawing.Color.Empty;
            this.BtnClose.Borders.TopWidth = 1;
            this.BtnClose.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("BtnClose.Canvas")));
            this.BtnClose.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.BtnClose.HaloColor = System.Drawing.Color.White;
            this.BtnClose.HaloSize = 5;
            this.BtnClose.HoverImage = global::WeLink.Properties.Resources.sysbtn_close_hover;
            this.BtnClose.IsPureColor = false;
            this.BtnClose.Location = new System.Drawing.Point(387, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.NormalImage = global::WeLink.Properties.Resources.sysbtn_close_normal;
            this.BtnClose.PressedImage = global::WeLink.Properties.Resources.sysbtn_close_down;
            this.BtnClose.Radius = 10;
            this.BtnClose.ShowBorder = true;
            this.BtnClose.Size = new System.Drawing.Size(30, 27);
            this.BtnClose.TabIndex = 53;
            this.BtnClose.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.BtnClose.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.BtnClose.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.White;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(6, 35);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(411, 10);
            this.skinLine1.TabIndex = 67;
            this.skinLine1.Text = "skinLine1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::WeLink.Properties.Resources._23像素图标;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 23);
            this.label1.TabIndex = 66;
            this.label1.Text = "我的信息";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeLink.Properties.Resources.瑞士冬季;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(422, 367);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.textLife);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.btnChooseHead);
            this.Controls.Add(this.panelSex);
            this.Controls.Add(this.labelChangeInfo);
            this.Controls.Add(this.btnFace);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.labelLife);
            this.Controls.Add(this.labelFace);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelCardID);
            this.Controls.Add(this.labelSex);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.headImg);
            this.Name = "UserInfo";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelSex.ResumeLayout(false);
            this.panelSex.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LayeredSkin.Controls.LayeredBaseControl headImg;
        private CCWin.SkinControl.SkinLabel labelName;
        private CCWin.SkinControl.SkinLabel labelSex;
        private CCWin.SkinControl.SkinLabel labelCardID;
        private System.Windows.Forms.Label labelLife;
        private CCWin.SkinControl.SkinLabel labelEmail;
        private CCWin.SkinControl.SkinLabel labelFace;
        private CCWin.SkinControl.SkinButton btnEmail;
        private CCWin.SkinControl.SkinButton btnFace;
        private CCWin.SkinControl.SkinLabel labelChangeInfo;
        private CCWin.SkinControl.SkinPanel panelSex;
        private CCWin.SkinControl.SkinRadioButton radioWoman;
        private CCWin.SkinControl.SkinRadioButton radioMan;
        private CCWin.SkinControl.SkinButton btnChooseHead;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private CCWin.SkinControl.SkinTextBox textName;
        private CCWin.SkinControl.SkinTextBox textLife;
        private LayeredSkin.Controls.LayeredButton BtnClose;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label label1;
    }
}