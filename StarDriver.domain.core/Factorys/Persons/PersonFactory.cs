using StarDriver.domain.core.Business.Persons;

namespace StarDriver.domain.core.Factorys.Persons
{
    public class PersonFactory : IFactoryGeneric<Person>
    {
        public Person FactoryMethod(string type)
        {
            Person factory = type switch
            {
                "Apprentice" => new Apprentice(),
                "Instructor" => new Instructor(),
                _ => null
            };
            return factory;
        }
    }
}