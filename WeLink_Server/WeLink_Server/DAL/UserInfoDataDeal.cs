using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink_Server.DAL;
using WeLink_Server.BLL;
using System.Data;

namespace WeLink_Server.DAL
{
    class UserInfoDataDeal : BaseDataDeal
    {
        #region 属性约束
        //10位纯数字
        public static bool uCardIDIsLegal(string key)
        {
            bool flag = false;
            try
            {
                if (key.Length == 10)
                {
                    int i;
                    for (i = 0; i < 10; i++)
                    {
                        if (Char.IsDigit(key[i]) == false)
                            break;
                    }
                    if (i == 10)
                        flag = true;
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }

        //6-20位字母或数字
        public static bool uPassWordIsLegal(string key)
        {
            bool flag = false;
            try
            {
                if (key.Length >= 6 && key.Length <= 20)
                {
                    int i;
                    for (i = 0; i < key.Length; i++)
                    {
                        if (Char.IsLetterOrDigit(key[i]) == false)
                            break;
                    }
                    if (i == key.Length)
                        flag = true;
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }

        //数字0-3
        public static bool uErrorIsLegal(string key)
        {
            try
            {
                if (key.Length == 1 && Char.IsDigit(key[0]))
                {
                    if (Int32.Parse(key) >= 0 && Int32.Parse(key) <= 3)
                        return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 得到未被申请过的随机账号
        /// </summary>
        /// <returns></returns>
        public static string getRandomID()
        {
            try
            {
                MySqlConnection conn = ConnectionPool.getConnection();
                MySqlCommand command = new MySqlCommand("getRandomCardID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new MySqlParameter("cardID", MySqlDbType.VarChar));
                command.Parameters["cardID"].Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                string id = command.Parameters["cardID"].Value.ToString();
                ConnectionPool.returnConnection(conn);
                return id;
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>
        /// 插入新用户
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="sex"></param>
        /// <param name="email"></param>
        /// <param name="life"></param>
        /// <returns></returns>
        public static bool addUser(UserRegisterRequest user, string cardID)
        {
            try
            {
                string tSex = "男";
                if (user.sex == 0)
                {
                    tSex = "女";
                }
                string tPassFace = "否";
                if (user.face == 1)
                {
                    tPassFace = "是";
                }
                try
                {
                    string stamp = ToolUnion.getTimeStamp();
                    string ymd = ToolUnion.getYearMonthDay();
                    string sql = $"insert into userinfo(uUpdateTime, uCardID, uPassword, uName, " +
                        $"uSex, uLogOutDate, uLoginDate, uLife, uEmail, uPassFace) " +
                        $"values('{stamp}', '{cardID}', '{user.password}', '{user.name}', " +
                        $"'{tSex}', '{stamp}', '{ymd}', '{user.life}', '{user.email}', '{tPassFace}');";
                    int cnt = update(sql);
                    if (cnt > 0)
                        return true;
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 修改用户信息，密码修改置错误次数0，昵称性别签名修改时更新uUpdateTime
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static bool updateUser(UInfoUpdateRequest info)
        {
            try
            {
                string itemName, itemValue = info.infoText;
                switch (info.itemName)
                {
                    case 1: itemName = "uPassWord"; break;
                    case 2: itemName = "uName"; break;
                    case 3: itemName = "uSex";break;
                    case 4: itemName = "uEmail"; break;
                    case 5: itemName = "uLife"; break;
                    case 6: itemName = "uPassFace"; break;
                    default: return false;
                }
                string sql = $"update UserInfo set {itemName} = '{itemValue}'"; 
                if (info.itemName == 1)
                {
                    sql += " ,uError = 0";
                }
                sql += $" where uCardID = '{info.cardID}';";
                if (update(sql) > 0)
                    return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 登录：0不正确，1正确，2用户不存在，3账户锁定，4其他错误
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int login(string cardID, string password)
        {
            int flag = 4;
            try
            {
                //账户合法
                if (uCardIDIsLegal(cardID) && uPassWordIsLegal(password))
                {
                    string sql = $"select * from UserInfo where uCardID = '{cardID}';";
                    MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                    //账户存在
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlDataReader.Read();
                        //账户锁定
                        if (mySqlDataReader.GetInt32("uError") == 3)
                        {
                            flag = 3;
                        }
                        else
                        {
                            //密码正确：更新登录日期，错误次数置0
                            if (mySqlDataReader.GetString("uPassWord") == password)
                            {
                                flag = 1;
                                string sql2 = $"update UserInfo set uError = 0, uLoginDate = '{ToolUnion.getYearMonthDay()}' where uCardID = '{cardID}';";
                                BaseDataDeal.update(sql2);
                            }
                            else
                            {
                                flag = 0;
                                string sql2;
                                //密码错误，当日第一次登录,更新登录时间并使错误此时置1
                                if (mySqlDataReader.GetString("uLoginDate") != ToolUnion.getYearMonthDay())
                                {
                                    sql2 = $"update UserInfo set uError = 1, uLoginDate = '{ToolUnion.getYearMonthDay()}' where uCardID = '{cardID}';";
                                }
                                //密码错误，当日非第一次登录,更新登录时间并使错误此时+1
                                else
                                {
                                    sql2 = $"update UserInfo set uError = uError + 1, uLoginDate = '{ToolUnion.getYearMonthDay()}' where uCardID = '{cardID}';";
                                }
                                BaseDataDeal.update(sql2);
                            }
                        }
                    }
                    else
                    {
                        flag = 2;
                    }
                    mySqlDataReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        /// <summary>
        /// 验证账户是否存在：存在返回1，不存在返回2
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public static int cardIDExist(string cardID)
        {
            int flag = 2;
            try
            {
                //账户合法
                if (uCardIDIsLegal(cardID))
                {
                    string sql = $"select * from UserInfo where uCardID = '{cardID}'";
                    MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                    //账户存在
                    if (mySqlDataReader.HasRows)
                    {
                        mySqlDataReader.Close();
                        return 1;
                    }
                    mySqlDataReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        /// <summary>
        /// 验证该邮箱绑定的账户：有则返回账号，无则返回 空字符串
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string cardIDExitsByEmail(string email)
        {
            string cardID = "";
            try
            {
                string sql = $"select uCardID from UserInfo where uEmail = '{email}'";
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                //账户存在
                if (mySqlDataReader.HasRows)
                {
                    mySqlDataReader.Read();
                    cardID = mySqlDataReader.GetString("uCardID");
                }
                mySqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cardID;
        }
       
        /// <summary>
        /// 通过账号或邮箱用户基本信息
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static UserGroupInfoAnswer getUserOrGroupInfo(string cardID)
        {
            UserGroupInfoAnswer userGroupInfoAnswer = new UserGroupInfoAnswer();
            try
            {
                string sql = "";
                if (uCardIDIsLegal(cardID))
                {
                    sql = $"select uCardID, uName, uSex, uLife from userinfo where uCardID = '{cardID}';";
                }
                else if (cardID.Contains("@"))
                {
                    sql = $"select uCardID, uName, uSex, uLife from userinfo where uEmail = '{cardID}';";
                }
                else
                {
                    sql = $"select uCardID, uName, uSex, uLife from userinfo where uName like'%{cardID}%' limit 1;";
                }
                MySqlDataReader mySqlDataReader = BaseDataDeal.select(sql);
                if (mySqlDataReader.HasRows)
                {
                    mySqlDataReader.Read();
                    userGroupInfoAnswer.answerType = 0;
                    userGroupInfoAnswer.cardID = mySqlDataReader.GetString("uCardID");
                    userGroupInfoAnswer.name = mySqlDataReader.GetString("uName");
                    userGroupInfoAnswer.master = mySqlDataReader.GetString("uSex");
                    userGroupInfoAnswer.life = mySqlDataReader.GetString("uLife");
                }
                mySqlDataReader.Close();
            }
            catch (Exception)
            {
            }
            return userGroupInfoAnswer;
        }
        
        #endregion
    }
}
