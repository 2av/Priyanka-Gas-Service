using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GasStock:Base
    {
        public int GasStockId { get; set; }

        public string EntryType { get; set; }

        public string EntryFor { get; set; }

        public int? EntryForId { get; set; }

        public int? _10KG { get; set; }

        public int? _15KG { get; set; }

        public int? _17KG { get; set; }

        public int? _19KG { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }


    }

    public class vmGasStockDetails
    {
        public int EntryForId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobileno { get; set; }
        public string AlternateNo { get; set; }
        public int Record { get; set; }

    }
}
