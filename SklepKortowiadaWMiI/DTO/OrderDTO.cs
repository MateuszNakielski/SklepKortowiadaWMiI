using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKortowiadaWMiI.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public bool Paid { get; set; }
        public bool Received { get; set; }
        public String Name { get; set; }
        public String SecondName { get; set; }
        public String StudentNumber { get; set; }
        public String Barcode { get; set; }
        public String Faculty { get; set; }
        public String Mode { get; set; }
        public class Detail
        {
            public int ProductID { get; set; }
            public int Quantity { get; set; }
        }
        public IEnumerable<Detail> Details { get; set; }

        
    }
}