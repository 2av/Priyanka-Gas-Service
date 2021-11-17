using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GasMaster:Base
    {
        public int ID { get; set; }

        public string ItemName { get; set; }

        public string ItemWeight { get; set; }

        public double? ItemCharges { get; set; }
        public double? BuyPrice { get; set; }

    }
}
