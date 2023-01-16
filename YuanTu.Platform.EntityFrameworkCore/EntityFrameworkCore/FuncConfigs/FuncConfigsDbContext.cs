using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.StFuncConfigs;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<StFuncConfig> StFuncConfig { get; set; }

        public DbSet<StTerminalFuncConfig> StTerminalFuncConfig { get; set; }

        //public DbSet<StFuncItemConfig> StFuncItemConfig { get; set; }

    }
}
