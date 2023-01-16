using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.StFuncConfigs
{
    /// <summary>
    /// 功能配置项管理
    /// </summary>
    public class StFuncItemConfig : ParentCustomEditEntity<string>
    {
        public ComponentTypes ComponentType { get; set; }

        public string Value { get; set; }

        public string Name { get; set; }
    }
}