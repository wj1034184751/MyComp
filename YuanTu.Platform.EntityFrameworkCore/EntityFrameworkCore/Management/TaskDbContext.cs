using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Management;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public partial class PlatformDbContext
    {
        public DbSet<Task> Task { get; set; }

        public DbSet<TaskDetail> TaskDetail { get; set; }

        public DbSet<TaskTrigger> TaskTrigger { get; set; }

        public DbSet<TaskOperation> TaskOperation { get; set; }

        public DbSet<TaskVsTerminal> TaskVsTerminal { get; set; }


    }
}
