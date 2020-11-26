using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StarDriver.application.core;
using StarDriver.application.core.RoomServices;
using StarDriver.domain.core.Contracts;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
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
        public ActionResult<UpdateRoomResponse> Post(UpdateRoomRequest request)
        {
            var service = new UpdateRoomService(_unitOfWork);
            var response = service.Run(request);
            return Ok(response);
        }
        
    }
}