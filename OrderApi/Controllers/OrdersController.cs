using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Model;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly List<OrderDto> orders = null;

        public OrdersController()
        {
            orders = new List<OrderDto>
            {
                new OrderDto
                {
                    Id = Guid.NewGuid(),
                    CustomerId = 1,
                    DateCreated = DateTime.Now,
                    Total = 1500.00m,
                    TotalItems = 3
                },
                new OrderDto
                {
                    Id = Guid.NewGuid(),
                    CustomerId = 1,
                    DateCreated = DateTime.Now,
                    Total = 2030,
                    TotalItems = 7
                },
                new OrderDto
                {
                    Id = Guid.NewGuid(),
                    CustomerId = 2,
                    DateCreated = DateTime.Now,
                    Total = 870,
                    TotalItems = 4
                }
            };
        }

        [HttpGet("customer/{id:int}")]
        public IActionResult GetOrdersByCustomerId(int id)
        {
            return Ok(orders.Where(x => x.CustomerId == id).ToList());
        }
    }
}