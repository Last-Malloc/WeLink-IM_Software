namespace WeLink.UI
{
    partial class GroupMem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupMem));
            this.listBoxMem = new LayeredSkin.Controls.LayeredListBox();
            this.labelClose = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // listBoxMem
            // 
            this.listBoxMem.AutoFocus = false;
            this.listBoxMem.BackColor = System.Drawing.Color.Transparent;
            this.listBoxMem.Borders.BottomColor = System.Drawing.Color.Empty;
            this.listBoxMem.Borders.BottomWidth = 1;
            this.listBoxMem.Borders.LeftColor = System.Drawing.Color.Empty;
            this.listBoxMem.Borders.LeftWidth = 1;
            this.listBoxMem.Borders.RightColor = System.Drawing.Color.Empty;
            this.listBoxMem.Borders.RightWidth = 1;
            this.listBoxMem.Borders.TopColor = System.Drawing.Color.Empty;
            this.listBoxMem.Borders.TopWidth = 1;
            this.listBoxMem.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("listBoxMem.Canvas")));
            this.listBoxMem.EnabledMouseWheel = true;
            this.listBoxMem.ItemSize = new System.Drawing.Size(100, 100);
            this.listBoxMem.ListTop = 0;
            this.listBoxMem.Location = new System.Drawing.Point(5, 5);
            this.listBoxMem.Name = "listBoxMem";
            this.listBoxMem.Orientation = LayeredSkin.Controls.ListOrientation.Vertical;
            this.listBoxMem.RollSize = 20;
            this.listBoxMem.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listBoxMem.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listBoxMem.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listBoxMem.ScrollBarWidth = 10;
            this.listBoxMem.ShowScrollBar = true;
            this.listBoxMem.Size = new System.Drawing.Size(290, 360);
            this.listBoxMem.SmoothScroll = false;
            this.listBoxMem.TabIndex = 5;
            this.listBoxMem.Text = "layeredListBox1";
            this.listBoxMem.Ulmul = false;
            this.listBoxMem.Value = 0D;
            // 
            // labelClose
            // 
            this.labelClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.labelClose.BorderColor = System.Drawing.Color.White;
            this.labelClose.Font = new System.Drawing.Font("微软雅黑", 15F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelClose.Location = new System.Drawing.Point(5, 365);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(290, 30);
            this.labelClose.TabIndex = 3;
            this.labelClose.Text = "关          闭";
            this.labelClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // GroupMem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(184)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(300, 400);
            this.Controls.Add(this.labelClose);
            this.Controls.Add(this.listBoxMem);
            this.Name = "GroupMem";
            this.Radius = 10;
            this.Load += new System.EventHandler(this.GroupMem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public LayeredSkin.Controls.LayeredListBox listBoxMem;
        private CCWin.SkinControl.SkinLabel labelClose;
    }
}