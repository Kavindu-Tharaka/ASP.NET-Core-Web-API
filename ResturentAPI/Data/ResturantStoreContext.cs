using Microsoft.EntityFrameworkCore;

namespace ResturentAPI.Data
{
    public class ResturantStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Resturant> Resturants { get; set; }


        public ResturantStoreContext(DbContextOptions<ResturantStoreContext> options) : base(options)
        {

        }
    }
}
