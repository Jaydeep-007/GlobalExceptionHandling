using GlobalExceptionHandling.Exceptions;
using GlobalExceptionHandling.Model;
using GlobalExceptionHandling.Services;
using Microsoft.AspNetCore.Mvc;
using NotImplementedException = GlobalExceptionHandling.Exceptions.NotImplementedException;

namespace GlobalExceptionHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private ILogger<ProductController> _logger;
        public ProductController(IProductService _productService, ILogger<ProductController> logger)
        {
            productService = _productService;
            _logger = logger;
        }

        [HttpGet("productlist")]
        public Task<IEnumerable<Product>> ProductList()
        {
            var productList = productService.GetProductList();
            return productList;

        }
        [HttpGet("getproductbyid")]
        public Task<Product> GetProductById(int Id)
        {
            _logger.LogInformation($"Fetch Product with ID: {Id} from the database");
            var product = productService.GetProductById(Id);
            if (product.Result == null)
            {
                throw new NotFoundException($"Product ID {Id} not found.");

            }
            _logger.LogInformation($"Returning product with ID: {product.Result.ProductId}.");
            return product;
        }

        [HttpPost("addproduct")]
        public Task<Product> AddProduct(Product product)
        {
            return productService.AddProduct(product);
        }

        [HttpPut("updateproduct")]
        public Task<Product> UpdateProduct(Product product)
        {
            return productService.UpdateProduct(product);
        }

        [HttpDelete("deleteproduct")]
        public Task<bool> DeleteProduct(int Id)
        {
            return productService.DeleteProduct(Id);
        }

        [HttpGet("filterproduct")]
        public Task<List<Product>> FilterProduct(int Id)
        {
            throw new NotImplementedException("Not Implemented Exception!");
        }
    }
}
