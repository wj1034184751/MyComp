using Abp.Application.Services.Dto;
using YuanTu.Platform.Medical;
using YuanTu.Platform.Medical.MedTradeDatas.Dto;

namespace YuanTu.Platform.Medical.MedTradeDatas
{
    public interface IMedTradeDataAppService : IAsynPermissionAppService<MedTradeData, MedTradeDataDto, string, MedTradeDataRequestDto, MedTradeDataDto, MedTradeDataDto>
    {
        //ListResultDto<AbpColumnDto> GetAllByTable(string tableName);
    }
}