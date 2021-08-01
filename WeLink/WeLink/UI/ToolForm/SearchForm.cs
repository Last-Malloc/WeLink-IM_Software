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
using WeLink.Properties;

namespace WeLink.UI
{
    public partial class SearchForm : LayeredBaseForm
    {
        MainForm mainForm = null;
        public SearchForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.TopMost = true;
        }
        
        /// <summary>
        /// 模糊查询：显示匹配的好友和群
        /// </summary>
        public void setItem(string key)
        {
            listBoxSearch.Items.Clear();

            //好友标签
            DuiLabel labelFriend = DuiBaseControlClass.AddDuiLabel("好友",
                mainForm.itemFont, new Size(210, 20), new Point(20, 0));
            DuiBaseControl itemFriend = new DuiBaseControl();
            itemFriend.BackColor = mainForm.itemBackNormal;
            itemFriend.Width = this.Width;
            itemFriend.Height = 20;
            itemFriend.Borders.TopColor = mainForm.itemBackLine;
            itemFriend.Controls.Add(labelFriend);
            listBoxSearch.Items.Add(itemFriend);

            foreach (string item in mainForm.linkNameFriend.Keys)
            {
                if (item.Contains(key) || key.Contains(item))
                {
                    string cardID = mainForm.linkNameFriend[item];
                    listBoxSearch.Items.Add(mainForm.linkFriendItem[cardID]);
                }
            }

            //群标签
            DuiLabel labelGroup = DuiBaseControlClass.AddDuiLabel("群",
                mainForm.itemFont, new Size(210, 20), new Point(20, 0));
            DuiBaseControl itemGroup = new DuiBaseControl();
            itemGroup.BackColor = mainForm.itemBackNormal;
            itemGroup.Width = this.Width;
            itemGroup.Height = 20;
            itemGroup.Borders.TopColor = mainForm.itemBackLine;
            itemGroup.Controls.Add(labelGroup);
            listBoxSearch.Items.Add(itemGroup);

            foreach (string item in mainForm.linkNameGroup.Keys)
            {
                if (item.Contains(key) || key.Contains(item))
                {
                    string cardID = mainForm.linkNameGroup[item];
                    listBoxSearch.Items.Add(mainForm.linkGroupItem[cardID]);
                }
            }

            listBoxSearch.RefreshList();
        }
        
        public void clear()
        {
            listBoxSearch.Items.Clear();
            listBoxSearch.RefreshList();
        }

    }
}
