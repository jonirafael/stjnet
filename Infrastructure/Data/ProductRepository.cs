using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Where(p => p.isEnabled == true)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductFactory)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<ProductCategory>> GetProductCategoriesAsync()
        {
            return await _context.ProductCategories.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductFactory>> GetProductFactoriesAsync()
        {
            return await _context.ProductFactories.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Where(p => p.isEnabled == true)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductFactory)
                .ToListAsync();
        }
    }
}