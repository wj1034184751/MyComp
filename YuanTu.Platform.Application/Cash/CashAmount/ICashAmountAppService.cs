using YuanTu.Platform.Cash.Dto;

namespace YuanTu.Platform.Cash
{
    public interface ICashAmountAppService : IAsynPermissionAppService<CashAmount, CashAmountDto, string, CashAmountRequestDto, CashAmountDto, CashAmountDto>
    {
    }
}
