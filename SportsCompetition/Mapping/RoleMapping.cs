using AutoMapper;
using DatabaseAccessLayer;
using Services.Models;

namespace SportsCompetition.Mapping
{
    public class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<AspNetRole, Role>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.Id))
            .ForMember(d => d.Name, s => s.MapFrom(s => s.Name));

            CreateMap<Role, AspNetRole>()
            .ForMember(d => d.Id, s => s.MapFrom(s => s.Id))
            .ForMember(d => d.Name, s => s.MapFrom(s => s.Name));
        }
    }
}
