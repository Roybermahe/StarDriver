using StarDriver.domain.core;
using StarDriver.domain.core.Business.VirtualRooms;
using StarDriver.domain.core.Repos;
using StarDriver.infrastructure.core.Base;

namespace StarDriver.infrastructure.core.Repos
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(IDbContext context) : base(context)
        {
        }
    }
}