using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeLink_Server.BLL;
using MySql.Data.MySqlClient;
using System.Data;

namespace WeLink_Server.DAL
{
    class GroupInfoDataDeal
    {
        /// <summary>
        /// 根据群号返回群基本信息
        /// </summary>
        /// <param name="gID"></param>
        /// <returns></returns>
        public static UserGroupInfoAnswer getUserGroupInfo(string gID)
        {
            UserGroupInfoAnswer userGroupInfoAnswer = new UserGroupInfoAnswer();
            try
            {
                string sql = "";
                if (UserInfoDataDeal.uCardIDIsLegal(gID))
                    sql = $"select gID, gName, gMaster, uName, gAffiche from groupinfo, userinfo where gID = '{gID}' and gMaster = uCardID;";
                else
                    sql = $"select gID, gName, gMaster, uName, gAffiche from groupinfo, userinfo where gName like'%{gID}%' and gMaster = uCardID limit 1;";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                if (mySqlDataReader.HasRows)
                {
                    mySqlDataReader.Read();
                    userGroupInfoAnswer.answerType = 1;
                    userGroupInfoAnswer.cardID = mySqlDataReader.GetString("gID");
                    userGroupInfoAnswer.name = mySqlDataReader.GetString("gName");
                    userGroupInfoAnswer.master = mySqlDataReader.GetString("gMaster") + mySqlDataReader.GetString("uName");
                    userGroupInfoAnswer.life = mySqlDataReader.GetString("gAffiche");
                }
                mySqlDataReader.Close();
            }
            catch (Exception)
            {
            }
            return userGroupInfoAnswer;
        }

        /// <summary>
        /// 得到未被申请过的随机账号
        /// </summary>
        /// <returns></returns>
        public static string getRandomID()
        {
            try
            {
                MySqlConnection conn = ConnectionPool.getConnection();
                MySqlCommand command = new MySqlCommand("getRandomGID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new MySqlParameter("groupID", MySqlDbType.VarChar));
                command.Parameters["groupID"].Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                string id = command.Parameters["groupID"].Value.ToString();
                ConnectionPool.returnConnection(conn);
                return id;
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>
        /// 添加新群：涉及groupinfo和friendlist表
        /// 0成功1群号已经存在2其他错误
        /// </summary>
        /// <returns></returns>
        public static byte addGroup(GroupInfoAnswer groupInfoAnswer, string gID)
        {
            try
            {
                //插入数据项
                string sql = $"insert into groupinfo values('{gID}', '{groupInfoAnswer.gName}', " +
                    $"'{groupInfoAnswer.gAffiche}', '{groupInfoAnswer.gMasterID}', '{ToolUnion.getFirstAlpha(groupInfoAnswer.gName)}');";
                sql += $"insert into friendlist values('{groupInfoAnswer.gMasterID}', '是', '{gID}', " +
                    $"'{ToolUnion.getFirstAlpha(groupInfoAnswer.gMasterRemark)}', '{groupInfoAnswer.gMasterRemark}', '否');";
                if (BaseDataDeal.update(sql) > 0)
                {
                    return 1;
                }
            }
            catch (Exception)
            {
            }
            return 0;
        }

        /// <summary>
        /// 通过群号获得群主id
        /// </summary>
        /// <param name="gID"></param>
        /// <returns></returns>
        public static string getMasterID(string gID)
        {
            try
            {
                string sql = $"SELECT gMaster FROM groupinfo WHERE gID = '{gID}';";
                MySqlDataReader reader = BaseDataDeal.select(sql);
                reader.Read();
                string cardID = reader.GetString("gMaster");
                reader.Close();
                return cardID;
            }
            catch (Exception)
            {
            }
            return "";
        }
    }
}
