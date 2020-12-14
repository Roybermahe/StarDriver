using System.Collections.Generic;
using System.Linq;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Business.Persons;
using StarDriver.domain.core.Contracts;
using StarDriver.infrastructure.core.Repos;

namespace StarDriver.application.core.PersonServices
{
    public class GetPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetPersonResponse Ejecutar()
        {
            var list = _unitOfWork.PersonsRepository.GetAll().ToArray();
            return !list.Any() ? 
                new GetPersonResponse("No se encontro ninguna persona.") : 
                new GetPersonResponse($"Se encontraron {list.Count()} personas.", personlist: list);
        }
        
        public GetPersonResponse Ejecutar(int id)
        {
            var person = _unitOfWork.PersonsRepository.Find(id);
            return person == null ? 
                new GetPersonResponse("No se encontro la persona") : 
                new GetPersonResponse($"La persona {person.Id} fue encontrada.", person: person);
        }
        
        public GetPersonResponse ListaInstructors()
        {
            var person = ((PersonRepository)_unitOfWork.PersonsRepository).getAllInstructor();
            var enumerable = person as Person[] ?? person.ToArray();
            return !enumerable.Any() ? 
                new GetPersonResponse("No se encontraron instructores.") : 
                new GetPersonResponse($"La persona {enumerable.Count()} fue encontrada.", personlist: enumerable);
        }
        
        public GetPersonResponse ListaApprentices()
        {
            var person = ((PersonRepository)_unitOfWork.PersonsRepository).GetAllApprentice();
            var enumerable = person as Person[] ?? person.ToArray();
            return !enumerable.Any() ? 
                new GetPersonResponse("No se encontraron instructores.") : 
                new GetPersonResponse($"La persona {enumerable.Count()} fue encontrada.", personlist: enumerable);
        }

    }
    
    public class GetPersonResponse
    {
        public string Message { get; }
        public Person Person { get;  }
        public IEnumerable<Person> Personlist { get; }

        public GetPersonResponse(string message, IEnumerable<Person> personlist = null, Person person = null)
        {
            Message = message;
             Person= person;
            Personlist = personlist;
        }
    }
}