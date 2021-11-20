using DatabaseAccessLayer.Interfaces;

namespace DatabaseAccessLayer.Repositories
{
	public class CountryRepository : Repository<Country, int>, ICountryRepository
	{
		public CountryRepository(SportsCompetitionDbContext context, bool track) : base(context, track)
		{
		}
    }
}