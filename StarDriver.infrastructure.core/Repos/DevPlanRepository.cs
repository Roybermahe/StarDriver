using StarDriver.domain.core;
using StarDriver.domain.core.Repos;
using StarDriver.infrastructure.core.Base;

namespace StarDriver.infrastructure.core.Repos
{
    public class DevPlanRepository : GenericRepository<DevelopmentPlan>, IDevPlanRepository
    {
        public DevPlanRepository(IDbContext context) : base(context)
        {
        }
    }
}