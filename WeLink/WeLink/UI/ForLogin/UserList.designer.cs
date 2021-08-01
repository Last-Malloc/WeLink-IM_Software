namespace WeLink.UI
{
    partial class UserList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            this.layeredListBox1 = new LayeredSkin.Controls.LayeredListBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // layeredListBox1
            // 
            this.layeredListBox1.AutoFocus = false;
            this.layeredListBox1.BackColor = System.Drawing.Color.Transparent;
            this.layeredListBox1.Borders.BottomColor = System.Drawing.Color.Empty;
            this.layeredListBox1.Borders.BottomWidth = 1;
            this.layeredListBox1.Borders.LeftColor = System.Drawing.Color.Empty;
            this.layeredListBox1.Borders.LeftWidth = 1;
            this.layeredListBox1.Borders.RightColor = System.Drawing.Color.Empty;
            this.layeredListBox1.Borders.RightWidth = 1;
            this.layeredListBox1.Borders.TopColor = System.Drawing.Color.Empty;
            this.layeredListBox1.Borders.TopWidth = 1;
            this.layeredListBox1.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("layeredListBox1.Canvas")));
            this.layeredListBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layeredListBox1.EnabledMouseWheel = true;
            this.layeredListBox1.ItemSize = new System.Drawing.Size(100, 100);
            this.layeredListBox1.ListTop = 0;
            this.layeredListBox1.Location = new System.Drawing.Point(5, 5);
            this.layeredListBox1.Name = "layeredListBox1";
            this.layeredListBox1.Orientation = LayeredSkin.Controls.ListOrientation.Vertical;
            this.layeredListBox1.RollSize = 20;
            this.layeredListBox1.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.layeredListBox1.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.layeredListBox1.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.layeredListBox1.ScrollBarWidth = 10;
            this.layeredListBox1.ShowScrollBar = true;
            this.layeredListBox1.Size = new System.Drawing.Size(276, 269);
            this.layeredListBox1.SmoothScroll = false;
            this.layeredListBox1.TabIndex = 1;
            this.layeredListBox1.Text = "layeredListBox1";
            this.layeredListBox1.Ulmul = false;
            this.layeredListBox1.Value = 0D;
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(5, 278);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(190, 25);
            this.skinLabel1.TabIndex = 2;
            this.skinLabel1.Text = "关       闭";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.skinLabel1.Click += new System.EventHandler(this.skinLabel1_Click);
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(221)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(286, 309);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.layeredListBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Radius = 10;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.FrmMenu_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion

        private LayeredSkin.Controls.LayeredListBox layeredListBox1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
    }
}