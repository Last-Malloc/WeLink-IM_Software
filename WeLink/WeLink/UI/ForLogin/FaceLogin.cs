using AForge.Video.DirectShow;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WeLink.UI
{
    public partial class FaceLogin : LayeredBaseForm
    {
        public string id = "";//用户id，识别失败时id为空字符串

        //调用百度云人脸识别库
        //Api_Key
        public static string Api_Key = "EdvpXzn4CQ20ofQjQ4cZsZXX";
        //Secret_Key
        public static string Secret_Key = "WBm7hyfPrIYmGA0UdHsmmXxlA4KZjlBY";

        public FaceLogin()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;

        int cnt = 10;
        //窗体加载
        private void facelogin_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;//每1秒执行1次
            timer1.Start();
            cnt = 10;

            // 刷新可用相机的列表
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //打开摄像头
            openCamera();
        }

        //打开摄像头
        private void openCamera( )
        {
            //连接摄像头。
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.VideoResolution = videoSource.VideoCapabilities[0];

            // 枚举所有摄像头支持的像素，设置拍照为1920*1080
            foreach (VideoCapabilities capab in videoSource.VideoCapabilities)
            {
                if (capab.FrameSize.Width == 1920 && capab.FrameSize.Height == 1080)
                {
                    videoSource.VideoResolution = capab;
                    break;
                }
            }
            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }

        // 人脸识别登录
        public void FaceVerify()
        {
            try
            {
                if (videoSource == null)
                {
                    return;
                }
                //截屏，将图片保存为base64字符串格式
                var image = "";
                Bitmap bmp1 = videoSourcePlayer1.GetCurrentVideoFrame();
                using (MemoryStream ms1 = new MemoryStream())
                {
                    bmp1.Save(ms1, ImageFormat.Jpeg);
                    byte[] arr1 = new byte[ms1.Length];
                    ms1.Position = 0;
                    ms1.Read(arr1, 0, (int)ms1.Length);
                    ms1.Close();
                    image = Convert.ToBase64String(arr1);
                }
                bmp1.Dispose();
                var imageType = "BASE64";
                var client = new Baidu.Aip.Face.Face(Api_Key, Secret_Key);
                try
                {
                    var result = client.Search(image, imageType, "GROUP1");

                    //先判断脸是不是在上面，在继续看有匹配的没
                    JObject jo_result = (JObject)JsonConvert.DeserializeObject(result.ToString());
                    switch ((string)jo_result["error_msg"])
                    {
                        //case "pic not has face":  MyMessageBox.Show("对不起，请把脸放上！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop); break;
                        //case "match user is not found":  MyMessageBox.Show("验证失败，用户不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop); break;
                        case "SUCCESS":
                            {
                                //在结果字符串中筛选出user_id和匹配得分
                                string t = result.ToString();
                                int s = t.IndexOf("\"user_id\": \"");
                                int e = t.IndexOf("\",", s + 12);
                                string user_id = t.Substring(s + 12, e - s - 12);
                                int len = t.Length;
                                s = t.IndexOf("\"score\": ");
                                double score = Double.Parse(t.Substring(s + 9, 5));
                                if (score >= 80)
                                {
                                    timer1.Stop();
                                     MyMessageBox.Show("人脸验证成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    id = user_id;
                                }
                                //else
                                //{
                                //     MyMessageBox.Show("验证失败，用户不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //}
                            }; break;
                    }
                    if (id.Length == 10)
                    {
                        this.Close();
                    }
                }
                catch (Exception)
                {
                     MyMessageBox.Show("请检查网络连接！！！", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        private void FaceLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止摄像头
            videoSourcePlayer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = cnt + "s";
            if (cnt % 2 == 0)
            {
                //异步执行委托中的内容
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    FaceVerify();
                });
            }
            if (cnt != 0)
            {
                --cnt;
            }
            else
            {
                timer1.Stop();
                DialogResult dialogResult =  MyMessageBox.Show("验证失败，是否重试？", "验证失败", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Cancel)
                {
                    //关闭窗口并退出
                    this.Close();
                }
                else
                {
                    cnt = 10;
                    timer1.Start();
                }
            }
        }
    }
}
