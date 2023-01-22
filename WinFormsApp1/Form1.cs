using ConnectCamera;
using ConnectCamera.HKCamera;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            ICamera camera = new HKCamera("Left","Right"); //构造函数里面传入要连接的相机Name
            camera.ConnectCamera("Left");   //这个是连接单个相机 
            camera.ConnectCameras();   //这个是连接构造函数里面添加的所有相机

            bool b = camera.IsConnected("Left");  //返回指定相机是否连接

            camera.GetImage("Left",60000);   //同步获取图片,第一个参数是相机名称,第二个参数是相机获取图像的曝光值  返回Bitmap类型图片
            await camera.GetImageAsync("Left", 60000);   //异步获取图片 可等待 返回Bitmap类型图片

            camera.DisConnect("Left");   //断开指定的相机连接
            camera.DisConnectAll();   //断开所有已经连接的相机

           
        }
    }
}