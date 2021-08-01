using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using CCWin;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeLink.UI
{
    public partial class SmilPanel : Skin_DevExpress
    {
        MainForm mainForm = null;
        public SmilPanel(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void SmilPanel_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        #region 1-8

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\am";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\baiy";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\bs";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\bz";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\ch";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\cy";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\dk";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\doge";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        #endregion

        #region 9-16

        private void button9_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\dy";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\fd";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\fendou";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\fn";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\gg";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\gz";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\hanx";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\hq";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        #endregion

        #region 17-24

        private void button17_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\huaix";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\hx";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\jie";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\jk";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\jy";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\ka";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\kb";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\kel";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        #endregion

        #region 18-32

        private void button25_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\kk";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\kl";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\kuk";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\kun";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\lengh";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\lh";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\ll";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\ng";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        #endregion

        #region 33-40

        private void button33_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\px";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\pz";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\qd";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\qiao";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\qq";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button36_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\shuai";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\shui";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\sr";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        #endregion

        #region 41-48

        private void button41_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\tp";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\ts";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\tuu";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button47_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\tx";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button43_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\wn";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\wq";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\wx";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        private void button48_Click(object sender, EventArgs e)
        {
            mainForm.textMessage.Text = "\\wzm";
            mainForm.btnSendMessage_Click(sender, e);
            this.Hide();
        }

        #endregion

    }
}
