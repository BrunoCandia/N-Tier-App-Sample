using Sample.DataAccess.Data.Entities.Product;

namespace Sample.BusinessLogic.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Guid id);
        Task<Product?> GetProductByNameAsync(string name);
    }
}
