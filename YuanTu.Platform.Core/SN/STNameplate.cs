using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.SN
{
    public class STNameplate : CustomCreationEntityWithOrg<string>, IModificationAudited,
        IHasModificationTime
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public virtual DateTime OrderDate { get; set; }

        /// <summary>
        /// 预发货时间
        /// </summary>
        public virtual DateTime PreDeliveryDate { get; set; }

        /// <summary>
        /// 发货状态
        /// </summary>
        public virtual byte DeliveryStatus { get; set; }

        /// <summary>
        /// 微信随机码
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string WeChatCode { get; set; }

        public virtual DateTime? LastModificationTime { get; set; }
        public virtual long? LastModifierUserId { get; set; }
    }
}