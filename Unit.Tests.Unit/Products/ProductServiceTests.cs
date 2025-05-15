

using System.ComponentModel.DataAnnotations;
using Moq;
using Unit.Core.Dtos.Products;
using Unit.Core.Entities;
using Unit.Core.Interfaces.Products;
using Unit.Core.Services;

namespace Unit.Tests.Unit.Products
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepository;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetById_ExistingProduct_ReturnsProductDto()
        {

            // Arrange
            var productId = 1;
            // Cria o produto
            var product = new Product { Id = productId, Name = "Test Product", Price = 10.0m, CategoryId = 1 };
            // Diz qual o retorno esperado quando chamar a função passando os parâmetros
            _mockRepository.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);


            // Act
            var result = await _service.GetByIdAsync(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.Price, result.Price);
        }

        [Fact]
        public async Task GetById_NonExistingProduct_ReturnsNull()
        {
            var productId = 99;

            _mockRepository.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync((Product)null);

            var result = await _service.GetByIdAsync(productId);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreateProduct_ValidProduct_ReturnsProductId()
        {
            // Arrange
            var newProductId = 1;
            var productDto = new CreateProductDto { CategoryId = 1, Name = "New Product", Price = 200m };

            // Mockando rep, se passar qualquer objeto do tipo Produto, retorna o Id
            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Product>())).ReturnsAsync(newProductId);

            // Act
            var result = await _service.AddAsync(productDto);

            // Assert
            Assert.Equal(newProductId, result);
            _mockRepository.Verify(r => r.AddAsync(It.Is<Product>(p =>
                p.Name == productDto.Name &&
                p.Price == productDto.Price &&
                p.CategoryId == productDto.CategoryId)), Times.Once);
        }

        [Fact]
        public async Task CreateProduct_InvalidProduct_ThrowsValidationException()
        {
            var productDto = new CreateProductDto { Name = "", Price = 0m, CategoryId = 1 };

            await Assert.ThrowsAsync<ValidationException>(() => _service.AddAsync(productDto));

            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Product>()), Times.Never);
        }
    }
}