using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using YuanTu.Platform.Authorization.Menus;
using YuanTu.Platform.Authorization.Roles;
using YuanTu.Platform.Authorization.Users;
using YuanTu.Platform.Health;
using YuanTu.Platform.MultiTenancy;
using YuanTu.Platform.Organizations;
using YuanTu.Platform.Sys;
using YuanTu.Platform.Local;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext : AbpZeroDbContext<Tenant, Role, User, PlatformDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AbpCustomEnum>(b => { b.HasIndex(e => new { e.ParentCode }); });

            modelBuilder.Entity<HealthUserData>(b => { b.HasIndex(e => new { e.IdNo }); });

            modelBuilder.Entity<AbpOrg>(b => { b.HasIndex(e => new { e.HospitalId, e.Code }).IsUnique(); });

            modelBuilder.Entity<STTerminalCustomEnum>(b => { b.HasIndex(e => new {e.TerminalId}); });

            modelBuilder.Entity<STTemplateCustomEnum>(b => { b.HasIndex(e => new { e.TemplateId }); });
        }

        public DbSet<AbpCustomEnum> AbpCustomEnums { get; set; }

        public DbSet<AbpMenu> AbpMenus { get; set; }

        public DbSet<AbpLog> AbpLogs { get; set; }

        public DbSet<AbpTable> AbpTables { get; set; }

        public DbSet<AbpColumn> AbpColumns { get; set; }

        public DbSet<AbpAttachment> AbpAttachment { get; set; }

        public DbSet<AbpZipLog> AbpZipLog { get; set; }

        public DbSet<AbpOrg> CustomOrganizationUnits { get; set; }

        public DbSet<AbpWardArea> AbpWardArea { get; set; }

        public DbSet<AbpMenuPermission> AbpMenuPermissions { get; set; }
        //public DbSet<AbpFolder> AbpFolder { get; set; }
    }
}
