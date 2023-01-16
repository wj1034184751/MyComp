using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Medical.Base;

namespace YuanTu.Platform.Medical.MedTransDatas.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(MedTransData))]
    public class MedTransDataDto : TransDataDto
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
