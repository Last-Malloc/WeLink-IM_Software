namespace WeLink.UI
{
    partial class ContextMore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContextMore));
            this.btnChangeID = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangeID
            // 
            this.btnChangeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnChangeID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangeID.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChangeID.ForeColor = System.Drawing.Color.White;
            this.btnChangeID.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeID.Image")));
            this.btnChangeID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChangeID.Location = new System.Drawing.Point(5, 45);
            this.btnChangeID.Name = "btnChangeID";
            this.btnChangeID.Size = new System.Drawing.Size(140, 40);
            this.btnChangeID.TabIndex = 1;
            this.btnChangeID.Text = "切换账号";
            this.btnChangeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChangeID.UseVisualStyleBackColor = false;
            this.btnChangeID.Click += new System.EventHandler(this.btnChangeID_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(5, 85);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(140, 40);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退    出";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSet.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.ForeColor = System.Drawing.Color.White;
            this.btnSet.Image = ((System.Drawing.Image)(resources.GetObject("btnSet.Image")));
            this.btnSet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSet.Location = new System.Drawing.Point(5, 5);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(140, 40);
            this.btnSet.TabIndex = 3;
            this.btnSet.Text = "设    置";
            this.btnSet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // ContextMore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(167)))), ((int)(((byte)(227)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(150, 130);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnChangeID);
            this.Name = "ContextMore";
            this.Radius = 10;
            this.Deactivate += new System.EventHandler(this.ContextMore_Deactivate);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnChangeID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSet;
    }
}