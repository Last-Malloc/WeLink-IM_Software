using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using WeLink.Properties;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;
using WeLink.BLL;
using WeLink.DAL;
using System.Threading;

namespace WeLink.UI
{
    public partial class UserList : LayeredBaseForm
    {
        #region 构造函数 和 成员变量
        private LayeredTextBox textCardID;//账户输入框
        private LoginForm loginForm = null;
        private GetRecSyncInfo getRecSyncInfo = null;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="textCardID"></param>
        /// <param name="textPW"></param>
        /// <param name="headbase"></param>
        public UserList(LayeredTextBox textCardID, LoginForm loginForm, RecentUserList[] recentUserList)
        {
            InitializeComponent();
            getRecSyncInfo = loginForm.serverMain.getRecSyncInfo;
            this.ShowInTaskbar = false;
            this.textCardID = textCardID;
            this.loginForm = loginForm;
            setUserInfo(recentUserList);
        }

        #endregion

        /// <summary>
        /// 鼠标按下事件：改变按钮图片，删除该条并进行相应处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsCloseMouseDown(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackgroundImage = Resources.page_close_btn_click;
            int index = Int32.Parse(((DuiBaseControl)((DuiBaseControl)sender).Parent).Name);
            string cardID = ((DuiLabel)(layeredListBox1.Items[index].Controls[1])).Text;
            DialogResult dialogResult = MyMessageBox.Show("是否删除账号\n" + cardID + "\n的所有本地缓存记录？" +
                "\n(否:不再在本列表中显示)", "删除记录", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            //删除在recent表中的记录
            if (dialogResult != DialogResult.Cancel)
            {
                LoginDataDeal.deleteUserList(cardID);
                //删除该账号的缓存文件夹
                if (dialogResult == DialogResult.Yes)
                {
                    LoginDataDeal.deleteUserCookie(cardID);
                }
                //刷新显示
                loginForm.RefreshUserList();
            }
        }

        /// <summary>
        /// 向ListBox中写入用户列表并刷新
        /// </summary>
        public void setUserInfo(RecentUserList[] recentUserList)
        {
            foreach (RecentUserList item in recentUserList)
            {
                layeredListBox1.Items.Add(
                    AddChatItems(item.name, item.cardID));
            }
            layeredListBox1.RefreshList();
        }

        /// <summary>
        /// 向ListBox插入单个用户的头像、昵称、账号
        /// </summary>
        /// <param name="headimg"></param>
        /// <param name="nic"></param>
        /// <param name="qq"></param>
        /// <returns></returns>
        public DuiBaseControl AddChatItems(string name, string cardID)
        {
            Bitmap headPic = new Bitmap(Properties.Resources.moren);
            //昵称标签
            DuiLabel labelName = DuiBaseControlClass.AddDuiLabel(string.Format("{0}", name),
                DuiBaseControlClass.Msgfont, new Size(this.Width - 55, 20), new Point(30, 8));
            //账号标签
            DuiLabel labelCardID = DuiBaseControlClass.AddDuiLabel(cardID, DuiBaseControlClass.Msgfont, new Size(this.Width - 85, 20),
                    new Point(30, 30));
            //定义控件，添加显示头像图片
            DuiBaseControl pic = DuiBaseControlClass.AddDuiBaseControl(headPic, ImageLayout.Stretch, Cursors.Default, new Size(22, 22),
                new Point(5, 5));
            //控件添加背景色
            pic.BackColor = Color.BurlyWood;
            //定义控件，添加关闭按钮图片
            DuiBaseControl closepci = DuiBaseControlClass.AddDuiBaseControl(Resources.page_close_btn_normal, ImageLayout.Stretch, Cursors.Default, new Size(25, 25),
                new Point(layeredListBox1.Width - 30, 4));
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
            item.BackColor = Color.Transparent;
            item.Width = layeredListBox1.Width - 10;
            item.Height = 32;
            //设置该控件的鼠标抬起，进入，离开的响应
            item.MouseClick += ItemsMouseClick;
            item.MouseEnter += ItemsMouseEnter;
            item.MouseLeave += ItemsMouseLeave;

            item.Controls.Add(labelName);//添加昵称标签
            item.Controls.Add(labelCardID);//添加账户标签
            item.Controls.Add(pic);//添加显示头像控件
            item.Controls.Add(closepci);//添加显示关闭按钮控件
            item.Name = this.layeredListBox1.Items.Count.ToString();//账户项容器的名称为当前ListBox的item数量
            item.Visible = true;//账户项容器设置为可见

            getRecSyncInfo.setHeadPicForBaseControl(pic, cardID);

            return item;//返回整个账户项容器
        }

        #region UI美化

        private Font _font1 = new Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
            ((byte)(134)));
        private Font _font2 = new Font("微软雅黑", 9.3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
            ((byte)(134)));

        /// <summary>
        /// 当前窗口不为活动窗口时关闭该窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMenu_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 账号项容器事件

        /// <summary>
        /// 账号项容器点击事件：关闭列表，并将点击项的账号设置在账号输入框内
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsMouseClick(object sender, MouseEventArgs e)
        {
            textCardID.Text =  ((DuiLabel)(((DuiBaseControl)sender).Controls[1])).Text;
            this.layeredListBox1.RefreshList();
            this.Close();
        }

        /// <summary>
        /// 账户项容器鼠标项进入事件：当前项显示昵称关闭按钮并增大账号和头像显示等外观改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsMouseEnter(object sender, EventArgs e)
        {
            int ItemsIndex = int.Parse(((DuiBaseControl)sender).Name);
            int one = ItemsIndex - 2;
            int two = ItemsIndex - 1;
            int tree = ItemsIndex;
            int four = ItemsIndex + 1;
            int five = ItemsIndex + 2;

            if (one > -1)
            {
                layeredListBox1.Items[one].Height = 32;
                layeredListBox1.Items[one].Controls[0].Visible = false;
                layeredListBox1.Items[one].Controls[1].Location = new Point(30, 8);
                layeredListBox1.Items[one].Controls[2].Size = new Size(22, 22);
            }
            layeredListBox1.RefreshList();
            if (two > -1)
            {
                layeredListBox1.Items[two].Height = 45;
                layeredListBox1.Items[two].Controls[0].Visible = false;
                layeredListBox1.Items[two].Controls[1].Location = new Point(42, 10);
                layeredListBox1.Items[two].Controls[2].Size = new Size(35, 35);
            }
            layeredListBox1.RefreshList();
            layeredListBox1.Items[tree].Height = 53;
            layeredListBox1.Items[tree].Controls[0].Visible = true;
            layeredListBox1.Items[tree].Controls[0].Location = new Point(50, 7);
            layeredListBox1.Items[tree].Controls[1].Location = new Point(50, 28);
            layeredListBox1.Items[tree].Controls[2].Size = new Size(43, 43);
            ((DuiBaseControl)sender).Controls[3].Location = new Point(layeredListBox1.Width - 50, 14);
            layeredListBox1.RefreshList();
            if (four < layeredListBox1.Items.Count)
            {
                layeredListBox1.Items[four].Height = 45;
                layeredListBox1.Items[four].Controls[0].Visible = false;
                layeredListBox1.Items[four].Controls[1].Location = new Point(42, 10);
                layeredListBox1.Items[four].Controls[2].Size = new Size(35, 35);
            }
            layeredListBox1.RefreshList();
            if (five < layeredListBox1.Items.Count)
            {
                layeredListBox1.Items[five].Height = 32;
                layeredListBox1.Items[five].Controls[0].Visible = false;
                layeredListBox1.Items[five].Controls[1].Location = new Point(42, 10);
                layeredListBox1.Items[five].Controls[2].Size = new Size(22, 22);
            }
            layeredListBox1.RefreshList();
            ((DuiBaseControl)sender).Controls[1].ForeColor = Color.White;
            ((DuiBaseControl)sender).Controls[3].Visible = true;
            ((DuiBaseControl)sender).BackColor = Color.DodgerBlue;
            for (int i = 0; i < layeredListBox1.Items.Count; i++)
            {
                if (i != one && i != two && i != tree && i != four && i != five)
                {
                    layeredListBox1.Items[i].Height = 32;
                    layeredListBox1.Items[i].Controls[0].Visible = false;
                    layeredListBox1.Items[i].Controls[1].Location = new Point(30, 8);
                    layeredListBox1.Items[i].Controls[2].Size = new Size(22, 22);
                    layeredListBox1.RefreshList();
                }
            }
            layeredListBox1.RefreshList();
        }

        /// <summary>
        /// 账户项容器鼠标项离开事件：当前项取消显示昵称关闭按钮、背景色等外观改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsMouseLeave(object sender, EventArgs e)
        {
            if (this.Bounds.Contains(Cursor.Position))
            {
                ((DuiBaseControl)sender).Controls[1].ForeColor = Color.Black;
                ((DuiBaseControl)sender).BackColor = Color.Transparent;
                ((DuiBaseControl)sender).Controls[3].Visible = false;
                layeredListBox1.RefreshList();
            }
            else
            {
                this.Close();
            }
        }

        #endregion

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
        /// 鼠标抬起事件：改变按钮图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemsCloseMouseUp(object sender, EventArgs e)
        {
            ((DuiBaseControl)sender).BackgroundImage = Resources.page_close_btn_hover;
        }

        #endregion

        private void skinLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #endregion

    }
}