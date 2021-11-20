using DatabaseAccessLayer.Interfaces;

namespace DatabaseAccessLayer.Repositories
{
    public class UserGroupRepository : Repository<UserGroup, string>, IUserGroupRepository
    {
        private readonly SportsCompetitionDbContext _context;

        public UserGroupRepository(SportsCompetitionDbContext context, bool track) : base(context, track)
        {
        }
    }
}