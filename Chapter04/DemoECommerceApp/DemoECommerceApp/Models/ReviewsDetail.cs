using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class ReviewsDetail
    {
        public Guid Id { get; set; }
        public Guid? Reviewid { get; set; }
        public string Text { get; set; }

        public Reviews Review { get; set; }
    }
}
