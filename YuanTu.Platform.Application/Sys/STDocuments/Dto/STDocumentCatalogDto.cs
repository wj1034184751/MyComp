using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys
{
    [Abp.AutoMapper.AutoMap(typeof(STDocumentCatalog))]
    public class STDocumentCatalogDto : ParentCustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 层级码
        /// </summary>
        public string LevelCode { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 语言包Id
        /// </summary>
        public string STLanguageId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
