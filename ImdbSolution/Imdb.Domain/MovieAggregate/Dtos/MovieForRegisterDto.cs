using System.Collections.Generic;

namespace Imdb.Domain.MovieAggregate.Dtos
{
    public class MovieForRegisterDto
    {
        public string Name { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }

        public List<ActorDto> Actors { get; set; }
    }
}
