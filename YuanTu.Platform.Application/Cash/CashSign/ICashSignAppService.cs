using YuanTu.Platform.Cash.Dto;

namespace YuanTu.Platform.Cash
{
    public interface ICashSignAppService : IAsynPermissionAppService<CashSign, CashSignDto,string, CashSignRequestDto,CashSignDto, CashSignDto>
    {
    }
}
