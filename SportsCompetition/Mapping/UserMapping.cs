using AutoMapper;
using DatabaseAccessLayer;
using Services.Models;

namespace SportsCompetition.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<AspNetUser, User>()
            .ForMember(d => d.Id, s => s.MapFrom(c => c.Id))
            .ForMember(d => d.Name, s => s.MapFrom(c => c.UserName))
            .ForMember(d => d.Email, s => s.MapFrom(c => c.Email));

            CreateMap<User, AspNetUser>()
            .ForMember(d => d.Id, s => s.MapFrom(c => c.Id))
            .ForMember(d => d.UserName, s => s.MapFrom(c => c.Name))
            .ForMember(d => d.Email, s => s.MapFrom(c => c.Email));
        }
    }
}
