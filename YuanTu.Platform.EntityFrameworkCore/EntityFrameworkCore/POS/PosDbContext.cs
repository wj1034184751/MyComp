using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.POS;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<PosTrade> PosTrade { get; set; }
        public DbSet<PosConfig> PosConfig { get; set; }
    }
}