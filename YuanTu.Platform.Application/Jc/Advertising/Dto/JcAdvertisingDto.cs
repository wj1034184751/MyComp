using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Jc.Advertising.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(Jc_Advertising))]
    public class JcAdvertisingDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 文档分类
        /// </summary>
        public string Jc_AdvertisingCatalogId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// 二级标题
        /// </summary>
        public string SndCaption { get; set; }

        /// <summary>
        /// 标签(暂不用)
        /// </summary>
        public string Labels { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 轮播图
        /// </summary>
        public string Carousel { get; set; }

        /// <summary>
        /// 附件Id
        /// </summary>
        public string AttachmentTypeId { get; set; }

        /// <summary>
        /// 附件地址
        /// </summary>
        public string AttachmentUrl { get; set; }

        /// <summary>
        /// 附件类型、PDF、图片、视频（需考虑本地缓存策略）
        /// </summary>
        public string AttachmentType { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 点击数(暂不用)
        /// </summary>
        public int ClickNum { get; set; }

        /// <summary>
        /// 投放状态（待发布、待审核、已审核、反审核）
        /// </summary>
        public string AdStatus { get; set; }

        /// <summary>
        /// 投放策略（无限期、特定期限）
        /// </summary>
        public string AdStrategy { get; set; }

        /// <summary>
        /// 投放媒介（终端设备、公众号、APP、网站）
        /// </summary>
        public string AdMedium { get; set; }

        /// <summary>
        /// 是否全部设备投放
        /// </summary>
        public bool IsAllMedium { get; set; }

        /// <summary>
        /// 投放页面（首页、支付页面等等）(暂不用)
        /// </summary>
        public string AdPage { get; set; }

        /// <summary>
        /// 投放位置（横幅、中间、左边、右边、浮动、底部）(暂不用)
        /// </summary>
        public string AdPos { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishTime { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CheckTime { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 支持打印
        /// </summary>
        public bool Printable { get; set; }

        /// <summary>
        /// 支持下载
        /// </summary>
        public bool Downloadable { get; set; }
    }
}
