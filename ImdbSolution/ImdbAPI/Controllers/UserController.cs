using Imdb.Domain.AuthAggregate.Dtos;
using Imdb.Domain.AuthAggregate.Services;
using Microsoft.AspNetCore.Mvc;

namespace Imdb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] UserForRegisterDto userForRegisterDto)
        {
            _userService.RegisterUser(userForRegisterDto);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserForUpdateDto userForUpdateDto)
        {
            _userService.UpdateUser(userForUpdateDto);

            return Ok();
        }

        [HttpDelete("inativar")]
        public IActionResult UpdateAdmin()
        {
            _userService.InactivateUser();

            return Ok();
        }
    }
}
