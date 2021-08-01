using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeLink.BLL
{
    /// <summary>
    /// 图片工具：字节流->头像文件(注意删除了png和jpg的重复)、从文件流中得到图片（代替Image.FromFile）
    /// 彩色图片变黑白图片
    /// 文件工具：复制文件、文件<->字节流转换、
    /// 其他工具：byte和int的0-9转换、字符串<->定长字节流、发送验证码邮件
    /// 获取8位时间字符串(20200101)、获取16位时间戳(2020/01/01 12:00)、获取秒+毫秒时间
    /// 16位时间戳->12位时间戳
    /// </summary>
    class ToolUnion
    {
        #region 图片工具

        /// <summary>
        /// 从文件流中得到文件，解除了FromFile后文件不能操作的弊端
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Image Image_FromStream(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            int byteLength = (int)fileStream.Length;
            byte[] fileBytes = new byte[byteLength];
            fileStream.Read(fileBytes, 0, byteLength);
            fileStream.Close();
            return Image.FromStream(new MemoryStream(fileBytes));
        }

        /// <summary>
        /// 彩色图片变黑白图片
        /// </summary>
        /// <param name="bmp"></param>
        /// <returns></returns>
        public static Image Image_ToBlackWhite(Bitmap bmp)
        {
            int mode = 0;
            if (bmp == null)
            {
                return null;
            }
            int w = bmp.Width;
            int h = bmp.Height;
            try
            {
                byte newColor = 0;
                BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* p = (byte*)srcData.Scan0.ToPointer();
                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {

                            if (mode == 0) // 加权平均
                            {
                                newColor = (byte)((float)p[0] * 0.114f + (float)p[1] * 0.587f + (float)p[2] * 0.299f);
                            }
                            else    // 算数平均
                            {
                                newColor = (byte)((float)(p[0] + p[1] + p[2]) / 3.0f);
                            }
                            p[0] = newColor;
                            p[1] = newColor;
                            p[2] = newColor;

                            p += 3;
                        }
                        p += srcData.Stride - w * 3;
                    }
                    bmp.UnlockBits(srcData);
                    return bmp;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 字节流->头像文件(注意删除png和jpg的重复)
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public static bool getHeadPicFromFileStream(string cardID, byte[] fileStream)
        {
            string pathPng = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".png";
            string pathJpg = Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID + ".jpg";
            if (File.Exists(pathPng))
            {
                File.Delete(pathPng);
            }
            if (File.Exists(pathJpg))
            {
                File.Delete(pathJpg);
            }
            return getFileFromFileStream(Environment.CurrentDirectory + "\\cookie\\userheadpic\\" + cardID, fileStream);
        }
        
        #endregion

        #region 文件工具

        /// <summary>
        /// 复制文件(pathAim不带类型后缀)
        /// </summary>
        /// <param name="pathSource"></param>
        /// <param name="pathAim"></param>
        /// <returns></returns>
        public static bool copyFile(string pathSource, string pathAim)
        {
            try
            {
                string[] temp = pathSource.Split('.');
                string type = "." + temp[temp.Length - 1];
                if (File.Exists(pathSource))//判断要复制的文件是否存在
                {
                    File.Copy(pathSource, pathAim + type, true);//true表示相同文件替换
                }
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// 文件转字节流(path带类型后缀)(字节流前10字节为文件类型)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] getFileStreamFromFile(string path)
        {
            List<byte> list = new List<byte>();
            byte[] buffer = new byte[1024 * 1024 * 2];
            try
            {
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
        /// 字节流转文件(path不带类型后缀，正确后缀将被覆盖，错误后缀被作为文件名)，成功返回true否则返回false
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

        #endregion

        #region 其他工具

        /// <summary>
        /// 0-9的int转byte
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static byte intToByteZeroToNine(int num)
        {
            byte result = 11;
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
            return result;
        }

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

        /// <summary>
        /// 将以$填充的定长字符串转换为字符串，失败返回空字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getStringFromFixedLenString(string key)
        {
            try
            {
                return key.Split('$')[0];
            }
            catch (Exception)
            {
            }
            return "";
        }

        /// <summary>
        /// 将字符串key为长度为len的定长字符串，以$填充，失败返回空字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string getFixedLenStringFromString(string key, int len)
        {
            if (key.Length > len)
                return "";
            else
            {
                string str = key;
                for (int i = 0; i < len - key.Length; i++)
                {
                    str += "$";
                }
                return str;
            }
        }

        /// <summary>
        /// 将以$(36)填充的定长字节流的index始的count字节转换为字符串，失败返回空字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string getStringFromFixedLenByteStream(byte[] key, int index, int count)
        {
            return getStringFromFixedLenByteStream(key.Skip(index).Take(count).ToArray());
        }

        /// <summary>
        /// 生成长度为5的随机字母/数字字符串
        /// </summary>
        /// <returns></returns>
        private static string getRandomCheckString()
        {
            string allCode = "1234567890qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
            string str = "";
            Random random = new Random();
            for (int i = 0; i < 5; ++i)
            {
                str += allCode[random.Next(allCode.Length)];
            }
            return str;
        }

        /// <summary>
        /// 向目标地址发送包含验证码的邮件，发送成功返回生成的验证码，失败返回空字符串
        /// </summary>
        /// <param name="aimEmailAddress"></param>
        /// <returns></returns>
        public static string sendEmailCheck(string aimEmailAddress)
        {
            string checkString = getRandomCheckString();
            try
            {
                //实例化一个发送邮件类。
                MailMessage mailMessage = new MailMessage();
                //发件人邮箱地址
                mailMessage.From = new MailAddress("welinkofficialteam@163.com");
                //收件人邮箱地址
                mailMessage.To.Add(aimEmailAddress);
                //邮件标题
                mailMessage.Subject = "WeLink";
                mailMessage.SubjectEncoding = Encoding.UTF8;
                //邮件内容。
                mailMessage.Body = "验证码：" + checkString;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.Priority = MailPriority.High;
                mailMessage.IsBodyHtml = true;

                //实例化一个SmtpClient类。
                SmtpClient client = new SmtpClient();
                //主机为163邮箱
                client.Host = "smtp.163.com";
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //使用安全加密连接。
                client.EnableSsl = true;
                //不和请求一块发送。
                client.UseDefaultCredentials = true;
                //验证发件人身份
                client.Credentials = new NetworkCredential("welinkofficialteam@163.com", "123abcdefg");
                //发送
                client.Send(mailMessage);
            }
            catch (Exception)
            {
                checkString = "";
            }
            return checkString;
        }

        #endregion

        /// <summary>
        /// 获取8位定长字符串的年月日
        /// </summary>
        /// <returns></returns>
        public static string getYearMonthDay()
        {
            return DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00");
        }

        /// <summary>
        /// 获取16位时间戳
        /// </summary>
        public static string getTimeStamp()
        {
            return DateTime.Now.Year.ToString("0000") + "/"
                + DateTime.Now.Month.ToString("00") + "/"
                + DateTime.Now.Day.ToString("00") + " "
                + DateTime.Now.Hour.ToString("00") + ":"
                + DateTime.Now.Minute.ToString("00");
        }

        /// <summary>
        /// 获取秒+毫秒时间
        /// </summary>
        /// <returns></returns>
        public static string getSecond()
        {
            return DateTime.Now.Second.ToString("00")
                + DateTime.Now.Millisecond.ToString("000");
        }

        /// <summary>
        /// 16位时间戳->12位
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string timeStamp16to12(string key)
        {
            string str = key.Substring(0, 4);
            str += key.Substring(5, 2);
            str += key.Substring(8, 2);
            str += key.Substring(11, 2);
            str += key.Substring(14, 2);
            return str;
        }

    }
}
