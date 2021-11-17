using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
namespace CRM.Models.ViewModel
{
    public class vmItemMaster
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public double? Price { get; set; }
        public double? SecurityDeposite { get; set; }
        public double? ServiceCharges { get; set; }
        public int Qty { get; set; }
        public double? Total { get; set; }

    }
    public class vmCustomerDetailsItem
    {
        public int ID { get; set; }
        public string ConsumerNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
        public string AreaCode { get; set; }

        public string PhoneNo { get; set; }
        public string AlternateNo { get; set; }
        public string CustomerType { get; set; }
        public string CreatedDate { get; set; }
        public List<vmItemMaster> ItemMaster { get; set; }
        
    }
   
}