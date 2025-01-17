using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;
using System.Reflection;

namespace csharp_ecommerce.Services.Category
{
    public interface ICategoryInterface
    {
        Task<ResponseModel<List<CategoryModel>>> FindAllCategories();
        Task<ResponseModel<CategoryModel>> FindCategoryById(int categoryId);
        Task<ResponseModel<CategoryDTO>> CreateCategory(CategoryDTO categoryDTO);
        Task<ResponseModel<CategoryDTO>> UpdateCategory(int categoryId, CategoryDTO categoryDTO);
        Task<ResponseModel<CategoryDTO>> DeleteCategory(int categoryId);
    }
}
