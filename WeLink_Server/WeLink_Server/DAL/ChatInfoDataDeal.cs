using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeLink_Server.BLL;

namespace WeLink_Server.DAL
{
    class ChatInfoDataDeal
    {
        /// <summary>
        /// 向数据库中插入MessageInform
        /// </summary>
        public static void insertMessageInfo(object o)
        {
            try
            {
                MessageInform messageInform = (MessageInform)o;
                string infoType = "0";
                if (messageInform.type == 1)
                    infoType = "1";
                else if (messageInform.type == 2)
                    infoType = "2";
                string sql = null;
                if (messageInform.fIDType == 1)
                {
                    sql = $"insert into chatinfo values('{messageInform.cardID}', '{messageInform.fCardID}', " +
                        $"'1', '{messageInform.time}', '{messageInform.second}', '{infoType}', '{messageInform.info}');";
                }
                else
                {
                    sql = $"insert into chatinfo values('{messageInform.cardID}', '{messageInform.fCardID}', " +
                            $"'0', '{messageInform.time}', '{messageInform.second}', '{infoType}', '{messageInform.info}');";
                }
                BaseDataDeal.update(sql);   
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 得到该账号未接收过的信息：从注销时间到当前时间
        /// </summary>
        /// <param name="o">cardID</param>
        /// <returns></returns>
        public static MessageInform[] getMessageInfoCookie(object o)
        {
            List<MessageInform> list = new List<MessageInform>();
            try
            {
                string cardID = (string)o;
                string sql = $"SELECT * FROM chatinfo WHERE " +
                    $"((cfCardID = '{cardID}' AND cSendType = '0') " +
                    $"OR (cSendType = '1' AND cfCardID IN " +
                    $"(SELECT DISTINCT fFriendID FROM friendlist where " +
                    $"fCardID = '{cardID}' AND fIDType = '是'))) AND cTime " +
                    $">= (SELECT uLogOutDate FROM userinfo WHERE uCardID = '{cardID}');";
                MySqlDataReader reader = BaseDataDeal.select(sql);
                while (reader.Read())
                {
                    MessageInform messageInform = new MessageInform();
                    messageInform.time = reader.GetString("cTime");
                    messageInform.second = reader.GetString("cSecond");
                    if (reader.GetString("cInfoType") == "1")
                    {
                        messageInform.type = 1;
                    }
                    else if (reader.GetString("cInfoType") == "2")
                    {
                        messageInform.type = 2;
                    }
                    else
                    {
                        messageInform.type = 0;
                    }
                    messageInform.info = reader.GetString("cInfo");
                    messageInform.cardID = reader.GetString("cCardID");
                    messageInform.fCardID = reader.GetString("cfCardID");
                    messageInform.IDType = 0;
                    if (reader.GetString("cSendType") == "0")
                    {
                        messageInform.fIDType = 0;
                    }
                    else
                    {
                        messageInform.fIDType = 1;
                    }
                    list.Add(messageInform);
                }
                reader.Close();
            }
            catch (Exception)
            {
            }
            return list.ToArray();
        }
    }

}
