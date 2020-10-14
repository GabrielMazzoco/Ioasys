using Imdb.Domain.MovieAggregate.Entities;

namespace Imdb.Domain.MovieAggregate.Repositories
{
    public interface IVoteRepository
    {
        void CreateVote(Vote vote);
        decimal GetRating(int numberOfVotes);
    }
}
