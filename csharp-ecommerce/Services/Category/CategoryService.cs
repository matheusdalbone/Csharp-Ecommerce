using csharp_ecommerce.Data;
using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace csharp_ecommerce.Services.Category
{
    public class CategoryService : ICategoryInterface
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<CategoryDTO>> CreateCategory(CategoryDTO categoryDTO)
        {
            ResponseModel<CategoryDTO> response = new ResponseModel<CategoryDTO>();

            try
            {
                var newCategory = new CategoryModel()
                {
                    Name = categoryDTO.Name,
                    Description = categoryDTO.Description,
                    Products = []
                };

                _context.Add(newCategory);
                await _context.SaveChangesAsync();

                response.Value = categoryDTO;
                response.Message = "Category successfuly created";
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

        public async Task<ResponseModel<List<CategoryModel>>> FindAllCategories()
        {
            ResponseModel<List<CategoryModel>> response = new ResponseModel<List<CategoryModel>>();

            try
            {
                var categories = _context.Categories.ToList();

                response.Value = categories;
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

        public async Task<ResponseModel<CategoryModel>> FindCategoryById(int categoryId)
        {
            ResponseModel<CategoryModel> response = new ResponseModel<CategoryModel>();

            try
            {
                var category =  _context.Categories.FirstOrDefault(c => c.Id == categoryId);

                response.Value = category;
                response.Message = "Category found successfuly";
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
        public async Task<ResponseModel<CategoryDTO>> DeleteCategory(int categoryId)
        {
            ResponseModel<CategoryDTO> response = new ResponseModel<CategoryDTO>();

            try
            {
                var dbCategory = _context.Categories.FirstOrDefault(c => c.Id == categoryId);

                _context.Remove(dbCategory);
                await _context.SaveChangesAsync();

                response.Value = null;
                response.Message = $"Category: {dbCategory.Id}, Name: {dbCategory.Name} removed successfuly";
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

        public async Task<ResponseModel<CategoryDTO>> UpdateCategory(int categoryId, CategoryDTO categoryDTO)
        {
            ResponseModel<CategoryDTO> response = new ResponseModel<CategoryDTO>();

            try
            {
                var dbCategory = _context.Categories.FirstOrDefault(c => c.Id == categoryId);

                dbCategory.Name = categoryDTO.Name;
                dbCategory.Description = categoryDTO.Description;

                await _context.SaveChangesAsync();

                response.Value = categoryDTO;
                response.Message = "Category updated successfuly";
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
