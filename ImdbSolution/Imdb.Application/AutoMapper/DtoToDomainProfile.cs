using System.Collections.Generic;
using AutoMapper;
using Imdb.Domain.AuthAggregate.Dtos;
using Imdb.Domain.AuthAggregate.Entities;
using Imdb.Domain.MovieAggregate.Dtos;
using Imdb.Domain.MovieAggregate.Entities;

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

            CreateMap<MovieForRegisterDto, Movie>()
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom<MovieActorsResolver>());
        }
    }

    public class MovieActorsResolver : IValueResolver<MovieForRegisterDto, Movie, ICollection<MovieActor>>
    {
        public ICollection<MovieActor> Resolve(MovieForRegisterDto source, Movie destination, 
            ICollection<MovieActor> destMember, ResolutionContext context)
        {
            var list = new List<MovieActor>();

            foreach (var actor in source.Actors)
            {
                var movieActor = new MovieActor
                {
                    Actor = new Actor{Active = true, Name = actor.Name},
                    Movie = destination
                };
                list.Add(movieActor);
            }

            return list;
        }
    }
}
