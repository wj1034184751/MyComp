using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.SN;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<STNameplate> STNameplate { get; set; }

        public DbSet<STSerialNo> STSerialNo { get; set; } 
    }
}