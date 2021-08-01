using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink_Server.UI;
using WeLink_Server.DAL;
using System.IO;
using System.Drawing;
using MySql.Data.MySqlClient;

namespace WeLink_Server.BLL
{
    //用于为新线程传递参数，包括监听socket及其类型Main/Assist
    struct WatchSocketTypeAndSocket
    {
        public WatchSocketType watchSocketType;
        public Socket socketWatch;
        public WatchSocketTypeAndSocket(WatchSocketType watchSocketType, Socket socketWatch)
        {
            this.watchSocketType = watchSocketType;
            this.socketWatch = socketWatch;
        }
    }

    class ServerMain_Server
    {
        #region 与UI层交互：写日志记录框（writeLogs:private）、初始化和窗口加载

        /// <summary>
        /// 向UI层写日志记录框
        /// </summary>
        /// <param name="str"></param>
        private void writeLogs(string str)
        {
            try
            {
                mainForm.writeLogs(str);
            }
            catch (Exception)
            {
            }
        }

        MainForm mainForm = null;
        public ServerMain_Server(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        #endregion

        #region 服务器的开启和关闭
        Socket socketWatchMain = null;//主端口监听套接字
        Socket socketWatchAssist = null;//辅端口监听套接字
        Thread threadMainListen = null;//主端口监听线程
        Thread threadAssistListen = null;//辅端口监听线程
        Dictionary<string, Socket> sendSocketList = null;//仍在连接的套接字的地址和socket
        Dictionary<string, Semaphore> sendSocketSemaphore = null;
        /// <summary>
        /// 开启服务器，监听端口
        /// </summary>
        /// <param name="portMain"></param>
        /// <param name="portAssist"></param>
        public void startServer(int portMain, int portAssist)
        {
            try
            {
                writeLogs("服务器开启中...");
                sendSocketList = new Dictionary<string, Socket>();//初始化
                sendSocketSemaphore = new Dictionary<string, Semaphore>();
                //1.创建负责监听的socket
                //当点击开始监听按钮的时候，在服务器端创建一个负责监听 IP地址跟端口号 的Socket
                socketWatchMain = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketWatchAssist = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //创建端口号对象
                IPAddress ip = IPAddress.Any;
                IPEndPoint pointMain = new IPEndPoint(ip, portMain);
                IPEndPoint pointAssist = new IPEndPoint(ip, portAssist);
                //2.socket绑定监听端口
                socketWatchMain.Bind(pointMain);
                writeLogs("端口" + pointMain + "开启成功");
                socketWatchAssist.Bind(pointAssist);
                writeLogs("端口" + pointAssist + "开启成功");
                //3.设置监听队列
                //同一时间只能监听50个客户端请求，多的排队
                socketWatchMain.Listen(50);
                socketWatchAssist.Listen(50);

                //封装套接字即其类型，为Listen函数传递参数
                WatchSocketTypeAndSocket wSYASMain = new WatchSocketTypeAndSocket(WatchSocketType.Main, socketWatchMain);
                WatchSocketTypeAndSocket wSYASAssist = new WatchSocketTypeAndSocket(WatchSocketType.Assist, socketWatchAssist);

                //4.创建新线程监听客户端连接
                threadMainListen = new Thread(Listen);
                threadMainListen.IsBackground = true;
                threadMainListen.Start(wSYASMain);
                threadAssistListen = new Thread(Listen);
                threadAssistListen.IsBackground = true;
                threadAssistListen.Start(wSYASAssist);
                writeLogs("服务器开启成功");
            }
            catch (Exception)
            {
                writeLogs("服务器开启失败");
            }
        }

        /// <summary>
        /// 等待监听客户端的连接并创建和保存与之通信用的socket
        /// </summary>
        /// <param name="o"></param>
        private void Listen(object o)
        {
            try
            {
                WatchSocketTypeAndSocket watchSocketTypeAndSocket = (WatchSocketTypeAndSocket)o;
                WatchSocketType watchSocketType = watchSocketTypeAndSocket.watchSocketType;
                Socket socketWatch = watchSocketTypeAndSocket.socketWatch;
                while (true)
                {
                    //循环等待客户端的连接（阻塞等待），并且返回一个负责通信的socket
                    Socket socketSend = socketWatch.Accept();
                    sendSocketList.Add(socketSend.RemoteEndPoint.ToString(), socketSend);
                    sendSocketSemaphore.Add(socketSend.RemoteEndPoint.ToString(), new Semaphore(1, 1));

                    //显示连接服务器的客户端ip地址和端口号
                    if (watchSocketType == WatchSocketType.Main)
                        writeLogs("客户端" + socketSend.RemoteEndPoint.ToString() + "：连接成功[主]");
                    else
                        writeLogs("客户端" + socketSend.RemoteEndPoint.ToString() + "：连接成功[辅]");

                    //5.创建新线程接收客户端消息，参数为负责通信的Socket及获得该Socket的端口类型：主/辅
                    WatchSocketTypeAndSocket socketTypeAndSocket = new WatchSocketTypeAndSocket(watchSocketType, socketSend);
                    Thread thread = new Thread(OnReceiveData);
                    thread.IsBackground = true;
                    thread.Start(socketTypeAndSocket);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 关闭服务器
        /// </summary>
        /// <param name="o"></param>
        public void stopServer()
        {
            try
            {
                writeLogs("服务器关闭中...");
                //在线用户清空显示清空
                try
                {
                    foreach (string item in KeyValue.kvIdSocMain.Keys)
                    {
                        try
                        {
                            mainForm.deleteFromDgvLoginUserInfo(item);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                catch (Exception)
                {
                }

                //关闭负责通信的socket，OnReceiveData线程将被终止
                foreach (Socket i in sendSocketList.Values)
                {
                    i.Close();
                }
                sendSocketList.Clear();
                sendSocketSemaphore.Clear();

                //关闭负责监听的socket，Listen线程将被终止
                socketWatchMain.Close();
                socketWatchAssist.Close();

                writeLogs("服务器关闭成功");
                //写入txt文件
                writeLogs("endServer");

                //销毁数据库连接池
                try
                {
                    ConnectionPool.destoryPool();
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

        #region 发送数据和接收数据的响应

        /// <summary>
        /// 处理收到的数据（包括对用于通信的socket被关闭时的处理）
        /// </summary>
        public void OnReceiveData(object socketTypeAndSocket)
        {
            //负责通信的socket
            WatchSocketTypeAndSocket temp = (WatchSocketTypeAndSocket)socketTypeAndSocket;
            Socket socketSend = temp.socketWatch;
            WatchSocketType watchSocketType = temp.watchSocketType;
            //负责通信的socket的描述符
            string str = socketSend.RemoteEndPoint.ToString();

            try
            {
                while (true)
                {
                    StructGetInfo structGetInfo = Protocol.get(socketSend);

                    //频繁更改区域 对收到的复合数据类型 分类进行 相应的响应
                    switch (structGetInfo.type)
                    {
                        //向发送方返回客户端登录请求的执行结果，登录成功在UI层进行显示
                        case TransType.LogOut: OnReceiveLogOutData(str, watchSocketType); break;
                        case TransType.LoginRequest: OnReceiveLoginRequestData((LoginRequest)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.IdIsExistRequest: OnReceiveIdIsExistRequestData((IdIsExistRequest)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.HeadPicSubmitRequest: OnReceiveHeadPicSubmitRequestData((HeadPicSubmitRequest)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.HeadPicGetRequest: OnReceiveHeadPicGetRequestData((HeadPicGetRequest)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.UserRegisterRequest: OnReceiveUserRegisterRequestData((UserRegisterRequest)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.UInfoUpdateRequest: OnReceiveUInfoUpdateRequestData((UInfoUpdateRequest)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.FriendGroupInfoRequest: OnReceiveFriendGroupInfoRequestData((FriendGroupInfoRequest)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.GroupInfoAnswer: OnReceiveGroupInfoAnswerData((GroupInfoAnswer)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.FGInfoUpdateRequest: OnReceiveFGInfoUpdateRequestData((FGInfoUpdateRequest)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.UserGroupInfoRequest: OnReceiveUserGroupInfoRequestData((UserGroupInfoRequest)structGetInfo.data, socketSend, watchSocketType); break;
                        case TransType.ADRequestInform: OnReceiveADRequestInformData((ADRequestInform)structGetInfo.data); break;
                        case TransType.AddDeleDeal: OnReceiveAddDeleDealData((AddDeleDeal)structGetInfo.data); break;
                        case TransType.MessageInform: OnReceiveMessageInformData((MessageInform)structGetInfo.data); break;
                        case TransType.FileSubOrGet: OnReceiveFileSubOrGetData((FileSubOrGet)structGetInfo.data); break;
                        case TransType.FileRequest: OnReceiveFileRequestData((FileRequest)structGetInfo.data, socketSend); break;
                        case TransType.ErrorType: break;
                    }
                    //频繁更改区域
                    
                }
            }
            catch (Exception)
            {
                try
                {
                    //负责通信的socket被关闭后序操作：
                    //1.确认关闭
                    try
                    {
                        socketSend.Close();
                    }
                    catch (Exception)
                    {
                    }

                    //2.写操作日志、关闭与客户端连接的另外一个端口
                    if (watchSocketType == WatchSocketType.Main)
                    {
                        writeLogs("客户端" + str + "：断开连接[主]");
                    }
                    else
                    {
                        writeLogs("客户端" + str + "：断开连接[辅]");
                    }

                    //3.在sendSocketList、sendSocketSemaphore记录
                    try
                    {
                        if (sendSocketList.ContainsKey(str))
                            sendSocketList.Remove(str);
                        if (sendSocketSemaphore.ContainsKey(str))
                            sendSocketSemaphore.Remove(str);
                    }
                    catch (Exception)
                    {
                    }

                    //在keyvalue删除相应的记录、在UI层进行显示处理并更新用户 注销时间
                    OnReceiveLogOutData(str, watchSocketType);
                    
                }
                catch (Exception)
                {
                }
            }
        }

        #region 各组合数据类型 的 OnReceiveData方法

        #region 好友/群 添加/删除 处理集合

        /// <summary>
        /// 收到 添加/删除 申请/通知 的处理
        /// </summary>
        /// <param name="aDRequestInform"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveADRequestInformData(ADRequestInform aDRequestInform)
        {
            try
            {
                //申请类型为 添加 类型 则 记录入库
                if (aDRequestInform.type == 0)
                {
                    AddRIDataDeal.insertAddRequest(aDRequestInform);
                }
                //对申请进行转发
                onLineTransmit(aDRequestInform);
                //交给AddRIDataDeal进行删除好友，退出群，移出群，解散群的操作
                AddRIDataDeal.addDeleDeal(aDRequestInform);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 【工具】在线转发机制：被申请方在线转发(被申请方解散群时为除群主外所有群员，其他为用户 或 群主)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        private void onLineTransmit(ADRequestInform aDRequestInform)
        {
            try
            {
                //类型2(解散群）：向除群主外所有在线成员转发消息
                if (aDRequestInform.type == 2)
                {
                    string sql = $"SELECT fCardID FROM friendlist WHERE fFriendID = '{aDRequestInform.cardID}' " +
                        $"AND fIDType = '是' AND fCardID != (SELECT gMaster FROM groupinfo " +
                        $"WHERE gID = '{aDRequestInform.cardID}');";
                    try
                    {
                        MySqlDataReader reader = BaseDataDeal.select(sql);
                        while (reader.Read())
                        {
                            string temp = reader.GetString("fCardID");
                            string socketStr = KeyValue.getSocketStr(temp, WatchSocketType.Main);
                            //若在线则转发
                            if (socketStr != "")
                            {
                                SendData(sendSocketList[socketStr], new StructGetInfo(TransType.ADRequestInform,
                                    aDRequestInform));
                            }
                        }
                        reader.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    //被申请方默认为好友类型
                    string cardID = aDRequestInform.fCardID;
                    //被申请方为群类型
                    if (aDRequestInform.fIDType == 1)
                    {
                        //获得群所主的id
                        cardID = GroupInfoDataDeal.getMasterID(aDRequestInform.fCardID);
                    }
                    try
                    {
                        //获得被申请方或其群主的socket描述串
                        string socketStr = KeyValue.getSocketStr(cardID, WatchSocketType.Main);
                        //若在线则转发
                        if (socketStr != "")
                        {
                            SendData(sendSocketList[socketStr], new StructGetInfo(TransType.ADRequestInform,
                                aDRequestInform));
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 被申请者对申请信息 同意或拒绝的操作：修改数据库，若申请发在线则向其转发通知
        /// </summary>
        /// <param name="addRIDataDeal"></param>
        private void OnReceiveAddDeleDealData(AddDeleDeal addDeleDeal)
        {
            try
            {
                //由AddRIDataDeal进行数据库操作建立好友/群成员 关系
                AddRIDataDeal.addDeleDeal(addDeleDeal);
                //申请方在线则发送向其 同意/拒绝 通知
                string socketStr = KeyValue.getSocketStr(addDeleDeal.cardID, WatchSocketType.Main);
                if (socketStr != "")
                {
                    ADRequestInform aDRequestInform = new ADRequestInform();
                    if (addDeleDeal.dealResult == 0)
                    {
                        aDRequestInform.type = 20;
                    }
                    else
                    {
                        aDRequestInform.type = 30;
                    }
                    aDRequestInform.cardID = addDeleDeal.cardID;
                    aDRequestInform.IDType = addDeleDeal.IDType;
                    aDRequestInform.fCardID = addDeleDeal.fCardID;
                    aDRequestInform.fIDType = addDeleDeal.fIDType;
                    aDRequestInform.time = addDeleDeal.time;
                    //生成显示信息字符串
                    string info = "";
                    if (addDeleDeal.fIDType == 0)
                    {
                        string sql = $"SELECT uName FROM userinfo where uCardID = '{addDeleDeal.fCardID}';";
                        MySqlDataReader reader = BaseDataDeal.select(sql);
                        try
                        {
                            reader.Read();
                            string name = reader.GetString("uName");
                            if (addDeleDeal.dealResult == 0)
                                info = $"您已成功添加好友 {name}({addDeleDeal.fCardID})。";
                            else
                                info = $"{name}({addDeleDeal.fCardID}) 拒绝添加您为好友。";
                        }
                        catch (Exception)
                        {
                        }
                        reader.Close();
                    }
                    else
                    {
                        string sql = $"SELECT gName FROM groupinfo where gID = '{addDeleDeal.fCardID}';";
                        MySqlDataReader reader = BaseDataDeal.select(sql);
                        try
                        {
                            reader.Read();
                            string name = reader.GetString("gName");
                            if (addDeleDeal.dealResult == 0)
                                info = $"您已成功加入群 {name}({addDeleDeal.fCardID})。";
                            else
                                info = $"{name}({addDeleDeal.fCardID}) 拒绝您加入该群。";
                        }
                        catch (Exception)
                        {
                        }
                        reader.Close();
                    }
                    aDRequestInform.info = info;
                    SendData(sendSocketList[socketStr], new StructGetInfo(TransType.ADRequestInform, aDRequestInform));
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 聊天 处理集合

        /// <summary>
        /// 收到聊天消息的处理：在线转发+数据库存储
        /// </summary>
        /// <param name="messageInform"></param>
        private void OnReceiveMessageInformData(MessageInform messageInform)
        {
            try
            {
                Thread thread1 = new Thread(onLineTransmitMessage);
                thread1.IsBackground = true;
                thread1.Start(messageInform);
                Thread thread2 = new Thread(ChatInfoDataDeal.insertMessageInfo);
                thread2.IsBackground = true;
                thread2.Start(messageInform);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 【工具】在线转发机制：被申请方在线转发消息(被申请方为好友或除发送者外的群成员)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="data"></param>
        private void onLineTransmitMessage(object o)
        {
            try
            {
                MessageInform messageInform = (MessageInform)o;
                if (messageInform.fIDType == 1)
                {
                    string sql = $"SELECT fCardID FROM friendlist WHERE fFriendID " +
                        $"= '{messageInform.fCardID}' AND fIDType = '是' AND fCardID " +
                        $"!= '{messageInform.cardID}';";
                    try
                    {
                        MySqlDataReader reader = BaseDataDeal.select(sql);
                        while (reader.Read())
                        {
                            string temp = reader.GetString("fCardID");
                            string socketStr = KeyValue.getSocketStr(temp, WatchSocketType.Main);
                            //若在线则转发
                            if (socketStr != "")
                            {
                                SendData(sendSocketList[socketStr], new StructGetInfo(TransType.MessageInform,
                                    messageInform));
                            }
                        }
                        reader.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    //向目的好友转发
                    try
                    {
                        string socketStr = KeyValue.getSocketStr(messageInform.fCardID, WatchSocketType.Main);
                        //若在线则转发
                        if (socketStr != "")
                        {
                            SendData(sendSocketList[socketStr], new StructGetInfo(TransType.MessageInform,
                                messageInform));
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 登录成功后，从数据库发送没有收到的消息
        /// </summary>
        /// <param name="o"></param>
        private void SendMessageCookieAfterLogin(object o)
        {
            try
            {
                Thread.Sleep(2000);
                object[] temp = (object[])o;
                string cardID = (string)temp[0];
                Socket socketSend = (Socket)temp[1];
                try
                {
                    MessageInform[] messageInforms = ChatInfoDataDeal.getMessageInfoCookie(cardID);
                    foreach (MessageInform item in messageInforms)
                    {
                        try
                        {
                            Thread.Sleep(500);
                            SendData(socketSend, new StructGetInfo(TransType.MessageInform, item));
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 收到文件上传请求：将文件按照文件名key存放到指定路径下
        /// </summary>
        /// <param name="fileSubOrGet"></param>
        private void OnReceiveFileSubOrGetData(FileSubOrGet fileSubOrGet)
        {
            try
            {
                using (FileStream fsWrite = new FileStream(Environment.CurrentDirectory 
                    + @"\fileStore\" + fileSubOrGet.key, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fsWrite.Write(fileSubOrGet.data, 10, fileSubOrGet.data.Length - 10);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 收到文件请求：根据key获取文件流向指定端口传送
        /// </summary>
        /// <param name="fileRequest"></param>
        /// <param name="socketSend"></param>
        private void OnReceiveFileRequestData(FileRequest fileRequest, Socket socketSend)
        {
            try
            {
                byte[] data = ToolUnion.getFileStreamFromFile(Environment.CurrentDirectory 
                    + @"\fileStore\" + fileRequest.key);
                FileSubOrGet fileSubOrGet = new FileSubOrGet();
                fileSubOrGet.key = fileRequest.key;
                fileSubOrGet.data = data;
                SendData(socketSend, new StructGetInfo(TransType.FileSubOrGet, fileSubOrGet));
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region 其他

        /// <summary>
        /// 群注册的响应，返回执行结果
        /// </summary>
        /// <param name="groupInfoAnswer"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveGroupInfoAnswerData(GroupInfoAnswer groupInfoAnswer, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                string gID = GroupInfoDataDeal.getRandomID();
                byte flag = GroupInfoDataDeal.addGroup(groupInfoAnswer, gID);
                GroupRegisterAnswer groupRegisterAnswer = new GroupRegisterAnswer();
                groupRegisterAnswer.result = flag;
                groupRegisterAnswer.gID = gID;
                SendData(socketSend, new StructGetInfo(TransType.GroupRegisterAnswer, groupRegisterAnswer));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 添加好友/群模块：收到请求信息后检查数据库中的用户/群并返回信息，无则不返回信息
        /// </summary>
        /// <param name="userGroupInfoRequest"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveUserGroupInfoRequestData(UserGroupInfoRequest userGroupInfoRequest, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                UserGroupInfoAnswer userGroupInfoAnswer = new UserGroupInfoAnswer();
                if (userGroupInfoRequest.idType == 1)
                {
                    userGroupInfoAnswer = GroupInfoDataDeal.getUserGroupInfo(userGroupInfoRequest.fCardID);
                }
                else
                {
                    userGroupInfoAnswer = UserInfoDataDeal.getUserOrGroupInfo(userGroupInfoRequest.fCardID);
                }
                if (userGroupInfoAnswer.cardID != null)
                    SendData(socketSend, new StructGetInfo(TransType.UserGroupInfoAnswer, userGroupInfoAnswer));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 更改0备注1群名片2群名称3群公告
        /// </summary>
        /// <param name="fGInfoUpdateRequest"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveFGInfoUpdateRequestData(FGInfoUpdateRequest fGInfoUpdateRequest, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                FriendListDataDeal.fGInfoUpdate(fGInfoUpdateRequest);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 收到注销请求的处理方法，在keyvalue删除相应的记录、在UI层进行显示处理并更新用户注销时间
        /// 新线程向其在线好友发送离线通知
        /// </summary>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveLogOutData(string socketStr, WatchSocketType watchSocketType)
        {
            try
            {
                //获取socketStr对应的cardID
                string cardID = KeyValue.getId(socketStr);
                //在keyvalue中删除相应记录
                try
                {
                    //通过socketStr对应的KeyValue记录
                    KeyValue.remove(socketStr);
                }
                catch (Exception)
                {
                }

                //主端口:1.关闭删除UI层显示并写操作日志并更新用户注销时间2.向其所有好友发送离线通知
                if (watchSocketType == WatchSocketType.Main && cardID != "")
                {
                    //1.更新UI层显示、写操作日志，更新注销时间
                    mainForm.deleteFromDgvLoginUserInfo(cardID);

                    //2.向其所有好友发送离线通知
                    Thread thread = new Thread(sendInOutStatus);
                    thread.IsBackground = true;
                    thread.Start(new object[] { cardID, 0 });
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 收到请求登录信息的处理方法：向客户端发送处理结果
        /// </summary>
        /// <param name="loginRequest"></param>
        private void OnReceiveLoginRequestData(LoginRequest loginRequest, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                //对不同的登录类型进行分别处理，但均发送登录反馈LoginAnswer;
                LoginAnswer loginAnswer = new LoginAnswer(4);
                int flag = 4;
                bool isEmailCheck = false;
                switch (loginRequest.loginType)
                {
                    //账户密码登录:验证账户密码是否正确，调用DAL层的相应方法
                    case 0:
                        flag = UserInfoDataDeal.login(loginRequest.cardID, loginRequest.password);
                        loginAnswer.cardID = loginRequest.cardID; loginAnswer.loginSucOrNot = ToolUnion.intToByteZeroToNine(flag); break;
                    //面容识别登录:验证该账户是否存在
                    case 1:
                        flag = UserInfoDataDeal.cardIDExist(loginRequest.cardID);
                        loginAnswer.cardID = loginRequest.cardID; loginAnswer.loginSucOrNot = ToolUnion.intToByteZeroToNine(flag); break;
                    //邮箱登录:验证该邮箱绑定的账户是否存在
                    case 2:
                        //以emailcheck开头，不登录仅返回账户信息
                        if (loginRequest.cardID.StartsWith("emilcheck"))
                        {
                            isEmailCheck = true;
                            loginRequest.cardID = loginRequest.cardID.Substring(9);
                        }
                        string cardID = UserInfoDataDeal.cardIDExitsByEmail(loginRequest.cardID);
                        loginAnswer.cardID = cardID; if (cardID == "") { loginAnswer.loginSucOrNot = 2; } else { flag = 1; loginAnswer.loginSucOrNot = 1; }; break;
                }
                //占线判断后 若登录成功 向UI层进行显示（仅主端口），并在KeyValue中做出相应记录
                if (flag == 1 && isEmailCheck == false)
                {
                    //占线判定
                    if (KeyValue.kvIdSocAssist.ContainsKey(loginAnswer.cardID)
                        || KeyValue.kvIdSocMain.ContainsKey(loginAnswer.cardID))
                    {
                        loginAnswer.loginSucOrNot = 5;
                    }
                    else
                    {
                        if (watchSocketType == WatchSocketType.Main)
                            mainForm.addToDgvLoginUserInfo(loginAnswer.cardID, socketSend, loginRequest.loginType);
                        KeyValue.Add(loginAnswer.cardID, socketSend.RemoteEndPoint.ToString(), watchSocketType);

                        //确认可以登录后返回所需要的用户自身各种信息
                        string sql = $"select * from UserInfo where uCardID = '{loginAnswer.cardID}'";
                        MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                        if (mySqlDataReader.HasRows)
                        {
                            mySqlDataReader.Read();
                            loginAnswer.password = mySqlDataReader.GetString("uPassWord");

                            loginAnswer.name = mySqlDataReader.GetString("uName");
                            loginAnswer.sex = 1;
                            if (mySqlDataReader.GetString("uSex") == "女")
                            {
                                loginAnswer.sex = 0;
                            }
                            loginAnswer.passFace = 0;
                            if (mySqlDataReader.GetString("uPassFace") == "是")
                            {
                                loginAnswer.passFace = 1;
                            }

                            loginAnswer.email = mySqlDataReader.GetString("uEmail");
                            loginAnswer.life = mySqlDataReader.GetString("uLife");
                        }
                        mySqlDataReader.Close();

                        //新线程发送好友/群状态信息
                        Thread thread = new Thread(sendFriendGroupStatusAfterLogin);
                        thread.IsBackground = true;
                        thread.Start(new object[] { loginAnswer.cardID, socketSend });
                        //新线程向所有好友发送上线通知
                        Thread thread2 = new Thread(sendInOutStatus);
                        thread2.IsBackground = true;
                        thread2.Start(new object[] { loginAnswer.cardID, 1 });
                        //新线程尝试更新本地头像
                        Thread thread3 = new Thread(updateLocalHeadPic);
                        thread3.IsBackground = true;
                        thread3.Start(new Object[] { loginAnswer.cardID, socketSend });
                        //新线程发送 好友/群 添加/删除 消息
                        Thread thread4 = new Thread(sendNotDealInform);
                        thread4.IsBackground = true;
                        thread4.Start(new Object[] { loginAnswer.cardID, socketSend });
                        //登录成功后，从数据库发送没有收到的消息
                        Thread thread5 = new Thread(SendMessageCookieAfterLogin);
                        thread5.IsBackground = true;
                        thread5.Start(new Object[] { loginAnswer.cardID, socketSend });
                    }
                }
                //发送回登录申请的执行结果
                SendData(socketSend, new StructGetInfo(TransType.LoginAnswer, loginAnswer));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 收到请求账号是否存在检查的处理方法：向客户端发送处理结果
        /// </summary>
        /// <param name="idIsExistRequest"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveIdIsExistRequestData(IdIsExistRequest idIsExistRequest, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                int flag = UserInfoDataDeal.cardIDExist(idIsExistRequest.cardID);
                IdIsExistAnswer idIsExistAnswer = new IdIsExistAnswer();
                if (flag == 1)
                {
                    idIsExistAnswer.result = 1;
                }
                else
                {
                    idIsExistAnswer.result = 0;
                }
                SendData(socketSend, new StructGetInfo(TransType.IdIsExistAnswer, idIsExistAnswer));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 收到头像图片提交申请的处理方法：在userheadpic下存储图片后向客户端发送确认
        /// </summary>
        /// <param name="headPicSubmitRequest"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveHeadPicSubmitRequestData(HeadPicSubmitRequest headPicSubmitRequest, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                bool flag = ToolUnion.getHeadPicFromFileStream(headPicSubmitRequest.cardID, headPicSubmitRequest.fileData);
                HeadPicSubmitAnswer headPicSubmitAnswer = new HeadPicSubmitAnswer();
                headPicSubmitAnswer.cardID = headPicSubmitRequest.cardID;
                if (flag)
                {
                    headPicSubmitAnswer.result = 1;
                    try
                    {
                        BaseDataDeal.update($"update userinfo set uUpdateTime = '{ToolUnion.getTimeStamp()}' where " +
                            $"uCardID = '{headPicSubmitRequest.cardID}';");
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                    headPicSubmitAnswer.result = 0;
                SendData(socketSend, new StructGetInfo(TransType.HeadPicSubmitAnswer, headPicSubmitAnswer));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 收到头像申请的处理方法：有则返回1+图片，无则返回0
        /// </summary>
        /// <param name="headPicGetRequest"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveHeadPicGetRequestData(HeadPicGetRequest headPicGetRequest, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                string cardID = headPicGetRequest.cardID;
                HeadPicGetAnswer headPicGetAnswer = new HeadPicGetAnswer();
                headPicGetAnswer.result = 0;
                headPicGetAnswer.cardID = headPicGetRequest.cardID;
                try
                {
                    string path = System.Environment.CurrentDirectory + "\\userheadpic\\" + cardID + ".png";
                    if (File.Exists(path))
                    {
                        headPicGetAnswer.result = 1;
                        headPicGetAnswer.fileData = ToolUnion.getFileStreamFromFile(path);
                    }
                    path = System.Environment.CurrentDirectory + "\\userheadpic\\" + cardID + ".jpg";
                    if (File.Exists(path))
                    {
                        headPicGetAnswer.result = 1;
                        headPicGetAnswer.fileData = ToolUnion.getFileStreamFromFile(path);
                    }
                    SendData(socketSend, new StructGetInfo(TransType.HeadPicGetAnswer, headPicGetAnswer));
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 用户注册请求的处理方法：返回注册的执行结果
        /// </summary>
        /// <param name="userRegisterRequest"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveUserRegisterRequestData(UserRegisterRequest userRegisterRequest, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                string cardID = UserInfoDataDeal.getRandomID();
                bool flag = UserInfoDataDeal.addUser(userRegisterRequest, cardID);
                UserRegisterAnswer userRegisterAnswer = new UserRegisterAnswer();
                if (flag)
                {
                    userRegisterAnswer.result = 1;
                    userRegisterAnswer.cardID = cardID;
                }
                else
                {
                    userRegisterAnswer.result = 0;
                    userRegisterAnswer.cardID = cardID;
                }

                SendData(socketSend, new StructGetInfo(TransType.UserRegisterAnswer, userRegisterAnswer));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 用户信息修改请求的处理方法：修改信息并返回执行结果
        /// 可能修改数据表的uUpdateTime属性或uError属性
        /// </summary>
        /// <param name="uInfoUpdateRequest"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveUInfoUpdateRequestData(UInfoUpdateRequest uInfoUpdateRequest, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                bool flag = UserInfoDataDeal.updateUser(uInfoUpdateRequest);
                UInfoUpdateAnswer uInfoUpdateAnswer = new UInfoUpdateAnswer();
                if (flag)
                {
                    uInfoUpdateAnswer.result = 1;
                }
                else
                {
                    uInfoUpdateAnswer.result = 0;
                }

                SendData(socketSend, new StructGetInfo(TransType.UInfoUpdateAnswer,
                    uInfoUpdateAnswer));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 查询发送cardID的好友friendInfoRequest.cardID的部分信息
        /// </summary>
        /// <param name="friendInfoRequest"></param>
        /// <param name="socketSend"></param>
        /// <param name="watchSocketType"></param>
        private void OnReceiveFriendGroupInfoRequestData(FriendGroupInfoRequest friendGroupInfoRequest, Socket socketSend, WatchSocketType watchSocketType)
        {
            try
            {
                //申请者账号
                string cardID = friendGroupInfoRequest.cardID;
                //申请的其好友账号或所在群账号
                string fCardID = friendGroupInfoRequest.fCardID;
                //申请类型
                if (friendGroupInfoRequest.idType == 0)
                {
                    //好友
                    FriendInfoAnswer friendInfoAnswer = FriendListDataDeal.initFriendInfoAnswer(cardID, fCardID);
                    SendData(socketSend, new StructGetInfo(TransType.FriendInfoAnswer, friendInfoAnswer));
                }
                else if (friendGroupInfoRequest.idType == 1)
                {
                    //群
                    GroupInfoAnswer groupInfoAnswer = FriendListDataDeal.initGroupInfoAnswer(cardID, fCardID);
                    SendData(socketSend, new StructGetInfo(TransType.GroupInfoAnswer, groupInfoAnswer));
                }
                else
                {
                    //群成员
                    GBriefMemInfoAnswer gBriefMemInfoAnswer = FriendListDataDeal.initGBriefMemInfoAnswer(cardID);
                    SendData(socketSend, new StructGetInfo(TransType.GBriefMemInfoAnswer, gBriefMemInfoAnswer));
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// [固定]通过设置 套接字 和 复合数据结构 传送数据
        /// </summary>
        public bool SendData(Socket socketSend, StructGetInfo structGetInfo)
        {
            try
            {
                return Protocol.set(socketSend, structGetInfo, 
                    sendSocketSemaphore[socketSend.RemoteEndPoint.ToString()]);
            }
            catch (Exception)
            {
            }
            return false;
        }
        
        #endregion

        #region 登录/注销后服务函数:为cardID发送未处理的好友/群 添加通知、更新登录账号旧头像、缓存好友状态信息发送、好友上线/离线信息发送

        /// <summary>
        /// 为cardID发送未处理的好友/群 添加通知
        /// </summary>
        public void sendNotDealInform(object o)
        {
            try
            {
                object[] temp = (object[])o;
                string cardID = (string)temp[0];
                Socket socketsend = (Socket)temp[1];
                ADRequestInform[] aDRequestInform = AddRIDataDeal.getADRequestInform(cardID);
                int len = aDRequestInform.Length;
                for (int i = 0; i < len; i++)
                {
                    SendData(socketsend, new StructGetInfo(TransType.ADRequestInform,
                        aDRequestInform[i]));
                    Thread.Sleep(3000);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 为cardID发送头像更新
        /// 参数o为登录的账号，登录方主端口
        /// </summary>
        /// <param name="o"></param>
        public void updateLocalHeadPic(object o)
        {
            try
            {
                object[] temp = (object[])o;
                string cardID = (string)temp[0];
                Socket socketSend = (Socket)temp[1];
                string sql = $"select uCardID from userinfo,friendlist where fCardID = '{cardID}' " +
                    $"and fFriendID = uCardID and fIDType = '否' and uUpdateTime > " +
                    $"(select uLogOutDate from userinfo where uCardID = '{cardID}');";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                string tCardID, tPath;
                HeadPicGetAnswer headPicGetAnswer = new HeadPicGetAnswer();
                headPicGetAnswer.result = 1;
                while (mySqlDataReader.Read())
                {
                    try
                    {
                        tCardID = mySqlDataReader.GetString("uCardID");
                        tPath = Environment.CurrentDirectory + "\\userheadpic\\" + tCardID + ".png";
                        if (File.Exists(tPath))
                        {
                            headPicGetAnswer.fileData = ToolUnion.getFileStreamFromFile(tPath);
                        }
                        tPath = Environment.CurrentDirectory + "\\userheadpic\\" + tCardID + ".jpg";
                        if (File.Exists(tPath))
                        {
                            headPicGetAnswer.fileData = ToolUnion.getFileStreamFromFile(tPath);
                        }
                        SendData(socketSend, new StructGetInfo(TransType.HeadPicGetAnswer, headPicGetAnswer));
                        Thread.Sleep(1000);
                    }
                    catch (Exception)
                    {
                    }
                }
                mySqlDataReader.Close();
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 为cardID发送好友/群状态信息
        /// </summary>
        public void sendFriendGroupStatusAfterLogin(object o)
        {
            try
            {
                object[] t1 = (object[])o;
                string cardID = (string)t1[0];
                Socket socketSend = (Socket)t1[1];
                FriendGroupStatus friendGroupStatus = FriendListDataDeal.initFriendGroupStatus(cardID);
                SendData(socketSend, new StructGetInfo(TransType.FriendGroupStatus, friendGroupStatus));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 为cardID的在线好友发送上线/离线通知
        /// </summary>
        /// <param name="o"></param>
        public void sendInOutStatus(object o)
        {
            try
            {
                object[] t = (object[])o;
                string cardID = (string)t[0];//要登录/注销的用户
                byte type = ToolUnion.intToByteZeroToNine((int)t[1]);//登录/注销的用户类型
                string[] idList = FriendListDataDeal.getFriendIDList(cardID);
                foreach (string item in idList)
                {
                    //item为其好友账号
                    string str = KeyValue.getSocketStr(item, WatchSocketType.Main);
                    if (str != "")
                    {
                        try
                        {
                            //用户item在线
                            SendData(sendSocketList[str], new StructGetInfo(TransType.InOutStatus,
                                new InOutStatus(type, cardID)));
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
       
        #endregion

    }
}
