using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class Manufacturers
    {
        public Manufacturers()
        {
            ManufacturersInfo = new HashSet<ManufacturersInfo>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<ManufacturersInfo> ManufacturersInfo { get; set; }
    }
}
