using GlobalExceptionHandling.Data;
using GlobalExceptionHandling.Model;
using Microsoft.EntityFrameworkCore;

namespace GlobalExceptionHandling.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;

        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetProductList()
        {
            return  await _dbContext.Products.ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<bool> DeleteProduct(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            await _dbContext.SaveChangesAsync();
            return result != null ? true : false;
        }
    }
}

