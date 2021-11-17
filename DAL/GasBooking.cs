using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GasBooking : Base
    {
        public int ID { get; set; }

        public string ConsumerNo { get; set; }

        public int? GasItemId { get; set; }

        public double? ItemCharges { get; set; }
        public int? DeliveryManId { get; set; }
        public int? PaymentId { get; set; }
        public int? GasCompanyTypeId { get; set; }
        public bool IsPrint { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string PrintId { get; set; }
        public int? Quantity { get; set; }
        
    }

    public class BookingHistory
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string ItemWeight { get; set; }
        public string ItemCharges { get; set; }
        public string BookingDate { get; set; }
        public string Quantity { get; set; }
        public string TotalCharges { get; set; }
        public string CompanyName { get; set; }
    }


}
