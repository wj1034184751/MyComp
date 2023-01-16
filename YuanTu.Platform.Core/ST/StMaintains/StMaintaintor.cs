using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.StMaintains
{
    /// <summary>
    /// 维护人员信息
    /// </summary>
    public class StMaintaintor : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string Name { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string IdNo { get; set; }

        /// <summary>
        /// 射频卡号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public string CardNo { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string Phone { get; set; }

        /// <summary>
        /// 口令
        /// </summary>\
        [StringLength(PlatformConsts.MaxLength32)]
        public string Password { get; set; }

        /// <summary>
        /// 就诊号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
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