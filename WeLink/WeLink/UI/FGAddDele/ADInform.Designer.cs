namespace WeLink.UI
{
    partial class ADInform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ADInform));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox = new LayeredSkin.Controls.LayeredListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(184)))), ((int)(((byte)(226)))));
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TheMouseDown);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox);
            this.splitContainer1.Size = new System.Drawing.Size(530, 370);
            this.splitContainer1.SplitterDistance = 33;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Image = global::WeLink.Properties.Resources._23像素图标;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 59;
            this.label1.Text = "添加申请";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listBox
            // 
            this.listBox.AutoFocus = false;
            this.listBox.BackColor = System.Drawing.Color.White;
            this.listBox.BackgroundImage = global::WeLink.Properties.Resources.纯色紫背景;
            this.listBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.listBox.Borders.BottomColor = System.Drawing.Color.Empty;
            this.listBox.Borders.BottomWidth = 1;
            this.listBox.Borders.LeftColor = System.Drawing.Color.Empty;
            this.listBox.Borders.LeftWidth = 1;
            this.listBox.Borders.RightColor = System.Drawing.Color.Empty;
            this.listBox.Borders.RightWidth = 1;
            this.listBox.Borders.TopColor = System.Drawing.Color.Empty;
            this.listBox.Borders.TopWidth = 1;
            this.listBox.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("listBox.Canvas")));
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.EnabledMouseWheel = true;
            this.listBox.ItemSize = new System.Drawing.Size(100, 100);
            this.listBox.ListTop = 0;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Orientation = LayeredSkin.Controls.ListOrientation.Vertical;
            this.listBox.RollSize = 20;
            this.listBox.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listBox.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listBox.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listBox.ScrollBarWidth = 10;
            this.listBox.ShowScrollBar = true;
            this.listBox.Size = new System.Drawing.Size(530, 336);
            this.listBox.SmoothScroll = false;
            this.listBox.TabIndex = 6;
            this.listBox.Text = "layeredListBox1";
            this.listBox.Ulmul = false;
            this.listBox.Value = 0D;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(184)))), ((int)(((byte)(226)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 33);
            this.panel1.TabIndex = 60;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TheMouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TheMouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TheMouseUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Image = global::WeLink.Properties.Resources.sysbtn_close_normal;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(492, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 23);
            this.label2.TabIndex = 59;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ADInform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(530, 370);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ADInform";
            this.Radius = 10;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public LayeredSkin.Controls.LayeredListBox listBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
    }
}