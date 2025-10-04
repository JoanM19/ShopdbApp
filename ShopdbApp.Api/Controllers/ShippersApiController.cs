using Microsoft.AspNetCore.Mvc;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Models.Shippers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopdbApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersApiController : ControllerBase
    {
        private readonly IShippersService _shippersService;
        public ShippersApiController(IShippersService shippersService)
        {
            _shippersService = shippersService;
        }
        // GET: api/<ShippersApiController>
        [HttpGet("InsertarCustomer")]
        public async Task<IActionResult> Get()
        {
            var result = await _shippersService.GetAllShippersAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<ShippersApiController>/5
        [HttpGet("{id}")]
        public string  Get(int id)
        {
            return "value";
        }

        // POST api/<ShippersApiController>
        [HttpPost("Guardar")]
        public async Task<IActionResult> Post([FromBody] ShippersCreateModel shippersCreate)
        {
            var result = await _shippersService.CreateShipperAsync(shippersCreate);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<ShippersApiController>/5
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Put(int id, [FromBody] ShippersUpdateModel shippersUpdate)
        {
            var shippersUpdateModel = new ShippersUpdateModel
            {
                Shipperid = shippersUpdate.Shipperid,
                Name = shippersUpdate.Name,
                Phone = shippersUpdate.Phone,
                Address = shippersUpdate.Address,
                City = shippersUpdate.City,
                Region = shippersUpdate.Region,
                Postalcode = shippersUpdate.Postalcode,
                Country = shippersUpdate.Country,
                ModifyUser = shippersUpdate.ModifyUser
            };
            var result = await _shippersService.UpdateShipperAsync(id, shippersUpdateModel);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<ShippersApiController>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id, ShippersDeleteModel shippersDelete)
        {
            var result = await _shippersService.DeleteShipperAsync(id, shippersDelete);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
    }
}
