using System.ComponentModel.DataAnnotations;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Business.Persons;
using StarDriver.domain.core.Contracts;
using StarDriver.domain.core.Factorys.Persons;

namespace StarDriver.application.core.PersonServices
{
    public class UpdatePersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UpdatePersonResponse Ejecutar(UpdatePersonRequest request)
        {
            var person = _unitOfWork.PersonsRepository.Find(request.Id);
            if(person == null) return new UpdatePersonResponse() {Message = "La persona no existe"};
            person = request.Map(person);
            _unitOfWork.PersonsRepository.Edit(person);
            _unitOfWork.Commit();
            return new UpdatePersonResponse() { Message = "La persona fue actualizada."};
        }
    }
    
    public class UpdatePersonRequest
    {
        [Required(ErrorMessage ="El id es un campo requerido")]
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public  string Surname { get; set; }
        

        public  string Phone { get; set; }
        public  string Mail { get; set; }
        public  string Direction { get; set; }
        
        public Person Map(Person person)
        {
           
            person.Name = Name;
            person.Surname = Surname;
            person.Phone = Phone;
            person.Mail = Mail;
            person.Direction = Direction;
            return person ;
        }
        
    }
    
    public class UpdatePersonResponse
    {
        public string Message { get; set; }
    }
}