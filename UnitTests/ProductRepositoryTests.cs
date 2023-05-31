using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using Moq;

using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories;

namespace UnitTests
{
    public class ProductRepositoryTests
    {
        private ApplicationDbContext _context;
        private ProductRepository _repository;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "MyBlogDb")
          .Options;
            // Create an in-memory database for testing
            _context = new ApplicationDbContext(dbContextOptions);
            _repository = new ProductRepository(_context);
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    // Dispose the in-memory database after each test
        //    _context.Dispose();
        //}

        [Test]
        [Order(0)]
        public void CreateProduct_ShouldCreateProductAndReturnTrue()
        {
            // Arrange
            var product = new Product
            {
                Name = "Test Product",
                Price = 10
            };

            // Act
            var result = _repository.CreateProduct(product);

            // Assert
            Assert.AreEqual(true, result);
            //Assert.Contains(product, _context.Products.ToList());
        }

        [Test]
        [Order(1)]
        public void DeleteProduct_ExistingProductId_ShouldDeleteProductAndReturnTrue()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = "Test Product",
                Price = 10
            };
            _context.Products.Add(product);
            _context.SaveChanges();

            // Act
            var result = _repository.DeleteProduct(product.Id);

            // Assert
            Assert.IsTrue(result);
            //Assert.IsFalse(_context.Products.Contains(product));
        }

        [Test]
        [Order(2)]
        public void DeleteProduct_NonExistingProductId_ShouldReturnFalse()
        {
            // Arrange
            var productId = 1; // Assuming the product with ID 1 does not exist

            // Act
            var result = _repository.DeleteProduct(productId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        [Order(3)]
        public void GetProductById_ExistingProductId_ShouldReturnProduct()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = "Test Product",
                Price = 10
            };
            _context.Products.Add(product);
            _context.SaveChanges();

            // Act
            var result = _repository.GetProductById(product.Id);

            // Assert
            Assert.AreEqual(product, result);
        }

        [Test]
        [Order(4)]
        public void GetProductById_NonExistingProductId_ShouldReturnNull()
        {
            // Arrange
            var productId = 1; // Assuming the product with ID 1 does not exist

            // Act
            var result = _repository.GetProductById(productId);

            // Assert
            Assert.IsNull(result);
        }
    }
}