using System;

namespace DemoECommerceApp.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Id = Guid.NewGuid();
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
    }
}
