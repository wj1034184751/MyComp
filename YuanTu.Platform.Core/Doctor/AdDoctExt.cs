using Abp.Domain.Entities;

namespace YuanTu.Platform.Doctor
{
    /// <summary>
    /// 医生扩展表
    /// </summary>
    public class AdDoctExt : Entity<string>
    {
        /// <summary>
        /// 医生表编号（主键）
        /// </summary> 
        public virtual long DoctId { get; set; } 

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }
    }
}