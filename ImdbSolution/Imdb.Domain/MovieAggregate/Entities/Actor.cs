using System.Collections.Generic;
using Imdb.Domain.Shared.Entities;

namespace Imdb.Domain.MovieAggregate.Entities
{
    public class Actor : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<MovieActor> Movies { get; set; }
    }
}
