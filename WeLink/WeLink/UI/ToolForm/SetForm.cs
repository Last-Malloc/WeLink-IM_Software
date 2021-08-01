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
using CCWin;
using System.Diagnostics;
using System.IO;

namespace WeLink.UI
{
    public partial class SetForm : Skin_DevExpress
    {
        MainForm mainForm = null;
        /// <summary>
        /// 登录成功的账号
        /// </summary>
        private string cardID = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SetForm(string cardID, ContextMore contextMore)
        {
            InitializeComponent();
            this.cardID = cardID;
            this.mainForm = contextMore.mainForm;
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetForm_Load(object sender, EventArgs e)
        {
            //读取文件保存位置
            string str = ConfigXml.selectConfigXML(cardID + "文件保存路径");
            textFile.Text = str;
        }

        /// <summary>
        /// 窗口移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveForm(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// 更改按钮：更改文件保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择目录";
            folder.ShowDialog();
            string folderPath = folder.SelectedPath;
            if (folderPath.Length != 0)
            {
                ConfigXml.updateConfigXML(cardID + "文件保存路径", folderPath);
                textFile.Text = folderPath;
            }
        }

        /// <summary>
        /// 打开按钮：打开该文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(textFile.Text);
            }
            catch (Exception)
            {
                MyMessageBox.Show("打开失败，文件已移动。", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// 打开帮助文档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenHelpDoc_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Environment.CurrentDirectory + @"\system\帮助文档.pdf");
            }
            catch (Exception)
            {
                MyMessageBox.Show("打开失败，文件已移动。", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 删除账号的全部缓存信息并注销账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearCookie_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MyMessageBox.Show("是否删除账号\n" +cardID + "\n的所有本地缓存记录并注销登录？",
                "删除缓存", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //删除在recent表中的记录
            if (dialogResult == DialogResult.OK)
            {
                LoginDataDeal.deleteUserList(cardID);
                //删除该账号的缓存文件夹
                LoginDataDeal.deleteUserCookie(cardID);
                //刷新显示
                mainForm.loginForm.RefreshUserList();
                //注销登录
                mainForm.closeAppOrChangeID = false;
                mainForm.Close();
            }
        } 

        /// <summary>
        /// 删除客户端所有数据并关闭客户端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MyMessageBox.Show("是否删除客户端所有数据并退出？",
                "删除缓存", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                //删除\cookie文件夹
                try
                {
                    if (Directory.Exists(Environment.CurrentDirectory + "\\cookie"))
                    {
                        LoginDataDeal.deleteFolder(@"cookie");
                        Directory.Delete(Environment.CurrentDirectory + "\\cookie");
                    }
                }
                catch (Exception)
                {
                }
                //注销登录
                mainForm.closeAppOrChangeID = true;
                mainForm.Close();
            }
        }

        /// <summary>
        /// 清除账号的本地聊天纪录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearChatRecord_Click(object sender, EventArgs e)
        {
            LoginAnswer loginAnswer = mainForm.loginAnswerSource;
            string connStr = BaseDataDeal.getConnString($@"cookie\userdata\{loginAnswer.cardID}\info.db3");
            try
            {
                string sql = $"delete from chatinfo;";
                BaseDataDeal.update(sql, connStr);
                mainForm.initMessageShowForm();
            }
            catch (Exception)
            {
            }
        }
    }
}
