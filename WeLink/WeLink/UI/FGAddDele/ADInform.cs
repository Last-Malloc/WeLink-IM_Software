using LayeredSkin.DirectUI;
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
using WeLink.Properties;

namespace WeLink.UI
{
    public partial class ADInform : LayeredBaseForm
    {
        MainForm mainForm = null;
        ServerMain serverMain = null;
        GetRecSyncInfo getRecSync = null;
        List<ADRequestInform> informFriendCookie = null;
        List<ADRequestInform> informGroupCookie = null;
        byte operateObj = 0;//0通过点击 新的朋友 打开，1通过点击 新的群 打开
        public ADInform(byte operateObj, List<ADRequestInform> informFriendCookie, List<ADRequestInform> informGroupCookie, MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.serverMain = this.mainForm.serverMain;
            this.getRecSync = this.serverMain.getRecSyncInfo;
            this.operateObj = operateObj;
            this.informFriendCookie = informFriendCookie;
            this.informGroupCookie = informGroupCookie;
            if (operateObj == 0)
            {
                foreach (ADRequestInform item in informFriendCookie)
                {
                    listBox.Items.Add(addItem(item.cardID, item.time, item.info));
                }
            }
            else
            {
                foreach (ADRequestInform item in informGroupCookie)
                {
                    listBox.Items.Add(addItem(item.cardID, item.time, item.info));
                }
            }
            listBox.RefreshList();
            this.TopMost = true;
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

        public Font itemFont = new Font("宋体", 10f, FontStyle.Regular);

        /// <summary>
        /// 添加条目，显示头像，账号，时间，验证信息，名称为账号加类型(用户/群)
        /// </summary>
        /// <param name="cardID"></param>
        /// <param name="name"></param>
        /// <param name="online"></param>
        public DuiBaseControl addItem(string cardID, string time, string info)
        {
            DuiBaseControl pic = DuiBaseControlClass.AddDuiBaseControl(Resources.moren,
                ImageLayout.Stretch, Cursors.Default, new Size(40, 40), new Point(10, 10));

            if (operateObj == 0)
                getRecSync.setHeadPicForBaseControl(pic, cardID);
            else
                pic.BackgroundImage = Resources.群组;

            //账号标签
            DuiLabel labelIDTime = DuiBaseControlClass.AddDuiLabel(cardID + "(" + time + ")",
                itemFont, new Size(400, 15), new Point(60, 5));

            //验证信息标签
            DuiLabel labelInfo = DuiBaseControlClass.AddDuiLabel(info,
                itemFont, new Size(340, 35), new Point(60, 20));

            DuiLabel agree = DuiBaseControlClass.AddDuiLabel("同意",
                itemFont, new Size(40, 15), new Point(400, 17));
            DuiLabel disAgree = DuiBaseControlClass.AddDuiLabel("拒绝",
                itemFont, new Size(40, 15), new Point(450, 17));
            agree.BackColor = disAgree.BackColor = Color.FromArgb(252, 228, 214);
            agree.TextAlign = disAgree.TextAlign = ContentAlignment.MiddleCenter;
            agree.MouseClick += OnBtnAgreeClicked;
            disAgree.MouseClick += OnBtnDisAgreeClicked;

            DuiBaseControl item = new DuiBaseControl();
            item.Width = listBox.Width;
            item.Height = 60;
            if (listBox.Items.Count % 2 == 1)
            {
                item.BackColor = Color.FromArgb(217, 225, 242);
            }
            else
            {
                item.BackColor = Color.FromArgb(226, 239, 218);
            }

            item.Controls.Add(pic);
            item.Controls.Add(labelIDTime);
            item.Controls.Add(labelInfo);
            item.Controls.Add(agree);
            item.Controls.Add(disAgree);
            item.Name = cardID + operateObj.ToString();
            return item;
        }

        /// <summary>
        /// 点击同意按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnAgreeClicked(object sender, MouseEventArgs e)
        {
            DuiBaseControl item = (DuiBaseControl)((DuiLabel)sender).Parent;
            string tInfo = "";
            listBox.Items.Remove(item);
            listBox.RefreshList();

            if (operateObj == 0)
            {
                foreach (ADRequestInform temp in informFriendCookie)
                {
                    if (temp.cardID == item.Name.Substring(0, 10))
                    {
                        AddDeleDeal addDeleDeal = new AddDeleDeal();
                        addDeleDeal.cardID = temp.cardID;
                        addDeleDeal.IDType = temp.IDType;
                        addDeleDeal.fCardID = temp.fCardID;
                        addDeleDeal.fIDType = temp.fIDType;
                        addDeleDeal.time = temp.time;
                        addDeleDeal.dealResult = 0;
                        serverMain.SendData(new StructGetInfo(TransType.AddDeleDeal,
                            addDeleDeal));
                        informFriendCookie.Remove(temp);
                        tInfo = temp.info;
                        break;
                    }
                }
            }
            else
            {
                foreach (ADRequestInform temp in informGroupCookie)
                {
                    if (temp.cardID == item.Name.Substring(0, 10))
                    {
                        AddDeleDeal addDeleDeal = new AddDeleDeal();
                        addDeleDeal.cardID = temp.cardID;
                        addDeleDeal.IDType = temp.IDType;
                        addDeleDeal.fCardID = temp.fCardID;
                        addDeleDeal.fIDType = temp.fIDType;
                        addDeleDeal.time = temp.time;
                        addDeleDeal.dealResult = 0;
                        serverMain.SendData(new StructGetInfo(TransType.AddDeleDeal,
                            addDeleDeal));
                        informGroupCookie.Remove(temp);
                        break;
                    }
                }
            }
            if (operateObj == 0)
            {
                try
                {
                    int index = tInfo.IndexOf('(');
                    string name = tInfo.Substring(0, index);
                    string cardID = tInfo.Substring(index + 1, 10);
                    mainForm.linkFriendItem.Add(cardID, mainForm.addItem(cardID, name, 1));
                    try
                    {
                        mainForm.linkNameFriend.Add(name, cardID);
                    }
                    catch (Exception)
                    {
                    }
                    mainForm.refreshLinkFriend();
                }
                catch (Exception)
                {
                }
            }
            else
                mainForm.initGroupInfomCnt();
        }

        /// <summary>
        /// 点击不同意按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnDisAgreeClicked(object sender, MouseEventArgs e)
        {
            DuiBaseControl item = (DuiBaseControl)((DuiLabel)sender).Parent;
            listBox.Items.Remove(item);
            listBox.RefreshList();

            if (operateObj == 0)
            {
                foreach (ADRequestInform temp in informFriendCookie)
                {
                    if (temp.cardID == item.Name.Substring(0, 10))
                    {
                        AddDeleDeal addDeleDeal = new AddDeleDeal();
                        addDeleDeal.cardID = temp.cardID;
                        addDeleDeal.IDType = temp.IDType;
                        addDeleDeal.fCardID = temp.fCardID;
                        addDeleDeal.fIDType = temp.fIDType;
                        addDeleDeal.time = temp.time;
                        addDeleDeal.dealResult = 1;
                        serverMain.SendData(new StructGetInfo(TransType.AddDeleDeal,
                            addDeleDeal));
                        informFriendCookie.Remove(temp);
                        break;
                    }
                }
            }
            else
            {
                foreach (ADRequestInform temp in informGroupCookie)
                {
                    if (temp.cardID == item.Name.Substring(0, 10))
                    {
                        AddDeleDeal addDeleDeal = new AddDeleDeal();
                        addDeleDeal.cardID = temp.cardID;
                        addDeleDeal.IDType = temp.IDType;
                        addDeleDeal.fCardID = temp.fCardID;
                        addDeleDeal.fIDType = temp.fIDType;
                        addDeleDeal.time = temp.time;
                        addDeleDeal.dealResult = 1;
                        serverMain.SendData(new StructGetInfo(TransType.AddDeleDeal,
                            addDeleDeal));
                        informGroupCookie.Remove(temp);
                        break;
                    }
                }
            }
            if (operateObj == 0)
                mainForm.initFriendInfomCnt();
            else
                mainForm.initGroupInfomCnt();
        }

        #region 窗口移动

        private Point mouseOff;//鼠标移动位置变量
        private bool leftFlag;//鼠标是否为左键
        private void TheMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y);//获得当前鼠标的坐标
                leftFlag = true;
            }
        }

        private void TheMouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;//获得移动后鼠标的坐标
                mouseSet.Offset(mouseOff.X, mouseOff.Y);//设置移动后的位置
                Location = mouseSet;
            }
        }

        private void TheMouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;
            }
        }

        #endregion

    }
}
