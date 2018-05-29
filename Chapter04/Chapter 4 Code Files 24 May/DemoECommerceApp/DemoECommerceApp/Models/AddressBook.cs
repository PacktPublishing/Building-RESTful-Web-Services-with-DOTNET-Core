using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class AddressBook
    {
        public Guid Id { get; set; }
        public Guid? Customerid { get; set; }
        public string Company { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Streetaddress { get; set; }
        public string Postalcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Guid? Countryid { get; set; }

        public Customers Customer { get; set; }
    }
}
