namespace WeLink.UI
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.listBoxSearch = new LayeredSkin.Controls.LayeredListBox();
            this.SuspendLayout();
            // 
            // listBoxSearch
            // 
            this.listBoxSearch.AutoFocus = false;
            this.listBoxSearch.BackColor = System.Drawing.Color.Transparent;
            this.listBoxSearch.Borders.BottomColor = System.Drawing.Color.Empty;
            this.listBoxSearch.Borders.BottomWidth = 1;
            this.listBoxSearch.Borders.LeftColor = System.Drawing.Color.Empty;
            this.listBoxSearch.Borders.LeftWidth = 1;
            this.listBoxSearch.Borders.RightColor = System.Drawing.Color.Empty;
            this.listBoxSearch.Borders.RightWidth = 1;
            this.listBoxSearch.Borders.TopColor = System.Drawing.Color.Empty;
            this.listBoxSearch.Borders.TopWidth = 1;
            this.listBoxSearch.Canvas = ((System.Drawing.Bitmap)(resources.GetObject("listBoxSearch.Canvas")));
            this.listBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSearch.EnabledMouseWheel = true;
            this.listBoxSearch.ItemSize = new System.Drawing.Size(100, 100);
            this.listBoxSearch.ListTop = 0;
            this.listBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.listBoxSearch.Name = "listBoxSearch";
            this.listBoxSearch.Orientation = LayeredSkin.Controls.ListOrientation.Vertical;
            this.listBoxSearch.RollSize = 20;
            this.listBoxSearch.ScrollBarBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.listBoxSearch.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listBoxSearch.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.listBoxSearch.ScrollBarWidth = 10;
            this.listBoxSearch.ShowScrollBar = true;
            this.listBoxSearch.Size = new System.Drawing.Size(210, 350);
            this.listBoxSearch.SmoothScroll = false;
            this.listBoxSearch.TabIndex = 4;
            this.listBoxSearch.Text = "layeredListBox1";
            this.listBoxSearch.Ulmul = false;
            this.listBoxSearch.Value = 0D;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(210, 350);
            this.Controls.Add(this.listBoxSearch);
            this.Name = "SearchForm";
            this.ResumeLayout(false);

        }

        #endregion

        public LayeredSkin.Controls.LayeredListBox listBoxSearch;
    }
}