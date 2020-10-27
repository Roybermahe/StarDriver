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
    }
}