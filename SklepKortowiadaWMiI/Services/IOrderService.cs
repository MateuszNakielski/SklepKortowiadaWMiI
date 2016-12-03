using SklepKortowiadaWMiI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepKortowiadaWMiI.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOneOrderById(int id);
        Order AddOrder(Order o);
        Order DeleteOrderById(int id);
        Order UpdateOrderById(int id, Order o);
        Order AddOrderDetail(int orderId, OrderDetail od);
        Order DeleteOrderDetailByNumber(int orderId, int n);
        Order GetOneOrderByBarCode(string b);
        void ClearOrderDetail(int id);
    }
}
