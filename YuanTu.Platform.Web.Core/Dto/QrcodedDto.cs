using System;
using System.Collections.Generic;
using System.Text;
using ZXing;

namespace YuanTu.Platform.Dto
{
    public class QrcodedDto
    {
        public BarcodeFormat Format { get; set; } = BarcodeFormat.QR_CODE;

        public int Width { get; set; } = 320;

        public int Height { get; set; } = 320;

        public string Text { get; set; }

        public bool PureBarcode { get; set; } = true;
    }
}
