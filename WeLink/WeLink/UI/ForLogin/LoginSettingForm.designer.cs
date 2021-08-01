namespace WeLink.UI
{
    partial class LoginSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginSettingForm));
            this.BtnMini = new LayeredSkin.Controls.LayeredButton();
            this.BtnClose = new LayeredSkin.Controls.LayeredButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.textPort1 = new LayeredSkin.Controls.LayeredTextBox();
            this.textIP = new LayeredSkin.Controls.LayeredTextBox();
            this.textPort2 = new LayeredSkin.Controls.LayeredTextBox();
            this.btnSet = new CCWin.SkinControl.SkinButton();
            this.BtnCancel = new CCWin.SkinControl.SkinButton();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.label1 = new System.Windows.Forms.Label();
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
            this.BtnMini.Location = new System.Drawing.Point(247, 5);
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
            this.BtnClose.Location = new System.Drawing.Point(277, 5);
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
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(42, 112);
            this.skinLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(66, 19);
            this.skinLabel1.TabIndex = 29;
            this.skinLabel1.Text = "主端口";
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(42, 157);
            this.skinLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(66, 19);
            this.skinLabel2.TabIndex = 29;
            this.skinLabel2.Text = "辅端口";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(31, 63);
            this.skinLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(77, 19);
            this.skinLabel3.TabIndex = 29;
            this.skinLabel3.Text = "IP地址";
            // 
            // textPort1
            // 
            this.textPort1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textPort1.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textPort1.Borders.BottomWidth = 3;
            this.textPort1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textPort1.Borders.LeftWidth = 1;
            this.textPort1.Borders.RightColor = System.Drawing.Color.Empty;
            this.textPort1.Borders.RightWidth = 1;
            this.textPort1.Borders.TopColor = System.Drawing.Color.Empty;
            this.textPort1.Borders.TopWidth = 1;
            this.textPort1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPort1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textPort1.Canvas")));
            this.textPort1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPort1.Location = new System.Drawing.Point(113, 101);
            this.textPort1.Multiline = true;
            this.textPort1.Name = "textPort1";
            this.textPort1.Size = new System.Drawing.Size(143, 30);
            this.textPort1.TabIndex = 28;
            this.textPort1.TransparencyKey = System.Drawing.Color.White;
            this.textPort1.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPort1.WaterText = "xxxxx";
            this.textPort1.WaterTextOffset = new System.Drawing.Point(3, 5);
            // 
            // textIP
            // 
            this.textIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textIP.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textIP.Borders.BottomWidth = 3;
            this.textIP.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textIP.Borders.LeftWidth = 1;
            this.textIP.Borders.RightColor = System.Drawing.Color.Empty;
            this.textIP.Borders.RightWidth = 1;
            this.textIP.Borders.TopColor = System.Drawing.Color.Empty;
            this.textIP.Borders.TopWidth = 1;
            this.textIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textIP.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textIP.Canvas")));
            this.textIP.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textIP.Location = new System.Drawing.Point(113, 51);
            this.textIP.Multiline = true;
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(143, 30);
            this.textIP.TabIndex = 28;
            this.textIP.TransparencyKey = System.Drawing.Color.White;
            this.textIP.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textIP.WaterText = "xxx.xxx.xxx.xxx";
            this.textIP.WaterTextOffset = new System.Drawing.Point(3, 5);
            // 
            // textPort2
            // 
            this.textPort2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textPort2.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textPort2.Borders.BottomWidth = 3;
            this.textPort2.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textPort2.Borders.LeftWidth = 1;
            this.textPort2.Borders.RightColor = System.Drawing.Color.Empty;
            this.textPort2.Borders.RightWidth = 1;
            this.textPort2.Borders.TopColor = System.Drawing.Color.Empty;
            this.textPort2.Borders.TopWidth = 1;
            this.textPort2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPort2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textPort2.Canvas")));
            this.textPort2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPort2.Location = new System.Drawing.Point(113, 146);
            this.textPort2.Multiline = true;
            this.textPort2.Name = "textPort2";
            this.textPort2.Size = new System.Drawing.Size(143, 30);
            this.textPort2.TabIndex = 28;
            this.textPort2.TransparencyKey = System.Drawing.Color.White;
            this.textPort2.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPort2.WaterText = "xxxxx";
            this.textPort2.WaterTextOffset = new System.Drawing.Point(3, 5);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.Transparent;
            this.btnSet.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSet.DownBack = null;
            this.btnSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.Location = new System.Drawing.Point(76, 198);
            this.btnSet.MouseBack = null;
            this.btnSet.Name = "btnSet";
            this.btnSet.NormlBack = null;
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 32;
            this.btnSet.Text = "应用";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.Transparent;
            this.BtnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.BtnCancel.DownBack = null;
            this.BtnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCancel.Location = new System.Drawing.Point(181, 198);
            this.BtnCancel.MouseBack = null;
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.NormlBack = null;
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 32;
            this.BtnCancel.Text = "返回";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.White;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(2, 35);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(376, 10);
            this.skinLine1.TabIndex = 63;
            this.skinLine1.Text = "skinLine1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 62;
            this.label1.Text = "端口设置";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoginSettingForm
            // 
            this.AnimationType = LayeredSkin.Forms.AnimationTypes.ThreeDTurn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::WeLink.Properties.Resources.纯色紫背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(310, 236);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.textPort2);
            this.Controls.Add(this.textPort1);
            this.Controls.Add(this.textIP);
            this.Controls.Add(this.BtnMini);
            this.Controls.Add(this.BtnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginSettingForm";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LayeredSkin.Controls.LayeredButton BtnMini;
        private LayeredSkin.Controls.LayeredButton BtnClose;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private LayeredSkin.Controls.LayeredTextBox textPort1;
        private LayeredSkin.Controls.LayeredTextBox textIP;
        private LayeredSkin.Controls.LayeredTextBox textPort2;
        private CCWin.SkinControl.SkinButton btnSet;
        private CCWin.SkinControl.SkinButton BtnCancel;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label label1;
    }
}