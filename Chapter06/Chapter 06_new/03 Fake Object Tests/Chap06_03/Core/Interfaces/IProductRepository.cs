using System;
using System.Collections.Generic;
using Chap06_03.Core.Model;

namespace Chap06_03.Core.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();
        Product GetBy(Guid id);
        void Remove(Guid id);
        void Update(Product product);
    }
}