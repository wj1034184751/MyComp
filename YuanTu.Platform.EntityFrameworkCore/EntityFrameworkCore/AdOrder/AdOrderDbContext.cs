using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.AdOrder;
using YuanTu.Platform.App; 

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<AdUserAccount> AdUserAccount { get; set; }

        public DbSet<AdUserInhosRecord> AdUserInhosRecord { get; set; }

        public DbSet<AdRegBusinessOrder> AdRegBusinessOrder { get; set; }

        public DbSet<AdRechargeBusinessOrder> AdRechargeBusinessOrder { get; set; }

        public DbSet<AdBillBusinessOrder> AdBillBusinessOrder { get; set; }

        public DbSet<AdInhosBusinessOrder> AdInhosBusinessOrder { get; set; }

        public DbSet<AdSetPatientBusinessOrder> AdSetPatientBusinessOrder { get; set; }

        public DbSet<AdUserFlowLog> AdUserFlowLog { get; set; }

        public DbSet<AdUserFlowDetailLog> AdUserFlowDetailLog { get; set; }

        public DbSet<AdUserHisFlowDetailLog> AdUserHisFlowDetailLog { get; set; }
    }
}