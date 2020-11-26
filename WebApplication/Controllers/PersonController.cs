using Microsoft.AspNetCore.Mvc;
using StarDriver.application.core.PersonServices;
using StarDriver.domain.core.Contracts;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public ActionResult<PersonCreateResponse> Post(PersonCreateRequest request)
        {
            var service = new CreatePersonServices(_unitOfWork);
            var response = service.Ejecutar(request);
            return Ok(response);
        }

        [HttpPut]
        public ActionResult<UpdatePersonResponse> Put(UpdatePersonRequest request)
        {
            var service = new UpdatePersonService(_unitOfWork);
            var response = service.Ejecutar(request);
            return Ok(response);
        }

        
        [HttpGet]
        public ActionResult<GetPersonResponse> Get()
        {
            var service = new GetPersonService(_unitOfWork);
            var response = service.Ejecutar();
            return Ok(response);
        }
        
        
        [HttpGet("GetPerson")]
        public ActionResult<GetPersonResponse> GetById([FromQuery] int id)
        {
            var service = new GetPersonService(_unitOfWork);
            var response = service.Ejecutar(id);
            return Ok(response);
        }
        
    }
}