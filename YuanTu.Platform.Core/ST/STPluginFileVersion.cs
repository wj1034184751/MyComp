using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    /// <summary>
    /// 文件版本
    /// </summary>
    public class STPluginFileVersion : CustomCreationEntityWithOrg<string>
    { 
        /// <summary>
        /// 文件夹ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string FolderId { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Version { get; set; }

        /// <summary>
        ///  插件代码（字典中插件类型代码）
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PluginCode { get; set; }

        /// <summary>
        /// 文件结构JSON内容
        /// </summary>
        public virtual string JsonText { get; set; }

        /// <summary>
        /// 程序路径
        /// </summary>
        [StringLength(PlatformConsts.MaxLength1024)]
        public virtual string Path { get; set; }

        /// <summary>
        /// exe传入参数
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Args { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PluginType { get; set; }

        /// <summary>
        /// 文件绝对路径
        /// </summary>
        [StringLength(PlatformConsts.MaxLength1024)]
        public virtual string AbsolutePath { get; set; }
    }
}