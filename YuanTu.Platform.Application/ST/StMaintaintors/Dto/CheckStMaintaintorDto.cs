using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.ST
{
    public class CheckStMaintaintorDto
    {
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdNo { get; set; }

        /// <summary>
        /// 射频卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 口令
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 小程序二维码
        /// </summary>
        public string Qrcode { get; set; }

        /// <summary>
        /// 就诊号
        /// </summary>
        public string PatientId { get; set; }
    }
}
