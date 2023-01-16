using System;
using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Health
{
    /// <summary>
    /// 预检用户数据表
    /// </summary>
    public class HealthUserData : CustomCreationEntityWithOrg<string>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public virtual int Age { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public virtual byte Sex { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string IdNo { get; set; }
        /// <summary>
        /// 开始检测时间
        /// </summary>
        public virtual DateTime StartTime { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public virtual  bool IsComplete { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string Height { get; set; }
        /// <summary>
        /// 体重
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string Weight { get; set; }
        /// <summary>
        /// 体脂（预留）
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string Fat { get; set; }
        /// <summary>
        /// 血氧
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string SaO2 { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string Temperature { get; set; }
        /// <summary>
        /// 血压
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)] 
        public virtual string BloodPressure { get; set; }
        /// <summary>
        /// 脉搏
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string Pulse { get; set; }
        /// <summary>
        /// 心电
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string Ecg { get; set; } 

        /// <summary>
        /// 测量身高体重耗时
        /// </summary>
        public virtual int HtTime { get; set; }
        /// <summary>
        /// 测量血氧耗时
        /// </summary>
        public virtual int SaO2Time { get; set; }
        /// <summary>
        /// 测量体温耗时
        /// </summary>
        public virtual int TempTime { get; set; }
        /// <summary>
        /// 测量血压耗时
        /// </summary>
        public virtual int BpTime { get; set; }
        /// <summary>
        /// 测量体脂耗时
        /// </summary>
        public virtual int FatTime { get; set; }
        /// <summary>
        /// 测量心电耗时
        /// </summary>
        public virtual int EcgTime { get; set; }
    }
}