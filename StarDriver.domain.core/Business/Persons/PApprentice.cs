using System.Collections.Generic;

namespace StarDriver.domain.core.Business.Persons
{
    public class Apprentice : Person
    {
        public Apprentice()
        {
            
        }
        
        public Apprentice(int id, string name, string surname,  string phone, string mail, string direction)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
            Mail = mail;
            Direction = direction;  
        }
    }
}