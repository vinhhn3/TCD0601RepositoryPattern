using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        bool CreateProduct(Product product);
        void UpdateProduct(Product product);
        bool DeleteProduct(int productId);
        int SumPrice();
    }
}
