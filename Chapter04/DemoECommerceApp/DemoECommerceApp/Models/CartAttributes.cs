using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class CartAttributes
    {
        public Guid Id { get; set; }
        public Guid? Customerid { get; set; }
        public Guid? Productid { get; set; }
        public Guid? Productoptionid { get; set; }
        public Guid? Productoptionvalueid { get; set; }

        public Customers Customer { get; set; }
        public Products Product { get; set; }
        public ProductsOptions Productoption { get; set; }
        public ProductsOptionsValues Productoptionvalue { get; set; }
    }
}
