using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;
using csharp_ecommerce.Services.Category;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace csharp_ecommerce.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryInterface _categoryInterface;
        public CategoryController(ICategoryInterface categoryInterface)
        {
            _categoryInterface = categoryInterface;
        }

        [HttpPost("create-category")]
        public async Task<ActionResult<ResponseModel<CategoryDTO>>> CreateCategory(CategoryDTO categoryDTO)
        { 
            var category = await _categoryInterface.CreateCategory(categoryDTO);
            return Ok(category);
        }

        [HttpGet("get-all-categories")]
        public async Task<ActionResult<ResponseModel<List<CategoryModel>>>> FindAllCategories()
        {
            var categories = await _categoryInterface.FindAllCategories();
            
            return Ok(categories);
        }
    }
}
