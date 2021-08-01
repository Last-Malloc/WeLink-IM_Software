using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeLink_Server.DAL
{
    /// <summary>
    /// 数据库连接池
    /// </summary>
    static class ConnectionPool
    {
        static string connstr = "data source=localhost;database=welink_server;user id=root;password=648371;pooling=false;charset=utf8";
        static Queue<MySqlConnection> pooledconnections = null;
        static readonly object queueLocker = new object();//队列锁
        
        //调用creatPool
        static ConnectionPool()
        {
            try
            {
                createPool();
            }
            catch (Exception)
            {
            }
        }

        //创建数据库连接池，包含50个数据库连接对象
        public static void createPool()
        {
            try
            {
                if (pooledconnections != null)
                    return;
                pooledconnections = new Queue<MySqlConnection>();
            }
            catch (Exception)
            {
            }
            try
            {
                lock (queueLocker)
                {
                    for (int i = 0; i < 50; ++i)
                    {
                        MySqlConnection tmpConnect = new MySqlConnection(connstr);
                        tmpConnect.Open();
                        pooledconnections.Enqueue(tmpConnect);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //得到一个可用的数据库连接
        public static MySqlConnection getConnection()
        {
            try
            {
                if (pooledconnections == null)
                    return null;
                MySqlConnection tmpConnect = null;
                do
                {
                    Thread.Sleep(200);
                    lock (queueLocker)
                    {
                        if (pooledconnections.Count > 0)
                        {
                            tmpConnect = pooledconnections.Dequeue();
                        }
                    }
                } while (tmpConnect == null);
                return tmpConnect;
            }
            catch (Exception)
            {
            }
            return null;
        }

        //返还一个数据库连接
        public static void returnConnection(MySqlConnection tmpConnect)
        {
            try
            {
                if (pooledconnections == null)
                    return;
                lock (queueLocker)
                {
                    pooledconnections.Enqueue(tmpConnect);
                }
            }
            catch (Exception)
            {
            }
        }
        
        //关闭所有连接并销毁数据库连接池
        public static void destoryPool()
        {
            if (pooledconnections == null)
                return;
            try
            {
                MySqlConnection tmpConnect = null;
                for (int i = 0; i < 50; ++i)
                {
                    while (pooledconnections.Count == 0)
                        Thread.Sleep(500);
                    lock (queueLocker)
                    {
                        if (pooledconnections.Count > 0)
                            tmpConnect = pooledconnections.Dequeue();
                        else
                            --i;
                    }
                    if (tmpConnect != null && tmpConnect.State == System.Data.ConnectionState.Connecting)
                        tmpConnect.Close();
                }
                pooledconnections = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}