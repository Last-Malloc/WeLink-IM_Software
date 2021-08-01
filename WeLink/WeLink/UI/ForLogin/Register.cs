using System;
using System.Threading;
using System.Windows.Forms;
using LayeredSkin.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using WeLink.DAL;
using WeLink.BLL;
using System.Drawing;
using System.IO;

namespace WeLink.UI
{
    public partial class Register : LayeredBaseForm
    {
        #region 成员变量
        /// <summary>
        /// 申请成功为新账户，失败为空串
        /// </summary>
        public string cardID = "";
        private string headPicPath = System.Environment.CurrentDirectory + @"\system\moren.png";
        ServerMain serverMain = null;
        #endregion

        #region UI层业务处理
        /// <summary>
        /// 构造函数
        /// </summary>
        public Register(ServerMain serverMain)
        {
            InitializeComponent();
            radioMan.Checked = true;
            this.serverMain = serverMain;
        }
        
        /// <summary>
        /// 选择头像：为空时设置为system\moren.png
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseHead_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG图片|*.png|JPG图片|*.jpg";
            openFileDialog.Title = "选择头像图片";
            openFileDialog.ShowDialog();
            headPicPath = openFileDialog.FileName;
            if (headPicPath.Length == 0)
                headPicPath = System.Environment.CurrentDirectory + @"\system\moren.png";
            HeadImg.BackgroundImage = ToolUnion.Image_FromStream(headPicPath);
        }

        /// <summary>
        /// 申请按钮响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            //检查输入数据是否合法
            if (textName.Text.Length == 0 || textName.Text.Length > 5)
            {
                MyMessageBox.Show("昵称长度不合法!", "申请失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LoginDataDeal.rPassWordIsLegal(textPW.Text) == false)
            {
                MyMessageBox.Show("密码长度不合法或包含非法字符!", "申请失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textLife.Text.Length > 50)
            {
                MyMessageBox.Show("个性签名长度不合法!", "申请失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte tSex = 1;
            if (radioWoman.Checked)
            {
                tSex = 0;
            }
            string email = "";
            byte tFace = 0;
            UserRegisterRequest userRegisterRequest = new UserRegisterRequest(
                textPW.Text, textName.Text, tSex, tFace, email, textLife.Text);
            serverMain.SendData(new StructGetInfo(TransType.UserRegisterRequest, userRegisterRequest));
            bool tOK = serverMain.checkExcuteUserRegisterSuccess();
            //注册成功
            if (tOK)
            {
                cardID = serverMain.registerID;
                MyMessageBox.Show("注册成功，新账户为" + cardID + "！", "申请成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //后台上传头像
                Thread thread = new Thread(fun);
                thread.IsBackground = true;
                thread.Start();

                while (sendFinished == false)
                    Thread.Sleep(100);
                this.Close();
            }
        }

        /// <summary>
        /// 后台上传头像
        /// </summary>
        bool sendFinished = false;
        private void fun()
        {
            try
            {
                sendFinished = false;
                StructGetInfo getInfo = new StructGetInfo(TransType.HeadPicSubmitRequest,
                    new HeadPicSubmitRequest(cardID, ToolUnion.getFileStreamFromFile(headPicPath), headPicPath));
                serverMain.SendData(getInfo);
            }
            catch (Exception)
            {
            }
            sendFinished = true;
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
