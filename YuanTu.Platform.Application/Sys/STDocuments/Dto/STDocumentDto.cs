using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys
{
    /// <summary>
     /// 文档中心
     /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(STDocument))]
    public class STDocumentDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 文档分类
        /// </summary>
        public string STDocumentCatalogId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Labels { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 点击数
        /// </summary>
        public int ClickNum { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; }

        /// <summary>
        /// 消息置顶
        /// </summary>
        public bool IsSetTop { get; set; }

        /// <summary>
        /// 置顶有效期
        /// </summary>
        public DateTime? SetTopTime { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishTime { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
