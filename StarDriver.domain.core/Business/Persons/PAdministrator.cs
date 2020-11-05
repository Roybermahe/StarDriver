using System;
using System.Collections.Generic;
using System.Text;
using StarDriver.domain.core.Base;

namespace StarDriver.domain.core.Business.Persons
{
    public class Administrator : Entity<int>
    {
        private readonly List<Person> _persons;
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public Administrator() {}
        
        public Administrator(int id, string name, string surname) 
        {
            _persons = new List<Person>();
            Id = id;
            Name = name;
            Surname = surname;
        }
        

        
        public string SaveInstructor(Instructor instructor)
        {
            if (ExistsPerson(instructor.Id)) return "No se puede realizar el registro,Ya existe un instructor con la misma identificación";
            if (!instructor.HaveSpecialization()) return "No se puede realizar el registro, Se necesita una o más especializaciones";
            if (instructor.Phone.Length > 10 || instructor.Phone.Length < 7)
                return "No se puede realizar el registro, la cantidad de digitos del telefono no es permitida";
            SavePerson(instructor);
            return "Instructor registrado";
        }

        private void SavePerson(Person person)
        {
            _persons.Add(person);
        }

        private bool ExistsPerson(int idPerson)
        {
            return _persons.FindAll(t => t.Id == idPerson).Count > 0;
        }

        public int CountPersons()
        {
            return _persons.Count;
        }
    }
}
