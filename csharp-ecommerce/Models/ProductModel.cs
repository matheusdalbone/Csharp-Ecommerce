using System.ComponentModel.DataAnnotations.Schema;

namespace csharp_ecommerce.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description{ get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
