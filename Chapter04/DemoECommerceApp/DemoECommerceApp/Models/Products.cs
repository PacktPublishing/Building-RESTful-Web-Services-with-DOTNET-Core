using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class Products
    {
        public Products()
        {
            Cart = new HashSet<Cart>();
            CartAttributes = new HashSet<CartAttributes>();
            OrdersProducts = new HashSet<OrdersProducts>();
            ProductsAttributes = new HashSet<ProductsAttributes>();
            Productsdetail = new HashSet<Productsdetail>();
            Reviews = new HashSet<Reviews>();
        }

        public Guid Id { get; set; }
        public int Qty { get; set; }
        public string Model { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public DateTime Addedon { get; set; }
        public DateTime Modifiedon { get; set; }
        public decimal Weight { get; set; }
        public byte Status { get; set; }
        public Guid? ManufactureId { get; set; }
        public Guid? Taxclassid { get; set; }

        public ICollection<Cart> Cart { get; set; }
        public ICollection<CartAttributes> CartAttributes { get; set; }
        public ICollection<OrdersProducts> OrdersProducts { get; set; }
        public ICollection<ProductsAttributes> ProductsAttributes { get; set; }
        public ICollection<Productsdetail> Productsdetail { get; set; }
        public ICollection<Reviews> Reviews { get; set; }
    }
}
