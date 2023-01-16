using System;
using System.Threading.Tasks;
using Abp.Json;
using Castle.Core.Logging;  
using YuanTu.Platform.Sessions.Dto;

namespace YuanTu.Platform
{
    internal sealed class AppCacheHelper
    {
        /// <summary>
        /// 更新缓存版本
        /// </summary>
        /// <param name="cacheType"></param>
        /// <returns></returns>
        public static async Task<string> UpdateCache(CacheType cacheType)
        {
            var cache = string.Empty;
            try
            {
                var version = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                cache = await AppVersionHelper.GetCacheFileAsync();
                if (string.IsNullOrWhiteSpace(cache))
                {
                    var cacheInfo = new CacheInfoDto
                    {
                        MenuCache = new MenuCacheInfo { Version = version },
                        EnumCache = new EnumCacheInfo { Version = version }
                    };
                    cache = cacheInfo.ToJsonString(true); 
                }
                else
                {
                    var cacheInfo = cache.FromJsonString<CacheInfoDto>();
                    switch (cacheType)
                    {
                        case CacheType.Menu:
                            cacheInfo.MenuCache.Version = version;
                            break;
                        case CacheType.Enum:
                            cacheInfo.EnumCache.Version = version;
                            break; 
                        case CacheType.UnKnown:
                            break;
                        default:
                            break;
                    } 
                    cache = cacheInfo.ToJsonString(true);
                }
                AppVersionHelper.UpdateCacheFile(cache);
            }
            catch (Exception ex)
            {
                NullLogger.Instance.Error(ex.ToString);
            }

            return cache;
        }
    }
}