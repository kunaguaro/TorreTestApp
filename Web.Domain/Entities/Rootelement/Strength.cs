using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities
{
    public class Strength
    {
        public string id { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public decimal weight { get; set; }
        public int recommendations { get; set; }
        public List<object> media { get; set; }
        public DateTime created { get; set; }
    }
}
