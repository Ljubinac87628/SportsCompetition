using AutoMapper;
using DatabaseAccessLayer.Repositories;
using Services.Models;
using System.Collections.Generic;

namespace Services
{
    public class CompetitionTypeService : ICompetitionTypeService
    {
        private IMapper _mapper;

        public CompetitionTypeService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<CompetitionTypeView> GetAllCompetitionTypes()
        {
            using (var uow = new UnitOfWork())
            {
                var competitionTypes = uow.CompetitionTypeRepository.GetAll();
                var competitionTypesResult = _mapper.Map<List<CompetitionTypeView>>(competitionTypes);
                return competitionTypesResult;
            }
        }
    }
}
