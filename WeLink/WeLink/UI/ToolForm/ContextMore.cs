using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink.BLL;

namespace WeLink.UI
{
    public partial class ContextMore : LayeredBaseForm
    {
        ServerMain serverMain = null;
        public MainForm mainForm = null;
        public ContextMore(MainForm mainForm)
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.TopMost = true;

            this.mainForm = mainForm;
            this.serverMain = this.mainForm.serverMain;
        }

        /// <summary>
        /// 失去焦点后关闭该菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMore_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            mainForm.closeAppOrChangeID = true;
            mainForm.saveChatStatus();
            mainForm.Close();
        }

        /// <summary>
        /// 切换账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangeID_Click(object sender, EventArgs e)
        {
            mainForm.closeAppOrChangeID = false;
            mainForm.saveChatStatus();
            mainForm.Close();
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginAnswer l = mainForm.loginAnswerSource;
            SetForm setForm = new SetForm(l.cardID, this);
            setForm.ShowDialog();
        }
    }
}
