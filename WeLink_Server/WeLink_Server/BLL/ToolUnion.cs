using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.International.Converters.PinYinConverter;//导入拼音相关

namespace WeLink_Server.BLL
{
    /// <summary>
    /// 通用工具单元：字符串<->定长字节流、复制文件、文件<->字节流转换、获取本机IP地址
    /// 字节流->头像文件(注意删除png和jpg的重复)
    /// byte和int的0-9转换、获取字符串的拼音首字母
    /// 获取8位时间字符串(20200101)、获取16位时间戳(2020/01/01 12:00),获取秒+毫秒时间
    /// 获取首个字符(数字,字母)或拼音首字母(汉字)
    /// </summary>
    class ToolUnion
    {
        /// <summary>
        /// 将字符串key按照utf-8编码转换为长度为len的字节流，以$(36)填充，失败返回空字节流
        /// </summary>
        /// <param name="key"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static byte[] getFixedLenByteStreamFromString(string key, int len)
        {
            try
            {
                List<byte> result = new List<byte>();
                result.AddRange(Encoding.UTF8.GetBytes(key));
                int resultLen = result.Count;
                if (resultLen > len)
                {
                    return new byte[0];
                }
                else
                {
                    for (int i = 0; i < len - resultLen; i++)
                    {
                        result.Add(36);
                    }
                    return result.ToArray();

                }
            }
            catch (Exception)
            {
            }
            return new byte[0];
        }

        /// <summary>
        /// 将以$(36)填充的定长字节流转换为字符串，失败返回空字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getStringFromFixedLenByteStream(byte[] key)
        {
            try
            {
                return Encoding.UTF8.GetString(key).Split('$')[0];
            }
            catch (Exception)
            {
            }
            return "";
        }

        public static string getStringFromFixedLenByteStream(byte[] key, int index, int count)
        {
            try
            {
                return getStringFromFixedLenByteStream(key.Skip(index).Take(count).ToArray());
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="pathSource"></param>
        /// <param name="pathAim"></param>
        /// <returns></returns>
        public static bool copyFile(string pathSource, string pathAim)
        {
            try
            {
                if (File.Exists(pathSource))//判断要复制的文件是否存在
                {
                    File.Copy(pathSource, pathAim, true);//相同文件替换
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 文件转字节流(path带文件类型后缀)(字节流前10字节为文件类型)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] getFileStreamFromFile(string path)
        {
            List<byte> list = new List<byte>();
            try
            {
                byte[] buffer = new byte[1024 * 1024 * 2];
                string[] temp = path.Split('.');
                list.AddRange(getFixedLenByteStreamFromString("." + temp[temp.Length - 1], 10));
                using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    while (true)
                    {
                        int r = fsRead.Read(buffer, 0, buffer.Length);
                        if (r > 0)
                            list.AddRange(buffer.Take(r));
                        else
                            break;
                    }
                }
            }
            catch (Exception)
            {
            }
            return list.ToArray();
        }

        /// <summary> 
        /// 字节流转文件(path不带文件类型后缀，正确后缀将被覆盖，错误后缀被作为文件名)，成功返回true否则返回false
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool getFileFromFileStream(string path, byte[] fileStream)
        {
            try
            {
                int len = fileStream.Length;
                string houZhui = getStringFromFixedLenByteStream(fileStream.Take(10).ToArray());
                if (path.Substring(path.Length - houZhui.Length, houZhui.Length) != houZhui)
                {
                    path += houZhui;
                }
                using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    fsWrite.Write(fileStream, 10, len - 10);
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 字节流->头像文件(注意删除png和jpg的重复)
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public static bool getHeadPicFromFileStream(string cardID, byte[] fileStream)
        {
            try
            {
                string pathPng = Environment.CurrentDirectory + "\\userheadpic\\" + cardID + ".png";
                string pathJpg = Environment.CurrentDirectory + "\\userheadpic\\" + cardID + ".jpg";
                if (File.Exists(pathPng))
                {
                    File.Delete(pathPng);
                }
                if (File.Exists(pathJpg))
                {
                    File.Delete(pathJpg);
                }
                return getFileFromFileStream(Environment.CurrentDirectory + "\\userheadpic\\" + cardID, fileStream);
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 获取主机的IP地址
        /// </summary>
        /// <returns></returns>
        public static string getHostIPAddress()
        {
            try
            {
                string HostName = Dns.GetHostName();
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "获取本机IP地址错误";
            }
            catch (Exception)
            {
                return "获取本机IP地址错误";
            }
        }

        /// <summary>
        /// 0-9的int转byte
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static byte intToByteZeroToNine(int num)
        {
            byte result = 11;
            try
            {
                switch (num)
                {
                    case 0: result = 0; break;
                    case 1: result = 1; break;
                    case 2: result = 2; break;
                    case 3: result = 3; break;
                    case 4: result = 4; break;
                    case 5: result = 5; break;
                    case 6: result = 6; break;
                    case 7: result = 7; break;
                    case 8: result = 8; break;
                    case 9: result = 9; break;
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        /// <summary>
        /// 0-9的byte转int
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int byteToIntZeroToNine(byte num)
        {
            int result = 11;
            try
            {
                switch (num)
                {
                    case 0: result = 0; break;
                    case 1: result = 1; break;
                    case 2: result = 2; break;
                    case 3: result = 3; break;
                    case 4: result = 4; break;
                    case 5: result = 5; break;
                    case 6: result = 6; break;
                    case 7: result = 7; break;
                    case 8: result = 8; break;
                    case 9: result = 9; break;
                }
            }
            catch (Exception)
            {
            }
            return result;
        }

        /// <summary>
        /// 获取8位定长字符串的年月日
        /// </summary>
        /// <returns></returns>
        public static string getYearMonthDay()
        {
            try
            {
                return DateTime.Now.Year.ToString("0000") 
                    + DateTime.Now.Month.ToString("00") 
                    + DateTime.Now.Day.ToString("00");
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>
        /// 获取16位时间戳
        /// </summary>
        public static string getTimeStamp()
        {
            try
            {
                return DateTime.Now.Year.ToString("0000") + "/"
                    + DateTime.Now.Month.ToString("00") + "/"
                    + DateTime.Now.Day.ToString("00") + " "
                    + DateTime.Now.Hour.ToString("00") + ":"
                    + DateTime.Now.Minute.ToString("00");
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>
        /// 获取秒+毫秒时间
        /// </summary>
        /// <returns></returns>
        public static string getSecond()
        {
            try
            {
                return DateTime.Now.Second.ToString("00")
                    + DateTime.Now.Millisecond.ToString("000");
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>
        /// 获取首个字符(数字,字母)或拼音首字母(汉字)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string getFirstAlpha(string str)
        {
            try
            {
                //空
                if (str.Length == 0)
                    return "Z";
                char t = str[0];
                //汉字
                if (t >= 0x4E00 && t <= 0x9FA5)
                {
                    ChineseChar chineseChar = new ChineseChar(str[0]);
                    return chineseChar.Pinyins[0].ToString()[0].ToString();
                }
                //字母
                if (Char.IsLetter(t))
                    return Char.ToUpper(t).ToString();
                //数字
                if (Char.IsDigit(t))
                    return t.ToString();
            }
            catch
            {
            }
            return "Z";
        }
    }
}
