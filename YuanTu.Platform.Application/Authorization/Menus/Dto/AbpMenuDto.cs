using Abp.AutoMapper;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Authorization.Menus.Dto
{
    [AutoMap(typeof(AbpMenu))]
    public class AbpMenuDto : ParentCustomEntityWithOrgDto<string>
    {
        public string Code
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Router
        {
            get;
            set;
        }

        public string Icon
        {
            get;
            set;
        }

        public int Sort
        {
            get;
            set;
        }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 添加
        /// </summary>
        public bool IsAddEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 编辑
        /// </summary>
        public bool IsEditEnabled
        {
            get;
            set;
        }


        /// <summary>
        /// 激活/停用
        /// </summary>
        public bool IsActiveEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public bool IsDeleteEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 审核
        /// </summary>
        public bool IsApproveEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 打印
        /// </summary>
        public bool IsPrintEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// 是否区分机构
        /// </summary>
        public bool IsOrgDiscriminated
        {
            get;
            set;
        }

        /// <summary>
        /// 未确定状态
        /// </summary>
        public bool Indeterminate { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked { get; set; }
    }
}
