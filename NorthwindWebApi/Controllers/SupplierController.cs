using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Northwind.BusinessLogic.Interfaces;

namespace NorthwindWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierLogic _supplierLogic;

        public SupplierController(ISupplierLogic supplierLogic)
        {
            _supplierLogic = supplierLogic;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_supplierLogic.GetById(id));
        }

        [HttpGet]
        [Route("GetPaginatedSupplier/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedSupplier(int page, int rows)
        {
            return Ok(_supplierLogic.SupplierPagedList(page, rows));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Supplier Supplier)
        {
            if (!ModelState.IsValid) return BadRequest();

            return Ok(_supplierLogic.Insert(Supplier));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Supplier Supplier)
        {
            if (!ModelState.IsValid && _supplierLogic.Update(Supplier))
            {
                return Ok(new { Message = "The Supplier was updated" });
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Supplier Supplier)
        {
            if (Supplier.Id > 0)
            {
                return Ok(_supplierLogic.Delete(Supplier));
            }

            return BadRequest();
        }
    }
}
