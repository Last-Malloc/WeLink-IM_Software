using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeLink_Server.DAL
{
    class LoginLogsDataDeal : BaseDataDeal
    {
        public static void insertLoginLog(object o)
        {
            try
            {
                object[] b = (object[])o;
                string[] a = new string[b.Length];
                for (int i = 0; i < b.Length; i++)
                {
                    a[i] = (string)b[i];
                }
                try
                {
                    string sql = $"insert into LoginLogs values ('{a[0]}', '{a[1]}', '{a[2]}', '{a[3]}', '{a[4]}');";
                    BaseDataDeal.update(sql);
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
