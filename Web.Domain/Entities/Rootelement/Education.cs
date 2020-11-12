using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities
{
    public class Education
    {
        public string id { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public List<Organization4> organizations { get; set; }
        public List<object> responsibilities { get; set; }
        public string fromMonth { get; set; }
        public string fromYear { get; set; }
        public string toMonth { get; set; }
        public string toYear { get; set; }
        public bool highlighted { get; set; }
        public decimal weight { get; set; }
        public int verifications { get; set; }
        public int recommendations { get; set; }
        public List<object> media { get; set; }
        public int rank { get; set; }
    }
}
