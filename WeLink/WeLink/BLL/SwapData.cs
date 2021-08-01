using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WeLink.BLL
{
    /// <summary>
    /// 客户端与服务器间的直接数据交换
    /// send方法发送数据，receive方法接收数据，分片传输每片最大承载2MB
    /// </summary>
    class SwapData
    {
        /// <summary>
        /// 接收并组装字节流片 上交给 Protocol层
        /// </summary>
        /// <param name="socketTypeAndSocket"></param>
        /// <returns></returns>
        public static byte[] receive(Socket socketSend)
        {
            List<byte> byteStream = new List<byte>();
            try
            {
                //头部1字节为序号，0表示某次传输大字节流的最后一个片，>0则不是
                byte[] buffer = new byte[2 * 1024 * 1024 + 1];
                while (true)
                {
                    int r = socketSend.Receive(buffer);
                    byteStream.AddRange(buffer.Skip(1).Take(r - 1));
                    //得到某次传输数据流的最后一片
                    if (buffer[0] == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception)
            {
                //服务器负责通信的socket关闭时，向上层抛出异常
                throw;
            }
            return byteStream.ToArray();
        }

        /// <summary>
        /// 将Protocol层设置的 字节流 分片发送
        /// </summary>
        /// <param name="sendInfo"></param>
        public static bool send(Socket socketSend, byte[] byteStream)
        {
            try
            {
                List<byte> buffer = new List<byte>();
                int startCnt = 0, len = 2 * 1024 * 1024;
                int cnt = (int)Math.Ceiling(byteStream.Length / (1.0 * len));
                for (int i = cnt - 1; i >= 0; --i)
                {
                    buffer.Clear();
                    buffer.Add(ToolUnion.intToByteZeroToNine(i));
                    if (i == 0)
                        buffer.AddRange(byteStream.Skip(startCnt * len));
                    else
                        buffer.AddRange(byteStream.Skip(startCnt * len).Take(len));
                    ++startCnt;
                    socketSend.Send(buffer.ToArray());
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}
