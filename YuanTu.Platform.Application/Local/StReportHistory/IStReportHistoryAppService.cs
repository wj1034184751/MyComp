
using System;
using YuanTu.Platform;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Local.StReportHistory.Dto;

namespace YuanTu.Platform.Local
{
    /// <summary>
    /// 报告打印查询
    /// 作者: 系统用户
    /// 生成时间: 2022年08月04日 08:17:16
    /// </summary>
    public interface IStReportHistoryAppService : IAsynPermissionAppService<STReportHistory, StReportHistoryDto, string, PagedSTReportHistoryRequestDto, StReportHistoryDto, StReportHistoryDto>
    {
    }
}
