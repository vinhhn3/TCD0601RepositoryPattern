using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int productId);
        int SumPrice();
    }
}
