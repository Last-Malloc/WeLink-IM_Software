using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;
using WeLink.DAL;
using WeLink.BLL;
using WeLink.Properties;
using System.Threading;

namespace WeLink.UI
{
    public partial class AddFG : Skin_DevExpress
    {
        #region 构造、加载函数、刷新

        MainForm mainForm = null;
        ServerMain serverMain = null;
        GetRecSyncInfo getRecSync = null;
        string sourceCardID = null;
        string sourceName = null;

        public AddFG(MainForm mainForm)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            
            this.mainForm = mainForm;
            serverMain = mainForm.serverMain;
            getRecSync = serverMain.getRecSyncInfo;
            LoginAnswer loginAnswer = mainForm.loginAnswerSource;
            sourceCardID = loginAnswer.cardID;
            sourceName = loginAnswer.name;
            this.TopMost = true;
        }

        private void AddFG_Load(object sender, EventArgs e)
        {
            comboAddType.SelectedIndex = 0;
        }

        #endregion

        /// <summary>
        /// 设置信息
        /// </summary>
        /// <param name="userGroupInfoAnswer"></param>
        void setInfo(UserGroupInfoAnswer userGroupInfoAnswer)
        {
            panel.Visible = true;
            btnOK.Enabled = true;
            if (userGroupInfoAnswer.answerType == 0)
            {
                getRecSync.setHeadPicForBaseControl(HeadImg, userGroupInfoAnswer.cardID);

                iconSex.Visible = true;
                if (userGroupInfoAnswer.master == "男")
                {
                    iconSex.BackgroundImage = Resources.男;
                }
                else
                {
                    iconSex.BackgroundImage = Resources.女;
                }
                
                label群主.Visible = false;
                label昵称.Text = "昵称";
                label账号.Text = "账号";
                
                labelMaster.Visible = false;
                labelName.Text = userGroupInfoAnswer.name;
                labelCardID.Text = userGroupInfoAnswer.cardID;
                
                label签名.Text = "个性签名";
                labelLife.Text = userGroupInfoAnswer.life; 
            }
            else
            {
                HeadImg.BackgroundImage = Properties.Resources.群组;

                iconSex.Visible = false;

                label群主.Visible = true;
                label昵称.Text = "群名";
                label账号.Text = "群号";

                labelMaster.Visible = true;
                labelName.Text = userGroupInfoAnswer.name;
                labelCardID.Text = userGroupInfoAnswer.cardID;
                string cardID = userGroupInfoAnswer.master.Substring(0, 10);
                string name = userGroupInfoAnswer.master.Substring(10);
                labelMaster.Text = name + "(" + cardID + ")";
                
                label签名.Text = "群公告";
                labelLife.Text = userGroupInfoAnswer.life;
            }
        }

        /// <summary>
        /// 搜索按钮：搜索用户或群
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            panel.Visible = false;
            btnOK.Enabled = false;
            textCheckStr.Text = "";
            if (comboAddType.SelectedIndex == 0)
            {
                string str = textIDorEmail.Text;
                byte type = 2;
                if (LoginDataDeal.rCardIDIsLegal(str))
                {
                    type = 0;
                }
                serverMain.SendData(new StructGetInfo(TransType.UserGroupInfoRequest, 
                    new UserGroupInfoRequest(textIDorEmail.Text, type)));
            }
            else
            {
                string str = textIDorEmail.Text;
                byte type = 1;
                serverMain.SendData(new StructGetInfo(TransType.UserGroupInfoRequest,
                    new UserGroupInfoRequest(textIDorEmail.Text, type)));
            }
            Thread thread = new Thread(fun);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 确认发送申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //判断是否已经是已经是好友或本账号
            if (labelCardID.Text == sourceCardID && comboAddType.SelectedIndex == 0)
            {
                MyMessageBox.Show("不可添加登录账号为好友！", "申请失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mainForm.linkFriendItem.ContainsKey(labelCardID.Text) && comboAddType.SelectedIndex == 0)
            {
                MyMessageBox.Show("您已添加该用户为好友！", "申请失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mainForm.linkGroupItem.ContainsKey(labelCardID.Text) && comboAddType.SelectedIndex == 1)
            {
                MyMessageBox.Show("您已加入该群！", "申请失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ADRequestInform aDRequestInform = new ADRequestInform();
                aDRequestInform.type = 0;
                aDRequestInform.cardID = sourceCardID;
                aDRequestInform.IDType = 0;
                aDRequestInform.fCardID = labelCardID.Text;
                aDRequestInform.time = ToolUnion.getTimeStamp();
                string info = "";
                if (comboAddType.SelectedIndex == 0)
                {
                    aDRequestInform.fIDType = 0;
                    info = $"{sourceName}({sourceCardID}) 申请添加您为好友:{textCheckStr.Text}";
                    if (LoginDataDeal.rCardIDIsLegal(textIDorEmail.Text))
                    {
                        info += "(对方通过账号查找)。";
                    }
                    else
                    {
                        info += "(对方通过邮箱查找)。";
                    }
                }
                else
                {
                    aDRequestInform.fIDType = 1;
                    info = $"{sourceName}({sourceCardID}) 申请加入群 {labelName.Text}({labelCardID.Text}):{textCheckStr.Text}。";
                }
                aDRequestInform.info = info;
                serverMain.SendData(new StructGetInfo(TransType.ADRequestInform, aDRequestInform));
                MyMessageBox.Show("发送申请成功！", "申请成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MyMessageBox.Show("发送申请失败，请稍后重试！", "申请失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 界面美化与连接

        /// <summary>
        /// 临时供线程调用函数
        /// </summary>
        /// <param name="o"></param>
        void fun()
        {
            UserGroupInfoAnswer userGroupInfoAnswer = serverMain.checkUserGroupInfoAnswer();
            if (userGroupInfoAnswer.cardID != null)
                setInfo(userGroupInfoAnswer);
            else
            {
                MyMessageBox.Show("未找到用户/群！", "未找到", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            mainForm.WindowState = FormWindowState.Normal;
            this.Close();
        }

        private void comboAddType_SelectedIndexChanged(object sender, EventArgs e)
        {
            textIDorEmail.Text = textCheckStr.Text = "";
            btnOK.Enabled = false;
            panel.Hide();
            if (comboAddType.SelectedIndex == 0)
            {
                textIDorEmail.WaterText = "输入用户账号/邮箱/昵称";
            }
            else
            {
                textIDorEmail.WaterText = "输入群账号/群名";
            }
        }

        /// <summary>
        /// 窗口移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        #endregion
    }
}
