using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YuanTu.Platform.Union;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<UnionTransData> UnionTransData { get; set; }

        public DbSet<UnionConfigData> UnionConfigData { get; set; }

    }
}
