

using Unit.Core.Dtos.Products;
using Unit.Core.Entities;

namespace Unit.Core.Interfaces.Products
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<int> AddAsync(CreateProductDto product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}