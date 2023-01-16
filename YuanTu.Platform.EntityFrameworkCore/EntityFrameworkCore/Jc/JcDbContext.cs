using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.App;
using YuanTu.Platform.Jc;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<Jc_UserEnum> Jc_UserEnum { get; set; }

        public DbSet<Jc_Advertising> Jc_Advertising { get; set; }

        public DbSet<Jc_Advertising_Terminal> Jc_Advertising_Terminal { get; set; }

        public DbSet<Jc_AdvertisingCatalog> Jc_AdvertisingCatalog { get; set; }
    }
}
