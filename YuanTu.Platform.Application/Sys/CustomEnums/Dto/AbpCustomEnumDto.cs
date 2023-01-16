using YuanTu.Platform.Common.Dto; 

namespace YuanTu.Platform.Sys.CustomEnums.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AbpCustomEnum))]
    public class AbpCustomEnumDto : ParentCustomEntityWithOrgDto<string>
    {
        public string Code
        {
            get;
            set;
        }

        public string Name
        {
            get; set;
        }

        public string ParentCode
        {
            get;
            set;
        }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImageUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string ThumbnailUrl
        {
            get;
            set;
        }

        public int Sort
        {
            get;
            set;
        }

        /// <summary>
        /// 规则描述
        /// </summary>
        public string Rule { get; set; }
    }
}
