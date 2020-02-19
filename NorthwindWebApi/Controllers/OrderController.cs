using Microsoft.AspNetCore.Mvc;
using Northwind.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderLogic _orderLogic;
        public OrderController(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
        }

        [HttpGet]
        [Route("GetPaginatedOrders/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedOrders(int page, int rows)
        {
            return Ok(_orderLogic.getPaginatedOrder(page, rows));
        }

        [HttpGet]
        [Route("GetOrderById/{orderId:int}")]
        public IActionResult GetOrderById(int orderId)
        {
            return Ok(_orderLogic.getOrderById(orderId));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var request = _orderLogic.getOrderById(id);
            return Ok(_orderLogic.Delete(request));
        }
    }
}
