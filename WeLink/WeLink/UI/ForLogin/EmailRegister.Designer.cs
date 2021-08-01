namespace WeLink.UI
{
    partial class EmailRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailRegister));
            this.textEmail = new LayeredSkin.Controls.LayeredTextBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.textCheckCode = new LayeredSkin.Controls.LayeredTextBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.btnSendCheckCode = new CCWin.SkinControl.SkinButton();
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.btnBack = new CCWin.SkinControl.SkinButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.SuspendLayout();
            // 
            // textEmail
            // 
            this.textEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textEmail.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textEmail.Borders.BottomWidth = 3;
            this.textEmail.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textEmail.Borders.LeftWidth = 1;
            this.textEmail.Borders.RightColor = System.Drawing.Color.Empty;
            this.textEmail.Borders.RightWidth = 1;
            this.textEmail.Borders.TopColor = System.Drawing.Color.Empty;
            this.textEmail.Borders.TopWidth = 1;
            this.textEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textEmail.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textEmail.Canvas")));
            this.textEmail.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEmail.Location = new System.Drawing.Point(84, 39);
            this.textEmail.Multiline = true;
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(184, 30);
            this.textEmail.TabIndex = 29;
            this.textEmail.TransparencyKey = System.Drawing.Color.White;
            this.textEmail.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textEmail.WaterText = "xxxxxxxxxx@qq.com";
            this.textEmail.WaterTextOffset = new System.Drawing.Point(3, 5);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(32, 50);
            this.skinLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(47, 19);
            this.skinLabel1.TabIndex = 30;
            this.skinLabel1.Text = "邮箱";
            // 
            // textCheckCode
            // 
            this.textCheckCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textCheckCode.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textCheckCode.Borders.BottomWidth = 3;
            this.textCheckCode.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textCheckCode.Borders.LeftWidth = 1;
            this.textCheckCode.Borders.RightColor = System.Drawing.Color.Empty;
            this.textCheckCode.Borders.RightWidth = 1;
            this.textCheckCode.Borders.TopColor = System.Drawing.Color.Empty;
            this.textCheckCode.Borders.TopWidth = 1;
            this.textCheckCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textCheckCode.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textCheckCode.Canvas")));
            this.textCheckCode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textCheckCode.Location = new System.Drawing.Point(84, 96);
            this.textCheckCode.Multiline = true;
            this.textCheckCode.Name = "textCheckCode";
            this.textCheckCode.Size = new System.Drawing.Size(90, 30);
            this.textCheckCode.TabIndex = 29;
            this.textCheckCode.TransparencyKey = System.Drawing.Color.White;
            this.textCheckCode.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textCheckCode.WaterText = "5位验证码";
            this.textCheckCode.WaterTextOffset = new System.Drawing.Point(3, 5);
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(13, 107);
            this.skinLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(66, 19);
            this.skinLabel2.TabIndex = 30;
            this.skinLabel2.Text = "验证码";
            // 
            // btnSendCheckCode
            // 
            this.btnSendCheckCode.BackColor = System.Drawing.Color.Transparent;
            this.btnSendCheckCode.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSendCheckCode.DownBack = null;
            this.btnSendCheckCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendCheckCode.Location = new System.Drawing.Point(180, 96);
            this.btnSendCheckCode.MouseBack = null;
            this.btnSendCheckCode.Name = "btnSendCheckCode";
            this.btnSendCheckCode.NormlBack = null;
            this.btnSendCheckCode.Size = new System.Drawing.Size(88, 30);
            this.btnSendCheckCode.TabIndex = 33;
            this.btnSendCheckCode.Text = "发送验证码";
            this.btnSendCheckCode.UseVisualStyleBackColor = false;
            this.btnSendCheckCode.Click += new System.EventHandler(this.btnSendCheckCode_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DownBack = null;
            this.btnOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(36, 146);
            this.btnOK.MouseBack = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Size = new System.Drawing.Size(99, 29);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnBack.DownBack = null;
            this.btnBack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBack.Location = new System.Drawing.Point(160, 146);
            this.btnBack.MouseBack = null;
            this.btnBack.Name = "btnBack";
            this.btnBack.NormlBack = null;
            this.btnBack.Size = new System.Drawing.Size(99, 29);
            this.btnBack.TabIndex = 33;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 60;
            this.label1.Text = "邮箱验证";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.White;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(1, 30);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(288, 12);
            this.skinLine1.TabIndex = 61;
            this.skinLine1.Text = "skinLine1";
            // 
            // EmailRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeLink.Properties.Resources.纯色紫背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(292, 192);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSendCheckCode);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.textCheckCode);
            this.Controls.Add(this.textEmail);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmailRegister";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LayeredSkin.Controls.LayeredTextBox textEmail;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private LayeredSkin.Controls.LayeredTextBox textCheckCode;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinButton btnSendCheckCode;
        private CCWin.SkinControl.SkinButton btnOK;
        private CCWin.SkinControl.SkinButton btnBack;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinLine skinLine1;
    }
}