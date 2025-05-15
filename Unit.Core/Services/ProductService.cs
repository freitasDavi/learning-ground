

using System.ComponentModel.DataAnnotations;
using Unit.Core.Dtos.Products;
using Unit.Core.Entities;
using Unit.Core.Interfaces.Products;

namespace Unit.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> AddAsync(CreateProductDto request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId
            };

            if (!product.IsValid())
            {
                throw new ValidationException("Product is not valid");
            }

            return await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);

            if (product == null)
                throw new ValidationException("Product not found");

            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();

            var response = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryId = p.CategoryId,
            });

            return response;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };
        }

        public Task UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}