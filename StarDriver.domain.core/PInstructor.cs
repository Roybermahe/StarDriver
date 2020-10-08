using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarDriver.domain.core
{
    public class PInstructor : Person
    {
        List<string> Especializations;
        List<PInstructor> instructors = new List<PInstructor>();
        public PInstructor(int idPerson, string name, string surname,  string phone, string mail, string direction) : base(idPerson, name, surname, phone, mail, direction)
        {
            Especializations =  new List<string>();
        }

        public string CreateInstructor(PInstructor pInstuctor, List<string> especializations)
        {


            if (ExistsInstructor(pInstuctor.IdPerson)) return "No se puede realizar el registro,Ya existe un instructor con la misma identificación";


            instructors.Add(pInstuctor);
            return "Instructor registrado";
        }

        public bool ExistsInstructor(int idInstructor)
        {
            return instructors.All(t => t.IdPerson == idInstructor);


        }

    }
}
