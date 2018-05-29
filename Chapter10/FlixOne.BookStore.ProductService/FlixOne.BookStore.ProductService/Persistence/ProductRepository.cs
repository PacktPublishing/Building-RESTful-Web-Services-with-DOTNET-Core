using System;
using System.Collections.Generic;
using System.Linq;
using FlixOne.BookStore.ProductService.Models;

namespace FlixOne.BookStore.ProductService.Persistence
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> ProductList => FakeProductList();
        public List<Category> CategoryList => FakeCategoryList();

        public void Remove(Guid id)
        {
            var product = GetBy(id);
            ProductList.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductList;
        }

        public Product GetBy(Guid id)
        {
            return ProductList.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Product product)
        {
            ProductList.Add(product);
        }

        public void Update(Product product)
        {
            var prod = ProductList.FirstOrDefault(x => x.Id == product.Id);
            if (prod == null) return;
            ProductList.Remove(prod);
            ProductList.Add(product);
        }

        private List<Product> FakeProductList()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = new Guid("8DD81D72-3859-4376-B7DE-A55D7A09627E"),
                    Image = "Not available",
                    Name = "Learn C# in 7 days",
                    Description = "Start learning C# in 7 days",
                    Price = 115M,
                    Category = CategoryBy(new Guid("880AC2AD-112B-4CAC-A60F-348EEFE7BBCC")),
                    CategoryId = new Guid("880AC2AD-112B-4CAC-A60F-348EEFE7BBCC")
                },
                new Product
                {
                    Id = new Guid("2BCFA359-8D49-4531-821D-40F4E04CC4DF"),
                    Image = "Not available",
                    Name = "Next day after death",
                    Description = "Next day after death",
                    Price = 655M,
                    Category = CategoryBy(new Guid("9703106A-B473-47EA-B9D8-11681E33AD8C")),
                    CategoryId = new Guid("9703106A-B473-47EA-B9D8-11681E33AD8C")
                }
            };
        }

        private List<Category> FakeCategoryList()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = new Guid("880AC2AD-112B-4CAC-A60F-348EEFE7BBCC"),
                    Name = "Tech books",
                    Description = "Technical books on various technology stacks."
                },
                new Category
                {
                    Id = new Guid("9703106A-B473-47EA-B9D8-11681E33AD8C"),
                    Name = "Story books",
                    Description = "Story books."
                },
                new Category
                {
                    Id = new Guid("77DD5B53-8439-49D5-9CBC-DC5314D6F190"),
                    Name = "Miscellanious books",
                    Description = "Miscellanious books."
                }
            };
        }

        private Category CategoryBy(Guid id)
        {
            return CategoryList.FirstOrDefault(x => x.Id == id);
        }
    }
}