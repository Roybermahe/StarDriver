using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarDriver.domain.core
{
    public class PInstructor : Person
    {
        List<string> Specializations;
   
        public PInstructor(int idPerson, string name, string surname,  string phone, string mail, string direction) : base(idPerson, name, surname, phone, mail, direction)
        {
            Specializations =  new List<string>();

        }

        public string AddSpecializations(List<string> specializations)
        {
            if (specializations.Count == 0) return "No se puede realizar el registro";
            Specializations= specializations;
            return "Especializaciones agregadas";
        }
        protected string DeleteSpecializations(string specializations)
        {
            if (specializations == "") return "No se puede eliminar";
            Specializations.Remove(specializations);
            return "Especializaciones agregadas";
        }
        
 

       
    }
}
