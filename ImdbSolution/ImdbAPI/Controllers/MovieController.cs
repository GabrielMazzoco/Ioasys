using Imdb.Domain.MovieAggregate.Dtos;
using Imdb.Domain.MovieAggregate.Services;
using Imdb.Domain.Shared.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imdb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IVoteService _voteService;

        public MovieController(IMovieService movieService, IVoteService voteService)
        {
            _movieService = movieService;
            _voteService = voteService;
        }

        /// <summary>
        /// Registra um filme no sistema com os atores desse filme
        /// </summary>
        /// <response code="201"></response>
        [HttpPost]
        public IActionResult RegisterMovie([FromBody] MovieForRegisterDto movieForRegisterDto)
        {
            _movieService.RegisterMovie(movieForRegisterDto);

            return Created($"{nameof(MovieController)}", new { });
        }

        /// <summary>
        /// Endpoint para um usuario poder votar em um determinado filme.
        /// </summary>
        /// <response code="200"></response>
        [HttpPost("vote")]
        public IActionResult VoteRating([FromBody] RatingMovie ratingMovie)
        {
            _voteService.VoteRating(ratingMovie);

            return Ok();
        }

        /// <summary>
        /// Endpoint para listar todos os filmes permitindo paginacao e alguns filtros
        /// </summary>
        /// <response code="200"></response>
        [HttpGet]
        public IActionResult GetMovies([FromQuery] MovieFilter filter)
        {
            var result = _movieService.GetMovies(filter);

            return Ok(result.Items);
        }


        /// <summary>
        /// Endpoint para buscar um filme especifico no banco e suas informacoes
        /// </summary>
        /// <response code="200"></response>
        [HttpGet("{idMovie}")]
        public IActionResult GetMovies([FromRoute] int idMovie)
        {
            var result = _movieService.GetMovie(idMovie);

            return Ok(result);
        }
    }
}
