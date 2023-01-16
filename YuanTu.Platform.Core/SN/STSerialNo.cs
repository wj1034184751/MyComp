using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Abp.Domain.Entities.Auditing;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.SN
{
    public class STSerialNo : CustomCreationEntityWithOrg<string>, IModificationAudited, IHasModificationTime
    {
        /// <summary>
        /// 设备型号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TerminalTypeId { get; set; }

        /// <summary>
        /// 下单日期
        /// </summary>
        public virtual DateTime OrderDate { get; set; }

        /// <summary>
        /// 设备颜色
        /// </summary>
        [StringLength(PlatformConsts.MaxLength20)]
        public virtual string Color { get; set; }

        /// <summary>
        /// 设备数量
        /// </summary>
        public virtual int Num { get; set; }

        /// <summary>
        /// 起始编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength20)]
        public virtual string StartNum { get; set; }

        /// <summary>
        /// 钣金厂家
        /// </summary>
        [StringLength(PlatformConsts.MaxLength20)]
        public virtual string Factory { get; set; }

        /// <summary>
        /// 状态 1-正常 0-作废
        /// </summary>
        public virtual bool Status { get; set; } = true;

        /// <summary>
        /// 铭牌项目编号
        /// </summary>
        public virtual string NameplateId { get; set; } 

        /// <summary>
        /// SN码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string SerialNo { get; set; }

        /// <summary>
        /// 下单型号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string OrderModel { get; set; }

        /// <summary>
        /// 发货型号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DeliveryModel { get; set; }

        /// <summary>
        /// 发货状态
        /// </summary>
        public virtual byte DeliveryStatus { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public virtual byte TerminalModel { get; set; }

        public virtual DateTime? LastModificationTime { get; set; }
        public virtual long? LastModifierUserId { get; set; }
    }
}