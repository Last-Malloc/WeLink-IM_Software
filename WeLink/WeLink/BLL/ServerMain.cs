using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink.DAL;
using LayeredSkin.DirectUI;
using WeLink.UI;

namespace WeLink.BLL
{
    /// <summary> 
    /// 在client中作为LoginForm的public成员变量
    /// </summary>
    public class ServerMain
    {
        #region 构造函数
        LoginForm loginForm = null;
        public GetRecSyncInfo getRecSyncInfo = null;
        public ServerMain(LoginForm loginForm)
        {
            this.loginForm = loginForm;
            getRecSyncInfo = new GetRecSyncInfo(this);
        }
        #endregion

        #region [属性]主/辅套接字，[方法]与服务器连接、断开连接
        public Socket socketSendMain = null;
        public Socket socketSendAssist = null;
        Semaphore socketSendMainSemaphore = new Semaphore(1, 1);
        Semaphore socketSendAssistSemaphore = new Semaphore(1, 1);
        /// <summary>
        /// 开启连接
        /// </summary>
        public void connect()
        {
            try 
            {
                //1.创建负责通信的Socket
                socketSendMain = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketSendAssist = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //获得连接的服务器的IP地址和端口号
                IPAndPort iPAndPort = LoginDataDeal.getIPAndPort();
                IPEndPoint pointMain = new IPEndPoint(iPAndPort.iPAddress, iPAndPort.portMain);
                IPEndPoint pointAssist = new IPEndPoint(iPAndPort.iPAddress, iPAndPort.portAssist);
                //2.连接远程服务器
                socketSendMain.Connect(pointMain);
                socketSendAssist.Connect(pointAssist);
                if (socketSendAssist.Connected == false || socketSendMain.Connected == false)
                {
                    throw new Exception();
                }
                //3.开启一个新的线程不停的接收服务端发来的消息
                Thread threadMain = new Thread(OnReceiveData);
                threadMain.IsBackground = true;
                threadMain.Start(socketSendMain);
                Thread threadAssist = new Thread(OnReceiveData);
                threadAssist.IsBackground = true;
                threadAssist.Start(socketSendAssist);
                loginForm.pallet.Icon = Properties.Resources.托盘图标_在线;
                loginForm.conItemConnect.Visible = false;
            }
            catch (Exception)
            {
                DialogResult dialogResult =  MyMessageBox.Show("网络连接失败，是否尝试重新连接？", "网络连接失败", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    Thread thread = new Thread(connect);
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public void disconnect()
        {
            try
            {
                loginForm.pallet.Icon = Properties.Resources.托盘图标_掉线;
                loginForm.conItemConnect.Visible = true;
            }
            catch (Exception)
            {
            }
            //关闭负责通信的socket
            try
            {
                socketSendMain.Close();
                socketSendMain = null;
            }
            catch (Exception)
            {
                    
            }
            try
            {
                socketSendAssist.Close();
                socketSendMain = null;
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region [重要]发送数据和接收数据时供外界检查的标志位和表示方法(最长等待2s，每100ms检查一次)
        //3为未获得，1为存在，0为不存在，使用下面的公有方法进行访问
        private LoginAnswer loginAnswer = new LoginAnswer(10, null);//(等待5s)登录申请的反馈,10代表没收到响应
        private byte idIsExist = 3;//账号是否存在
        private byte headPicSubmitRequestIsOk = 3;//向服务器发送头像是否成功
        private byte excuteUserRegiserSuccess = 3;//注册是否成功
        public string registerID = "";
        private byte excuteUInfoUpdateRequest = 3;//更新信息是否成功
        private GBriefMemInfoAnswer gBrief = new GBriefMemInfoAnswer();//(等待5s)群成员的反馈,其成员为null代表没收到响应
        private UserGroupInfoAnswer userGroupInfoAnswer = new UserGroupInfoAnswer();////(等待3s)用户/群信息的反馈,其成员为null代表没收到响应
        private byte groupRegisterSuccess = 2;//群申请结果
        public string registerGID = "";
        //群申请的反馈
        public byte checkGroupRegister()
        {
            int cnt = 0;
            while (groupRegisterSuccess == 2 && (cnt++) < 20)
            {
                Thread.Sleep(100);
            }
            return groupRegisterSuccess;
        }
        //登录申请的反馈
        public LoginAnswer checkLoginAnswer()
        {
            int cnt = 0;
            while (loginAnswer.loginSucOrNot == 10 && (cnt++) < 50)
            {
                Thread.Sleep(100);
            }
            if (loginAnswer.loginSucOrNot != 10)
                return loginAnswer;
            return new LoginAnswer(10, null);
        }
        //群成员的反馈
        public GBriefMemInfoAnswer checkGBriefMemInfoAnswer()
        {
            int cnt = 0;
            while (gBrief.gmCardID == null && (cnt++) < 50)
            {
                Thread.Sleep(100);
            }
            return gBrief;
        }
        //用户/群信息的反馈
        public UserGroupInfoAnswer checkUserGroupInfoAnswer()
        {
            int cnt = 0;
            while (userGroupInfoAnswer.cardID == null && (cnt++) < 30)
            {
                Thread.Sleep(100);
            }
            return userGroupInfoAnswer;
        }
        //账号是否可用（未被注册)
        public bool checkIdIsOK()
        {
            int cnt = 0;
            while (idIsExist == 3 && (cnt++) < 20)
            {
                Thread.Sleep(100);
            }
            if (idIsExist == 0)
                return true;
            return false;
        }
        //上交头像图片是否成功
        public bool checkHeadPicSubmitRequestIsOk()
        {
            int cnt = 0;
            while (headPicSubmitRequestIsOk == 3 && (cnt++) < 20)
            {
                Thread.Sleep(100);
            }
            if (headPicSubmitRequestIsOk == 1)
                return true;
            return false;
        }
        //注册是否成功
        public bool checkExcuteUserRegisterSuccess()
        {
            int cnt = 0;
            while (excuteUserRegiserSuccess == 3 && (cnt++) < 20)
            {
                Thread.Sleep(100);
            }
            if (excuteUserRegiserSuccess == 1)
                return true;
            return false;
        }
        //更新信息是否成功
        public bool checkExcuteUInfoUpdateRequest()
        {
            int cnt = 0;
            while (excuteUInfoUpdateRequest == 3 && (cnt++) < 20)
            {
                Thread.Sleep(100);
            }
            if (excuteUInfoUpdateRequest == 1)
                return true;
            return false;
        }
        #endregion

        #region 发送数据和接收数据的响应
        public bool netIsOkWhenClientRun = false;
        /// <summary>
        /// 处理收到的数据（包括对socket的主动关闭、被动关闭及相应处理）
        /// </summary>
        public void OnReceiveData(object o)
        {
            bool isMainSocket = false;//该socket是否为与主端口通信的socket
            Socket socketSend = (Socket)o;
            try
            {
                if (socketSend.RemoteEndPoint.ToString() == socketSendMain.RemoteEndPoint.ToString())
                    isMainSocket = true;
                netIsOkWhenClientRun = true;
                while (true)
                {
                    StructGetInfo structGetInfo = Protocol.get(socketSend);
                    //频繁更改区域 对收到的复合数据类型 分类进行 相应的响应
                    switch (structGetInfo.type)
                    {
                        case TransType.LoginAnswer: OnReceiveLoginAnswer((LoginAnswer)structGetInfo.data); break;
                        case TransType.IdIsExistAnswer: OnReceiveIdIsExitAnswer((IdIsExistAnswer)structGetInfo.data); break;
                        case TransType.HeadPicSubmitAnswer: OnReceiveHeadPicSubmitAnswer((HeadPicSubmitAnswer)structGetInfo.data); break;
                        case TransType.HeadPicGetAnswer: OnReceiveHeadPicGetAnswer((HeadPicGetAnswer)structGetInfo.data); break;
                        case TransType.UserRegisterAnswer: OnReceiveUserRegisterAnswer((UserRegisterAnswer)structGetInfo.data); break;
                        case TransType.UInfoUpdateAnswer: OnReceiveUInfoUpdateAnswer((UInfoUpdateAnswer)structGetInfo.data); break;
                        case TransType.FriendGroupStatus: OnReceiveFriendGroupStatus((FriendGroupStatus)structGetInfo.data); break;
                        case TransType.InOutStatus: OnReceiveInOutStatus((InOutStatus)structGetInfo.data); break;
                        case TransType.FriendInfoAnswer: OnReceiveFriendInfoAnswer((FriendInfoAnswer)structGetInfo.data); break;
                        case TransType.GroupRegisterAnswer:
                            GroupRegisterAnswer answer = (GroupRegisterAnswer)structGetInfo.data;
                            groupRegisterSuccess = answer.result;
                            registerGID = answer.gID;
                            break;
                        case TransType.GroupInfoAnswer: OnReceiveGroupInfoAnswer((GroupInfoAnswer)structGetInfo.data); break;
                        case TransType.GBriefMemInfoAnswer: OnReceiveGBriefMemInfoAnswer((GBriefMemInfoAnswer)structGetInfo.data); break;
                        case TransType.UserGroupInfoAnswer: OnReceiveUserGroupInfoAnswer((UserGroupInfoAnswer)structGetInfo.data); break;
                        case TransType.ADRequestInform: OnReceiveADRequestInform((ADRequestInform)structGetInfo.data); break;
                        case TransType.MessageInform: OnReceiveMessageInform((MessageInform)structGetInfo.data); break;
                        case TransType.FileSubOrGet: OnReceiveFileSubOrGet((FileSubOrGet)structGetInfo.data); break;
                        case TransType.ErrorType: break;
                    }
                    ///频繁更改区域
                }
            }
            catch (Exception)
            {
                DialogResult dialogResult = DialogResult.Cancel;//是否尝试重新连接
                //处理下层抛出的异常（负责通信的socket被关闭）
                if (isMainSocket)
                {
                    dialogResult =  MyMessageBox.Show("网络连接失败，是否尝试重新连接？", "网络连接失败", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                disconnect();
                if (isMainSocket && dialogResult == DialogResult.OK)
                {
                    Thread thread = new Thread(connect);
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }

        #region 各组合数据类型 的 OnReceiveData方法

        #region 聊天处理集合

        /// <summary>
        /// 保存最先接收到的消息
        /// </summary>
        public strMessageShow newMessage;

        /// <summary>
        /// 接收到消息：入库，更新聊天列表的消息数量显示
        /// </summary>
        /// <param name="messageInform"></param>
        private void OnReceiveMessageInform(MessageInform messageInform)
        {
            MainForm mainForm = loginForm.mainForm;
            //等待登录
            while (mainForm == null)
            {
                Thread.Sleep(1000);
                mainForm = loginForm.mainForm;
            }

            Thread threadd = null;
            //收到震动后窗口震动
            if (messageInform.type == 1)
            {
                threadd = new Thread(mainForm.ZD);
                threadd.IsBackground = true;
                threadd.Start();
            }

            //刷新数量显示
            byte sendType = 0;
            if (messageInform.fIDType == 1)
                sendType = 2;
            newMessage = new strMessageShow(messageInform.cardID, messageInform.time, sendType, messageInform.type, messageInform.info);
            if (messageInform.fIDType == 0)
            {
                mainForm.refreshChatCnt(messageInform.cardID, 0);
            }
            else
            {
                mainForm.refreshChatCnt(messageInform.fCardID, 1);
            }

            //消息入库
            Thread thread = new Thread(ChatInfoDataDeal.InsertMessageIn);
            thread.IsBackground = true;
            thread.Start(new object[] { messageInform, BaseDataDeal.getConnString($@"cookie\userdata\{loginAnswer.cardID}\info.db3") });

        }

        /// <summary>
        /// 接收到文件传送
        /// </summary>
        /// <param name="fileSubOrGet"></param>
        private void OnReceiveFileSubOrGet(FileSubOrGet fileSubOrGet)
        {
            try
            {
                MainForm mainForm = loginForm.mainForm;
                //等待登录
                while (mainForm == null)
                {
                    Thread.Sleep(1000);
                    mainForm = loginForm.mainForm;
                }

                if (File.Exists(mainForm.saveFilePath))
                {
                    File.Delete(mainForm.saveFilePath);
                }
                using (FileStream fsWrite = new FileStream(mainForm.saveFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fsWrite.Write(fileSubOrGet.data, 10, fileSubOrGet.data.Length - 10);
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 好友/群 添加/删除 处理集合

        /// <summary>
        /// 收到 添加/删除 申请/通知 的 处理
        /// 类型有：1添加申请（好友/群 延时/即时)
        /// 2删除好友通知、3退出群通知、4被移出群通知、5群解散通知
        /// 6申请被同意或拒绝通知
        /// </summary>
        /// <param name="aDRequestInform"></param>
        private void OnReceiveADRequestInform(ADRequestInform aDRequestInform)
        {
            MainForm mainForm = loginForm.mainForm;
            //等待登录
            while (mainForm == null)
            {
                Thread.Sleep(1000);
                mainForm = loginForm.mainForm;
            }

            //1添加申请（好友 / 群 延时 / 即时)：添加显示
            if (aDRequestInform.type == 0 || aDRequestInform.type == 10)
            {
                if (aDRequestInform.fIDType == 0)
                {
                    mainForm.informFriendCookie.Add(aDRequestInform);
                }
                else
                {
                    mainForm.informGroupCookie.Add(aDRequestInform);
                }
                if (aDRequestInform.type == 0)
                {
                    mainForm.initFriendInfomCnt();
                    mainForm.initGroupInfomCnt();
                }
            }
            //2删除好友通知：显示通知并更新本地好友列表
            else if (aDRequestInform.type == 1 && aDRequestInform.IDType == 0 && aDRequestInform.fIDType == 0)
            {
                MyMessageBox.Show(aDRequestInform.info, "删除通知");
                if (mainForm.linkChatItem.ContainsKey(aDRequestInform.cardID + "0"))
                {
                    mainForm.linkChatItem.Remove(aDRequestInform.cardID + "0");
                    mainForm.initMessageShowForm();
                    mainForm.refreshLinkChat();
                }
                mainForm.linkFriendItem.Remove(aDRequestInform.cardID);
                int index = aDRequestInform.info.IndexOf('(');
                mainForm.linkNameFriend.Remove(aDRequestInform.info.Substring(0, index));
                mainForm.refreshLinkFriend();
            }
            //3退出群通知：显示通知（提示群主创建的群有人员退出）
            else if (aDRequestInform.type == 1 && aDRequestInform.IDType == 0 && aDRequestInform.fIDType == 1)
            {
                MyMessageBox.Show(aDRequestInform.info, "退群通知");
            }
            //4被移出群通知：显示通知并更新本地群列表
            else if (aDRequestInform.type == 1 && aDRequestInform.IDType == 1 && aDRequestInform.fIDType == 0)
            {
                MyMessageBox.Show(aDRequestInform.info, "删除通知");
                if (mainForm.linkChatItem.ContainsKey(aDRequestInform.cardID + "1"))
                {
                    mainForm.linkChatItem.Remove(aDRequestInform.cardID + "1");
                    mainForm.initMessageShowForm();
                    mainForm.refreshLinkChat();
                }
                mainForm.linkGroupItem.Remove(aDRequestInform.cardID);
                int index = aDRequestInform.info.IndexOf('(');
                mainForm.linkNameGroup.Remove(aDRequestInform.info.Substring(0, index));
                mainForm.refreshLinkGroup();
            }
            //5群解散通知：显示通知并更新本地群列表
            else if (aDRequestInform.type == 2 && aDRequestInform.IDType == 1)
            {
                MyMessageBox.Show(aDRequestInform.info, "解散通知");
                if (mainForm.linkChatItem.ContainsKey(aDRequestInform.cardID + "1"))
                {
                    mainForm.linkChatItem.Remove(aDRequestInform.cardID + "1");
                    mainForm.initMessageShowForm();
                    mainForm.refreshLinkChat();
                }
                mainForm.linkGroupItem.Remove(aDRequestInform.cardID);
                int index = aDRequestInform.info.IndexOf('(');
                mainForm.linkNameGroup.Remove(aDRequestInform.info.Substring(0, index));
                mainForm.refreshLinkGroup();
            }
            //6申请被同意或拒绝通知：显示通知，同意则更新好友/群列表(发送好友/群信息申请)
            else if (aDRequestInform.type == 20 || aDRequestInform.type == 30)
            {
                MyMessageBox.Show(aDRequestInform.info, "添加结果");
                if (aDRequestInform.type == 20)
                {
                    Thread thread = new Thread(updateAfterAddSuccess);
                    thread.IsBackground = true;
                    thread.Start(new object[] { aDRequestInform.fCardID, aDRequestInform.fIDType});
                }
            }
        }

        /// <summary>
        /// 收到添加申请通过通知时更新本地列表的线程
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        private void updateAfterAddSuccess(object o)
        {
            object[] temp = (object[])o;
            string id = (string)temp[0];
            byte type = (byte)temp[1];
            MainForm mainForm = loginForm.mainForm;
            //等待登录
            while (mainForm == null)
            {
                Thread.Sleep(1000);
                mainForm = loginForm.mainForm;
            }
            LoginAnswer loginAnswer = mainForm.loginAnswerSource;
            SendData(new StructGetInfo(TransType.FriendGroupInfoRequest,
                new FriendGroupInfoRequest(loginAnswer.cardID, id, type)));
            //列表的更新在OnReceiveFriendInfoAnswer
            //和OnReceiceGroupInfoAnswer中判断实现
        }

        #endregion

        private void OnReceiveUserGroupInfoAnswer(UserGroupInfoAnswer userGroupInfoAnswer)
        {
            this.userGroupInfoAnswer = userGroupInfoAnswer;
        }
        private void OnReceiveLoginAnswer(LoginAnswer loginAnswer)
        {
            this.loginAnswer = loginAnswer;
        }
        private void OnReceiveIdIsExitAnswer(IdIsExistAnswer idIsExistAnswer)
        {
            idIsExist = idIsExistAnswer.result;
        }
        private void OnReceiveHeadPicSubmitAnswer(HeadPicSubmitAnswer headPicSubmitAnswer)
        {
            headPicSubmitRequestIsOk = headPicSubmitAnswer.result;
            //头像上传失败
            if (headPicSubmitAnswer.result == 0)
            {
                string pathPng = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + headPicSubmitAnswer.cardID + ".png";
                string pathJpg = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + headPicSubmitAnswer.cardID + ".jpg";
                //删除本地的缓存的jpg和png
                if (File.Exists(pathPng))
                {
                    File.Delete(pathPng);
                }
                if (File.Exists(pathJpg))
                {
                    File.Delete(pathJpg);
                }
            }
        }
        private void OnReceiveHeadPicGetAnswer(HeadPicGetAnswer headPicGetAnswer)
        {
            if (headPicGetAnswer.result == 1)
            {
                ToolUnion.getHeadPicFromFileStream(headPicGetAnswer.cardID, headPicGetAnswer.fileData);
            }
        }
        private void OnReceiveUserRegisterAnswer(UserRegisterAnswer userRegisterAnswer)
        {
            registerID = userRegisterAnswer.cardID;
            excuteUserRegiserSuccess = userRegisterAnswer.result;
        }
        private void OnReceiveUInfoUpdateAnswer(UInfoUpdateAnswer uInfoUpdateAnswer)
        {
            excuteUInfoUpdateRequest = uInfoUpdateAnswer.result;
        }
        private void OnReceiveFriendGroupStatus(FriendGroupStatus friendGroupStatus)
        {
            try
            {
                MainForm mainForm = loginForm.mainForm;
                //等待登录
                while (mainForm == null)
                {
                    Thread.Sleep(1000);
                    mainForm = loginForm.mainForm;
                }
                //填充linkFriendItem
                Dictionary<string, DuiBaseControl> tf = mainForm.linkFriendItem;
                Dictionary<string, DuiBaseControl> tg = mainForm.linkGroupItem;
                Dictionary<string, string> nf = mainForm.linkNameFriend;
                Dictionary<string, string> ng = mainForm.linkNameGroup;
                tf.Clear();
                tg.Clear();
                nf.Clear();
                ng.Clear();
                int len = friendGroupStatus.arrCardID.Length;
                for (int i = 0; i < len; i++)
                {
                    byte online = friendGroupStatus.arrOnline[i];
                    string cardID = friendGroupStatus.arrCardID[i];
                    string remark = friendGroupStatus.arrRemark[i];
                    //该条为群记录
                    if (online == 2)
                    {
                        tg.Add(cardID, mainForm.addItemGroup(cardID, remark));
                        try
                        {
                            ng.Add(remark, cardID);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    else
                    {
                        //该条为好友记录
                        tf.Add(cardID, mainForm.addItem(cardID, remark, online));
                        try
                        {
                            nf.Add(remark, cardID);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                //刷新显示
                mainForm.refreshLinkFriend();
                mainForm.refreshLinkGroup();
            }
            catch (Exception)
            {
            }
        }
        private void OnReceiveInOutStatus(InOutStatus inOutStatus)
        {
            try
            {
                MainForm mainForm = loginForm.mainForm;
                //等待登录
                while (mainForm == null)
                {
                    Thread.Sleep(1000);
                    mainForm = loginForm.mainForm;
                }

                DuiBaseControl duiBaseControl = mainForm.linkFriendItem[inOutStatus.cardID];
                //好友上线
                if (inOutStatus.status == 1)
                {
                    mainForm.getRecSyncInfo.setHeadPicForBaseControl((DuiBaseControl)duiBaseControl.Controls[0], inOutStatus.cardID);
                    ((DuiBaseControl)duiBaseControl.Controls[2]).BackgroundImage = Properties.Resources.在线;
                }
                else
                {
                    //好友离线
                    mainForm.getRecSyncInfo.setHeadPicForBaseControl((DuiBaseControl)duiBaseControl.Controls[0], inOutStatus.cardID, 1);
                    ((DuiBaseControl)duiBaseControl.Controls[2]).BackgroundImage = Properties.Resources.离线;
                }
            }
            catch (Exception)
            {
            }
        }
        private void OnReceiveFriendInfoAnswer(FriendInfoAnswer friendInfoAnswer)
        {
            MainForm mainForm = loginForm.mainForm;
            //等待登录
            while (mainForm == null)
            {
                Thread.Sleep(1000);
                mainForm = loginForm.mainForm;
            }
            //若本地好友列表中有该收到信息的好友，则为获取该好友信息
            //否则为添加好友成功后的列表更新
            if (mainForm.linkFriendItem.ContainsKey(friendInfoAnswer.cardID))
                mainForm.setFriendInfo(friendInfoAnswer);
            else
            {
                mainForm.linkFriendItem.Add(friendInfoAnswer.cardID, 
                    mainForm.addItem(friendInfoAnswer.cardID, friendInfoAnswer.remark, 1));
                try
                {
                    mainForm.linkNameFriend.Add(friendInfoAnswer.remark, friendInfoAnswer.cardID);
                }
                catch (Exception)
                {
                }
                mainForm.refreshLinkFriend();
            }
        }
        private void OnReceiveGroupInfoAnswer(GroupInfoAnswer groupInfoAnswer)
        {
            MainForm mainForm = loginForm.mainForm;
            //等待登录
            while (mainForm == null)
            {
                Thread.Sleep(1000);
                mainForm = loginForm.mainForm;
            }
            //若本地群列表中有该收到信息的群，则为获取该群信息
            //否则为加入群成功后的列表更新
            if (mainForm.linkGroupItem.ContainsKey(groupInfoAnswer.gID))
                mainForm.setGroupInfo(groupInfoAnswer);
            else
            {
                mainForm.linkGroupItem.Add(groupInfoAnswer.gID,
                    mainForm.addItemGroup(groupInfoAnswer.gID,groupInfoAnswer.gName));
                try
                {
                    mainForm.linkNameGroup.Add(groupInfoAnswer.gName, groupInfoAnswer.gID);
                }
                catch (Exception)
                {
                }
                mainForm.refreshLinkGroup();
            }
        }
        private void OnReceiveGBriefMemInfoAnswer(GBriefMemInfoAnswer gBriefMemInfoAnswer)
        {
            gBrief = gBriefMemInfoAnswer;
        }
        #endregion

        /// <summary>
        /// 通过设置 复合数据结构 传送数据(套接字将根据发送数据类型由程序决定)
        /// [重要]包含发送前预处理
        /// </summary>
        public bool SendData(StructGetInfo structGetInfo)
        {
            bool flag = false;
            Socket socketSend = null;
            try
            {
                switch (structGetInfo.type)
                {
                    //频繁更改区域 选择发送端口
                    case TransType.LogOut: socketSend = socketSendMain; break;
                    case TransType.LoginRequest: socketSend = socketSendMain; loginAnswer = new LoginAnswer(10, null); break;
                    case TransType.IdIsExistRequest: socketSend = socketSendMain; idIsExist = 3; break;
                    case TransType.HeadPicSubmitRequest:
                        socketSend = socketSendAssist;
                        headPicSubmitRequestIsOk = 3;
                        //将头像文件复制到头像缓存文件夹中
                        HeadPicSubmitRequest h = (HeadPicSubmitRequest)(structGetInfo.data);
                        object[] th = new object[] { h.cardID, h.path };
                        Thread thread = new Thread(fun1);
                        thread.IsBackground = true;
                        thread.Start(th);
                        break;
                    case TransType.HeadPicGetRequest: socketSend = socketSendAssist; break;
                    case TransType.UserRegisterRequest: socketSend = socketSendMain; excuteUserRegiserSuccess = 3; break;
                    case TransType.UInfoUpdateRequest: socketSend = socketSendMain; excuteUInfoUpdateRequest = 3; break;
                    case TransType.FriendGroupInfoRequest: socketSend = socketSendMain; gBrief.gmCardID = null; break;
                    case TransType.GroupInfoAnswer: socketSend = socketSendMain; groupRegisterSuccess = 2; break;
                    case TransType.FGInfoUpdateRequest: socketSend = socketSendMain; break;
                    case TransType.UserGroupInfoRequest: socketSend = socketSendMain; userGroupInfoAnswer.cardID = null; break;
                    case TransType.ADRequestInform: socketSend = socketSendMain; break;
                    case TransType.AddDeleDeal: socketSend = socketSendMain; break;
                    case TransType.MessageInform: socketSend = socketSendMain; break;
                    case TransType.FileSubOrGet: socketSend = socketSendAssist; break;
                    case TransType.FileRequest: socketSend = socketSendMain; break;
                    case TransType.ErrorType: break;
                    ///频繁更改区域
                }
                if (structGetInfo.type != TransType.ErrorType)
                {
                    if (socketSend == socketSendMain)
                        flag = Protocol.set(socketSend, structGetInfo, socketSendMainSemaphore);
                    else
                        flag = Protocol.set(socketSend, structGetInfo, socketSendAssistSemaphore);
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }
       
        #endregion

        #region 临时线程方法

        /// <summary>
        /// 发送头像提交申请后的图片复制操作
        /// </summary>
        /// <param name="o"></param>
        void fun1(object o)
        {
            Thread.Sleep(1000);
            object[] t = (object[])o;
            string tID = t[0].ToString();
            string tPath = t[1].ToString();
            string pathPng = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + tID + ".png";
            string pathJpg = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + tID + ".jpg";
            //删除本地的缓存的jpg和png
            if (File.Exists(pathPng))
            {
                File.Delete(pathPng);
            }
            if (File.Exists(pathJpg))
            {
                File.Delete(pathJpg);
            }
            ToolUnion.copyFile(tPath, Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + tID);
        }

        #endregion
    }
}
