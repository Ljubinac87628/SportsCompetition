using System.Collections.Generic;

namespace DatabaseAccessLayer.Interfaces
{
    public interface ICompetitionRepository : IRepository<Competition, int>
    {
        public IEnumerable<Competition> GetAllCompetitions();
    }
}
