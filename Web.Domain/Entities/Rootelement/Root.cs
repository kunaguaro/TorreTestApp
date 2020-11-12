using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Entities
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Root
    {
        public Person person { get; set; }
        public Stats stats { get; set; }
        public List<Strength> strengths { get; set; }
        public List<Interest> interests { get; set; }
        public List<Experience> experiences { get; set; }
        public List<object> awards { get; set; }
        public List<Job> jobs { get; set; }
        public List<Project> projects { get; set; }
        public List<object> publications { get; set; }
        public List<Education> education { get; set; }
        public List<Opportunity> opportunities { get; set; }
        public List<Language> languages { get; set; }
        public PersonalityTraitsResults personalityTraitsResults { get; set; }
        public ProfessionalCultureGenomeResults professionalCultureGenomeResults { get; set; }
    }



   
   


}
