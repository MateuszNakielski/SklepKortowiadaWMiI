using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SklepKortowiadaWMiI.Models;
using System.Data.Entity;

namespace SklepKortowiadaWMiI.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private SklepKortowiadaWMiIContext db = new SklepKortowiadaWMiIContext();

        public Order AddOrder(Order o)
        {
            db.Orders.Add(o);
            db.SaveChanges();
            return o;
        }

        public Order AddOrderDetail(int orderId, OrderDetail od)
        {
            Order order = db.Orders.Find(orderId);
            if (order == null)
                return null;
            db.OrderDetails.Add(od);
            db.SaveChanges();

            return order;
        }

        public Order DeleteOrderById(int id)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
                return null;
            db.Orders.Remove(order);
            db.SaveChanges();
            return order;
        }

        public Order DeleteOrderDetailByNumber(int orderId, int n, OrderDetail od)
        {
            OrderDetail orderDetail = db.OrderDetails.Where(o => o.OrderId == orderId).Where(o => o.Number == n).Single();
            db.OrderDetails.Remove(orderDetail);
            return db.Orders.Find(orderId);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return db.Orders.AsEnumerable<Order>();
        }

        public Order GetOneOrderById(int id)
        {
            return db.Orders.Find(id);
        }

        public Order UpdateOrderById(int id, Order o)
        {
            Order newOrder = db.Orders.Find(id);
            if (newOrder ==null || newOrder.Id != o.Id)
                return null;
            db.Entry(o).State = EntityState.Modified;
            db.SaveChanges();
            return o;
        }

        public Order GetOneOrderByBarCode(string b)
        {
            return db.Orders.Where(o => o.Barcode.Equals(b)).First();
            
        }
    }
}