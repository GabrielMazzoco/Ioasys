namespace Imdb.Domain.MovieAggregate.Entities
{
    public class MovieActor
    {
        public int Id { get; set; }
        public int IdMovie { get; set; }
        public int IdActor { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
