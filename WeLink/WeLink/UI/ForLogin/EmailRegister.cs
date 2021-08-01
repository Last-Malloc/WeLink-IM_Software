using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using WeLink.BLL;

namespace WeLink.UI
{
    public partial class EmailRegister : LayeredBaseForm
    {
        /// <summary>
        /// 成功返回邮箱，失败返回空字符串
        /// </summary>
        public string email = "";
        string checkCode = "";
        int cnt = 0;
        public ServerMain serverMain = null;
        bool loginNotCheck = false;

        public EmailRegister(ServerMain serverMain, bool loginNotCheck = false)
        {
            InitializeComponent();
            this.serverMain = serverMain;
            this.loginNotCheck = loginNotCheck;
            timer1.Interval = 1000;
            this.TopMost = true;
        }

        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendCheckCode_Click(object sender, EventArgs e)
        {
            if (textEmail.Text.Length == 0)
            {
                MyMessageBox.Show("请输入邮箱", "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (loginNotCheck == false)
            {
                serverMain.SendData(new StructGetInfo(TransType.LoginRequest, new LoginRequest(2, "emilcheck" + textEmail.Text)));
                //检查该邮箱是否返回账号
                LoginAnswer loginAnswer = serverMain.checkLoginAnswer();
                if (loginAnswer.loginSucOrNot == 1)
                {
                    //该邮箱已注册
                    MyMessageBox.Show("该邮箱已经与其他WeLink账户绑定，请更换邮箱", "邮箱验证失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            checkCode = ToolUnion.sendEmailCheck(textEmail.Text);
            Console.WriteLine(checkCode);
            if (checkCode == "")
            {
                MyMessageBox.Show("发送失败，请检查网络连接或稍后再试！", "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                cnt = 0;
                timer1.Start();
                btnSendCheckCode.Enabled = false;
            }
        }

        /// <summary>
        /// 每1s执行1次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            btnSendCheckCode.Text = (30 - cnt).ToString() + "s";
            ++cnt;
            if (cnt == 31)
            {
                timer1.Stop();
                btnSendCheckCode.Enabled = true;
                btnSendCheckCode.Text = "发送验证";
            }
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (checkCode.ToLower() == textCheckCode.Text.ToLower())
            {
                MyMessageBox.Show("邮箱验证成功！", "验证成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                email = textEmail.Text;
                this.Close();
            }
            else
            {
                 MyMessageBox.Show("邮箱验证失败，请重新输入！", "验证失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
