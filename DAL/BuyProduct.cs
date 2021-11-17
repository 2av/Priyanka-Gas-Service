using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BuyProduct:Base
    {
        public int ID { get; set; }

        public int? SellerId { get; set; }

        public int? ProductId { get; set; }

        public string ProductName { get; set; }
        public int Quantity{ get; set; }

        public double? ProductPrice { get; set; }
        public int InvoiceNo { get; set; }
    }
}
