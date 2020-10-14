using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarDriver.domain.core
{
    public class Instructor : Person
    {
        private List<string> _specialization;
   
        public Instructor(int idPerson, string name, string surname,  string phone, string mail, string direction) : base(idPerson, name, surname, phone, mail, direction)
        {
            _specialization =  new List<string>();
        }

        public string CreateInstructor(Instructor instructor, List<string> especializations)
        {
            if (ExistsInstructor(instructor.IdPerson)) return "No se puede realizar el registro,Ya existe un instructor con la misma identificación";
            if (especializations.Count == 0) return "No se puede realizar el registro, Se necesita una o más especializaciones";
            if (instructor.Phone.Length > 10 || instructor.Phone.Length < 7) return "No se puede realizar el registro, la cantidad de digitos del telefono no es permitida";
            SavePerson(instructor);
            return "Instructor registrado";
        }
    }
}
