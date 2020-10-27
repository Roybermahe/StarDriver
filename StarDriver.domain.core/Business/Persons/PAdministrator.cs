using System;
using System.Collections.Generic;
using System.Text;

namespace StarDriver.domain.core.Business.Persons
{
    public class Administrator : Person
    {
        private readonly List<Person> Persons;
        
        public Administrator(int idPerson, string name, string surname, string phone, string mail, string direction) : base(idPerson, name, surname, phone, mail, direction)
        {
            Persons = new List<Person>();
        }
        
        public string SaveInstructor(Instructor instructor)
        {
            if (ExistsPerson(instructor.IdPerson)) return "No se puede realizar el registro,Ya existe un instructor con la misma identificación";
            if (!instructor.HaveSpecialization()) return "No se puede realizar el registro, Se necesita una o más especializaciones";
            if (instructor.Phone.Length > 10 || instructor.Phone.Length < 7) return "No se puede realizar el registro, la cantidad de digitos del telefono no es permitida";
            SavePerson(instructor);
            return "Instructor registrado";
        }

        private void SavePerson(Person person)
        {
            Persons.Add(person);
        }

        private bool ExistsPerson(int idPerson)
        {
            return Persons.FindAll(t => t.IdPerson == idPerson).Count > 0;
        }

        public int CountPersons()
        {
            return Persons.Count;
        }
    }
}
