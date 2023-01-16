using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.StMaintains;

namespace YuanTu.Platform.ST
{
    [Abp.AutoMapper.AutoMap(typeof(StMaintaintor))]
    public class StMaintaintorDto : CustomEntityDto<string>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdNo { get; set; }

        /// <summary>
        /// 射频卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 口令
        /// </summary>\
        public string Password { get; set; }
        
        /// <summary>
        /// 就诊号
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 是否启动
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 最后一次登陆时间
        /// </summary>
        public DateTime LastLoginTime { get; set; }
    }
}
