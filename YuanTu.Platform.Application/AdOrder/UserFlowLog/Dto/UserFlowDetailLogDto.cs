using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuanTu.Platform.AdOrder.UserFlowLog.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AdUserFlowDetailLog))]
    public class UserFlowDetailLogDto : EntityDto<string>
    {
        public string FlowId { get; set; }

        public string TraceId { get; set; }

        public int SourceType { get; set; }

        public string ServiceName { get; set; }

        public decimal Tick { get; set; }

        public string InputData { get; set; }

        public string OutputData { get; set; }

        public string ExtResult { get; set; }

        public string PatientId { get; set; }

        public string PatientName { get; set; }
        public string IdCardNo { get; set; }

        public int LogLevel { get; set; }

        public string LogStep { get; set; }

        public string Msg { get; set; }

        public DateTime CreateTime { get; set; }

        public string createTimeStr
        {
            get
            {
                return CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}
