using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarDriver.domain.core
{
    public class PInstructor : Person
    {
        List<string> Especializations;
   
        public PInstructor(int idPerson, string name, string surname,  string phone, string mail, string direction) : base(idPerson, name, surname, phone, mail, direction)
        {
            Especializations =  new List<string>();

        }

        public string CreateInstructor(PInstructor pInstuctor, List<string> especializations)
        {

            if (ExistsInstructor(pInstuctor.IdPerson)) return "No se puede realizar el registro,Ya existe un instructor con la misma identificación";

            if (especializations.Count() == 0) return "No se puede realizar el registro, Se necesita una o más especializaciones";

            SavePerson(pInstuctor);
          
            return "Instructor registrado";
        }

 

       
    }
}
