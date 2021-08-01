namespace WeLink_Server.UI
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (System.Exception)
            {
            }
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textIP1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textIP2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPort1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textPort2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelOnlineNum = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvLoginUserInfo = new System.Windows.Forms.DataGridView();
            this.cardID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nowDateSwap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listLogs = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // textIP1
            // 
            this.textIP1.Location = new System.Drawing.Point(67, 22);
            this.textIP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textIP1.Name = "textIP1";
            this.textIP1.ReadOnly = true;
            this.textIP1.Size = new System.Drawing.Size(191, 25);
            this.textIP1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP1";
            // 
            // textIP2
            // 
            this.textIP2.Location = new System.Drawing.Point(67, 72);
            this.textIP2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textIP2.Name = "textIP2";
            this.textIP2.ReadOnly = true;
            this.textIP2.Size = new System.Drawing.Size(191, 25);
            this.textIP2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "IP2";
            // 
            // textPort1
            // 
            this.textPort1.Location = new System.Drawing.Point(369, 22);
            this.textPort1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textPort1.Name = "textPort1";
            this.textPort1.Size = new System.Drawing.Size(100, 25);
            this.textPort1.TabIndex = 0;
            this.textPort1.Text = "50000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Port1";
            // 
            // textPort2
            // 
            this.textPort2.Location = new System.Drawing.Point(369, 72);
            this.textPort2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textPort2.Name = "textPort2";
            this.textPort2.Size = new System.Drawing.Size(100, 25);
            this.textPort2.TabIndex = 0;
            this.textPort2.Text = "50001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Port2";
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = true;
            this.btnStart.Location = new System.Drawing.Point(649, 46);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 28);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开启";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(493, 52);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(97, 15);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "状态：已停止";
            // 
            // labelOnlineNum
            // 
            this.labelOnlineNum.AutoSize = true;
            this.labelOnlineNum.Location = new System.Drawing.Point(64, 128);
            this.labelOnlineNum.Name = "labelOnlineNum";
            this.labelOnlineNum.Size = new System.Drawing.Size(120, 15);
            this.labelOnlineNum.TabIndex = 3;
            this.labelOnlineNum.Text = "当前在线人数：0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(317, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "今日登陆人次：0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(561, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "累计登陆人次：0";
            // 
            // dgvLoginUserInfo
            // 
            this.dgvLoginUserInfo.AllowUserToAddRows = false;
            this.dgvLoginUserInfo.AllowUserToDeleteRows = false;
            this.dgvLoginUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginUserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cardID,
            this.loginTime,
            this.loginIP,
            this.loginPort,
            this.nowDateSwap});
            this.dgvLoginUserInfo.Location = new System.Drawing.Point(15, 195);
            this.dgvLoginUserInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLoginUserInfo.Name = "dgvLoginUserInfo";
            this.dgvLoginUserInfo.ReadOnly = true;
            this.dgvLoginUserInfo.RowTemplate.Height = 27;
            this.dgvLoginUserInfo.Size = new System.Drawing.Size(725, 436);
            this.dgvLoginUserInfo.TabIndex = 4;
            // 
            // cardID
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cardID.DefaultCellStyle = dataGridViewCellStyle1;
            this.cardID.HeaderText = "在线账号";
            this.cardID.Name = "cardID";
            this.cardID.ReadOnly = true;
            // 
            // loginTime
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.loginTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.loginTime.HeaderText = "登陆时间";
            this.loginTime.Name = "loginTime";
            this.loginTime.ReadOnly = true;
            this.loginTime.Width = 150;
            // 
            // loginIP
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.loginIP.DefaultCellStyle = dataGridViewCellStyle3;
            this.loginIP.HeaderText = "登陆IP";
            this.loginIP.Name = "loginIP";
            this.loginIP.ReadOnly = true;
            this.loginIP.Width = 80;
            // 
            // loginPort
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.loginPort.DefaultCellStyle = dataGridViewCellStyle4;
            this.loginPort.HeaderText = "登陆端口";
            this.loginPort.Name = "loginPort";
            this.loginPort.ReadOnly = true;
            this.loginPort.Width = 80;
            // 
            // nowDateSwap
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nowDateSwap.DefaultCellStyle = dataGridViewCellStyle5;
            this.nowDateSwap.HeaderText = "登录方式";
            this.nowDateSwap.Name = "nowDateSwap";
            this.nowDateSwap.ReadOnly = true;
            // 
            // listLogs
            // 
            this.listLogs.FormattingEnabled = true;
            this.listLogs.ItemHeight = 15;
            this.listLogs.Location = new System.Drawing.Point(764, 26);
            this.listLogs.Margin = new System.Windows.Forms.Padding(4);
            this.listLogs.Name = "listLogs";
            this.listLogs.Size = new System.Drawing.Size(501, 604);
            this.listLogs.TabIndex = 5;
            this.listLogs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listLogs_MouseClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(159, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "今日最高同时登录人数：0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(421, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "累计最高同时登录人数：0";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "服务器 for WeLink";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 649);
            this.Controls.Add(this.listLogs);
            this.Controls.Add(this.dgvLoginUserInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelOnlineNum);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textIP2);
            this.Controls.Add(this.textPort2);
            this.Controls.Add(this.textPort1);
            this.Controls.Add(this.textIP1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "WeLink服务器";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginUserInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textIP1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIP2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPort1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPort2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelOnlineNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvLoginUserInfo;
        private System.Windows.Forms.ListBox listLogs;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardID;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn nowDateSwap;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
    }
}

