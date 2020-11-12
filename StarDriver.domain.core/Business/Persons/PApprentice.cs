namespace StarDriver.domain.core.Business.Persons
{
    public class Apprentice : Person
    {
        public Apprentice()
        {
            
        }
        
        public Apprentice(int identificacion, string name, string surname,  string phone, string mail, string direction)
        {
            Id = identificacion;
            Name = name;
            Surname = surname;
            Phone = phone;
            Mail = mail;
            Direction = direction;  
        }
    }
}