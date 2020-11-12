using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities
{
    public class Group
    {
        public string id { get; set; }
        public int order { get; set; }
        public double median { get; set; }
        public double stddev { get; set; }
    }
}
