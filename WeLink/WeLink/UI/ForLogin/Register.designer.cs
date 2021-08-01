namespace WeLink.UI
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.BtnMini = new LayeredSkin.Controls.LayeredButton();
            this.BtnClose = new LayeredSkin.Controls.LayeredButton();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.textLife = new LayeredSkin.Controls.LayeredTextBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.radioWoman = new CCWin.SkinControl.SkinRadioButton();
            this.radioMan = new CCWin.SkinControl.SkinRadioButton();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.btnChooseHead = new CCWin.SkinControl.SkinButton();
            this.btnSet = new CCWin.SkinControl.SkinButton();
            this.HeadImg = new LayeredSkin.Controls.LayeredBaseControl();
            this.BtnCancel = new CCWin.SkinControl.SkinButton();
            this.textName = new LayeredSkin.Controls.LayeredTextBox();
            this.textPW = new LayeredSkin.Controls.LayeredTextBox();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.label1 = new System.Windows.Forms.Label();
            this.skinPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnMini
            // 
            this.BtnMini.AdaptImage = true;
            this.BtnMini.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnMini.BaseColor = System.Drawing.Color.Wheat;
            this.BtnMini.Borders.BottomColor = System.Drawing.Color.Empty;
            this.BtnMini.Borders.BottomWidth = 1;
            this.BtnMini.Borders.LeftColor = System.Drawing.Color.Empty;
            this.BtnMini.Borders.LeftWidth = 1;
            this.BtnMini.Borders.RightColor = System.Drawing.Color.Empty;
            this.BtnMini.Borders.RightWidth = 1;
            this.BtnMini.Borders.TopColor = System.Drawing.Color.Empty;
            this.BtnMini.Borders.TopWidth = 1;
            this.BtnMini.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("BtnMini.Canvas")));
            this.BtnMini.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.BtnMini.HaloColor = System.Drawing.Color.White;
            this.BtnMini.HaloSize = 5;
            this.BtnMini.HoverImage = global::WeLink.Properties.Resources.sysbtn_min_hover;
            this.BtnMini.IsPureColor = false;
            this.BtnMini.Location = new System.Drawing.Point(284, 5);
            this.BtnMini.Name = "BtnMini";
            this.BtnMini.NormalImage = global::WeLink.Properties.Resources.sysbtn_min_normal;
            this.BtnMini.PressedImage = global::WeLink.Properties.Resources.sysbtn_min_down;
            this.BtnMini.Radius = 10;
            this.BtnMini.ShowBorder = true;
            this.BtnMini.Size = new System.Drawing.Size(30, 27);
            this.BtnMini.TabIndex = 26;
            this.BtnMini.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.BtnMini.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.BtnMini.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.BtnMini.Click += new System.EventHandler(this.BtnMiniClick);
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
            this.BtnClose.Location = new System.Drawing.Point(310, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.NormalImage = global::WeLink.Properties.Resources.sysbtn_close_normal;
            this.BtnClose.PressedImage = global::WeLink.Properties.Resources.sysbtn_close_down;
            this.BtnClose.Radius = 10;
            this.BtnClose.ShowBorder = true;
            this.BtnClose.Size = new System.Drawing.Size(30, 27);
            this.BtnClose.TabIndex = 25;
            this.BtnClose.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.BtnClose.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.BtnClose.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.BtnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(12, 189);
            this.skinLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(85, 19);
            this.skinLabel5.TabIndex = 29;
            this.skinLabel5.Text = "个性签名";
            // 
            // textLife
            // 
            this.textLife.BackColor = System.Drawing.Color.White;
            this.textLife.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textLife.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textLife.Borders.BottomWidth = 3;
            this.textLife.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textLife.Borders.LeftWidth = 1;
            this.textLife.Borders.RightColor = System.Drawing.Color.Empty;
            this.textLife.Borders.RightWidth = 1;
            this.textLife.Borders.TopColor = System.Drawing.Color.Empty;
            this.textLife.Borders.TopWidth = 1;
            this.textLife.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textLife.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textLife.Canvas")));
            this.textLife.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textLife.ForeColor = System.Drawing.Color.Black;
            this.textLife.Location = new System.Drawing.Point(117, 189);
            this.textLife.Multiline = true;
            this.textLife.Name = "textLife";
            this.textLife.Size = new System.Drawing.Size(178, 82);
            this.textLife.TabIndex = 28;
            this.textLife.TransparencyKey = System.Drawing.Color.Black;
            this.textLife.WaterColor = System.Drawing.Color.Black;
            this.textLife.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textLife.WaterText = "50字符以内";
            this.textLife.WaterTextOffset = new System.Drawing.Point(0, 0);
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(50, 155);
            this.skinLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(47, 19);
            this.skinLabel2.TabIndex = 29;
            this.skinLabel2.Text = "密码";
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.radioWoman);
            this.skinPanel1.Controls.Add(this.radioMan);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(117, 107);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(181, 23);
            this.skinPanel1.TabIndex = 37;
            // 
            // radioWoman
            // 
            this.radioWoman.AutoSize = true;
            this.radioWoman.BackColor = System.Drawing.Color.Transparent;
            this.radioWoman.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.radioWoman.DownBack = null;
            this.radioWoman.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioWoman.Location = new System.Drawing.Point(123, 0);
            this.radioWoman.MouseBack = null;
            this.radioWoman.Name = "radioWoman";
            this.radioWoman.NormlBack = null;
            this.radioWoman.SelectedDownBack = null;
            this.radioWoman.SelectedMouseBack = null;
            this.radioWoman.SelectedNormlBack = null;
            this.radioWoman.Size = new System.Drawing.Size(38, 21);
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
            this.radioMan.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioMan.Location = new System.Drawing.Point(36, 0);
            this.radioMan.MouseBack = null;
            this.radioMan.Name = "radioMan";
            this.radioMan.NormlBack = null;
            this.radioMan.SelectedDownBack = null;
            this.radioMan.SelectedMouseBack = null;
            this.radioMan.SelectedNormlBack = null;
            this.radioMan.Size = new System.Drawing.Size(38, 21);
            this.radioMan.TabIndex = 0;
            this.radioMan.TabStop = true;
            this.radioMan.Text = "男";
            this.radioMan.UseVisualStyleBackColor = false;
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(113, 71);
            this.skinLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(47, 19);
            this.skinLabel3.TabIndex = 29;
            this.skinLabel3.Text = "昵称";
            // 
            // btnChooseHead
            // 
            this.btnChooseHead.BackColor = System.Drawing.Color.Transparent;
            this.btnChooseHead.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnChooseHead.DownBack = null;
            this.btnChooseHead.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChooseHead.Location = new System.Drawing.Point(37, 117);
            this.btnChooseHead.MouseBack = null;
            this.btnChooseHead.Name = "btnChooseHead";
            this.btnChooseHead.NormlBack = null;
            this.btnChooseHead.Size = new System.Drawing.Size(60, 23);
            this.btnChooseHead.TabIndex = 32;
            this.btnChooseHead.Text = "浏览";
            this.btnChooseHead.UseVisualStyleBackColor = false;
            this.btnChooseHead.Click += new System.EventHandler(this.btnChooseHead_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSet.DownBack = null;
            this.btnSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.Location = new System.Drawing.Point(54, 288);
            this.btnSet.MouseBack = null;
            this.btnSet.Name = "btnSet";
            this.btnSet.NormlBack = null;
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 32;
            this.btnSet.Text = "申请";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // HeadImg
            // 
            this.HeadImg.BackgroundImage = global::WeLink.Properties.Resources.moren;
            this.HeadImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeadImg.Borders.BottomColor = System.Drawing.Color.Black;
            this.HeadImg.Borders.BottomWidth = 1;
            this.HeadImg.Borders.LeftColor = System.Drawing.Color.Black;
            this.HeadImg.Borders.LeftWidth = 1;
            this.HeadImg.Borders.RightColor = System.Drawing.Color.Black;
            this.HeadImg.Borders.RightWidth = 1;
            this.HeadImg.Borders.TopColor = System.Drawing.Color.Black;
            this.HeadImg.Borders.TopWidth = 1;
            this.HeadImg.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("HeadImg.Canvas")));
            this.HeadImg.Location = new System.Drawing.Point(37, 51);
            this.HeadImg.Name = "HeadImg";
            this.HeadImg.Size = new System.Drawing.Size(60, 60);
            this.HeadImg.TabIndex = 36;
            this.HeadImg.Text = "layeredBaseControl3";
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BtnCancel.DownBack = null;
            this.BtnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCancel.Location = new System.Drawing.Point(220, 288);
            this.BtnCancel.MouseBack = null;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.NormlBack = null;
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 32;
            this.BtnCancel.Text = "返回";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // textName
            // 
            this.textName.BackColor = System.Drawing.Color.White;
            this.textName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textName.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textName.Borders.BottomWidth = 3;
            this.textName.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textName.Borders.LeftWidth = 1;
            this.textName.Borders.RightColor = System.Drawing.Color.Empty;
            this.textName.Borders.RightWidth = 1;
            this.textName.Borders.TopColor = System.Drawing.Color.Empty;
            this.textName.Borders.TopWidth = 1;
            this.textName.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textName.Canvas")));
            this.textName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textName.ForeColor = System.Drawing.Color.Black;
            this.textName.Location = new System.Drawing.Point(165, 60);
            this.textName.Multiline = true;
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(133, 30);
            this.textName.TabIndex = 28;
            this.textName.TransparencyKey = System.Drawing.Color.Black;
            this.textName.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textName.WaterText = "";
            this.textName.WaterTextOffset = new System.Drawing.Point(0, 0);
            // 
            // textPW
            // 
            this.textPW.BackColor = System.Drawing.Color.White;
            this.textPW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textPW.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textPW.Borders.BottomWidth = 3;
            this.textPW.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textPW.Borders.LeftWidth = 1;
            this.textPW.Borders.RightColor = System.Drawing.Color.Empty;
            this.textPW.Borders.RightWidth = 1;
            this.textPW.Borders.TopColor = System.Drawing.Color.Empty;
            this.textPW.Borders.TopWidth = 1;
            this.textPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPW.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textPW.Canvas")));
            this.textPW.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPW.ForeColor = System.Drawing.Color.Black;
            this.textPW.Location = new System.Drawing.Point(117, 144);
            this.textPW.Multiline = true;
            this.textPW.Name = "textPW";
            this.textPW.PasswordChar = '●';
            this.textPW.Size = new System.Drawing.Size(181, 30);
            this.textPW.TabIndex = 28;
            this.textPW.TransparencyKey = System.Drawing.Color.Black;
            this.textPW.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPW.WaterText = "(6-20位数字或字母)";
            this.textPW.WaterTextOffset = new System.Drawing.Point(0, 0);
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.White;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(5, 35);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(335, 10);
            this.skinLine1.TabIndex = 65;
            this.skinLine1.Text = "skinLine1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::WeLink.Properties.Resources._23像素图标;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 64;
            this.label1.Text = "用户注册";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Register
            // 
            this.AnimationType = LayeredSkin.Forms.AnimationTypes.ThreeDTurn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::WeLink.Properties.Resources.纯色紫背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(345, 323);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textPW);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnMini);
            this.Controls.Add(this.HeadImg);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnChooseHead);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.textLife);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinPanel1);
            this.Controls.Add(this.skinLabel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.skinPanel1.ResumeLayout(false);
            this.skinPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LayeredSkin.Controls.LayeredButton BtnMini;
        private LayeredSkin.Controls.LayeredButton BtnClose;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private LayeredSkin.Controls.LayeredTextBox textLife;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private CCWin.SkinControl.SkinRadioButton radioWoman;
        private CCWin.SkinControl.SkinRadioButton radioMan;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinButton btnChooseHead;
        private CCWin.SkinControl.SkinButton btnSet;
        private LayeredSkin.Controls.LayeredBaseControl HeadImg;
        private CCWin.SkinControl.SkinButton BtnCancel;
        private LayeredSkin.Controls.LayeredTextBox textName;
        private LayeredSkin.Controls.LayeredTextBox textPW;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label label1;
    }
}