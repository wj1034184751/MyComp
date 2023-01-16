using Microsoft.EntityFrameworkCore; 

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<Health.HealthConfig> HealthConfig { get; set; }

        public DbSet<Health.HealthUserData> HealthUserData { get; set; }
    }
}