namespace WeLink.UI
{
    partial class CreateGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateGroup));
            this.label签名 = new System.Windows.Forms.Label();
            this.HeadImg = new LayeredSkin.Controls.LayeredBaseControl();
            this.label昵称 = new System.Windows.Forms.Label();
            this.label群主 = new System.Windows.Forms.Label();
            this.textgName = new CCWin.SkinControl.SkinTextBox();
            this.textgRemark = new CCWin.SkinControl.SkinTextBox();
            this.textgAffiche = new CCWin.SkinControl.SkinTextBox();
            this.btnOK = new CCWin.SkinControl.SkinButton();
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.SuspendLayout();
            // 
            // label签名
            // 
            this.label签名.AutoSize = true;
            this.label签名.BackColor = System.Drawing.Color.Transparent;
            this.label签名.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label签名.ForeColor = System.Drawing.Color.Black;
            this.label签名.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label签名.Location = new System.Drawing.Point(22, 161);
            this.label签名.Name = "label签名";
            this.label签名.Size = new System.Drawing.Size(72, 20);
            this.label签名.TabIndex = 62;
            this.label签名.Text = "群公告";
            this.label签名.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // HeadImg
            // 
            this.HeadImg.BackgroundImage = global::WeLink.Properties.Resources.群组;
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
            this.HeadImg.Location = new System.Drawing.Point(26, 49);
            this.HeadImg.Name = "HeadImg";
            this.HeadImg.Size = new System.Drawing.Size(100, 100);
            this.HeadImg.TabIndex = 53;
            // 
            // label昵称
            // 
            this.label昵称.AutoSize = true;
            this.label昵称.BackColor = System.Drawing.Color.Transparent;
            this.label昵称.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label昵称.ForeColor = System.Drawing.Color.Black;
            this.label昵称.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label昵称.Location = new System.Drawing.Point(153, 66);
            this.label昵称.Name = "label昵称";
            this.label昵称.Size = new System.Drawing.Size(51, 20);
            this.label昵称.TabIndex = 55;
            this.label昵称.Text = "群名";
            this.label昵称.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label群主
            // 
            this.label群主.AutoSize = true;
            this.label群主.BackColor = System.Drawing.Color.Transparent;
            this.label群主.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold);
            this.label群主.ForeColor = System.Drawing.Color.Black;
            this.label群主.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label群主.Location = new System.Drawing.Point(132, 117);
            this.label群主.Name = "label群主";
            this.label群主.Size = new System.Drawing.Size(72, 20);
            this.label群主.TabIndex = 56;
            this.label群主.Text = "群名片";
            this.label群主.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textgName
            // 
            this.textgName.BackColor = System.Drawing.Color.Transparent;
            this.textgName.DownBack = null;
            this.textgName.Icon = null;
            this.textgName.IconIsButton = false;
            this.textgName.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textgName.IsPasswordChat = '\0';
            this.textgName.IsSystemPasswordChar = false;
            this.textgName.Lines = new string[0];
            this.textgName.Location = new System.Drawing.Point(217, 58);
            this.textgName.Margin = new System.Windows.Forms.Padding(0);
            this.textgName.MaxLength = 32767;
            this.textgName.MinimumSize = new System.Drawing.Size(28, 28);
            this.textgName.MouseBack = null;
            this.textgName.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textgName.Multiline = false;
            this.textgName.Name = "textgName";
            this.textgName.NormlBack = null;
            this.textgName.Padding = new System.Windows.Forms.Padding(5);
            this.textgName.ReadOnly = false;
            this.textgName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textgName.Size = new System.Drawing.Size(139, 28);
            // 
            // 
            // 
            this.textgName.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textgName.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textgName.SkinTxt.Font = new System.Drawing.Font("宋体", 15F);
            this.textgName.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textgName.SkinTxt.Name = "BaseText";
            this.textgName.SkinTxt.Size = new System.Drawing.Size(129, 23);
            this.textgName.SkinTxt.TabIndex = 0;
            this.textgName.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textgName.SkinTxt.WaterText = "";
            this.textgName.TabIndex = 63;
            this.textgName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textgName.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textgName.WaterText = "";
            this.textgName.WordWrap = true;
            // 
            // textgRemark
            // 
            this.textgRemark.BackColor = System.Drawing.Color.Transparent;
            this.textgRemark.DownBack = null;
            this.textgRemark.Icon = null;
            this.textgRemark.IconIsButton = false;
            this.textgRemark.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textgRemark.IsPasswordChat = '\0';
            this.textgRemark.IsSystemPasswordChar = false;
            this.textgRemark.Lines = new string[0];
            this.textgRemark.Location = new System.Drawing.Point(217, 109);
            this.textgRemark.Margin = new System.Windows.Forms.Padding(0);
            this.textgRemark.MaxLength = 32767;
            this.textgRemark.MinimumSize = new System.Drawing.Size(28, 28);
            this.textgRemark.MouseBack = null;
            this.textgRemark.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textgRemark.Multiline = false;
            this.textgRemark.Name = "textgRemark";
            this.textgRemark.NormlBack = null;
            this.textgRemark.Padding = new System.Windows.Forms.Padding(5);
            this.textgRemark.ReadOnly = false;
            this.textgRemark.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textgRemark.Size = new System.Drawing.Size(139, 28);
            // 
            // 
            // 
            this.textgRemark.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textgRemark.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textgRemark.SkinTxt.Font = new System.Drawing.Font("宋体", 15F);
            this.textgRemark.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textgRemark.SkinTxt.Name = "BaseText";
            this.textgRemark.SkinTxt.Size = new System.Drawing.Size(129, 23);
            this.textgRemark.SkinTxt.TabIndex = 0;
            this.textgRemark.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textgRemark.SkinTxt.WaterText = "";
            this.textgRemark.TabIndex = 63;
            this.textgRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textgRemark.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textgRemark.WaterText = "";
            this.textgRemark.WordWrap = true;
            // 
            // textgAffiche
            // 
            this.textgAffiche.BackColor = System.Drawing.Color.Transparent;
            this.textgAffiche.DownBack = null;
            this.textgAffiche.Icon = null;
            this.textgAffiche.IconIsButton = false;
            this.textgAffiche.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textgAffiche.IsPasswordChat = '\0';
            this.textgAffiche.IsSystemPasswordChar = false;
            this.textgAffiche.Lines = new string[0];
            this.textgAffiche.Location = new System.Drawing.Point(26, 181);
            this.textgAffiche.Margin = new System.Windows.Forms.Padding(0);
            this.textgAffiche.MaxLength = 32767;
            this.textgAffiche.MinimumSize = new System.Drawing.Size(28, 28);
            this.textgAffiche.MouseBack = null;
            this.textgAffiche.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textgAffiche.Multiline = true;
            this.textgAffiche.Name = "textgAffiche";
            this.textgAffiche.NormlBack = null;
            this.textgAffiche.Padding = new System.Windows.Forms.Padding(5);
            this.textgAffiche.ReadOnly = false;
            this.textgAffiche.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textgAffiche.Size = new System.Drawing.Size(330, 98);
            // 
            // 
            // 
            this.textgAffiche.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textgAffiche.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textgAffiche.SkinTxt.Font = new System.Drawing.Font("宋体", 15F);
            this.textgAffiche.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.textgAffiche.SkinTxt.Multiline = true;
            this.textgAffiche.SkinTxt.Name = "BaseText";
            this.textgAffiche.SkinTxt.Size = new System.Drawing.Size(320, 88);
            this.textgAffiche.SkinTxt.TabIndex = 0;
            this.textgAffiche.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textgAffiche.SkinTxt.WaterText = "";
            this.textgAffiche.TabIndex = 64;
            this.textgAffiche.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textgAffiche.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textgAffiche.WaterText = "";
            this.textgAffiche.WordWrap = true;
            // 
            // btnOK
            // 
            this.btnOK.AutoSize = true;
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnOK.DownBack = null;
            this.btnOK.Font = new System.Drawing.Font("宋体", 15F);
            this.btnOK.Location = new System.Drawing.Point(26, 298);
            this.btnOK.MouseBack = null;
            this.btnOK.Name = "btnOK";
            this.btnOK.NormlBack = null;
            this.btnOK.Size = new System.Drawing.Size(126, 30);
            this.btnOK.TabIndex = 65;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DownBack = null;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 15F);
            this.btnCancel.Location = new System.Drawing.Point(230, 298);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(126, 30);
            this.btnCancel.TabIndex = 66;
            this.btnCancel.Text = "返回";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 67;
            this.label1.Text = "创建群";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.White;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(1, 35);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(385, 10);
            this.skinLine1.TabIndex = 68;
            this.skinLine1.Text = "skinLine1";
            // 
            // CreateGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeLink.Properties.Resources.瑞士冬季;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(392, 349);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textgAffiche);
            this.Controls.Add(this.textgRemark);
            this.Controls.Add(this.textgName);
            this.Controls.Add(this.label签名);
            this.Controls.Add(this.HeadImg);
            this.Controls.Add(this.label昵称);
            this.Controls.Add(this.label群主);
            this.Name = "CreateGroup";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label签名;
        private LayeredSkin.Controls.LayeredBaseControl HeadImg;
        private System.Windows.Forms.Label label昵称;
        private System.Windows.Forms.Label label群主;
        private CCWin.SkinControl.SkinTextBox textgName;
        private CCWin.SkinControl.SkinTextBox textgRemark;
        private CCWin.SkinControl.SkinTextBox textgAffiche;
        private CCWin.SkinControl.SkinButton btnOK;
        private CCWin.SkinControl.SkinButton btnCancel;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinLine skinLine1;
    }
}