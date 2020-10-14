using Imdb.Domain.AuthAggregate.Dtos;
using Imdb.Domain.AuthAggregate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imdb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Endpoint para logar no sistema e obter o token
        /// para posteriores interacoes no sistema
        /// </summary>
        /// <response code="200"></response>
        [HttpPost("login")]
        public IActionResult LoginAdmin([FromBody] LoginDto loginDto)
        {
            var token = _authService.Login(loginDto);

            return Ok(new { token });
        }
    }
}
