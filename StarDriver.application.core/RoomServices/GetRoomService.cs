using System.Collections.Generic;
using System.Linq;
using StarDriver.domain.core.Business.VirtualRooms;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.RoomServices
{
    public class GetRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public GetRoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetRoomResponse Run()
        {
            var list = _unitOfWork.RoomRepository.GetAll().ToArray();
            return !list.Any() ?
                new GetRoomResponse("No se encontro ningun examen.") : 
                new GetRoomResponse($"Se encontraron {list.Count()} examenes.", roomList: list);
        }

        public GetRoomResponse Run(int id)
        {
            var room = _unitOfWork.RoomRepository.Find(id);
            return room == null
                ? new GetRoomResponse("no se encontro la sala virtual")
                : new GetRoomResponse($"La sala {room.Name} fue encontrada.", room: room);

        }
        
    }

    public class GetRoomResponse
    {
        public  string Message { get; }
        public Room Room { get; }
        public IEnumerable<Room> RoomList { get; }
        
        public GetRoomResponse(string message, IEnumerable<Room> roomList = null, Room room = null)
        {
            Message = message;
            Room = room;
            RoomList = roomList;
        }
    }
}