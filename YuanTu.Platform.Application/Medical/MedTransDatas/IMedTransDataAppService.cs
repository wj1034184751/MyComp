using Abp.Application.Services.Dto;
using YuanTu.Platform.Medical;
using YuanTu.Platform.Medical.MedTransDatas.Dto;

namespace YuanTu.Platform.Medical.MedTransDatas
{
    public interface IMedTransDataAppService : IAsynPermissionAppService<MedTransData, MedTransDataDto, string, MedTransDataRequestDto, MedTransDataDto, MedTransDataDto>
    {
        //ListResultDto<AbpColumnDto> GetAllByTable(string tableName);
    }
}