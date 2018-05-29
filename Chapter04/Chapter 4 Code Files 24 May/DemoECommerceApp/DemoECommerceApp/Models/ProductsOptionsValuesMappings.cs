using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class ProductsOptionsValuesMappings
    {
        public Guid Id { get; set; }
        public Guid? Optionsid { get; set; }
        public Guid? Valuesid { get; set; }

        public ProductsOptions Options { get; set; }
        public ProductsOptionsValues Values { get; set; }
    }
}
