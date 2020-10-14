using Imdb.Domain.AuthAggregate.Dtos;
using Imdb.Domain.AuthAggregate.Services;
using Imdb.Domain.Shared.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Imdb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Endpoint listar os usuarios do Sistema permitindo paginacao
        /// </summary>
        /// <response code="200"></response>
        [HttpGet]
        public IActionResult GetUsers([FromQuery] GenericFilter<UsersForList> filter)
        {
            var result = _userService.GetUsers(filter);

            return Ok(result.Items);
        }

        /// <summary>
        /// Endpoint para registrar um usuario Admin no sistema
        /// </summary>
        /// <response code="201"></response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegisterAdmin([FromBody] AdminForRegisterDto adminForRegisterDto)
        {
            _userService.RegisterAdmin(adminForRegisterDto);

            return Created($"{nameof(AdminController)}", new {});
        }

        /// <summary>
        /// Endpoint para editar um usuario Admin.
        /// </summary>
        /// <response code="200"></response>
        [HttpPut]
        public IActionResult UpdateAdmin([FromBody] UserForUpdateDto userForUpdateDto)
        {
            _userService.UpdateUser(userForUpdateDto);

            return Ok();
        }

        /// <summary>
        /// Endpoint para que um admin possa desativar outros usuarios.
        /// </summary>
        /// <response code="200"></response>
        [HttpDelete("inativar/{userId}")]
        public IActionResult InactivateAdmin([FromRoute] int userId)
        {
            _userService.InactivateUserAsAdmin(userId);

            return Ok();
        }
    }
}
