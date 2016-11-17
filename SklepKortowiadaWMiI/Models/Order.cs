using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepKortowiadaWMiI.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [DefaultValue("false")]
        public bool Paid { get; set; }
        [DefaultValue("false")]
        public bool Received { get; set; }
        public String Name { get; set; }
        public String SecondName { get; set; }
        public String StudentNumber { get; set; }
        public String Barcode { get; set; }
        public String Faculty { get; set; }
        public String Mode { get; set; }
    }
}