using Abp.Application.Services.Dto;
using YuanTu.Platform.Medical;
using YuanTu.Platform.Medical.MedTransStatisticss.Dto;

namespace YuanTu.Platform.Medical.MedTransStatisticss
{
    public interface IMedTransStatisticsAppService : IAsynPermissionAppService<MedTransStatistics, MedTransStatisticsDto, string, MedTransStatisticsRequestDto, MedTransStatisticsDto, MedTransStatisticsDto>
    {

    }
}