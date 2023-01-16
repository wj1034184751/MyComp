using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Controllers
{
    public class Install
    {
        public IPAddressInfo Server { get; set; } = new IPAddressInfo();

        public IPAddressInfo DataCenter { get; set; } = new IPAddressInfo();

        public string OrgName { get; set; }

        public string PluginName { get; set; }

        public string PartsName { get; set; }

        public string TerminalType { get; set; }

        public bool IsNotYuantu { get; set; }
    }

    public class IPAddressInfo
    {
        public string IP { get; set; }

        public int Port { get; set; }
    }
}
