using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class ProductsAttributes
    {
        public Guid Id { get; set; }
        public Guid? Productsid { get; set; }
        public Guid? Optionsid { get; set; }
        public Guid? Optionvaluesid { get; set; }
        public decimal Price { get; set; }
        public string PricePrefix { get; set; }

        public ProductsOptions Options { get; set; }
        public ProductsOptionsValues Optionvalues { get; set; }
        public Products Products { get; set; }
    }
}
