using System;
using System.Collections.Generic;
using FlixOneProductServices.Core.Model;

namespace FlixOneProductServices.Core.Interfaces
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