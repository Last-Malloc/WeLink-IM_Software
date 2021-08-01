using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using WeLink.UI;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WeLink.BLL
{

    #region 数据结构

    /// <summary>
    /// 数据传输类型
    /// </summary>
    public enum TransType
    {
        ErrorType = -1,
        LogOut = 0, LoginRequest = 1, LoginAnswer = 2,
        IdIsExistRequest = 3, IdIsExistAnswer = 4, HeadPicSubmitRequest = 5,
        HeadPicSubmitAnswer = 6, HeadPicGetRequest = 7, HeadPicGetAnswer = 8,
        UserRegisterRequest = 9, UserRegisterAnswer = 10, UInfoUpdateRequest = 11,
        UInfoUpdateAnswer = 12, FriendGroupStatus = 13, InOutStatus = 14, FriendGroupInfoRequest = 15,
        FriendInfoAnswer = 16, GroupInfoAnswer = 17, GBriefMemInfoAnswer = 18, FGInfoUpdateRequest = 19,
        UserGroupInfoRequest = 20, UserGroupInfoAnswer = 21, GroupRegisterAnswer = 22, ADRequestInform = 23,
        AddDeleDeal = 24, MessageInform = 25, FileSubOrGet = 26, FileRequest = 27
    };

    /// <summary>
    /// 最终获得的复合数据结构：类型+数据
    /// </summary>
    public struct StructGetInfo
    {
        public TransType type;
        public object data;
        public StructGetInfo(TransType type, object data)
        {
            this.type = type;
            this.data = data;
        }
    };

    #region 客户端需要 接收/发送 的 各数据传输类型 的 数据具体组织

    #region 1 2 3 4

    /// <summary>
    /// 登陆请求 1
    /// </summary>
    struct LoginRequest
    {
        public int loginType;
        public string cardID;
        public string password;
        public LoginRequest(int loginType, string cardID, string password = "")
        {
            this.loginType = loginType;
            this.cardID = cardID;
            this.password = password;
        }
    };

    /// <summary>
    /// 登录响应 2
    /// </summary>
    public struct LoginAnswer
    {
        public byte loginSucOrNot;
        public string cardID;
        public string password;
        public string name;
        public byte sex;
        public byte passFace;
        public string email;
        public string life;
        public LoginAnswer(byte loginSucOrNot, string cardID = "", string password = "",
            string name = "", byte sex = 1, byte passFace = 0, string email = "", string life = "")
        {
            this.loginSucOrNot = loginSucOrNot;
            this.cardID = cardID;
            this.password = password;
            this.name = name;
            this.sex = sex;
            this.passFace = passFace;
            this.email = email;
            this.life = life;
        }
    }

    /// <summary>
    /// 账号是否存在检查请求 3
    /// </summary>
    struct IdIsExistRequest
    {
        public string cardID;
        public IdIsExistRequest(string cardID)
        {
            this.cardID = cardID;
        }
    }

    /// <summary>
    /// 账号是否存在检查响应 4
    /// </summary>
    struct IdIsExistAnswer
    {
        public byte result;
        public IdIsExistAnswer(byte result)
        {
            this.result = result;
        }
    }

    #endregion

    #region 5 6 7 8

    /// <summary>
    /// 头像图片提交申请 5
    /// </summary>
    struct HeadPicSubmitRequest
    {
        public string cardID;
        public byte[] fileData;
        public string path;
        public HeadPicSubmitRequest(string cardID, byte[] fileData, string path = "")
        {
            this.cardID = cardID;
            this.fileData = fileData;
            this.path = path;
        }
    }

    /// <summary>
    /// 头像图片提交响应 6
    /// </summary>
    struct HeadPicSubmitAnswer
    {
        public byte result;
        public string cardID;
        public HeadPicSubmitAnswer(byte result, string cardID)
        {
            this.result = result;
            this.cardID = cardID;
        }
    }

    /// <summary>
    /// 头像图片申请请求 7
    /// </summary>
    struct HeadPicGetRequest
    {
        public string cardID;
        public HeadPicGetRequest(string cardID)
        {
            this.cardID = cardID;
        }
    }

    /// <summary>
    /// 头像图片申请响应 8
    /// </summary>
    struct HeadPicGetAnswer
    {
        public byte result;
        public string cardID;
        public byte[] fileData;
        public HeadPicGetAnswer(byte result, string cardID, byte[] fileData)
        {
            this.result = result;
            this.cardID = cardID;
            this.fileData = fileData;
        }
    }

    #endregion

    #region 9 10 11 12

    /// <summary>
    /// 用户注册请求 9
    /// </summary>
    struct UserRegisterRequest
    {
        public string password;
        public string name;
        public byte sex;
        public byte face;
        public string email;
        public string life;
        public UserRegisterRequest(string password, string name, byte sex,
            byte face, string email, string life)
        {
            this.password = password;
            this.name = name;
            this.sex = sex;
            this.face = face;
            this.email = email;
            this.life = life;
        }
    }

    /// <summary>
    /// 用户注册响应 10
    /// </summary>
    struct UserRegisterAnswer
    {
        public byte result;
        public string cardID;
        public UserRegisterAnswer(byte result, string cardID)
        {
            this.result = result;
            this.cardID = cardID;
        }
    }

    /// <summary>
    /// 信息修改请求 11
    /// </summary>
    struct UInfoUpdateRequest
    {
        public byte itemName;
        public string cardID;
        public string infoText;
        public UInfoUpdateRequest(byte itemName, string cardID, string infoText)
        {
            this.itemName = itemName;
            this.cardID = cardID;
            this.infoText = infoText;
        }
    }

    /// <summary>
    /// 信息修改响应12
    /// </summary>
    struct UInfoUpdateAnswer
    {
        public byte result;
        public UInfoUpdateAnswer(byte result)
        {
            this.result = result;
        }
    }

    #endregion

    #region 13 14 15 16

    /// <summary>
    /// 好友/群状态信息 13
    /// </summary>
    public struct FriendGroupStatus
    {
        public string[] arrCardID;
        public string[] arrRemark;
        public byte[] arrOnline;
    }

    /// <summary>
    /// 好友上/离线通知 14
    /// </summary>
    public struct InOutStatus
    {
        public byte status;
        public string cardID;
        public InOutStatus(byte status, string cardID)
        {
            this.status = status;
            this.cardID = cardID;
        }
    }

    /// <summary>
    /// 好友/群信息申请 15
    /// </summary>
    public struct FriendGroupInfoRequest
    {
        public string cardID;
        public string fCardID;
        public byte idType;
        public FriendGroupInfoRequest(string cardID, string fCardID, byte idType)
        {
            this.cardID = cardID;
            this.fCardID = fCardID;
            this.idType = idType;
        }
    }

    /// <summary>
    /// 好友信息响应 16
    /// </summary>
    public struct FriendInfoAnswer
    {
        public string cardID;
        public string name;
        public byte sex;
        public string remark;
        public byte source;
        public string life;
        public FriendInfoAnswer(string cardID, string name, byte sex,
            string remark, byte source, string life)
        {
            this.cardID = cardID;
            this.name = name;
            this.sex = sex;
            this.remark = remark;
            this.source = source;
            this.life = life;
        }
    }

    #endregion

    #region 17 18 19 20

    /// <summary>
    /// 群信息响应 17
    /// </summary>
    public struct GroupInfoAnswer
    {
        public string gID;
        public string gName;
        public string gRemark;
        public string gMasterID;
        public string gMasterRemark;
        public string gAffiche;
        public GroupInfoAnswer(string gID, string gName, string gRemark,
            string gMasterID, string gMasterRemark, string gAffiche)
        {
            this.gID = gID;
            this.gName = gName;
            this.gRemark = gRemark;
            this.gMasterID = gMasterID;
            this.gMasterRemark = gMasterRemark;
            this.gAffiche = gAffiche;
        }
    }

    /// <summary>
    /// 群成员简略信息响应 18
    /// </summary>
    public struct GBriefMemInfoAnswer
    {
        public string[] gmCardID;
        public string[] gmRemark;
    }

    /// <summary>
    /// 好友/群信息更改申请 19
    /// </summary>
    public struct FGInfoUpdateRequest
    {
        public string cardID;
        public string fCardID;
        public byte updateItem;
        public string updateInfo;
        public FGInfoUpdateRequest(string cardID, string fCardID, byte updateItem, string updateInfo)
        {
            this.cardID = cardID;
            this.fCardID = fCardID;
            this.updateItem = updateItem;
            this.updateInfo = updateInfo;
        }
    }

    /// <summary>
    /// 用户/群信息申请
    /// </summary>
    public struct UserGroupInfoRequest
    {
        public string fCardID;
        public byte idType;
        public UserGroupInfoRequest(string fCardID, byte idType)
        {
            this.fCardID = fCardID;
            this.idType = idType;
        }
    }

    #endregion

    #region 21 22 23 24

    /// <summary>
    /// 用户/群信息响应 21
    /// </summary>
    public struct UserGroupInfoAnswer
    {
        public byte answerType;
        public string cardID;
        public string name;
        public string master;
        public string life;
        public UserGroupInfoAnswer(byte answerType, string cardID, string name,
            string master, string life)
        {
            this.answerType = answerType;
            this.cardID = cardID;
            this.name = name;
            this.master = master;
            this.life = life;
        }
    }

    /// <summary>
    /// 群申请响应 22
    /// </summary>
    public struct GroupRegisterAnswer
    {
        public byte result;
        public string gID;
        public GroupRegisterAnswer(byte result, string gID)
        {
            this.result = result;
            this.gID = gID;
        }
    }

    /// <summary>
    /// 添加/删除申请/通知 23
    /// </summary>
    public struct ADRequestInform
    {
        public byte type;
        public byte addType;
        public string cardID;
        public byte IDType;
        public string fCardID;
        public byte fIDType;
        public string time;
        public string info;
    }

    /// <summary>
    /// 添加处理 24
    /// </summary>
    public struct AddDeleDeal
    {
        public string cardID;
        public byte IDType;
        public string fCardID;
        public byte fIDType;
        public string time;
        public byte dealResult;
    }

    #endregion

    #region 25 26 27 28

    /// <summary>
    /// 聊天消息 25
    /// </summary>
    public struct MessageInform
    {
        public string cardID;
        public byte IDType;
        public string fCardID;
        public byte fIDType;
        public string time;
        public string second;
        public byte type;
        public string info;
    }

    /// <summary>
    /// 文件上传 26
    /// </summary>
    public struct FileSubOrGet
    {
        public string key;
        public byte[] data;
    }

    /// <summary>
    /// 文件申请 27
    /// </summary>
    public struct FileRequest
    {
        public string key;
        public FileRequest(string key)
        {
            this.key = key;
        }
    }

    #endregion

    #endregion

    #endregion

    class Protocol
    {
        #region 供外部调用方法：get，set

        /// <summary>
        /// 通过SwapData层得到的字节流 获得 复合数据结构，交给ServerMain层
        /// </summary>
        public static StructGetInfo get(Socket socketSend)
        {
            StructGetInfo structGetInfo = new StructGetInfo();
            try
            {
                //从SwapData层得到字节流
                byte[] byteStream = SwapData.receive(socketSend);
                byte type = byteStream[0];//头部1B为传输数据的类型
                byte[] dataStream = byteStream.Skip(1).ToArray();//数据流正文
                TransType transType = TransType.ErrorType;
                object data = null;

                //频繁更改区域 对SwapData层上交的字节流 分类处理得到 复合数据类型
                switch (type)
                {
                    case 0:
                        transType = TransType.LogOut; break;
                    case 1:
                        transType = TransType.LoginRequest;
                        data = getLoginRequest(dataStream); break;
                    case 2:
                        transType = TransType.LoginAnswer;
                        data = getLoginAnswer(dataStream); break;
                    case 3:
                        transType = TransType.IdIsExistRequest;
                        data = getIdIsExistRequest(dataStream); break;
                    case 4:
                        transType = TransType.IdIsExistAnswer;
                        data = getIdIsExistAnswer(dataStream); break;
                    case 5:
                        transType = TransType.HeadPicSubmitRequest;
                        data = getHeadPicSubmitRequest(dataStream); break;
                    case 6:
                        transType = TransType.HeadPicSubmitAnswer;
                        data = getHeadPicSubmitAnswer(dataStream); break;
                    case 7:
                        transType = TransType.HeadPicGetRequest;
                        data = getHeadPicGetRequest(dataStream); break;
                    case 8:
                        transType = TransType.HeadPicGetAnswer;
                        data = getHeadPicGetAnswer(dataStream); break;
                    case 9:
                        transType = TransType.UserRegisterRequest;
                        data = getUserRegisterRequest(dataStream); break;
                    case 10:
                        transType = TransType.UserRegisterAnswer;
                        data = getUserRegisterAnswer(dataStream); break;
                    case 11:
                        transType = TransType.UInfoUpdateRequest;
                        data = getUInfoUpdateRequest(dataStream); break;
                    case 12:
                        transType = TransType.UInfoUpdateAnswer;
                        data = getUInfoUpdateAnswer(dataStream); break;
                    case 13:
                        transType = TransType.FriendGroupStatus;
                        data = getFriendGroupStatus(dataStream); break;
                    case 14:
                        transType = TransType.InOutStatus;
                        data = getInOutStatus(dataStream); break;
                    case 15:
                        transType = TransType.FriendGroupInfoRequest;
                        data = getFriendGroupInfoRequest(dataStream); break;
                    case 16:
                        transType = TransType.FriendInfoAnswer;
                        data = getFriendInfoAnswer(dataStream); break;
                    case 17:
                        transType = TransType.GroupInfoAnswer;
                        data = getGroupInfoAnswer(dataStream); break;
                    case 18:
                        transType = TransType.GBriefMemInfoAnswer;
                        data = getGBriefMemInfoAnswer(dataStream); break;
                    case 19:
                        transType = TransType.FGInfoUpdateRequest;
                        data = getFGInfoUpdateRequest(dataStream); break;
                    case 20:
                        transType = TransType.UserGroupInfoRequest;
                        data = getUserGroupInfoRequest(dataStream); break;
                    case 21:
                        transType = TransType.UserGroupInfoAnswer;
                        data = getUserGroupInfoAnswer(dataStream); break;
                    case 22:
                        transType = TransType.GroupRegisterAnswer;
                        data = getGroupRegisterAnswer(dataStream); break;
                    case 23:
                        transType = TransType.ADRequestInform;
                        data = getADRequestInform(dataStream); break;
                    case 24:
                        transType = TransType.AddDeleDeal;
                        data = getAddDeleDeal(dataStream); break;
                    case 25:
                        transType = TransType.MessageInform;
                        data = getMessageInform(dataStream); break;
                    case 26:
                        transType = TransType.FileSubOrGet;
                        data = getFileSubOrGet(dataStream); break;
                    case 27:
                        transType = TransType.FileRequest;
                        data = getFileRequest(dataStream); break;
                    default: transType = TransType.ErrorType; data = null; break;
                }
                ///频繁更改区域

                structGetInfo.type = transType;
                structGetInfo.data = data;
            }
            catch (Exception)
            {
                //负责通信的socket被关闭，向上层抛出异常
                throw;
            }
            return structGetInfo;
        }

        /// <summary>
        /// 将ServerMain层设置的 复合数据结构 转换成 字节流，交给SwapData层的send函数
        /// </summary>
        public static bool set(Socket socketSend, StructGetInfo structGetInfo, Semaphore sema)
        {
            //需要转换的组合数据类型 和 数据正文
            TransType transType = structGetInfo.type;
            object data = structGetInfo.data;
            //转换为的字节流
            List<byte> byteStream = new List<byte>();

            //频繁更改区域
            switch (transType)
            {
                case TransType.LogOut:
                    byteStream.Add(0); break;
                case TransType.LoginRequest:
                    byteStream.Add(1);
                    byteStream.AddRange(setLoginRequest(data)); break;
                case TransType.LoginAnswer:
                    byteStream.Add(2);
                    byteStream.AddRange(setLoginAnswer(data)); break;
                case TransType.IdIsExistRequest:
                    byteStream.Add(3);
                    byteStream.AddRange(setIdIsExistRequest(data)); break;
                case TransType.IdIsExistAnswer:
                    byteStream.Add(4);
                    byteStream.AddRange(setIdIsExistAnswer(data)); break;
                case TransType.HeadPicSubmitRequest:
                    byteStream.Add(5);
                    byteStream.AddRange(setHeadPicSubmitRequest(data)); break;
                case TransType.HeadPicSubmitAnswer:
                    byteStream.Add(6);
                    byteStream.AddRange(setHeadPicSubmitAnswer(data)); break;
                case TransType.HeadPicGetRequest:
                    byteStream.Add(7);
                    byteStream.AddRange(setHeadPicGetRequest(data)); break;
                case TransType.HeadPicGetAnswer:
                    byteStream.Add(8);
                    byteStream.AddRange(setHeadPicGetAnswer(data)); break;
                case TransType.UserRegisterRequest:
                    byteStream.Add(9);
                    byteStream.AddRange(setUserRegisterRequest(data)); break;
                case TransType.UserRegisterAnswer:
                    byteStream.Add(10);
                    byteStream.AddRange(setUserRegisterAnswer(data)); break;
                case TransType.UInfoUpdateRequest:
                    byteStream.Add(11);
                    byteStream.AddRange(setUInfoUpdateRequest(data)); break;
                case TransType.UInfoUpdateAnswer:
                    byteStream.Add(12);
                    byteStream.AddRange(setUInfoUpdateAnswer(data)); break;
                case TransType.FriendGroupStatus:
                    byteStream.Add(13);
                    byteStream.AddRange(setFriendGroupStatus(data)); break;
                case TransType.InOutStatus:
                    byteStream.Add(14);
                    byteStream.AddRange(setInOutStatus(data)); break;
                case TransType.FriendGroupInfoRequest:
                    byteStream.Add(15);
                    byteStream.AddRange(setFriendGroupInfoRequest(data)); break;
                case TransType.FriendInfoAnswer:
                    byteStream.Add(16);
                    byteStream.AddRange(setFriendInfoAnswer(data)); break;
                case TransType.GroupInfoAnswer:
                    byteStream.Add(17);
                    byteStream.AddRange(setGroupInfoAnswer(data)); break;
                case TransType.GBriefMemInfoAnswer:
                    byteStream.Add(18);
                    byteStream.AddRange(setGBriefMemInfoAnswer(data)); break;
                case TransType.FGInfoUpdateRequest:
                    byteStream.Add(19);
                    byteStream.AddRange(setFGInfoUpdateRequest(data)); break;
                case TransType.UserGroupInfoRequest:
                    byteStream.Add(20);
                    byteStream.AddRange(setUserGroupInfoRequest(data)); break;
                case TransType.UserGroupInfoAnswer:
                    byteStream.Add(21);
                    byteStream.AddRange(setUserGroupInfoAnswer(data)); break;
                case TransType.GroupRegisterAnswer:
                    byteStream.Add(22);
                    byteStream.AddRange(setGroupRegisterAnswer(data)); break;
                case TransType.ADRequestInform:
                    byteStream.Add(23);
                    byteStream.AddRange(setADRequestInform(data)); break;
                case TransType.AddDeleDeal:
                    byteStream.Add(24);
                    byteStream.AddRange(setAddDeleDeal(data)); break;
                case TransType.MessageInform:
                    byteStream.Add(25);
                    byteStream.AddRange(setMessageInform(data)); break;
                case TransType.FileSubOrGet:
                    byteStream.Add(26);
                    byteStream.AddRange(setFileSubOrGet(data)); break;
                case TransType.FileRequest:
                    byteStream.Add(27);
                    byteStream.AddRange(setFileRequest(data)); break;
                default: MessageBox.Show("不存在该数据传输类型", "Protocol_set方法出错！", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
            }
            ///频繁更改区域

            sema.WaitOne();
            bool flag = SwapData.send(socketSend, byteStream.ToArray());
            sema.Release();

            return flag;
        }
        #endregion

        #region 各数据传输类型的具体实现方法 频繁改动

        #region 1 2 3 4

        private static LoginRequest getLoginRequest(byte[] byteStream)
        {
            LoginRequest loginRequest = new LoginRequest();
            switch (byteStream[0])
            {
                case 0:
                    loginRequest.loginType = 0; loginRequest.cardID = Encoding.UTF8.GetString(byteStream, 1, 10);
                    loginRequest.password = Encoding.UTF8.GetString(byteStream, 11, byteStream.Length - 11); break;
                case 1: loginRequest.loginType = 1; loginRequest.cardID = Encoding.UTF8.GetString(byteStream, 1, byteStream.Length - 1); break;
                case 2: loginRequest.loginType = 2; loginRequest.cardID = Encoding.UTF8.GetString(byteStream, 1, byteStream.Length - 1); break;
            }
            return loginRequest;
        }

        private static byte[] setLoginRequest(object o)
        {
            LoginRequest loginRequest = (LoginRequest)o;
            List<byte> list = new List<byte>();
            switch (loginRequest.loginType)
            {
                //账号密码登录方式
                case 0: list.Add(0); list.AddRange(Encoding.UTF8.GetBytes(loginRequest.cardID + loginRequest.password)); break;
                //人脸识别登录方式
                case 1: list.Add(1); list.AddRange(Encoding.UTF8.GetBytes(loginRequest.cardID)); break;
                //QQ邮箱登录方式
                case 2: list.Add(2); list.AddRange(Encoding.UTF8.GetBytes(loginRequest.cardID)); break;
            }
            return list.ToArray();
        }

        private static LoginAnswer getLoginAnswer(byte[] byteStream)
        {
            LoginAnswer loginAnswer = new LoginAnswer();
            loginAnswer.loginSucOrNot = byteStream[0];
            loginAnswer.cardID = ToolUnion.getStringFromFixedLenByteStream(byteStream, 1, 10);
            loginAnswer.password = ToolUnion.getStringFromFixedLenByteStream(byteStream, 11, 20);

            loginAnswer.name = ToolUnion.getStringFromFixedLenByteStream(byteStream, 31, 15);
            loginAnswer.sex = byteStream[46];
            loginAnswer.passFace = byteStream[47];

            loginAnswer.email = ToolUnion.getStringFromFixedLenByteStream(byteStream, 48, 50);
            loginAnswer.life = ToolUnion.getStringFromFixedLenByteStream(byteStream, 98, byteStream.Length - 98);
            return loginAnswer;
        }

        private static byte[] setLoginAnswer(object o)
        {
            LoginAnswer loginAnswer = (LoginAnswer)o;
            List<byte> list = new List<byte>();
            list.Add(loginAnswer.loginSucOrNot);
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(loginAnswer.cardID, 10));
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(loginAnswer.password, 20));

            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(loginAnswer.name, 15));
            list.Add(loginAnswer.sex);
            list.Add(loginAnswer.passFace);

            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(loginAnswer.email, 50));
            list.AddRange(Encoding.UTF8.GetBytes(loginAnswer.life));
            return list.ToArray();
        }

        private static IdIsExistRequest getIdIsExistRequest(byte[] byteStream)
        {
            IdIsExistRequest idIsExistRequest = new IdIsExistRequest();
            try
            {
                idIsExistRequest.cardID = Encoding.UTF8.GetString(byteStream, 0, byteStream.Length);
            }
            catch (Exception)
            {
            }
            return idIsExistRequest;
        }

        private static byte[] setIdIsExistRequest(object o)
        {
            IdIsExistRequest idIsExistRequest = (IdIsExistRequest)o;
            return Encoding.UTF8.GetBytes(idIsExistRequest.cardID);
        }

        private static IdIsExistAnswer getIdIsExistAnswer(byte[] byteStream)
        {
            IdIsExistAnswer idIsExistAnswer = new IdIsExistAnswer();
            idIsExistAnswer.result = byteStream[0];
            return idIsExistAnswer;
        }

        private static byte[] setIdIsExistAnswer(object o)
        {
            IdIsExistAnswer idIsExistAnswer = (IdIsExistAnswer)o;
            List<byte> list = new List<byte>();
            list.Add(idIsExistAnswer.result);
            return list.ToArray();
        }

        #endregion

        #region 5 6 7 8

        private static HeadPicSubmitRequest getHeadPicSubmitRequest(byte[] byteStream)
        {
            HeadPicSubmitRequest headPicSubmitRequest = new HeadPicSubmitRequest();
            try
            {
                headPicSubmitRequest.cardID = Encoding.UTF8.GetString(byteStream, 0, 10);
                headPicSubmitRequest.fileData = byteStream.Skip(10).ToArray();
            }
            catch (Exception)
            {
            }
            return headPicSubmitRequest;
        }

        private static byte[] setHeadPicSubmitRequest(object o)
        {
            HeadPicSubmitRequest headPicSubmitRequest = (HeadPicSubmitRequest)o;
            List<byte> list = new List<byte>();
            list.AddRange(Encoding.UTF8.GetBytes(headPicSubmitRequest.cardID));
            list.AddRange(headPicSubmitRequest.fileData);
            return list.ToArray();
        }

        private static HeadPicSubmitAnswer getHeadPicSubmitAnswer(byte[] byteStream)
        {
            HeadPicSubmitAnswer headPicSubmitAnswer = new HeadPicSubmitAnswer();
            headPicSubmitAnswer.result = byteStream[0];
            headPicSubmitAnswer.cardID = Encoding.UTF8.GetString(byteStream, 1, byteStream.Length - 1);
            return headPicSubmitAnswer;
        }

        private static byte[] setHeadPicSubmitAnswer(object o)
        {
            HeadPicSubmitAnswer headPicSubmitAnswer = (HeadPicSubmitAnswer)o;
            List<byte> list = new List<byte>();
            list.Add(headPicSubmitAnswer.result);
            list.AddRange(Encoding.UTF8.GetBytes(headPicSubmitAnswer.cardID));
            return list.ToArray();
        }

        private static HeadPicGetRequest getHeadPicGetRequest(byte[] byteStream)
        {
            HeadPicGetRequest headPicGetRequest = new HeadPicGetRequest();
            headPicGetRequest.cardID = Encoding.UTF8.GetString(byteStream);
            return headPicGetRequest;
        }

        private static byte[] setHeadPicGetRequest(object o)
        {
            HeadPicGetRequest headPicGetRequest = (HeadPicGetRequest)o;
            List<byte> list = new List<byte>();
            list.AddRange(Encoding.UTF8.GetBytes(headPicGetRequest.cardID));
            return list.ToArray();
        }

        private static HeadPicGetAnswer getHeadPicGetAnswer(byte[] byteStream)
        {
            HeadPicGetAnswer headPicGetAnswer = new HeadPicGetAnswer();
            headPicGetAnswer.result = byteStream[0];
            headPicGetAnswer.cardID = Encoding.UTF8.GetString(byteStream, 1, 10);
            headPicGetAnswer.fileData = byteStream.Skip(11).ToArray();
            return headPicGetAnswer;
        }

        private static byte[] setHeadPicGetAnswer(object o)
        {
            HeadPicGetAnswer headPicGetAnswer = (HeadPicGetAnswer)o;
            List<byte> list = new List<byte>();
            list.Add(headPicGetAnswer.result);
            list.AddRange(Encoding.UTF8.GetBytes(headPicGetAnswer.cardID));
            list.AddRange(headPicGetAnswer.fileData);
            return list.ToArray();
        }

        #endregion

        #region 9 10 11 12
        private static UserRegisterRequest getUserRegisterRequest(byte[] byteStream)
        {
            UserRegisterRequest userRegisterRequest = new UserRegisterRequest(
                ToolUnion.getStringFromFixedLenByteStream(byteStream, 0, 20),
                ToolUnion.getStringFromFixedLenByteStream(byteStream, 20, 15),
                byteStream[35],
                byteStream[36],
                ToolUnion.getStringFromFixedLenByteStream(byteStream, 37, 50),
                ToolUnion.getStringFromFixedLenByteStream(byteStream.Skip(87).ToArray()));
            return userRegisterRequest;
        }

        private static byte[] setUserRegisterRequest(object o)
        {
            UserRegisterRequest userRegisterRequest = (UserRegisterRequest)o;
            List<byte> list = new List<byte>();
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(userRegisterRequest.password, 20));
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(userRegisterRequest.name, 15));
            list.Add(userRegisterRequest.sex);
            list.Add(userRegisterRequest.face);
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(userRegisterRequest.email, 50));
            list.AddRange(Encoding.UTF8.GetBytes(userRegisterRequest.life));
            return list.ToArray();
        }

        private static UserRegisterAnswer getUserRegisterAnswer(byte[] byteStream)
        {
            UserRegisterAnswer userRegisterAnswer = new UserRegisterAnswer(byteStream[0], Encoding.UTF8.GetString(byteStream, 1, 10));
            return userRegisterAnswer;
        }

        public static byte[] setUserRegisterAnswer(object o)
        {
            UserRegisterAnswer userRegisterAnswer = (UserRegisterAnswer)o;
            List<byte> list = new List<byte>();
            list.Add(userRegisterAnswer.result);
            list.AddRange(Encoding.UTF8.GetBytes(userRegisterAnswer.cardID));
            return list.ToArray();
        }

        public static UInfoUpdateRequest getUInfoUpdateRequest(byte[] byteStream)
        {
            return new UInfoUpdateRequest(byteStream[0], Encoding.UTF8.GetString(byteStream, 1, 10),
                Encoding.UTF8.GetString(byteStream, 11, byteStream.Length - 11));
        }

        public static byte[] setUInfoUpdateRequest(object o)
        {
            UInfoUpdateRequest uInfoUpdateRequest = (UInfoUpdateRequest)o;
            List<byte> list = new List<byte>();
            list.Add(uInfoUpdateRequest.itemName);
            list.AddRange(Encoding.UTF8.GetBytes(uInfoUpdateRequest.cardID));
            list.AddRange(Encoding.UTF8.GetBytes(uInfoUpdateRequest.infoText));
            return list.ToArray();
        }

        private static UInfoUpdateAnswer getUInfoUpdateAnswer(byte[] byteStream)
        {
            UInfoUpdateAnswer uInfoUpdateAnswer = new UInfoUpdateAnswer(byteStream[0]);
            return uInfoUpdateAnswer;
        }

        public static byte[] setUInfoUpdateAnswer(object o)
        {
            UInfoUpdateAnswer uInfoUpdateAnswer = (UInfoUpdateAnswer)o;
            List<byte> list = new List<byte>();
            list.Add(uInfoUpdateAnswer.result);
            return list.ToArray();
        }

        #endregion

        #region 13 14 15 16

        public static FriendGroupStatus getFriendGroupStatus(byte[] byteStream)
        {
            //共len个用户
            int len = (byteStream.Length) / 26;

            FriendGroupStatus friendGroupStatus = new FriendGroupStatus();
            friendGroupStatus.arrCardID = new String[len];
            friendGroupStatus.arrRemark = new String[len];
            friendGroupStatus.arrOnline = new Byte[len];
            for (int i = 0; i < len; i++)
            {
                friendGroupStatus.arrCardID[i] = Encoding.UTF8.GetString(byteStream, i * 26, 10);
                friendGroupStatus.arrRemark[i] = ToolUnion.getStringFromFixedLenByteStream(
                    byteStream, i * 26 + 10, 15);
                friendGroupStatus.arrOnline[i] = byteStream[i * 26 + 25];
            }
            return friendGroupStatus;
        }

        public static byte[] setFriendGroupStatus(object o)
        {
            FriendGroupStatus friendGroupStatus = (FriendGroupStatus)o;
            List<byte> list = new List<byte>();
            int len = friendGroupStatus.arrCardID.Length;
            for (int i = 0; i < len; i++)
            {
                list.AddRange(Encoding.UTF8.GetBytes(friendGroupStatus.arrCardID[i]));
                list.AddRange(ToolUnion.getFixedLenByteStreamFromString(friendGroupStatus.arrRemark[i], 15));
                list.Add(friendGroupStatus.arrOnline[i]);
            }
            return list.ToArray();
        }

        public static InOutStatus getInOutStatus(byte[] byteStream)
        {
            InOutStatus inOutStatus = new InOutStatus();
            inOutStatus.status = byteStream[0];
            inOutStatus.cardID = Encoding.UTF8.GetString(byteStream, 1, 10);
            return inOutStatus;
        }

        public static byte[] setInOutStatus(object o)
        {
            InOutStatus inOutStatus = (InOutStatus)o;
            List<byte> list = new List<byte>();
            list.Add(inOutStatus.status);
            list.AddRange(Encoding.UTF8.GetBytes(inOutStatus.cardID));
            return list.ToArray();
        }

        public static FriendGroupInfoRequest getFriendGroupInfoRequest(byte[] byteStream)
        {
            FriendGroupInfoRequest friendGroupInfoRequest = new FriendGroupInfoRequest();
            friendGroupInfoRequest.cardID = Encoding.UTF8.GetString(byteStream, 0, 10);
            friendGroupInfoRequest.fCardID = Encoding.UTF8.GetString(byteStream, 10, 10);
            friendGroupInfoRequest.idType = byteStream[20];
            return friendGroupInfoRequest;
        }

        public static byte[] setFriendGroupInfoRequest(object o)
        {
            FriendGroupInfoRequest friendGroupInfoRequest = (FriendGroupInfoRequest)o;
            List<byte> list = new List<byte>();
            list.AddRange(Encoding.UTF8.GetBytes(friendGroupInfoRequest.cardID));
            list.AddRange(Encoding.UTF8.GetBytes(friendGroupInfoRequest.fCardID));
            list.Add(friendGroupInfoRequest.idType);
            return list.ToArray();
        }

        public static FriendInfoAnswer getFriendInfoAnswer(byte[] byteStream)
        {
            FriendInfoAnswer friendInfoAnswer = new FriendInfoAnswer();

            friendInfoAnswer.cardID = Encoding.UTF8.GetString(byteStream, 0, 10);
            friendInfoAnswer.name = ToolUnion.getStringFromFixedLenByteStream(byteStream, 10, 15);
            friendInfoAnswer.sex = byteStream[25];

            friendInfoAnswer.remark = ToolUnion.getStringFromFixedLenByteStream(byteStream, 26, 15);
            friendInfoAnswer.source = byteStream[41];
            friendInfoAnswer.life = Encoding.UTF8.GetString(byteStream, 42, byteStream.Length - 42);

            return friendInfoAnswer;
        }

        public static byte[] setFriendInfoAnswer(object o)
        {
            FriendInfoAnswer friendInfoAnswer = (FriendInfoAnswer)o;
            List<byte> list = new List<byte>();

            list.AddRange(Encoding.UTF8.GetBytes(friendInfoAnswer.cardID));
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(friendInfoAnswer.name, 15));
            list.Add(friendInfoAnswer.sex);

            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(friendInfoAnswer.remark, 15));
            list.Add(friendInfoAnswer.source);
            list.AddRange(Encoding.UTF8.GetBytes(friendInfoAnswer.life));

            return list.ToArray();
        }

        #endregion

        #region 17 18 19 20

        public static GroupInfoAnswer getGroupInfoAnswer(byte[] byteStream)
        {
            GroupInfoAnswer groupInfoAnswer = new GroupInfoAnswer();
            groupInfoAnswer.gID = Encoding.UTF8.GetString(byteStream, 0, 10);
            groupInfoAnswer.gName = ToolUnion.getStringFromFixedLenByteStream(byteStream, 10, 15);
            groupInfoAnswer.gRemark = ToolUnion.getStringFromFixedLenByteStream(byteStream, 25, 15);
            groupInfoAnswer.gMasterID = Encoding.UTF8.GetString(byteStream, 40, 10);
            groupInfoAnswer.gMasterRemark = ToolUnion.getStringFromFixedLenByteStream(byteStream, 50, 15);
            groupInfoAnswer.gAffiche = Encoding.UTF8.GetString(byteStream, 65, byteStream.Length - 65);
            return groupInfoAnswer;
        }

        public static byte[] setGroupInfoAnswer(object o)
        {
            GroupInfoAnswer groupInfoAnswer = (GroupInfoAnswer)o;
            List<byte> list = new List<byte>();
            list.AddRange(Encoding.UTF8.GetBytes(groupInfoAnswer.gID));
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(groupInfoAnswer.gName, 15));
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(groupInfoAnswer.gRemark, 15));
            list.AddRange(Encoding.UTF8.GetBytes(groupInfoAnswer.gMasterID));
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(groupInfoAnswer.gMasterRemark, 15));
            list.AddRange(Encoding.UTF8.GetBytes(groupInfoAnswer.gAffiche));
            return list.ToArray();
        }

        public static GBriefMemInfoAnswer getGBriefMemInfoAnswer(byte[] byteStream)
        {
            GBriefMemInfoAnswer gBriefMemInfoAnswer = new GBriefMemInfoAnswer();
            int len = byteStream.Length / 25;
            gBriefMemInfoAnswer.gmCardID = new String[len];
            gBriefMemInfoAnswer.gmRemark = new String[len];
            for (int i = 0; i < len; i++)
            {
                gBriefMemInfoAnswer.gmCardID[i] = Encoding.UTF8.GetString(byteStream, 25 * i, 10);
                gBriefMemInfoAnswer.gmRemark[i] = ToolUnion.getStringFromFixedLenByteStream(byteStream, 25 * i + 10, 15);
            }
            return gBriefMemInfoAnswer;
        }

        public static byte[] setGBriefMemInfoAnswer(object o)
        {
            GBriefMemInfoAnswer gBriefMemInfoAnswer = (GBriefMemInfoAnswer)o;
            List<byte> list = new List<byte>();
            int len = gBriefMemInfoAnswer.gmCardID.Length;
            for (int i = 0; i < len; i++)
            {
                list.AddRange(Encoding.UTF8.GetBytes(gBriefMemInfoAnswer.gmCardID[i]));
                list.AddRange(ToolUnion.getFixedLenByteStreamFromString(gBriefMemInfoAnswer.gmRemark[i], 15));
            }
            return list.ToArray();
        }

        public static FGInfoUpdateRequest getFGInfoUpdateRequest(byte[] byteStream)
        {
            FGInfoUpdateRequest fGInfoUpdateRequest = new FGInfoUpdateRequest();
            fGInfoUpdateRequest.cardID = Encoding.UTF8.GetString(byteStream, 0, 10);
            fGInfoUpdateRequest.fCardID = Encoding.UTF8.GetString(byteStream, 10, 10);
            fGInfoUpdateRequest.updateItem = byteStream[20];
            fGInfoUpdateRequest.updateInfo = Encoding.UTF8.GetString(byteStream, 21, byteStream.Length - 21);
            return fGInfoUpdateRequest;
        }

        public static byte[] setFGInfoUpdateRequest(object o)
        {
            FGInfoUpdateRequest fGInfoUpdateRequest = (FGInfoUpdateRequest)o;
            List<byte> list = new List<byte>();
            list.AddRange(Encoding.UTF8.GetBytes(fGInfoUpdateRequest.cardID));
            list.AddRange(Encoding.UTF8.GetBytes(fGInfoUpdateRequest.fCardID));
            list.Add(fGInfoUpdateRequest.updateItem);
            list.AddRange(Encoding.UTF8.GetBytes(fGInfoUpdateRequest.updateInfo));
            return list.ToArray();
        }

        public static UserGroupInfoRequest getUserGroupInfoRequest(byte[] byteStream)
        {
            UserGroupInfoRequest userGroupInfoRequest = new UserGroupInfoRequest();
            userGroupInfoRequest.idType = byteStream[0];
            userGroupInfoRequest.fCardID = Encoding.UTF8.GetString(byteStream, 1, byteStream.Length - 1);
            return userGroupInfoRequest;
        }

        public static byte[] setUserGroupInfoRequest(object o)
        {
            UserGroupInfoRequest userGroupInfoRequest = (UserGroupInfoRequest)o;
            List<byte> list = new List<byte>();
            list.Add(userGroupInfoRequest.idType);
            list.AddRange(Encoding.UTF8.GetBytes(userGroupInfoRequest.fCardID));
            return list.ToArray();
        }

        #endregion

        #region 21 22 23 24

        public static UserGroupInfoAnswer getUserGroupInfoAnswer(byte[] byteStream)
        {
            UserGroupInfoAnswer userGroupInfoAnswer = new UserGroupInfoAnswer();
            userGroupInfoAnswer.answerType = byteStream[0];
            userGroupInfoAnswer.cardID = Encoding.UTF8.GetString(byteStream, 1, 10);
            userGroupInfoAnswer.name = ToolUnion.getStringFromFixedLenByteStream(byteStream, 11, 15);
            userGroupInfoAnswer.master = ToolUnion.getStringFromFixedLenByteStream(byteStream, 26, 25);
            userGroupInfoAnswer.life = Encoding.UTF8.GetString(byteStream, 51, byteStream.Length - 51);
            return userGroupInfoAnswer;
        }

        public static byte[] setUserGroupInfoAnswer(object o)
        {
            UserGroupInfoAnswer userGroupInfoAnswer = (UserGroupInfoAnswer)o;
            List<byte> list = new List<byte>();
            list.Add(userGroupInfoAnswer.answerType);
            list.AddRange(Encoding.UTF8.GetBytes(userGroupInfoAnswer.cardID));
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(userGroupInfoAnswer.name, 15));
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(userGroupInfoAnswer.master, 25));
            list.AddRange(Encoding.UTF8.GetBytes(userGroupInfoAnswer.life));
            return list.ToArray();
        }

        public static GroupRegisterAnswer getGroupRegisterAnswer(byte[] byteStream)
        {
            GroupRegisterAnswer groupRegisterAnswer = new GroupRegisterAnswer();
            groupRegisterAnswer.result = byteStream[0];
            groupRegisterAnswer.gID = Encoding.UTF8.GetString(byteStream, 1, 10);
            return groupRegisterAnswer;
        }

        public static byte[] setGroupRegisterAnswer(object o)
        {
            GroupRegisterAnswer groupRegisterAnswer = (GroupRegisterAnswer)o;
            List<byte> list = new List<byte>();
            list.Add(groupRegisterAnswer.result);
            list.AddRange(Encoding.UTF8.GetBytes(groupRegisterAnswer.gID));
            return list.ToArray();
        }

        public static ADRequestInform getADRequestInform(byte[] byteStream)
        {
            ADRequestInform aDRequestInform = new ADRequestInform();
            aDRequestInform.type = byteStream[0];
            aDRequestInform.cardID = Encoding.UTF8.GetString(byteStream, 1, 10);
            aDRequestInform.IDType = byteStream[11];
            aDRequestInform.fCardID = Encoding.UTF8.GetString(byteStream, 12, 10);
            aDRequestInform.fIDType = byteStream[22];
            aDRequestInform.time = Encoding.UTF8.GetString(byteStream, 23, 16);
            aDRequestInform.info = Encoding.UTF8.GetString(byteStream, 39, byteStream.Length - 39);
            return aDRequestInform;
        }

        public static byte[] setADRequestInform(object o)
        {
            ADRequestInform aDRequestInform = (ADRequestInform)o;
            List<byte> list = new List<byte>();
            list.Add(aDRequestInform.type);
            list.AddRange(Encoding.UTF8.GetBytes(aDRequestInform.cardID));
            list.Add(aDRequestInform.IDType);
            list.AddRange(Encoding.UTF8.GetBytes(aDRequestInform.fCardID));
            list.Add(aDRequestInform.fIDType);
            list.AddRange(Encoding.UTF8.GetBytes(aDRequestInform.time));
            list.AddRange(Encoding.UTF8.GetBytes(aDRequestInform.info));
            return list.ToArray();
        }

        public static AddDeleDeal getAddDeleDeal(byte[] byteStream)
        {
            AddDeleDeal addDeleDeal = new AddDeleDeal();
            addDeleDeal.cardID = Encoding.UTF8.GetString(byteStream, 0, 10);
            addDeleDeal.IDType = byteStream[10];
            addDeleDeal.fCardID = Encoding.UTF8.GetString(byteStream, 11, 10);
            addDeleDeal.fIDType = byteStream[21];
            addDeleDeal.time = Encoding.UTF8.GetString(byteStream, 22, 16);
            addDeleDeal.dealResult = byteStream[38];
            return addDeleDeal;
        }

        public static byte[] setAddDeleDeal(object o)
        {
            AddDeleDeal addDeleDeal = (AddDeleDeal)o;
            List<byte> list = new List<byte>();
            list.AddRange(Encoding.UTF8.GetBytes(addDeleDeal.cardID));
            list.Add(addDeleDeal.IDType);
            list.AddRange(Encoding.UTF8.GetBytes(addDeleDeal.fCardID));
            list.Add(addDeleDeal.fIDType);
            list.AddRange(Encoding.UTF8.GetBytes(addDeleDeal.time));
            list.Add(addDeleDeal.dealResult);
            return list.ToArray();
        }

        #endregion

        #region 25 26 27 28

        public static MessageInform getMessageInform(byte[] byteStream)
        {
            MessageInform messageInform = new MessageInform();
            messageInform.cardID = Encoding.UTF8.GetString(byteStream, 0, 10);
            messageInform.IDType = byteStream[10];
            messageInform.fCardID = Encoding.UTF8.GetString(byteStream, 11, 10);
            messageInform.fIDType = byteStream[21];
            messageInform.time = Encoding.UTF8.GetString(byteStream, 22, 16);
            messageInform.second = Encoding.UTF8.GetString(byteStream, 38, 5);
            messageInform.type = byteStream[43];
            messageInform.info = Encoding.UTF8.GetString(byteStream, 44, byteStream.Length - 44);
            return messageInform;
        }

        public static byte[] setMessageInform(object o)
        {
            MessageInform messageInform = (MessageInform)o;
            List<byte> list = new List<byte>();
            list.AddRange(Encoding.UTF8.GetBytes(messageInform.cardID));
            list.Add(messageInform.IDType);
            list.AddRange(Encoding.UTF8.GetBytes(messageInform.fCardID));
            list.Add(messageInform.fIDType);
            list.AddRange(Encoding.UTF8.GetBytes(messageInform.time));
            list.AddRange(Encoding.UTF8.GetBytes(messageInform.second));
            list.Add(messageInform.type);
            list.AddRange(Encoding.UTF8.GetBytes(messageInform.info));
            return list.ToArray();
        }

        public static FileSubOrGet getFileSubOrGet(byte[] byteStream)
        {
            FileSubOrGet fileSubOrGet = new FileSubOrGet();
            fileSubOrGet.key = ToolUnion.getStringFromFixedLenByteStream(byteStream, 0, 48);
            fileSubOrGet.data = byteStream.Skip(48).ToArray();
            return fileSubOrGet;
        }

        public static byte[] setFileSubOrGet(object o)
        {
            FileSubOrGet fileSubOrGet = (FileSubOrGet)o;
            List<byte> list = new List<byte>();
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(fileSubOrGet.key, 48));
            list.AddRange(fileSubOrGet.data);
            return list.ToArray();
        }

        public static FileRequest getFileRequest(byte[] byteStream)
        {
            FileRequest fileRequest = new FileRequest();
            fileRequest.key = ToolUnion.getStringFromFixedLenByteStream(byteStream, 0, 48);
            return fileRequest;
        }

        public static byte[] setFileRequest(object o)
        {
            FileRequest fileRequest = (FileRequest)o;
            List<byte> list = new List<byte>();
            list.AddRange(ToolUnion.getFixedLenByteStreamFromString(fileRequest.key, 48));
            return list.ToArray();
        }

        #endregion

        #endregion
    }

}