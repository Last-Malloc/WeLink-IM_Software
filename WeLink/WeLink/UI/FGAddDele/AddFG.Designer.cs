namespace WeLink.UI
{
    partial class AddFG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFG));
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.textCheckStr = new LayeredSkin.Controls.LayeredTextBox();
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.btnSearch = new CCWin.SkinControl.SkinButton();
            this.HeadImg = new LayeredSkin.Controls.LayeredBaseControl();
            this.textIDorEmail = new LayeredSkin.Controls.LayeredTextBox();
            this.labelCardID = new System.Windows.Forms.Label();
            this.label账号 = new System.Windows.Forms.Label();
            this.label昵称 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.iconSex = new System.Windows.Forms.Button();
            this.label群主 = new System.Windows.Forms.Label();
            this.labelMaster = new System.Windows.Forms.Label();
            this.label签名 = new System.Windows.Forms.Label();
            this.labelLife = new System.Windows.Forms.Label();
            this.comboAddType = new CCWin.SkinControl.SkinComboBox();
            this.panel = new LayeredSkin.Controls.LayeredPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DownBack = null;
            this.btnOK.Enabled = false;
            this.btnOK.Font = new System.Drawing.Font("宋体", 15F);
            this.btnOK.Location = new System.Drawing.Point(376, 319);
            this.btnOK.MouseBack = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Size = new System.Drawing.Size(88, 30);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // textCheckStr
            // 
            this.textCheckStr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textCheckStr.Borders.BottomColor = System.Drawing.Color.Empty;
            this.textCheckStr.Borders.BottomWidth = 1;
            this.textCheckStr.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textCheckStr.Borders.LeftWidth = 1;
            this.textCheckStr.Borders.RightColor = System.Drawing.Color.Empty;
            this.textCheckStr.Borders.RightWidth = 1;
            this.textCheckStr.Borders.TopColor = System.Drawing.Color.Empty;
            this.textCheckStr.Borders.TopWidth = 1;
            this.textCheckStr.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textCheckStr.Canvas")));
            this.textCheckStr.Font = new System.Drawing.Font("宋体", 15F);
            this.textCheckStr.Location = new System.Drawing.Point(25, 319);
            this.textCheckStr.Multiline = true;
            this.textCheckStr.Name = "textCheckStr";
            this.textCheckStr.Size = new System.Drawing.Size(331, 82);
            this.textCheckStr.TabIndex = 1;
            this.textCheckStr.TransparencyKey = System.Drawing.Color.Empty;
            this.textCheckStr.WaterFont = new System.Drawing.Font("宋体", 15F);
            this.textCheckStr.WaterText = "向对方发送验证信息";
            this.textCheckStr.WaterTextOffset = new System.Drawing.Point(0, 0);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DownBack = null;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 15F);
            this.btnCancel.Location = new System.Drawing.Point(376, 371);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(88, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSearch.DownBack = null;
            this.btnSearch.Font = new System.Drawing.Font("宋体", 15F);
            this.btnSearch.Location = new System.Drawing.Point(389, 50);
            this.btnSearch.MouseBack = null;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.NormlBack = null;
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // HeadImg
            // 
            this.HeadImg.BackgroundImage = global::WeLink.Properties.Resources.moren;
            this.HeadImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeadImg.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HeadImg.Borders.BottomWidth = 1;
            this.HeadImg.Borders.LeftColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HeadImg.Borders.LeftWidth = 1;
            this.HeadImg.Borders.RightColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HeadImg.Borders.RightWidth = 1;
            this.HeadImg.Borders.TopColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.HeadImg.Borders.TopWidth = 1;
            this.HeadImg.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("HeadImg.Canvas")));
            this.HeadImg.ForeColor = System.Drawing.Color.Black;
            this.HeadImg.Location = new System.Drawing.Point(14, 3);
            this.HeadImg.Name = "HeadImg";
            this.HeadImg.Size = new System.Drawing.Size(100, 100);
            this.HeadImg.TabIndex = 8;
            // 
            // textIDorEmail
            // 
            this.textIDorEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textIDorEmail.Borders.BottomColor = System.Drawing.Color.Empty;
            this.textIDorEmail.Borders.BottomWidth = 1;
            this.textIDorEmail.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textIDorEmail.Borders.LeftWidth = 1;
            this.textIDorEmail.Borders.RightColor = System.Drawing.Color.Empty;
            this.textIDorEmail.Borders.RightWidth = 1;
            this.textIDorEmail.Borders.TopColor = System.Drawing.Color.Empty;
            this.textIDorEmail.Borders.TopWidth = 1;
            this.textIDorEmail.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textIDorEmail.Canvas")));
            this.textIDorEmail.Font = new System.Drawing.Font("宋体", 15F);
            this.textIDorEmail.Location = new System.Drawing.Point(123, 50);
            this.textIDorEmail.Name = "textIDorEmail";
            this.textIDorEmail.Size = new System.Drawing.Size(254, 30);
            this.textIDorEmail.TabIndex = 9;
            this.textIDorEmail.TransparencyKey = System.Drawing.Color.Empty;
            this.textIDorEmail.WaterFont = new System.Drawing.Font("宋体", 15F);
            this.textIDorEmail.WaterText = "输入用户账号/邮箱/昵称";
            this.textIDorEmail.WaterTextOffset = new System.Drawing.Point(0, 0);
            // 
            // labelCardID
            // 
            this.labelCardID.AutoSize = true;
            this.labelCardID.BackColor = System.Drawing.Color.Transparent;
            this.labelCardID.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.labelCardID.ForeColor = System.Drawing.Color.Black;
            this.labelCardID.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelCardID.Location = new System.Drawing.Point(233, 43);
            this.labelCardID.Name = "labelCardID";
            this.labelCardID.Size = new System.Drawing.Size(119, 20);
            this.labelCardID.TabIndex = 50;
            this.labelCardID.Text = "0000000000";
            this.labelCardID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label账号
            // 
            this.label账号.AutoSize = true;
            this.label账号.BackColor = System.Drawing.Color.Transparent;
            this.label账号.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label账号.ForeColor = System.Drawing.Color.Black;
            this.label账号.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label账号.Location = new System.Drawing.Point(178, 43);
            this.label账号.Name = "label账号";
            this.label账号.Size = new System.Drawing.Size(51, 20);
            this.label账号.TabIndex = 49;
            this.label账号.Text = "账号";
            this.label账号.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label昵称
            // 
            this.label昵称.AutoSize = true;
            this.label昵称.BackColor = System.Drawing.Color.Transparent;
            this.label昵称.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label昵称.ForeColor = System.Drawing.Color.Black;
            this.label昵称.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label昵称.Location = new System.Drawing.Point(178, 3);
            this.label昵称.Name = "label昵称";
            this.label昵称.Size = new System.Drawing.Size(51, 20);
            this.label昵称.TabIndex = 49;
            this.label昵称.Text = "昵称";
            this.label昵称.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelName.Location = new System.Drawing.Point(233, 3);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(64, 20);
            this.labelName.TabIndex = 50;
            this.labelName.Text = "xxxxx";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // iconSex
            // 
            this.iconSex.BackColor = System.Drawing.Color.Transparent;
            this.iconSex.BackgroundImage = global::WeLink.Properties.Resources.男;
            this.iconSex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iconSex.FlatAppearance.BorderSize = 0;
            this.iconSex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconSex.ForeColor = System.Drawing.Color.Black;
            this.iconSex.Location = new System.Drawing.Point(120, 63);
            this.iconSex.Name = "iconSex";
            this.iconSex.Size = new System.Drawing.Size(40, 40);
            this.iconSex.TabIndex = 51;
            this.iconSex.UseVisualStyleBackColor = false;
            // 
            // label群主
            // 
            this.label群主.AutoSize = true;
            this.label群主.BackColor = System.Drawing.Color.Transparent;
            this.label群主.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label群主.ForeColor = System.Drawing.Color.Black;
            this.label群主.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label群主.Location = new System.Drawing.Point(178, 83);
            this.label群主.Name = "label群主";
            this.label群主.Size = new System.Drawing.Size(51, 20);
            this.label群主.TabIndex = 49;
            this.label群主.Text = "群主";
            this.label群主.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelMaster
            // 
            this.labelMaster.AutoSize = true;
            this.labelMaster.BackColor = System.Drawing.Color.Transparent;
            this.labelMaster.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.labelMaster.ForeColor = System.Drawing.Color.Black;
            this.labelMaster.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelMaster.Location = new System.Drawing.Point(233, 83);
            this.labelMaster.Name = "labelMaster";
            this.labelMaster.Size = new System.Drawing.Size(196, 20);
            this.labelMaster.TabIndex = 50;
            this.labelMaster.Text = "xxxxx(0000000000)";
            this.labelMaster.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label签名
            // 
            this.label签名.AutoSize = true;
            this.label签名.BackColor = System.Drawing.Color.Transparent;
            this.label签名.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label签名.ForeColor = System.Drawing.Color.Black;
            this.label签名.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label签名.Location = new System.Drawing.Point(10, 106);
            this.label签名.Name = "label签名";
            this.label签名.Size = new System.Drawing.Size(93, 20);
            this.label签名.TabIndex = 52;
            this.label签名.Text = "个性签名";
            this.label签名.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLife
            // 
            this.labelLife.BackColor = System.Drawing.Color.Transparent;
            this.labelLife.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.labelLife.ForeColor = System.Drawing.Color.Black;
            this.labelLife.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelLife.Location = new System.Drawing.Point(10, 126);
            this.labelLife.Name = "labelLife";
            this.labelLife.Size = new System.Drawing.Size(419, 88);
            this.labelLife.TabIndex = 50;
            this.labelLife.Text = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            // 
            // comboAddType
            // 
            this.comboAddType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboAddType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAddType.Font = new System.Drawing.Font("宋体", 15F);
            this.comboAddType.FormattingEnabled = true;
            this.comboAddType.Items.AddRange(new object[] {
            "找人",
            "找群"});
            this.comboAddType.Location = new System.Drawing.Point(25, 49);
            this.comboAddType.Name = "comboAddType";
            this.comboAddType.Size = new System.Drawing.Size(92, 31);
            this.comboAddType.TabIndex = 56;
            this.comboAddType.WaterText = "";
            this.comboAddType.SelectedIndexChanged += new System.EventHandler(this.comboAddType_SelectedIndexChanged);
            // 
            // panel
            // 
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel.Borders.BottomColor = System.Drawing.Color.Empty;
            this.panel.Borders.BottomWidth = 1;
            this.panel.Borders.LeftColor = System.Drawing.Color.Empty;
            this.panel.Borders.LeftWidth = 1;
            this.panel.Borders.RightColor = System.Drawing.Color.Empty;
            this.panel.Borders.RightWidth = 1;
            this.panel.Borders.TopColor = System.Drawing.Color.Empty;
            this.panel.Borders.TopWidth = 1;
            this.panel.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("panel.Canvas")));
            this.panel.Controls.Add(this.label签名);
            this.panel.Controls.Add(this.label账号);
            this.panel.Controls.Add(this.labelMaster);
            this.panel.Controls.Add(this.label群主);
            this.panel.Controls.Add(this.HeadImg);
            this.panel.Controls.Add(this.iconSex);
            this.panel.Controls.Add(this.labelCardID);
            this.panel.Controls.Add(this.labelLife);
            this.panel.Controls.Add(this.labelName);
            this.panel.Controls.Add(this.label昵称);
            this.panel.Location = new System.Drawing.Point(25, 91);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(439, 222);
            this.panel.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::WeLink.Properties.Resources._23像素图标;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 58;
            this.label1.Text = "添加好友或群";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinLine1.LineColor = System.Drawing.Color.White;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(4, 34);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(484, 10);
            this.skinLine1.TabIndex = 59;
            this.skinLine1.Text = "skinLine1";
            // 
            // AddFG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeLink.Properties.Resources.纯色紫背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderColor = System.Drawing.Color.Black;
            this.BorderRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.CaptionFont = new System.Drawing.Font("宋体", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(492, 409);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.comboAddType);
            this.Controls.Add(this.textIDorEmail);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.textCheckStr);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.skinLine1);
            this.EffectBack = System.Drawing.Color.Transparent;
            this.EffectCaption = CCWin.TitleType.None;
            this.EffectWidth = 60;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MdiAutoScroll = false;
            this.MinimizeBox = false;
            this.Name = "AddFG";
            this.Opacity = 0.8D;
            this.Radius = 5;
            this.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.ShowDrawIcon = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.TitleCenter = false;
            this.Load += new System.EventHandler(this.AddFG_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinButton btnOK;
        private LayeredSkin.Controls.LayeredTextBox textCheckStr;
        private CCWin.SkinControl.SkinButton btnCancel;
        private CCWin.SkinControl.SkinButton btnSearch;
        private LayeredSkin.Controls.LayeredBaseControl HeadImg;
        private LayeredSkin.Controls.LayeredTextBox textIDorEmail;
        private System.Windows.Forms.Label labelCardID;
        private System.Windows.Forms.Label label账号;
        private System.Windows.Forms.Label label昵称;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button iconSex;
        private System.Windows.Forms.Label label群主;
        private System.Windows.Forms.Label labelMaster;
        private System.Windows.Forms.Label labelLife;
        private System.Windows.Forms.Label label签名;
        private CCWin.SkinControl.SkinComboBox comboAddType;
        private LayeredSkin.Controls.LayeredPanel panel;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinLine skinLine1;
    }
}