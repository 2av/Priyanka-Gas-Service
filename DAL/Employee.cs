using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Employee:Base
    {
        public int Employeeid { get; set; }

        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Mobileno { get; set; }

        public string AlternateNo { get; set; }

        public string Address { get; set; }

        public DateTime? DateOfJoining { get; set; }

        public string Position { get; set; }

        public string ProfileImage { get; set; }

        public int? GasCompanyTypeId { get; set; }
        public bool IsGasDeliveryMan { get; set; }
        
    }

   
}
