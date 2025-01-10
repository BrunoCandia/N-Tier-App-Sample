using Microsoft.EntityFrameworkCore;
using Sample.DataAccess.Data.Entities.Product;

namespace Sample.DataAccess
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
