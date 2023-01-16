using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.UC.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(UCCatalog))]
    public class UCCatalogDto : CustomCreationEntityWithOrgDto<string>
    { 
        /// <summary>
        ///  分类
        /// </summary> 
        [Required]
        public string Name { get; set; } 
    }
}