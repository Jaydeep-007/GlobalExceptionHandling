using GlobalExceptionHandling.Model;

namespace GlobalExceptionHandling.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProductList();
        public Task<Product> GetProductById(int id);
        public Task<Product> AddProduct(Product product);
        public Task<Product> UpdateProduct(Product product);
        public Task<bool> DeleteProduct(int Id);
    }
}
