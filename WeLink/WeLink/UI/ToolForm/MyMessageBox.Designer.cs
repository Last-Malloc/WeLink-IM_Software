namespace WeLink.UI
{
    partial class MyMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyMessageBox));
            this.btnYes = new CCWin.SkinControl.SkinButton();
            this.btnNo = new CCWin.SkinControl.SkinButton();
            this.btnCancel = new CCWin.SkinControl.SkinButton();
            this.pictureBox1 = new AForge.Controls.PictureBox();
            this.labelText = new System.Windows.Forms.Label();
            this.pictureBox2 = new AForge.Controls.PictureBox();
            this.BtnClose = new LayeredSkin.Controls.LayeredButton();
            this.labelCaption = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnYes.DownBack = null;
            this.btnYes.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnYes.Location = new System.Drawing.Point(12, 160);
            this.btnYes.MouseBack = null;
            this.btnYes.Name = "btnYes";
            this.btnYes.NormlBack = null;
            this.btnYes.Size = new System.Drawing.Size(75, 29);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "是";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnNo.DownBack = null;
            this.btnNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNo.Location = new System.Drawing.Point(115, 160);
            this.btnNo.MouseBack = null;
            this.btnNo.Name = "btnNo";
            this.btnNo.NormlBack = null;
            this.btnNo.Size = new System.Drawing.Size(75, 29);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "否";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCancel.DownBack = null;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(213, 160);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WeLink.Properties.Resources.提示_Box;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = null;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelText
            // 
            this.labelText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelText.Location = new System.Drawing.Point(107, 58);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(172, 99);
            this.labelText.TabIndex = 2;
            this.labelText.Text = "正文";
            this.labelText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelText_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::WeLink.Properties.Resources.提示_Box;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = null;
            this.pictureBox2.Location = new System.Drawing.Point(12, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 75);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // BtnClose
            // 
            this.BtnClose.AdaptImage = true;
            this.BtnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnClose.BaseColor = System.Drawing.Color.Transparent;
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
            this.BtnClose.Location = new System.Drawing.Point(265, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.NormalImage = global::WeLink.Properties.Resources.sysbtn_close_normal;
            this.BtnClose.PressedImage = global::WeLink.Properties.Resources.sysbtn_close_down;
            this.BtnClose.Radius = 10;
            this.BtnClose.ShowBorder = true;
            this.BtnClose.Size = new System.Drawing.Size(30, 27);
            this.BtnClose.TabIndex = 0;
            this.BtnClose.TextLocationOffset = new System.Drawing.Point(0, 0);
            this.BtnClose.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.BtnClose.TextShowMode = LayeredSkin.TextShowModes.Halo;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // labelCaption
            // 
            this.labelCaption.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelCaption.ForeColor = System.Drawing.Color.White;
            this.labelCaption.Location = new System.Drawing.Point(39, 9);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(192, 23);
            this.labelCaption.TabIndex = 8;
            this.labelCaption.Text = "标题";
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.Gray;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(5, 38);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(290, 3);
            this.skinLine1.TabIndex = 9;
            this.skinLine1.Text = "skinLine1";
            // 
            // MyMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeLink.Properties.Resources.纯色紫背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 213);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.labelCaption);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Name = "MyMessageBox";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton btnYes;
        private CCWin.SkinControl.SkinButton btnNo;
        private CCWin.SkinControl.SkinButton btnCancel;
        private AForge.Controls.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelText;
        private AForge.Controls.PictureBox pictureBox2;
        private LayeredSkin.Controls.LayeredButton BtnClose;
        private System.Windows.Forms.Label labelCaption;
        private CCWin.SkinControl.SkinLine skinLine1;
    }
}