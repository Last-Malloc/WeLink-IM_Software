using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink.DAL;
using WeLink.BLL;
using System.Threading;

namespace WeLink.UI
{
    public partial class CreateGroup : LayeredBaseForm
    {
        MainForm mainForm = null;
        ServerMain serverMain = null;

        public CreateGroup(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.serverMain = this.mainForm.serverMain;
            this.TopMost = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainForm.WindowState = FormWindowState.Normal;
            this.Close();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (textgName.Text.Length == 0 || textgName.Text.Length > 5)
                {
                    MyMessageBox.Show("群名长度应为1-5！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textgRemark.Text.Length > 5)
                {
                    MyMessageBox.Show("群名片长度应小于5，您可以使用默认值！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string remark = textgRemark.Text;
                LoginAnswer loginAnswer = mainForm.loginAnswerSource;
                if (remark == "")
                {
                    remark = loginAnswer.name;
                }
                serverMain.SendData(new StructGetInfo(TransType.GroupInfoAnswer,
                    new GroupInfoAnswer("$$$$$$$$$$", textgName.Text, "", loginAnswer.cardID, remark, textgAffiche.Text)));
                Thread thread = new Thread(waitReply);
                thread.IsBackground = true;
                thread.Start();
            }
            catch (Exception)
            {
                MyMessageBox.Show("网络异常，请稍后重试！", "申请失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 等待回应并提示/处理
        /// </summary>
        private void waitReply()
        {
            byte result = serverMain.checkGroupRegister();
            if (result == 0)
            {
                MyMessageBox.Show("申请失败，请稍后重试！", "申请失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MyMessageBox.Show("申请成功，群号为" + serverMain.registerGID + "！", "申请成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainForm.addGroupItem(serverMain.registerGID, textgName.Text);
                mainForm.WindowState = FormWindowState.Normal;
                this.Close();
            }
        }

    }
}
