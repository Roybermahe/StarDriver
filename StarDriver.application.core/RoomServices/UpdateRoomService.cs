using System.ComponentModel.DataAnnotations;
using StarDriver.domain.core.Business.DevPlans;
using StarDriver.domain.core.Business.Persons;
using StarDriver.domain.core.Business.VirtualRooms;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.RoomServices
{
    public class UpdateRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UpdateRoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       public UpdateRoomResponse Run(UpdateRoomRequest request)
       {
           
           var saveOption = _unitOfWork.RoomRepository.Find(request.RoomId);
           if (saveOption == null)
           {
               return new UpdateRoomResponse(){Message = "La sala virtual que desea actualizar no esta registrada"};
           }
           
           var instructor = (Instructor) _unitOfWork.PersonsRepository.Find(request.IdInsturctor);
           var devPlan = _unitOfWork.DevPlanRepository.Find(request.IdDevPlan);
            
           if (instructor == null)
           {
               return new UpdateRoomResponse() {Message = "El instructor que desea modificar no se encuentra registrado."};
           }

           if (devPlan == null)
           {
               return new UpdateRoomResponse() {Message = "El plan de desarrollo que desea modificar no se encuentra registrado."};
           }

           request.Map(saveOption );

           saveOption.Instructor = instructor;
           saveOption.DevelopmentPlan = devPlan;
           
           
           
           _unitOfWork.RoomRepository.Edit(saveOption);
           _unitOfWork.Commit();
           return new UpdateRoomResponse(){Message = "La sala virtual fue actualizada."};
           
       }

    }
    
    public class UpdateRoomRequest
    {
        [Required(ErrorMessage = "Es necesario el Id de la sala virtual.")]
        public int RoomId { get; set; }
        
        [Required(ErrorMessage = "Es necesario el Nombre de la sala virtual.")]
        public string Name { get; set; }
            
        [Required(ErrorMessage = "Es necesaria la descripción de la sala virtual.")]
        public string Description { get; set; }
            
        [Required(ErrorMessage = "Es necesario el estado de la sala virtual. => creado, en curso, pausado, finalizado.")]
        public string State { get; set; }
        
        [Required(ErrorMessage = "Es necesaria la identificación del instructor asignado a la sala virtual.")]
        public int IdInsturctor { get; set; }
        
        [Required(ErrorMessage = "Es necesaria la id del plan de desarrollo asignado a la sala virtual.")]
        public int IdDevPlan { get; set; }

        public void Map(Room room)
        {
            room.Name = Name;
             room.Description = Description;
             room.State = State;
        }
    }
    
    public class UpdateRoomResponse
    {
        public string Message { get; set; }
    }
    
}