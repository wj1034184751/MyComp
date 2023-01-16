using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Parts; 

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<STCardReader> STCardReader { get; set; }
        public DbSet<STKeyBoard> STKeyBoard { get; set; }
        public DbSet<STCashBox> STCashBox { get; set; }
        public DbSet<STPrinter> STPrinter { get; set; }
        public DbSet<STScanner> STScanner { get; set; }
        public DbSet<STCardDispenser> STCardDispenser { get; set; }
        public DbSet<STLedScreen> STLedScreen { get; set; }
        public DbSet<STCamera> STCamera { get; set; }
        public DbSet<STThermometer> STThermometer { get; set; }
        public DbSet<STSphygmomanometer> STSphygmomanometer { get; set; }
        public DbSet<STOximeter> STOximeter { get; set; }
        public DbSet<STOther> STOther { get; set; }
        public DbSet<STHeightAndWeight> STHeightAndWeight { get; set; }
        public DbSet<STECG> STECG { get; set; }
    }
}