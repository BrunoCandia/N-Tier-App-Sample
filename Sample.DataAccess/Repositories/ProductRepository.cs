using Microsoft.EntityFrameworkCore;
using Sample.DataAccess.Data.Entities.Product;

namespace Sample.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly SampleContext _sampleContext;

        public ProductRepository(SampleContext sampleContext) : base(sampleContext)
        {
            _sampleContext = sampleContext;
        }

        public async Task<Product?> GetProductByNameAsync(string name)
        {
            return await _sampleContext.Product
                .FirstOrDefaultAsync(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
