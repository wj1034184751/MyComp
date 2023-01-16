
using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Authorization.Roles;
using YuanTu.Platform.Authorization.Users;
using YuanTu.Platform.Medical;
using YuanTu.Platform.MultiTenancy;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<MedTransData> MedTransData
        {
            get;
            set;
        }

        public DbSet<MedHisTransData> MedHisTransData
        {
            get;
            set;
        }

        public DbSet<MedCheckAccountinfo> MedCheckAccountinfo
        {
            get;
            set;
        }

        public DbSet<MedCheckExpData> MedCheckExpData
        {
            get;
            set;
        }

        public DbSet<MedSigninfo> MedSigninfo
        {
            get;
            set;
        }

        public DbSet<MedTransStatistics> MedTransStatistics
        {
            get;
            set;
        }

        public DbSet<MedTradeData> MedTradeData
        {
            get;
            set;
        }
    }
}
