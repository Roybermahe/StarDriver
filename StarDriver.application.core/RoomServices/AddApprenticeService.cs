using System.ComponentModel.DataAnnotations;
using StarDriver.domain.core.Business.Persons;
using StarDriver.domain.core.Contracts;
using StarDriver.infrastructure.core.Repos;

namespace StarDriver.application.core.RoomServices
{
    public class AddApprenticeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddApprenticeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public AddApprenticeResponse Ejecutar(AddApprenticeRequest request)
        {
            var room = ((RoomRepository) _unitOfWork.RoomRepository).getAllData(request.IdRoom);
            var apprentice = _unitOfWork.PersonsRepository.FindFirstOrDefault(t => t.Id == request.IdApprentice);
            if (apprentice == null) return new AddApprenticeResponse(){ Message = "Este aprendiz no existe."};
            var result = room.AddApprentices(((Apprentice)apprentice));
            _unitOfWork.RoomRepository.Edit(room);
            _unitOfWork.Commit();
            return new AddApprenticeResponse() { Message = result };
        }
        
        public AddApprenticeResponse EjecutarRemove(AddApprenticeRequest request)
        {
            var room = ((RoomRepository) _unitOfWork.RoomRepository).getAllData(request.IdRoom);
            var apprentice = _unitOfWork.PersonsRepository.FindFirstOrDefault(t => t.Id == request.IdApprentice);
            if (apprentice == null) return new AddApprenticeResponse(){ Message = "Este aprendiz no existe."};
            room._apprentice.RemoveAll(t => t.Id == request.IdApprentice);
            _unitOfWork.RoomRepository.Edit(room);
            _unitOfWork.Commit();
            return new AddApprenticeResponse() { Message = "El aprendiz fue removido" };
        }
    }

    public class AddApprenticeRequest
    {
        [Required]
        public int IdRoom { get; set; }
        [Required]
        public int IdApprentice { get; set; }
    }

    public class AddApprenticeResponse
    {
        public string Message { get; set; }
    }
}