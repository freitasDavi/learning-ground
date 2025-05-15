

using Microsoft.EntityFrameworkCore;
using Unit.Core.Entities;
using Unit.Core.Interfaces.Products;
using Unit.Infra.Context;

namespace Unit.Infra.Repositories
{
    public class ProductRepository(UnitDbContext context) : IProductRepository
    {
        private readonly UnitDbContext _context = context;

        public async Task<int> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);

            if (product is null)
                throw new Exception("Product not found");

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);

            await _context.SaveChangesAsync();
        }
    }
}