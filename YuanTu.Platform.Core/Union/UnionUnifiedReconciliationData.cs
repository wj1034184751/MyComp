using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Union
{
    public class UnionUnifiedReconciliationData : CustomEntityWithOrg<string>
    {
        public string BankType { get; set; }

        public string MerchantId { get; set; }

        public string HospitalId { get; set; }

        public string HospitalName { get; set; }

        public int TotalAmount { get; set; }

        public DateTime DataTime { get; set; }

        public int OrdersCount { get; set; }

        public int ReconciliationType { get; set; }

        public int OptType { get; set; }

    }
}