using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    public class AbpColumn : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 表Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string AbpTableId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DataType { get; set; }

        /// <summary>
        /// 允许为空
        /// </summary>
        public virtual bool CanbeNull { get; set; }

        /// <summary>
        /// 最小长度
        /// </summary>
        public virtual int MinLen { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        public virtual int MaxLen { get; set; }

        /// <summary>
        /// 正则表达式
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Regex { get; set; }

        /// <summary>
        /// 正则表达式，数据字典ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string RegexModeId { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        [StringLength(PlatformConsts.MaxLength1024)]
        public virtual string RegexDescribe { get; set; }

        /// <summary>
        /// 映射类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string MapType { get; set; }

        /// <summary>
        /// 映射对象
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string MapTable { get; set; }

        /// <summary>
        /// 映射枚举值
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string MapEnum { get; set; }

        /// <summary>
        /// 默认枚举值
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DefaultEnum { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }

        /// <summary>
        /// 关联控件
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string UserControl { get; set; }

        /// <summary>
        /// 是否只读
        /// </summary>
        public virtual bool IsReadOnly { get; set; }

        #region 样式

        /// <summary>
        /// 是否显示/隐藏
        /// </summary>
        public virtual bool Visible { get; set; }
        /// <summary>
        /// 是否脱敏
        /// </summary>
        public virtual bool Sensitive { get; set; }
        /// <summary>
        /// 脱敏规则
        /// </summary>
        [StringLength(PlatformConsts.MaxLength2048)]
        public virtual string SensitiveRule { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public virtual int Width { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public virtual int MinWidth { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public virtual int MaxWidth { get; set; }
        /// <summary>
        /// 对齐方式，可选值为 left 左对齐、right 右对齐和 center 居中对齐
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Align { get; set; }
        /// <summary>
        /// 列的样式
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Style { get; set; }
        /// <summary>
        /// 列的样式名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ClassName { get; set; }
        /// <summary>
        /// 列是否固定在左侧或者右侧，可选值为 left 左侧和 right 右侧
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Fixed { get; set; }
        /// <summary>
        /// 开启后，文本将不换行，超出部分显示为省略号
        /// </summary>
        public virtual bool Ellipsis { get; set; }
        /// <summary>
        /// 开启后，文本将不换行，超出部分显示为省略号，并用 Tooltip 组件显示完整内容
        /// </summary>
        public virtual bool Tooltip { get; set; }

        #endregion 
    }
}
