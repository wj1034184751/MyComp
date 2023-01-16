using System;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Health.Dto
{
    /// <summary>
    /// 预检用户数据
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(HealthUserData))]
    public class HealthUserDataDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 姓名
        /// </summary> 
        public string Name { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public byte Sex { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>

        public string IdNo { get; set; }
        /// <summary>
        /// 开始检测时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsComplete { get; set; }
        /// <summary>
        /// 身高
        /// </summary>

        public string Height { get; set; }
        /// <summary>
        /// 体重
        /// </summary>

        public string Weight { get; set; }
        /// <summary>
        /// 体脂（预留）
        /// </summary>

        public string Fat { get; set; }
        /// <summary>
        /// 血氧
        /// </summary>

        public string SaO2 { get; set; }
        /// <summary>
        /// 体温
        /// </summary>

        public string Temperature { get; set; }
        /// <summary>
        /// 血压
        /// </summary>

        public string BloodPressure { get; set; }
        /// <summary>
        /// 脉搏
        /// </summary> 
        public string Pulse { get; set; }
        /// <summary>
        /// 心电
        /// </summary> 
        public string Ecg { get; set; }

        /// <summary>
        /// 测量身高体重耗时
        /// </summary>
        public int HtTime { get; set; }
        /// <summary>
        /// 测量血氧耗时
        /// </summary>
        public int SaO2Time { get; set; }
        /// <summary>
        /// 测量体温耗时
        /// </summary>
        public int TempTime { get; set; }
        /// <summary>
        /// 测量血压耗时
        /// </summary>
        public int BpTime { get; set; }
        /// <summary>
        /// 测量体脂耗时（预留）
        /// </summary>
        public int FatTime { get; set; }
        /// <summary>
        /// 测量心电耗时（预留）
        /// </summary>
        public int EcgTime { get; set; }

        /// <summary>
        /// 总耗时
        /// </summary>
        public int TotalTime => HtTime + SaO2Time + TempTime + BpTime + FatTime + EcgTime;
    }
}