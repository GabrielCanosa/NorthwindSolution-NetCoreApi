using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerLogic _customerLogic;
        public CustomerController(ICustomerLogic customerLogic)
        {
            _customerLogic = customerLogic;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerLogic.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_customerLogic.GetById(id));
        }

        [HttpGet]
        [Route("GetPaginatedCustomer/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedCustomer(int page, int rows)
        {
            return Ok(_customerLogic.CustomerPagedList(page, rows));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_customerLogic.Insert(customer));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Customer customer)
        {
            if (!ModelState.IsValid && _customerLogic.Update(customer))
            {
                return Ok(new { Message = "The customer was updated" });
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Customer customer)
        {
            if (customer.Id > 0)
            {
                return Ok(_customerLogic.Delete(customer));
            }

            return BadRequest();
        }
    }
}
