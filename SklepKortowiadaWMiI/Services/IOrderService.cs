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
        IEnumerable<Order> GetAllOrders();                      //Pobranie wszystkich zamowien
        Order GetOneOrderById(int id);                          //Pobranie jednego zamiowienia wg identyfikatora
        Order AddOrder(Order o);                                //Dodanie zamówienia
        Order DeleteOrderById(int id);                          //Usunięcie zamówienia wg identyfikatora
        Order UpdateOrderById(int id, Order o);                 //Aktualizacja zamówienia wg identyfikatora
        Order AddOrderDetail(int orderId, OrderDetail od);      //Dodanie elementu zamówienia
        Order DeleteOrderDetailByNumber(int orderId, int n);    //Usunięcie elementu zamówienia wg identyfikatora zamówienia i numeru elementu zamówienia
        Order GetOneOrderByBarCode(string b);                   //Pobranie jednego zamówienia wg kodu kreskowego
        IEnumerable<OrderDetail> GetOrderDetailsById(int id);   //Pobranie listy elementów zamowienia danego zamówienia wg identyfikatora
        void ClearOrderDetail(int id);                          //Czyszczenie listy elementów zamówienia wg identyfikatora
    }
}
