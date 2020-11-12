using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Domain.Enums
{
    public class Enums
    {

        public enum EEstados
        {
            Edicion = 1,
            Publicado = 2
        }


        public static Dictionary<int, string> Meses = new Dictionary<int, string> {
            {1,"Ene"},
            {2,"Feb"},
            {3,"Mar"},
            {4,"Abr"},
            {5,"May"},
            {5,"Jun"},
            {6,"Jul"},
            {7,"Ago"},
            {9,"Set"},
            {10,"Oct"},
            {11,"Nov"},
            {12,"Dic"},

        };


    }
}
