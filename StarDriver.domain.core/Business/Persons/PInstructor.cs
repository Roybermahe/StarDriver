using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core
{
    public class Instructor : Person
    {
        readonly List<string> Specializations;
   
        public Instructor(int idPerson, string name, string surname,  string phone, string mail, string direction) : base(idPerson, name, surname, phone, mail, direction)
        {
            Specializations =  new List<string>();

        }

        public string AddSpecializations(string specializations)
        {
            if (StringOperations.IsEmpty(specializations)) return "No se puede realizar el registro";
            Specializations.Add(specializations);
            return "Especializaciones agregadas";
        }
       /* protected string DeleteSpecializations(string specializations)
        {
            if (specializations == "") return "No se puede eliminar";
            Specializations.Remove(specializations);
            return "Especializaciones agregadas";
        }*/

        public bool HaveSpecialization()
        {
            return Specializations.Count > 0;
        }
        
 

       
    }
}
