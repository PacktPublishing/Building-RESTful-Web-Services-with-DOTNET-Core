using DemoECommerceApp.Domain;
using DemoECommerceApp.Interfaces;
using System.Threading.Tasks;

namespace DemoECommerceApp.Services
{
    public class ProductService : IProductService
    {
        public async Task<bool> CreateProductAsync(Product product)
        {
            // Do database operation and save the product.
            product.Id = 1;

            return true;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            // Delete from database and return true/false.
            return true;
        }

        public Task<Product> GetOrderAsync(int id)
        {
            // Get from database and return.
            return Task.Run(() => new Product(id, "Noddles", 12.9m));
        }

        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            product.Id = id;
            product.Name = product.Name;
            product.Price = product.Price;

            // Update in database.

            return true;
        }
    }
}