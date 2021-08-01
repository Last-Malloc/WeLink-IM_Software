namespace WeLink.UI
{
    partial class FaceLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceLogin));
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.labelTime = new System.Windows.Forms.Label();
            this.skinLine1 = new CCWin.SkinControl.SkinLine();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.videoSourcePlayer1.BorderColor = System.Drawing.Color.Transparent;
            this.videoSourcePlayer1.Location = new System.Drawing.Point(11, 40);
            this.videoSourcePlayer1.Margin = new System.Windows.Forms.Padding(2);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(288, 173);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // labelTime
            // 
            this.labelTime.BackColor = System.Drawing.Color.Transparent;
            this.labelTime.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTime.Location = new System.Drawing.Point(230, 178);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(69, 35);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "10s";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // skinLine1
            // 
            this.skinLine1.BackColor = System.Drawing.Color.Transparent;
            this.skinLine1.LineColor = System.Drawing.Color.White;
            this.skinLine1.LineHeight = 1;
            this.skinLine1.Location = new System.Drawing.Point(1, 32);
            this.skinLine1.Name = "skinLine1";
            this.skinLine1.Size = new System.Drawing.Size(317, 10);
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
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 62;
            this.label1.Text = "人脸识别登录";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FaceLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WeLink.Properties.Resources.纯色紫背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(312, 226);
            this.Controls.Add(this.skinLine1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.videoSourcePlayer1);
            this.DrawIcon = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FaceLogin";
            this.Radius = 10;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FaceLogin_FormClosing);
            this.Load += new System.EventHandler(this.facelogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label labelTime;
        private CCWin.SkinControl.SkinLine skinLine1;
        private System.Windows.Forms.Label label1;
    }
}