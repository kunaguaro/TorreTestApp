using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Web.Domain.Utils
{
    public class DomainUtils
    {
        public static string ObtenerPalabras(string input, int nroCaracteres)
        {
            try
            {

                int nchar = nroCaracteres;

                for (int i = 0; i < input.Length; i++)
                {
                    nchar--;
                    if (nchar == 0)
                    {
                        return input.Substring(0, i);
                    }
                }
            }
            catch (Exception)
            {
                // to do
            }
            return string.Empty;
        }


        public static List<Tuple<string, string>> GetNamesAndValuesFromClassToFilterForms<T>(object classObj)
        {
            List<Tuple<string, string>> lista = new List<Tuple<string, string>>();
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();
            for (int i = 0; i < pia.Length; i++)
            {
                    if (classObj.GetType().GetProperty(pia[i].Name).GetValue(classObj, null) != null)
                    {
                        string valorfiltro = classObj.GetType().GetProperty(pia[i].Name).GetValue(classObj, null).ToString();
                        string nombreDisplay = GetSingleNameFromDataAnotationModel<T>(pia[i].Name);
                        lista.Add(new Tuple<string, string>(nombreDisplay, valorfiltro));
                        return lista;
                    }
            }
            return lista;
        }

        public static string GetSingleNameFromDataAnotationModel<T>(string NombrePropiedad)
        {
            Type t = typeof(T);
            PropertyInfo[] pia = t.GetProperties();
            PropertyInfo p = pia.Where(o => o.Name == NombrePropiedad).FirstOrDefault();

            CustomAttributeData displayAttribute = p.CustomAttributes.FirstOrDefault(x => x.AttributeType.Name == "DisplayAttribute");


            if (displayAttribute != null)
            {
                return displayAttribute.NamedArguments.FirstOrDefault().TypedValue.Value.ToString();

            }
            else
            {
                return "DisplayAttribute error";
            }

        }
    }
}
