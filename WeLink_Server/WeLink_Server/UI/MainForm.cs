using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink_Server.BLL;
using WeLink_Server.DAL;

namespace WeLink_Server.UI
{
    public partial class MainForm : Form
    {
        #region 窗口的构造和初始化

        ServerMain_Server serverMain = null;
        public MainForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        int timerCnt = 0;
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                getStatisticsData();//加载窗口变量
                serverMain = new ServerMain_Server(this);

                timer1.Interval = 1000 * 60 * 60;
                timer1.Start();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 各响应函数

        /// <summary>
        /// 开启/停止按钮响应：开启/关闭服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (labelStatus.Text == "状态：已停止")
                {
                    labelStatus.Text = "状态：已开启";
                    btnStart.Text = "停止";
                    textIP1.Text = textIP2.Text = ToolUnion.getHostIPAddress();
                    int port1 = Int32.Parse(textPort1.Text);
                    int port2 = Int32.Parse(textPort2.Text);
                    serverMain.startServer(port1, port2);
                }
                else
                {
                    labelStatus.Text = "状态：已停止";
                    btnStart.Text = "开启";
                    textIP1.Text = textIP2.Text = "";
                    serverMain.stopServer();
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 窗口关闭响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                timer1.Stop();
                setStatisticsData();//窗口统计变量数据入库
                Application.Exit();
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 窗口统计变量，变量的加载和保存
        int nowOnlineNum = 0;//当前在线人数
        int todayLoginNum = 0;//今日登陆人次
        int totalLoginNum = 0;//累计登录人次
        int todayMaxNum = 0;//今日最高同时登录人次
        int totalMaxNum = 0;//累计最高同时登录人次

        #region 设置窗口统计数据标签数据
        void setAllLabel()
        {
            try
            {
                setNowOnlineNum();
                setTodayLoginNum();
                setTodayMaxNum();
                setTotalLoginNum();
                setTotalMaxNum();
            }
            catch (Exception)
            {
            }
        }
        void setNowOnlineNum()
        {
            labelOnlineNum.Text = "当前在线人数：" + nowOnlineNum;
        }
        void setTodayLoginNum()
        {
            label5.Text = "今日登陆人次：" + todayLoginNum;
        }
        void setTotalLoginNum()
        {
            label6.Text = "累计登录人次：" + totalLoginNum;
        }
        void setTodayMaxNum()
        {
            label7.Text = "今日最高同时登录人数：" + todayMaxNum;
        }
        void setTotalMaxNum()
        {
            label8.Text = "累计最高同时登录人数：" + totalMaxNum;
        }

        #endregion

        /// <summary>
        /// 加载窗口统计变量
        /// </summary>
        private void getStatisticsData()
        {
            try
            {
                nowOnlineNum = 0;
                todayLoginNum = 0;
                todayMaxNum = 0;
                string temp = StatisticsDataDeal.getTodayStatisticsData();
                if (temp != null)//已经有今天的记录
                {
                    string[] temp2 = temp.Split(' ');
                    todayLoginNum = Int32.Parse(temp2[0]);
                    todayMaxNum = Int32.Parse(temp2[1]);
                }
                string[] str = StatisticsDataDeal.getTotalStatisticsData().Split(' ');
                totalLoginNum = Int32.Parse(str[0]);
                totalMaxNum = Int32.Parse(str[1]);
                setAllLabel();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 窗口统计变量数据入库
        /// </summary>
        private void setStatisticsData()
        {
            try
            {
                StatisticsDataDeal.setTodayAndTotalStatisticsData(todayLoginNum, todayMaxNum);
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 其他功能：写日志，日志栏提示标签，插入/删除在线用户信息（写入数据库）并更新在线人数

        public List<string> operateLogs = new List<string>();
        List<string> tempLogs = null;

        /// <summary>
        /// UI层写操作日志到ListLogs，每100条或参数为“endServer”清空显示并写入txt日志文件
        /// </summary>
        /// <param name="str"></param>
        public void writeLogs(string str)
        {
            try
            {
                if (str == "endServer")
                {
                    tempLogs = new List<string>(operateLogs);
                    operateLogs.Clear();
                    listLogs.Items.Clear();
                    //异步执行
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        BaseDataDeal.writeLogsToTxt(tempLogs);
                    });
                }
                else
                {
                    string key = DateTime.Now.ToString() + "：" + str;
                    listLogs.Items.Add(key);
                    operateLogs.Add(key);
                    if (operateLogs.Count == 100)
                    {
                        tempLogs = new List<string>(operateLogs);
                        operateLogs.Clear();
                        listLogs.Items.Clear();
                        //异步执行
                        this.BeginInvoke((MethodInvoker)delegate ()
                        {
                            BaseDataDeal.writeLogsToTxt(tempLogs);
                        });
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 插入在线用户信息并更新相关数据
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="socketSend"></param>
        /// <param name="loginType"></param>
        public void addToDgvLoginUserInfo(string cardID, Socket socketSend, int loginType)
        {
            try
            {
                List<object> record = new List<object>();
                writeLogs("用户" + cardID + "登录账号");
                string[] ipPort = socketSend.RemoteEndPoint.ToString().Split(':');
                int index = dgvLoginUserInfo.Rows.Add();
                dgvLoginUserInfo.Rows[index].Cells[0].Value = cardID;
                dgvLoginUserInfo.Rows[index].Cells[1].Value = DateTime.Now.ToString();
                dgvLoginUserInfo.Rows[index].Cells[2].Value = ipPort[0];
                dgvLoginUserInfo.Rows[index].Cells[3].Value = ipPort[1];
                record.Add(cardID);
                record.Add(dgvLoginUserInfo.Rows[index].Cells[1].Value);
                record.Add(ipPort[0]);
                record.Add(ipPort[1]);
                switch (loginType)
                {
                    case 1: dgvLoginUserInfo.Rows[index].Cells[4].Value = "面容识别"; break;
                    case 2: dgvLoginUserInfo.Rows[index].Cells[4].Value = "QQ邮箱"; break;
                    default: dgvLoginUserInfo.Rows[index].Cells[4].Value = "WeLink账号"; break;
                }
                record.Add(dgvLoginUserInfo.Rows[index].Cells[4].Value);
                ++nowOnlineNum;
                ++todayLoginNum;
                ++totalLoginNum;
                if (nowOnlineNum > todayMaxNum)
                    todayMaxNum = nowOnlineNum;
                if (todayMaxNum > totalMaxNum)
                    totalMaxNum = todayMaxNum;
                setAllLabel();
                //后台写入登录日志表
                Thread thread = new Thread(LoginLogsDataDeal.insertLoginLog);
                thread.IsBackground = true;
                thread.Start(record.ToArray());
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 删除在线用户信息并更新相关数据
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="socketSend"></param>
        /// <param name="loginType"></param>
        public void deleteFromDgvLoginUserInfo(string cardID)
        {
            try
            {
                writeLogs("用户" + cardID + "注销账号");
                //删除指定行
                for (int i = 0; i < dgvLoginUserInfo.RowCount; i++)
                {
                    if (dgvLoginUserInfo.Rows[i].Cells[0].Value.ToString() == cardID)
                        dgvLoginUserInfo.Rows.RemoveAt(i);
                }
                if (nowOnlineNum>0)
                {
                    --nowOnlineNum;
                    setNowOnlineNum();//显示
                }
                try
                {
                    //更新用户的注销时间
                    string sql = $"update UserInfo set uLogOutDate = '{ToolUnion.getTimeStamp()}' " +
                        $"where uCardID = '{cardID}';";
                    BaseDataDeal.update(sql);
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region UI层连接处理

        /// <summary>
        /// listLogs的点击提示标签ToolTip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listLogs_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listLogs.SelectedItems.Count > 0)
                {
                    this.toolTip1.Active = true;
                    this.toolTip1.SetToolTip(listLogs, listLogs.Items[listLogs.SelectedIndex].ToString());
                }
                else
                {
                    this.toolTip1.Active = false;
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 托盘图标点击事件：显示界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 失去焦点事件：最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        /// <summary>
        /// 每7小时重启一次服务器，防止数据库连接池掉线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            ++timerCnt;
            if (timerCnt % 7 == 0 && labelStatus.Text == "状态：已开启")
            {
                btnStart_Click(sender, e);
                Thread.Sleep(5000);
                btnStart_Click(sender, e);
            }
        }
    }
}
