using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Web.Domain.Views.ListElement
{
    public class ListElementListView
    {

        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Location")]
        public string locationName { get; set; }
        [Display(Name = "Prof. Headline")]
        public string professionalHeadline { get; set; }
    }




}
