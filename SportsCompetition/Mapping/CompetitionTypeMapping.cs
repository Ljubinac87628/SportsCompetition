using AutoMapper;
using DatabaseAccessLayer;
using Services.Models;

namespace SportsCompetition.Mapping
{
    public class CompetitionTypeMapping : Profile
    {
        public CompetitionTypeMapping()
        {
            CreateMap<CompetitionTypeView, CompetitionType>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.Id))
            .ForMember(d => d.Name, s => s.MapFrom(s => s.Name));

            CreateMap<CompetitionType, CompetitionTypeView>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.Id))
            .ForMember(d => d.Name, s => s.MapFrom(s => s.Name));
        }
    }
}
