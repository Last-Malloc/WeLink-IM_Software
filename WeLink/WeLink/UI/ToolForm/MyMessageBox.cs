using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayeredSkin.Controls;
using LayeredSkin.DirectUI;

namespace WeLink.UI
{
    public partial class MyMessageBox : LayeredBaseForm
    {
        public MyMessageBox()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.Controls.Add(pictureBox1);
            this.Controls.Add(labelCaption);
            this.Controls.Add(BtnClose);
            this.Controls.Add(pictureBox2);
            this.Controls.Add(labelText);
            pictureBox1.BackColor = Color.Transparent;
            labelCaption.BackColor = Color.Transparent;
            BtnClose.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            labelText.BackColor = Color.Transparent;
            pictureBox1.MouseDown += labelText_MouseDown;
            labelCaption.MouseDown += labelText_MouseDown;
            pictureBox2.MouseDown += labelText_MouseDown;
            this.TopMost = true;
        }

        MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;
        DialogResult dialogResult = DialogResult.Cancel;
        /// <summary>
        /// 以模态对话框方式运行
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, 
            MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MyMessageBox MyMessageBox = new MyMessageBox();
            MyMessageBox.labelText.Text = text;//正文
            MyMessageBox.labelCaption.Text = caption;//标题

            //可指定为error，否则为information
            if (icon == MessageBoxIcon.Error)
            {
                MyMessageBox.pictureBox1.BackgroundImage
                    = MyMessageBox.pictureBox2.BackgroundImage
                        = Properties.Resources.错误_Box;
            }
            else
            {
                MyMessageBox.pictureBox1.BackgroundImage
                    = MyMessageBox.pictureBox2.BackgroundImage
                        = Properties.Resources.提示_Box;
            }

            //可指定为YESNOCANCEL、OKCANCEL、否则为OK
            //YESNOCANCEL不作更改
            if (buttons == MessageBoxButtons.YesNoCancel)
            {

            }
            else if (buttons == MessageBoxButtons.OKCancel)
            {
                MyMessageBox.btnYes.Hide();
                MyMessageBox.btnNo.Text = "确定";
            }
            else
            {
                buttons = MessageBoxButtons.OK;
                MyMessageBox.btnYes.Hide();
                MyMessageBox.btnNo.Text = "确定";
                MyMessageBox.btnCancel.Hide();
            }
            MyMessageBox.messageBoxButtons = buttons;

            MyMessageBox.ShowDialog();

            return MyMessageBox.dialogResult;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            if (messageBoxButtons == MessageBoxButtons.YesNoCancel)
            {
                dialogResult = DialogResult.No;
            }
            else
            {
                dialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void labelText_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
    }
}
