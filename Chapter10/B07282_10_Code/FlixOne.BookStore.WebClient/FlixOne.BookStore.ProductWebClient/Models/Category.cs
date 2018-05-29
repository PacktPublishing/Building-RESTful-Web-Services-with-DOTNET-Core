using System;
using System.Collections.Generic;

namespace FlixOne.BookStore.ProductWebClient.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
