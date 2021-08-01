using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using WeLink.BLL;
using WeLink.DAL;

namespace WeLink.UI
{
    public partial class LoginForm : LayeredBaseForm
    {
        #region 构造函数 和 窗口加载（建立数据连接）
        public MainForm mainForm = null;
        public ServerMain serverMain = null;
        private DuiCheckBox chkAutoLogin = null;
        private DuiCheckBox chkRemPW = null;
        RecentUserList[] recentUserList = null;
        int autoLoginCnt = 0;

        public LoginForm()
        {
            InitializeComponent();
            //取消控件跨线程访问检查
            Control.CheckForIllegalCrossThreadCalls = false;
            //头像图片圆角化
            HeadImg.InnerDuiControl.BorderRender = new FilletBorderRender(10, 1, Color.SkyBlue);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //服务类主体
            serverMain = new ServerMain(this);
            serverMain.connect();

            //输入框背景
            textCardID.BackgroundImage = Properties.Resources.txtId_NormlBack;
            textPW.BackgroundImage = Properties.Resources.txtPwd_NormlBack;

            //最近登录和记住密码勾选框
            chkAutoLogin = (DuiCheckBox)(duiChkAutoLogin.DUIControls[0]);
            chkAutoLogin.CheckedChanged += ChkAutoLogin_CheckedChanged;
            chkRemPW = (DuiCheckBox)(duiChkRemPW.DUIControls[0]);

            RefreshUserList();

            if (serverMain.netIsOkWhenClientRun && recentUserList.Length > 0 && recentUserList[0].autoLogin == 1)
            {
                timer1.Interval = 1000;
                timer1.Start();
                btnCancelLogin.Visible = true;
            }
        }

        /// <summary>
        /// 重新加载最近登录用户到内存
        /// </summary>
        public void RefreshUserList()
        {
            recentUserList = LoginDataDeal.getRecentUserList();

            if (recentUserList.Length > 0)
            {
                textCardID.Text = recentUserList[0].cardID;
            }
        }

        #endregion

        #region 登录过程
        /// <summary>
        /// 登录过程的处理
        /// </summary>
        /// <param name="loginAnswer"></param>
        private void Login(LoginAnswer loginAnswer)
        {
            switch (loginAnswer.loginSucOrNot)
            {
                case 0: MyMessageBox.Show("密码错误，今日3次错误将锁定账户！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                case 1: MyMessageBox.Show("登录成功！", "登录成功", MessageBoxButtons.OK, MessageBoxIcon.Information); break;
                case 2: MyMessageBox.Show("该用户不存在！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                case 3: MyMessageBox.Show("锁定账户，请修改密码后登录！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                case 4: MyMessageBox.Show("系统错误，请重启客户端！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                case 5: MyMessageBox.Show("该用户已在线！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                default: MyMessageBox.Show("连接超时！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
            }
            if (loginAnswer.loginSucOrNot == 1)
            {
                //建立缓存目录和默认文件存储路径参数
                LoginDataDeal.initUserCookie(loginAnswer.cardID);
                //异步执行委托中的内容
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    //更新最近登录表：插入或修改
                    int tAuto = 0, tRemPW = 0;
                    if (chkAutoLogin.Checked)
                    {
                        tAuto = 1;
                    }
                    if (chkRemPW.Checked)
                    {
                        tRemPW = 1;
                    }
                    LoginDataDeal.insertOrUpdateUserList(loginAnswer.cardID, loginAnswer.password,
                        loginAnswer.name, tAuto, tRemPW);
                    //刷新显示列表
                    RefreshUserList();
                    //请求头像
                    serverMain.SendData(new StructGetInfo(TransType.HeadPicGetRequest, new HeadPicGetRequest(loginAnswer.cardID)));
                });
                //启用托盘的切换账号项
                conItemChangeID.Enabled = true;
                //显示托盘气泡文字为登录状态
                string str = "WeLink:" + loginAnswer.name + "(" + loginAnswer.cardID + ")\n";
                pallet.Text = str;
                //开启执行主窗口
                this.Hide();
                mainForm = new MainForm(loginAnswer, this);
                mainForm.ShowDialog();
                //用户选择了关闭程序
                if (mainForm.closeAppOrChangeID)
                {
                    BtnCloseClick(new object(), new EventArgs());
                }
                else//用户选择了注销账号
                {
                    serverMain.SendData(new StructGetInfo(TransType.LogOut, null));
                    this.Show();
                    //关闭托盘的切换账号项
                    conItemChangeID.Enabled = false;
                    //关闭conncet以强制退出账号
                    pallet.Text = "WeLink";
                }
                mainForm.Dispose();
                mainForm = null;
            }
        }
        #endregion

        #region 最近登录账户列表的显示
        private void UserListShowDown(object sender, MouseEventArgs e)
        {
            int left = textCardID.Location.X + this.Left + textCardID.Parent.Left;
            int top = textCardID.Location.Y + this.Top + textCardID.Parent.Top + textCardID.Height;
            //窗体的TopLeft值
            int UserTop = top;
            //判断是否超过屏幕高度
            if (UserTop < 0)
            {
                UserTop = 0;
            }
            int UserLeft = left;

            //屏幕不包括任务栏的高度
            int PH = Screen.GetWorkingArea(this).Height;
            int PW = Screen.GetWorkingArea(this).Width;
            //判断是否大于屏幕右边
            if (UserLeft + 260 > PW)
            {
                UserLeft = PW - 160;
            }

            UserList userList = new UserList(textCardID, this, recentUserList);
            userList.Location = new Point(left - 3, UserTop);
            userList.Width = textCardID.Width + 6;
            userList.ShowDialog();
        }
        #endregion

        #region UI层连接处理

        /// <summary>
        /// 显示帮助文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Environment.CurrentDirectory + @"\system\帮助文档.pdf");
            }
            catch (Exception)
            {
                MyMessageBox.Show("打开失败，文件已移动。", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 自动登录勾选时自动勾选记住密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoLogin.Checked == true)
            {
                chkRemPW.Checked = true;
            }
        }

        /// <summary>
        /// 账户输入框中账户改变时改变头像显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textCardID_TextChanged(object sender, EventArgs e)
        {
            if (LoginDataDeal.rCardIDIsLegal(textCardID.Text))
            {
                //异步执行委托中的内容
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    bool flag = false;//是否为最近登录的账户
                    for (int i = 0; i < recentUserList.Length; i++)
                    {
                        if (textCardID.Text == recentUserList[i].cardID)
                        {
                            if (recentUserList[i].autoLogin == 1)
                            {
                                chkAutoLogin.Checked = chkRemPW.Checked = true;
                                textPW.Text = recentUserList[i].password;
                            }
                            else if (recentUserList[i].rememPW == 1)
                            {
                                chkAutoLogin.Checked = false;
                                chkRemPW.Checked = true;
                                textPW.Text = recentUserList[i].password;
                            }
                            else
                            {
                                chkAutoLogin.Checked = chkRemPW.Checked = false;
                                textPW.Text = "";
                            }
                            flag = true;
                            break;
                        }
                    }
                    if (flag == false)
                    {
                        chkAutoLogin.Checked = chkRemPW.Checked = false;
                        textPW.Text = "";
                    }
                });
                //异步执行委托中的内容
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    serverMain.getRecSyncInfo.setHeadPicForBaseControl(HeadImg, textCardID.Text);
                });
            }
            else
            {
                chkAutoLogin.Checked = chkRemPW.Checked = false;
                textPW.Text = "";
                HeadImg.BackgroundImage = Properties.Resources.moren;
            }
        }

        #region 鼠标进入离开账号密码框事件（白色背景和无边框）
        private void textCardID_MouseEnter(object sender, EventArgs e)
        {
            ((LayeredTextBox)sender).BackgroundImage = Properties.Resources.txtId_MouseBack;
        }
        private void textCardID_MouseLeave(object sender, EventArgs e)
        {
            ((LayeredTextBox)sender).BackgroundImage = Properties.Resources.txtId_NormlBack;
        }
        private void textPW_MouseEnter(object sender, EventArgs e)
        {
            ((LayeredTextBox)sender).BackgroundImage = Properties.Resources.txtPwd_MouseBack;
        }
        private void textPW_MouseLeave(object sender, EventArgs e)
        {
            ((LayeredTextBox)sender).BackgroundImage = Properties.Resources.txtPwd_NormlBack;
        }
        #endregion

        /// <summary>
        /// 窗口移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveFormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LayeredSkin.NativeMethods.MouseToMoveControl(this.Handle);
            }
        }

        /// <summary>
        /// 点击设置按钮，显示设置界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSetClick(object sender, EventArgs e)
        {
            this.Hide();
            LoginSettingForm loginSettingForm = new LoginSettingForm();
            loginSettingForm.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// 最小化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMiniClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCloseClick(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 申请账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register(serverMain);
            register.ShowDialog();
            //在头像和账号框中填充刚申请成功的账号和头像
            if (register.cardID != "")
            {
                textCardID.Text = register.cardID;
                serverMain.getRecSyncInfo.setHeadPicForBaseControl(HeadImg, textCardID.Text);
                textPW.Text = "";
                chkAutoLogin.Checked = false;
                chkRemPW.Checked = false;
            }
            this.Show();
        }

        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindBackPW_Click(object sender, EventArgs e)
        {
            this.Hide();
            GetBackPW getBackPW = new GetBackPW(serverMain);
            getBackPW.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// 账号密码登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnLogin.Text = "登录";
            btnCancelLogin.Visible = false;

            string cardID = textCardID.Text;
            string password = textPW.Text;
            if (LoginDataDeal.rCardIDIsLegal(cardID) == false)
            {
                MyMessageBox.Show("账号格式不正确！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LoginDataDeal.rPassWordIsLegal(password) == false)
            {
                MyMessageBox.Show("密码格式不正确！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            serverMain.SendData(new StructGetInfo(TransType.LoginRequest,
                new LoginRequest(0, cardID, password)));
            Login(serverMain.checkLoginAnswer());
        }

        /// <summary>
        /// 人脸识别登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginByFace_Click(object sender, EventArgs e)
        {
            this.Hide();
            FaceLogin faceLogin = new FaceLogin();
            faceLogin.ShowDialog();
            string cardID = faceLogin.id;
            this.Show();
            if (cardID != "")
            {
                serverMain.SendData(new StructGetInfo(TransType.LoginRequest,
                    new LoginRequest(1, cardID)));
                Login(serverMain.checkLoginAnswer());
            }
        }

        /// <summary>
        /// 邮箱登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoginByEmail_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmailRegister emailRegister = new EmailRegister(serverMain, true);
            emailRegister.ShowDialog();
            string email = emailRegister.email;
            this.Show();
            if (email != "")
            {
                serverMain.SendData(new StructGetInfo(TransType.LoginRequest,
                    new LoginRequest(2, email)));
                Login(serverMain.checkLoginAnswer());
            }
        }

        /// <summary>
        /// 窗口关闭过程中：关闭数据连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            serverMain.disconnect();
        }

        /// <summary>
        /// 自动登录计时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnLogin.Text = "登录中...(" + (3 - autoLoginCnt) + "s)";
            if (autoLoginCnt == 3)
            {
                btnLogin_Click(sender, e);
            }
            ++autoLoginCnt;
        }

        /// <summary>
        /// 取消自动登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelLogin_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnCancelLogin.Visible = false;
            btnLogin.Text = "登录";
        }

        #endregion

        #region 托盘菜单栏

        /// <summary>
        /// 切换账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void conItemChangeID_Click(object sender, EventArgs e)
        {
            mainForm.closeAppOrChangeID = false;
            mainForm.Close();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void conItemExit_Click(object sender, EventArgs e)
        {
            //当前已经登录成功
            if (conItemChangeID.Enabled)
            {
                mainForm.closeAppOrChangeID = true;
                mainForm.Close();
            }
            else
            {
                BtnCloseClick(new object(), new EventArgs());
            }
        }

        /// <summary>
        /// 打开主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void conItemOpenMain_Click(object sender, EventArgs e)
        {
            //当前已经登录成功
            if (conItemChangeID.Enabled)
            {
                mainForm.Show();
                mainForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        /// <summary>
        /// 连接到网络
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void conItemConnect_Click(object sender, EventArgs e)
        {
            serverMain.connect();
        }

        /// <summary>
        /// 左键点击：显示主界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pallet_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                conItemOpenMain_Click(sender, e);
            }
        }

        #endregion
    }
}
