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
using WeLink.DAL;

namespace WeLink.UI
{
    public partial class FaceRegister : LayeredBaseForm
    {
        /// <summary>
        /// 成功返回id，失败返回空串
        /// </summary>
        public string cardID = "";
        string tempId = "";//用户id

        //调用百度云人脸识别库
        //Api_Key
        public static string Api_Key = "EdvpXzn4CQ20ofQjQ4cZsZXX";
        //Secret_Key
        public static string Secret_Key = "WBm7hyfPrIYmGA0UdHsmmXxlA4KZjlBY";

        public FaceRegister(string key)
        {
            InitializeComponent();
            tempId = key;
            this.TopMost = true;
        }

        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;

        //窗体加载
        private void facelogin_Load(object sender, EventArgs e)
        {
            // 刷新可用相机的列表
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            //打开摄像头
            openCamera();
        }

        //打开摄像头
        private void openCamera()
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

        //关闭摄像头并退出
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 点击确定进行人脸注册
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (FacePhotoRegister())
                this.Close();
        }

        //人脸注册
        public bool FacePhotoRegister()
        {
            cardID = "";
            var client = new Baidu.Aip.Face.Face(Api_Key, Secret_Key);

            //截屏，将图片保存为base64字符串格式
            var image = "";
            //截取摄像头的当前图片
            Bitmap bmp1 = videoSourcePlayer1.GetCurrentVideoFrame();

            //验证是否注册过
            if (FaceVerify(bmp1))
            {
                MyMessageBox.Show("您已经与其他账号进行绑定，请解除绑定后重试！", "人脸注册", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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
            var groupId = "GROUP1";
            var userId = tempId;

            string result = "";
            try
            {
                var tResult  = client.UserAdd(image, imageType, groupId, userId);
                result = tResult.ToString();
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                 MyMessageBox.Show("请检查网络连接！！！", "网络错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //验证是否成功识别人脸
            JObject jo_result = (JObject)JsonConvert.DeserializeObject(result);
            if ((string)jo_result["error_msg"] != "SUCCESS")
            {
                 MyMessageBox.Show("对不起，请把脸放上！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            MyMessageBox.Show("人脸扫描成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cardID = tempId;

            //获取faceToken
            int index1 = result.IndexOf("\"face_token\": \"") + ("\"face_token\": \"").Length;
            int index2 = result.IndexOf("\",", index1);
            string str = result.Substring(index1, index2 - index1);
            ConfigXml.addConfigXML(cardID + "facetoken", str);
            return true;
        }

        // 人脸识别登录
        public bool FaceVerify(Bitmap bmp1)
        {
            bool flag = false;
            try
            {
                //截屏，将图片保存为base64字符串格式
                var image = "";
                using (MemoryStream ms1 = new MemoryStream())
                {
                    bmp1.Save(ms1, ImageFormat.Jpeg);
                    byte[] arr1 = new byte[ms1.Length];
                    ms1.Position = 0;
                    ms1.Read(arr1, 0, (int)ms1.Length);
                    ms1.Close();
                    image = Convert.ToBase64String(arr1);
                }
                var imageType = "BASE64";
                var client = new Baidu.Aip.Face.Face(Api_Key, Secret_Key);

                var result = client.Search(image, imageType, "GROUP1");

                //先判断脸是不是在上面，在继续看有匹配的没
                JObject jo_result = (JObject)JsonConvert.DeserializeObject(result.ToString());
                switch ((string)jo_result["error_msg"])
                {
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
                                flag = true;
                            }
                        }; break;
                }
            }
            catch (Exception)
            {
            }
            return flag;
        }

        //人脸删除
        public static bool FacePhotoDelete(string cardID)
        {
            try
            {
                var groupId = "GROUP1";

                var userId = cardID;

                var client = new Baidu.Aip.Face.Face(Api_Key, Secret_Key);

                // 调用删除用户，可能会抛出网络等异常，请使用try/catch捕获
                string facetoken = ConfigXml.selectConfigXML(cardID + "facetoken");
                if (facetoken != "")
                {
                    client.FaceDelete(userId, groupId, facetoken);
                    client.UserDelete(groupId, userId);
                    ConfigXml.removeConfigXML(cardID + "facetoken");
                    return true;
                }
            }
            catch (Exception)
            {
            }
            return false;
        }

        private void FaceLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止摄像头
            videoSourcePlayer1.Stop();
        }
    }
}
