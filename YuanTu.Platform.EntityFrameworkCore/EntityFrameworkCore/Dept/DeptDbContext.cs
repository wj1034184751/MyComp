using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Dept;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<AdDept> Ad_Dept { get; set; }
        public DbSet<AdDeptExt> AdDeptExt { get; set; }
    }
}