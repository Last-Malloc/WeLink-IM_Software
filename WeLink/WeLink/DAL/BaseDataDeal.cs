using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Data.Common;
using System.Data;
using WeLink.UI;
using System.Threading;

namespace WeLink.DAL
{
    class BaseDataDeal
    {
        #region 整个项目的数据库准备
        /// <summary>
        /// 项目数据库准备的外部调用方法
        /// </summary>
        public static void projectInit()
        {
            //首次运行，无cookie，进行初始化工作
            if (Directory.Exists(Environment.CurrentDirectory + @"\cookie") == false)
            {
                //创建cookie\general\login.db3，并在其中创建Recent
                dbAndRecentInit();

                //创建cookie\general.clientConfig.xml文件，并置入服务器的 双 IP和端口号信息
                ConfigXml.initConfigXML();
                ConfigXml.addConfigXML("ip", "120.26.38.146");
                ConfigXml.addConfigXML("port1", "50000");
                ConfigXml.addConfigXML("port2", "50001");

                //默认主界面关闭按钮的功能为退出程序0：退出，1：最小化
                ConfigXml.addConfigXML("closeAppNotMin", "0");

                //创建userheadpic文件夹，存储缓存头像
                BaseDataDeal.createFolder(@"cookie\userheadpic");

                //创建userdata文件夹，存储用户的缓存数据
                BaseDataDeal.createFolder(@"cookie\userdata");

                UpdateInform updateInform = new UpdateInform();
                updateInform.ShowDialog();
            }
        }

        /// <summary>
        /// 创建cookie/general/login.db3，并在其中创建Recent表
        /// </summary>
        private static bool dbAndRecentInit()
        {
            try
            {
                //创建成功，即之前不存在缓存的login.db3
                if (createFile(@"cookie\general\login.db3"))
                {
                    //创建recent表
                    string sql = "CREATE TABLE Recent("
                        +"rCardID CHAR(10) PRIMARY KEY,"
                        + "rPassWord VARCHAR(20) NOT NULL,"
                        + "rName VARCHAR(10) NOT NULL,"
                        +"rRememPW enum(0, 1) NOT NULL DEFAULT 0,"
                        +"rAutoLogin enum(0, 1) NOT NULL DEFAULT 0,"
                        + "rInsertTime timestamp NOT NULL DEFAULT(datetime(CURRENT_TIMESTAMP,'localtime')));";
                    update(sql ,getConnString(@"cookie\general\login.db3"));
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        #endregion

        #region 数据库相关操作
        //获取连接字符串
        public static string getConnString(string fileName)
        {
            string str = null;
            try
            {
                //拆分出各级文件夹和文件名
                string[] pathAndFile = fileName.Split('\\');
                string fullPath = System.Environment.CurrentDirectory;
                for (int i = 0; i < pathAndFile.Length; ++i)
                {
                    fullPath += "\\" + pathAndFile[i];
                }
                if (File.Exists(fullPath))
                    str = @"Data Source=" + fullPath + ";Initial Catalog=main;Integrated Security=True;Max Pool Size=20";
            }
            catch (Exception)
            {
            }
            return str;
        }
        //执行Sql语句
        public static int update(string sql, string connStr)
        {
            try
            {
                using (DbConnection conn = new SQLiteConnection(connStr))
                {
                    conn.Open();
                    DbCommand comm = conn.CreateCommand();
                    comm.CommandText = sql;
                    comm.CommandType = CommandType.Text;
                    return comm.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
            }
            return 0;
        }
        //执行查询并返回DataSet
        public static DataSet select(string sql, string connStr)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connStr))
                {
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception)
            {
            }
            return null;
        }
        #endregion

        #region 文件及文件夹操作
        /// <summary>
        /// 创建指定路径下的文件夹（使用例：123\abc或\123\abc，则创建123文件夹和abc子文件夹）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool createFolder(string path)
        {
            string fullPath = null;
            try
            {
                //拆分出各级文件夹名
                string[] folderName = path.Split('\\');
                fullPath = System.Environment.CurrentDirectory;
                for (int i = 0; i < folderName.Length; ++i)
                {
                    fullPath += "\\" + folderName[i];
                }
                //创建文件夹
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 删除指定路径下的文件夹及所有子文件（使用例：123\abc或\123\abc，则删除123文件夹下的abc子文件夹）
        /// 但不删除123文件夹
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string deleteFolder(string path)
        {
            string fullPath = null;
            try
            {
                //拆分出各级文件夹名
                string[] folderName = path.Split('\\');
                fullPath = System.Environment.CurrentDirectory;
                for (int i = 0; i < folderName.Length; ++i)
                {
                    fullPath += "\\" + folderName[i];
                }
                //删除文件夹
                if (Directory.Exists(fullPath))
                {
                    deleteDir(fullPath);
                    Directory.Delete(fullPath);
                }
            }
            catch (Exception)
            {
            }
            return fullPath;
        }
        //由deleteFolder调用，不对外开放
        private static void deleteDir(string file)
        {
            try
            {
                //去除文件夹和子文件的只读属性
                //去除文件夹的只读属性
                System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file);
                fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;

                //去除文件的只读属性
                System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);

                //判断文件夹是否还存在
                if (Directory.Exists(file))
                {
                    foreach (string f in Directory.GetFileSystemEntries(file))
                    {
                        if (File.Exists(f))
                        {
                            //如果有子文件删除文件
                            File.Delete(f);
                        }
                        else
                        {
                            //循环递归删除子文件夹
                            deleteDir(f);
                        }
                    }
                    //删除空文件夹
                    Directory.Delete(file);
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 创建指定路径下的文件（使用例：123\abc.db3，则在123文件夹下创建abc.db3）
        /// 新创建返回true，已存在返回false
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool createFile(string fileName)
        {
            try
            {
                //拆分出各级文件夹和文件名
                string[] pathAndFile = fileName.Split('\\');
                string fullPath = System.Environment.CurrentDirectory;
                for (int i = 0; i < pathAndFile.Length - 1; ++i)
                {
                    fullPath += "\\" + pathAndFile[i];
                }
                //创建文件夹
                if (!Directory.Exists(fullPath))
                    Directory.CreateDirectory(fullPath);
                fullPath += "\\" + pathAndFile[pathAndFile.Length - 1];
                if (!File.Exists(fullPath))
                {
                    SQLiteConnection.CreateFile(fullPath);
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 删除指定路径下的文件（使用例：123\abc.db3，则仅删除123文件夹下的abc.db3）
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string deleteFile(string fileName)
        {
            string fullPath = null;
            try
            {
                //拆分出各级文件夹和文件名
                string[] pathAndFile = fileName.Split('\\');
                fullPath = System.Environment.CurrentDirectory;
                for (int i = 0; i < pathAndFile.Length; ++i)
                {
                    fullPath += "\\" + pathAndFile[i];
                }
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
            catch (Exception)
            {
            }
            return fullPath;
        }
        #endregion
    }
}
