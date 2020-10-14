using System.Linq;
using Imdb.Domain.MovieAggregate.Entities;
using Imdb.Domain.MovieAggregate.Repositories;

namespace Imdb.Adapter.Data.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly DataContext _dbContext;

        public VoteRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateVote(Vote vote)
        {
            _dbContext.Set<Vote>().Add(vote);
        }

        public decimal GetRating(int numberOfVotes)
        {
            var ratings = _dbContext.Set<Vote>().Select(x => x.Rating).ToList();

            return ratings.Sum() / numberOfVotes;
        }
    }
}
