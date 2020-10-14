using System.ComponentModel.DataAnnotations;

namespace Imdb.Domain.MovieAggregate.Dtos
{
    public class RatingMovie
    {
        public int IdMovie { get; set; }
        [Range(0, 4, ErrorMessage = "Valor deve estar entre 0 e 4")]
        public decimal Rating { get; set; }
    }
}
