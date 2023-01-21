# -
提供.NET与.NET Framework版本的连接工业相机

# 1.提供连接工业相机的.net版本函数(只支持海康相机)

## 1.1 如何使用该库函数
### Nuget包上下载ConnectCamera的包


	ICamera camera = new HKCamera("Left","Right"); //构造函数里面传入要连接的相机Name
	camera.ConnectCamera("Left");   //这个是连接单个相机 
	camera.ConnectCameras();   //这个是连接构造函数里面添加的所有相机
    bool b = camera.IsConnected("Left");  //返回指定相机是否连接
    camera.GetImage("Left",60000);   //同步获取图片,第一个参数是相机名称,第二个参数是相机获取图像的曝光值  返回Bitmap类型图片
    await camera.GetImageAsync("Left", 60000);   //异步获取图片 可等待 返回Bitmap类型图片
    camera.DisConnect("Left");   //断开指定的相机连接
    camera.DisConnectAll();   //断开所有已经连接的相机
## 1.2 目前只支持海康相机,后续项目上用到的相机都会添加进来
