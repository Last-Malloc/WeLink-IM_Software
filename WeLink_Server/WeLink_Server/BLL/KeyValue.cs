using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WeLink_Server.BLL
{
    /// <summary>
    /// 监听端口类型：主端口和辅助端口
    /// </summary>
    public enum WatchSocketType { Main = 0, Assist = 1};
    /// <summary>
    /// 建立账号和通信socket描述字符串的关系
    /// 每个账号有两个套接字分别连接主端口和辅端口
    /// </summary>
    class KeyValue
    {
        /// <summary>
        /// id为用户账号，socket为通信套接字描述字符串
        /// </summary>
        public static Dictionary<string, string> kvIdSocMain = new Dictionary<string, string>();
        public static Dictionary<string, string> kvSocIdMain = new Dictionary<string, string>();
        public static Dictionary<string, string> kvIdSocAssist = new Dictionary<string, string>();
        public static Dictionary<string, string> kvSocIdAssist = new Dictionary<string, string>();
        /// <summary>
        /// 添加账号-Socket键值对
        /// </summary>
        /// <param name="str">账号</param>
        /// <param name="socket">套接字</param>
        /// <param name="watchSocketType">套接字类型</param>
        /// <returns>执行成功与否</returns>
        public static bool Add(string id, string socketStr, WatchSocketType watchSocketType)
        {
            try
            {
                if (watchSocketType == WatchSocketType.Main)
                {
                    if (kvIdSocMain.ContainsKey(id) == false && kvSocIdMain.ContainsKey(socketStr) == false)
                    {
                        kvIdSocMain.Add(id, socketStr);
                        kvSocIdMain.Add(socketStr, id);
                    }
                }
                else
                {
                    if (kvIdSocAssist.ContainsKey(id) == false && kvSocIdAssist.ContainsKey(socketStr) == false)
                    {
                        kvIdSocAssist.Add(id, socketStr);
                        kvSocIdAssist.Add(socketStr, id);
                    }
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        /// <summary>
        /// 通过Socket得到账号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string getId(string socketStr)
        {
            try
            {
                if (kvSocIdMain.ContainsKey(socketStr))
                    return kvSocIdMain[socketStr];
                if (kvSocIdAssist.ContainsKey(socketStr))
                    return kvSocIdAssist[socketStr];
            }
            catch (Exception)
            {
            }
            return "";
        }
        /// <summary>
        /// 通过账号得到Socket
        /// </summary>
        /// <param name="input">账户</param>
        /// <param name="socketType">套接字类型</param>
        /// <returns></returns>
        public static string getSocketStr(string id, WatchSocketType socketType)
        {
            try
            {
                if (kvIdSocMain.ContainsKey(id) && socketType == WatchSocketType.Main)
                    return kvIdSocMain[id];
                if (kvIdSocAssist.ContainsKey(id) && socketType == WatchSocketType.Assist)
                    return kvIdSocAssist[id];
            }
            catch (Exception)
            {
            }
            return "";
        }
        /// <summary>
        /// 通过账号删除键值对
        /// </summary>
        /// <param name="str">账号</param>
        /// <returns>执行成功与否</returns>
        public static bool removeById(string id)
        {
            try
            {
                if (kvIdSocMain.ContainsKey(id))
                {
                    string socketStr = kvIdSocMain[id];
                    kvIdSocMain.Remove(id);
                    kvSocIdMain.Remove(socketStr);
                }
                if (kvIdSocAssist.ContainsKey(id))
                {
                    string socketStr = kvIdSocAssist[id];
                    kvIdSocAssist.Remove(id);
                    kvSocIdAssist.Remove(socketStr);
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        /// <summary>
        /// 通过账号删除键值对
        /// </summary>
        public static bool removeById(string id, WatchSocketType socketType)
        {
            try
            {
                if (kvIdSocMain.ContainsKey(id) && socketType == WatchSocketType.Main)
                {
                    string socketStr = kvIdSocMain[id];
                    kvIdSocMain.Remove(id);
                    kvSocIdMain.Remove(socketStr);
                }
                else
                {
                    string socketStr = kvIdSocAssist[id];
                    kvIdSocAssist.Remove(id);
                    kvSocIdAssist.Remove(socketStr);
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        /// <summary>
        /// 通过socketStr删除键值对
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public static bool remove(string socketStr)
        {
            try
            {
                if (kvSocIdMain.ContainsKey(socketStr))
                {
                    string id = kvSocIdMain[socketStr];
                    kvSocIdMain.Remove(socketStr);
                    kvIdSocMain.Remove(id);
                }
                if (kvSocIdAssist.ContainsKey(socketStr))
                {
                    string id = kvSocIdAssist[socketStr];
                    kvSocIdAssist.Remove(socketStr);
                    kvIdSocAssist.Remove(id);
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
        /// <summary>
        /// 删除键值对信息
        /// </summary>
        /// <returns>执行成功与否</returns>
        public static bool clear()
        {
            try
            {
                kvIdSocMain.Clear();
                kvIdSocAssist.Clear();
                kvSocIdMain.Clear();
                kvSocIdAssist.Clear();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
