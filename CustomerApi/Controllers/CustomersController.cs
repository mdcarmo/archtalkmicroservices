using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly List<CustomerDto> customers = null;

        public CustomersController()
        {
            customers = new List<CustomerDto>
            {
                new CustomerDto
                {
                    Id = 1,
                    EnrollmentDate = DateTime.Now,
                    FirstName = "Cristian",
                    LastName = "Owen",
                    Birthdate = new DateTime(1980, 07, 15),
                    LastBuyAt = DateTime.Now.AddMonths(-3)
                },
                new CustomerDto
                {
                    Id = 2,
                    EnrollmentDate = DateTime.Now,
                    FirstName = "John",
                    LastName = "Stuart",
                    Birthdate = new DateTime(1973, 07, 15),
                    LastBuyAt = DateTime.Now.AddMonths(-4)
                }
            };

        }

        [HttpGet("{id:int}")]
        public IActionResult GetCustomers(int id)
        {
            return Ok(customers.FirstOrDefault(x => x.Id == id));
        }
    }
}