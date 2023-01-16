using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.App; 

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<AppAuth> AppAuth { get; set; } 
    }
}