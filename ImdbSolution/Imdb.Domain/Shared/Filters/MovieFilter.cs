using System.Collections.Generic;
using Imdb.Domain.MovieAggregate.Dtos;

namespace Imdb.Domain.Shared.Filters
{
    public class MovieFilter : GenericFilter<MovieForGet>
    {
        public string Diretor { get; set; }
        public string Genre { get; set; }
        public string Name { get; set; }
        public string Actor { get; set; }
    }
}
