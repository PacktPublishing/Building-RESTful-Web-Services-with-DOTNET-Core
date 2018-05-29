using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class Categories
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? Parentcatid { get; set; }
        public int Order { get; set; }
        public DateTime Addedon { get; set; }
        public DateTime Modifiedon { get; set; }
    }
}
