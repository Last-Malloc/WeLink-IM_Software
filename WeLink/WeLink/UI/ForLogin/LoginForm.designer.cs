namespace WeLink.UI
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            LayeredSkin.DirectUI.DuiCheckBox duiCheckBox3 = new LayeredSkin.DirectUI.DuiCheckBox();
            LayeredSkin.DirectUI.DuiCheckBox duiCheckBox4 = new LayeredSkin.DirectUI.DuiCheckBox();
            this.textPW = new LayeredSkin.Controls.LayeredTextBox();
            this.textCardID = new LayeredSkin.Controls.LayeredTextBox();
            this.btnRegister = new LayeredSkin.Controls.LayeredButton();
            this.btnFindBackPW = new LayeredSkin.Controls.LayeredButton();
            this.HeadImg = new LayeredSkin.Controls.LayeredBaseControl();
            this.BtnSet = new LayeredSkin.Controls.LayeredButton();
            this.BtnMini = new LayeredSkin.Controls.LayeredButton();
            this.BtnClose = new LayeredSkin.Controls.LayeredButton();
            this.layeredPanel1 = new LayeredSkin.Controls.LayeredPanel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.layeredPanel3 = new LayeredSkin.Controls.LayeredPanel();
            this.duiChkRemPW = new LayeredSkin.Controls.LayeredBaseControl();
            this.duiChkAutoLogin = new LayeredSkin.Controls.LayeredBaseControl();
            this.btnShowUserList = new LayeredSkin.Controls.LayeredButton();
            this.btnLoginByFace = new System.Windows.Forms.Button();
            this.btnLogin = new CCWin.SkinControl.SkinButton();
            this.btnLoginByEmail = new System.Windows.Forms.Button();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.pallet = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.conItemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.conItemOpenMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.conItemChangeID = new System.Windows.Forms.ToolStripMenuItem();
            this.conItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCancelLogin = new CCWin.SkinControl.SkinButton();
            this.layeredPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.layeredPanel3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textPW
            // 
            this.textPW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textPW.Borders.BottomColor = System.Drawing.Color.Empty;
            this.textPW.Borders.BottomWidth = 1;
            this.textPW.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textPW.Borders.LeftWidth = 1;
            this.textPW.Borders.RightColor = System.Drawing.Color.Empty;
            this.textPW.Borders.RightWidth = 1;
            this.textPW.Borders.TopColor = System.Drawing.Color.Empty;
            this.textPW.Borders.TopWidth = 1;
            this.textPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPW.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textPW.Canvas")));
            this.textPW.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPW.Location = new System.Drawing.Point(8, 33);
            this.textPW.Multiline = true;
            this.textPW.Name = "textPW";
            this.textPW.PasswordChar = '●';
            this.textPW.Size = new System.Drawing.Size(194, 30);
            this.textPW.TabIndex = 26;
            this.textPW.TransparencyKey = System.Drawing.Color.White;
            this.textPW.WaterFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPW.WaterText = "密码(6-20位数字或字母)";
            this.textPW.WaterTextOffset = new System.Drawing.Point(3, 5);
            this.textPW.MouseEnter += new System.EventHandler(this.textPW_MouseEnter);
            this.textPW.MouseLeave += new System.EventHandler(this.textPW_MouseLeave);
            // 
            // textCardID
            // 
            this.textCardID.BackColor = System.Drawing.Color.White;
            this.textCardID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textCardID.Borders.BottomColor = System.Drawing.Color.Empty;
            this.textCardID.Borders.BottomWidth = 1;
            this.textCardID.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textCardID.Borders.LeftWidth = 1;
            this.textCardID.Borders.RightColor = System.Drawing.Color.Empty;
            this.textCardID.Borders.RightWidth = 1;
            this.textCardID.Borders.TopColor = System.Drawing.Color.Empty;
            this.textCardID.Borders.TopWidth = 1;
            this.textCardID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textCardID.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textCardID.Canvas")));
            this.textCardID.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.textCardID.Location = new System.Drawing.Point(8, 3);
            this.textCardID.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.textCardID.Multiline = true;
            this.textCardID.Name = "textCardID";
            this.textCardID.Size = new System.Drawing.Size(194, 30);
            this.textCardID.TabIndex = 27;
            this.textCardID.TransparencyKey = System.Drawing.Color.White;
            this.textCardID.WaterFont = new System.Drawing.Font("微软雅黑", 9F);
            this.textCardID.WaterText = "WeLink账号(10位数字)";
            this.textCardID.WaterTextOffset = new System.Drawing.Point(3, 5);
            this.textCardID.TextChanged += new System.EventHandler(this.textCardID_TextChanged);
            this.textCardID.MouseEnter += new System.EventHandler(this.textCardID_MouseEnter);
            this.textCardID.MouseLeave += new System.EventHandler(this.textCardID_MouseLeave);
            // 
            // btnRegister
            // 
            this.btnRegister.AdaptImage = true;
            this.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRegister.BaseColor = System.Drawing.Color.Wheat;
            this.btnRegister.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btnRegister.Borders.BottomWidth = 1;
            this.btnRegister.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btnRegister.Borders.LeftWidth = 1;
            this.btnRegister.Borders.RightColor = System.Drawing.Color.Empty;
            this.btnRegister.Borders.RightWidth = 1;
            this.btnRegister.Borders.TopColor = System.Drawing.Color.Empty;
            this.btnRegister.Borders.TopWidth = 1;
            this.btnRegister.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btnRegister.Canvas")));
            this.btnRegister.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btnRegister.HaloColor = System.Drawing.Color.White;
            this.btnRegister.HaloSize = 5;
            this.btnRegister.HoverImage = global::WeLink.Properties.Resources.zhuce_hover;
            this.btnRegister.IsPureColor = false;
            this.btnRegister.Location = new System.Drawing.Point(222, 49);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.NormalImage = global::WeLink.Properties.Resources.zhuce;
            this.btnRegister.PressedImage = global::WeLink.Properties.Resources.zhuce_press;
            this.btnRegister.Radius = 10;
            this.btnRegister.ShowBorder = true;
            this.btnRegister.Size = new System.Drawing.Size(48, 11);
            this.btnRegister.TabIndex = 23;
            this.btnRegister.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btnRegister.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btnRegister.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnFindBackPW
            // 
            this.btnFindBackPW.AdaptImage = true;
            this.btnFindBackPW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFindBackPW.BaseColor = System.Drawing.Color.Wheat;
            this.btnFindBackPW.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btnFindBackPW.Borders.BottomWidth = 1;
            this.btnFindBackPW.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btnFindBackPW.Borders.LeftWidth = 1;
            this.btnFindBackPW.Borders.RightColor = System.Drawing.Color.Empty;
            this.btnFindBackPW.Borders.RightWidth = 1;
            this.btnFindBackPW.Borders.TopColor = System.Drawing.Color.Empty;
            this.btnFindBackPW.Borders.TopWidth = 1;
            this.btnFindBackPW.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btnFindBackPW.Canvas")));
            this.btnFindBackPW.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btnFindBackPW.HaloColor = System.Drawing.Color.White;
            this.btnFindBackPW.HaloSize = 5;
            this.btnFindBackPW.HoverImage = global::WeLink.Properties.Resources.mima_hover;
            this.btnFindBackPW.IsPureColor = false;
            this.btnFindBackPW.Location = new System.Drawing.Point(222, 12);
            this.btnFindBackPW.Name = "btnFindBackPW";
            this.btnFindBackPW.NormalImage = global::WeLink.Properties.Resources.mima;
            this.btnFindBackPW.PressedImage = global::WeLink.Properties.Resources.mima_press;
            this.btnFindBackPW.Radius = 10;
            this.btnFindBackPW.ShowBorder = true;
            this.btnFindBackPW.Size = new System.Drawing.Size(48, 11);
            this.btnFindBackPW.TabIndex = 23;
            this.btnFindBackPW.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btnFindBackPW.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btnFindBackPW.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btnFindBackPW.Click += new System.EventHandler(this.btnFindBackPW_Click);
            // 
            // HeadImg
            // 
            this.HeadImg.BackgroundImage = global::WeLink.Properties.Resources.moren;
            this.HeadImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HeadImg.Borders.BottomColor = System.Drawing.Color.Empty;
            this.HeadImg.Borders.BottomWidth = 1;
            this.HeadImg.Borders.LeftColor = System.Drawing.Color.Empty;
            this.HeadImg.Borders.LeftWidth = 1;
            this.HeadImg.Borders.RightColor = System.Drawing.Color.Empty;
            this.HeadImg.Borders.RightWidth = 1;
            this.HeadImg.Borders.TopColor = System.Drawing.Color.Empty;
            this.HeadImg.Borders.TopWidth = 1;
            this.HeadImg.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("HeadImg.Canvas")));
            this.HeadImg.Location = new System.Drawing.Point(179, 74);
            this.HeadImg.Name = "HeadImg";
            this.HeadImg.Size = new System.Drawing.Size(80, 80);
            this.HeadImg.TabIndex = 33;
            this.HeadImg.Text = "layeredBaseControl3";
            // 
            // BtnSet
            // 
            this.BtnSet.AdaptImage = true;
            this.BtnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnSet.BaseColor = System.Drawing.Color.Wheat;
            this.BtnSet.Borders.BottomColor = System.Drawing.Color.Empty;
            this.BtnSet.Borders.BottomWidth = 1;
            this.BtnSet.Borders.LeftColor = System.Drawing.Color.Empty;
            this.BtnSet.Borders.LeftWidth = 1;
            this.BtnSet.Borders.RightColor = System.Drawing.Color.Empty;
            this.BtnSet.Borders.RightWidth = 1;
            this.BtnSet.Borders.TopColor = System.Drawing.Color.Empty;
            this.BtnSet.Borders.TopWidth = 1;
            this.BtnSet.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("BtnSet.Canvas")));
            this.BtnSet.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.BtnSet.HaloColor = System.Drawing.Color.White;
            this.BtnSet.HaloSize = 5;
            this.BtnSet.HoverImage = global::WeLink.Properties.Resources.aio_setting_hover;
            this.BtnSet.IsPureColor = false;
            this.BtnSet.Location = new System.Drawing.Point(342, 0);
            this.BtnSet.Name = "BtnSet";
            this.BtnSet.NormalImage = global::WeLink.Properties.Resources.aio_setting_normal;
            this.BtnSet.PressedImage = global::WeLink.Properties.Resources.aio_setting_down;
            this.BtnSet.Radius = 10;
            this.BtnSet.ShowBorder = true;
            this.BtnSet.Size = new System.Drawing.Size(30, 27);
            this.BtnSet.TabIndex = 8;
            this.BtnSet.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.BtnSet.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.BtnSet.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.BtnSet.Click += new System.EventHandler(this.BtnSetClick);
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
            this.BtnMini.Location = new System.Drawing.Point(372, 0);
            this.BtnMini.Name = "BtnMini";
            this.BtnMini.NormalImage = global::WeLink.Properties.Resources.sysbtn_min_normal;
            this.BtnMini.PressedImage = global::WeLink.Properties.Resources.sysbtn_min_down;
            this.BtnMini.Radius = 10;
            this.BtnMini.ShowBorder = true;
            this.BtnMini.Size = new System.Drawing.Size(30, 27);
            this.BtnMini.TabIndex = 7;
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
            this.BtnClose.Location = new System.Drawing.Point(402, 0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.NormalImage = global::WeLink.Properties.Resources.sysbtn_close_normal;
            this.BtnClose.PressedImage = global::WeLink.Properties.Resources.sysbtn_close_down;
            this.BtnClose.Radius = 10;
            this.BtnClose.ShowBorder = true;
            this.BtnClose.Size = new System.Drawing.Size(30, 27);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.BtnClose.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.BtnClose.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.BtnClose.Click += new System.EventHandler(this.BtnCloseClick);
            // 
            // layeredPanel1
            // 
            this.layeredPanel1.BackgroundImage = global::WeLink.Properties.Resources.背景1;
            this.layeredPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.layeredPanel1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPanel1.Borders.BottomWidth = 1;
            this.layeredPanel1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPanel1.Borders.LeftWidth = 1;
            this.layeredPanel1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPanel1.Borders.RightWidth = 1;
            this.layeredPanel1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPanel1.Borders.TopWidth = 1;
            this.layeredPanel1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel1.Canvas")));
            this.layeredPanel1.Controls.Add(this.btnHelp);
            this.layeredPanel1.Controls.Add(this.skinPictureBox1);
            this.layeredPanel1.Controls.Add(this.BtnSet);
            this.layeredPanel1.Controls.Add(this.BtnMini);
            this.layeredPanel1.Controls.Add(this.BtnClose);
            this.layeredPanel1.Controls.Add(this.HeadImg);
            this.layeredPanel1.Location = new System.Drawing.Point(5, 5);
            this.layeredPanel1.Name = "layeredPanel1";
            this.layeredPanel1.Size = new System.Drawing.Size(432, 177);
            this.layeredPanel1.TabIndex = 28;
            this.layeredPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveFormMouseDown);
            // 
            // btnHelp
            // 
            this.btnHelp.BackgroundImage = global::WeLink.Properties.Resources.help1;
            this.btnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Location = new System.Drawing.Point(315, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(23, 18);
            this.btnHelp.TabIndex = 35;
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.BackgroundImage = global::WeLink.Properties.Resources.logo;
            this.skinPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.skinPictureBox1.Location = new System.Drawing.Point(6, 6);
            this.skinPictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(68, 21);
            this.skinPictureBox1.TabIndex = 34;
            this.skinPictureBox1.TabStop = false;
            // 
            // layeredPanel3
            // 
            this.layeredPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.layeredPanel3.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredPanel3.Borders.BottomWidth = 1;
            this.layeredPanel3.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredPanel3.Borders.LeftWidth = 1;
            this.layeredPanel3.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredPanel3.Borders.RightWidth = 1;
            this.layeredPanel3.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredPanel3.Borders.TopWidth = 1;
            this.layeredPanel3.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredPanel3.Canvas")));
            this.layeredPanel3.Controls.Add(this.duiChkRemPW);
            this.layeredPanel3.Controls.Add(this.duiChkAutoLogin);
            this.layeredPanel3.Controls.Add(this.btnShowUserList);
            this.layeredPanel3.Controls.Add(this.textPW);
            this.layeredPanel3.Controls.Add(this.textCardID);
            this.layeredPanel3.Controls.Add(this.btnRegister);
            this.layeredPanel3.Controls.Add(this.btnFindBackPW);
            this.layeredPanel3.Location = new System.Drawing.Point(86, 188);
            this.layeredPanel3.Name = "layeredPanel3";
            this.layeredPanel3.Size = new System.Drawing.Size(272, 90);
            this.layeredPanel3.TabIndex = 32;
            // 
            // duiChkRemPW
            // 
            this.duiChkRemPW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.duiChkRemPW.Borders.BottomColor = System.Drawing.Color.Empty;
            this.duiChkRemPW.Borders.BottomWidth = 1;
            this.duiChkRemPW.Borders.LeftColor = System.Drawing.Color.Empty;
            this.duiChkRemPW.Borders.LeftWidth = 1;
            this.duiChkRemPW.Borders.RightColor = System.Drawing.Color.Empty;
            this.duiChkRemPW.Borders.RightWidth = 1;
            this.duiChkRemPW.Borders.TopColor = System.Drawing.Color.Empty;
            this.duiChkRemPW.Borders.TopWidth = 1;
            this.duiChkRemPW.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("duiChkRemPW.Canvas")));
            duiCheckBox3.AutoCheck = true;
            duiCheckBox3.AutoSize = true;
            duiCheckBox3.BackColor = System.Drawing.Color.Empty;
            duiCheckBox3.BackgroundImage = null;
            duiCheckBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiCheckBox3.BackgroundRender = null;
            duiCheckBox3.BitmapCache = false;
            duiCheckBox3.BorderPath = null;
            duiCheckBox3.BorderRender = null;
            duiCheckBox3.Borders.BottomColor = System.Drawing.Color.Empty;
            duiCheckBox3.Borders.BottomWidth = 1;
            duiCheckBox3.Borders.LeftColor = System.Drawing.Color.Empty;
            duiCheckBox3.Borders.LeftWidth = 1;
            duiCheckBox3.Borders.RightColor = System.Drawing.Color.Empty;
            duiCheckBox3.Borders.RightWidth = 1;
            duiCheckBox3.Borders.TopColor = System.Drawing.Color.Empty;
            duiCheckBox3.Borders.TopWidth = 1;
            duiCheckBox3.CanFocus = true;
            duiCheckBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            duiCheckBox3.Checked = false;
            duiCheckBox3.CheckedHover = ((System.Drawing.Image)(resources.GetObject("duiCheckBox3.CheckedHover")));
            duiCheckBox3.CheckedNormal = ((System.Drawing.Image)(resources.GetObject("duiCheckBox3.CheckedNormal")));
            duiCheckBox3.CheckedPressed = ((System.Drawing.Image)(resources.GetObject("duiCheckBox3.CheckedPressed")));
            duiCheckBox3.CheckFlagColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(151)))), ((int)(((byte)(2)))));
            duiCheckBox3.CheckFlagColorDisabled = System.Drawing.Color.Gray;
            duiCheckBox3.CheckRectBackColorDisabled = System.Drawing.Color.Silver;
            duiCheckBox3.CheckRectBackColorHighLight = System.Drawing.Color.White;
            duiCheckBox3.CheckRectBackColorNormal = System.Drawing.Color.White;
            duiCheckBox3.CheckRectBackColorPressed = System.Drawing.Color.White;
            duiCheckBox3.CheckRectColor = System.Drawing.Color.DodgerBlue;
            duiCheckBox3.CheckRectColorDisabled = System.Drawing.Color.Gray;
            duiCheckBox3.CheckRectWidth = 17;
            duiCheckBox3.CheckState = System.Windows.Forms.CheckState.Unchecked;
            duiCheckBox3.ClientRectangle = new System.Drawing.Rectangle(0, 0, 75, 21);
            duiCheckBox3.ControlState = LayeredSkin.DirectUI.ControlStates.Normal;
            duiCheckBox3.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiCheckBox3.Cursor = System.Windows.Forms.Cursors.Default;
            duiCheckBox3.Dock = System.Windows.Forms.DockStyle.None;
            duiCheckBox3.Enabled = true;
            duiCheckBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiCheckBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
            duiCheckBox3.Height = 21;
            duiCheckBox3.InnerPaddingWidth = 2;
            duiCheckBox3.InnerRectInflate = 3;
            duiCheckBox3.IsMoveParentPaint = true;
            duiCheckBox3.Left = 0;
            duiCheckBox3.Location = new System.Drawing.Point(0, 0);
            duiCheckBox3.Margin = new System.Windows.Forms.Padding(0);
            duiCheckBox3.Name = null;
            duiCheckBox3.ParentInvalidate = true;
            duiCheckBox3.ShowBorder = true;
            duiCheckBox3.Size = new System.Drawing.Size(75, 21);
            duiCheckBox3.SpaceBetweenCheckMarkAndText = 0;
            duiCheckBox3.SuspendInvalidate = false;
            duiCheckBox3.Tag = null;
            duiCheckBox3.Text = "记住密码";
            duiCheckBox3.TextColorDisabled = System.Drawing.Color.Gray;
            duiCheckBox3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            duiCheckBox3.ThreeState = false;
            duiCheckBox3.Top = 0;
            duiCheckBox3.UncheckedHover = global::WeLink.Properties.Resources.chkZdLogin_MouseBack;
            duiCheckBox3.UncheckedNormal = global::WeLink.Properties.Resources.chkZdLogin_NormlBack;
            duiCheckBox3.UncheckedPressed = global::WeLink.Properties.Resources.chkZdLogin_DownBack;
            duiCheckBox3.Visible = true;
            duiCheckBox3.Width = 75;
            this.duiChkRemPW.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiCheckBox3});
            this.duiChkRemPW.Location = new System.Drawing.Point(121, 65);
            this.duiChkRemPW.Name = "duiChkRemPW";
            this.duiChkRemPW.Size = new System.Drawing.Size(81, 21);
            this.duiChkRemPW.TabIndex = 32;
            this.duiChkRemPW.Text = "layeredBaseControl1";
            // 
            // duiChkAutoLogin
            // 
            this.duiChkAutoLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.duiChkAutoLogin.Borders.BottomColor = System.Drawing.Color.Empty;
            this.duiChkAutoLogin.Borders.BottomWidth = 1;
            this.duiChkAutoLogin.Borders.LeftColor = System.Drawing.Color.Empty;
            this.duiChkAutoLogin.Borders.LeftWidth = 1;
            this.duiChkAutoLogin.Borders.RightColor = System.Drawing.Color.Empty;
            this.duiChkAutoLogin.Borders.RightWidth = 1;
            this.duiChkAutoLogin.Borders.TopColor = System.Drawing.Color.Empty;
            this.duiChkAutoLogin.Borders.TopWidth = 1;
            this.duiChkAutoLogin.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("duiChkAutoLogin.Canvas")));
            duiCheckBox4.AutoCheck = true;
            duiCheckBox4.AutoSize = true;
            duiCheckBox4.BackColor = System.Drawing.Color.Empty;
            duiCheckBox4.BackgroundImage = null;
            duiCheckBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            duiCheckBox4.BackgroundRender = null;
            duiCheckBox4.BitmapCache = false;
            duiCheckBox4.BorderPath = null;
            duiCheckBox4.BorderRender = null;
            duiCheckBox4.Borders.BottomColor = System.Drawing.Color.Empty;
            duiCheckBox4.Borders.BottomWidth = 1;
            duiCheckBox4.Borders.LeftColor = System.Drawing.Color.Empty;
            duiCheckBox4.Borders.LeftWidth = 1;
            duiCheckBox4.Borders.RightColor = System.Drawing.Color.Empty;
            duiCheckBox4.Borders.RightWidth = 1;
            duiCheckBox4.Borders.TopColor = System.Drawing.Color.Empty;
            duiCheckBox4.Borders.TopWidth = 1;
            duiCheckBox4.CanFocus = true;
            duiCheckBox4.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft;
            duiCheckBox4.Checked = false;
            duiCheckBox4.CheckedHover = ((System.Drawing.Image)(resources.GetObject("duiCheckBox4.CheckedHover")));
            duiCheckBox4.CheckedNormal = ((System.Drawing.Image)(resources.GetObject("duiCheckBox4.CheckedNormal")));
            duiCheckBox4.CheckedPressed = ((System.Drawing.Image)(resources.GetObject("duiCheckBox4.CheckedPressed")));
            duiCheckBox4.CheckFlagColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(151)))), ((int)(((byte)(2)))));
            duiCheckBox4.CheckFlagColorDisabled = System.Drawing.Color.Gray;
            duiCheckBox4.CheckRectBackColorDisabled = System.Drawing.Color.Silver;
            duiCheckBox4.CheckRectBackColorHighLight = System.Drawing.Color.White;
            duiCheckBox4.CheckRectBackColorNormal = System.Drawing.Color.White;
            duiCheckBox4.CheckRectBackColorPressed = System.Drawing.Color.White;
            duiCheckBox4.CheckRectColor = System.Drawing.Color.DodgerBlue;
            duiCheckBox4.CheckRectColorDisabled = System.Drawing.Color.Gray;
            duiCheckBox4.CheckRectWidth = 17;
            duiCheckBox4.CheckState = System.Windows.Forms.CheckState.Unchecked;
            duiCheckBox4.ClientRectangle = new System.Drawing.Rectangle(0, 0, 75, 21);
            duiCheckBox4.ControlState = LayeredSkin.DirectUI.ControlStates.Normal;
            duiCheckBox4.CurrentCursor = System.Windows.Forms.Cursors.Default;
            duiCheckBox4.Cursor = System.Windows.Forms.Cursors.Default;
            duiCheckBox4.Dock = System.Windows.Forms.DockStyle.None;
            duiCheckBox4.Enabled = true;
            duiCheckBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            duiCheckBox4.ForeColor = System.Drawing.SystemColors.HotTrack;
            duiCheckBox4.Height = 21;
            duiCheckBox4.InnerPaddingWidth = 2;
            duiCheckBox4.InnerRectInflate = 3;
            duiCheckBox4.IsMoveParentPaint = true;
            duiCheckBox4.Left = 0;
            duiCheckBox4.Location = new System.Drawing.Point(0, 0);
            duiCheckBox4.Margin = new System.Windows.Forms.Padding(0);
            duiCheckBox4.Name = null;
            duiCheckBox4.ParentInvalidate = true;
            duiCheckBox4.ShowBorder = true;
            duiCheckBox4.Size = new System.Drawing.Size(75, 21);
            duiCheckBox4.SpaceBetweenCheckMarkAndText = 0;
            duiCheckBox4.SuspendInvalidate = false;
            duiCheckBox4.Tag = null;
            duiCheckBox4.Text = "自动登录";
            duiCheckBox4.TextColorDisabled = System.Drawing.Color.Gray;
            duiCheckBox4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            duiCheckBox4.ThreeState = false;
            duiCheckBox4.Top = 0;
            duiCheckBox4.UncheckedHover = global::WeLink.Properties.Resources.chkZdLogin_MouseBack;
            duiCheckBox4.UncheckedNormal = global::WeLink.Properties.Resources.chkZdLogin_NormlBack;
            duiCheckBox4.UncheckedPressed = global::WeLink.Properties.Resources.chkZdLogin_DownBack;
            duiCheckBox4.Visible = true;
            duiCheckBox4.Width = 75;
            this.duiChkAutoLogin.DUIControls.AddRange(new LayeredSkin.DirectUI.DuiBaseControl[] {
            duiCheckBox4});
            this.duiChkAutoLogin.Location = new System.Drawing.Point(8, 65);
            this.duiChkAutoLogin.Name = "duiChkAutoLogin";
            this.duiChkAutoLogin.Size = new System.Drawing.Size(73, 21);
            this.duiChkAutoLogin.TabIndex = 33;
            this.duiChkAutoLogin.Text = "layeredBaseControl1";
            // 
            // btnShowUserList
            // 
            this.btnShowUserList.AdaptImage = true;
            this.btnShowUserList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnShowUserList.BaseColor = System.Drawing.Color.Wheat;
            this.btnShowUserList.Borders.BottomColor = System.Drawing.Color.Empty;
            this.btnShowUserList.Borders.BottomWidth = 1;
            this.btnShowUserList.Borders.LeftColor = System.Drawing.Color.Empty;
            this.btnShowUserList.Borders.LeftWidth = 1;
            this.btnShowUserList.Borders.RightColor = System.Drawing.Color.Empty;
            this.btnShowUserList.Borders.RightWidth = 1;
            this.btnShowUserList.Borders.TopColor = System.Drawing.Color.Empty;
            this.btnShowUserList.Borders.TopWidth = 1;
            this.btnShowUserList.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("btnShowUserList.Canvas")));
            this.btnShowUserList.ControlState = LayeredSkin.Controls.ControlStates.Normal;
            this.btnShowUserList.HaloColor = System.Drawing.Color.White;
            this.btnShowUserList.HaloSize = 5;
            this.btnShowUserList.HoverImage = global::WeLink.Properties.Resources.btnId_MouseBack;
            this.btnShowUserList.IsPureColor = false;
            this.btnShowUserList.Location = new System.Drawing.Point(179, 3);
            this.btnShowUserList.Name = "btnShowUserList";
            this.btnShowUserList.NormalImage = global::WeLink.Properties.Resources.btnId_NormlBack;
            this.btnShowUserList.PressedImage = global::WeLink.Properties.Resources.btnId_DownBack;
            this.btnShowUserList.Radius = 10;
            this.btnShowUserList.ShowBorder = true;
            this.btnShowUserList.Size = new System.Drawing.Size(22, 24);
            this.btnShowUserList.TabIndex = 31;
            this.btnShowUserList.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.btnShowUserList.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.btnShowUserList.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.btnShowUserList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserListShowDown);
            // 
            // btnLoginByFace
            // 
            this.btnLoginByFace.BackColor = System.Drawing.Color.Transparent;
            this.btnLoginByFace.BackgroundImage = global::WeLink.Properties.Resources.人脸识别;
            this.btnLoginByFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoginByFace.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnLoginByFace.FlatAppearance.BorderSize = 0;
            this.btnLoginByFace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginByFace.Location = new System.Drawing.Point(198, 337);
            this.btnLoginByFace.Name = "btnLoginByFace";
            this.btnLoginByFace.Size = new System.Drawing.Size(40, 40);
            this.btnLoginByFace.TabIndex = 33;
            this.btnLoginByFace.UseVisualStyleBackColor = false;
            this.btnLoginByFace.Click += new System.EventHandler(this.btnLoginByFace_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = global::WeLink.Properties.Resources.人脸识别;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnLogin.DownBack = null;
            this.btnLogin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.Location = new System.Drawing.Point(112, 289);
            this.btnLogin.MouseBack = null;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NormlBack = null;
            this.btnLogin.Size = new System.Drawing.Size(212, 35);
            this.btnLogin.TabIndex = 34;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnLoginByEmail
            // 
            this.btnLoginByEmail.BackColor = System.Drawing.Color.Transparent;
            this.btnLoginByEmail.BackgroundImage = global::WeLink.Properties.Resources.邮箱;
            this.btnLoginByEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoginByEmail.FlatAppearance.BorderSize = 0;
            this.btnLoginByEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginByEmail.Location = new System.Drawing.Point(265, 337);
            this.btnLoginByEmail.Name = "btnLoginByEmail";
            this.btnLoginByEmail.Size = new System.Drawing.Size(40, 40);
            this.btnLoginByEmail.TabIndex = 33;
            this.btnLoginByEmail.UseVisualStyleBackColor = false;
            this.btnLoginByEmail.Click += new System.EventHandler(this.btnLoginByEmail_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.skinLabel1.Location = new System.Drawing.Point(65, 337);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(110, 21);
            this.skinLabel1.TabIndex = 35;
            this.skinLabel1.Text = "其他登录方式:";
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.ForeColor = System.Drawing.Color.Firebrick;
            this.skinLine1.LineColor = System.Drawing.Color.DodgerBlue;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(64, 330);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(327, 10);
            this.skinLine1.TabIndex = 36;
            this.skinLine1.Text = "skinLine1";
            // 
            // pallet
            // 
            this.pallet.BalloonTipTitle = "";
            this.pallet.ContextMenuStrip = this.contextMenuStrip1;
            this.pallet.Icon = ((System.Drawing.Icon)(resources.GetObject("pallet.Icon")));
            this.pallet.Text = "WeLink";
            this.pallet.Visible = true;
            this.pallet.Click += new System.EventHandler(this.pallet_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conItemConnect,
            this.toolStripSeparator2,
            this.conItemOpenMain,
            this.toolStripSeparator3,
            this.conItemChangeID,
            this.conItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 104);
            // 
            // conItemConnect
            // 
            this.conItemConnect.Name = "conItemConnect";
            this.conItemConnect.Size = new System.Drawing.Size(136, 22);
            this.conItemConnect.Text = "连接到网络";
            this.conItemConnect.Click += new System.EventHandler(this.conItemConnect_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // conItemOpenMain
            // 
            this.conItemOpenMain.Name = "conItemOpenMain";
            this.conItemOpenMain.Size = new System.Drawing.Size(136, 22);
            this.conItemOpenMain.Text = "打开主面板";
            this.conItemOpenMain.Click += new System.EventHandler(this.conItemOpenMain_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // conItemChangeID
            // 
            this.conItemChangeID.Enabled = false;
            this.conItemChangeID.Name = "conItemChangeID";
            this.conItemChangeID.Size = new System.Drawing.Size(136, 22);
            this.conItemChangeID.Text = "切换账号";
            this.conItemChangeID.Click += new System.EventHandler(this.conItemChangeID_Click);
            // 
            // conItemExit
            // 
            this.conItemExit.Name = "conItemExit";
            this.conItemExit.Size = new System.Drawing.Size(136, 22);
            this.conItemExit.Text = "退出";
            this.conItemExit.Click += new System.EventHandler(this.conItemExit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCancelLogin
            // 
            this.btnCancelLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancelLogin.DownBack = null;
            this.btnCancelLogin.Location = new System.Drawing.Point(332, 301);
            this.btnCancelLogin.MouseBack = null;
            this.btnCancelLogin.Name = "btnCancelLogin";
            this.btnCancelLogin.NormlBack = null;
            this.btnCancelLogin.Size = new System.Drawing.Size(75, 23);
            this.btnCancelLogin.TabIndex = 37;
            this.btnCancelLogin.Text = "停止登录";
            this.btnCancelLogin.UseVisualStyleBackColor = false;
            this.btnCancelLogin.Visible = false;
            this.btnCancelLogin.Click += new System.EventHandler(this.btnCancelLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(441, 389);
            this.Controls.Add(this.btnCancelLogin);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnLoginByEmail);
            this.Controls.Add(this.btnLoginByFace);
            this.Controls.Add(this.layeredPanel1);
            this.Controls.Add(this.layeredPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.layeredPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.layeredPanel3.ResumeLayout(false);
            this.layeredPanel3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LayeredSkin.Controls.LayeredTextBox textPW;
        private LayeredSkin.Controls.LayeredTextBox textCardID;
        private LayeredSkin.Controls.LayeredButton btnRegister;
        private LayeredSkin.Controls.LayeredButton btnFindBackPW;
        private LayeredSkin.Controls.LayeredBaseControl HeadImg;
        private LayeredSkin.Controls.LayeredButton BtnSet;
        private LayeredSkin.Controls.LayeredButton BtnMini;
        private LayeredSkin.Controls.LayeredButton BtnClose;
        private LayeredSkin.Controls.LayeredPanel layeredPanel1;
        private LayeredSkin.Controls.LayeredPanel layeredPanel3;
        private LayeredSkin.Controls.LayeredButton btnShowUserList;
        private LayeredSkin.Controls.LayeredBaseControl duiChkRemPW;
        private LayeredSkin.Controls.LayeredBaseControl duiChkAutoLogin;
        private System.Windows.Forms.Button btnLoginByFace;
        private CCWin.SkinControl.SkinButton btnLogin;
        private System.Windows.Forms.Button btnLoginByEmail;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLine skinLine1;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        public System.Windows.Forms.NotifyIcon pallet;
        public System.Windows.Forms.Timer timer1;
        private CCWin.SkinControl.SkinButton btnCancelLogin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem conItemConnect;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem conItemOpenMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem conItemChangeID;
        private System.Windows.Forms.ToolStripMenuItem conItemExit;
        private System.Windows.Forms.Button btnHelp;
    }
}

