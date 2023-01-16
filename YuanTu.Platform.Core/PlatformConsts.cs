namespace YuanTu.Platform
{
    public class PlatformConsts
    {
        public const string LocalizationSourceName = "Platform";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;

        #region 上传文件大小

        public const long RequestSizeLimit = 1024000000;//1GB

        #endregion

        #region 数据库字段长度定义

        public const int MaxLength16 = 16;
        public const int MaxLength20 = 20;
        public const int MaxLength32 = 32;
        public const int MaxLength36 = 36;
        public const int MaxLength50 = 50;
        public const int MaxLength64 = 64;
        public const int MaxLength100 = 100;
        public const int MaxLength128 =128;
        public const int MaxLength200 = 200;
        public const int MaxLength255 = 255;//临界点
        public const int MaxLength512 = 512;
        public const int MaxLength1024 = 1024;
        public const int MaxLength2048 = 2048;
        public const int MaxLength4000 = 4000;
        public const int MaxLength5000 = 5000;

        #endregion
    }
}
