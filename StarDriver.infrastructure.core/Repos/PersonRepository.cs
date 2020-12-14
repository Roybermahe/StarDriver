using System.Collections.Generic;
using System.Linq;
using StarDriver.domain.core.Business.Persons;
using StarDriver.domain.core.Repos;
using StarDriver.infrastructure.core.Base;

namespace StarDriver.infrastructure.core.Repos
{
    public class PersonRepository: GenericRepository<Person>, IPersonsRepository
    {
        public PersonRepository(IDbContext context) : base(context)
        {
        }

        public IEnumerable<Person> getAllInstructor()
        {
            var list = new List<Person>();
            var result = _dbset.Where(x => x is Instructor);
            foreach (var person in result)
            {
                list.Add(person);
            }
            return list.ToArray();
        }
        
        public IEnumerable<Person> GetAllApprentice()
        {
            var list = new List<Person>();
            var result = _dbset.Where(x => x is Apprentice);
            foreach (var person in result)
            {
                list.Add(person);
            }
            return list.ToArray();
        }
    }
}