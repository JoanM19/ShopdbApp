using Microsoft.AspNetCore.Mvc;
using PlatformShop.Application.Contracts;
using PlatformShop.Domain.Models.Employees;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopdbApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        public EmployeesApiController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }
        // GET: api/<EmployeesApiController>
        [HttpGet("InsertarCustomer")]
        public async Task<IActionResult> Get()
        {
            var result = await _employeesService.GetAllEmployeesAsync();
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<EmployeesApiController>/5
        [HttpGet("id")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeesApiController>
        [HttpPost("Guardar")]
        public async Task<IActionResult> Post([FromBody] EmployesCreateModel employesCreate)
        {
            var result = await _employeesService.CreateEmployeesAsync(employesCreate);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<EmployeesApiController>/5
        [HttpPut("Actualizar")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeesUpdateModel employeesUpdate)
        {
            var EmployeesUpdate = new EmployeesUpdateModel
            {
                Empid = employeesUpdate.Empid,
                LastName = employeesUpdate.LastName,
                FirstName = employeesUpdate.FirstName,
                Title = employeesUpdate.Title,
                Titleofcourtesy = employeesUpdate.Titleofcourtesy,
                BirthDate = employeesUpdate.BirthDate,
                HireDate = employeesUpdate.HireDate,
                Address = employeesUpdate.Address,
                City = employeesUpdate.City,
                Region = employeesUpdate.Region,
                PostalCode = employeesUpdate.PostalCode,
                Country = employeesUpdate.Country,
                Phone = employeesUpdate.Phone,
                Mgrid = employeesUpdate.Mgrid,
                ModifyDate = employeesUpdate.ModifyDate,
                ModifyUser = employeesUpdate.ModifyUser


            };
            var result = await _employeesService.UpdateEmployeesAsync(id, EmployeesUpdate);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<EmployeesApiController>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id, EmployeesDeleteModel employeesDelete)
        {
            var result = await _employeesService.DeleteEmployeesAsync(id, employeesDelete);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
