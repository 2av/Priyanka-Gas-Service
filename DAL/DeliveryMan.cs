using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DeliveryMan:Base
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNo { get; set; }

        public string Address { get; set; }

        public string Qualification { get; set; }

        public string PanCardNo { get; set; }

        public string AdharCardNO { get; set; }

        public int? Age { get; set; }

        public double? Salary { get; set; }

    }



}
