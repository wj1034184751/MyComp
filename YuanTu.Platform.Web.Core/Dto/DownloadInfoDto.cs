using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Dto
{
    public class DownloadInfoDto
    {
        public string Server { get; set; }

        public int ServerPort { get; set; }

        public string Datacenter { get; set; }

        public int CenterPort { get; set; }

        public string OrgName { get; set; }

        public string PluginName { get; set; }

        public string PartsName { get; set; }

        public string TerminalType { get; set; }

        public bool IsNotYuantu { get; set; }

        public bool IsOffline { get; set; }

        public string System { get; set; }

        public string Framework { get; set; }
    }
}