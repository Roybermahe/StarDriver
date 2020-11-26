using StarDriver.domain.core.Base;

namespace StarDriver.domain.core.Business.Persons
{
    public abstract class Person: Entity<int>
    {
        protected Person()
        {
        }

        public Person(int identificacion,string name, string surname, string phone, string mail, string direction)
        {
            Identificacion = identificacion;
            Name = name;
            Surname = surname;
            Phone = phone;
            Mail = mail;
            Direction = direction;
        }
        
        public int Identificacion { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Direction { get; set; }
    }
}