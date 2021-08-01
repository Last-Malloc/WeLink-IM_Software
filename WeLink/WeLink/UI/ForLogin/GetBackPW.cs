using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using WeLink.DAL;
using WeLink.BLL;

namespace WeLink.UI
{
    public partial class GetBackPW : LayeredBaseForm
    {
        #region 成员变量
        private ServerMain serverMain = null;
        #endregion

        #region UI层业务处理
        /// <summary>
        /// 构造函数
        /// </summary>
        public GetBackPW(ServerMain serverMain)
        {
            InitializeComponent();
            this.serverMain = serverMain;
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetBackPW_Load(object sender, EventArgs e)
        {
            textNewPW.Enabled = false;
            textNewPW2.Enabled = false;
            btnOK.Enabled = false;
        }

        /// <summary>
        /// 邮箱验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckEmail_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmailRegister emailRegister = new EmailRegister(serverMain, true);
            emailRegister.ShowDialog();
            string email = emailRegister.email;
            this.Show();
            //验证是本人使用的邮箱，接下来获取邮箱绑定的账号
            if (email != "")
            {
                serverMain.SendData(new StructGetInfo(TransType.LoginRequest, new LoginRequest(2, "emilcheck" + email)));
                //检查该邮箱是否返回账号
                LoginAnswer loginAnswer = serverMain.checkLoginAnswer();
                //验证成功，可以开始修改密码
                if (loginAnswer.loginSucOrNot == 1)
                {
                    textCardID.Text = loginAnswer.cardID;
                    btnCheckEmail.Enabled = false;
                    btnCheckFace.Enabled = false;
                    textNewPW.Enabled = true;
                    textNewPW2.Enabled = true;
                    btnOK.Enabled = true;
                }
                else
                {
                     MyMessageBox.Show("请更换验证方式或检查网络连接！", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 人脸识别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckFace_Click(object sender, EventArgs e)
        {
            this.Hide();
            FaceLogin faceLogin = new FaceLogin();
            faceLogin.ShowDialog();
            string cardID = faceLogin.id;
            this.Show();
            //验证成功
            if (cardID != "")
            {
                textCardID.Text = cardID;
                btnCheckEmail.Enabled = false;
                btnCheckFace.Enabled = false;
                textNewPW.Enabled = true;
                textNewPW2.Enabled = true;
                btnOK.Enabled = true;
            }
        }

        /// <summary>
        /// 确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (LoginDataDeal.rPassWordIsLegal(textNewPW.Text) == false)
            {
                 MyMessageBox.Show("新密码不符合要求！", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LoginDataDeal.rPassWordIsLegal(textNewPW2.Text) == false)
            {
                 MyMessageBox.Show("确认密码不符合要求！", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textNewPW.Text != textNewPW2.Text)
            {
                 MyMessageBox.Show("两次密码不一致！", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            serverMain.SendData(new StructGetInfo(TransType.UInfoUpdateRequest, 
                new UInfoUpdateRequest(1, textCardID.Text, textNewPW.Text)));
            bool flag = serverMain.checkExcuteUInfoUpdateRequest();
            //修改成功
            if (flag)
            {
                 MyMessageBox.Show("密码修改成功！", "修改成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                 MyMessageBox.Show("密码修改失败，请稍后再试或检查网络连接！", "修改失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region UI层连接处理
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
