using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeLink_Server.BLL;

namespace WeLink_Server.DAL
{
    class FriendListDataDeal : BaseDataDeal
    {
        #region 好友[否]/群[是]处理

        /// <summary>
        /// 创建好友ID列表
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public static string[] getFriendIDList(string cardID)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = $"SELECT DISTINCT fFriendID FROM friendlist WHERE fCardID = '{cardID}' AND fIDType = '否';";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                while (mySqlDataReader.Read())
                {
                    list.Add(mySqlDataReader.GetString("fFriendID"));
                }
                mySqlDataReader.Close();
            }
            catch (Exception)
            {
            }
            return list.ToArray();
        }

        /// <summary>
        /// 为cardID创建好友/群状态信息(ID, 备注/群名，在线状态，首字母分界行)
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public static FriendGroupStatus initFriendGroupStatus(string cardID)
        {
            FriendGroupStatus friendGroupStatus = new FriendGroupStatus();
            List<string> id = new List<string>();
            List<string> remark = new List<string>();
            List<byte> online = new List<byte>();
            try
            {
                string sql = $"SELECT fFriendID, fRemark, fFirstAlpha FROM friendlist WHERE fCardID = '{cardID}' AND fIDType = '否' ORDER BY fFirstAlpha;";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                string now, last = "";
                while (mySqlDataReader.Read())
                {
                    now = mySqlDataReader.GetString("fFirstAlpha");
                    if (now != last)
                    {
                        id.Add("$$$$$$$$$" + now);
                        remark.Add(now);
                        online.Add(0);
                    }
                    last = now;

                    string tId = mySqlDataReader.GetString("fFriendID");
                    id.Add(tId);

                    remark.Add(mySqlDataReader.GetString("fRemark"));

                    byte tOn = 0;
                    if (KeyValue.kvIdSocMain.ContainsKey(tId))
                    {
                        tOn = 1;
                    }
                    online.Add(tOn);
                }
                mySqlDataReader.Close();

                sql = $"SELECT gID, gName, gFirstAlpha FROM groupinfo, friendlist WHERE fCardID = '{cardID}' AND fFriendID = gID ORDER BY gFirstAlpha;";
                mySqlDataReader = BaseDataDeal.select(sql);
                last = "";
                while (mySqlDataReader.Read())
                {
                    now = mySqlDataReader.GetString("gFirstAlpha");
                    if (now != last)
                    {
                        id.Add("$$$$$$$$$" + now);
                        remark.Add(now);
                        online.Add(2);
                    }
                    last = now;

                    string tId = mySqlDataReader.GetString("gID");
                    id.Add(tId);

                    remark.Add(mySqlDataReader.GetString("gName"));
                    
                    online.Add(2);
                }
                mySqlDataReader.Close();

                friendGroupStatus.arrCardID = id.ToArray();
                friendGroupStatus.arrRemark = remark.ToArray();
                friendGroupStatus.arrOnline = online.ToArray();
            }
            catch (Exception)
            {
            }
            return friendGroupStatus;
        }

        /// <summary>
        /// 查询某账号好友的部分基本信息
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="fCardID"></param>
        /// <returns></returns>
        public static FriendInfoAnswer initFriendInfoAnswer(string cardID, string fCardID)
        {
            FriendInfoAnswer friendInfoAnswer = new FriendInfoAnswer();
            try
            {
                string sql = $"select userinfo.uCardID, userinfo.uName, userinfo.uSex, friendlist.fRemark, " +
                    $"friendlist.fAddWay, userinfo.uLife from userinfo, friendlist where " +
                    $"friendlist.fCardID = '{cardID}' and friendlist.fFriendID = '{fCardID}' " +
                    $"and friendlist.fFriendID = userinfo.uCardID and friendlist.fIDType = '否';";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                if (mySqlDataReader.HasRows)
                {
                    mySqlDataReader.Read();
                    friendInfoAnswer.cardID = mySqlDataReader[0].ToString();
                    friendInfoAnswer.name = mySqlDataReader[1].ToString();
                    byte t = 1;
                    if (mySqlDataReader[2].ToString() == "女")
                        t = 0;
                    friendInfoAnswer.sex = t;
                    friendInfoAnswer.remark = mySqlDataReader[3].ToString();
                    t = 0;
                    if (mySqlDataReader[4].ToString() == "是")
                        t = 1;
                    friendInfoAnswer.source = t;
                    friendInfoAnswer.life = mySqlDataReader[5].ToString();
                }
                mySqlDataReader.Close();
            }
            catch (Exception)
            {
            }
            return friendInfoAnswer;
        }

        /// <summary>
        /// 查询某账号好友的部分基本信息
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="fCardID"></param>
        /// <returns></returns>
        public static GroupInfoAnswer initGroupInfoAnswer(string cardID, string fCardID)
        {
            GroupInfoAnswer groupInfoAnswer = new GroupInfoAnswer();
            try
            {
                string sql = $"select groupinfo.gID, groupinfo.gName, friendlist.fRemark, " +
                    $"groupinfo.gMaster, groupinfo.gAffiche from groupinfo, friendlist " +
                    $"where friendlist.fCardID = '{cardID}' and friendlist.fFriendID = '{fCardID}' " +
                    $"and friendlist.fIDType = '是' and friendlist.fFriendID = groupinfo.gID;";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                if (mySqlDataReader.HasRows)
                {
                    mySqlDataReader.Read();
                    groupInfoAnswer.gID = mySqlDataReader.GetString(0);
                    groupInfoAnswer.gName = mySqlDataReader.GetString(1);
                    groupInfoAnswer.gRemark = mySqlDataReader.GetString(2);
                    groupInfoAnswer.gMasterID = mySqlDataReader.GetString(3);
                    groupInfoAnswer.gAffiche = mySqlDataReader.GetString(4);
                }
                mySqlDataReader.Close();
                sql = $"select fRemark from friendlist where fCardID = '{groupInfoAnswer.gMasterID}' and fFriendID = '{fCardID}' and fIDType = '是';";
                MySqlDataReader mySqlDataReader2 = BaseDataDeal.select(sql);
                if (mySqlDataReader2.HasRows)
                {
                    mySqlDataReader2.Read();
                    groupInfoAnswer.gMasterRemark = mySqlDataReader2.GetString(0);
                }
                mySqlDataReader2.Close();
            }
            catch (Exception)
            {
            }
            return groupInfoAnswer;
        }

        /// <summary>
        /// 获取某群所有群成员的备注和账号
        /// </summary>
        /// <param name="gID"></param>
        /// <returns></returns>
        public static GBriefMemInfoAnswer initGBriefMemInfoAnswer(string gID)
        {
            GBriefMemInfoAnswer gBrief = new GBriefMemInfoAnswer();
            List<string> gmCardID = new List<string>();
            List<string> gmRemark = new List<string>();
            try
            {
                string sql = $"select fCardID, fRemark, fFirstAlpha " +
                    $"from friendlist " +
                    $"where fFriendID = '{gID}' and fIDType = '是' " +
                    $"order by fFirstAlpha asc;";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                string now, last = "";
                while (mySqlDataReader.Read())
                {
                    now = mySqlDataReader.GetString("fFirstAlpha");
                    if (now != last)
                    {
                        gmCardID.Add("$$$$$$$$$" + now);
                        gmRemark.Add(now);
                    }
                    last = now;

                    gmCardID.Add(mySqlDataReader.GetString("fCardID"));
                    gmRemark.Add(mySqlDataReader.GetString("fRemark"));
                }
                mySqlDataReader.Close();
            }
            catch (Exception)
            {
            }
            gBrief.gmCardID = gmCardID.ToArray();
            gBrief.gmRemark = gmRemark.ToArray();
            return gBrief;
        }

        /// <summary>
        /// 更改0备注1群名片2群名称3群公告
        /// </summary>
        /// <param name="fGInfoUpdateRequest"></param>
        public static void fGInfoUpdate(FGInfoUpdateRequest fGInfoUpdateRequest)
        {
            try
            {
                string sql = "";
                switch (fGInfoUpdateRequest.updateItem)
                {
                    case 0:
                        sql = $"update friendlist set fRemark = '{fGInfoUpdateRequest.updateInfo}' " +
                        $"where fCardID = '{fGInfoUpdateRequest.cardID}' and fFriendID = '{fGInfoUpdateRequest.fCardID}' and fIDType = '否';"; break;
                    case 1:
                        sql = $"update friendlist set fRemark = '{fGInfoUpdateRequest.updateInfo}' " +
                        $"where fCardID = '{fGInfoUpdateRequest.cardID}' and fFriendID = '{fGInfoUpdateRequest.fCardID}' and fIDType = '是';"; break;
                    case 2: sql = $"update groupinfo set gName = '{fGInfoUpdateRequest.updateInfo}' where gID = '{fGInfoUpdateRequest.cardID}';"; break;
                    case 3: sql = $"update groupinfo set gAffiche = '{fGInfoUpdateRequest.updateInfo}' where gID = '{fGInfoUpdateRequest.cardID}';"; break;
                }
                BaseDataDeal.update(sql);
            }
            catch (Exception)
            {
            }
        }
        
        #endregion
    }
}
