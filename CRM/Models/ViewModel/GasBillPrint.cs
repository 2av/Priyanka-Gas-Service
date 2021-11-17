using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models.ViewModel
{
    public class GasBillPrint
    {
        public string CustomerNo { get; set; }
        public string OrderNo { get; set; }
        public string Name { get; set; }
        public string MemoNo { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string MemoDate { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryMan { get; set; }
        public string CompanyName { get; set; }
        public string BookingDate { get; set; }
        public string BillPrinted { get; set; }
        public string ItemCharges { get; set; }
        public string ItemWeight { get; set; }
        public string Quantity { get; set; }
        public string TotalCharge { get; set; }

    }
}