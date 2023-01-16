using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Cash;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<CashSign> CashSign { get; set; }

        public DbSet<CashTrade> CashTrade { get; set; }

        public DbSet<CashTradeDetail> CashTradeDetail { get; set; }

        public DbSet<CashAmount> CashAmount { get; set; }
    }
}
