using System.Text.Json.Serialization;

namespace csharp_ecommerce.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public List<ProductModel> Products { get; set; }
    }
}
