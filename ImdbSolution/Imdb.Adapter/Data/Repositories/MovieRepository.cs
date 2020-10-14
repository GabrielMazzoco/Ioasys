using System.Linq;
using Imdb.Domain.MovieAggregate.Dtos;
using Imdb.Domain.MovieAggregate.Entities;
using Imdb.Domain.MovieAggregate.Repositories;
using Imdb.Domain.Shared.Filters;
using Microsoft.EntityFrameworkCore;

namespace Imdb.Adapter.Data.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext dbContext) : base(dbContext)
        {
        }

        public MovieFilter GetMovies(MovieFilter filter)
        {
            var query = DbContext.Set<Movie>()
                .Include(x => x.Actors)
                    .ThenInclude(x => x.Actor)
                .Where(x => x.Active);

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Genre))
            {
                query = query.Where(x => x.Genre.ToLower().Contains(filter.Genre.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Diretor))
            {
                query = query.Where(x => x.Director.ToLower().Contains(filter.Diretor.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Actor))
            {
                query = query.Where(x => x.Actors.Any(y => y.Actor.Name.ToLower().Contains(filter.Actor.ToLower())));
            }

            if (filter.ItemsPerPage != 0 && filter.Page != 0)
            {
                query = query.Skip((filter.Page - 1) * filter.ItemsPerPage).Take(filter.ItemsPerPage);
            }

            query = query.OrderBy(x => x.Rating).ThenBy(x => x.Name);

            var result = query.Select(x => new MovieForGet
            {
                Director = x.Director,
                Genre = x.Genre,
                Name = x.Name,
                Rating = x.Rating,
                Actors = x.Actors.Select(y => new ActorDto
                {
                    Name = y.Actor.Name
                }).ToList()
            });

            filter.Items = result.ToList();

            return filter;
        }

        public MovieForGet GetMovie(int idMovie)
        {
            var movie = DbContext.Set<Movie>()
                .Include(x => x.Actors)
                    .ThenInclude(x => x.Actor)
                .FirstOrDefault(x => x.Id == idMovie);

            if (movie is null) return null;

            var movieGet = new MovieForGet
            {
                Director = movie.Director,
                Name = movie.Name,
                Genre = movie.Genre,
                Rating = movie.Rating,
                Actors = movie.Actors.Select(x => new ActorDto
                {
                    Name = x.Actor.Name
                }).ToList()
            };

            return movieGet;
        }
    }
}
