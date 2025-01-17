using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;

namespace csharp_ecommerce.Services.Product
{
    public interface IProductInterface
    {
        Task<ResponseModel<List<ProductModel>>> FindAllProducts();
        Task<ResponseModel<ProductModel>> FindProductById(int productId);
        Task<ResponseModel<ProductDTO>> CreateProduct(ProductDTO productDTO);
        Task<ResponseModel<ProductDTO>> UpdateProduct(int productId, ProductDTO productDTO);
        Task<ResponseModel<ProductDTO>> DeleteProduct(int productId);

    }
}
