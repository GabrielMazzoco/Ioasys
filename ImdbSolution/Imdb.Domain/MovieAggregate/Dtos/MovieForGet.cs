using System.Collections.Generic;

namespace Imdb.Domain.MovieAggregate.Dtos
{
    public class MovieForGet
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public decimal Rating { get; set; }

        public List<ActorDto> Actors { get; set; }
    }
}
