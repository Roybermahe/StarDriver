using StarDriver.domain.core;
using StarDriver.domain.core.Repos;
using StarDriver.infrastructure.core.Base;

namespace StarDriver.infrastructure.core.Repos
{
    public class MainThemeRepository: GenericRepository<MainTheme>, IMainThemeRepository
    {
        public MainThemeRepository(IDbContext context) : base(context)
        {
        }
    }
}