using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CCWin;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink.Properties;

namespace WeLink.UI
{
    public partial class UpdateInform : Skin_DevExpress
    {
        public UpdateInform()
        {
            InitializeComponent();
        }

        string[] str = null;
        int cnt = 1;
        private void UpdateInform_Load(object sender, EventArgs e)
        {
            str = new string[]
            {
                "1.全新界面设计，",
                "2.支持文字、表情、文件、震动消息",
                "3.添加好友/群支持按昵称模糊搜索方式",
                "4.取消用户注册/群申请的自主选号，改用随机选号方式",
                "5.优化用户体验：\n取消回车提示音；\n扩大消息输入区域；",
                "6.修复部分系统漏洞；\n提高服务器稳定性；"
            };
            timer1.Interval = 1500;
            timer1.Start();
        }

        private void setPicture(Bitmap bitmap)
        {
            int wid = 175 * bitmap.Width / bitmap.Height;
            pictureBox1.Width = wid;
            pictureBox1.Location = new Point(160 - wid / 2, 70);
            pictureBox1.BackgroundImage = bitmap;
        }

        private void setLineColor(int index)
        {
            switch (cnt)
            {
                case 0: skinLine6.LineColor = Color.Black; skinLine1.LineColor = Color.Gold; break;
                case 1: skinLine1.LineColor = Color.Black; skinLine2.LineColor = Color.Gold; break;
                case 2: skinLine2.LineColor = Color.Black; skinLine3.LineColor = Color.Gold; break;
                case 3: skinLine3.LineColor = Color.Black; skinLine4.LineColor = Color.Gold; break;
                case 4: skinLine4.LineColor = Color.Black; skinLine5.LineColor = Color.Gold; break;
                case 5: skinLine5.LineColor = Color.Black; skinLine6.LineColor = Color.Gold; break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (cnt)
            {
                case 1: setPicture(Resources.截图新增); break;
                case 2: setPicture(Resources.截图3); break;
                case 3: setPicture(Resources.截图4); break;
                case 4: setPicture(Resources.截图5); break;
                case 5: setPicture(Resources.截图61); break;
                case 6: cnt = 0; setPicture(Resources.截图);; break;
            }
            setLineColor(cnt);
            label1.Text = str[cnt];
            ++cnt;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
