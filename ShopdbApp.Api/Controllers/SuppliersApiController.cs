using Microsoft.AspNetCore.Mvc;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Models.Suppliers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopdbApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersApiController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SuppliersApiController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        // GET: api/<SuppliersApiController>
        [HttpGet("InsertarCustomer")]
        public async Task<IActionResult> Get()
        {
            var result = await _supplierService.GetAllSuppliersAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

        // GET api/<SuppliersApiController>/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SuppliersApiController>
        [HttpPost("Guardar")]
        public async Task<IActionResult> Post([FromBody] SuppliersCreateModel suppliersCreate)
        {
            var result = await _supplierService.CreateSupplierAsync(suppliersCreate);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<SuppliersApiController>/5
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Put(int id, [FromBody]SuppliersUpdateModel suppliersUpdate)
        {
            var suppliersUpdateModel = new SuppliersUpdateModel
            {
                Supplierid = suppliersUpdate.Supplierid,
                CompanyName = suppliersUpdate.CompanyName,
                ContactName = suppliersUpdate.ContactName,
                ContactTitle = suppliersUpdate.ContactTitle,
                Address = suppliersUpdate.Address,
                City = suppliersUpdate.City,
                Region = suppliersUpdate.Region,
                PostalCode = suppliersUpdate.PostalCode,
                Country = suppliersUpdate.Country,
                Phone = suppliersUpdate.Phone,
                Fax = suppliersUpdate.Fax,
                ModifyUser = suppliersUpdate.ModifyUser
            };
            var result = await _supplierService.UpdateSupplierAsync(id, suppliersUpdateModel);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<SuppliersApiController>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id, SuppliersDeleteModel suppliersDelete)
        {
            var result = await _supplierService.DeleteSupplierAsync(id, suppliersDelete);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
