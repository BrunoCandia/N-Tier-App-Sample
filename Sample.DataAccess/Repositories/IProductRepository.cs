using Sample.DataAccess.Data.Entities.Product;

namespace Sample.DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetProductByNameAsync(string name);
    }
}
