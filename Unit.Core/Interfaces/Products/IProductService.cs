

using Unit.Core.Dtos.Products;

namespace Unit.Core.Interfaces.Products
{
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<int> AddAsync(CreateProductDto product);
        Task UpdateAsync(int id, UpdateProductDto product);
        Task DeleteAsync(int id);
    }
}