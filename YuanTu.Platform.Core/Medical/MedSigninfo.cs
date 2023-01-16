using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Medical
{
    public class MedSigninfo : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        [StringLength(64)]
        public string HospId { get; set; }
        /// <summary>
        /// 医保类型
        /// </summary>
        [StringLength(8)]
        public string MedicareType { get; set; }
        /// <summary>
        /// 操作员号
        /// </summary>
        [StringLength(64)]
        public string OperCode { get; set; }
        /// <summary>
        /// 业务周期号
        /// </summary>
        [StringLength(64)]
        public string BusinessCode { get; set; }
        /// <summary>
        /// 签到时间
        /// </summary>
        public DateTime SignInTime { get; set; }
        /// <summary>
        /// 签退时间
        /// </summary>
        public DateTime SignOutTime { get; set; }
        /// <summary>
        /// 签到签退状态
        /// </summary>
        public int SignStatus { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        [StringLength(512)]
        public string Memo { get; set; }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string Extend { get; set; }
    }
}
