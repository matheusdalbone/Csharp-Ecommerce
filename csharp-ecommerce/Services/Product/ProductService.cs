using csharp_ecommerce.Data;
using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;
using Microsoft.EntityFrameworkCore;


namespace csharp_ecommerce.Services.Product
{
    public class ProductService : IProductInterface
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ProductDTO>> CreateProduct(ProductDTO productDTO)
        {
            ResponseModel<ProductDTO> response = new ResponseModel<ProductDTO>();

            try
            {
                var product = new ProductModel()
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Price = productDTO.Price,
                    Stock = productDTO.Stock,
                    CategoryId = productDTO.CategoryId,
                    ImageUrl = productDTO.ImageUrl
                };

                _context.Add(product);
                await _context.SaveChangesAsync();

                response.Value = productDTO;
                response.Message = "Product create successfuly";
                response.IsError = false;

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsError = true;
                response.Value = null;

                return response;
            }
        }

        public async Task<ResponseModel<List<ProductModel>>> FindAllProducts()
        {
            ResponseModel<List<ProductModel>> response = new ResponseModel<List<ProductModel>>();

            try
            {
                var products = await _context.Products.Include(p => p.Category).ToListAsync();

                response.Value = products;
                response.Message = "Success";
                response.IsError = false;

                return response;
            }
            catch (Exception ex)
            {
                response.Value = null;
                response.Message = ex.Message;
                response.IsError = true;

                return response;
            }
        }

        public async Task<ResponseModel<ProductModel>> FindProductById(int productId)
        {
            ResponseModel<ProductModel> response = new ResponseModel<ProductModel>();

            try
            {
                var product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == productId);

                response.Value = product;
                response.Message = "Successful";
                response.IsError = false;

                return response;
            }
            catch (Exception ex)
            {
                response.Value = null;
                response.Message = ex.Message;
                response.IsError = true;

                return response;
            }
            
        }

        public async Task<ResponseModel<ProductDTO>> UpdateProduct(int productId, ProductDTO productDTO)
        { 
            ResponseModel<ProductDTO> response = new ResponseModel<ProductDTO>();

            try
            {
                var dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

                dbProduct.Price = productDTO.Price;
                dbProduct.Stock = productDTO.Stock;
                dbProduct.Name = productDTO.Name;
                dbProduct.Description = productDTO.Description;
                dbProduct.CategoryId = productDTO.CategoryId;
                dbProduct.ImageUrl = productDTO.ImageUrl;

                await _context.SaveChangesAsync();

                response.Value = productDTO;
                response.Message = "Product updated successfuly";
                response.IsError = false;

                return response;
            }
            catch (Exception ex)
            { 
                response.Value = null;
                response.Message = ex.Message;
                response.IsError = true;

                return response;
            }
        }

        public async Task<ResponseModel<ProductDTO>> DeleteProduct(int productId)
        {
            ResponseModel<ProductDTO> response = new ResponseModel<ProductDTO>();

            try
            {
                var dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

                _context.Remove(dbProduct);
                await _context.SaveChangesAsync();

                response.Value = null;
                response.Message = $"Product id: {dbProduct.Id}, Name: {dbProduct.Name} removed successfuly";
                response.IsError = false;

                return response;
            }
            catch (Exception ex)
            {
                response.Value = null;
                response.Message = ex.Message;
                response.IsError = true;

                return response;
            }

        }
    }
}
