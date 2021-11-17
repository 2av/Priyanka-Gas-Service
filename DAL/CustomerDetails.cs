using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDetails:Base
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
        public string FromDate { get; set; }
        public string ToDate { get; set; }

    }
}
