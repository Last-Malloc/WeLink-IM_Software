using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeLink.BLL;

namespace WeLink.UI
{
    /// <summary>
    /// 显示和修改数据：对头像、邮箱、人脸作单独处理
    /// </summary>
    public partial class UserInfo : LayeredBaseForm
    {
        //用来传输数据的服务类
        ServerMain serverMain = null;
        MainForm mainForm = null;
        //主窗口传来的数据
        //源数据，确认提交完成后更改，且需要加载会主界面
        public LoginAnswer loginAnswerSource;
        private LoginAnswer loginAnswerTemp;  //可变数据，作临时存储用
        //用户是否信息改变了
        private string headPicPath = System.Environment.CurrentDirectory + @"\system\moren.png";
        private bool nameChanged = false;
        private bool sexChanged = false;
        private bool lifeChanged = false;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="loginAnswer"></param>
        public UserInfo(LoginAnswer loginAnswer, ServerMain serverMain, MainForm mainForm)
        {
            InitializeComponent();
            this.TopMost = true;
            //传入数据
            loginAnswerSource = loginAnswer;
            //只读状态（初始化loginAnSwerSource）
            readOnlyStatus();

            //对人脸识别和邮箱验证按钮做格外处理
            if (loginAnswerSource.email == "")
            {
                labelEmail.Text = "邮箱：未通过";
                btnEmail.Text = "绑定";
            }
            else
            {
                labelEmail.Text = "邮箱：" + loginAnswerSource.email;
                btnEmail.Text = "解除";
            }
            if (loginAnswerSource.passFace == 0)
            {
                labelFace.Text = "人脸识别：未通过";
                btnFace.Text = "绑定";
            }
            else
            {
                labelFace.Text = "人脸识别：已通过";
                btnFace.Text = "解除";
            }

            this.serverMain = serverMain;
            this.mainForm = mainForm;

            this.serverMain.getRecSyncInfo.setHeadPicForBaseControl(headImg, loginAnswerSource.cardID);
        }
        
        /// <summary>
        /// 将所做的更改上交至服务器
        /// </summary>
        private bool SubmitToClient()
        {
            bool flag = true;
            if (nameChanged)
            {
                serverMain.SendData(new StructGetInfo(TransType.UInfoUpdateRequest,
                    new UInfoUpdateRequest(2, loginAnswerTemp.cardID, loginAnswerTemp.name)));
                flag = serverMain.checkExcuteUInfoUpdateRequest();
            }
            if (sexChanged && flag)
            {
                string tSex = "男";
                if (loginAnswerTemp.sex == 0)
                {
                    tSex = "女";
                }
                serverMain.SendData(new StructGetInfo(TransType.UInfoUpdateRequest,
                    new UInfoUpdateRequest(3, loginAnswerTemp.cardID, tSex)));
            }
            if (lifeChanged && flag)
            {
                serverMain.SendData(new StructGetInfo(TransType.UInfoUpdateRequest,
                    new UInfoUpdateRequest(5, loginAnswerTemp.cardID, loginAnswerTemp.life)));
            }
            if (flag)
            {
                MyMessageBox.Show("信息修改成功！", "信息修改", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MyMessageBox.Show("信息修改失败！", "信息修改", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flag;
        }

        /// <summary>
        /// 邮箱按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (btnEmail.Text == "解除")
            {
                serverMain.SendData(new StructGetInfo(TransType.UInfoUpdateRequest,
                    new UInfoUpdateRequest(4, loginAnswerSource.cardID, "")));
                bool flag = serverMain.checkExcuteUInfoUpdateRequest();
                //修改成功
                if (flag)
                {
                    MyMessageBox.Show("邮箱解除绑定成功！", "解除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    labelEmail.Text = "邮箱：未通过";
                    btnEmail.Text = "绑定";
                    loginAnswerSource.email = "";
                }
                else
                {
                    MyMessageBox.Show("邮箱解除绑定失败！", "解除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                EmailRegister emailRegister = new EmailRegister(serverMain);
                emailRegister.ShowDialog();
                //邮箱验证成功
                if (emailRegister.email != "")
                {
                    serverMain.SendData(new StructGetInfo(TransType.UInfoUpdateRequest,
                    new UInfoUpdateRequest(4, loginAnswerSource.cardID, emailRegister.email)));
                    bool flag = serverMain.checkExcuteUInfoUpdateRequest();
                    //修改成功
                    if (flag)
                    {
                        MyMessageBox.Show("邮箱绑定绑定成功！", "绑定成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        labelEmail.Text = "邮箱：" + emailRegister.email;
                        btnEmail.Text = "解除";
                        loginAnswerSource.email = emailRegister.email;
                    }
                    else
                    {
                        MyMessageBox.Show("邮箱解除绑定失败！", "绑定失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 人脸识别按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFace_Click(object sender, EventArgs e)
        {
            if (btnFace.Text == "解除")
            {
                if (FaceRegister.FacePhotoDelete(loginAnswerSource.cardID))
                {
                    serverMain.SendData(new StructGetInfo(TransType.UInfoUpdateRequest,
                        new UInfoUpdateRequest(6, loginAnswerSource.cardID, "否")));
                    bool flag = serverMain.checkExcuteUInfoUpdateRequest();
                    //修改成功
                    if (flag)
                    {
                        MyMessageBox.Show("人脸识别解除绑定成功！", "解除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        labelFace.Text = "人脸识别：未通过";
                        btnFace.Text = "绑定";
                        loginAnswerSource.passFace = 0;
                    }
                    else
                    {
                        MyMessageBox.Show("人脸识别解除绑定失败！", "解除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MyMessageBox.Show("人脸识别解除绑定失败！", "解除失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                FaceRegister faceRegister = new FaceRegister(loginAnswerSource.cardID);
                faceRegister.ShowDialog();
                //人脸识别验证成功
                if (faceRegister.cardID != "")
                {
                    serverMain.SendData(new StructGetInfo(TransType.UInfoUpdateRequest,
                    new UInfoUpdateRequest(6, loginAnswerSource.cardID, "是")));
                    bool flag = serverMain.checkExcuteUInfoUpdateRequest();
                    //修改成功
                    if (flag)
                    {
                        MyMessageBox.Show("人脸识别绑定成功！", "绑定成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        labelFace.Text = "人脸识别：已通过";
                        btnFace.Text = "解除";
                        loginAnswerSource.passFace = 1;
                    }
                    else
                    {
                        MyMessageBox.Show("人脸识别" +
                            "绑定失败！", "绑定失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
       
        #region UI层连接处理

        /// <summary>
        /// 只读状态
        /// </summary>
        private void readOnlyStatus()
        {
            labelChangeInfo.Text = "编辑资料";
            textName.Hide();
            labelName.Text = "昵称：" + loginAnswerSource.name;
            panelSex.Hide();
            if (loginAnswerSource.sex == 1)
            {
                labelSex.Text = "性别：男";
            }
            else
            {
                labelSex.Text = "性别：女";
            }
            labelCardID.Text = "账户：" + loginAnswerSource.cardID;
            btnChooseHead.Hide();
            textLife.Hide();
            labelLife.Text = "个性签名：" + loginAnswerSource.life;
        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        private void inputStatus()
        {
            labelChangeInfo.Text = " 保  存 ";
            textName.Show();
            textName.Text = loginAnswerSource.name;
            panelSex.Show();
            if (loginAnswerSource.sex == 1)
            {
                radioMan.Checked = true;
            }
            else
            {
                radioWoman.Checked = true;
            }
            btnChooseHead.Show();
            textLife.Show();
            textLife.Text = loginAnswerSource.life;
        }

        /// <summary>
        /// 编辑资料标签点击事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelChangeInfo_Click(object sender, EventArgs e)
        {
            if (labelChangeInfo.Text == "编辑资料")
            {
                loginAnswerTemp = loginAnswerSource;
                inputStatus();
            }
            else
            {
                //分析信息合法性和是否进行了更新
                if (textName.Text.Length == 0 || textName.Text.Length > 5)
                {
                    MyMessageBox.Show("输入的昵称不合法", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textLife.Text.Length > 50)
                {
                    MyMessageBox.Show("个性签名长度不合法!", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textName.Text != loginAnswerTemp.name)
                {
                    loginAnswerTemp.name = textName.Text;
                    nameChanged = true;
                }
                if (loginAnswerTemp.sex == 1 && radioWoman.Checked)
                {
                    loginAnswerTemp.sex = 0;
                    sexChanged = true;
                }
                if (loginAnswerTemp.sex == 0 && radioMan.Checked)
                {
                    loginAnswerTemp.sex = 1;
                    sexChanged = true;
                }
                if (textLife.Text != loginAnswerTemp.life)
                {
                    loginAnswerTemp.life = textLife.Text;
                    lifeChanged = true;
                }

                //用户做了更改并且提交到服务器成功
                if ((nameChanged || lifeChanged || sexChanged) && SubmitToClient())
                {
                    loginAnswerSource = loginAnswerTemp;
                }
                //转换为只读状态
                readOnlyStatus();
            }
        }

        /// <summary>
        /// 选择图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseHead_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "PNG图片|*.png|JPG图片|*.jpg";
                openFileDialog.Title = "选择头像图片";
                openFileDialog.ShowDialog();
                string tPath = openFileDialog.FileName;
                //用户选择了新的头像
                if (tPath.Length != 0 && tPath != headPicPath)
                {
                    serverMain.SendData(new StructGetInfo(TransType.HeadPicSubmitRequest,
                        new HeadPicSubmitRequest(loginAnswerSource.cardID, ToolUnion.getFileStreamFromFile(tPath), tPath)));
                    bool flag = serverMain.checkHeadPicSubmitRequestIsOk();
                    //提交成功
                    if (flag)
                    {
                        headPicPath = tPath;
                        headImg.BackgroundImage = ToolUnion.Image_FromStream(headPicPath);
                        mainForm.HeadImg.BackgroundImage = ToolUnion.Image_FromStream(headPicPath);
                        MyMessageBox.Show("头像修改成功！", "头像修改", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MyMessageBox.Show("头像修改失败！", "头像修改", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 关闭按钮：关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (mainForm.userInfoClick)
            {
                mainForm.userInfoClick = false;
                mainForm.refreshLoginAnswer(loginAnswerSource);
            }
            this.Close();
            mainForm.Show();
        }

        /// <summary>
        /// 窗口移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMove(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
        #endregion
    }
}
