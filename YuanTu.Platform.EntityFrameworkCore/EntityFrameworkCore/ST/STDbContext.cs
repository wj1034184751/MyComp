using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.St;
using YuanTu.Platform.ST;
using YuanTu.Platform.StDisinfects;
using YuanTu.Platform.StMaintains;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<STTerminal> STTerminal { get; set; }

        public DbSet<STTerminalPart> STTerminalPart { get; set; }

        public DbSet<STTerminalPlugin> STTerminalPlugin { get; set; }

        public DbSet<STTerminalPluginNet> STTerminalPluginNet { get; set; }

        public DbSet<STTemplate> STTemplate { get; set; }

        public DbSet<STTemplatePart> STTemplatePart { get; set; }

        public DbSet<STTemplatePlugin> STTemplatePlugin { get; set; }

        public DbSet<STTemplatePluginNet> STTemplatePluginNet { get; set; }

        public DbSet<STPlugin> STPlugin { get; set; }

        public DbSet<STPluginDetail> STPluginDetail { get; set; }

        //public DbSet<STTerminalFolder> STTerminalFolder { get; set; }

        public DbSet<STPluginFolder> STPluginFolder { get; set; }

        public DbSet<STPluginFileVersion> STPluginFileVersion { get; set; }

        public DbSet<STTerminalCustomEnum> STTerminalCustomEnum { get; set; }

        public DbSet<STTemplateEnum> STTemplateEnum { get; set; }

        public DbSet<STTemplateCustomEnum> STTemplateCustomEnum { get; set; }

        public DbSet<StMaintaintor> StMaintains { get; set; }

        public DbSet<StMaintainLog> StMaintainLogs { get; set; }

        public DbSet<STTerminalDeptMap> STTerminalDeptMap { get; set; }

        public DbSet<DigitalMap> DigitalMap { get; set; }

        public DbSet<DigitalMapModel> DigitalMapModel { get; set; }

        public DbSet<StDisinfect> StDisinfect { get; set; }

        public DbSet<StDisinfectLog> StDisinfectLog { get; set; }
    }
}