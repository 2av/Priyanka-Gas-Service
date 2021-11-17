using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Enquiry : Base
    {
        public long EnquiryId { get; set; }

        public long? StudentId { get; set; }

        public int? EnquirySourceId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string MobileNo { get; set; }

        public string EmailId { get; set; }

        public string FatherName { get; set; }

        public string HusbandName { get; set; }

        public string CourseIntrested { get; set; }

        public string CourseIntrestedId { get; set; }

        public long? CourseFeesOffer { get; set; }

        public long? Discount { get; set; }

        public long? CompanyId { get; set; }

        public long? BranchId { get; set; }

        public string Address { get; set; }

        public string Pincode { get; set; }



    }
}
