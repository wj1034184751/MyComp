using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YuanTu.Platform.Local
{
    public interface IStPrintReportAppService : IAsynPermissionAppService<StPrintReport, StPrintReportDto, string, PagedStPrintReportDto, StPrintReportDto, StPrintReportDto>
    {
    }
}
