using System;
using System.Collections.Generic;
using System.Text;
using ZXing;
using ZXing.QrCode;
using ZXing.Rendering;

namespace YuanTu.Platform.Print
{
    public partial class BarcodeUtil
    {
        public static PixelData Create(string content, int width = 160, int height = 160, BarcodeFormat format = BarcodeFormat.QR_CODE, string characterSet = "UTF-8")
        {
            BarcodeWriterPixelData writer = new BarcodeWriterPixelData();
            writer.Format = format;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.DisableECI = true;
            //设置内容编码
            options.CharacterSet = "UTF-8";
            //设置二维码的宽度和高度
            options.Width = width;
            options.Height = height;
            //设置二维码的边距,单位不是固定像素
            options.Margin = 1;
            if (format == BarcodeFormat.QR_CODE)
            {
                options.PureBarcode = true;
            } 
            else
            {
                options.PureBarcode = false;
            }

            writer.Options = options;

            return writer.Write(content);
        }
    }
}
