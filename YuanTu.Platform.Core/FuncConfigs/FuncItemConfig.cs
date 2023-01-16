using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.FuncConfigs
{
    public enum FuncItemTypes { 
        // 默认文本框
        Text = 0, 
        // 数字控件
        Number = 1, 
        // 单选框
        RadioButton = 2,
        // 多选框
        Checkbox = 2,
        // 下拉框
        Dropdown = 4, 
        // 图片路径
        Image = 5, 
        // 富文本
        Html = 6, 
        // 可视化布局
        Layout = 7 
    }

    /// <summary>
    /// 功能配置项管理
    /// </summary>
    public class FuncItemConfig : ParentCustomEditEntity<string>
    {
        public FuncItemTypes FuncItemType { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }
    }
}