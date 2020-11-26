using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StarDriver.domain.core.Business.DevPlans;
using StarDriver.domain.core.Business.Persons;
using StarDriver.domain.core.Business.VirtualRooms;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.RoomServices
{
    public class CreateRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateRoomResponse Run(CreateRoomRequest request)
        {
            var room = request.Map();
            
            var instructor = (Instructor) _unitOfWork.PersonsRepository.Find(request.IdInsturctor);
            var devPlan = _unitOfWork.DevPlanRepository.Find(request.IdDevPlan);
            
            if (instructor == null)
            {
                return new CreateRoomResponse() {Message = "El instructor ingresado no se encuentra registrado."};
            }

            if (devPlan == null)
            {
                return new CreateRoomResponse() {Message = "El plan de desarrollo ingresado no se encuentra registrado."};
            }

            room.Instructor = instructor;
            room.DevelopmentPlan = devPlan;
            
            _unitOfWork.RoomRepository.Add(room);
            _unitOfWork.Commit();
            return new CreateRoomResponse() {Message = "El salon fue creado con exito."};
            
        }

    }
    
    public class CreateRoomRequest
    {
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

        public Room Map()
        { 
            return new Room(){Name = Name, Description = Description, State = State};
        }
            
    }
    
    public class CreateRoomResponse
    {
        public string Message { get; set; }
    }


}