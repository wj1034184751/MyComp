using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common;
using System.ComponentModel.DataAnnotations;

namespace YuanTu.Platform.Local
{
    public class FireWall : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 程序名称
        /// </summary>
        [StringLength(32)]
        public string Name { get; set; }
        /// <summary>
        /// 配置文件
        /// </summary>
        [StringLength(32)]
        public string Range { get; set; }
        /// <summary>
        /// 程序路径
        /// </summary>
        [StringLength(128)]
        public string Path { get; set; }
        /// <summary>
        /// 协议
        /// </summary>
        [StringLength(32)]
        public string Deal { get; set; }
        /// <summary>
        /// 本地地址
        /// </summary>
        [StringLength(32)]
        public string LocalAddress { get; set; }
        /// <summary>
        /// 本地端口
        /// </summary>
        [StringLength(32)]
        public string LocalPort { get; set; }
        /// <summary>
        /// 远端地址
        /// </summary>
        [StringLength(32)]
        public string RemoteAddress { get; set; }
        /// <summary>
        /// 远端端口
        /// </summary>
        [StringLength(32)]
        public string RemotePort { get; set; }
        /// <summary>
        /// 规则设置
        /// </summary>
        [StringLength(32)]
        public string Rules { get; set; }
        /// <summary>
        /// 操作选项
        /// </summary>
        public string Operation { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string IsEnable { get; set; }
    }
}
