using YuanTu.Platform.Cash.Dto;

namespace YuanTu.Platform.Cash
{
    public interface ICashTradeAppService : IAsynPermissionAppService<CashTrade, CashTradeDto, string, CashTradeRequestDto, CashTradeDto, CashTradeDto>
    {
    }
}
