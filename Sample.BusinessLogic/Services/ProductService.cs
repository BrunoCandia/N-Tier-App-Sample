﻿using Sample.DataAccess.Data.Entities.Product;
using Sample.DataAccess.Repositories;

namespace Sample.BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        ////private readonly IRepository<Product> _repository;

        ////public ProductService(IRepository<Product> repository)
        ////{
        ////    _repository = repository;
        ////}

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<Product?> GetProductByNameAsync(string name)
        {
            return await _productRepository.GetProductByNameAsync(name);
        }
    }
}
