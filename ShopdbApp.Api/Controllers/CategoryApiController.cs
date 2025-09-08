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
            var result = await _categoriesService.GetAllCategoriesAsync();
            
            if(!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("")]
        public void  Get(int id)
        {

        }

        // Updated the method to fix the type mismatch issue in the CreateCategoriesAsync call.
        [HttpPost("Guardar")]
        public async Task<IActionResult> Post([FromBody] CategoriesCreateModel createcategory)
        {
            // Map CategoriesCreateModel to CategoriesGetModel before passing it to the service
            var categoryGetModel = new CategoriesGetModel
            {
                CategoryName = createcategory.CategoryName,
                Description = createcategory.Description
            };

            var result = await _categoriesService.CreateCategoriesAsync(categoryGetModel);

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
            var categoryGetModel = new CategoriesGetModel
            {
                CategoryName = categoriesUpdate.CategoryName,
                Description = categoriesUpdate.Description
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
        public void Delete(int id)
        {
        }
    }
}
