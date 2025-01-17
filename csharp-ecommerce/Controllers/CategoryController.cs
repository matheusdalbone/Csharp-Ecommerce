using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;
using csharp_ecommerce.Services.Category;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("find-category-by-id/{categoryId}")]
        public async Task<ActionResult<ResponseModel<CategoryModel>>> FindCategoryById(int categoryId)
        {
            var category = await _categoryInterface.FindCategoryById(categoryId);

            return Ok(category);
        }

        [HttpDelete("delete-category/{categoryId}")]
        public async Task<ActionResult<ResponseModel<CategoryDTO>>> DeleteCategory(int categoryId)
        { 
            var removedCategory = await _categoryInterface.DeleteCategory(categoryId);

            return Ok(removedCategory);
        }

        [HttpPut("update-category/{categoryId}")]
        public async Task<ActionResult<ResponseModel<CategoryDTO>>> UpdateCategory(int categoryId, CategoryDTO categoryDTO)
        { 
            var updatedCategory = await _categoryInterface.UpdateCategory(categoryId, categoryDTO);

            return Ok(updatedCategory);
        }
    }
}
