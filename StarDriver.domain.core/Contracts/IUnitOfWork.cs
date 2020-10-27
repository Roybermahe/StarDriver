using System;
using StarDriver.domain.core.Base;
using StarDriver.domain.core.Repos;

namespace StarDriver.domain.core.Contracts
{
    public interface IUnitOfWork : IDisposable, IUnitRepos
    {
        int Commit();
    }
}