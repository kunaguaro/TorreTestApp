using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities
{
    public class Location
    {
        public string name { get; set; }
        public string shortName { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public int timezoneOffSet { get; set; }
    }
}
