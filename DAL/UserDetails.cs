using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL 
{
    public class UserDetails :Base
    {
        public int ID { get; set; }
        public string UserID { get; set; }

        public string FullName { get; set; }

        public string EmailID { get; set; }

        public string MobileNo { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }
                
    }

}
