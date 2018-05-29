using DemoECommerceApp.Domain;
using System.Threading.Tasks;

namespace DemoECommerceApp.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(Product product);
        Task<Product> GetOrderAsync(int id);
        Task<bool> UpdateProductAsync(int id, Product product);
        Task<bool> DeleteOrderAsync(int id);
    }
}