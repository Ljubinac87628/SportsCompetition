using AutoMapper;
using DatabaseAccessLayer.Repositories;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class CompetitionService : ICompetitionService
    {
        private IMapper _mapper;

        public CompetitionService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public CompetitionsViewModel GetCompetitionsViewModel()
        {
            var competitionViewModel = new CompetitionsViewModel();
            using (var uow = new UnitOfWork())
            {
                var competitions = uow.CompetitionRepository.GetAllCompetitions();
                foreach (var competition in competitions)
                {
                    var competition1 = new Competition()
                    {
                        CompetitionTypeName = competition.CompetitionType.Name,
                        CompetitionOrganizerName = competition.CompetitionOrganizer.UserName,
                        VenueName = competition.Venue.Name,                        
                    };

                    foreach (var competitor in competition.CompetitionMembers)
                    {
                        var competitor1 = new Competitor()
                        {
                            Name = competitor.Member.UserName
                        };
                        competition1.Competitors.Add(competitor1);
                    }
                    competitionViewModel.Competitions.Add(competition1);
                }
                return competitionViewModel;
            }
        }
    }
}
