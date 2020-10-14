using System.Security.Claims;
using System.Threading.Tasks;
using Imdb.Domain.MovieAggregate.Dtos;
using Imdb.Domain.MovieAggregate.Entities;
using Imdb.Domain.MovieAggregate.Repositories;
using Imdb.Domain.MovieAggregate.Services;
using Imdb.Domain.Properties;
using Imdb.Domain.Shared.Exceptions;
using Imdb.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Imdb.Application.MovieServices
{
    public class VoteService : IVoteService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMovieRepository _movieRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IVoteRepository _voteRepository;

        public VoteService(IHttpContextAccessor httpContext, 
            IMovieRepository movieRepository, 
            IUnityOfWork unityOfWork, 
            IVoteRepository voteRepository)
        {
            _httpContext = httpContext;
            _movieRepository = movieRepository;
            _unityOfWork = unityOfWork;
            _voteRepository = voteRepository;
        }

        public void VoteRating(RatingMovie ratingMovie)
        {
            var userId = int.Parse(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var movie = _movieRepository.GetById(ratingMovie.IdMovie);

            if (movie is null) throw new CoreException(Resources.FilmeInexistente);

            var vote = new Vote { IdMovie = movie.Id, IdUser = userId, Rating = ratingMovie.Rating };

            _voteRepository.CreateVote(vote);

            _unityOfWork.Commit();

            UpdateRatingMovie(movie);
        }

        private async Task UpdateRatingMovie(Movie movie)
        {
            movie.NumberOfVotes += 1;

            movie.Rating = _voteRepository.GetRating(movie.NumberOfVotes);

            _movieRepository.Update(movie);

            _unityOfWork.Commit();
        }
    }
}
