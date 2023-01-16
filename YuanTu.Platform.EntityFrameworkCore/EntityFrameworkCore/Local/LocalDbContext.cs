using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Local;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<PrintTemplate> PrintTemplate { get; set; } 

        public DbSet<FireWall> FireWall { get; set; }

        public DbSet<STPrintHistory> STPrintHistory { get; set; }

        public DbSet<StPrintReport> StPrintReport { get; set; }
        public DbSet<STReportRecord> STReportRecord { get; set; }
        public DbSet<STReportHistory> STReportHistory { get; set; }

    }
}
