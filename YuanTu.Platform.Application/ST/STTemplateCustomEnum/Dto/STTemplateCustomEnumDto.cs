using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.Sys.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTemplateCustomEnum))]
    public class STTemplateCustomEnumDto : ParentCustomEntityWithOrgDto<string>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string ParentCode { get; set; }

        public  string TemplateId { get; set; }

        public int Sort { get; set; }

        /// <summary>
        /// 规则描述
        /// </summary>
        public string Rule { get; set; }
    }
}
