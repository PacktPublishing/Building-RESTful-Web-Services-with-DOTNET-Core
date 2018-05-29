using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class Customers
    {
        public Customers()
        {
            AddressBook = new HashSet<AddressBook>();
            Cart = new HashSet<Cart>();
            CartAttributes = new HashSet<CartAttributes>();
            CustomerInfo = new HashSet<CustomerInfo>();
            Orders = new HashSet<Orders>();
        }

        public Guid Id { get; set; }
        public string Gender { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public Guid? Mainaddressid { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Password { get; set; }
        public bool Newsletteropted { get; set; }

        public ICollection<AddressBook> AddressBook { get; set; }
        public ICollection<Cart> Cart { get; set; }
        public ICollection<CartAttributes> CartAttributes { get; set; }
        public ICollection<CustomerInfo> CustomerInfo { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
