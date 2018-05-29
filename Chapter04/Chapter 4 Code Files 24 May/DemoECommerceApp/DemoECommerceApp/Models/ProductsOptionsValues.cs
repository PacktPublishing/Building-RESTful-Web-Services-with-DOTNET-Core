using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class ProductsOptionsValues
    {
        public ProductsOptionsValues()
        {
            CartAttributes = new HashSet<CartAttributes>();
            ProductsAttributes = new HashSet<ProductsAttributes>();
            ProductsOptionsValuesMappings = new HashSet<ProductsOptionsValuesMappings>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<CartAttributes> CartAttributes { get; set; }
        public ICollection<ProductsAttributes> ProductsAttributes { get; set; }
        public ICollection<ProductsOptionsValuesMappings> ProductsOptionsValuesMappings { get; set; }
    }
}
