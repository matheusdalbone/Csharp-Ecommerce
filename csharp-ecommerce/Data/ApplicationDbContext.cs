using csharp_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_ecommerce.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
