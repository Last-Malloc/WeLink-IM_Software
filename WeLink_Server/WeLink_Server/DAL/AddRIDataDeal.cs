using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeLink_Server.BLL;
using MySql.Data.MySqlClient;

namespace WeLink_Server.DAL
{
    class AddRIDataDeal
    {
        /// <summary>
        /// 向表AddRequestInfo插入添加好友/群申请记录
        /// </summary>
        /// <param name="addDeleRequest"></param>
        public static bool insertAddRequest(ADRequestInform aDRequestInform)
        {
            try
            {
                string type = "否", ftype = "否";
                if (aDRequestInform.IDType == 1)
                {
                    type = "是";
                }
                if (aDRequestInform.fIDType == 1)
                {
                    ftype = "是";
                }
                string sql = $"INSERT INTO addrequestinfo VALUES('{aDRequestInform.cardID}', '{type}', " +
                    $"'{aDRequestInform.fCardID}', '{ftype}', '{aDRequestInform.time}', '{aDRequestInform.info}');";
                if (BaseDataDeal.update(sql) > 0)
                {
                    return true;
                }
                
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 为cardID获取好友/群添加申请记录
        /// </summary>
        /// <param name="cardID"></param>
        public static ADRequestInform[] getADRequestInform(string cardID)
        {
            List<ADRequestInform> list = new List<ADRequestInform>();
            try
            {
                string sqlFriend = $"select * from addrequestinfo where afCardID = '{cardID}' " +
                    $"and afIDType = '否';";
                string sqlGroup = $"select * from addrequestinfo where afIDType= '是' and " +
                    $"afCardID in (select gID from groupinfo where gMaster = '{cardID}');";
                MySqlDataReader readerFriend = BaseDataDeal.select(sqlFriend);
                while(readerFriend.Read())
                {
                    byte type = 0, ftype = 0;
                    if (readerFriend.GetString("aIDType") == "是")
                    {
                        type = 1;
                    }
                    if (readerFriend.GetString("afIDType") == "是")
                    {
                        ftype = 1;
                    }
                    ADRequestInform aDRequestInform = new ADRequestInform();
                    aDRequestInform.type = 10;
                    aDRequestInform.cardID = readerFriend.GetString("aCardID");
                    aDRequestInform.IDType = type;
                    aDRequestInform.fCardID = readerFriend.GetString("afCardID");
                    aDRequestInform.fIDType = ftype;
                    aDRequestInform.time = readerFriend.GetString("aTime");
                    aDRequestInform.info = readerFriend.GetString("aInfo");
                    list.Add(aDRequestInform);
                }
                readerFriend.Close();

                MySqlDataReader readerGroup = BaseDataDeal.select(sqlGroup);
                while (readerGroup.Read())
                {
                    byte type = 0, ftype = 0;
                    if (readerGroup.GetString("aIDType") == "是")
                    {
                        type = 1;
                    }
                    if (readerGroup.GetString("afIDType") == "是")
                    {
                        ftype = 1;
                    }
                    ADRequestInform aDRequestInform = new ADRequestInform();
                    aDRequestInform.type = 10;
                    aDRequestInform.cardID = readerGroup.GetString("aCardID");
                    aDRequestInform.IDType = type;
                    aDRequestInform.fCardID = readerGroup.GetString("afCardID");
                    aDRequestInform.fIDType = ftype;
                    aDRequestInform.time = readerGroup.GetString("aTime");
                    aDRequestInform.info = readerGroup.GetString("aInfo");
                    list.Add(aDRequestInform);
                }
                readerGroup.Close();
            }
            catch (Exception)
            {
            }
            ADRequestInform[] temp = list.ToArray();
            if (temp.Length > 0)
                temp[temp.Length - 1].type = 0;
            return temp;
        }

        /// <summary>
        /// 添加/删除 好友/群 的 主要处理（根据ADRequestInform自动判断）
        /// 1删除好友2退出群3被移出群4群被解散
        /// </summary>
        /// <param name="aDRequestInform"></param>
        /// <returns></returns>
        public static bool addDeleDeal(ADRequestInform aDRequestInform)
        {
            try
            {
                //1删除好友 1 0 0（type, IDType, fIDType）
                if (aDRequestInform.type == 1 && aDRequestInform.IDType == 0 && aDRequestInform.fIDType == 0)
                {
                    //删除聊天记录?，好友/群列表关系
                    string sql = $"DELETE FROM friendlist WHERE (fCardID = '{aDRequestInform.cardID}' " +
                        $"AND fFriendID = '{aDRequestInform.fCardID}' AND fIDType = '否') OR " +
                        $"(fCardID = '{aDRequestInform.fCardID}' AND fFriendID = '{aDRequestInform.cardID}' " +
                        $"AND fIDType = '否');";
                    if (BaseDataDeal.update(sql) > 0)
                        return true;
                }
                //2退出群 1 0 1（type, IDType, fIDType）
                if (aDRequestInform.type == 1 && aDRequestInform.IDType == 0 && aDRequestInform.fIDType == 1)
                {
                    //好友/群列表关系
                    string sql = $"DELETE FROM friendlist WHERE (fCardID = '{aDRequestInform.cardID}' " +
                        $"AND fFriendID = '{aDRequestInform.fCardID}' AND fIDType = '是');";
                    if (BaseDataDeal.update(sql) > 0)
                        return true;
                }
                //3被移出群 1 1 0（type, IDType, fIDType）
                if (aDRequestInform.type == 1 && aDRequestInform.IDType == 1 && aDRequestInform.fIDType == 0)
                {
                    //好友/群列表关系
                    string sql = $"DELETE FROM friendlist WHERE (fCardID = '{aDRequestInform.fCardID}' " +
                       $"AND fFriendID = '{aDRequestInform.cardID}' AND fIDType = '是');";
                    if (BaseDataDeal.update(sql) > 0)
                        return true;
                }
                //4解散群 2 1 x（type, IDType, fIDType）
                if (aDRequestInform.type == 2 && aDRequestInform.IDType == 1)
                {
                    //删除聊天记录?，好友/群列表关系
                    string sql = $"DELETE FROM friendlist WHERE (fFriendID = '{aDRequestInform.cardID}' " +
                        $"AND fIDType = '是');" +
                        $"DELETE FROM groupinfo where fFriendID = '{aDRequestInform.cardID}';";
                    if (BaseDataDeal.update(sql) > 0)
                        return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 添加/删除 好友/群 的 主要处理（根据AddDeleDeal自动判断）
        /// 删除申请记录，若被申请方同意0 则 添加好友/群列表关系
        /// </summary>
        /// <param name="addDeleDeal"></param>
        /// <returns></returns>
        public static bool addDeleDeal(AddDeleDeal addDeleDeal)
        {
            try
            {
                //type必为"否"，ftype加好友为"是"，加群为"否"
                string type = "否", ftype = "否";
                if (addDeleDeal.fIDType == 1)
                {
                    ftype = "是";
                }
                string addWay = "否";
                //从记录中读出添加方式信息
                string sqlGetInfo = $"SELECT aInfo FROM addrequestinfo WHERE " +
                    $"aCardID = '{addDeleDeal.cardID}' AND aIDType = '{type}' " +
                    $"AND afCardID = '{addDeleDeal.fCardID}' AND afIDType = '{ftype}' " +
                    $"AND aTime = '{addDeleDeal.time}';";
                MySqlDataReader readerGetInfo = BaseDataDeal.select(sqlGetInfo);
                while(readerGetInfo.Read())
                {
                    try
                    {
                        string info = readerGetInfo.GetString("aInfo");
                        if (info.Substring(info.Length - 6, 2) == "邮箱")
                        {
                            addWay = "是";
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                readerGetInfo.Close();

                //删除记录
                string sql = $"DELETE FROM addrequestinfo WHERE aCardID = '{addDeleDeal.cardID}' " +
                    $"AND aIDType = '{type}' AND afCardID = '{addDeleDeal.fCardID}' " +
                    $"AND afIDType = '{ftype}' AND aTime = '{addDeleDeal.time}';";
                if (addDeleDeal.dealResult == 0)
                {
                    //加好友(双方互加，备注默认昵称)
                    if (ftype == "否")
                    {
                        string sqlGetName = $"select uCardID,uName from userinfo where uCardID " +
                            $"in ('{addDeleDeal.cardID}','{addDeleDeal.fCardID}');";
                        //获取双方昵称信息
                        MySqlDataReader readerGetName = BaseDataDeal.select(sqlGetName);
                        string name = "", fName = "";
                        try
                        {
                            string id;
                            readerGetName.Read();
                            id = readerGetName.GetString("uCardID");
                            if (id == addDeleDeal.cardID)
                            {
                                name = readerGetName.GetString("uName");
                            }
                            else
                            {
                                fName = readerGetName.GetString("uName");
                            }
                            readerGetName.Read();
                            id = readerGetName.GetString("uCardID");
                            if (id == addDeleDeal.cardID)
                            {
                                name = readerGetName.GetString("uName");
                            }
                            else
                            {
                                fName = readerGetName.GetString("uName");
                            }
                        }
                        catch (Exception)
                        {
                        }
                        readerGetName.Close();

                        sql += $"INSERT INTO friendlist VALUES('{addDeleDeal.cardID}', '否', " +
                            $"'{addDeleDeal.fCardID}', '{ToolUnion.getFirstAlpha(fName)}', " +
                            $"'{fName}', '{addWay}');" +
                            $"INSERT INTO friendlist VALUES('{addDeleDeal.fCardID}', '否', " +
                            $"'{addDeleDeal.cardID}', '{ToolUnion.getFirstAlpha(name)}', " +
                            $"'{name}', '{addWay}');";
                    }
                    else
                    {
                        //获取自己昵称信息
                        string sqlGetName = $"select uName from userinfo where uCardID = '{addDeleDeal.cardID}';";
                        //获取双方昵称信息
                        MySqlDataReader readerGetName = BaseDataDeal.select(sqlGetName);
                        string name = "";
                        try
                        {
                            readerGetName.Read();
                            name = readerGetName.GetString("uName");
                        }
                        catch (Exception)
                        {
                        }
                        readerGetName.Close();
                        //加群，群名片默认自己的昵称
                        sql += $"INSERT INTO friendlist VALUES('{addDeleDeal.cardID}', '是', " +
                            $"'{addDeleDeal.fCardID}', '{ToolUnion.getFirstAlpha(name)}', " +
                            $"'{name}', '{addWay}');";
                    }
                }
                if (BaseDataDeal.update(sql) > 0)
                    return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
