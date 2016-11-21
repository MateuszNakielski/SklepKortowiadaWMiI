using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SklepKortowiadaWMiI.Models;
using SklepKortowiadaWMiI.DTO;
using System.Collections.Generic;
using SklepKortowiadaWMiI.Services;

namespace SklepKortowiadaWMiI.Controllers
{
    public class OrdersController : ApiController
    {
        IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            return orderService.GetAllOrders().Select(o => OrderDTO.ToOrderDTO(o));
        }

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
        [Route("api/Orders/{id}")]
        [HttpPost]
        [ResponseType(typeof(int))]
        public IHttpActionResult AddOrderDetail(int id, OrderDetailDTO orderDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = orderService.AddOrderDetail(id, OrderDetailDTO.FromOrderDetailDTO(orderDetailDTO, id));
            return Ok(OrderDTO.ToOrderDTO(order));
        }

        // DELETE: api/Orders1/5
        [ResponseType(typeof(Order))]
        public IHttpActionResult DeleteOrder(int id)
        {
            Order order = orderService.DeleteOrderById(id);
            if (order == null)
                return NotFound();
            return Ok(OrderDTO.ToOrderDTO(order));
        }
    }
}