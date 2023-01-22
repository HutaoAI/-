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

            ICamera camera = new HKCamera("Left","Right"); //���캯�����洫��Ҫ���ӵ����Name
            camera.ConnectCamera("Left");   //��������ӵ������ 
            camera.ConnectCameras();   //��������ӹ��캯��������ӵ��������

            bool b = camera.IsConnected("Left");  //����ָ������Ƿ�����

            camera.GetImage("Left",60000);   //ͬ����ȡͼƬ,��һ���������������,�ڶ��������������ȡͼ����ع�ֵ  ����Bitmap����ͼƬ
            await camera.GetImageAsync("Left", 60000);   //�첽��ȡͼƬ �ɵȴ� ����Bitmap����ͼƬ

            camera.DisConnect("Left");   //�Ͽ�ָ�����������
            camera.DisConnectAll();   //�Ͽ������Ѿ����ӵ����

           
        }
    }
}