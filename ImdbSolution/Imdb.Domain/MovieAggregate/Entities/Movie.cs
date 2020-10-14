using System.Collections.Generic;
using Imdb.Domain.Shared.Entities;

namespace Imdb.Domain.MovieAggregate.Entities
{
    public class Movie : Entity
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }

        public virtual ICollection<MovieActor> Actors { get; set; }
    }
}
