using Imdb.Domain.AuthAggregate.Entities;

namespace Imdb.Domain.MovieAggregate.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdMovie { get; set; }
        public decimal Rating { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
