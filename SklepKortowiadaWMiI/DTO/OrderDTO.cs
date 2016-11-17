using SklepKortowiadaWMiI.Models;
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
        public IEnumerable<OrderDetailDTO> Details { get; set; }

        public static OrderDTO ToOrderDTO(Order o)
        {
            SklepKortowiadaWMiIContext db = new SklepKortowiadaWMiIContext();
            List<OrderDetailDTO> orderDetails = db.OrderDetails.AsEnumerable<OrderDetail>().Select(p => OrderDetailDTO.ToOrderDetailDTO(p)).Where(p => p.Id == o.Id).AsEnumerable<OrderDetailDTO>().ToList();
            return new OrderDTO()
            {
                Id = o.Id,
                Barcode = o.Barcode,
                Details = orderDetails,
                Faculty = o.Faculty,
                Mode = o.Mode,
                Name = o.Name,
                Paid = o.Paid,
                Received = o.Received,
                SecondName = o.SecondName,
                StudentNumber = o.StudentNumber
            };
        }

        public static Order FromOrderDTO(OrderDTO o)
        {

            return new Order()
            {
                Barcode = o.Barcode,
                Faculty = o.Faculty,
                Id = o.Id,
                Mode = o.Mode,
                Name = o.Name,
                Paid = o.Paid,
                Received = o.Received,
                SecondName = o.SecondName,
                StudentNumber = o.StudentNumber
            };
        }
    }
}