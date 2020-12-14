using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StarDriver.application.core;
using StarDriver.application.core.RoomServices;
using StarDriver.domain.core.Contracts;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public ActionResult<CreateRoomResponse> Post(CreateRoomRequest request)
        {
            var service = new CreateRoomService(_unitOfWork);
            var response = service.Run(request);
            return Ok(response);
        }
        
        
        [HttpPut]
        public ActionResult<UpdateRoomResponse> Put(UpdateRoomRequest request)
        {
            var service = new UpdateRoomService(_unitOfWork);
            var response = service.Run(request);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<GetRoomResponse> Get()
        {
            var service = new GetRoomService(_unitOfWork);
            var response = service.Run();
            return Ok(response);
        }
        
        [Route("GetRoom")]
        [HttpGet]
        public ActionResult<GetRoomResponse> GetById([FromQuery] int id)
        {
            var service = new GetRoomService(_unitOfWork);
            var response = service.Run(id);
            return Ok(response);
        }

        [Route("Apprentices")]
        [HttpPost]
        public ActionResult<AddApprenticeResponse> AddApprentices(AddApprenticeRequest request)
        {
            var service = new AddApprenticeService(_unitOfWork);
            var response = service.Ejecutar(request);
            return Ok(response);
        }
        
        [Route("RemoveApprentices")]
        [HttpPost]
        public ActionResult<AddApprenticeResponse> RemoveApprentices(AddApprenticeRequest request)
        {
            var service = new AddApprenticeService(_unitOfWork);
            var response = service.EjecutarRemove(request);
            return Ok(response);
        }
        
    }
}