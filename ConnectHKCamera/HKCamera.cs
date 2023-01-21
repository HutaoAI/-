using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectHKCamera
{
    public class HKCamera
    {
        readonly Dictionary<string,Hikvision> keyValuePairs= new Dictionary<string,Hikvision>();
        
        public HKCamera(params string[] CamName)
        {
            foreach (var item in CamName)
            {
                keyValuePairs.Add(item,new Hikvision());
            }
        }

        readonly Hikvision hikvision = new Hikvision();
        public bool Camera_OK => hikvision.bl_CamOpen;
        public bool ConnectCamera(string ID)
        {
            hikvision.connectCamera(ID);
            if (hikvision.bl_CamOpen)
            {
                hikvision.setTriggerMode(1);
                hikvision.setTriggerSource(7);
                hikvision.startCamera();//开启相机采集
            }
            return Camera_OK;
        }

        public void DisConnect()
        {
            if (Camera_OK)
                hikvision.closeCamera();
        }
        /// <summary>
        /// 获取图像
        /// </summary>
        /// <returns></returns>
        public async Task<Bitmap> GetImageAsync(int exposure)
        {
#pragma warning disable CA1416 // 验证平台兼容性
            Bitmap imgBytes = await Task.Run(async () =>
            {
                hikvision.setExposureTime((uint)exposure);//设置曝光
                hikvision.softTrigger();//发送软触发采集图像
                await Task.Delay(100);
                return hikvision.ReadImage();
            });
#pragma warning restore CA1416 // 验证平台兼容性
            return imgBytes;
        }

        public Bitmap GetImage(int exposure)
        {
            hikvision.setExposureTime((uint)exposure);//设置曝光
            hikvision.softTrigger();//发送软触发采集图像
            Thread.Sleep(100);  
            return hikvision.ReadImage();
        }
    }
}
