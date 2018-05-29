using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class Reviews
    {
        public Reviews()
        {
            ReviewsDetail = new HashSet<ReviewsDetail>();
        }

        public Guid Id { get; set; }
        public Guid? Productid { get; set; }
        public Guid? Customerid { get; set; }
        public string Customername { get; set; }
        public int Rating { get; set; }
        public DateTime Addedon { get; set; }
        public DateTime Modifiedon { get; set; }

        public Products Product { get; set; }
        public ICollection<ReviewsDetail> ReviewsDetail { get; set; }
    }
}
