using DatabaseAccessLayer.Interfaces;

namespace DatabaseAccessLayer.Repositories
{
	public class RoleRepository : Repository<AspNetRole, string>, IRoleRepository
	{
		public RoleRepository(SportsCompetitionDbContext context, bool track) : base(context, track)
		{
		}
    }
}