using System;
using System.Collections.Generic;
using System.Text;

namespace StarDriver.domain.core
{
    
    public abstract class Person
    {
        public readonly List<Person> _instructors = new List<Person>();
        public Person(int idPerson, string name, string surname, string phone, string mail, string direction)
        {
            IdPerson = idPerson;
            Name = name;
            Surname = surname;
            Phone = phone;
            Mail = mail;
            Direction = direction;
            
        }

        public int IdPerson { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Direction { get; set; }

        protected void SavePerson(Person person)
        {
            _instructors.Add(person);
        }

        protected bool ExistsInstructor(int idPerson)
        {
            return _instructors.FindAll(t => t.IdPerson == idPerson).Count > 0;
        }
    }
}
