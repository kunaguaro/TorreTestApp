using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Domain.Views.ListElement
{
    public class ListElementCriteria
    {
        [Display(Name = "Currency")]
        public string currency { get; set; }

        [Display(Name = "Periodicity")]
        public string periodicity { get; set; }
    }
}
