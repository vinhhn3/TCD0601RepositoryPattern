using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateProduct(Product product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Price = product.Price,
            };

            try
            {
                _context.Products.Add(newProduct);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product == null) {
                return false;
            }
            _context.Remove(product);
            return _context.SaveChanges() > 0;
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.SingleOrDefault(t => t.Id == productId);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public int SumPrice()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
