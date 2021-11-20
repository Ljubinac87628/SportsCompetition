using DatabaseAccessLayer.Repositories;
using System;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompetitionRepository CompetitionRepository { get; }

        ICompetitionTypeRepository CompetitionTypeRepository { get; }

        IUserGroupRepository UserGroupRepository { get; }

        IUserGroupRolesRepository UserGroupRolesRepository { get; }

        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }

        int Commit();
        Task<int> CommitAsync();
    }
}
