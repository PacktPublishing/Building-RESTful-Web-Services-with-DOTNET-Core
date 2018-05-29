using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chap08_02.Models;

namespace Chap08_02.Persistence
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByProduct(string id);
        IEnumerable<Product> GetBy(string productName);
        void Remove(string id);
        void Update(Product product);
    }
}
