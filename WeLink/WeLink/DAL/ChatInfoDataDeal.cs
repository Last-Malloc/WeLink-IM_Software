using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeLink.BLL;
using WeLink.DAL;
using System.Data;

namespace WeLink.DAL
{
    public struct strMessageShow
    {
        public string sendCardID;//$$$$$$$$$$表示登录账号
        public string time;
        public byte sendType;
        public byte infoType;
        public string info;
        public strMessageShow(string sendCardID, string time, byte sendType, byte infoType, string info)
        {
            this.sendCardID = sendCardID;
            this.time = time;
            this.sendType = sendType;
            this.infoType = infoType;
            this.info = info;
        }
    }

    class ChatInfoDataDeal
    {
        /// <summary>
        /// 通过资源描述串在cardID的聊天记录中获取保存路径，没有保存过返回空串
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getSavePath(string cardID, string key)
        {
            try
            {
                string sql = $"SELECT cInfo FROM ChatInfo WHERE cInfo LIKE'{key}%' LIMIT 1;";
                string connStr = BaseDataDeal.getConnString($@"cookie\userdata\{cardID}\info.db3");
                DataSet dataSet = BaseDataDeal.select(sql, connStr);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string t = dataSet.Tables[0].Rows[0][0].ToString();
                    string[] tt = null;
                    if (t.Length != 0)
                        tt = t.Split('?');
                    if (tt.Length > 1)
                        return tt[1];
                }
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>
        /// 在cardID的聊天记录中设置 资源描述串 - 保存路径
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static void setSavePath(string cardID, string key, string path)
        {
            try
            {
                string sql = $"SELECT cInfo FROM ChatInfo WHERE cInfo LIKE'{key}%' LIMIT 1;";
                string connStr = BaseDataDeal.getConnString($@"cookie\userdata\{cardID}\info.db3");
                DataSet dataSet = BaseDataDeal.select(sql, connStr);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string t = dataSet.Tables[0].Rows[0][0].ToString();
                    string[] tt = null;
                    string ttt = null;
                    if (t.Length != 0)
                    {
                        tt = t.Split('?');
                        ttt = tt[0];
                    }
                    string result = ttt + "?" + path;
                    string sql2 = $"update ChatInfo set cInfo = '{result}' WHERE cInfo LIKE'{key}%';";
                    BaseDataDeal.update(sql2, connStr);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 在指定用目录下创建表charInfo;
        /// </summary>
        /// <param name="cardID"></param>
        public static void createTableChatInfo(string cardID)
                {
                    try
                    {
                        string sql = "CREATE TABLE ChatInfo" +
                            "(" +
                            "cfCardID char(10)," +
                            "cSendType char(1)," +
                            "cTime char(16)," +
                            "cSecond char(5)," +
                            "cInfoType char(1) not null," +
                            "cInfo varchar(300) default''," +
                            "primary key(cfCardID, cSendType, cTime, cSecond)" +
                            ");";
                        BaseDataDeal.update(sql, BaseDataDeal.getConnString($@"cookie\userdata\{cardID}\info.db3"));
                    }
                    catch (Exception)
                    {
                    }
                }

        /// <summary>
        /// 在指定用目录下创建表charStatus;
        /// </summary>
        /// <param name="cardID"></param>
        public static void createTableChatStatus(string cardID)
        {
            try
            {
                string sql = "CREATE TABLE ChatStatus" +
                    "(" +
                    "fCardID char(10)," +
                    "fIDType char(1)," +
                    "primary key(fCardID, fIDType)" +
                    ");";
                BaseDataDeal.update(sql, BaseDataDeal.getConnString($@"cookie\userdata\{cardID}\info.db3"));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 向数据库插入接收消息
        /// </summary>
        /// <param name="messageInform"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public static void InsertMessageIn(object o)
        {
            try
            {
                object[] temp = (object[])o;
                MessageInform messageInform = (MessageInform)temp[0];
                string connStr = (String)temp[1];
                string sql = "";
                //好友消息
                if (messageInform.fIDType == 0)
                    sql = $"INSERT INTO chatinfo VALUES('{messageInform.cardID}', '0', '{messageInform.time}'" +
                        $", '{messageInform.second}', '{messageInform.type}', '{messageInform.info}');";
                else//群消息
                    sql = $"INSERT INTO chatinfo VALUES('{messageInform.fCardID}', '2', '{messageInform.time}'" +
                        $", '{messageInform.second}', '{messageInform.type}', '{messageInform.cardID + messageInform.info}');";
                BaseDataDeal.update(sql, connStr);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 向数据库插入发送消息
        /// </summary>
        /// <param name="messageInform"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public static void InsertMessageOut(object o)
        {
            try
            {
                object[] temp = (object[])o;
                MessageInform messageInform = (MessageInform)temp[0];
                string connStr = (String)temp[1];
                string sql = "";
                //好友消息
                if (messageInform.fIDType == 0)
                    sql = $"INSERT INTO chatinfo VALUES('{messageInform.fCardID}', '1', '{messageInform.time}'" +
                        $", '{messageInform.second}', '{messageInform.type}', '{messageInform.info}');";
                else//群消息
                    sql = $"INSERT INTO chatinfo VALUES('{messageInform.fCardID}', '3', '{messageInform.time}'" +
                        $", '{messageInform.second}', '{messageInform.type}', '{messageInform.info}');";
                BaseDataDeal.update(sql, connStr);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 删除用户 与 某一好友或群的聊天记录:0好友1群
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public static bool deleteMessage(string cardID, string fCardIDAndType)
        {
            try
            {
                string fCardID = fCardIDAndType.Substring(0, 10);
                byte fIDType = 0;
                if (fCardIDAndType[10] == '1')
                    fIDType = 1;
                string connStr = BaseDataDeal.getConnString($@"cookie\userdata\{cardID}\info.db3");
                string sql = "";
                if (fIDType == 0)
                    sql = $"delete from chatinfo where cfCardID = '{fCardID}' and cSendType in ('0', '1');";
                else
                    sql = $"delete from chatinfo where cfCardID = '{fCardID}' and cSendType in ('2', '3');";
                if (BaseDataDeal.update(sql, connStr) > 0)
                    return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 从本地数据库 获取 某对话的100条记录(或更少)
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="fCardID"></param>
        /// <param name="fIDType"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static strMessageShow[] getStrMessageShows(string cardID, string fCardIDAndType)
        {
            List<strMessageShow> list = new List<strMessageShow>();
            try
            {
                string fCardID = fCardIDAndType.Substring(0, 10);
                byte fIDType = 0;
                if (fCardIDAndType[10] == '1')
                    fIDType = 1;
                string connStr = BaseDataDeal.getConnString($@"cookie\userdata\{cardID}\info.db3");
                string sql = "";
                if (fIDType == 0)
                    sql = $"SELECT cfCardID, cTime, cSendType, cInfoType, cInfo FROM ChatInfo where " +
                        $"cfCardID = '{fCardID}' AND cSendType in ('0', '1') " +
                        $"ORDER BY cTime desc, cSecond desc limit 100 OFFSET 0;";
                else
                    sql = $"SELECT cfCardID, cTime, cSendType, cInfoType, cInfo FROM ChatInfo where " +
                       $"cfCardID = '{fCardID}' AND cSendType in ('2', '3') " +
                       $"ORDER BY cTime desc, cSecond desc limit 100 OFFSET 0;";
                DataSet dataSet = BaseDataDeal.select(sql, connStr);
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    byte sendType = 0;
                    byte infoType = 0;
                    string sendCardID = null;
                    string info = null;
                    if (item[3].ToString() == "1")
                        infoType = 1;
                    else if (item[3].ToString() == "2")
                        infoType = 2;

                    if (item[2].ToString() == "1")
                    {
                        sendType = 1;
                        sendCardID = "$$$$$$$$$$";
                        info = item[4].ToString();
                    }
                    else if (item[2].ToString() == "2")
                    {
                        sendType = 2;
                        info = item[4].ToString();
                        int len = info.Length;
                        sendCardID = info.Substring(0, 10);
                        info = info.Substring(10, len - 10);
                    }
                    else if (item[2].ToString() == "3")
                    {
                        sendType = 3;
                        sendCardID = "$$$$$$$$$$";
                        info = item[4].ToString();
                    }
                    else
                    {
                        sendType = 0;
                        sendCardID = item[0].ToString();
                        info = item[4].ToString();
                    }
                    list.Add(new strMessageShow(sendCardID, item[1].ToString(), 
                        sendType, infoType, info));
                }
            }
            catch (Exception)
            {
            }
            return list.ToArray();
        }
        
    }

}