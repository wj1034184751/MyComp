using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using YuanTu.Platform.AdOrder;
using YuanTu.Platform.Common.Dto;
using System.Collections.Generic;
using YuanTu.Platform.AdOrder.UserFlowLog.Dto;

namespace YuanTu.Platform.UserFlowLog.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AdUserFlowLog))]
    public class UserFlowLogDto : EntityDto<string>
    {
        public string TraceId { get; set; }
        public int BusinessType { get; set; }

        public int Status { get; set; }

        public string PatientId { get; set; }

        public string PatientName { get; set; }

        public string IptOptNo { get; set; }

        public string IptHospitalNo { get; set; }

        public string IdCardNo { get; set; }

        public string TerminalNo { get; set; }

        public string DeviceIp { get; set; }

        public DateTime OperateTime { get; set; }

        public string operateTimeStr
        { 
            get
            {
                return OperateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        public string BusinessTypeStr
        {
            get
            {
                //业务类型(1:挂号,2:预约，3：缴费，4：门诊充值，5：住院充值，6：自助入院，7：出院结算，8：检验报告打印
                var result = string.Empty;
                switch (BusinessType)
                {
                    case 1:
                        result = "挂号";
                        break;
                    case 2:
                        result = "预约";
                        break;
                    case 3:
                        result = "缴费";
                        break;
                    case 4:
                        result = "门诊充值";
                        break;
                    case 5:
                        result = "住院充值";
                        break;
                    case 6:
                        result = "自助入院";
                        break;
                    case 7:
                        result = "出院结算";
                        break;
                    case 9:
                        result = "检验报告打印";
                        break;
                    default:
                        result = "全部";
                        break;
                }
                return result;
            }
        }

        public string PatientnameOrId
        {
            get
            {
                return $"{PatientName}|{PatientId}";
            }
        }

        public string StatusStr
        {
            get
            {
                //状态(1:成功, 2:失败, 3:单边, 4:未知)
                var result = string.Empty;
                switch (Status)
                {
                    case 1:
                        result = "成功";
                        break;
                    case 2:
                        result = "失败";
                        break;
                    case 3:
                        result = "单边";
                        break;
                    case 4:
                        result = "未知";
                        break;
                    default:
                        result = "全部";
                        break;
                }
                return result;
            }
        }

        public List<UserFlowDetailLogDto> YuDetailListlog { get; set; } = new List<UserFlowDetailLogDto>();

        public List<UserHisFlowDetailLogDto> HisDetailListlog { get; set; } = new List<UserHisFlowDetailLogDto>();

    }
}