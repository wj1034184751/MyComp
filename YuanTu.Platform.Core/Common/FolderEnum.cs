using System.ComponentModel;

namespace YuanTu.Platform.Common
{
    /// <summary>
    /// 文件夹枚举类型
    /// </summary>
    public enum FolderEnum : uint
    {
        [Description("终端")]
        Terminal = 0,
        [Description("配件")]
        Part = 1,
        [Description("插件")]
        Plugin = 2,
        [Description("版本")]
        Version = 3
    }
}