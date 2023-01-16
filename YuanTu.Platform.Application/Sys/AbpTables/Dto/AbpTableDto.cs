using YuanTu.Platform.Common.Dto; 

namespace YuanTu.Platform.Sys.AbpTables.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AbpTable))]
    public class AbpTableDto : CustomCreationEntityWithOrgDto<string>
    {
        public string Namespace { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string PkDataType { get; set; }

        public bool IsParent { get; set; }

        public bool IsDistinatOrg { get; set; }

        public bool IsFullEdit { get; set; }

        /// <summary>
        /// 是否从表
        /// </summary>
        public virtual bool IsDetail { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        public string ParentId { get; set; }
    }
}