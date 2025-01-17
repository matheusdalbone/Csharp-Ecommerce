using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;
using csharp_ecommerce.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace csharp_ecommerce.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductInterface _productInterface;

        public ProductController(IProductInterface productInterface)
        { 
            _productInterface = productInterface;
        }

        [HttpPost("/create-product")]
        public async Task<ActionResult<ResponseModel<ProductDTO>>> CreateUser(ProductDTO productDTO)
        {
            var product = await _productInterface.CreateProduct(productDTO);

            return Ok(product);
        }

        [HttpGet("/find-all-products")]
        public async Task<ActionResult<ResponseModel<List<ProductModel>>>> FindAllProducts()
        {
            var products = await _productInterface.FindAllProducts();

            return Ok(products);
        }

        [HttpGet("/find-product-by-id/{productId}")]
        public async Task<ActionResult<ResponseModel<ProductModel>>> FindProductById(int productId)
        {
            var product = await _productInterface.FindProductById(productId);

            return Ok(product);
        }

        [HttpDelete("/delete-product/{productId}")]
        public async Task<ActionResult<ResponseModel<ProductDTO>>> DeleteProduct(int productId)
        { 
            var removedProduct = await _productInterface.DeleteProduct(productId);

            return Ok(removedProduct);
        }

        [HttpPut("/update-product/{productId}")]
        public async Task<ActionResult<ResponseModel<ProductDTO>>> UpdateProduct(int productId, ProductDTO productDTO)
        {
            var updatedProduct = await _productInterface.UpdateProduct(productId, productDTO);

            return Ok(updatedProduct);
        }
    }
}
