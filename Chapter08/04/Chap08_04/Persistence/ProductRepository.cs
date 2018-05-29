using System;
using System.Collections.Generic;
using System.Linq;
using Chap08_04.Contexts;
using Chap08_04.Models;
using Microsoft.EntityFrameworkCore;

namespace Chap08_04.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include("Category").ToList();
        }

        //public IEnumerable<Product> GetByProduct(string id) => _context.Products.FromSql("SELECT * FROM dbo.Products WHERE id="+ id).Include(p => p.Category)
        //    .ToList();

        public IEnumerable<Product> GetByProduct(string id) => _context.Products
            .FromSql($"SELECT * FROM dbo.Products WHERE id={id}")
            .Include(p => p.Category)
            .ToList();

        public IEnumerable<Product> GetBy(string productName)
        {
            return _context.Products.FromSql($"SELECT * FROM dbo.Products WHERE Name = {productName}")
                .Include(p => p.Category)
                .ToList();
        }

        public void Remove(string id)
        {
            var product = GetByProduct(id);
            _context.Remove(product);
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }

        public IQueryable<Category> GetBy(Guid catId)
        {
            var category = from cat in _context.Categories
                where cat.Id == catId
                select cat;
            return category;
        }
    }
}