using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using WeLink.DAL;
using WeLink.BLL;
using WeLink.Properties;
using CCWin;
using System.Diagnostics;

namespace WeLink.UI
{
    public partial class MainForm : Skin_DevExpress
    {
        #region 成员变量

        //显示窗口
        UserInfo userInfo = null;
        ContextMore contextMore = null;
        //用来传输数据的服务类
        public ServerMain serverMain = null;
        public LoginForm loginForm = null;
        public GetRecSyncInfo getRecSyncInfo = null;
        //主窗口传来的数据
        public LoginAnswer loginAnswerSource;//源数据，确认提交完成后更改
        //关闭程序还是切换账号(true为closeApp)
        public bool closeAppOrChangeID = true;

        #endregion

        #region 构造函数和窗体加载

        /// <summary>
        /// 构造函数
        /// </summary>
        public MainForm(LoginAnswer loginAnswer, LoginForm loginForm)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            //传入数据
            loginAnswerSource = loginAnswer;
            this.loginForm = loginForm;
            this.serverMain = this.loginForm.serverMain;
            this.getRecSyncInfo = this.serverMain.getRecSyncInfo;

            contextMore = new ContextMore(this);
            contextMore.TopMost = true;
            searchForm = new SearchForm(this);
            searchForm.TopMost = true;

            panel1.BackColor = Color.FromArgb(100, 255, 255, 255);
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //加载关闭按钮的功能设置
            initCloseAppNotMin();

            //加载信息栏的显示
            initInfoBar();

            //初始化聊天框栏
            initMessageShowForm();

            //加载聊天现场
            Thread thread = new Thread(initChatStatus);
            thread.IsBackground = true;
            thread.Start();

            smilPanel = new SmilPanel(this);
            smilPanel.Location = new Point(this.Left + 235, this.Top + 305);
            smilPanel.Hide();
        }

        #endregion

        #region 信息显示栏和信息详情窗口

        /// <summary>
        /// 是否点击了头像使详细信息显示
        /// </summary>
        public bool userInfoClick = false;

        /// <summary>
        /// 重新加载信息栏的显示
        /// </summary>
        private void initInfoBar()
        {
            getRecSyncInfo.setHeadPicForBaseControl(HeadImg, loginAnswerSource.cardID);
            labelName.Text = loginAnswerSource.name;
            if (loginAnswerSource.life == "")
                labelLife.Text = "点击输入个性签名";
            else
                labelLife.Text = loginAnswerSource.life;
            if (loginAnswerSource.sex == 1)
            {
                iconSex.BackgroundImage = Properties.Resources.男;
            }
            else
            {
                iconSex.BackgroundImage = Properties.Resources.女;
            }
        }

        /// <summary>
        /// 鼠标进入头像框：显示详细信息(临时)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadImg_MouseEnter(object sender, EventArgs e)
        {
            if (userInfoClick == false)
            {
                userInfo = new UserInfo(loginAnswerSource, serverMain, this);
                userInfo.Show();
                userInfo.WindowState = FormWindowState.Normal;
                userInfo.Location = this.PointToScreen(new Point(
                    HeadImg.Right + 15, HeadImg.Top - 5));
            }
        }

        /// <summary>
        /// 鼠标离开头像框：隐藏详细信息(临时)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadImg_MouseLeave(object sender, EventArgs e)
        {
            if (!userInfoClick && userInfo != null)
            {
                userInfo.Close();
            }
        }

        public void refreshLoginAnswer(LoginAnswer loginAnswer)
        {
            loginAnswerSource = loginAnswer;
            labelName.Text = loginAnswerSource.name;
            if (loginAnswerSource.sex == 1)
            {
                iconSex.BackgroundImage = Resources.男;
            }
            else
            {
                iconSex.BackgroundImage = Resources.女;
            }
            labelLife.Text = loginAnswerSource.life;
        }

        /// <summary>
        /// 鼠标点击头像框：显示和修改详细信息(常驻的模态对话框)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadImg_MouseDown(object sender, MouseEventArgs e)
        {
            userInfoClick = true;
        }

        #endregion

        #region 个性签名的处理

        /// <summary>
        /// 点击个性标签，Label->textBox，更改个性签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelLife_Click(object sender, EventArgs e)
        {
            textLife.Visible = true;
            if (textLife.Text == "点击输入个性签名")
            {
                textLife.Text = "";
            }
            else
            {
                textLife.Text = loginAnswerSource.life;
            }
        }

        /// <summary>
        /// 点击其他位置：textBox->label，确认更改个性签名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (textLife.Visible)
            {
                //用户对个性签名做了修改
                if (textLife.Text != loginAnswerSource.life)
                {
                    //提交到服务器
                    serverMain.SendData(new StructGetInfo(TransType.UInfoUpdateRequest,
                    new UInfoUpdateRequest(5, loginAnswerSource.cardID, textLife.Text)));
                    bool flag = serverMain.checkExcuteUInfoUpdateRequest();
                    if (flag)
                    {
                        loginAnswerSource.life = textLife.Text;
                        MyMessageBox.Show("个性签名修改成功！", "签名修改", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MyMessageBox.Show("个性签名修改失败！", "签名修改", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //显示
                    if (loginAnswerSource.life == "")
                        labelLife.Text = "点击输入个性签名";
                    else
                        labelLife.Text = loginAnswerSource.life;
                }
                textLife.Visible = false;
            }
            if (searchForm.Visible)
            {
                textCSearch_Leave(sender, e);
            }
        }

        #endregion

        #region UI层美化和界面连接

        bool keepTop = false;
        /// <summary>
        /// 保持/取消窗口在最前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKeepTop_Click(object sender, EventArgs e)
        {
            if (keepTop)
            {
                keepTop = false;
                btnKeepTop.NormalImage
                    = btnKeepTop.HoverImage
                        = btnKeepTop.PressedImage
                            = Properties.Resources.not_keep_top_normal;
                this.TopMost = false;
            }
            else
            {
                keepTop = true;
                btnKeepTop.NormalImage
                    = btnKeepTop.HoverImage
                        = btnKeepTop.PressedImage
                            = Properties.Resources.keep_top_normal;
                this.TopMost = true;
            }
        }

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region 选择关闭按钮的功能

        bool closeAppNotMin = true;
        /// <summary>
        /// 加载关闭按钮功能的配置参数
        /// </summary>
        private void initCloseAppNotMin()
        {
            if (ConfigXml.selectConfigXML("closeAppNotMin") == "0")
            {
                closeApp.Checked = true;
                minToPallet.Checked = false;
                closeAppNotMin = true;
            }
            else
            {
                closeApp.Checked = false;
                minToPallet.Checked = true;
                closeAppNotMin = false;
            }
        }

        /// <summary>
        /// 关闭按钮-关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关闭程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeApp.Checked = true;
            minToPallet.Checked = false;
            closeAppNotMin = true;
            //写入配置文件
            ConfigXml.updateConfigXML("closeAppNotMin", "0");
        }

        /// <summary>
        /// 关闭按钮-隐藏到托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minToPallet_Click(object sender, EventArgs e)
        {
            closeApp.Checked = false;
            minToPallet.Checked = true;
            closeAppNotMin = false;
            //写入配置文件
            ConfigXml.updateConfigXML("closeAppNotMin", "1");
        }

        /// <summary>
        /// 关闭按钮事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                if (closeAppNotMin)
                {
                    closeAppOrChangeID = true;
                    saveChatStatus();
                    this.Close();
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }
        }

        #endregion

        /// <summary>
        /// 切换tabcontrol的页：更改标签图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    tabPageChat.ImageIndex = 0;
                    tabPageFriend.ImageIndex = 3;
                    tabPageGroup.ImageIndex = 5;
                    break;
                case 1:
                    tabPageChat.ImageIndex = 1;
                    tabPageFriend.ImageIndex = 2;
                    tabPageGroup.ImageIndex = 5;
                    break;
                case 2:
                    tabPageChat.ImageIndex = 1;
                    tabPageFriend.ImageIndex = 3;
                    tabPageGroup.ImageIndex = 4;
                    break;
                case 3:
                    tabPageChat.ImageIndex = 1;
                    tabPageFriend.ImageIndex = 3;
                    tabPageGroup.ImageIndex = 5;
                    break;
            }
        }

        /// <summary>
        /// 显示菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMore_Click(object sender, EventArgs e)
        {
            contextMore.Show();
            contextMore.Location = this.PointToScreen(new Point(
                btnMore.Left - 1, btnMore.Top - contextMore.Height + 1));
        }

        #endregion

        #region 联系人相关

        #region 备注修改相关

        /// <summary>
        /// 更改备注时，暂时存储之前的备注
        /// </summary>
        string fTempRemark = "";

        /// <summary>
        /// 点击备注标签，label->text，更改备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelfRemark_Click(object sender, EventArgs e)
        {
            textfRemark.Visible = true;
            labelfRemark.Visible = false;
            fTempRemark = labelfRemark.Text;
            textfRemark.Text = fTempRemark;
        }

        /// <summary>
        /// 编辑备注状态下点击其他位置提交修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelFriendMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (textfRemark.Visible)
            {
                textfRemark.Visible = false;
                labelfRemark.Visible = true;
                //字符数0-5且作了修改则提交至服务器
                string str = textfRemark.Text;
                if (str.Length > 0 && str.Length <= 5 && str != fTempRemark)
                {
                    serverMain.SendData(new StructGetInfo(TransType.FGInfoUpdateRequest,
                        new FGInfoUpdateRequest(loginAnswerSource.cardID, clickItem.Name, 0, str)));

                    //更新缓存列表
                    linkNameFriend.Remove(labelfRemark.Text);
                    try
                    {
                        linkNameFriend.Add(str, labelfCardID.Text);
                    }
                    catch (Exception)
                    {
                    }

                    //更新详细信息
                    labelfRemark.Text = str;

                    //更新列表信息
                    ((DuiLabel)(clickItem.Controls[1])).Text = str;
                }
                else if (str.Length > 5)
                {
                    MyMessageBox.Show("字符串不能大于5", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        /// <summary>
        /// 键值对：好友账号-DuiBaseControl item
        /// </summary>
        public Dictionary<string, DuiBaseControl> linkFriendItem = new Dictionary<string, DuiBaseControl>();
        /// <summary>
        /// 键值对：备注-好友账号
        /// </summary>
        public Dictionary<string, string> linkNameFriend = new Dictionary<string, string>();
        /// <summary>
        /// 好友添加/删除通知
        /// </summary>
        public DuiBaseControl friendInform = null;

        private bool initFriendFinished = false;
        /// <summary>
        /// 将linkIdItem中的内容插入到列表中（带有字母分界栏的item)
        /// </summary>
        public void refreshLinkFriend()
        {
            try
            {
                listBoxFriend.Items.Clear();
                //添加新朋友行
                {
                    //定义控件，添加显示头像图片
                    DuiBaseControl pic = DuiBaseControlClass.AddDuiBaseControl(Resources.新的, ImageLayout.Stretch, Cursors.Default, new Size(40, 40),
                        new Point(20, 10));
                    //备注标签
                    DuiLabel labelName = DuiBaseControlClass.AddDuiLabel("新朋友",
                        itemFont, new Size(160, 20), new Point(100, 20));

                    //未读条数标签
                    DuiLabel labelNotRead = DuiBaseControlClass.AddDuiLabel("",
                       itemFont, new Size(30, 30), new Point(180, 15));
                    labelNotRead.BackColor = Color.Red;
                    labelNotRead.TextAlign = ContentAlignment.MiddleCenter;
                    labelNotRead.Visible = false;
                    labelNotRead.AutoSize = true;

                    //账号项容器控件，可以装载其他DuiBaseControl控件
                    DuiBaseControl itemt = new DuiBaseControl();
                    itemt.BackColor = Color.FromArgb(100, 255, 192, 192);
                    itemt.Width = listBoxFriend.Width;
                    itemt.Height = 60;

                    //设置条目点击事件
                    itemt.MouseClick += newFriendClick;

                    itemt.Controls.Add(pic);//添加备注标签
                    itemt.Controls.Add(labelName);//添加账户标签
                    itemt.Controls.Add(labelNotRead);

                    friendInform = itemt;

                    listBoxFriend.Items.Add(itemt);
                }
                foreach (DuiBaseControl item in linkFriendItem.Values)
                {
                    listBoxFriend.Items.Add(item);
                }
                listBoxFriend.RefreshList();
                initFriendInfomCnt();
                initFriendFinished = true;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 新朋友点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newFriendClick(object sender, EventArgs e)
        {
            showADInform(0);
        }

        /// <summary>
        /// 将得到的好友信息予以显示
        /// </summary>
        public void setFriendInfo(FriendInfoAnswer friendInfoAnswer)
        {
            labelfName.Text = friendInfoAnswer.name;
            labelfLife.Text = friendInfoAnswer.life;
            if (friendInfoAnswer.sex == 1)
            {
                btnfSex.BackgroundImage = Resources.男;
            }
            else
            {
                btnfSex.BackgroundImage = Resources.女;
            }

            labelfRemark.Text = friendInfoAnswer.remark;
            labelfCardID.Text = friendInfoAnswer.cardID;
            if (friendInfoAnswer.source == 0)
            {
                labelfSource.Text = "WeLink账号";
            }
            else
            {
                labelfSource.Text = "第三方邮箱";
            }

            getRecSyncInfo.setHeadPicForBaseControl(fHeadPic, friendInfoAnswer.cardID);
        }

        #region UI层条目处理-联系人

        public Color itemBackNormal = Color.FromArgb(100, 245, 245, 245);
        Color itemBackMouseEnter = Color.FromArgb(100, 223, 222, 223);
        Color itemBackMouseClick = Color.FromArgb(100, 201, 199, 198);
        public Color itemBackLine = Color.FromArgb(100, 180, 180, 180);
        public Font itemFont = new Font("宋体", 16f, FontStyle.Regular);

        /// <summary>
        /// 当前被点击的对象
        /// </summary>
        public DuiBaseControl clickItem = null;

        /// <summary>
        /// 添加条目，显示头像，备注，在线/离线信息，item名设置为cardID
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="name"></param>
        /// <param name="online"></param>
        public DuiBaseControl addItem(string cardID, string remark, byte online)
        {
            //首字母分界
            if (cardID.StartsWith("$$$$$$$$$"))
            {
                //备注标签
                DuiLabel labelAlpha = DuiBaseControlClass.AddDuiLabel(remark,
                    itemFont, new Size(20, 20), new Point(20, 0));
                DuiBaseControl itemAlpha = new DuiBaseControl();
                itemAlpha.BackColor = itemBackNormal;
                itemAlpha.Width = listBoxFriend.Width;
                itemAlpha.Height = 20;
                itemAlpha.Borders.TopColor = itemBackLine;

                itemAlpha.Controls.Add(labelAlpha);
                return itemAlpha;
            }
            //定义控件，添加显示头像图片
            DuiBaseControl pic = DuiBaseControlClass.AddDuiBaseControl(Resources.moren, ImageLayout.Stretch, Cursors.Default, new Size(40, 40),
                new Point(20, 10));

            //在线/离线图标
            Bitmap image;
            if (online == 1)
                image = Resources.在线;
            else
                image = Resources.离线;
            DuiBaseControl onlinePic = DuiBaseControlClass.AddDuiBaseControl(image, ImageLayout.Stretch, Cursors.Default, new Size(12, 12),
                new Point(48, 38));

            //备注标签
            DuiLabel labelRemark = DuiBaseControlClass.AddDuiLabel(remark,
                itemFont, new Size(200, 20), new Point(100, 20));

            //账号项容器控件，可以装载其他DuiBaseControl控件
            DuiBaseControl item = new DuiBaseControl();
            item.BackColor = itemBackNormal;
            item.Width = listBoxFriend.Width;
            item.Height = 60;

            //设置条目点击事件
            item.MouseClick += itemsMouseClick;
            item.MouseEnter += itemsMouseEnter;
            item.MouseLeave += itemsMouseLeave;

            item.Controls.Add(pic);//添加备注标签
            item.Controls.Add(labelRemark);//添加账户标签
            item.Controls.Add(onlinePic);//在线图标
            item.Name = cardID;//添加名称

            //等待更新用户头像
            if (online == 1)
                getRecSyncInfo.setHeadPicForBaseControl(pic, cardID);
            else
                getRecSyncInfo.setHeadPicForBaseControl(pic, cardID, 1);

            return item;//返回整个账户项容器
        }

        /// <summary>
        /// 进入条目：改变背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsMouseEnter(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackColor = itemBackMouseEnter;
        }

        /// <summary>
        /// 离开条目，改变背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsMouseLeave(object sender, EventArgs e)
        {
            DuiBaseControl t = (DuiBaseControl)sender;
            if (t != clickItem)
                t.BackColor = itemBackNormal;
        }

        /// <summary>
        /// 点击条目，改变背景色，请求该用户的详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsMouseClick(object sender, EventArgs e)
        {
            searchForm.Hide();
            tabControl.SelectedTab = tabPageFriend;

            panelFriendMain_MouseDown(new object(),
                new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            if (clickItem != null)
            {
                clickItem.BackColor = itemBackNormal;
            }
            clickItem = (DuiBaseControl)sender;
            clickItem.BackColor = itemBackMouseClick;
            string cardID = ((DuiBaseControl)sender).Name;
            serverMain.SendData(new StructGetInfo(TransType.FriendGroupInfoRequest, new FriendGroupInfoRequest(loginAnswerSource.cardID, cardID, 0)));

            if (labelfName.Visible == false)
            {
                labelfName.Visible = labelfLife.Visible = btnfSex.Visible = fHeadPic.Visible
                    = btnfDelete.Visible = label备注.Visible = label账号.Visible = label来源.Visible
                    = lineFriend.Visible = labelfRemark.Visible = labelfSource.Visible
                    = labelfCardID.Visible = btnfSend.Visible = true;
            }
        }

        #endregion

        #endregion

        #region 群相关

        #region 群名片修改相关

        /// <summary>
        /// 更改群名片时，暂时存储之前的群名片
        /// </summary>
        string gTempRemark = "";

        /// <summary>
        /// 点击备注标签，label->text，更改群名片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelgRemark_Click(object sender, EventArgs e)
        {
            textgRemark.Visible = true;
            labelgRemark.Visible = false;
            gTempRemark = labelgRemark.Text;
            textgRemark.Text = gTempRemark;
        }

        /// <summary>
        /// 提交群名片/群名/群公告的修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelGroupMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (textgRemark.Visible)
            {
                textgRemark.Visible = false;
                labelgRemark.Visible = true;
                //字符数0-5且作了修改则提交至服务器
                string str = textgRemark.Text;
                if (str.Length > 0 && str.Length <= 5 && str != gTempRemark)
                {
                    serverMain.SendData(new StructGetInfo(TransType.FGInfoUpdateRequest,
                        new FGInfoUpdateRequest(loginAnswerSource.cardID, clickItemGroup.Name, 1, str)));

                    //更新详细信息
                    labelgRemark.Text = str;

                    //更新列表信息
                    ((DuiLabel)(clickItemGroup.Controls[1])).Text = str;
                }
                else if (str.Length > 5)
                {
                    MyMessageBox.Show("字符串不能大于5", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (textgName.Visible)
            {
                textgName.Visible = false;
                labelgName.Visible = true;
                //字符数0-5且作了修改则提交至服务器
                string str = textgName.Text;
                if (str.Length > 0 && str.Length <= 5 && str != gTempName)
                {
                    serverMain.SendData(new StructGetInfo(TransType.FGInfoUpdateRequest,
                        new FGInfoUpdateRequest(clickItemGroup.Name, "$$$$$$$$$$", 2, str)));

                    //更新本地列表信息
                    linkNameGroup.Remove(labelgName.Text);
                    try
                    {
                        linkNameGroup.Add(str, labelgID.Text);
                    }
                    catch (Exception)
                    {
                    }

                    //更新详细信息
                    labelgName.Text = str;
                }
                else if (str.Length > 5)
                {
                    MyMessageBox.Show("字符串不能大于5", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (textgAffiche.Visible)
            {
                textgAffiche.Visible = false;
                labelgAffiche.Visible = true;
                //作了修改则提交至服务器
                string str = textgAffiche.Text;
                if (str != gTempAffiche)
                {
                    serverMain.SendData(new StructGetInfo(TransType.FGInfoUpdateRequest,
                        new FGInfoUpdateRequest(clickItemGroup.Name, "$$$$$$$$$$", 3, str)));

                    //更新详细信息
                    labelgAffiche.Text = str;
                }
            }
        }

        #endregion

        #region 群主修改群名相关

        /// <summary>
        /// 更改群名时，暂时存储之前的群名
        /// </summary>
        string gTempName = "";

        /// <summary>
        /// 点击群名标签，label->text，更改群名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelgName_Click(object sender, EventArgs e)
        {
            int index = labelgMaster.Text.IndexOf('(');
            string masterID = labelgMaster.Text.Substring(index + 1, 10);
            if (masterID == loginAnswerSource.cardID)
            {
                textgName.Visible = true;
                labelgName.Visible = false;
                gTempName = labelgName.Text;
                textgName.Text = gTempName;
            }
        }

        #endregion

        #region 群主修改群公告相关

        /// <summary>
        /// 更改群公告时，暂时存储之前的群公告
        /// </summary>
        string gTempAffiche = "";

        /// <summary>
        /// 点击群公告标签，label->text，更改群公告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelgAffiche_Click(object sender, EventArgs e)
        {
            int index = labelgMaster.Text.IndexOf('(');
            string masterID = labelgMaster.Text.Substring(index + 1, 10);
            if (masterID == loginAnswerSource.cardID)
            {
                textgAffiche.Visible = true;
                labelgAffiche.Visible = false;
                gTempAffiche = labelgAffiche.Text;
                textgAffiche.Text = gTempAffiche;
            }
        }

        #endregion

        GroupMem groupMem = null;

        /// <summary>
        /// 键值对：群账号-DuiBaseControl item
        /// </summary>
        public Dictionary<string, DuiBaseControl> linkGroupItem = new Dictionary<string, DuiBaseControl>();
        /// <summary>
        /// 键值对：群名称-群账号
        /// </summary>
        public Dictionary<string, string> linkNameGroup = new Dictionary<string, string>();
        /// <summary>
        /// 群添加/删除通知
        /// </summary>
        public DuiBaseControl groupInform = null;

        private bool initGroupFinished = false;
        /// <summary>
        /// 将linkGroupItem中的内容插入到列表中（带有字母分界栏的item)
        /// </summary>
        public void refreshLinkGroup()
        {
            try
            {
                listBoxGroup.Items.Clear();
                //添加新的群行
                {
                    //定义控件，添加显示头像图片
                    DuiBaseControl pic = DuiBaseControlClass.AddDuiBaseControl(Resources.新的, ImageLayout.Stretch, Cursors.Default, new Size(40, 40),
                        new Point(20, 10));
                    //备注标签
                    DuiLabel labelName = DuiBaseControlClass.AddDuiLabel("新的群",
                        itemFont, new Size(160, 20), new Point(100, 20));

                    //未读条数标签
                    DuiLabel labelNotRead = DuiBaseControlClass.AddDuiLabel("",
                       itemFont, new Size(30, 30), new Point(180, 15));
                    labelNotRead.BackColor = Color.Red;
                    labelNotRead.TextAlign = ContentAlignment.MiddleCenter;
                    labelNotRead.Visible = false;
                    labelNotRead.AutoSize = true;

                    //账号项容器控件，可以装载其他DuiBaseControl控件
                    DuiBaseControl itemt = new DuiBaseControl();
                    itemt.BackColor = Color.FromArgb(100, 255, 192, 192);
                    itemt.Width = listBoxGroup.Width;
                    itemt.Height = 60;

                    //设置条目点击事件
                    itemt.MouseClick += newGroupClick;

                    itemt.Controls.Add(pic);//添加备注标签
                    itemt.Controls.Add(labelName);//添加账户标签
                    itemt.Controls.Add(labelNotRead);

                    groupInform = itemt;

                    listBoxGroup.Items.Add(itemt);
                }
                foreach (DuiBaseControl item in linkGroupItem.Values)
                {
                    listBoxGroup.Items.Add(item);
                }
                listBoxGroup.RefreshList();
                initGroupInfomCnt();
                initGroupFinished = true;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 新的群点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGroupClick(object sender, EventArgs e)
        {
            showADInform(1);
        }

        #region UI层条目处理-群

        /// <summary>
        /// 当前被点击的对象
        /// </summary>
        public DuiBaseControl clickItemGroup = null;

        /// <summary>
        /// 添加条目，显示头像，群名，item名设置为群号
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="name"></param>
        /// <param name="online"></param>
        public DuiBaseControl addItemGroup(string cardID, string name)
        {
            //首字母分界行
            if (cardID.StartsWith("$$$$$$$$$"))
            {
                //备注标签
                DuiLabel labelAlpha = DuiBaseControlClass.AddDuiLabel(name,
                    itemFont, new Size(20, 20), new Point(20, 0));
                DuiBaseControl itemAlpha = new DuiBaseControl();
                itemAlpha.BackColor = itemBackNormal;
                itemAlpha.Width = listBoxGroup.Width;
                itemAlpha.Height = 20;
                itemAlpha.Borders.TopColor = itemBackLine;

                itemAlpha.Controls.Add(labelAlpha);
                return itemAlpha;
            }
            //定义控件，添加显示头像图片
            DuiBaseControl pic = DuiBaseControlClass.AddDuiBaseControl(Resources.群组, ImageLayout.Stretch, Cursors.Default, new Size(40, 40),
                new Point(20, 10));

            //备注标签
            DuiLabel labelName = DuiBaseControlClass.AddDuiLabel(name,
                itemFont, new Size(200, 20), new Point(100, 20));

            //账号项容器控件，可以装载其他DuiBaseControl控件
            DuiBaseControl item = new DuiBaseControl();
            item.BackColor = itemBackNormal;
            item.Width = listBoxGroup.Width;
            item.Height = 60;

            //设置条目点击事件
            item.MouseClick += itemsGroupMouseClick;
            item.MouseEnter += itemsGroupMouseEnter;
            item.MouseLeave += itemsGroupMouseLeave;

            item.Controls.Add(pic);//添加备注标签
            item.Controls.Add(labelName);//添加账户标签
            item.Name = cardID;//添加名称

            return item;//返回整个账户项容器
        }

        /// <summary>
        /// 进入条目：改变背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsGroupMouseEnter(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackColor = itemBackMouseEnter;
        }

        /// <summary>
        /// 离开条目，改变背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsGroupMouseLeave(object sender, EventArgs e)
        {
            DuiBaseControl t = (DuiBaseControl)sender;
            if (t != clickItemGroup)
                t.BackColor = itemBackNormal;
        }

        /// <summary>
        /// 点击条目，改变背景色，请求该群组的详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsGroupMouseClick(object sender, EventArgs e)
        {
            searchForm.Hide();
            tabControl.SelectedTab = tabPageGroup;

            panelGroupMain_MouseDown(new object(),
                new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            if (clickItemGroup != null)
            {
                clickItemGroup.BackColor = itemBackNormal;
            }
            clickItemGroup = (DuiBaseControl)sender;
            clickItemGroup.BackColor = itemBackMouseClick;
            string cardID = ((DuiBaseControl)sender).Name;
            serverMain.SendData(new StructGetInfo(TransType.FriendGroupInfoRequest, new FriendGroupInfoRequest(loginAnswerSource.cardID, cardID, 1)));

            if (labelgName.Visible == false)
            {
                labelgName.Visible = labelgAffiche.Visible = gHeadPic.Visible
                    = btngDelete.Visible = gline.Visible = textgRemark.Visible
                    = label群名片.Visible = label群号.Visible = label群主.Visible
                    = labelgRemark.Visible = labelgID.Visible = labelgMaster.Visible
                    = labelShowgMem.Visible = btngSend.Visible = true;
            }
            textgRemark.Visible = false;
        }

        #endregion

        /// <summary>
        /// 将得到的群信息予以显示
        /// </summary>
        public void setGroupInfo(GroupInfoAnswer groupInfoAnswer)
        {
            labelgName.Text = groupInfoAnswer.gName;
            labelgAffiche.Text = groupInfoAnswer.gAffiche;
            labelgRemark.Text = groupInfoAnswer.gRemark;
            labelgID.Text = groupInfoAnswer.gID;
            labelgMaster.Text = groupInfoAnswer.gMasterRemark + "(" + groupInfoAnswer.gMasterID + ")";
        }

        /// <summary>
        /// 显示群成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelShowgMem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int index = labelgMaster.Text.IndexOf('(');
            string masterID = labelgMaster.Text.Substring(index + 1, 10);
            if (masterID == loginAnswerSource.cardID)
                flag = true;
            if (groupMem != null && groupMem.IsDisposed == false)
                groupMem.Dispose();
            groupMem = new GroupMem(clickItemGroup.Name, labelgName.Text, masterID, flag, serverMain);
            groupMem.Show();
            groupMem.Location = this.Location + new Size(270, 150);
        }

        #endregion

        #region 搜索框和添加好友

        SearchForm searchForm = null;

        /// <summary>
        /// 搜索框静止时隐藏搜索窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textCSearch_Leave(object sender, EventArgs e)
        {
            searchForm.Hide();
            textFSearch.Text = textGSearch.Text = textCSearch.Text
                = "查找联系人或群";
            this.Focus();
        }

        /// <summary>
        /// 输入信息时更新搜索结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textCSearch_TextChanged(object sender, EventArgs e)
        {
            string key = ((TextBox)sender).Text;
            if (key != "")
            {
                //异步执行委托中的内容
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    searchForm.setItem(key);
                });
            }
            else
            {
                searchForm.clear();
            }
        }

        /// <summary>
        /// 移动主窗口时移动搜索显示框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Move(object sender, EventArgs e)
        {
            if (searchForm.Visible)
            {
                searchForm.Location = this.Location + new Size(1, 166);
            }
            if (contextMore.Visible)
            {
                contextMore.Location = this.PointToScreen(new Point(
                btnMore.Left - 1, btnMore.Top - contextMore.Height + 1));
            }
        }

        /// <summary>
        /// 点击搜索输入框获得焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textCSearch_Click(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.Text = "";
            t.Focus();

            searchForm.Show();
            searchForm.Location = this.Location + new Size(1, 166);
            searchForm.clear();

        }

        #endregion

        #region 用户和群的增删改查操作

        #region 好友/群 添加/删除通知

        public List<ADRequestInform> informFriendCookie = new List<ADRequestInform>();
        public List<ADRequestInform> informGroupCookie = new List<ADRequestInform>();

        /// <summary>
        /// 设置好友 添加 通知条数
        /// </summary>
        public void initFriendInfomCnt()
        {
            DuiLabel duiLabel = (DuiLabel)(friendInform.Controls[2]);
            int num = informFriendCookie.Count;
            if (num > 0)
            {
                duiLabel.Visible = true;
                if (num > 99)
                    duiLabel.Text = "99+";
                else
                    duiLabel.Text = num.ToString();
            }
            else
            {
                duiLabel.Visible = false;
            }
        }

        /// <summary>
        /// 设置 群 添加 通知条数
        /// </summary>
        public void initGroupInfomCnt()
        {
            DuiLabel duiLabel = (DuiLabel)(groupInform.Controls[2]);
            int num = informGroupCookie.Count;
            if (num > 0)
            {
                duiLabel.Visible = true;
                if (num > 99)
                    duiLabel.Text = "99+";
                else
                    duiLabel.Text = num.ToString();
            }
            else
            {
                duiLabel.Visible = false;
            }
        }

        /// <summary>
        /// 删除好友按钮：删除本地列表并刷新，向服务器提交更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MyMessageBox.Show("是否确定删除该好友？", "删除好友", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                if (linkChatItem.ContainsKey(labelfCardID.Text + "0"))
                {
                    linkChatItem.Remove(labelfCardID.Text + "0");
                    initMessageShowForm();
                    refreshLinkChat();
                }
                linkFriendItem.Remove(labelfCardID.Text);
                linkNameFriend.Remove(labelfRemark.Text);
                refreshLinkFriend();
                clickItem = null;
                labelfName.Visible = btnfSex.Visible = labelfLife.Visible
                    = fHeadPic.Visible = btnfDelete.Visible = lineFriend.Visible
                    = label备注.Visible = label账号.Visible = label来源.Visible
                    = labelfRemark.Visible = labelfCardID.Visible = labelfSource.Visible
                    = textfRemark.Visible = btnfSend.Visible = false;

                try
                {
                    ADRequestInform aDRequestInform = new ADRequestInform();
                    aDRequestInform.type = 1;
                    aDRequestInform.cardID = loginAnswerSource.cardID;
                    aDRequestInform.IDType = 0;
                    aDRequestInform.fCardID = labelfCardID.Text;
                    aDRequestInform.fIDType = 0;
                    aDRequestInform.time = ToolUnion.getTimeStamp();
                    aDRequestInform.info = $"{loginAnswerSource.name}({loginAnswerSource.cardID}) 已将您删除。";
                    serverMain.SendData(new StructGetInfo(TransType.ADRequestInform, aDRequestInform));
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// 退出群（非群主）或解散群（群主）：删除本地列表并刷新，向服务器提交更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btngDelete_Click(object sender, EventArgs e)
        {
            string gMaster = labelgMaster.Text.Substring(
                labelgMaster.Text.IndexOf('(') + 1, 10);
            if (loginAnswerSource.cardID != gMaster)
            {
                //退出群
                DialogResult result = MyMessageBox.Show("是否确定退出该群？", "退出群", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    if (linkChatItem.ContainsKey(labelgID.Text + "1"))
                    {
                        linkChatItem.Remove(labelgID.Text + "1");
                        initMessageShowForm();
                        refreshLinkChat();
                    }
                    linkGroupItem.Remove(labelgID.Text);
                    linkNameGroup.Remove(labelgName.Text);
                    refreshLinkGroup();
                    clickItemGroup = null;
                    labelgName.Visible = labelgAffiche.Visible = gHeadPic.Visible
                        = textgName.Visible = textgAffiche.Visible = btngDelete.Visible
                        = gline.Visible = btngSend.Visible = textgRemark.Visible = labelShowgMem.Visible
                        = label群名片.Visible = label群号.Visible = label群主.Visible
                        = labelgRemark.Visible = labelgID.Visible = labelgMaster.Visible = false;

                    try
                    {
                        ADRequestInform aDRequestInform = new ADRequestInform();
                        aDRequestInform.type = 1;
                        aDRequestInform.cardID = loginAnswerSource.cardID;
                        aDRequestInform.IDType = 0;
                        aDRequestInform.fCardID = labelgID.Text;
                        aDRequestInform.fIDType = 1;
                        aDRequestInform.time = ToolUnion.getTimeStamp();
                        aDRequestInform.info = $"{loginAnswerSource.name}({loginAnswerSource.cardID}) 退出群 {labelgName.Text}({labelgID.Text})。";
                        serverMain.SendData(new StructGetInfo(TransType.ADRequestInform, aDRequestInform));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                //解散群
                DialogResult result = MyMessageBox.Show("是否确定解散该群？", "解散群", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    linkGroupItem.Remove(labelgID.Text);
                    linkNameGroup.Remove(labelgName.Text);
                    refreshLinkGroup();
                    clickItemGroup = null;
                    labelgName.Visible = labelgAffiche.Visible = gHeadPic.Visible
                        = textgName.Visible = textgAffiche.Visible = btngDelete.Visible
                        = gline.Visible = btngSend.Visible = textgRemark.Visible = labelShowgMem.Visible
                        = label群名片.Visible = label群号.Visible = label群主.Visible
                        = labelgRemark.Visible = labelgID.Visible = labelgName.Visible = false;

                    try
                    {
                        ADRequestInform aDRequestInform = new ADRequestInform();
                        aDRequestInform.type = 2;
                        aDRequestInform.cardID = labelgID.Text;
                        aDRequestInform.IDType = 1;
                        aDRequestInform.fCardID = "$$$$$$$$$$";
                        aDRequestInform.fIDType = 0;
                        aDRequestInform.time = ToolUnion.getTimeStamp();
                        aDRequestInform.info = $"{labelgName.Text}({labelgID.Text}) 已被解散。";
                        serverMain.SendData(new StructGetInfo(TransType.ADRequestInform, aDRequestInform));
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        #endregion

        #region 好友添加和群创建

        public AddFG addFG = null;
        public CreateGroup createGroup = null;
        public ADInform aDInform = null;

        /// <summary>
        /// 显示 新的朋友 或 新的群
        /// </summary>
        /// <param name="type"></param>
        public void showADInform(byte type)
        {
            if (aDInform != null)
                aDInform.Close();
            aDInform = new ADInform(type, informFriendCookie, informGroupCookie, this);
            aDInform.Show();
        }

        /// <summary>
        /// 显示 添加好友/群 和 创建群 菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCAdd_Click(object sender, EventArgs e)
        {
            contextFG.Show(MousePosition);
        }

        /// <summary>
        /// 显示添加好友/群 窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加好友群ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addFG = new AddFG(this);
            addFG.Show();
        }

        /// <summary>
        /// 显示创建群窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 创建群ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createGroup = new CreateGroup(this);
            createGroup.Show();
        }

        /// <summary>
        /// 成功创建群后刷新群的显示界面
        /// </summary>
        public void addGroupItem(string cardID, string name)
        {
            try
            {
                if (createGroup != null && createGroup.IsDisposed == false)
                {
                    DuiBaseControl item = addItemGroup(cardID, name);
                    linkGroupItem.Add(cardID, item);
                    try
                    {
                        linkNameGroup.Add(name, cardID);
                    }
                    catch (Exception)
                    {
                    }
                    listBoxGroup.Items.Insert(1, item);
                    listBoxGroup.RefreshList();
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #endregion

        #region 聊天处理集合

        /// <summary>
        /// 账号+类型，item
        /// </summary>
        public Dictionary<string, DuiBaseControl> linkChatItem = new Dictionary<string, DuiBaseControl>();

        /// <summary>
        /// 添加条目，显示头像(离线黑白)，备注/群名，在线离线标，item名设置为群号/账号+0/1
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="name"></param>
        /// <param name="online"></param>
        public DuiBaseControl addItemChat(string cardID, byte type)
        {
            //账号项容器控件，可以装载其他DuiBaseControl控件
            DuiBaseControl item = new DuiBaseControl();
            item.BackColor = itemBackNormal;
            item.Width = listBoxChat.Width;
            item.Height = 60;

            //设置条目点击事件
            item.MouseClick += itemsChatMouseClick;
            item.MouseEnter += itemsChatMouseEnter;
            item.MouseLeave += itemsChatMouseLeave;

            //定义控件，添加显示头像图片
            DuiBaseControl pic = DuiBaseControlClass.AddDuiBaseControl(Resources.群组, ImageLayout.Stretch, Cursors.Default, new Size(40, 40),
                new Point(20, 10));

            if (type == 0)
            {
                pic = linkFriendItem[cardID].Controls[0];
            }

            //在线/离线图标
            DuiBaseControl onlinePic = null;
            if (type == 0)
            {
                onlinePic = linkFriendItem[cardID].Controls[2];
            }

            //备注标签
            DuiLabel labelRemark = null;
            if (type == 0)
            {
                labelRemark = (DuiLabel)linkFriendItem[cardID].Controls[1];
            }
            else
            {
                labelRemark = (DuiLabel)linkGroupItem[cardID].Controls[1];
            }

            //未读条数标签
            DuiLabel labelNotRead = DuiBaseControlClass.AddDuiLabel("0",
               itemFont, new Size(30, 30), new Point(180, 15));
            labelNotRead.BackColor = Color.Red;
            labelNotRead.TextAlign = ContentAlignment.MiddleCenter;
            labelNotRead.Visible = false;
            labelNotRead.AutoSize = true;

            item.Controls.Add(pic);//添加备注标签
            item.Controls.Add(labelRemark);//添加账户标签
            item.Controls.Add(labelNotRead);//未读消息
            if (type == 0)
                item.Controls.Add(onlinePic);//在线图标
            item.Name = cardID + type.ToString();//添加名称

            return item;//返回整个账户项容器
        }

        /// <summary>
        /// 刷新聊天列表
        /// </summary>
        public void refreshLinkChat()
        {
            listBoxChat.Items.Clear();
            foreach (DuiBaseControl item in linkChatItem.Values)
            {
                listBoxChat.Items.Add(item);
            }
            listBoxChat.RefreshList();
        }

        /// <summary>
        /// 刷新聊天列表的数量显示：操作0表示数量加1(无该item先添加)，操作1表示数量置0
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="type"></param>
        /// <param name="operate"></param>
        public void refreshChatCnt(string cardID, byte type, byte operate = 0)
        {
            while (initChatStatusFinished == false)
            {
                Thread.Sleep(200);
            }
            if (operate == 0)
            {
                if (linkChatItem.ContainsKey(cardID + type.ToString()) == false)
                {
                    DuiBaseControl temp = addItemChat(cardID, type);
                    linkChatItem.Add(cardID + type.ToString(), temp);
                    listBoxChat.Items.Add(temp);
                }
                //更新消息显示
                if (clickItemChat != null && clickItemChat.Name == cardID + type.ToString())
                {
                    listBoxMessage.Items.Add(addItemMessage(serverMain.newMessage));
                    listBoxMessage.Value = 1;
                    //当前只在关注该页，不更新数量
                    if (tabControl.SelectedIndex == 0)
                    {
                        return;
                    }
                }
                else//更新数量
                {
                    DuiLabel label = (DuiLabel)(linkChatItem[cardID + type.ToString()]).Controls[2];
                    if (label.Text != "99+")
                    {
                        int cnt = Int32.Parse(label.Text) + 1;
                        if (cnt > 99)
                        {
                            label.Visible = true;
                            label.Text = "99+";
                        }
                        else
                        {
                            label.Visible = true;
                            label.Text = cnt.ToString();
                        }
                    }
                }
            }
            else
            {
                DuiLabel label = (DuiLabel)clickItemChat.Controls[2];
                label.Text = "0";
                label.Visible = false;
            }
        }

        #region 条目Item函数：点击，右键菜单，群成员显示

        /// <summary>
        /// 当前被点击的对象
        /// </summary>
        public DuiBaseControl clickItemChat = null;

        /// <summary>
        /// 进入条目：改变背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsChatMouseEnter(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackColor = itemBackMouseEnter;
        }

        /// <summary>
        /// 离开条目，改变背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsChatMouseLeave(object sender, EventArgs e)
        {
            DuiBaseControl t = (DuiBaseControl)sender;
            if (t != clickItemChat)
                t.BackColor = itemBackNormal;
        }

        /// <summary>
        /// 左键点击条目改变背景色，右键显示菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsChatMouseClick(object sender, MouseEventArgs e)
        {
            if (clickItemChat != null)
            {
                clickItemChat.BackColor = itemBackNormal;
            }
            clickItemChat = (DuiBaseControl)sender;
            if (clickItemChat.Name[10] == '1')
            {
                refreshChatCnt(clickItemChat.Name.Substring(0, 10), 0, 1);
            }
            else
            {
                refreshChatCnt(clickItemChat.Name.Substring(0, 10), 1, 1);
            }
            initGroupMemOrSexPic(clickItemChat.Name);
            clickItemChat.BackColor = itemBackMouseClick;
            showMessageForm();
            if (e.Button == MouseButtons.Right)
            {
                contextChat.Show(MousePosition);
            }
        }

        /// <summary>
        /// 后台获取所有所在群的群成员账号+备注
        /// </summary>
        Dictionary<string, string> messageGroupMemIDRemark = new Dictionary<string, string>();

        /// <summary>
        /// 点击聊天条目的响应：群加载群员列表填充并在聊天对话上加群名片
        /// 好友加载其性别并更换聊天展示图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initGroupMemOrSexPic(object o)
        {
            string cardIDAndType = (string)o;
            if (cardIDAndType[10] == '1')//点击了群
            {
                serverMain.SendData(new StructGetInfo(TransType.FriendGroupInfoRequest,
                    new FriendGroupInfoRequest(cardIDAndType.Substring(0, 10),"$$$$$$$$$$", 2)));
                messageGroupMemIDRemark.Clear();
                listMessageMem.Items.Clear();
                listMessageMem.BackgroundImage = Resources.人群全身;
                GBriefMemInfoAnswer gBrief = serverMain.checkGBriefMemInfoAnswer();
                if (gBrief.gmCardID != null)
                {
                    for (int i = 0; i < gBrief.gmCardID.Length; i++)
                    {
                        string cardID = gBrief.gmCardID[i];
                        string remark = gBrief.gmRemark[i];
                        messageGroupMemIDRemark.Add(cardID, remark);
                        listMessageMem.Items.Add(addItemMessageMem(cardID, remark));
                    }
                    listMessageMem.RefreshList();
                }
            }
            else//点击了好友
            {
                listMessageMem.Items.Clear();
                listMessageMem.RefreshList();
                listMessageMem.BackgroundImage = Resources.男全身;
            }
        }

        #region initGroupMemOrSexPic辅助函数

        private Font mmFont = new Font("宋体", 8f, FontStyle.Regular);
        private DuiBaseControl addItemMessageMem(string cardID, string name)
        {
            //首字母分界行
            if (cardID.StartsWith("$$$$$$$$$"))
            {
                DuiLabel labelAlpha = DuiBaseControlClass.AddDuiLabel(name,
                    itemFont, new Size(20, 20), new Point(5, 0));
                DuiBaseControl itemAlpha = new DuiBaseControl();
                itemAlpha.BackColor = itemBackNormal;
                itemAlpha.Width = listMessageMem.Width;
                itemAlpha.Height = 20;
                itemAlpha.Borders.TopColor = Color.FromArgb(100, 180, 180, 180);

                itemAlpha.Controls.Add(labelAlpha);
                return itemAlpha;
            }

            Bitmap headPic = new Bitmap(Properties.Resources.moren);
            //定义控件，添加显示头像图片
            DuiBaseControl pic = DuiBaseControlClass.AddDuiBaseControl(headPic, ImageLayout.Stretch, Cursors.Default, new Size(30, 30),
                new Point(5, 5));
            //备注标签
            DuiLabel labelName = DuiBaseControlClass.AddDuiLabel(name + "(" + cardID + ")",
                mmFont, new Size(160, 20), new Point(40, 10));

            //账号项容器控件，可以装载其他DuiBaseControl控件
            DuiBaseControl item = new DuiBaseControl();
            item.BackColor = Color.FromArgb(100, 182, 186, 234);
            item.Width = listMessageMem.Width;
            item.Height = 40;

            //设置该控件的鼠标抬起，进入，离开的响应

            item.Controls.Add(pic);//添加显示头像控件
            item.Controls.Add(labelName);//添加昵称标签
            item.Name = cardID;
            item.Visible = true;//账户项容器设置为可见

            serverMain.getRecSyncInfo.setHeadPicForBaseControl(pic, cardID);

            return item;//返回整个账户项容器
        }
        
        #endregion

        #region 右键菜单栏

        private void 删除聊天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            linkChatItem.Remove(clickItemChat.Name);
            refreshLinkChat();
            initMessageShowForm();
        }

        private void 删除记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChatInfoDataDeal.deleteMessage(loginAnswerSource.cardID, clickItemChat.Name);
            listBoxMessage.Items.Clear();
            listBoxMessage.RefreshList();
        }

        private void 删除记录及聊天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChatInfoDataDeal.deleteMessage(loginAnswerSource.cardID, clickItemChat.Name);
            linkChatItem.Remove(clickItemChat.Name);
            refreshLinkChat();
            initMessageShowForm();
        }

        private void 取消ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            contextChat.Hide();
        }

        //查看详情按钮
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string key = clickItemChat.Name;
            if (key[10] == '1')
            {
                try
                {
                    tabControl.SelectedTab = tabPageGroup;
                    itemsGroupMouseClick(linkGroupItem[key.Substring(0, 10)], new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    tabControl.SelectedTab = tabPageFriend;
                    itemsMouseClick(linkFriendItem[key.Substring(0, 10)], new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion

        #endregion

        #endregion

        #region 聊天记录显示

        /// <summary>
        /// 初始化聊天窗口：隐藏全部控件，clickItemChat置空
        /// </summary>
        public void initMessageShowForm()
        {
            listBoxMessage.Visible = listMessageMem.Visible = panelMessageSend.Visible
                = btnZDMessage.Visible = btnFileMessgae.Visible = btnSendMessage.Visible = false;
            clickItemChat = null;
        }

        /// <summary>
        /// 显示聊天窗口：显示所有控件，当前页码置0, 显示第0页聊天记录
        /// </summary>
        private void showMessageForm()
        {
            listBoxMessage.Visible = listMessageMem.Visible = panelMessageSend.Visible = btnZDMessage.Visible
                = btnFileMessgae.Visible = btnSendMessage.Visible = true;
            strMessageShow[] strMessageShows = ChatInfoDataDeal.getStrMessageShows(
                loginAnswerSource.cardID, clickItemChat.Name);
            listBoxMessage.Items.Clear();
            for (int i = strMessageShows.Length - 1; i >= 0; --i)
            {
                listBoxMessage.Items.Add(addItemMessage(strMessageShows[i]));
            }
            listBoxMessage.RefreshList();
            listBoxMessage.Value = 1;
        }

        private Color colorReceive = Color.FromArgb(100, 252, 228, 214);
        private Color colorSend = Color.FromArgb(100, 226, 239, 218);
        private Font fontTime = new Font("宋体", 8f, FontStyle.Italic);
        private Font fontText = new Font("宋体", 12f, FontStyle.Regular);
        private Font fontSpeicial = new Font("宋体", 12f, FontStyle.Bold | FontStyle.Italic);

        /// <summary>
        /// 添加聊天信息Item
        /// </summary>
        /// <param name="strMessageShow"></param>
        private DuiBaseControl addItemMessage(strMessageShow strMessageShow)
        {
            //账号项容器控件，可以装载其他DuiBaseControl控件
            DuiBaseControl item = new DuiBaseControl();
            if (strMessageShow.sendType == 0 || strMessageShow.sendType == 2)
                item.BackColor = colorReceive;
            else
                item.BackColor = colorSend;
            item.Width = listBoxMessage.Width;
            item.Height = 60;
            item.Borders.TopColor = itemBackNormal;

            //设置条目点击事件
            item.MouseClick += onClickMessageItem;

            //定义控件，添加显示头像图片
            DuiBaseControl pic = null;
            DuiLabel time = null;
            DuiLabel info = null;
            //收消息
            if (strMessageShow.sendType == 0 || strMessageShow.sendType == 2)
            {
                //定义控件，添加显示头像图片
                pic = DuiBaseControlClass.AddDuiBaseControl(new Bitmap(clickItemChat.Controls[0].BackgroundImage), ImageLayout.Stretch, Cursors.Default, new Size(40, 40),
                    new Point(10, 10));
                getRecSyncInfo.setHeadPicForBaseControl(pic, strMessageShow.sendCardID);
                time = DuiBaseControlClass.AddDuiLabel(strMessageShow.time, fontTime, new Size(350, 15), new Point(50, 0));
                time.TextAlign = ContentAlignment.MiddleCenter;
                if (strMessageShow.infoType == 1)
                {
                    info = DuiBaseControlClass.AddDuiLabel("[震动]对方向你发送了一个震动", fontSpeicial, new Size(380, 40), new Point(60, 10));
                    info.TextAlign = ContentAlignment.MiddleLeft;
                }
                else if (strMessageShow.infoType == 2)
                {
                    string key = strMessageShow.info;
                    item.Name = ToolUnion.getStringFromFixedLenString(key.Substring(0, 48));
                    info = DuiBaseControlClass.AddDuiLabel("[文件]" + key.Substring(48, key.Length - 48).Split('?')[0], fontSpeicial, new Size(380, 40), new Point(60, 10));
                    info.TextAlign = ContentAlignment.MiddleLeft;
                }
                else
                {
                    if (strMessageShow.info.StartsWith("\\"))
                    {
                         info = DuiBaseControlClass.AddDuiLabel("", fontText, new Size(40, 40), new Point(60, 10));
                        switch (strMessageShow.info)
                        {
                            case "\\am": info.BackgroundImage = Resources.am; break;
                            case "\\baiy": info.BackgroundImage = Resources.baiy; break;
                            case "\\bs": info.BackgroundImage = Resources.bs; break;
                            case "\\bz": info.BackgroundImage = Resources.bz; break;
                            case "\\ch": info.BackgroundImage = Resources.ch; break;
                            case "\\cy": info.BackgroundImage = Resources.cy; break;
                            case "\\dk": info.BackgroundImage = Resources.dk; break;
                            case "\\doge": info.BackgroundImage = Resources.doge; break;

                            case "\\dy": info.BackgroundImage = Resources.dy; break;
                            case "\\fd": info.BackgroundImage = Resources.fd; break;
                            case "\\fendou": info.BackgroundImage = Resources.fendou; break;
                            case "\\fn": info.BackgroundImage = Resources.fn; break;
                            case "\\gg": info.BackgroundImage = Resources.gg; break;
                            case "\\gz": info.BackgroundImage = Resources.gz; break;
                            case "\\hanx": info.BackgroundImage = Resources.hanx; break;
                            case "\\hq": info.BackgroundImage = Resources.hq; break;

                            case "\\huaix": info.BackgroundImage = Resources.huaix; break;
                            case "\\hx": info.BackgroundImage = Resources.hx; break;
                            case "\\jie": info.BackgroundImage = Resources.jie; break;
                            case "\\jk": info.BackgroundImage = Resources.jk; break;
                            case "\\jy": info.BackgroundImage = Resources.jy; break;
                            case "\\ka": info.BackgroundImage = Resources.ka; break;
                            case "\\kb": info.BackgroundImage = Resources.kb; break;
                            case "\\kel": info.BackgroundImage = Resources.kel; break;

                            case "\\kk": info.BackgroundImage = Resources.kk; break;
                            case "\\kl": info.BackgroundImage = Resources.kl; break;
                            case "\\kuk": info.BackgroundImage = Resources.kuk; break;
                            case "\\kun": info.BackgroundImage = Resources.kuk; break;
                            case "\\lengh": info.BackgroundImage = Resources.lengh; break;
                            case "\\lh": info.BackgroundImage = Resources.lh; break;
                            case "\\ll": info.BackgroundImage = Resources.ll; break;
                            case "\\ng": info.BackgroundImage = Resources.ng; break;

                            case "\\px": info.BackgroundImage = Resources.px; break;
                            case "\\pz": info.BackgroundImage = Resources.pz; break;
                            case "\\qd": info.BackgroundImage = Resources.qd; break;
                            case "\\qiao": info.BackgroundImage = Resources.qiao; break;
                            case "\\qq": info.BackgroundImage = Resources.qq; break;
                            case "\\shuai": info.BackgroundImage = Resources.shuai; break;
                            case "\\shui": info.BackgroundImage = Resources.shui; break;
                            case "\\sr": info.BackgroundImage = Resources.sr; break;

                            case "\\tp": info.BackgroundImage = Resources.tp; break;
                            case "\\ts": info.BackgroundImage = Resources.ts; break;
                            case "\\tuu": info.BackgroundImage = Resources.tuu; break;
                            case "\\tx": info.BackgroundImage = Resources.tx; break;
                            case "\\wn": info.BackgroundImage = Resources.wn; break;
                            case "\\wq": info.BackgroundImage = Resources.wq1; break;
                            case "\\wx": info.BackgroundImage = Resources.wx; break;
                            case "\\wzm": info.BackgroundImage = Resources.wzm; break;

                            default: info.Text = ""; break;
                        }
                    }
                    else
                    {
                        info = DuiBaseControlClass.AddDuiLabel(strMessageShow.info, fontText, new Size(380, 40), new Point(60, 10));
                        info.TextAlign = ContentAlignment.MiddleLeft;
                    }
                }
            }
            else//发消息
            {
                //定义控件，添加显示头像图片
                pic = DuiBaseControlClass.AddDuiBaseControl(new Bitmap(HeadImg.BackgroundImage), ImageLayout.Stretch, Cursors.Default, new Size(40, 40),
                    new Point(400, 10));
                time = DuiBaseControlClass.AddDuiLabel(strMessageShow.time, fontTime, new Size(350, 15), new Point(50, 0));
                time.TextAlign = ContentAlignment.MiddleCenter;
                if (strMessageShow.infoType == 1)
                {
                    info = DuiBaseControlClass.AddDuiLabel("[震动]你向对方发送了一个震动", fontSpeicial, new Size(380, 40), new Point(10, 10));
                    info.TextAlign = ContentAlignment.MiddleRight;
                }
                else if (strMessageShow.infoType == 2)
                {
                    string key = strMessageShow.info;
                    item.Name = ToolUnion.getStringFromFixedLenString(key.Substring(0, 48));
                    info = DuiBaseControlClass.AddDuiLabel("[文件]" + key.Substring(48, key.Length - 48).Split('?')[0], fontSpeicial, new Size(380, 40), new Point(10, 10));
                    info.TextAlign = ContentAlignment.MiddleRight;
                }
                else
                {
                    if (strMessageShow.info.StartsWith("\\"))
                    {
                        info = DuiBaseControlClass.AddDuiLabel("", fontText, new Size(40, 40), new Point(350, 10));
                        switch (strMessageShow.info)
                        {
                            case "\\am": info.BackgroundImage = Resources.am; break;
                            case "\\baiy": info.BackgroundImage = Resources.baiy; break;
                            case "\\bs": info.BackgroundImage = Resources.bs; break;
                            case "\\bz": info.BackgroundImage = Resources.bz; break;
                            case "\\ch": info.BackgroundImage = Resources.ch; break;
                            case "\\cy": info.BackgroundImage = Resources.cy; break;
                            case "\\dk": info.BackgroundImage = Resources.dk; break;
                            case "\\doge": info.BackgroundImage = Resources.doge; break;

                            case "\\dy": info.BackgroundImage = Resources.dy; break;
                            case "\\fd": info.BackgroundImage = Resources.fd; break;
                            case "\\fendou": info.BackgroundImage = Resources.fendou; break;
                            case "\\fn": info.BackgroundImage = Resources.fn; break;
                            case "\\gg": info.BackgroundImage = Resources.gg; break;
                            case "\\gz": info.BackgroundImage = Resources.gz; break;
                            case "\\hanx": info.BackgroundImage = Resources.hanx; break;
                            case "\\hq": info.BackgroundImage = Resources.hq; break;

                            case "\\huaix": info.BackgroundImage = Resources.huaix; break;
                            case "\\hx": info.BackgroundImage = Resources.hx; break;
                            case "\\jie": info.BackgroundImage = Resources.jie; break;
                            case "\\jk": info.BackgroundImage = Resources.jk; break;
                            case "\\jy": info.BackgroundImage = Resources.jy; break;
                            case "\\ka": info.BackgroundImage = Resources.ka; break;
                            case "\\kb": info.BackgroundImage = Resources.kb; break;
                            case "\\kel": info.BackgroundImage = Resources.kel; break;

                            case "\\kk": info.BackgroundImage = Resources.kk; break;
                            case "\\kl": info.BackgroundImage = Resources.kl; break;
                            case "\\kuk": info.BackgroundImage = Resources.kuk; break;
                            case "\\kun": info.BackgroundImage = Resources.kuk; break;
                            case "\\lengh": info.BackgroundImage = Resources.lengh; break;
                            case "\\lh": info.BackgroundImage = Resources.lh; break;
                            case "\\ll": info.BackgroundImage = Resources.ll; break;
                            case "\\ng": info.BackgroundImage = Resources.ng; break;

                            case "\\px": info.BackgroundImage = Resources.px; break;
                            case "\\pz": info.BackgroundImage = Resources.pz; break;
                            case "\\qd": info.BackgroundImage = Resources.qd; break;
                            case "\\qiao": info.BackgroundImage = Resources.qiao; break;
                            case "\\qq": info.BackgroundImage = Resources.qq; break;
                            case "\\shuai": info.BackgroundImage = Resources.shuai; break;
                            case "\\shui": info.BackgroundImage = Resources.shui; break;
                            case "\\sr": info.BackgroundImage = Resources.sr; break;

                            case "\\tp": info.BackgroundImage = Resources.tp; break;
                            case "\\ts": info.BackgroundImage = Resources.ts; break;
                            case "\\tuu": info.BackgroundImage = Resources.tuu; break;
                            case "\\tx": info.BackgroundImage = Resources.tx; break;
                            case "\\wn": info.BackgroundImage = Resources.wn; break;
                            case "\\wq": info.BackgroundImage = Resources.wq1; break;
                            case "\\wx": info.BackgroundImage = Resources.wx; break;
                            case "\\wzm": info.BackgroundImage = Resources.wzm; break;

                            default: info.Text = ""; break;
                        }
                    }
                    else
                    {
                        info = DuiBaseControlClass.AddDuiLabel(strMessageShow.info, fontText, new Size(380, 40), new Point(10, 10));
                        info.TextAlign = ContentAlignment.MiddleRight;
                    }
                }
            }

            item.Controls.Add(pic);
            item.Controls.Add(time);
            item.Controls.Add(info);
            if (strMessageShow.sendType == 2)
            {
                string remark = "";
                try
                {
                    remark = messageGroupMemIDRemark[strMessageShow.sendCardID];
                }
                catch (Exception)
                {
                }
                DuiLabel tr = DuiBaseControlClass.AddDuiLabel(remark, fontTime, new Size(50, 15), new Point(50, 0));
                tr.TextAlign = ContentAlignment.MiddleLeft;
                item.Controls.Add(tr);
            }
            else if (strMessageShow.sendType == 3)
            {
                string remark = "";
                try
                {
                    remark = messageGroupMemIDRemark[loginAnswerSource.cardID];
                }
                catch (Exception)
                {
                }
                DuiLabel tr = DuiBaseControlClass.AddDuiLabel(remark, fontTime, new Size(50, 15), new Point(350, 0));
                tr.TextAlign = ContentAlignment.MiddleRight;
                item.Controls.Add(tr);
            }

            return item;//返回整个账户项容器
        }

        /// <summary>
        /// 点击聊天记录响应：获取文件，展示震动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickMessageItem(object sender, EventArgs e)
        {
            DuiLabel label = (DuiLabel)((DuiBaseControl)sender).Controls[2];
            if (label.Text.Length >= 4 && label.Text.Substring(0, 4) == "[震动]")
                ZD();
            else if (label.Text.Length >= 4 && label.Text.Substring(0, 4) == "[文件]")
            {
                DuiBaseControl dui = (DuiBaseControl)sender;
                saveFilePath = ChatInfoDataDeal.getSavePath(loginAnswerSource.cardID, dui.Name);
                saveFileName = label.Text.Substring(4, label.Text.Length - 4);
                saveFileKey = dui.Name;
                if (saveFilePath == "")
                    打开ToolStripMenuItem.Enabled = false;
                else
                    打开ToolStripMenuItem.Enabled = true;

                contextFile.Show(MousePosition);
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFilePath != "")
            {
                try
                {
                    Process.Start(saveFilePath);
                }
                catch (Exception)
                {
                    MyMessageBox.Show("打开失败，文件已移动。", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 取消显示contextFile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            contextFile.Hide();
        }

        /// <summary>
        /// 将文件下载到默认位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFilePath = ConfigXml.selectConfigXML(loginAnswerSource.cardID + "文件保存路径") + "\\" + saveFileName;
            ChatInfoDataDeal.setSavePath(loginAnswerSource.cardID, saveFileKey, saveFilePath);
            serverMain.SendData(new StructGetInfo(TransType.FileRequest,
                     new FileRequest(saveFileKey)));
        }

        /// <summary>
        /// 文件另存为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = ConfigXml.selectConfigXML(loginAnswerSource.cardID + "文件保存路径");
            sfd.Title = "保存文件";
            string type = saveFileName.Split('.')[1];
            sfd.Filter = type + "文件|*." + type;
            sfd.ShowDialog(this);
            saveFilePath = sfd.FileName;
            if (saveFilePath.Length != 0)
            {
                ChatInfoDataDeal.setSavePath(loginAnswerSource.cardID, saveFileKey, saveFilePath);
                serverMain.SendData(new StructGetInfo(TransType.FileRequest,
                         new FileRequest(saveFileKey)));
            }
        }

        /// <summary>
        /// 文件资源描述串
        /// </summary>
        public string saveFileKey = "";
        /// <summary>
        /// 文件保存路径
        /// </summary>
        public string saveFilePath = "";
        /// <summary>
        /// 文件保存名称
        /// </summary>
        public string saveFileName = "";
        /// <summary>
        /// 获得文件
        /// </summary>
        private void getFile(string fileKey)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = ConfigXml.selectConfigXML(loginAnswerSource.cardID + "文件保存路径");
            sfd.Title = "保存文件";
            string type = saveFileName.Split('.')[1];
            sfd.Filter = type + "文件|*." + type;
            sfd.ShowDialog(this);
            saveFilePath = sfd.FileName;
            if (saveFilePath.Length != 0)
                serverMain.SendData(new StructGetInfo(TransType.FileRequest,
                     new FileRequest(fileKey)));
        }
        /// <summary>
        /// 窗口震动
        /// </summary>
        public void ZD()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(20);
                if (i % 2 == 1)
                {
                    this.Location = new Point(this.Location.X - 5, this.Location.Y - 5);
                }
                else
                {
                    this.Location = new Point(this.Location.X + 5, this.Location.Y + 5);
                }
            }
        }

        /// <summary>
        /// 上一次发送消息时间
        /// </summary>
        private string lastSecond = "";
        /// <summary>
        /// 发送震动：震动，写库，显示，发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZDMessage_Click(object sender, EventArgs e)
        {
            //1
            ZD();
            //2
            MessageInform messageInform = new MessageInform();
            messageInform.cardID = loginAnswerSource.cardID;
            messageInform.IDType = 0;
            messageInform.fCardID = clickItemChat.Name.Substring(0, 10);
            messageInform.fIDType = 0;
            byte sendType = 1;
            if (clickItemChat.Name[10] == '1')
            {
                messageInform.fIDType = 1;
                sendType = 3;
            }

            messageInform.time = ToolUnion.getTimeStamp();
            messageInform.second = ToolUnion.getSecond();
            while (messageInform.second == lastSecond)
            {
                Thread.Sleep(10);
                messageInform.second = ToolUnion.getSecond();
            }
            lastSecond = messageInform.second;

            messageInform.type = 1;
            messageInform.info = "";
            Thread thread1 = new Thread(ChatInfoDataDeal.InsertMessageOut);
            thread1.IsBackground = true;
            thread1.Start(new object[] { messageInform, BaseDataDeal.getConnString($@"cookie\userdata\{loginAnswerSource.cardID}\info.db3") });
            //3
            listBoxMessage.Items.Add(addItemMessage(new strMessageShow("$$$$$$$$$$", messageInform.time, sendType
                , 1, "")));
            listBoxMessage.Value = 1;
            //4
            serverMain.SendData(new StructGetInfo(TransType.MessageInform, messageInform));
        }

        /// <summary>
        /// 发送文字：写库，显示，发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSendMessage_Click(object sender, EventArgs e)
        {
            //1
            MessageInform messageInform = new MessageInform();
            messageInform.cardID = loginAnswerSource.cardID;
            messageInform.IDType = 0;
            messageInform.fCardID = clickItemChat.Name.Substring(0, 10);
            messageInform.fIDType = 0;
            byte sendType = 1;
            if (clickItemChat.Name[10] == '1')
            {
                messageInform.fIDType = 1;
                sendType = 3;
            }

            messageInform.time = ToolUnion.getTimeStamp();
            messageInform.second = ToolUnion.getSecond();
            while (messageInform.second == lastSecond)
            {
                Thread.Sleep(10);
                messageInform.second = ToolUnion.getSecond();
            }
            lastSecond = messageInform.second;

            messageInform.type = 0;
            messageInform.info = textMessage.Text;
            Thread thread1 = new Thread(ChatInfoDataDeal.InsertMessageOut);
            thread1.IsBackground = true;
            thread1.Start(new object[] { messageInform, BaseDataDeal.getConnString($@"cookie\userdata\{loginAnswerSource.cardID}\info.db3") });
            //2
            listBoxMessage.Items.Add(addItemMessage(new strMessageShow("$$$$$$$$$$", messageInform.time, sendType
                , 0, messageInform.info)));
            listBoxMessage.Value = 1;
            //3
            serverMain.SendData(new StructGetInfo(TransType.MessageInform, messageInform));
            textMessage.Text = "";
        }

        /// <summary>
        /// 发送文件：写库，显示，新线程发送文件，发送文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileMessgae_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();
            string name = ofd.FileName;
            if (name.Length != 0)
            {
                //1写库
                MessageInform messageInform = new MessageInform();
                messageInform.cardID = loginAnswerSource.cardID;
                messageInform.IDType = 0;
                messageInform.fCardID = clickItemChat.Name.Substring(0, 10);
                messageInform.fIDType = 0;
                byte sendType = 1;
                if (clickItemChat.Name[10] == '1')
                {
                    messageInform.fIDType = 1;
                    sendType = 3;
                }

                messageInform.time = ToolUnion.getTimeStamp();
                messageInform.second = ToolUnion.getSecond();
                while (messageInform.second == lastSecond)
                {
                    Thread.Sleep(10);
                    messageInform.second = ToolUnion.getSecond();
                }
                lastSecond = messageInform.second;

                messageInform.type = 2;
                messageInform.info = System.IO.Path.GetFileName(name);
                byte ttype = 0;
                if (sendType == 3)
                    ttype = 1;
                string fileKey = messageInform.cardID + messageInform.fCardID + ttype.ToString()
                    + ToolUnion.timeStamp16to12(messageInform.time) + messageInform.second + "." + messageInform.info.Split('.')[1];
                messageInform.info = ToolUnion.getFixedLenStringFromString(fileKey, 48) + messageInform.info;
                Thread thread1 = new Thread(ChatInfoDataDeal.InsertMessageOut);
                thread1.IsBackground = true;
                thread1.Start(new object[] { messageInform, BaseDataDeal.getConnString($@"cookie\userdata\{loginAnswerSource.cardID}\info.db3") });
                //2显示
                listBoxMessage.Items.Add(addItemMessage(new strMessageShow("$$$$$$$$$$", messageInform.time, sendType
                    , 2, messageInform.info)));
                listBoxMessage.Value = 1;

                //3新线程上传文件
                Thread thread = new Thread(sendFile);
                thread.IsBackground = true;
                thread.Start(new object[] { fileKey, name });

                //4发送文本
                serverMain.SendData(new StructGetInfo(TransType.MessageInform, messageInform));
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="o"></param>
        private void sendFile(object o)
        {
            object[] temp = (object[])o;
            string fileKey = (string)temp[0];
            string fullPath = (string)temp[1];
            FileSubOrGet fileSubOrGet = new FileSubOrGet();
            fileSubOrGet.key = fileKey;
            fileSubOrGet.data = ToolUnion.getFileStreamFromFile(fullPath);
            serverMain.SendData(new StructGetInfo(TransType.FileSubOrGet,
                fileSubOrGet));
        }

        /// <summary>
        /// 好友发消息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfSend_Click(object sender, EventArgs e)
        {
            while (initChatStatusFinished == false)
            {
                Thread.Sleep(200);
            }
            if (linkChatItem.ContainsKey(labelfCardID.Text + "0") == false)
            {
                DuiBaseControl temp = addItemChat(labelfCardID.Text, 0);
                linkChatItem.Add(labelfCardID.Text + "0", temp);
                listBoxChat.Items.Add(temp);
                listBoxChat.RefreshList();
            }
            tabControl.SelectedTab = tabPageChat;
            itemsChatMouseClick(linkChatItem[labelfCardID.Text + "0"], new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
        }

        /// <summary>
        /// 群发消息按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btngSend_Click(object sender, EventArgs e)
        {
            while (initChatStatusFinished == false)
            {
                Thread.Sleep(200);
            }
            if (linkChatItem.ContainsKey(labelgID.Text + "1") == false)
            {
                DuiBaseControl temp = addItemChat(labelgID.Text, 1);
                linkChatItem.Add(labelgID.Text + "1", temp);
                listBoxChat.Items.Add(temp);
                listBoxChat.RefreshList();
            }
            tabControl.SelectedTab = tabPageChat;
            itemsChatMouseClick(linkChatItem[labelgID.Text + "1"], new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
        }

        /// <summary>
        /// 输入框回车=发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSendMessage_Click(sender, e);
            }
        }

        #endregion

        #region 聊天现场保存

        /// <summary>
        /// 保存聊天现场
        /// </summary>
        public void saveChatStatus()
        {
            string connStr = BaseDataDeal.getConnString($@"cookie\userdata\{loginAnswerSource.cardID}\info.db3");
            try
            {
                string sqlDele = "delete from chatStatus;";
                BaseDataDeal.update(sqlDele, connStr);
            }
            catch (Exception)
            {
            }
            foreach (DuiBaseControl item in linkChatItem.Values)
            {
                try
                {
                    string sql = $"insert into chatStatus values('{item.Name.Substring(0, 10)}', '{item.Name[10].ToString()}');";
                    BaseDataDeal.update(sql, connStr);
                }
                catch (Exception)
                {
                }
            }
        }

        public bool initChatStatusFinished = false;
        /// <summary>
        /// 加载聊天现场
        /// </summary>
        private void initChatStatus()
        {
            int cnt = 50;
            while ((initFriendFinished == false || initGroupFinished == false) && cnt-- != 0)
            {
                Thread.Sleep(100);
            }
            if (initFriendFinished && initGroupFinished)
            {
                string sql = $"select * from ChatStatus";
                string connStr = BaseDataDeal.getConnString($@"cookie\userdata\{loginAnswerSource.cardID}\info.db3");
                DataSet dataSet = BaseDataDeal.select(sql, connStr);
                while (linkChatItem == null)
                    Thread.Sleep(100);
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    string cardID = item[0].ToString();
                    byte type = 0;
                    if (item[1].ToString() == "1")
                    {
                        type = 1;
                        if (linkGroupItem.ContainsKey(cardID) == false)
                            continue;
                    }
                    else
                    {
                        if (linkFriendItem.ContainsKey(cardID) == false)
                            continue;
                    }
                    DuiBaseControl temp = addItemChat(cardID, type);
                    linkChatItem.Add(cardID + type.ToString(), temp);
                    listBoxChat.Items.Add(temp);
                }
            }
            listBoxChat.RefreshList();
            initChatStatusFinished = true;
        }

        #endregion

        /// <summary>
        /// 点击选中消息输入框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelMessageSend_Click(object sender, EventArgs e)
        {
            textMessage.Focus();
        }

        /// <summary>
        /// 消除回车按键声音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
            }
        }

        SmilPanel smilPanel = null;
        private void btnSmil_Click(object sender, EventArgs e)
        {
            smilPanel.Show();
            smilPanel.Location = new Point(this.Left + 237, this.Top + 195);
        }
    }
}