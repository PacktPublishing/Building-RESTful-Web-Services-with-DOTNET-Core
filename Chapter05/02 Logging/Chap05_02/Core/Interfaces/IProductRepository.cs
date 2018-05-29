using System;
using System.Collections.Generic;
using Chap05_02.Core.Model;

namespace Chap05_02.Core.Interfaces
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