

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Unit.Core.Entities;
using Unit.Infra.Context;
using Unit.Infra.Repositories;

namespace Unit.Tests.Integration.Products
{
    public class ProductRepositoryTests : IDisposable
    {
        private readonly UnitDbContext _context;
        private readonly ProductRepository _repository;
        private readonly SqliteConnection _connection;

        public ProductRepositoryTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<UnitDbContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new UnitDbContext(options);

            // Garante que o banco foi criado
            _context.Database.EnsureCreated();

            _repository = new ProductRepository(_context);

            _context.Categories.Add(new Category { Id = 1, Name = "Eletronics" });
            _context.Products.Add(new Product { Id = 1, Name = "Laptop", Price = 1200, CategoryId = 1 });
            _context.SaveChanges();
        }

        [Fact]
        public async Task GetByIdAsync_ExistingProduct_ReturnsProduct()
        {
            // Act
            var product = await _repository.GetByIdAsync(1);

            // Assert
            Assert.NotNull(product);
            Assert.Equal("Laptop", product.Name);
            Assert.Equal(1200, product.Price);
        }

        [Fact]
        public async Task AddAsync_NewProduct_AddsToDatabase()
        {
            // Arrange
            var newProduct = new Product { Name = "Smartphone", Price = 800, CategoryId = 1 };

            // Act
            var productId = await _repository.AddAsync(newProduct);
            var addedProduct = await _repository.GetByIdAsync(productId);

            // Assert
            Assert.NotNull(addedProduct);
            Assert.Equal(newProduct.Name, addedProduct.Name);
            Assert.Equal(newProduct.Price, addedProduct.Price);
        }

        public void Dispose()
        {
            _context.Dispose();
            _connection.Dispose();
        }
    }
}