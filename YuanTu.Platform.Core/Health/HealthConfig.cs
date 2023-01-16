using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Health
{
    /// <summary>
    /// 预检设备功能配置表
    /// </summary>
    public class HealthConfig : CustomCreationEntityWithOrg<string>
    {
        /// <summary>
        /// 配置名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual  string Name { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        public virtual long HospitalId { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DeviceType { get; set; }

        /// <summary>
        /// 启用/停用
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// 配置JSON文本
        /// </summary> 
        public virtual string JsonText { get; set; }
    }
}