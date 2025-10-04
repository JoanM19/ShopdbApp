using Microsoft.AspNetCore.Mvc;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Models.Categories;
using PlatformShop.Domain.Models.Customers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopdbApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        public CustomerApiController(ICustomersService customersService)
        {
            _customersService = customersService;
        }
        // GET: api/<CustomerApiController>
        [HttpGet("InsertarCustomer")]
        public async Task<IActionResult> Get()
        {
            var result = await _customersService.GetAllCustomersAsync();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<CustomerApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerApiController>
        [HttpPost("Guardar")]
        public async Task<IActionResult> Post([FromBody] CustomersCreateModel createModel)
        {
            var result = await _customersService.CreateCustomersAsync(createModel);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<CustomerApiController>/5
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomersUpdateModel updateModel)
        {
            var customersUpdate = new CustomersUpdateModel
            {
                custid = updateModel.custid,
                CompanyName = updateModel.CompanyName,
                ContactName = updateModel.ContactName,
                ContactTitle = updateModel.ContactTitle,
                Email = updateModel.Email,
                Phone = updateModel.Phone,
                Address = updateModel.Address,
                City = updateModel.City,
                Region = updateModel.Region,
                PostalCode = updateModel.PostalCode,
                Country = updateModel.Country,
                Fax = updateModel.Fax,
                Modify_Date = updateModel.Modify_Date,
                Modify_User = updateModel.Modify_User

            };

            var result = await _customersService.UpdateCustomersAsync(id, customersUpdate);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<CustomerApiController>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id, CustomersDeleteModel customersDelete)
        {
            var result = await _customersService.DeleteCustomersAsync(id, customersDelete);


            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
