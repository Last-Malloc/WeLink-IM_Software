using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink.DAL;
using WeLink.UI;
using WeLink.BLL;
using System.Xml.Linq;
using System.Drawing;
using System.Threading;
using System.Diagnostics;

namespace WeLink
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //首次安装的数据库准备
            BaseDataDeal.projectInit();
            Application.Run(new LoginForm());
        }
    }
}
