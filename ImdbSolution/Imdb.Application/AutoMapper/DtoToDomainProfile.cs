using AutoMapper;
using Imdb.Domain.AuthAggregate.Dtos;
using Imdb.Domain.AuthAggregate.Entities;

namespace Imdb.Application.AutoMapper
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<AdminForRegisterDto, User>()
                .ForMember(dest => dest.Admin, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username.ToLower()));

            CreateMap<UserForRegisterDto, User>()
                .ForMember(dest => dest.Admin, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username.ToLower()));

            CreateMap<UserForUpdateDto, User>();
        }
    }
}
