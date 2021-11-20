using DatabaseAccessLayer.Interfaces;
using System.Collections.Generic;

namespace DatabaseAccessLayer.Repositories
{
	public class CompetitionRepository : Repository<Competition, int>, ICompetitionRepository
	{
		public CompetitionRepository(SportsCompetitionDbContext context, bool track) : base(context, track)
		{	
		}

		public IEnumerable<Competition> GetAllCompetitions()
        {
			return GetAll("CompetitionType,CompetitionMembers.Member,CompetitionOrganizer,Venue");
        }
    }
}