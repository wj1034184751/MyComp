using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.UC.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(UCBlog))]
    public class UCBlogDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 标题
        /// </summary> 
        [Required]
        public string Title { get; set; }
        /// <summary>
        ///  分类
        /// </summary> 
        [Required]
        public string CatalogId { get; set; }
        public UCCatalogDto Catalog { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// 标签
        /// </summary> 
        public string Tag { get; set; }
        /// <summary>
        /// 可见级别
        /// </summary> 
        public string VisibleLevel { get; set; }
        /// <summary>
        /// 作者
        /// </summary> 
        public string Author { get; set; }
    }
}