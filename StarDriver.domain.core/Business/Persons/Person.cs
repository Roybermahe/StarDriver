using System;
using System.Collections.Generic;
using System.Text;

namespace StarDriver.domain.core
{
    public abstract class Person
    {
        protected Person(int idPerson, string name, string surname, string phone, string mail, string direction)
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
    }
}
