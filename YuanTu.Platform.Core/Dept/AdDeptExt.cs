using Abp.Domain.Entities;

namespace YuanTu.Platform.Dept
{
    /// <summary>
    /// 科室扩展表
    /// </summary>
    public class AdDeptExt : Entity<string>
    {
        /// <summary>
        /// 科室表编号（主键）
        /// </summary> 
        public virtual long DeptId { get; set; }

        /// <summary>
        /// 性别限制
        /// </summary>
        public virtual byte GenderRestrictionType { get; set; }

        /// <summary>
        /// 可挂号年龄段最小值
        /// </summary>
        public virtual int MinAge { get; set; }

        /// <summary>
        /// 可挂号年龄段最大值
        /// </summary>
        public virtual int MaxAge { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }
    }
}