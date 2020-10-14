using Imdb.Domain.MovieAggregate.Dtos;

namespace Imdb.Domain.MovieAggregate.Services
{
    public interface IVoteService
    {
        void VoteRating(RatingMovie ratingMovie);
    }
}
