using DatabaseAccessLayer.Interfaces;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportsCompetitionDbContext _context;
        private readonly bool _track;

        public UnitOfWork(SportsCompetitionDbContext context, bool track = true)
        {
            _context = context;
            _track = track;
        }

        public UnitOfWork(bool track = true)
        {
            _context = new SportsCompetitionDbContext();
            _track = track;
        }

        public ICompetitionRepository CompetitionRepository => new CompetitionRepository(_context, _track);
        public ICompetitionTypeRepository CompetitionTypeRepository => new CompetitionTypeRepository(_context, _track);
        public IUserGroupRepository UserGroupRepository => new UserGroupRepository(_context, _track);

        public IUserRepository UserRepository => new UserRepository(_context, _track);

        public IUserGroupRolesRepository UserGroupRolesRepository => new UserGroupRolesRepository(_context, _track);

        public IRoleRepository RoleRepository => new RoleRepository(_context, _track);

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
