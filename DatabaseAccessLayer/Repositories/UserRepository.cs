using DatabaseAccessLayer.Interfaces;

namespace DatabaseAccessLayer.Repositories
{
	public class UserRepository : Repository<AspNetUser, string>, IUserRepository
	{
		public UserRepository(SportsCompetitionDbContext context, bool track) : base(context, track)
		{
		}
    }
}