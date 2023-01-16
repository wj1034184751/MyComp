using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Jc.Advertising.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(Jc_AdvertisingCatalog))]
    public class AdvertisingCatalogDto : ParentCustomEntityWithOrgDto<string>
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
        /// 分类编码
        /// </summary>
        public string Code { get; set; }

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
