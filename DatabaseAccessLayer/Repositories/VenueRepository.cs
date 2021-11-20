using DatabaseAccessLayer.Interfaces;

namespace DatabaseAccessLayer.Repositories
{
	public class VenueRepository : Repository<Venue, int>, IVenueRepository
	{
		public VenueRepository(SportsCompetitionDbContext context, bool track) : base(context, track)
		{
		}
    }
}