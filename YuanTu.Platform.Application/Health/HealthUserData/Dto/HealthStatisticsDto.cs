using System.Collections.Generic;

namespace YuanTu.Platform.Health.Dto
{
    /// <summary>
    /// 统计数据
    /// </summary>
    public class HealthStatisticsDto 
    {
        /// <summary>
        /// 平均耗时
        /// </summary>
        public int TestAvgTime { get; set; }
        /// <summary>
        /// 检测总人数
        /// </summary>
        public int TestTotalCount { get; set; }
        /// <summary>
        /// 成功率
        /// </summary>
        public int TestSuccessRate { get; set; } 
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
        /// 检测次数分析
        /// </summary>
        public Dictionary<string,int> TestAvgCounts { get; set; }
    }
}