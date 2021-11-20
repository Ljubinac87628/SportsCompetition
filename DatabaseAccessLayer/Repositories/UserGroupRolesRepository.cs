using DatabaseAccessLayer.Interfaces;
using System.Collections.Generic;

namespace DatabaseAccessLayer.Repositories
{
    public class UserGroupRolesRepository : Repository<UserGroupRole, int>, IUserGroupRolesRepository
    {
        public UserGroupRolesRepository(SportsCompetitionDbContext context, bool track) : base(context, track)
        {
        }

    }
}