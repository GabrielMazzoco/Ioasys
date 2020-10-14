using Imdb.Domain.MovieAggregate.Dtos;
using Imdb.Domain.Shared.Filters;

namespace Imdb.Domain.MovieAggregate.Services
{
    public interface IMovieService
    {
        void RegisterMovie(MovieForRegisterDto movieForRegisterDto);
        MovieFilter GetMovies(MovieFilter filter);
        MovieForGet GetMovie(int idMovie);
    }
}
