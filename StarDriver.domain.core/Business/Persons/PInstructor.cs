using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Persons
{
    public class Instructor : Person
    {
        private readonly List<string> _specializations;
   
        public Instructor(int idPerson, string name, string surname,  string phone, string mail, string direction) : base(idPerson, name, surname, phone, mail, direction)
        {
            _specializations =  new List<string>();

        }

        public string AddSpecializations(string specializations)
        {
            if (StringOperations.IsEmpty(specializations)) return "No se puede realizar el registro";
            _specializations.Add(specializations);
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
            return _specializations.Count > 0;
        }
        
 

       
    }
}
