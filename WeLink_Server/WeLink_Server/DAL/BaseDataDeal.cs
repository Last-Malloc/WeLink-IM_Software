using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace WeLink_Server.DAL
{
    class BaseDataDeal
    {
        /// <summary>
        /// 对数据库执行sql语句 进行更新操作，返回更新的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int update(string sql)
        {
            int cnt = 0;
            try
            {
                MySqlConnection tmpConnect = ConnectionPool.getConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, tmpConnect);
                cnt = mySqlCommand.ExecuteNonQuery();
                ConnectionPool.returnConnection(tmpConnect);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return cnt;
        }

        /// <summary>
        /// 对数据库执行sql语句 执行查询操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static MySqlDataReader select(string sql)
        {
            MySqlDataReader mySqlDataReader = null;
            try
            {
                MySqlConnection tmpConnect = ConnectionPool.getConnection();
                MySqlCommand mySqlCommand = new MySqlCommand(sql, tmpConnect);
                mySqlDataReader = mySqlCommand.ExecuteReader();

                Thread thread = new Thread(waitReaderClose);
                thread.IsBackground = true;
                thread.Start(new object[] { tmpConnect, mySqlDataReader} );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return mySqlDataReader;
        }

        /// <summary>
        /// 延时向连接池返回数据库连接
        /// </summary>
        /// <param name="o"></param>
        private static void waitReaderClose(object o)
        {
            try
            {
                object[] temp = (object[])o;
                MySqlConnection conn = (MySqlConnection)temp[0];
                MySqlDataReader reader = (MySqlDataReader)temp[1];
                if (reader != null)
                {
                    while (reader.IsClosed == false)
                    {
                        Thread.Sleep(100);
                    }
                    Thread.Sleep(100);
                    ConnectionPool.returnConnection(conn);
                }
                else
                {
                    ConnectionPool.returnConnection(conn);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 在当前的目录的logs文件夹下创建 当前时间戳.txt，并写入List<string>中的内容
        /// </summary>
        /// <param name="logsString"></param>
        /// <returns></returns>
        public static bool writeLogsToTxt(List<string> logsString)
        {
            try
            {
                string[] temp1 = DateTime.Now.ToString().Split(':');
                string[] temp2 = temp1[0].Split('/');
                string name = temp2[0] + "." + temp2[1] + "." + temp2[2] + "." + temp1[1] + ".txt";
                string path = System.Environment.CurrentDirectory + "\\logs\\" + name;
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);
                foreach (string item in logsString)
                {
                    sw.Write(item + "\n");
                }
                sw.Close();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }
    }
}
