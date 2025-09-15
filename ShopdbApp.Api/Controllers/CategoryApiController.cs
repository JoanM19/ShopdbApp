using Microsoft.AspNetCore.Mvc;
using PlatformShop.Domain.Repositories;
using PlatformShop.Application.Contracts;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PlatformShop.Domain.Models.Categories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopdbApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryApiController : ControllerBase
    {
        private readonly ICategoryService _categoriesService;
        public CategoryApiController(ICategoryService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // GET: api/<CategoryController>
        [HttpGet("InsertarCategoria")]
        public async Task<IActionResult> Get()
        {
            // Map CategoriesCreateModel to CategoriesGetModel before passing it to the service

            var result = await _categoriesService.GetAllCategoriesAsync();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("id")]
        public void Get(int id)
        {

        }

        // Updated the method to fix the type mismatch issue in the CreateCategoriesAsync call.
        [HttpPost("Guardar")]
        public async Task<IActionResult> Post([FromBody] CategoriesCreateModel createModel)
        {
            
            // Updated to pass the correct type (CategoriesGetModel) to CreateCategoriesAsync
            var result = await _categoriesService.CreateCategoriesAsync(createModel);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // Updated the method to fix the type mismatch issue in the UpdateCategoriesAsync call.
        [HttpPost("Actualizar")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoriesUpdateModel categoriesUpdate)
        {
            // Map CategoriesUpdateModel to CategoriesGetModel before passing it to the service

            var categoryGetModel = new CategoriesUpdateModel
            {
                CategoryID = categoriesUpdate.CategoryID,
                CategoryName = categoriesUpdate.CategoryName,
                Description = categoriesUpdate.Description,
                Modified_Date = categoriesUpdate.Modified_Date,
                Modified_User = categoriesUpdate.Modified_User
            };
            var result = await _categoriesService.UpdateCategoriesAsync(id, categoryGetModel);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id, CategoriesDeleteModel categoriesDelete)
        {
            var result = await _categoriesService.DeleteCategoriesAsync(id, categoriesDelete);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
