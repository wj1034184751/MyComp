using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace YuanTu.Platform.Web.Host.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    //所有controller都不限制post的body大小
                    options.Limits.MaxRequestBodySize = null;
                    options.Limits.MinRequestBodyDataRate = null;
                })
                .UseIIS()
#if !DEBUG
               .ConfigureLogging(logging =>
                    logging
                        .AddFilter("Microsoft.EntityFrameworkCore", LogLevel.None)
                )
#endif
                .Build();
        }
    }
}
