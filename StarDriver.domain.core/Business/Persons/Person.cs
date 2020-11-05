using StarDriver.domain.core.Base;

namespace StarDriver.domain.core.Business.Persons
{
    public abstract class Person: Entity<int>
    {
        protected Person()
        {
        }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Direction { get; set; }
    }
}