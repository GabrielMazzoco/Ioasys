using Imdb.Domain.MovieAggregate.Dtos;
using Imdb.Domain.MovieAggregate.Entities;
using Imdb.Domain.Shared.Filters;
using Imdb.Domain.Shared.Interfaces;

namespace Imdb.Domain.MovieAggregate.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        MovieFilter GetMovies(MovieFilter filter);
        MovieForGet GetMovie(int idMovie);
    }
}
