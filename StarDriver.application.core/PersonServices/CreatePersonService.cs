using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using StarDriver.domain.core.Business.Persons;
using StarDriver.domain.core.Contracts;
using StarDriver.domain.core.Factorys.Persons;

namespace StarDriver.application.core.PersonServices
{
    public class CreatePersonServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePersonServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PersonCreateResponse Ejecutar(PersonCreateRequest request)
        {
            var person = request.Map();
           _unitOfWork.PersonsRepository.Add(person);
            _unitOfWork.Commit();
            return new PersonCreateResponse() { Message = "Persona creada con exito"};
            
            
           
        }
        
    }

    public class PersonCreateRequest
    {
        [Required(ErrorMessage ="El id es un campo requerido")]
        public int Identificacion { get; set; }
        [Required(ErrorMessage ="El nombre es un campo requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage ="El apellido es un campo requerido")]
        public  string Surname { get; set; }
        
        [Required]
        public  string Phone { get; set; }
        public  string Mail { get; set; }
        public  string Direction { get; set; }
        
        [Required(ErrorMessage ="El tipo es un campo requerido")]
        public  string Type { get; set; }
        
        public Person Map()
        {
            var person = new PersonFactory().FactoryMethod(Type);
            person.Identificacion = Identificacion;
            person.Name = Name;
            person.Surname = Surname;
            person.Phone = Phone;
            person.Mail = Mail;
            person.Direction = Direction;
            return person;
        }
    }
    
    public class PersonCreateResponse
    {
        public string Message { get; set; }
    }
}