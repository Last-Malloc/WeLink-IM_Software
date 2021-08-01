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
    public partial class GroupMem : LayeredBaseForm
    {
        string groupID = "";
        string groupName = "";
        string masterID = "";
        bool isMaster = false;
        ServerMain serverMain = null;
        GetRecSyncInfo getRecSync = null;
        Font itemFont = new Font("宋体", 12f, FontStyle.Regular);
        Color itemBackNormal = Color.FromArgb(100, 245, 245, 245);
        Color itemBackMouseEnter = Color.FromArgb(100, 223, 222, 223);
        public GroupMem(string groupID, string name, string masterID, bool isMaster, ServerMain serverMain)
        {
            InitializeComponent();
            this.groupID = groupID;
            this.groupName = name;
            this.masterID = masterID;
            this.isMaster = isMaster;
            this.serverMain = serverMain;
            getRecSync = serverMain.getRecSyncInfo;
        }

        /// <summary>
        /// 窗口加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupMem_Load(object sender, EventArgs e)
        {
            serverMain.SendData(new StructGetInfo(TransType.FriendGroupInfoRequest, new FriendGroupInfoRequest(groupID, "$$$$$$$$$$", 2)));
            GBriefMemInfoAnswer gBrief = serverMain.checkGBriefMemInfoAnswer();
            if (gBrief.gmCardID == null)
            {
                MyMessageBox.Show("获取群成员失败！", "获取失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int len = gBrief.gmCardID.Length;
            for (int i = 0; i < len; i++)
            {
                listBoxMem.Items.Add(addItems(gBrief.gmRemark[i], gBrief.gmCardID[i]));
            }
            listBoxMem.RefreshList();
        }

        /// <summary>
        /// 移除群成员操作：向服务器提交更改
        /// </summary>
        private void removeGroupMem(string cardID)
        {
            try
            {
                ADRequestInform aDRequestInform = new ADRequestInform();
                aDRequestInform.type = 1;
                aDRequestInform.cardID = groupID;
                aDRequestInform.IDType = 1;
                aDRequestInform.fCardID = cardID;
                aDRequestInform.fIDType = 0;
                aDRequestInform.time = ToolUnion.getTimeStamp();
                aDRequestInform.info = $"{groupName}({groupID}) 已将您删除。";
                serverMain.SendData(new StructGetInfo(TransType.ADRequestInform, aDRequestInform));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 向ListBox添加成员头像、群备注、账号、移除按钮，条目名为账号
        /// </summary>
        /// <param name="headimg"></param>
        /// <param name="nic"></param>
        /// <param name="qq"></param>
        /// <returns></returns>
        public DuiBaseControl addItems(string name, string cardID)
        {
            //首字母分界行
            if (cardID.StartsWith("$$$$$$$$$"))
            {
                //备注标签
                DuiLabel labelAlpha = DuiBaseControlClass.AddDuiLabel(name,
                    itemFont, new Size(20, 20), new Point(20, 0));
                DuiBaseControl itemAlpha = new DuiBaseControl();
                itemAlpha.BackColor = itemBackNormal;
                itemAlpha.Width = listBoxMem.Width;
                itemAlpha.Height = 20;
                itemAlpha.Borders.TopColor = Color.FromArgb(180, 180, 180);

                itemAlpha.Controls.Add(labelAlpha);
                return itemAlpha;
            }

            Bitmap headPic = new Bitmap(Properties.Resources.moren);
            //定义控件，添加显示头像图片
            DuiBaseControl pic = DuiBaseControlClass.AddDuiBaseControl(headPic, ImageLayout.Stretch, Cursors.Default, new Size(50, 50),
                new Point(5, 5));
            //备注标签
            DuiLabel labelName = DuiBaseControlClass.AddDuiLabel(name + "(" + cardID + ")",
                itemFont, new Size(165, 20), new Point(70, 20));
            //添加关闭按钮图片
            DuiBaseControl closepci = DuiBaseControlClass.AddDuiBaseControl(Resources.page_close_btn_normal, ImageLayout.Stretch, Cursors.Default, new Size(25, 25),
                new Point(252, 17));
            //控件的鼠标样式设置为手型
            closepci.Cursor = Cursors.Hand;

            //装有关闭按钮图片控件的鼠标点击、进入、离开、按下、抬起的响应
            closepci.MouseEnter += ItemsCloseMouseEnter;
            closepci.MouseLeave += ItemsCloseMouseLeave;
            closepci.MouseDown += ItemsCloseMouseDown;
            closepci.MouseUp += ItemsCloseMouseUp;
            closepci.Visible = false;//关闭按钮设置为可见

            //账号项容器控件，可以装载其他DuiBaseControl控件
            DuiBaseControl item = new DuiBaseControl();
            item.BackColor = itemBackNormal;
            item.Width = listBoxMem.Width;
            item.Height = 60;

            //设置该控件的鼠标抬起，进入，离开的响应
            item.MouseEnter += itemsMouseEnter;
            item.MouseLeave += itemsMouseLeave;

            item.Controls.Add(pic);//添加显示头像控件
            item.Controls.Add(labelName);//添加昵称标签
            item.Controls.Add(closepci);//添加关闭按钮控件
            item.Name = cardID;
            item.Visible = true;//账户项容器设置为可见

            getRecSync.setHeadPicForBaseControl(pic, cardID);

            return item;//返回整个账户项容器
        }
        
        #region 关闭按钮事件

        /// <summary>
        /// 鼠标进入事件：改变关闭按钮图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsCloseMouseEnter(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackgroundImage = Resources.page_close_btn_hover;
        }

        /// <summary>
        /// 鼠标进入事件：改变关闭按钮图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsCloseMouseLeave(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackgroundImage = Resources.page_close_btn_normal;
        }

        /// <summary>
        /// 鼠标抬起事件：改变关闭按钮图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsCloseMouseUp(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackgroundImage = Resources.page_close_btn_hover;
        }

        /// <summary>
        /// 鼠标按下事件：显示是否确认移除群成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsCloseMouseDown(object sender, EventArgs e)
        {
            DialogResult dialogResult = MyMessageBox.Show("是否移除该群成员？", "移除群成员", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.OK)
            {
                removeGroupMem(curItem.Name);
            }
        }

        #endregion

        #region 条目美化

        DuiBaseControl curItem = null;

        /// <summary>
        /// 进入条目：改变背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsMouseEnter(object sender, EventArgs e)
        {
            DuiBaseControl temp = (DuiBaseControl)sender;
            temp.BackColor = itemBackMouseEnter;
            if (isMaster && temp.Name != masterID)
            {
                temp.Controls[2].Visible = true;
                curItem = temp;
            }
        }

        /// <summary>
        /// 离开条目，改变背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemsMouseLeave(object sender, EventArgs e)
        {
            DuiBaseControl temp = (DuiBaseControl)sender;
            temp.BackColor = itemBackNormal;
            temp.Controls[2].Visible = false;
        }

        #endregion

        /// <summary>
        /// 关闭按钮：关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
