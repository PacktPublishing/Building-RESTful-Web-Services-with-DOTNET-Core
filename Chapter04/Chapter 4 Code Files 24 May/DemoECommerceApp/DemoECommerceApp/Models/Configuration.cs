using System;
using System.Collections.Generic;

namespace DemoECommerceApp.Models
{
    public partial class Configuration
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public Guid? Configurationgroupid { get; set; }
        public int Order { get; set; }
        public DateTime ModifiedOn { get; set; }

        public ConfigurationGroup Configurationgroup { get; set; }
    }
}
