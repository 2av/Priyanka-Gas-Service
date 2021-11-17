using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewConnectionItems:Base
    {
        public int ID { get; set; }

        public string ConsumerNo { get; set; }

        public int? ItemNo { get; set; }

        public string ItemDescription { get; set; }

        public double? SecurityDeposit { get; set; }

        public double? ServiceCharges { get; set; }

        public double? Total { get; set; }

        public int? Qty { get; set; }

        public double? TotalAmount { get; set; }

    }
}
