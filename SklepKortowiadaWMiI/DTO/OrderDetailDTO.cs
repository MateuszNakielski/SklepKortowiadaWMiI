using SklepKortowiadaWMiI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SklepKortowiadaWMiI.DTO
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Number { get; set; }

        public static OrderDetailDTO ToOrderDetailDTO(OrderDetail o)
        {
            return new OrderDetailDTO()
            {
                OrderId = o.OrderId,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                Number = o.Number,
                Id = o.Id 
            };
        }

        public static OrderDetail FromOrderDetailDTO(OrderDetailDTO o, int orderId)
        {
            SklepKortowiadaWMiIContext db = new SklepKortowiadaWMiIContext();

            return new OrderDetail()
            {
                Quantity = o.Quantity,
                Number = o.Number,
                ProductId = o.ProductId,
                OrderId = orderId,
                Id = o.Id
            };
        }
    }
}