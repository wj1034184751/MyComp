using YuanTu.Platform.Payment.Dto; 

namespace YuanTu.Platform.Payment
{
    public interface IPayTradeAppService : IAsynPermissionAppService<PayTrade, PayTradeDto, string, PagePayTradeRequestDto, PayTradeDto, PayTradeDto>
    {

    } 
}
