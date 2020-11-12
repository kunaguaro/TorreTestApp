using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities
{
    public class Person
    {
        public string professionalHeadline { get; set; }
        public double completion { get; set; }
        public bool showPhone { get; set; }
        public DateTime created { get; set; }
        public bool verified { get; set; }
        public Flags flags { get; set; }
        public decimal weight { get; set; }
        public string locale { get; set; }
        public string subjectId { get; set; }
        public string picture { get; set; }
        public bool hasEmail { get; set; }
        public string name { get; set; }
        public List<Link> links { get; set; }
        public Location location { get; set; }
        public string theme { get; set; }
        public string id { get; set; }
        public string pictureThumbnail { get; set; }
        public bool claimant { get; set; }
        public string summaryOfBio { get; set; }
        public string weightGraph { get; set; }
        public string publicId { get; set; }
    }

}
