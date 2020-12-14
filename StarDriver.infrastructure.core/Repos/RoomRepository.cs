using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public Room getAllData(int id)
        {
            return _dbset.Include(x => x.Instructor).Include(t => t.DevelopmentPlan).Include(v => v._apprentice).Single(y => y.Id == id);
        }
    }
}