using Microsoft.AspNetCore.Mvc;
using StarDriver.application.core.DevPlanServices;
using StarDriver.domain.core.Contracts;

namespace WebApplication.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class DevPlansController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DevPlansController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public ActionResult<CreateDevPlanResponse> Post(CreateDevPlanRequest request)
        {
            var service = new CreateDevPlanService(_unitOfWork);
            var response = service.Run(request);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<GetDevPlanResponse> Get()
        {
            var service = new GetDevPlanService(_unitOfWork);
            var response = service.Run();
            return Ok(response);
        }
        
        [Route("GetDevPlan")]
        [HttpGet]
        public ActionResult<GetDevPlanResponse> GetById([FromQuery] int id)
        {
            var service = new GetDevPlanService(_unitOfWork);
            var response = service.Run(id);
            return Ok(response);
        }
    }
}