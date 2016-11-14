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
            List<OrderDetailDTO> orderDetails = new List<OrderDetailDTO>();

            foreach (OrderDetail od in o.OrderDetails)
                orderDetails.Add(OrderDetailDTO.ToOrderDetailDTO(od));
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
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            foreach (OrderDetailDTO od in o.Details)
                orderDetails.Add(OrderDetailDTO.FromOrderDetailDTO(od));

            return new Order()
            {
                Barcode = o.Barcode,
                Faculty = o.Faculty,
                Id = o.Id,
                Mode = o.Mode,
                Name = o.Name,
                OrderDetails = orderDetails,
                Paid = o.Paid,
                Received = o.Received,
                SecondName = o.SecondName,
                StudentNumber = o.StudentNumber
            };
        }
    }
}