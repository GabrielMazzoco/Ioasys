using System.Security.Claims;
using AutoMapper;
using Imdb.Domain.AuthAggregate.Repositories;
using Imdb.Domain.MovieAggregate.Dtos;
using Imdb.Domain.MovieAggregate.Entities;
using Imdb.Domain.MovieAggregate.Repositories;
using Imdb.Domain.MovieAggregate.Services;
using Imdb.Domain.Properties;
using Imdb.Domain.Shared.Exceptions;
using Imdb.Domain.Shared.Filters;
using Imdb.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Imdb.Application.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _userRepository;

        public MovieService(IMapper mapper, 
            IMovieRepository movieRepository, 
            IUnityOfWork unityOfWork, 
            IHttpContextAccessor httpContext, IUserRepository userRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
            _unityOfWork = unityOfWork;
            _httpContext = httpContext;
            _userRepository = userRepository;
        }

        public void RegisterMovie(MovieForRegisterDto movieForRegisterDto)
        {
            var userId = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _userRepository.GetById(userId);

            if (!user.Admin) throw new CoreException(Resources.RegistrarFilmeSemPermissao);

            var movie = _mapper.Map<Movie>(movieForRegisterDto);

            _movieRepository.Create(movie);

            _unityOfWork.Commit();
        }

        public MovieFilter GetMovies(MovieFilter filter)
        {
            var result = _movieRepository.GetMovies(filter);

            return result;
        }

        public MovieForGet GetMovie(int idMovie)
        {
            var result = _movieRepository.GetMovie(idMovie);

            return result;
        }
    }
}
