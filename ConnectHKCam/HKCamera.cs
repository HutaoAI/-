using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectHKCam
{
    public class HKCamera
    {
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
            Bitmap imgBytes = await Task.Run(async() =>
            {
                hikvision.setExposureTime((uint)exposure);//设置曝光
                hikvision.softTrigger();//发送软触发采集图像
                await Task.Delay(100);
                return hikvision.ReadImage();
            });
            return imgBytes;
        }
    }
}
