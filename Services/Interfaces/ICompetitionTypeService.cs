using Services.Models;
using System.Collections.Generic;

namespace Services
{
    public interface ICompetitionTypeService
    {
        List<CompetitionTypeView> GetAllCompetitionTypes();
    }
}