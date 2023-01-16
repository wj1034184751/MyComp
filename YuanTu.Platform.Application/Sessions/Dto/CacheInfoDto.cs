namespace YuanTu.Platform.Sessions.Dto
{
    public enum CacheType
    {
        UnKnown, Enum, Menu
    }

    public class BaseCacheInfo
    {
        public string Version { get; set; }
    }

    public class MenuCacheInfo : BaseCacheInfo { }

    public class EnumCacheInfo : BaseCacheInfo { }

    public class CacheInfoDto
    {
        public MenuCacheInfo MenuCache { get; set; }
        public EnumCacheInfo EnumCache { get; set; }
    }
}