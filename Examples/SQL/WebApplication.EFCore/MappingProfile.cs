using AutoMapper;
using Database.EFCore.Entities;

namespace WebApplication.EFCore
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<News, NewsDto>()
                .ForMember(
                    dst => dst.User, 
                    opt => opt.MapFrom(src => src.User.Name))
                .ForMember(
                    dst => dst.Title,
                    opt => opt.MapFrom(src => src.Title));
        }
    }
}