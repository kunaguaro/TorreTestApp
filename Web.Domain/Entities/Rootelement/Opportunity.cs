using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities
{
    public class Opportunity
    {
        public string id { get; set; }
        public string interest { get; set; }
        public string field { get; set; }
        public object data { get; set; }
    }
}
