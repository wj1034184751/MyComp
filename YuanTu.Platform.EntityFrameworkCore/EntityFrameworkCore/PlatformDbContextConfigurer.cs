using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace YuanTu.Platform.EntityFrameworkCore
{
    public static class PlatformDbContextConfigurer
    {
        //public static readonly ILoggerFactory MyLoggerFactory
        //    = LoggerFactory.Create(builder => { builder.AddConsole(); });
#if DEBUG
        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] {
            new DebugLoggerProvider()
        });
#endif

        //public static readonly ILoggerFactory MyLoggerFactory
        //    = LoggerFactory.Create(builder =>
        //    {
        //        builder
        //            .AddFilter((category, level) =>
        //                category == DbLoggerCategory.Database.Command.Name
        //                && level == LogLevel.Information)
        //            .AddConsole();
        //    });

        public static void Configure(DbContextOptionsBuilder<PlatformDbContext> builder, string connectionString)
        {
            builder
#if  DEBUG
                .UseLoggerFactory(MyLoggerFactory)
#endif 
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
#if !DEBUG
              .EnableSensitiveDataLogging(false);
#else
              .EnableSensitiveDataLogging(true);
#endif
        }

        public static void Configure(DbContextOptionsBuilder<PlatformDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection, ServerVersion.AutoDetect(connection.ConnectionString))
#if !DEBUG
              .EnableSensitiveDataLogging(false);
#else
              .EnableSensitiveDataLogging(true);
#endif
        }
    }
}
