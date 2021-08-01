namespace WeLink.UI
{
    partial class GetBackPW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetBackPW));
            this.btnBack = new CCWin.SkinControl.SkinButton();
            this.btnCheckEmail = new CCWin.SkinControl.SkinButton();
            this.btnCheckFace = new CCWin.SkinControl.SkinButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.textCardID = new LayeredSkin.Controls.LayeredTextBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.textNewPW = new LayeredSkin.Controls.LayeredTextBox();
            this.textNewPW2 = new LayeredSkin.Controls.LayeredTextBox();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnBack.DownBack = null;
            this.btnBack.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnBack.Location = new System.Drawing.Point(158, 228);
            this.btnBack.MouseBack = null;
            this.btnBack.Name = "btnBack";
            this.btnBack.NormlBack = null;
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 45;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCheckEmail
            // 
            this.btnCheckEmail.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckEmail.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCheckEmail.DownBack = null;
            this.btnCheckEmail.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckEmail.Location = new System.Drawing.Point(17, 48);
            this.btnCheckEmail.MouseBack = null;
            this.btnCheckEmail.Name = "btnCheckEmail";
            this.btnCheckEmail.NormlBack = null;
            this.btnCheckEmail.Size = new System.Drawing.Size(97, 23);
            this.btnCheckEmail.TabIndex = 46;
            this.btnCheckEmail.Text = "邮箱验证";
            this.btnCheckEmail.UseVisualStyleBackColor = false;
            this.btnCheckEmail.Click += new System.EventHandler(this.btnCheckEmail_Click);
            // 
            // btnCheckFace
            // 
            this.btnCheckFace.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckFace.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCheckFace.DownBack = null;
            this.btnCheckFace.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCheckFace.Location = new System.Drawing.Point(158, 48);
            this.btnCheckFace.MouseBack = null;
            this.btnCheckFace.Name = "btnCheckFace";
            this.btnCheckFace.NormlBack = null;
            this.btnCheckFace.Size = new System.Drawing.Size(97, 23);
            this.btnCheckFace.TabIndex = 46;
            this.btnCheckFace.Text = "人脸识别";
            this.btnCheckFace.UseVisualStyleBackColor = false;
            this.btnCheckFace.Click += new System.EventHandler(this.btnCheckFace_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(45, 99);
            this.skinLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(47, 19);
            this.skinLabel1.TabIndex = 49;
            this.skinLabel1.Text = "账号";
            // 
            // textCardID
            // 
            this.textCardID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textCardID.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textCardID.Borders.BottomWidth = 3;
            this.textCardID.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textCardID.Borders.LeftWidth = 1;
            this.textCardID.Borders.RightColor = System.Drawing.Color.Empty;
            this.textCardID.Borders.RightWidth = 1;
            this.textCardID.Borders.TopColor = System.Drawing.Color.Empty;
            this.textCardID.Borders.TopWidth = 1;
            this.textCardID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textCardID.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textCardID.Canvas")));
            this.textCardID.Enabled = false;
            this.textCardID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textCardID.Location = new System.Drawing.Point(103, 88);
            this.textCardID.Multiline = true;
            this.textCardID.Name = "textCardID";
            this.textCardID.Size = new System.Drawing.Size(152, 30);
            this.textCardID.TabIndex = 48;
            this.textCardID.Text = "未识别......(不可输入)";
            this.textCardID.TransparencyKey = System.Drawing.Color.White;
            this.textCardID.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textCardID.WaterText = "";
            this.textCardID.WaterTextOffset = new System.Drawing.Point(3, 5);
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(32, 145);
            this.skinLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(66, 19);
            this.skinLabel2.TabIndex = 51;
            this.skinLabel2.Text = "新密码";
            // 
            // textNewPW
            // 
            this.textNewPW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textNewPW.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textNewPW.Borders.BottomWidth = 3;
            this.textNewPW.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textNewPW.Borders.LeftWidth = 1;
            this.textNewPW.Borders.RightColor = System.Drawing.Color.Empty;
            this.textNewPW.Borders.RightWidth = 1;
            this.textNewPW.Borders.TopColor = System.Drawing.Color.Empty;
            this.textNewPW.Borders.TopWidth = 1;
            this.textNewPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textNewPW.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textNewPW.Canvas")));
            this.textNewPW.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textNewPW.Location = new System.Drawing.Point(103, 134);
            this.textNewPW.Multiline = true;
            this.textNewPW.Name = "textNewPW";
            this.textNewPW.PasswordChar = '●';
            this.textNewPW.Size = new System.Drawing.Size(152, 30);
            this.textNewPW.TabIndex = 50;
            this.textNewPW.TransparencyKey = System.Drawing.Color.White;
            this.textNewPW.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textNewPW.WaterText = "(6-20位数字或字母)";
            this.textNewPW.WaterTextOffset = new System.Drawing.Point(3, 5);
            // 
            // textNewPW2
            // 
            this.textNewPW2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.textNewPW2.Borders.BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.textNewPW2.Borders.BottomWidth = 3;
            this.textNewPW2.Borders.LeftColor = System.Drawing.Color.Empty;
            this.textNewPW2.Borders.LeftWidth = 1;
            this.textNewPW2.Borders.RightColor = System.Drawing.Color.Empty;
            this.textNewPW2.Borders.RightWidth = 1;
            this.textNewPW2.Borders.TopColor = System.Drawing.Color.Empty;
            this.textNewPW2.Borders.TopWidth = 1;
            this.textNewPW2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textNewPW2.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("textNewPW2.Canvas")));
            this.textNewPW2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textNewPW2.Location = new System.Drawing.Point(103, 180);
            this.textNewPW2.Multiline = true;
            this.textNewPW2.Name = "textNewPW2";
            this.textNewPW2.PasswordChar = '●';
            this.textNewPW2.Size = new System.Drawing.Size(152, 30);
            this.textNewPW2.TabIndex = 50;
            this.textNewPW2.TransparencyKey = System.Drawing.Color.White;
            this.textNewPW2.WaterFont = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textNewPW2.WaterText = "(6-20位数字或字母)";
            this.textNewPW2.WaterTextOffset = new System.Drawing.Point(3, 5);
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(13, 191);
            this.skinLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(85, 19);
            this.skinLabel3.TabIndex = 51;
            this.skinLabel3.Text = "确认密码";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DownBack = null;
            this.btnOK.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(36, 228);
            this.btnOK.MouseBack = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 45;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.White;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(2, 32);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(282, 10);
            this.skinLine1.TabIndex = 63;
            this.skinLine1.Text = "skinLine1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::WeLink.Properties.Resources._23像素图标;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 62;
            this.label1.Text = "找回密码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // GetBackPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.BackgroundImage = global::WeLink.Properties.Resources.纯色紫背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(288, 265);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.textNewPW2);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.textNewPW);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.textCardID);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCheckFace);
            this.Controls.Add(this.btnCheckEmail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetBackPW";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.GetBackPW_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CCWin.SkinControl.SkinButton btnBack;
        private CCWin.SkinControl.SkinButton btnCheckEmail;
        private CCWin.SkinControl.SkinButton btnCheckFace;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private LayeredSkin.Controls.LayeredTextBox textCardID;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private LayeredSkin.Controls.LayeredTextBox textNewPW;
        private LayeredSkin.Controls.LayeredTextBox textNewPW2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinButton btnOK;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label label1;
    }
}