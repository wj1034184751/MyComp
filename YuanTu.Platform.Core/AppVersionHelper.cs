using System;
using System.IO;
using System.Threading.Tasks;
using Abp.Reflection.Extensions;

namespace YuanTu.Platform
{
    /// <summary>
    /// Central point for application version.
    /// </summary>
    public class AppVersionHelper
    {
        /// <summary>
        /// Gets current version of the application.
        /// It's also shown in the web page.
        /// </summary>
        public const string Version = "5.1.0.0";

        /// <summary>
        /// Gets release (last build) date of the application.
        /// It's shown in the web page.
        /// </summary>
        public static DateTime ReleaseDate => LzyReleaseDate.Value;

        private static readonly Lazy<DateTime> LzyReleaseDate = new Lazy<DateTime>(() => new FileInfo(typeof(AppVersionHelper).GetAssembly().Location).LastWriteTime);

        private const string CacheFileName = "abpcache.json";
        private static readonly object LockObj = new object();

        /// <summary>
        /// 更新缓存文件
        /// </summary>
        public static void UpdateCacheFile(string input)
        {
            var path = Path.GetDirectoryName(typeof(AppVersionHelper).GetAssembly().Location);
            var filePath = Path.Combine(path, CacheFileName);
            lock (LockObj)
                File.WriteAllTextAsync(filePath, input);
        }

        /// <summary>
        /// 获取缓存文件
        /// </summary>
        /// <returns></returns>
        public static Task<string> GetCacheFileAsync()
        {
            var path = Path.GetDirectoryName(typeof(AppVersionHelper).GetAssembly().Location);
            var filePath = Path.Combine(path, CacheFileName);
            if (!File.Exists(filePath)) return Task.FromResult(string.Empty);
            return File.ReadAllTextAsync(filePath);
        }
    }
}
