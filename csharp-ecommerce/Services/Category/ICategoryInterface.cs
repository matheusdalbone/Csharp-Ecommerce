using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;

namespace csharp_ecommerce.Services.Category
{
    public interface ICategoryInterface
    {
        Task<ResponseModel<List<CategoryModel>>> FindAllCategories();
        Task<ResponseModel<CategoryModel>> FindById(int categoryId);
        Task<ResponseModel<CategoryDTO>> CreateCategory(CategoryDTO categoryDTO);    
    }
}
