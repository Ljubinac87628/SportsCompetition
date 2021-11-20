namespace DatabaseAccessLayer.Repositories
{
	public class CompetitionTypeRepository : Repository<CompetitionType, int>, ICompetitionTypeRepository
	{
		public CompetitionTypeRepository(SportsCompetitionDbContext context, bool track) : base(context, track)
		{	
		}
    }
}