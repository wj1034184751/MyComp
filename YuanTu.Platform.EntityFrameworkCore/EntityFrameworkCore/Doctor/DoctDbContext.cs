using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Dept;
using YuanTu.Platform.Doctor;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<AdDoct> Ad_Doct { get; set; }
        public DbSet<AdDoctExt> AdDoctExt { get; set; }
    }
}