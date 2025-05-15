

using Unit.Core.Entities;

namespace Unit.Core.Interfaces.Products
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<int> AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}