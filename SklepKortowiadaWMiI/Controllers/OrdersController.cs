﻿using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.DTO;
using System.Collections.Generic;
using SklepKortowiadaWMiI.Services;

namespace SklepKortowiadaWMiI.Controllers
{
    //Kontroler REST zamowien
    // dostep: /api/Orders
    public class OrdersController : ApiController
    {
        IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        //Pobranie wszystkich zamowien (metoda get)
        public IEnumerable<OrderDTO> GetOrders()
        {
            return orderService.GetAllOrders().Select(o => OrderDTO.ToOrderDTO(o));
        }

        //Pobranie zamowienia wg id
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult GetOrder(int id)
        {
            Order order = orderService.GetOneOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(OrderDTO.ToOrderDTO(order));
        }

        //Aktualizacja zamowienia wg id
        [Route("api/Orders/{id}")]
        [HttpPut]
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult PutOrder(int id, OrderDTO o)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = orderService.UpdateOrderById(id, OrderDTO.FromOrderDTO(o));
            if (order == null)
                return BadRequest();
            return Ok(OrderDTO.ToOrderDTO(order));
        }

        //Dodanie zamowienia
        // POST: api/Orders1
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult PostOrder(OrderDTO o)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = orderService.AddOrder(OrderDTO.FromOrderDTO(o));
            return Ok(OrderDTO.ToOrderDTO(order));
        }

        //Dodanie elementu do zamowienia wg id
        [Route("api/Orders/{id}")]
        [HttpPost]
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult AddOrderDetail(int id, OrderDetailDTO orderDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = orderService.AddOrderDetail(id, OrderDetailDTO.FromOrderDetailDTO(orderDetailDTO, id));
            return Ok(OrderDTO.ToOrderDTO(order));
        }

        //Usuniecie zamowienia wg id
        [HttpDelete]
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = orderService.DeleteOrderById(id);
            if (order == null)
                return NotFound();
            return Ok(OrderDTO.ToOrderDTO(order));
        }

        //Pobranie zamowienia wg kodu kreskowego
        [Route("api/Orders/{barCode}")]
        [HttpGet]
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult GetOrderByBarCode(string barCode)
        {
            Order order = orderService.GetOneOrderByBarCode(barCode);
            if (order == null)
                return NotFound();
            return Ok(OrderDTO.ToOrderDTO(order));
        }

        //Usuniecie elementu wg numeru z zamowienia wg id
        [Route("api/Orders/{id}")]
        [HttpDelete]
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult DeleteDetailOrder(int id, int number)
        {
            Order order = orderService.DeleteOrderDetailByNumber(id, number);
            return Ok(OrderDTO.ToOrderDTO(order));
        }

    }
}