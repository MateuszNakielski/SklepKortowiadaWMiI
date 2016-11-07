using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SklepKortowiadaWMiI.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}