using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Domain.Popups
{
    public class PopupModel
    {
        [MinLength(2, ErrorMessage = "No puede tener una longitud menor a 2 caracteres")]
        public string ValorBuscar { get; set; }
        public string Titulo { get; set; }
        public Boolean ShowCampoAdicional { get; set; }
        public string ModelName { get; set; }
    }


    public class PopupDetalle
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CampoAdicional { get; set; }
    }

    public class PopupCriteria
    {
        public string ValorBuscar { get; set; }
    }

}
