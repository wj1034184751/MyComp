using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.EntityFrameworkCore
{
    partial class PlatformDbContext
    {
        public DbSet<STMsg> STMsgs { get; set; }

        public DbSet<STMsgCatalog> STMsgCatalog { get; set; }

        public DbSet<STDocument> STDocument { get; set; }

        public DbSet<STDocumentCatalog> STDocumentCatalog { get; set; }
    }
}