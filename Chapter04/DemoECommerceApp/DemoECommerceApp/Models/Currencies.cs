using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class Currencies
    {
        public Currencies()
        {
            Countries = new HashSet<Countries>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Symboleleft { get; set; }
        public string Symbolright { get; set; }

        public ICollection<Countries> Countries { get; set; }
    }
}
