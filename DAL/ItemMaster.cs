using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemMaster:Base
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double? Price { get; set; }
        public double? SecurityDeposite { get; set; }
        public double? ServiceCharges { get; set; }

    }
}
