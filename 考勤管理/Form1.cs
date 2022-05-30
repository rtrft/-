using AForge.Video.DirectShow;
using Baidu.Aip.Face;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Model;
using Common;
using Bll;
#pragma warning disable 0436
namespace 考勤管理
{
    public partial class Form1 : Form
    {
        private string APP_ID = "23092650";
        private string API_KEY = "hBBlbG3msWxHyc62GFlrnOqG";
        private string SECRET_KEY = "C2rUmUSkOzScm1Pwg0NTPnHdWy323WCB";
        private Face client = null;
        /// <summary>
        /// 是否可以检测人脸
        /// </summary>
        private bool IsStart = false;
        /// <summary>
        /// 人脸在图像中的位置
        /// </summary>
        private FaceLocation location = null;

        private FilterInfoCollection videoDevices = null;
        private VideoCaptureDevice videoSource;
        string userid="2201";
        Sunisoft.IrisSkin.SkinEngine skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
        public Form1(string id)
        {
            InitializeComponent();
            client = new Face(API_KEY, SECRET_KEY);
            userid = id;
            Form1_Load();
            
        }







        private void Form1_Load()
        {
            skinEngine1.SkinFile = Application.StartupPath + @"/Skins/Calmness.ssk";
            /// 获取电脑已经安装的视频设备
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            MessageBox.Show("检测到了" + videoDevices.Count.ToString() + "个摄像头！");
            if (videoDevices != null && videoDevices.Count > 0)
            {
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
            }
            videoSourcePlayer1.NewFrame += VideoSourcePlayer1_NewFrame;

            // 开发者在百度AI平台人脸识别接口只能1秒中调用2次，所以需要做 定时开始检测，每个一秒检测2次
            ThreadPool.QueueUserWorkItem(new WaitCallback(p => {
                while (true)
                {
                    IsStart = true;
                    Thread.Sleep(500);
                }
            }));
        }
        /// <summary>
        /// 新场景的事件获取单帧图像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="image"></param>
        private void VideoSourcePlayer1_NewFrame(object sender, ref Bitmap image)
        {
           
                if (IsStart)
                {
                    IsStart = false;
                    // 在线程池中另起一个线程进行人脸检测,这样不会造成界面视频卡顿现象
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.Detect), image.Clone());
                }
                if (location != null)
                {

                        // 绘制方框套住人脸
                        Graphics g = Graphics.FromImage(image);
                        g.DrawLine(new Pen(Color.Black), new System.Drawing.Point(location.left, location.top), new System.Drawing.Point(location.left + location.width, location.top));
                        g.DrawLine(new Pen(Color.Black), new System.Drawing.Point(location.left, location.top), new System.Drawing.Point(location.left, location.top + location.height));
                        g.DrawLine(new Pen(Color.Black), new System.Drawing.Point(location.left, location.top + location.height), new System.Drawing.Point(location.left + location.width, location.top + location.height));
                        g.DrawLine(new Pen(Color.Black), new System.Drawing.Point(location.left + location.width, location.top), new System.Drawing.Point(location.left + location.width, location.top + location.height));
                        g.Dispose();

                  
                }
            
           

        }

        /// <summary>
        /// 连接并且打开摄像头
        /// </summary>
        private void CameraConn()
        {
            if (comboBox1.Items.Count <= 0)
            {
                MessageBox.Show("请插入视频设备");
                return;
            }
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.DesiredFrameSize = new System.Drawing.Size(320, 240);
            videoSource.DesiredFrameRate = 1;

            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }
        /// <summary>
        /// 重新检测连接视频设备
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            /// 获取电脑已经安装的视频设备
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices != null && videoDevices.Count > 0)
            {
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
            }
        }
        /// <summary>
        /// 拍照
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count <= 0)
            {
                MessageBox.Show("请插入视频设备");
                return;
            }
            try
            {
                if (videoSourcePlayer1.IsRunning)
                {
                    BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                    videoSourcePlayer1.GetCurrentVideoFrame().GetHbitmap(),
                                    IntPtr.Zero,
                                     Int32Rect.Empty,
                                    BitmapSizeOptions.FromEmptyOptions());
                    PngBitmapEncoder pE = new PngBitmapEncoder();
                    pE.Frames.Add(BitmapFrame.Create(bitmapSource));
                    string picName = GetImagePath() + "\\" + DateTime.Now.ToFileTime() + ".jpg";
                    if (File.Exists(picName))
                    {
                        File.Delete(picName);
                    }
                    using (Stream stream = File.Create(picName))
                    {
                        pE.Save(stream);
                    }
                    //拍照完成后关摄像头并刷新同时关窗体
                    if (videoSourcePlayer1 != null && videoSourcePlayer1.IsRunning)
                    {
                        videoSourcePlayer1.SignalToStop();
                        videoSourcePlayer1.WaitForStop();
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("摄像头异常：" + ex.Message);
            }
        }


        private string GetImagePath()
        {
            string personImgPath = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)
                         + Path.DirectorySeparatorChar.ToString() + "PersonImg";
            if (!Directory.Exists(personImgPath))
            {
                Directory.CreateDirectory(personImgPath);
            }

            return personImgPath;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CameraConn();
        }

        /// <summary>
        /// Bitmap 转byte[]
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public byte[] Bitmap2Byte(Bitmap bitmap)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, ImageFormat.Jpeg);
                    byte[] data = new byte[stream.Length];
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.Read(data, 0, Convert.ToInt32(stream.Length));
                    return data;
                }
            }
            catch (Exception ex) { }
            return null;
        }
        public byte[] BitmapSource2Byte(BitmapSource source)
        {
          
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.QualityLevel = 100;
                using (MemoryStream stream = new MemoryStream())
                {
                    encoder.Frames.Add(BitmapFrame.Create(source));
                    encoder.Save(stream);
                    byte[] bit = stream.ToArray();
                    stream.Close();
                    return bit;
                }
        
        }

        /// <summary>
        /// 人脸检测
        /// </summary>
        public void Detect(object image)
        {
            if (image != null && image is Bitmap)
            {
                
                    var img = (Bitmap)image;
                    var imgByte = Bitmap2Byte(img);
                    var imageType = "BASE64";
                    MemoryStream ms = new MemoryStream();
                    ms.Position = 0;
                    ms.Read(imgByte, 0, (int)ms.Length);
                    ms.Close();
                    string sim = Convert.ToBase64String(imgByte);
                    if (imgByte != null)
                    {
                        // 如果有可选参数
                        var options = new Dictionary<string, object>{
                            {"max_face_num", 2},
                            {"face_fields", "age,qualities,beauty"}
                        };

                        var result = client.Detect(sim, imageType, options);

                        FaceDetectInfo detect = JsonHelper.DeserializeObject<FaceDetectInfo>(result.ToString());
                        if (detect != null && detect.result_num > 0)
                        {
                            this.location = detect.result[0].location;
                            StringBuilder sb = new StringBuilder();
                            if (detect.result[0].qualities != null)
                            {
                                if (detect.result[0].qualities.blur >= 0.7)
                                {
                                    sb.AppendLine("人脸过于模糊");
                                }
                                if (detect.result[0].qualities.completeness >= 0.4)
                                {
                                    sb.AppendLine("人脸不完整");
                                }
                                if (detect.result[0].qualities.illumination <= 40)
                                {
                                    sb.AppendLine("灯光光线质量不好");
                                }
                                if (detect.result[0].qualities.occlusion != null)
                                {
                                    if (detect.result[0].qualities.occlusion.left_cheek >= 0.8)
                                    {
                                        sb.AppendLine("左脸颊不清晰");
                                    }
                                    if (detect.result[0].qualities.occlusion.left_eye >= 0.6)
                                    {
                                        sb.AppendLine("左眼不清晰");
                                    }
                                    if (detect.result[0].qualities.occlusion.mouth >= 0.7)
                                    {
                                        sb.AppendLine("嘴巴不清晰");
                                    }
                                    if (detect.result[0].qualities.occlusion.nose >= 0.7)
                                    {
                                        sb.AppendLine("鼻子不清晰");
                                    }
                                    if (detect.result[0].qualities.occlusion.right_cheek >= 0.8)
                                    {
                                        sb.AppendLine("右脸颊不清晰");
                                    }
                                    if (detect.result[0].qualities.occlusion.right_eye >= 0.6)
                                    {
                                        sb.AppendLine("右眼不清晰");
                                    }
                                    if (detect.result[0].qualities.occlusion.chin >= 0.6)
                                    {
                                        sb.AppendLine("下巴不清晰");
                                    }
                                    if (detect.result[0].pitch >= 20)
                                    {
                                        sb.AppendLine("俯视角度太大");
                                    }
                                    if (detect.result[0].roll >= 20)
                                    {
                                        sb.AppendLine("脸部应该放正");
                                    }
                                    if (detect.result[0].yaw >= 20)
                                    {
                                        sb.AppendLine("脸部应该放正点");
                                    }
                                }

                            }
                            if (detect.result[0].location.height <= 100 || detect.result[0].location.height <= 100)
                            {
                                sb.AppendLine("人脸部分过小");
                            }
                        }
                    }
                
              
            }

        }
        kaoqinDocument staff = new kaoqinDocument();
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 人脸注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            // 用户ID
            string uid = textBox5.Text.Trim();
            // 用户资料，长度限制256B
            string userInfo = textBox6.Text.Trim();
            var imageType = "BASE64";
            // 用户组ID
            string groupId = "1";

            if (comboBox1.Items.Count <= 0)
            {
                MessageBox.Show("请插入视频设备");
                return;
            }
            try
            {
                if (videoSourcePlayer1.IsRunning)
                {
                    BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                    videoSourcePlayer1.GetCurrentVideoFrame().GetHbitmap(),
                                    IntPtr.Zero,
                                     Int32Rect.Empty,
                                    BitmapSizeOptions.FromEmptyOptions());
                    var img = BitmapSource2Byte(bitmapSource);
                    MemoryStream ms = new MemoryStream();
                    ms.Position = 0;
                    ms.Read(img, 0, (int)ms.Length);
                    ms.Close();
                    string sim = Convert.ToBase64String(img);
                    var options = new Dictionary<string, object>{
                        {"user_info", userInfo},
                        {"quality_control", "NORMAL"},
                        {"liveness_control", "LOW"},
                        {"action_type", "REPLACE"}
                    };
                    var result = client.UserAdd(sim, imageType, groupId, uid, options);

                    if (result.ToString().Contains("error_code"))
                    {
                        MessageBox.Show("注册失败:" + result.ToString());
                    }
                    else
                    {
                        MessageBox.Show("注册成功");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("摄像头异常：" + ex.Message);
            }
        }
        /// <summary>
        /// 人脸登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            // 用户ID
            // 用户资料，长度限制256B
            string userInfo = textBox6.Text.Trim();
            // 用户组ID

            var imageType = "BASE64";
            var groupIdList = "1,2";
            if (comboBox1.Items.Count <= 0)
            {
                MessageBox.Show("请插入视频设备");
                return;
            }

            if (videoSourcePlayer1.IsRunning)
            {
                BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                videoSourcePlayer1.GetCurrentVideoFrame().GetHbitmap(),
                                IntPtr.Zero,
                                 Int32Rect.Empty,
                                BitmapSizeOptions.FromEmptyOptions());
                var img = BitmapSource2Byte(bitmapSource);
                MemoryStream ms = new MemoryStream();
                ms.Position = 0;
                ms.Read(img, 0, (int)ms.Length);
                ms.Close();
                string sim = Convert.ToBase64String(img);
                // 如果有可选参数
                //var options = new Dictionary<string, object>{
                //    {"ext_fields", "faceliveness"},
                //    {"user_top_num", 3}
                //};
                var options = new Dictionary<string, object>{
                        {"match_threshold", 80},
                        {"quality_control", "LOW"},
                        {"liveness_control", "LOW"},
                        {"user_id",userid},
                        {"max_user_num", 3}
                    };
                var result = client.Search(sim, imageType, groupIdList, options);
                DateTime time = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                DateTime time2 = Convert.ToDateTime(DateTime.Now.ToString("hh:MM"));
                string st0 = "00:00";
                string st1 = "08:30";
                string st2 = "09:00";
                string st3 = "17:00";
                DateTime dt0 = Convert.ToDateTime(st0);
                DateTime dt1 = Convert.ToDateTime(st1);
                DateTime dt2 = Convert.ToDateTime(st2);
                DateTime dt3 = Convert.ToDateTime(st3);
                string username = result["result"]["user_list"][0]["user_info"].ToString();
                if (username != null)
                {

                    if (DateTime.Compare(dt0, time) <0 && DateTime.Compare(dt1, time2) >0)
                    {
                        MessageBox.Show("未到打卡时间");
                    }
                    else if (DateTime.Compare(dt1, time2) <0&& DateTime.Compare(dt2, time2)>0)
                    {
                        staff.Add(userid, username, "正常", time);
                        MessageBox.Show("打卡成功:正常" + username);
                    }
                    else if(DateTime.Compare(dt2, time2) <0 && DateTime.Compare(dt3, time2) > 0)
                    {
                        staff.Add(userid, username, "迟到", time);
                        MessageBox.Show("打卡成功:迟到" + username);
                    }
                    else
                    {
                        staff.Add(userid, username, "缺勤", time);
                        MessageBox.Show("打卡成功:缺勤" + username);
                    }

                }
                else
                {
                    MessageBox.Show("打卡失败:" + result.ToString());
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }




    }
}