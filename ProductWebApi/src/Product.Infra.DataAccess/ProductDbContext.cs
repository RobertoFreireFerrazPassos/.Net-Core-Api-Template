using Microsoft.EntityFrameworkCore;

namespace Product.Infra.DataAccess
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Domain.Entities.Product> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options): base(options) { }
    }
}
