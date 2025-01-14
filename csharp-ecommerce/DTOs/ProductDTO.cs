using csharp_ecommerce.Models;

namespace csharp_ecommerce.DTOs
{
    public record ProductDTO(int Id, string Name, string Description, decimal Price, int Stock, int CategoryId, CategoryModel Category, string ImageUrl)
    {
    }
}
