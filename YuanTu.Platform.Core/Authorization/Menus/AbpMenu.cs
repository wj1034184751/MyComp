using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Authorization.Menus
{
    public class AbpMenu : ParentCustomEditEntityWithOrg<string>
    {
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code
        {
            get;
            set;
        }

        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name
        {
            get;
            set;
        }

        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Router
        {
            get;
            set;
        }

        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Icon
        {
            get;
            set;
        }

        public virtual int Sort
        {
            get;
            set;
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// 是否区分机构
        /// </summary>
        public virtual bool IsOrgDiscriminated
        {
            get;
            set;
        }

        /// <summary>
        /// 添加
        /// </summary>
        public virtual bool IsAddEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public virtual bool IsEditEnabled
        {
            get;
            set;
        }


        /// <summary>
        /// 激活/停用
        /// </summary>
        public virtual bool IsActiveEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public virtual bool IsDeleteEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 审核
        /// </summary>
        public virtual bool IsApproveEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 打印
        /// </summary>
        public virtual bool IsPrintEnabled
        {
            get;
            set;
        }

        [ForeignKey("MenuId")]
        public List<AbpMenuFunc> MenuFuncs
        {
            get;
            set;
        }
    }
}
