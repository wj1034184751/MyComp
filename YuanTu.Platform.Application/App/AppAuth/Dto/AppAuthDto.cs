using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.App.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AppAuth))]
    public class AppAuthDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 应用名称
        /// </summary> 
        public string AppName { get; set; }

        /// <summary>
        /// 应用ID
        /// </summary> 
        public string AppId { get; set; }

        /// <summary>
        /// 公钥
        /// </summary>  
        public string AppKey { get; set; }

        /// <summary>
        /// 密钥
        /// </summary> 
        public string AppSecret { get; set; }

        /// <summary>
        /// 生成的Token值
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enabled { get; set; }
    }
}