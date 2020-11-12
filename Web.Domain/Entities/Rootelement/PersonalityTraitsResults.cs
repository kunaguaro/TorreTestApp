using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities
{
    public class PersonalityTraitsResults
    {
        public List<Group> groups { get; set; }
        public List<Analysis> analyses { get; set; }
    }
}
