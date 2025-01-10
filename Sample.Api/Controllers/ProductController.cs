using Microsoft.AspNetCore.Mvc;
using Sample.BusinessLogic.Services;
using Sample.DataAccess.Data.Entities.Product;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _productService.AddProductAsync(product);

            return CreatedAtAction(nameof(GetProductById), new { productId = product.ProductId }, product);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Update(Guid productId, Product product)
        {
            if (productId != product.ProductId) return BadRequest();

            await _productService.UpdateProductAsync(product);

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            await _productService.DeleteProductAsync(productId);

            return NoContent();
        }

        [HttpGet("{productName:alpha}")]
        public async Task<IActionResult> GetProductByName(string productName)
        {
            var product = await _productService.GetProductByNameAsync(productName);

            if (product == null) return NotFound();

            return Ok(product);
        }
    }
}
