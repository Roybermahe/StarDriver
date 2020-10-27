using System;
using System.Collections.Generic;
using System.Text;

namespace StarDriver.domain.core.Business.Persons
{
    public class Administrator : Person
    {
        private readonly List<Person> Persons;
        
        public Administrator(int id, string name, string surname, string phone, string mail, string direction) 
        {
            Persons = new List<Person>();
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
            Mail = mail;
            Direction = direction;        }
        
        public string SaveInstructor(Instructor instructor)
        {
            if (ExistsPerson(pInstuctor.Id)) return "No se puede realizar el registro,Ya existe un instructor con la misma identificación";
            if (!pInstuctor.HaveSpecialization()) return "No se puede realizar el registro, Se necesita una o más especializaciones";
            if (pInstuctor.Phone.Length > 10 || pInstuctor.Phone.Length < 7)
                return "No se puede realizar el registro, la cantidad de digitos del telefono no es permitida";
            SavePerson(pInstuctor);
            return "Instructor registrado";
        }

        private void SavePerson(Person person)
        {
            Persons.Add(person);
        }

        private bool ExistsPerson(int idPerson)
        {
            return Persons.FindAll(t => t.Id == idPerson).Count > 0;
        }

        public int CountPersons()
        {
            return Persons.Count;
        }
    }
}
