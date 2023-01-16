using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Payment;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<PayTrade> PayTrade { get; set; } 
    }
}