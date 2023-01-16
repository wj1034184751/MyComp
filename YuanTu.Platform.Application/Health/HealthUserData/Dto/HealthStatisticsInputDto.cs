﻿using System;

namespace YuanTu.Platform.Health.Dto
{
    public class HealthStatisticsInputDto
    {
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StarTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
    }
}
