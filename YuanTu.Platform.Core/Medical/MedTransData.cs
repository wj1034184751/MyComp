using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Medical
{
    public class MedTransData : TransData
    {
        /// <summary>
        /// 医保原始入参
        /// </summary>
        public string InputStr { get; set; }
        /// <summary>
        /// 医保原始出参
        /// </summary>
        public string OutputStr { get; set; }
    }
}
