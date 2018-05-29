using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class OrderProductAttributes
    {
        public Guid Id { get; set; }
        public Guid? Orderid { get; set; }
        public Guid? Orderproductid { get; set; }
        public string Productoptions { get; set; }
        public string Productoptiobvalue { get; set; }
        public decimal Optionvalueprice { get; set; }
        public string PricePrefix { get; set; }

        public Orders Order { get; set; }
        public OrdersProducts Orderproduct { get; set; }
    }
}
