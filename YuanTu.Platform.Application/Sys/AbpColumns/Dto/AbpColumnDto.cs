using YuanTu.Platform.Common.Dto;
namespace YuanTu.Platform.Sys.AbpColumns.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AbpColumn))]
    public class AbpColumnDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 表Id
        /// </summary>
        public string AbpTableId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 允许为空
        /// </summary>
        public bool CanbeNull { get; set; }

        /// <summary>
        /// 最小长度
        /// </summary>
        public int MinLen { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLen { get; set; }

        /// <summary>
        /// 正则表达式
        /// </summary>
        public string Regex { get; set; }

        /// <summary>
        /// 错误描述
        /// </summary>
        public string RegexDescribe { get; set; }

        /// <summary>
        /// 映射类型
        /// </summary>
        public string MapType { get; set; }

        /// <summary>
        /// 映射对象
        /// </summary>
        public string MapTable { get; set; }

        /// <summary>
        /// 映射枚举值
        /// </summary>
        public string MapEnum { get; set; }

        /// <summary>
        /// 默认枚举值
        /// </summary>
        public string DefaultEnum { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 关联控件
        /// </summary>
        public string UserControl { get; set; }

        /// <summary>
        /// 是否只读
        /// </summary>
        public bool IsReadOnly { get; set; }

        #region 样式

        /// <summary>
        /// 是否显示/隐藏
        /// </summary>
        public bool Visible { get; set; }
        /// <summary>
        /// 是否脱敏
        /// </summary>
        public bool Sensitive { get; set; }
        /// <summary>
        /// 脱敏规则
        /// </summary>
        public string SensitiveRule { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public int MinWidth { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public int MaxWidth { get; set; }
        /// <summary>
        /// 对齐方式，可选值为 left 左对齐、right 右对齐和 center 居中对齐
        /// </summary>
        public string Align { get; set; }
        /// <summary>
        /// 列的样式
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// 列的样式名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 列是否固定在左侧或者右侧，可选值为 left 左侧和 right 右侧
        /// </summary>
        public string Fixed { get; set; }
        /// <summary>
        /// 开启后，文本将不换行，超出部分显示为省略号
        /// </summary>
        public bool Ellipsis { get; set; }
        /// <summary>
        /// 开启后，文本将不换行，超出部分显示为省略号，并用 Tooltip 组件显示完整内容
        /// </summary>
        public bool Tooltip { get; set; }

        #endregion 
    }
}