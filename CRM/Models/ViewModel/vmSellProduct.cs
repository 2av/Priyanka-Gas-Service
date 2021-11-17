using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models.ViewModel
{
    public class vmSellProduct
    {
        public int? ConsumerNo { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public double? Total { get; set; }
        public string CreatedDate { get; set; }
        public int InvoiceNo { get; set; }
        public List<vmSellProductItems> SellProductItems { get; set; }
    }
    public class vmSellProductItems
    {


        public int? ProductId { get; set; }

        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public double? ProductPrice { get; set; }
        public string GroupId { get; set; }
    }
}