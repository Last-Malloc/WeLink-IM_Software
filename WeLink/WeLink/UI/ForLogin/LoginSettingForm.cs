using System;
using System.Threading;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using WeLink.DAL;

namespace WeLink.UI
{
    public partial class LoginSettingForm : LayeredBaseForm
    {
        #region UI层业务处理
        public LoginSettingForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置按钮响应，设置与客户端进行通信的服务器IP地址和端口号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (textPort1.Text == "" || textPort2.Text == "" || textIP.Text == "")
                {
                     MyMessageBox.Show("设置输入框不能为空！", "设置失败！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ConfigXml.updateConfigXML("ip", textIP.Text);
                ConfigXml.updateConfigXML("port1", textPort1.Text);
                ConfigXml.updateConfigXML("port2", textPort2.Text);
                MyMessageBox.Show("服务器IP地址及端口号设置成功，重启应用后生效！", "设置成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                 MyMessageBox.Show(ex.Message, "设置失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region UI层连接处理
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 返回按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 最小化按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMiniClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
    }
}
