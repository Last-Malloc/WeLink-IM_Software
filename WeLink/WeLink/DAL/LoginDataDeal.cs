using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink.UI;

namespace WeLink.DAL
{
    //最近登录信息的内存数据
    public struct RecentUserList
    {
        public string cardID;
        public string password;
        public string name;
        public int autoLogin;
        public int rememPW;
        public RecentUserList(string cardID, string password, string name, 
            int autoLogin, int rememPW)
        {
            this.cardID = cardID;
            this.password = password;
            this.name = name;
            this.autoLogin = autoLogin;
            this.rememPW = rememPW;
        }
    }

    /// <summary>
    /// 服务器的IP地址和端口号结构体
    /// </summary>
    struct IPAndPort
    {
        public IPAddress iPAddress;
        public int portMain;
        public int portAssist;
        public IPAndPort(string iPAddress, string portMain, string portAssist)
        {
            this.iPAddress = IPAddress.Parse(iPAddress);
            this.portMain = Int32.Parse(portMain);
            this.portAssist = Int32.Parse(portAssist);
        }
    }

    class LoginDataDeal : BaseDataDeal
    {
        #region 属性约束
        //10位纯数字
        public static bool rCardIDIsLegal(string key)
        {
            bool flag = false;
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
            return flag;
        }
        //6-20位字母或数字
        public static bool rPassWordIsLegal(string key)
        {
            bool flag = false;
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
            return flag;
        }
        #endregion

        #region 用户登录成功后的 缓存文件夹 及其结构准备 和 删除

        public static bool initUserCookie(string cardID)
        {
            try
            {
                if (!Directory.Exists(Environment.CurrentDirectory + "\\cookie\\userdata\\" + cardID))
                {
                    //创建数据库文件和默认文件存储文件夹
                    createFolder(@"cookie\userdata\" + cardID + @"\file");
                    createFile(@"cookie\userdata\" + cardID + @"\info.db3");
                    //建立聊天记录表
                    ChatInfoDataDeal.createTableChatInfo(cardID);
                    //建立聊天现场保存表
                    ChatInfoDataDeal.createTableChatStatus(cardID);
                    //在xml文件里存入文件存储的初始化数据
                    ConfigXml.addConfigXML(cardID + "文件保存路径", Environment.CurrentDirectory + @"\cookie\userdata\" + cardID + @"\file");
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 删除的缓存文件夹\cookie\userdara\账号
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public static bool deleteUserCookie(string cardID)
        {
            try
            {
                if (Directory.Exists(Environment.CurrentDirectory + "\\cookie\\userdata\\" + cardID))
                {
                    deleteFolder(@"cookie\userdata\" + cardID);
                    Directory.Delete(Environment.CurrentDirectory + "\\cookie\\userdata\\" + cardID);
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        #endregion

        #region IPPort表相关操作：getIPAndPort，setIPAndPort（通过xml操作 2020/22/6）
        /// <summary>
        /// 得到服务器的IP地址和两个端口号
        /// </summary>
        /// <returns></returns>
        public static IPAndPort getIPAndPort()
        {
            try
            {
                string iPAddress = ConfigXml.selectConfigXML("ip");
                string portMain = ConfigXml.selectConfigXML("port1");
                string portAssist = ConfigXml.selectConfigXML("port2");
                return new IPAndPort(iPAddress, portMain, portAssist);
            }
            catch (Exception)
            {
            }
            return new IPAndPort();
        }

        /// <summary>
        /// 设置服务器的IP地址和两个端口号
        /// </summary>
        /// <returns></returns>
        public static bool setIPAndPort(string iPAddress, string portMain, string portAssist)
        {
            try
            {
                ConfigXml.updateConfigXML("ip", iPAddress);
                ConfigXml.updateConfigXML("port1", portMain);
                ConfigXml.updateConfigXML("port2", portAssist);
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        #endregion

        #region Recent表相关操作：按照时间逆序得到最近登录信息，插入或更新信息、删除信息
        /// <summary>
        /// 获取reccent表数据，按照时间逆序排序
        /// </summary>
        public static RecentUserList[] getRecentUserList()
        {
            List<RecentUserList> recentUserLists = new List<RecentUserList>();
            try
            {
                DataSet dataSet = select("select * from Recent order by rInsertTime desc;", getConnString(@"cookie\general\login.db3"));
                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    recentUserLists.Add(new RecentUserList(item[0].ToString(), item[1].ToString(), 
                        item[2].ToString(), Int32.Parse(item[3].ToString()), Int32.Parse(item[4].ToString())));
                }
            }
            catch (Exception)
            {
            }
            return recentUserLists.ToArray();
        }

        public static bool insertOrUpdateUserList(string cardID, string password, string name, int autoLogin, int rememPW)
        {
            try
            {
                string conn = getConnString(@"cookie\general\login.db3");
                string sql = $"select count(*) from Recent where rCardID = '{cardID}';";
                DataSet dataSet = select(sql, conn);
                if (Int32.Parse(dataSet.Tables[0].Rows[0][0].ToString()) > 0)
                {
                    sql = $"update recent set rPassWord = '{password}', rName = '{name}', " +
                    $"rAutoLogin = {autoLogin}, rRememPW = {rememPW}, rInsertTime = datetime(CURRENT_TIMESTAMP,'localtime') " +
                    $"where rCardID = '{cardID}';";
                    BaseDataDeal.update(sql, conn);
                }
                else
                {
                    sql = $"insert into recent(rCardID, rPassWord, rName, rAutoLogin, rRememPW) values('{cardID}', '{password}', '{name}', {autoLogin}, {rememPW}); ";
                    BaseDataDeal.update(sql, conn);
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 删除账号cardID在recent表中的记录
        /// </summary>
        /// <param name="cardID"></param>
        /// <returns></returns>
        public static bool deleteUserList(string cardID)
        {
            try
            {
                string conn = getConnString(@"cookie\general\login.db3");
                string sql = $"delete from recent where rCardID = '{cardID}';";
                BaseDataDeal.update(sql, conn);
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        #endregion
    }
}
