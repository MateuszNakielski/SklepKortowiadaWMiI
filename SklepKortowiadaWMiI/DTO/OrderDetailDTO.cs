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

        public static OrderDetail FromOrderDetailDTO(OrderDetailDTO o)
        {
            SklepKortowiadaWMiIContext db = new SklepKortowiadaWMiIContext();

            return new OrderDetail()
            {
                OrderId = o.OrderId,
                ProductId = o.ProductId,
                Quantity = o.Quantity,
                Order = db.Orders.Find(o.OrderId),
                Product = db.Products.Find(o.ProductId),
                Number = o.Number,
                Id = o.Id
            };
        }
    }
}